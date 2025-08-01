# AI Search - Quick Setup Guide

## 🚀 Quick Start

### Prerequisites
- Windows 10/11
- .NET 8.0 Runtime (download from https://dotnet.microsoft.com/download/dotnet/8.0)
- Google Chrome (for opening searches)

### Installation Steps

1. **Download and Extract**
   - Download the project files
   - Extract to a folder (e.g., `C:\AI-SEARCH`)

2. **Run the Application**
   ```powershell
   # Option 1: Using PowerShell (recommended)
   .\run.ps1
   
   # Option 2: Using Command Prompt
   run.bat
   
   # Option 3: Direct .NET command
   dotnet run
   ```

3. **First Run**
   - The application will start in the system tray
   - Look for the application icon in the notification area
   - Press `Ctrl+Space` to open the search

## 🎯 How to Use

### Basic Usage
1. **Open Search**: Press `Ctrl+Space` from anywhere
2. **Type Query**: Enter your search term
3. **Execute**: Press `Enter` to search with Gemini
4. **Close**: Press `Escape` or click outside

### System Tray Menu
- **Right-click** the tray icon for options:
  - Open Search
  - Settings
  - Exit

### Settings
- **Hotkey**: Change the global shortcut
- **Auto-start**: Launch with Windows
- **Behavior**: Configure window behavior

## 🔧 Troubleshooting

### Common Issues

**Application won't start:**
- Ensure .NET 8.0 is installed
- Run as administrator if needed
- Check Windows Defender settings

**Hotkey not working:**
- Check if another app uses `Ctrl+Space`
- Try running as administrator
- Restart the application

**Chrome not opening:**
- Ensure Chrome is installed
- Set Chrome as default browser
- Check internet connection

### Getting Help
- Check the full README.md for detailed documentation
- Look for error messages in the console output
- Restart the application if issues persist

## 🎨 Features

- ✅ Global hotkey (`Ctrl+Space`)
- ✅ System tray integration
- ✅ Modern UI (similar to macOS Spotlight)
- ✅ Gemini web search integration
- ✅ Real-time search suggestions
- ✅ Settings configuration
- ✅ Auto-start with Windows

## 📁 Project Structure

```
AI-SEARCH/
├── SearchApp.csproj          # Project configuration
├── App.xaml                  # Application resources
├── App.xaml.cs              # System tray & hotkeys
├── MainWindow.xaml          # Search UI
├── MainWindow.xaml.cs       # Search logic
├── SettingsWindow.xaml      # Settings UI
├── SettingsWindow.xaml.cs   # Settings logic
├── GlobalHotkeyManager.cs   # Hotkey handling
├── run.ps1                  # PowerShell launcher
├── run.bat                  # Batch launcher
├── README.md               # Full documentation
└── SETUP_GUIDE.md          # This file
```

## 🚀 Next Steps

1. **Customize**: Modify hotkeys in Settings
2. **Auto-start**: Enable "Start with Windows" in Settings
3. **Explore**: Try different search queries
4. **Share**: Tell others about the app!

---

**Enjoy your new system-wide search experience! 🎉** 