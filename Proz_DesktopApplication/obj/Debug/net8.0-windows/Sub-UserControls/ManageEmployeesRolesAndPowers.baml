   M S B A M L   `   `   `  ����R  NProz_DesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Proz_DesktopApplicationProz_DesktopApplication  5      c6clr-namespace:Proz_DesktopApplication.Sub_UserControls(Proz_DesktopApplication.Sub_UserControls  5      L    FProz_DesktopApplication.Sub_UserControls.ManageEmployeesRolesAndPowers   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6base%clr-namespace:Proz_DesktopApplication     5      Hlocal6clr-namespace:Proz_DesktopApplication.Sub_UserControls     5      .��5      � $��20q�6   .+�5   
   �� .@�5      �� $��Manage People Roles��6   .��5      �   � RowDefinitions  5      �� 5      $
��Auto �6(   �� 5      $��* �6(   .+�5      �� -   5         ��Name$ SearchUsersTextBox��5      $��Center=�6:   $	��250��5      $��0,15,0,5q�5      5      �� 5      -   5        $��Refresh Data��5      $��Right=�64   $��0,15,5,5q�6P      MyButtonStyle#��[  6b   5       &   System.Windows.Controls.DataGrid  5"      -   5          Name$ UsersRolesDataGrid��5"      $��1��5#         AutoGenerateColumns$ False��5$         
IsReadOnly$ False��5%         CanUserAddRows$ False��5&      $��0,10,0,0q�5'         SelectionMode$ Single=�5(         Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Full Name��61   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 2* 6a   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6D   �� *
FullName+6a   4  .System.Windows.Controls.DataGridTemplateColumn  5-      $ Is User?��65      CellTemplate 5.   "   �� 5/   &   .R�50   *   	�  	�Name$ 	UserRadio��6^   -   5        
 � Tag$
 User��50   6   
������  d� 	IsChecked 6A   �� *IsUser+ 	� 	GroupName 6�   �� *
FullName+51   '   53        55      $ Is Employee?��65    56   "   �� 57   &   .R�58   *   	� $ EmployeeRadio��6�   -   5        $ Employee��58   7   
������  6F   �� *
IsEmployee+ 6�   �� *
FullName+59   '   5;        5=      $ Is Department Manager?��65    5>   "   �� 5?   &   .R�5@   *   	� $ DeptManagerRadio��6�   -   5        $ Department Manager��5@   6   
������  6O   �� *IsDepartmentManager+ 6�   �� *
FullName+5A   '   5C        5E      $ Is HR Manager?��65    5F   "   �� 5G   &   .R�5H   *   	� $ HRManagerRadio��6�   -   5        $ 
HR Manager��5H   6   
������  6G   �� *IsHRManager+ 6�   �� *
FullName+5I   '   5K        5M      $ 	Is Admin?��65    5N   "   �� 5O   &   .R�5P   *   	� $ 
AdminRadio��6B   -   5        $ Admin��5P   6   
������  6V   �� *	IsAdmin+ 6�   �� *
FullName+5Q   '   5S        5V      $ Action��65   $		 100 6E    5W   "   �� 5X   &   .R�5Y   *   �� -	   5        $��Delete��5Y   1   ���	#FFA80000
�������6x   5Z   '   5\      5_      5a      5b      �� 5c      $*��$Limit/Unlimit Power from HR Managers��6   .��5d      �   5e      �� 5f   
   $
��Auto �6   �� 5g   
   $��* �6   .+�5k      �� -
   5        $ SearchHRManagersTextBox��5k      $	��250��5l      $��0,0,0,10q�5m      $	��Top=�5n      5p        5s      -   5        $ HRManagersGrid��5s      $��1��5t      $ False��5u      $ False��5v      $ False��5w      $��0,10,0,0q�5x       5y   
     5z      $ 	Full Name��6!   $	 2* 5|   !   
 5{   !   �� *
FullName+5|   !   4  .System.Windows.Controls.DataGridCheckBoxColumn  5~      $ Has Full Power?��6%   $	 * 5�   %   
 5   %   �� *HasFullPower+ �� Mode$ TwoWay=�5�   %   5�      5�      5�      5�      5�      5�      