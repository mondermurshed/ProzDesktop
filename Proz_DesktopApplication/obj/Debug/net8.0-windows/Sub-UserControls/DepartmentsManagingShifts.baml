   M S B A M L   `   `   `  ����R  NProz_DesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Proz_DesktopApplication.Sub_UserControls(Proz_DesktopApplication.Sub_UserControls  5      H    BProz_DesktopApplication.Sub_UserControls.DepartmentsManagingShifts   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      4xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      Blocal6clr-namespace:Proz_DesktopApplication.Sub_UserControls  5      .��5      �� $��20,30,20,20q�6   ._�5   
   �� .@�5      �� $��Create Department Shifts��6   .��5      � $��10q�6     � RowDefinitions  5      �� 5      $
��Auto �6(   �� 5      $��* �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   .+�5      �� -   5         ��Name$ DepartmentSearchBox��5      $	��250��5      $��0,0,0,10q�5      5      &   System.Windows.Controls.DataGrid  5!      -   5          Name$ DepartmentsDataGrid��5!      $��1��5"         AutoGenerateColumns$ False��5#         
IsReadOnly$
 True��5$         SelectionMode$ Single=�5%         SelectionUnit$ FullRow=�5&      $��0,0,0,10q�5'      $	��200��5(         Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$ Department Name��61   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6n   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6J   �� *Department_Name+6n   4  .System.Windows.Controls.DataGridTemplateColumn  5,      $ Action��65   $		 150 6E      CellTemplate 5-   "   �� 5.   &   .R�5/   *   �� -   5        $��Delete Morning Shfit��5/   1   
���\\��6t   50   '   53        54      $ Action��65   $		 150 6E    55   "   �� 56   &   .R�57   *   �� -   5        $��Delete Evening Shfit��57   1   
���\\��6t   58   '   5;      5=      �� 5@      $��2��6!    �� Orientation$ 
Horizontal=�6.   $��0,10,0,0q�6G   .+�5A      ��    MyTextBlockStyle#��[  6$   $��Start Time:��6N   $��Center=�6a   $��0,0,10,0q�6|   '  !MahApps.Metro.Controls.TimePicker  5B      -   5          Name$ StartTimePicker��5B   *   $	��300��6C   5C      �� 5F      $��3��6!   $ 
Horizontal=�6.   $��0,10,0,0q�6G   .+�5G      �� #��[  6$   $��	End Time:��6N   $��Center=�6_   $��0,0,10,0q�6z     5H      -   5        $ EndTimePicker��5H   )   $	��300��6@   5I      � 5L      $��4��6    � ColumnDefinitions 5N      �� 5O      $��* �6/   �� 5P      $��* �6/   .+�5R      �� $��4��6"   $ 
Horizontal=�60   $
��Left=�6I   $��	20,10,0,0q�6d   .+�5S      �� -   5        $��0,5,0,0q�5S   !   $
��30,7q�62     MyButtonStyle#��[ 6B   $��Create Shift��6i   5U   !   5V      5W      5X      5Y      �� 5[      $��Manage Breaks for Shifts��6   .��5\      � $��10q�6     5]      �� 5^      $
��Auto �6(   �� 5`      $��2* �6(   �� 5b      $��1* �6(   .+�5g      �� -   5        $ BreaksSearchBox��5g      $	��250��5h      $��0,0,0,10q�5i      5k        5n      -	   5        $ BreaksDepartmentsDataGrid��5n      $��1��5o      $ False��5p      $
 True��5q      $ Single=�5r      $ FullRow=�5s      $	��200��5t      $��0,0,0,10q�5u       5w        5x      $ Department Name��61   $	 * 6n   
 6J   �� *Department_Name+6n   5{        5~      -
   5        $$ BreaksForSelectedShiftDataGrid��5~      $��2��5      $ False��5�      $ False��5�      $ Single=�5�      $ FullRow=�5�      $	��150��5�       5�        5�      $ 
Shift Type��61   $	 * 6d      
IsReadOnly$
 True��6n   
 6E   �� *
Shift_Type+6n     5�      $ Shift Starts From��61   $	 * 6o   $
 True��6y   
 6L   �� *ShiftStartTime+6y     5�      $ Shift Ends To��61   $	 * 6j   $
 True��6t   
 6H   �� *ShiftStartEnd+6t     5�      $ Break Start��61   $	 * 6f   
 6F   �� *Break_Start+6f     5�      $ 	Break End��61   $	 * 6b   
 6D   �� *	Break_End+6b     5�      $ 
Break Type��61   $	 * 6d   $
 True��6n   
 6E   �� *
Break_Type+6n     5�      $ Notes��61   $	 2* 6Z   
 6@   �� *Notes+6Z     5�      $ Action��65   $		 200 6E    5�   "   �� 5�   &   .R�5�   *   �� -   5        $��Delete Break��5�   1   ���	#FF9223236k   5�   '   5�      5�      5�      5�      5�      5�      5�      