   M S B A M L   `   `   `  ����R  NProz_DesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Proz_DesktopApplication.Sub_UserControls(Proz_DesktopApplication.Sub_UserControls  5      B    <Proz_DesktopApplication.Sub_UserControls.MyLoginHistoryAdmin   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      Blocal6clr-namespace:Proz_DesktopApplication.Sub_UserControls  5        � 	Resources  5
      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value��%c   '        �� 5   
   "  6   .�5      ��  �@�FocusVisualStyle 61   Z� 5      5      .��5      �� $��20,30,20,20q�6   ._�5   
   4  .MahApps.Metro.Controls.MetroAnimatedTabControl  2  ,MahApps.Metro.Controls.HeaderedControlHelper   HeaderFontFamily$ Microsoft YaHei UI)�6&   -  'MahApps.Metro.Controls.TabControlHelper   
Underlined$ SelectedTabItem=�6f      UnderlinePlacement Left6�   .@�5      �� $��My Login Information��6   .��5      � $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $��* �6(   �� 5      $
��Auto �6(   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��Right=�6:   $��0,0,0,10q�6V   .+�5      �� -   5        	 ��Name$	 YearComboBox��5   #   $��5q�6:   6E   �� 5      -   5        $	 MonthComboBox��5   #   $��5q�6:   6E   �� 5      -   5        $	 SortOrderComboBox��5   #   $��5q�6?   .@�5       �� $ ��Show from newest to oldest��6+   
 �� 
IsSelected$

 True��6P   �� 5!      $ ��Show from oldest to newest��6+   5"      5#      &   System.Windows.Controls.DataGrid  5%      -   5          Name$ AdminLoginDataGrid��5%      $��1��5&         AutoGenerateColumns$ False��5'         
IsReadOnly$
 True��5(       �� AlternationCount$ 1000000��5)         SelectionMode$ Single=�5*         SelectionUnit$ FullRow=�5+       � FocusVisualStyle 5,      Z�    Columns 5-      4  .System.Windows.Controls.DataGridTemplateColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ #��65      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6@      CellTemplate 5/   "   �� 50   &   .R�51   *   �� ��64   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType DataGridRow �� Path$ AlternationIndex�52   '   54      0	  *System.Windows.Controls.DataGridTextColumn	  55      $ Date/Time Logged��61   $ * 6j   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6K   �� *
WhenLogged+6j   	  56      $ 
IP Address��61   $ * 6c    6E   �� *	IPAddress+6c   58      �� 59      $��0,10,0,0q�6!   $ 
Horizontal=�63   $��2��6L   $��Right=�6Y   .+�5:      �� -   5           MyButtonStyle#��[  5:   !   $-��'Find A Record With Different IP address��6H   6z   5<      5=      5>      �� 5?      $*��$Check Login Information of employees��6   .��5@      � $��20q�6    5A      �� 5B      $
��Auto �6(   �� 5C      $��* �6(   �� 5D      $
��Auto �6(   .+�5G      � $��0,0,0,10q�6    � ColumnDefinitions 5H      �� 5I      $��* �6/   �� 5J      $
��Auto �6/   .+�5N      �� $ 
Horizontal=�6%   $
��Left=�6>   $��0,0,10,0q�6Y   .+�5O      �� -   5        $	 DepartmentComboBox��5O   '   $	��150��6C   $��5q�6O   6Z   �� 5P      -   5        $	 EmployeeComboBox��5P   '   $	��150��6A   $��5q�6M   6X   5Q      �� 5T      $ 
Horizontal=�6%   $��1��6>   $��Right=�6N   .+�5U      �� -   5        $	 YearComboBoxEmployees��5U   '   $��5q�6G   6R   �� 5V      -	   5        $	 MonthComboBoxEmployees��5V   '   $��5q�6G   6R   �� 5W      -
   5        $ 	 SortOrderComboBoxEmployees��5W   '   $��5q�6L   .@�5X   "   �� $ ��Show from newest to oldest��6/   $

 True��6T   �� 5Y   "   $ ��Show from oldest to newest��6/   5Z      5[      5\        5^      -   5        $! AdminLoginDataGridEmployees��5^      $��1��5_      $ False��5`      $
 True��5a      $ 1000000��5b      $ Single=�5c      $ FullRow=�5d       5e      Z�  5f        5g      $ #��65   $ 50 6@    5h   "   �� 5i   &   .R�5j   *   �� ��64   ��  �� $ FindAncestor=� DataGridRow$ AlternationIndex�5k   '   5m      	  5n      $ Date/Time Logged��61   $ * 6j    6K   �� *
WhenLogged+6j   	  5o      $ 
IP Address��61   $ * 6c    6E   �� *	IPAddress+6c   5q      �� 5r      $��0,10,0,0q�6!   $ 
Horizontal=�63   $��2��6L   $��Right=�6Y   .+�5s      �� -   5        #��[  5s   !   $-��'Find A Record With Different IP address��6H   6z   5u      5v      5w      5x      5y      5z      