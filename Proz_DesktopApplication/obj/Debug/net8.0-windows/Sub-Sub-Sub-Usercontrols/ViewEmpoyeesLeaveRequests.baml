   M S B A M L   `   `   `  ����  Proz_DesktopApplicationP    JProz_DesktopApplication.Sub_Sub_Sub_Usercontrols.ViewEmpoyeesLeaveRequests   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5	      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value��%c   '        �� 5
   
   "  6   .�5      ��  �@�FocusVisualStyle 61   Z� 5      5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��250 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0,0,0,10q�6;   .+�5      �� $��Sub-Department:��6      MyTextBlockStyle#��[  6/   $��Center=�6Y   $��0,0,10,0q�6t   �� 5      -   5         ��Name$ SubDepartmentComboBox��5      $	��200��66   $��0,0,10,0q�6B   �� 5      -   5        $	��Get��5        MyButtonStyle#��[ 6#   $��80��6J   6U   5      &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$# EmployeeLeaveRequestsDataGrid��5!      $��1��5"         AutoGenerateColumns$ False��5#      	 �� AlternationCount$	 1000000��5$      
   
IsReadOnly$

 True��5%         SelectionMode$ Single=�5&       � FocusVisualStyle 5(      Z�    Columns 5*      4  .System.Windows.Controls.DataGridTemplateColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 64      CellTemplate 5,      �� 5-      .R�5.      �� ��6(   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType DataGridRow �� Path$ AlternationIndex�5/      51      0  *System.Windows.Controls.DataGridTextColumn  52      $ Employee Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *EmployeeName+  53      $ Start��6%    64   �� *Start+  54      $	 End��6%    62   �� *End+56      �� 59   
   $��2��6   $
��Auto=�6$   .��5:      �� $��
0,10,10,10q�6   .+�5;      �� $��Reason Message:��6   #��[  63   $��0,0,0,5q�6]   �� 5<      -   5         ��Name$ EmployeeReasonTextbox��5<        MyTextBoxStyle#��[ 69    �� 
IsReadOnly$
 True��6a   $��Medium"�6s   $��13(�6�   $��0,0,0,20q�6�   �� 5=      $��Manager Message:��6   #��[  64   $��0,0,0,5q�6^   �� 5>      -   5        $ ManagerMessageTextbox��5>      #��[ 5?       �� TextWrapping$
 Wrap=�5A       �� AcceptsReturn$
 True��5B      " �� VerticalScrollBarVisibility$
 Auto=�5C      $��0,0,0,20q�5D      �� 5F      $ 
Horizontal=�6   $��Right=�66   .+�5G      �� -   5        $��Approve��5G      #��[ 6/   $	��120��6V   6b   �� 5H      -   5        $��Reject��5H      #��[ 6.   $	��120��6U   $��10,0,0,0q�6a   6s   5I      5J      5K      5L      5M      