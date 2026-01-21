using System.IO;

namespace FRPUI.Services;

public class FileCheckService
{
    private readonly string _frpDir;
    private readonly string _exePath;
    private readonly string _configPath;

    public FileCheckService(string frpDir)
    {
        _frpDir = frpDir;
        _exePath = Path.Combine(frpDir, "frpc.exe");
        _configPath = Path.Combine(frpDir, "frpc.toml");
    }

    public bool AreFilesMissing()
    {
        return !File.Exists(_exePath) || !File.Exists(_configPath);
    }

    public (bool missingExe, bool missingConfig) GetMissingStatus()
    {
        return (!File.Exists(_exePath), !File.Exists(_configPath));
    }

    public void CreateDefaultConfig()
    {
        if (!Directory.Exists(_frpDir))
            Directory.CreateDirectory(_frpDir);

        if (!File.Exists(_configPath))
        {
            string defaultToml = @"serverAddr = ""127.0.0.1""
serverPort = 7000

[[proxies]]
name = ""test-tcp""
type = ""tcp""
localIP = ""127.0.0.1""
localPort = 22
remotePort = 6000
";
            File.WriteAllText(_configPath, defaultToml, new System.Text.UTF8Encoding(false));
        }
    }
}
