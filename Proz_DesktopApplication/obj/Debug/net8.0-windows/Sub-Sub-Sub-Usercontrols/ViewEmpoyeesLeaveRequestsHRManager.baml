   M S B A M L   `   `   `  ����  Proz_DesktopApplicationY    SProz_DesktopApplication.Sub_Sub_Sub_Usercontrols.ViewEmpoyeesLeaveRequestsHRManager   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5	      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value��%c   '        �� 5
   
   "  6   .�5      ��  �@�FocusVisualStyle 61   Z� 5      5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��250 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0,0,0,10q�6;   .+�5      �� $��Sub-Department:��6      MyTextBlockStyle#��[  6/   $��Center=�6Y   $��0,0,10,0q�6t   �� 5      -   5         ��Name$ SubDepartmentComboBox��5      $	��200��66   $��0,0,10,0q�6B   �� 5      -   5        $	��Get��5        MyButtonStyle#��[ 6#   $��80��6J   6U   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ HRLeaveRequestsDataGrid��5      $��1��5         AutoGenerateColumns$ False��5       	 �� AlternationCount$	 1000000��5!      
   
IsReadOnly$

 True��5"         SelectionMode$ Single=�5#       � FocusVisualStyle 5%      Z�    Columns 5'      4  .System.Windows.Controls.DataGridTemplateColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 64      CellTemplate 5)      �� 5*      .R�5+      �� ��6(   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType DataGridRow �� Path$ AlternationIndex�5,      5.      0  *System.Windows.Controls.DataGridTextColumn  5/      $ Employee Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *EmployeeName+  50      $ Start��6%    64   �� *Start+  51      $	 End��6%    62   �� *End+  52      $ 
Department��6%    69   �� *SubDepartment+54      �� 57   
   $��2��6   $
��Auto=�6$   .��58      �� $��
0,10,10,10q�6   .+�59      �� $��Reason Message:��6   #��[  63   $��0,0,0,5q�6]   �� 5:      -   5         ��Name$ EmployeeReasonTextbox��5:        MyTextBoxStyle#��[ 69    �� 
IsReadOnly$
 True��6a   $��Medium"�6s   $��13(�6�   $��0,0,0,20q�6�   �� 5<      $!��Department Manager Message:��6   #��[  6?   $��0,0,0,5q�6i   �� 5=      -   5        $% DepartmentManagerMessageTextbox��5=      #��[ 5>      $
 True��5?       �� TextWrapping$
 Wrap=�5@       �� AcceptsReturn$
 True��5A      " �� VerticalScrollBarVisibility$
 Auto=�5B      $��0,0,0,20q�5C      �� 5E      $��HR Final Message:��6   #��[  65   $��0,0,0,5q�6_   �� 5F      -   5        $ HRMessageTextbox��5F      #��[ 5G      $
 Wrap=�5H      $
 True��5I      $
 Auto=�5J      $��0,0,0,20q�5K      �� 5L      -   5         ��Name$ NeedesApprovalCheckbox��5L   G   $��Needed Approval��6    d� 	IsChecked$ FalseY�65   6G   �� 5M      $ 
Horizontal=�6   $��Right=�66   .+�5N      �� -   5        $��Approve��5N      #��[ 6/   $	��120��6V   6b   �� 5O      -	   5        $��Reject��5O      #��[ 6.   $	��120��6U   $��10,0,0,0q�6a   6s   5P      5Q      5R      5S      5T      