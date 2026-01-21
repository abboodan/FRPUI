using System.IO;
using Tomlyn;
using Tomlyn.Model;
using FRPUI.Models;
using System.Text;

namespace FRPUI.Services;

public class TomlConfigService
{
    private readonly string _configPath;

    public TomlConfigService(string configPath)
    {
        _configPath = configPath;
    }

    public string Load()
    {
        if (!File.Exists(_configPath))
            return string.Empty;
            
        // Read content and normalize line endings to CRLF for Windows Forms TextBox
        string content = File.ReadAllText(_configPath);
        return content.Replace("\r\n", "\n").Replace("\n", "\r\n");
    }

    public void Save(string content)
    {
        // 1. Create Backup
        if (File.Exists(_configPath))
        {
            var backupPath = _configPath + ".bak";
            File.Copy(_configPath, backupPath, true);
        }

        // 2. Validate
        Validate(content);

        // 3. Write
        File.WriteAllText(_configPath, content, new UTF8Encoding(false));
    }

    public void Validate(string content)
    {
        // Throws exception if invalid
        Toml.Parse(content);
    }

    public FrpcConfigSummary ParseSummary()
    {
        var summary = new FrpcConfigSummary();
        try
        {
            if (!File.Exists(_configPath)) return summary;

            var content = File.ReadAllText(_configPath);
            var model = Toml.ToModel(content);

            if (model.ContainsKey("serverAddr"))
                summary.ServerAddr = model["serverAddr"]?.ToString() ?? "";
            
            if (model.ContainsKey("serverPort"))
            {
                if (int.TryParse(model["serverPort"]?.ToString(), out int port))
                    summary.ServerPort = port;
            }

            // Count proxies - typical TOML for FRP might have [common] and then [proxy_name] sections.
            // In Tomlyn's model, tables are keys.
            // We assume keys other than "common" might be proxies.
            // Count proxies
            int proxies = 0;

            // 1. New style [[proxies]] array
            if (model.ContainsKey("proxies") && model["proxies"] is TomlTableArray proxyList)
            {
                proxies += proxyList.Count;
            }

            // 2. Old style [section] (excluding common and reserved keys)
            foreach(var key in model.Keys)
            {
                if (key != "common" && key != "proxies")
                {
                    // Check if the value is a table (section)
                    if (model[key] is TomlTable)
                    {
                        proxies++;
                    }
                }
            }
            summary.ProxyCount = proxies;
        }
        catch
        {
            // Ignore parse errors for summary
        }
        return summary;
    }
}
