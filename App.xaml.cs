#nullable enable
using System;
using System.Threading;
using System.Windows;

namespace SearchApp
{
    public partial class App : System.Windows.Application
    {
        private static Mutex? _mutex = null;
        private static MainWindow? _mainWindow = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            // Ensure only one instance of the application is running
            const string mutexName = "SearchApp_SingleInstance_Mutex";
            bool createdNew;
            _mutex = new Mutex(true, mutexName, out createdNew);

            if (!createdNew)
            {
                // Another instance is already running, show the existing window
                if (_mainWindow != null)
                {
                    _mainWindow.ShowAndFocus();
                }
                Shutdown();
                return;
            }

            base.OnStartup(e);
            
            // Create only one main window instance
            if (_mainWindow == null)
            {
                _mainWindow = new MainWindow();
                _mainWindow.ShowAndFocus();
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _mutex?.ReleaseMutex();
            _mutex?.Dispose();
            base.OnExit(e);
        }
    }
} 