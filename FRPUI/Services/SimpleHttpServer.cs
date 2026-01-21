using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FRPUI.Services;

public class SimpleHttpServer
{
    private HttpListener? _listener;
    private Task? _listenerTask;
    private CancellationTokenSource? _cts;
    private readonly string _rootPath;
    private readonly int _port;

    public bool IsListening => _listener?.IsListening ?? false;
    public event Action<string>? OnLog;

    public SimpleHttpServer(string rootPath, int port)
    {
        _rootPath = rootPath;
        _port = port;
    }

    public void Start()
    {
        if (_listener != null && _listener.IsListening) return;

        _listener = new HttpListener();
        _listener.Prefixes.Add($"http://*:{_port}/");
        _listener.Start();

        _cts = new CancellationTokenSource();
        _listenerTask = Task.Run(() => Loop(_cts.Token), _cts.Token);
        
        OnLog?.Invoke($"Server started on port {_port}");
        OnLog?.Invoke($"Serving files from: {_rootPath}");
    }

    public void Stop()
    {
        if (_listener == null) return;

        _cts?.Cancel();
        _listener.Stop();
        _listener.Close();
        _listener = null;
        
        OnLog?.Invoke("Server stopped.");
    }

    private async Task Loop(CancellationToken token)
    {
        while (!token.IsCancellationRequested && _listener != null && _listener.IsListening)
        {
            try
            {
                var context = await _listener.GetContextAsync();
                _ = Task.Run(() => ProcessRequest(context));
            }
            catch (HttpListenerException) { break; } // Stopped
            catch (ObjectDisposedException) { break; }
            catch (Exception ex) 
            {
                OnLog?.Invoke($"Server Error: {ex.Message}");
            }
        }
    }

    private void ProcessRequest(HttpListenerContext context)
    {
        try
        {
            var filename = context.Request.Url?.AbsolutePath.Substring(1) ?? "";
            if (string.IsNullOrEmpty(filename)) filename = "index.html";

            var filePath = Path.Combine(_rootPath, filename);

            if (File.Exists(filePath))
            {
                var bytes = File.ReadAllBytes(filePath);
                context.Response.ContentType = "text/html"; // Simplified content type detection could be added
                context.Response.ContentLength64 = bytes.Length;
                context.Response.OutputStream.Write(bytes, 0, bytes.Length);
                context.Response.OutputStream.Close();
                OnLog?.Invoke($"[200] Serving {filename}");
            }
            else
            {
                // If file not found, serve a default message if it's the root matching "test" usage
                string msg = "<html><body><h1>FRPUI Test Server</h1><p>It works!</p></body></html>";
                var bytes = Encoding.UTF8.GetBytes(msg);
                
                context.Response.StatusCode = 404;
                // If it was looking for something specific, 404. If root and index doesn't exist, we could show welcome.
                if (filename == "index.html")
                {
                     context.Response.StatusCode = 200;
                }
                
                context.Response.OutputStream.Write(bytes, 0, bytes.Length);
                context.Response.OutputStream.Close();
                
                if (context.Response.StatusCode == 404)
                    OnLog?.Invoke($"[404] Not Found: {filename}");
            }
        }
        catch (Exception ex)
        {
            OnLog?.Invoke($"Request Error: {ex.Message}");
        }
    }
}
