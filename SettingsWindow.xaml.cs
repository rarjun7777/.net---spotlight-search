using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SearchApp
{
    public partial class SettingsWindow : Window
    {
        private bool isListeningForHotkey = false;
        private Keys currentKey = Keys.Space;
        private ModifierKeys currentModifiers = ModifierKeys.Control;

        public SettingsWindow()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            // Load current settings from registry or config file
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(@"Software\AISearch"))
                {
                    if (key != null)
                    {
                        AutoStartCheckBox.IsChecked = (bool?)key.GetValue("AutoStart", false);
                        CloseOnSearchCheckBox.IsChecked = (bool?)key.GetValue("CloseOnSearch", true);
                        CloseOnFocusLossCheckBox.IsChecked = (bool?)key.GetValue("CloseOnFocusLoss", false);
                    }
                }
            }
            catch
            {
                // Use defaults if settings can't be loaded
                AutoStartCheckBox.IsChecked = false;
                CloseOnSearchCheckBox.IsChecked = true;
                CloseOnFocusLossCheckBox.IsChecked = false;
            }

            UpdateHotkeyDisplay();
        }

        private void SaveSettings()
        {
            try
            {
                using (var key = Registry.CurrentUser.CreateSubKey(@"Software\AISearch"))
                {
                    key?.SetValue("AutoStart", AutoStartCheckBox.IsChecked ?? false);
                    key?.SetValue("CloseOnSearch", CloseOnSearchCheckBox.IsChecked ?? true);
                    key?.SetValue("CloseOnFocusLoss", CloseOnFocusLossCheckBox.IsChecked ?? false);
                    key?.SetValue("HotkeyKey", (int)currentKey);
                    key?.SetValue("HotkeyModifiers", (int)currentModifiers);
                }

                // Update auto-start setting
                UpdateAutoStartSetting();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Failed to save settings: {ex.Message}", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void UpdateAutoStartSetting()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
                {
                    var appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    
                    if (AutoStartCheckBox.IsChecked == true)
                    {
                        key?.SetValue("AISearch", $"\"{appPath}\"");
                    }
                    else
                    {
                        key?.DeleteValue("AISearch", false);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Failed to update auto-start setting: {ex.Message}", "Warning", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
            }
        }

        private void ChangeHotkey_Click(object sender, RoutedEventArgs e)
        {
            isListeningForHotkey = true;
            HotkeyInstructions.Visibility = Visibility.Visible;
            CurrentHotkeyText.Text = "Press keys...";
            
            // Focus the window to capture key events
            Focus();
        }

        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            if (isListeningForHotkey)
            {
                e.Handled = true;
                
                // Convert WPF Key to Windows Forms Keys
                currentKey = ConvertWpfKeyToFormsKey(e.Key);
                currentModifiers = e.KeyboardDevice.Modifiers;

                // Update display
                UpdateHotkeyDisplay();
                
                // Stop listening
                isListeningForHotkey = false;
                HotkeyInstructions.Visibility = Visibility.Collapsed;
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        private Keys ConvertWpfKeyToFormsKey(Key wpfKey)
        {
            return wpfKey switch
            {
                Key.Space => Keys.Space,
                Key.F1 => Keys.F1,
                Key.F2 => Keys.F2,
                Key.F3 => Keys.F3,
                Key.F4 => Keys.F4,
                Key.F5 => Keys.F5,
                Key.F6 => Keys.F6,
                Key.F7 => Keys.F7,
                Key.F8 => Keys.F8,
                Key.F9 => Keys.F9,
                Key.F10 => Keys.F10,
                Key.F11 => Keys.F11,
                Key.F12 => Keys.F12,
                Key.A => Keys.A,
                Key.B => Keys.B,
                Key.C => Keys.C,
                Key.D => Keys.D,
                Key.E => Keys.E,
                Key.F => Keys.F,
                Key.G => Keys.G,
                Key.H => Keys.H,
                Key.I => Keys.I,
                Key.J => Keys.J,
                Key.K => Keys.K,
                Key.L => Keys.L,
                Key.M => Keys.M,
                Key.N => Keys.N,
                Key.O => Keys.O,
                Key.P => Keys.P,
                Key.Q => Keys.Q,
                Key.R => Keys.R,
                Key.S => Keys.S,
                Key.T => Keys.T,
                Key.U => Keys.U,
                Key.V => Keys.V,
                Key.W => Keys.W,
                Key.X => Keys.X,
                Key.Y => Keys.Y,
                Key.Z => Keys.Z,
                _ => Keys.Space // Default fallback
            };
        }

        private void UpdateHotkeyDisplay()
        {
            var modifierText = currentModifiers switch
            {
                ModifierKeys.Control => "Ctrl",
                ModifierKeys.Alt => "Alt",
                ModifierKeys.Shift => "Shift",
                ModifierKeys.Windows => "Win",
                ModifierKeys.Control | ModifierKeys.Alt => "Ctrl + Alt",
                ModifierKeys.Control | ModifierKeys.Shift => "Ctrl + Shift",
                ModifierKeys.Alt | ModifierKeys.Shift => "Alt + Shift",
                _ => ""
            };

            var keyText = currentKey.ToString();
            CurrentHotkeyText.Text = $"{modifierText} + {keyText}";
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
} 