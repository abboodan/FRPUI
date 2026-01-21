namespace FRPUI.Models;

public class FrpcConfigSummary
{
    public string ServerAddr { get; set; } = string.Empty;
    public int ServerPort { get; set; }
    public int ProxyCount { get; set; }
}

public enum AppState
{
    Stopped,
    Running,
    Crashed
}
