using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using FRPUI.Utilities;
using FRPUI.Models;

namespace FRPUI.Services;

public class FrpcService
{
    private Process? _process;
    private readonly string _exePath;
    private readonly string _configPath;
    private readonly string _workingDir;

    public event Action<AppState>? OnStateChanged;
    public event Action<string, bool>? OnLogReceived;

    public bool IsRunning => _process != null && !_process.HasExited;
    public int ProcessId => _process?.Id ?? 0;
    public DateTime? StartTime { get; private set; }

    public FrpcService(string exePath, string configPath)
    {
        _exePath = exePath;
        _configPath = configPath;
        _workingDir = Path.GetDirectoryName(exePath) ?? string.Empty;
    }

    public async Task StartAsync()
    {
        if (IsRunning) return;

        if (!File.Exists(_exePath))
            throw new FileNotFoundException("frpc.exe not found", _exePath);
        if (!File.Exists(_configPath))
            throw new FileNotFoundException("frpc.toml not found", _configPath);

        var startInfo = new ProcessStartInfo
        {
            FileName = _exePath,
            Arguments = $"-c \"{_configPath}\"",
            WorkingDirectory = _workingDir,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            StandardOutputEncoding = System.Text.Encoding.UTF8,
            StandardErrorEncoding = System.Text.Encoding.UTF8
        };

        _process = new Process { StartInfo = startInfo };
        _process.OutputDataReceived += (s, e) => { if (e.Data != null) OnLogReceived?.Invoke(e.Data, false); };
        _process.ErrorDataReceived += (s, e) => { if (e.Data != null) OnLogReceived?.Invoke(e.Data, true); };
        _process.EnableRaisingEvents = true;
        _process.Exited += (s, e) => HandleExit();

        try 
        {
            _process.Start();
            _process.BeginOutputReadLine();
            _process.BeginErrorReadLine();
            
            StartTime = DateTime.Now;
            OnStateChanged?.Invoke(AppState.Running);
            Logger.Info($"Process started. ID: {_process.Id}");
        }
        catch (Exception ex)
        {
            Logger.Error($"Failed to start process: {ex.Message}");
            _process?.Dispose();
            _process = null;
            throw;
        }

        await Task.CompletedTask;
    }

    public async Task StopAsync()
    {
        if (_process == null || _process.HasExited) return;

        Logger.Info("Stopping process...");
        
        try
        {
            // Try graceful shutdown first by attaching console Ctrl+C if possible,
            // but for NoWindow processes, we often have to resort to Kill or sending signals via specialized Win32 APIs.
            // Since this is a simple manager, we will try Kill directly for now as standard frpc handles it reasonably well,
            // OR if we wanted to be polite we could try CloseMainWindow (only works if it has a window context).
            
            // Note: StartAsync uses CreateNoWindow = true, so CloseMainWindow won't work.
            // Sending SIGINT on Windows to a child process without a window is complex (AttachConsole etc).
            // For now, we will just Kill. It's safe for frpc client.
            
            _process.Kill();
            await _process.WaitForExitAsync();
        }
        catch (Exception ex)
        {
            Logger.Error($"Error stopping process: {ex.Message}");
        }
        finally
        {
            _process?.Dispose();
            _process = null;
        }
    }

    public static void CleanUpExistingProcesses()
    {
        try
        {
            var processes = Process.GetProcessesByName("frpc");
            foreach (var p in processes)
            {
                try
                {
                    // Optionally check path? To be safe, we kill all 'frpc'
                    p.Kill();
                    p.WaitForExit(1000);
                }
                catch 
                { 
                    // Ignore access denied etc
                }
            }
        }
        catch { }
    }

    public (long memoryBytes, TimeSpan cpuTime) GetProcessMetrics()
    {
        if (_process == null || _process.HasExited) return (0, TimeSpan.Zero);
        
        try
        {
            _process.Refresh(); // Important to get latest stats
            return (_process.WorkingSet64, _process.TotalProcessorTime);
        }
        catch 
        {
            return (0, TimeSpan.Zero);
        }
    }

    private void HandleExit()
    {
        // Double check checks if it was intended stop or crash?
        // Actually StopAsync sets _process to null. 
        // If _process is not null here, it means it exited on its own (crash or server disconnect that killed client).
        
        if (_process != null)
        {
            int exitCode = _process.ExitCode;
            // Logger.Info($"Process exited with code {exitCode}"); // Logger removed or not accessible here? 
            // We use event.
            OnStateChanged?.Invoke(exitCode == 0 ? AppState.Stopped : AppState.Crashed);
            
            try { _process.Dispose(); } catch {}
            _process = null;
        }
        else
        {
            OnStateChanged?.Invoke(AppState.Stopped);
        }
    }
}
