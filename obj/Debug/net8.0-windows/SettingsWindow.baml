   M S B A M L   `   `   `  ����  	SearchApp    SearchApp.SettingsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  AI Search Settings��5   	   $	��400��5   	   $	��500��5   	    � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5
      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Settings��5      $��24(�5      $
��Bold"�5      $��0,0,0,20q�5      �� 5   
   $��1��6   $
��Auto=�6$   .��5      �� .+�5      �� $��Global Hotkey��6   $��0,0,0,20q�62   .��5      � $��10q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6/   �� 5       $��* �6/   �� 5!      $
��Auto �6/    5#      �� 5$      $
��Auto �6,   �� 5%      $
��Auto �6,   .+�5(      �� $��0��6$   $��0��61   $��Current Hotkey:��5)   $   $��Center=�5*   $   $��0,0,10,0q�5+   $   �� 5-      -   5         ��Name$ CurrentHotkeyText��5.   $   $��0��5-   $   $��1��61   $��Ctrl + Space��5/   $   $
��Bold"�50   $   $��Center=�51   $   �� 53      -   5        $��0��53   !   $��2��6.   $��Change��54   !   $��80��56   !   $��25��57   !   �� 59      -   5        $ HotkeyInstructions��5;   $   $��1��59   $   $��0��61   $��3��6A   $5��/Press the new key combination to set the hotkey��5:   $   
�������$��11(�5=   $   $��0,5,0,0q�5>   $   $y�	Collapsed=�5?   $   5@      5A      �� 5D      $��Search Settings��6   $��0,0,0,20q�64   .��5E      �� $��10q�6!   .+�5F      �� -   5         ��Name$ AutoStartCheckBox��5F   #   $��Start with Windows��5G   #   $��0,0,0,10q�5H   #   �� 5J      -   5        $ CloseOnSearchCheckBox��5J   #   $1��+Close search window after performing search��5K   #   $��0,0,0,10q�5L   #   �� 5N      -   5        $ CloseOnFocusLossCheckBox��5N   #   $-��'Close search window when it loses focus��5O   #   $��0,0,0,10q�5P   #   5Q      5R      �� 5U      $��About��6   $��0,0,0,20q�6*   .��5V      �� $��10q�6!   .+�5W      �� $��AI Search v1.0.0��6$   $
��Bold"�6<   �� 5X      $>��8A system-wide search application with Gemini integration��6$   
�������$��0,5,0,0q�5Z   $   �� 5[      $!��Built with .NET 8.0 and WPF��6$   
�������$��0,2,0,0q�5]   $   5^      5_      5`      5a      �� 5d   
   $��2��6    �� Orientation$ 
Horizontal=�5e      $��Right=�5f      $��0,20,0,0q�5g      .+�5h      �� -   5        $��OK��5h      $��80��5j      $��30��5k      $��0,0,10,0q�5l      �� 5m      -   5        $��Cancel��5m      $��80��5o      $��30��5p      5q      5r      5s      