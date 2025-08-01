# AI Search - System-Wide Search Application

A Windows system application that provides a Spotlight-like search experience, allowing you to quickly search using Google Gemini with automated browser interaction.

## Features

- **Global Hotkey**: Press `Ctrl+Space` from anywhere to open the search
- **System Tray Integration**: Runs in the background with system tray icon
- **Modern UI**: Clean, minimalist interface similar to macOS Spotlight
- **Gemini Integration**: Automatically opens Chrome, navigates to Gemini, and submits your query
- **Automated Search**: Your query is automatically typed and submitted to Gemini
- **Keyboard Navigation**: Full keyboard support (Enter to search, Escape to close)
- **Simple Operation**: Opens a new Chrome instance for each search

## Screenshots

The application features a clean interface with:
- Transparent background overlay
- White rounded search container with shadow
- Modern typography and spacing
- Seamless Gemini integration

## Requirements

- Windows 10/11
- .NET 8.0 Runtime
- Google Chrome (for automated searches)
- Internet connection
- Selenium WebDriver (automatically managed)

## Installation

### Option 1: Build from Source

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   cd .net---spotlight-search-master
   ```

2. **Install .NET 8.0 SDK** (if not already installed):
   - Download from: https://dotnet.microsoft.com/download/dotnet/8.0

3. **Build the application:**
   ```bash
   dotnet build
   ```

4. **Run the application:**
   ```bash
   dotnet run
   ```

### Option 2: Download Pre-built Release

1. Download the latest release from the releases page
2. Extract the ZIP file
3. Run `SearchApp.exe`

## Usage

### Starting the Application

1. Run the application
2. The app will start in the system tray (look for the icon in the notification area)
3. You can also double-click the tray icon to open the search window

### Using the Search

1. **Open Search**: Press `Ctrl+Space` from anywhere
2. **Type Query**: Enter your search term in the search box
3. **Execute Search**: Press `Enter` to automatically:
   - Open a new Chrome instance
   - Navigate to Gemini
   - Type your query in the input field
   - Submit the search automatically
4. **Close Search**: Press `Escape` or click outside the search box

### How It Works

The application uses Selenium WebDriver to:
- Launch a new Chrome browser instance
- Navigate to https://gemini.google.com/
- Locate the search input field
- Automatically type your query
- Submit the search with Enter key
- Provide feedback on successful submission

## Configuration

### Changing the Hotkey

To change the global hotkey, modify the `App.xaml.cs` file:

```csharp
// In InitializeGlobalHotkeys() method
hotkeyManager.RegisterHotkey(Keys.Space, ModifierKeys.Control);
```

Common alternatives:
- `Keys.Space, ModifierKeys.Alt` (Alt+Space)
- `Keys.Space, ModifierKeys.Windows` (Win+Space)
- `Keys.F1, ModifierKeys.Control` (Ctrl+F1)

### Auto-start with Windows

To make the application start automatically with Windows:

1. Press `Win+R` and type `shell:startup`
2. Create a shortcut to `SearchApp.exe` in the startup folder

## Development

### Project Structure

```
.net---spotlight-search-master/
├── SearchApp.csproj          # Project file with Selenium dependencies
├── App.xaml                  # Application resources and styles
├── App.xaml.cs              # Application startup and system tray
├── MainWindow.xaml          # Main search window UI
├── MainWindow.xaml.cs       # Search window logic with Selenium automation
├── SettingsWindow.xaml      # Settings window (if implemented)
├── SettingsWindow.xaml.cs   # Settings logic
├── search.ico               # Application icon
├── run.bat                  # Windows batch file to run the app
├── run.ps1                  # PowerShell script to run the app
└── README.md               # This file
```

### Key Components

- **Selenium WebDriver**: Automated browser control for Gemini integration
- **ChromeDriver**: Chrome browser automation
- **System Tray Integration**: Background operation with tray icon
- **WPF UI**: Modern, responsive user interface

### Dependencies

The project uses the following NuGet packages:
- `Selenium.WebDriver` (4.15.0)
- `Selenium.WebDriver.ChromeDriver` (119.0.6045.10500)

### Building for Distribution

```bash
# Create a self-contained executable
dotnet publish -c Release -r win-x64 --self-contained true

# Create a framework-dependent executable (smaller)
dotnet publish -c Release -r win-x64 --self-contained false
```

## Troubleshooting

### Common Issues

1. **Hotkey not working**:
   - Ensure the application has permission to register global hotkeys
   - Check if another application is using the same hotkey
   - Try running as administrator

2. **Chrome automation not working**:
   - Ensure Google Chrome is installed and up to date
   - Check if Chrome is set as the default browser
   - Verify internet connection
   - ChromeDriver is automatically managed by Selenium

3. **Query not being submitted**:
   - Check if Gemini's interface has changed
   - Ensure the page has fully loaded before automation
   - Check for any error messages in the application

4. **Application not starting**:
   - Ensure .NET 8.0 Runtime is installed
   - Check Windows Defender/firewall settings
   - Run as administrator if needed

### Error Messages

The application provides specific error messages for:
- Chrome initialization failures
- Input field not found on Gemini page
- Query submission failures
- General automation errors

## Features in Detail

### Automated Gemini Integration

- **New Browser Instance**: Opens a fresh Chrome window for each search
- **Smart Element Detection**: Tries multiple selectors to find the input field
- **Input Verification**: Confirms that your query was properly entered
- **Automatic Submission**: Submits the search without manual intervention
- **Success Feedback**: Shows confirmation when query is successfully submitted

### User Experience

- **Instant Search**: Type and press Enter for immediate Gemini search
- **No Manual Steps**: No need to manually type in Gemini's interface
- **Background Operation**: Runs silently in system tray
- **Global Access**: Available from anywhere with hotkey
- **Simple Setup**: No complex configuration required

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly with different queries
5. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- Inspired by macOS Spotlight search
- Uses .NET 8.0 and WPF for modern Windows development
- Integrates with Google's Gemini AI platform
- Powered by Selenium WebDriver for browser automation 