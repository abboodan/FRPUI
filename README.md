# FRP Client Manager

A robust Windows Forms application to manage the FRP Client (`frpc.exe`) on Windows. Built with .NET and C#.

> This tool is a GUI wrapper for **[fatedier/frp](https://github.com/fatedier/frp)**, a fast reverse proxy to help you expose a local server behind a NAT or firewall to the internet.

## Features

- **Process Management**: Start and Stop `frpc` safely. Handles crashes and unexpected exits.
- **Live Logs**: View real-time `stdout` and `stderr` logs from the frpc process directly in the UI.
- **Configuration Editor**: Built-in TOML editor with validation. Prevents saving invalid configs.
- **Safe Restart**: Warns if you try to save config while running, offering a "Save & Restart" workflow.
- **Tools & Diagnostics**:
    - **Local Test Server**: Built-in HTTP server to test your FRP setup locally without external tools.
    - **Port Checker**: Verify if ports are open on local or remote hosts.
    - **Public IP**: Quickly check your external IP address.
    - **Server Ping**: Measure latency to your FRP server.
    - **Process Monitor**: Real-time RAM and CPU usage stats for the `frpc` process.
- **Dependency Checks**: Automatically detects if `frpc.exe` or `frpc.toml` are missing and helps you set them up.

## Requirements

- **OS**: Windows 10/11
- **Runtime**: .NET Desktop Runtime (10.0, 9.0 or 8.0 depending on build)
- **FRP**: Requires `frpc.exe` (v0.50.0+ recommended)

## Setup

1. **Download/Build**: Extract the application or build the solution.
2. **First Run**:
   - The app looks for a `/frp` folder next to the executable.
   - If missing, a Setup dialog will appear.
   - You can click **Download from GitHub** to get `frpc.exe`.
   - Click **Create Default Config** to generate a template `frpc.toml`.
   - Use **Browse** to select your `frpc.exe` and it will be copied to the local `/frp` folder.
3. **Usage**:
   - **Dashboard**: Click **Start** to run the proxy. View logs in the black console window.
   - **Editor**: Switch to the **Config Editor** tab to modify `frpc.toml`. Click **Save & Restart** to apply changes immediately.

## Directory Structure

```text
/FRPUI.exe          # Main Application
/frp/
    frpc.exe        # The actual frp client binary
    frpc.toml       # Configuration file
    frpc.toml.bak   # Automatic backup created on save
```

## Development

- **IDE**: Visual Studio 2022 / VS Code
- **Framework**: .NET 10.0 (Change to `net8.0-windows` in `.csproj` if needed)
- **Dependencies**: 
  - `Tomlyn` (NuGet) for TOML parsing.

## Build

```powershell
dotnet restore
dotnet build -c Release
```
