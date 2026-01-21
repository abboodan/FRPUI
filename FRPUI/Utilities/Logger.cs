using System;

namespace FRPUI.Utilities;

public static class Logger
{
    // Event to broadcast logs to the UI
    public static event Action<string, bool>? OnLog;

    public static void Info(string message)
    {
        OnLog?.Invoke(message, false);
    }

    public static void Error(string message)
    {
        OnLog?.Invoke(message, true);
    }
}
