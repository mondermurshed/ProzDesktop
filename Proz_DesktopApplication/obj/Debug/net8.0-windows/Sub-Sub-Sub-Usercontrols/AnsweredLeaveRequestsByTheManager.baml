   M S B A M L   `   `   `  ����  Proz_DesktopApplicationX    RProz_DesktopApplication.Sub_Sub_Sub_Usercontrols.AnsweredLeaveRequestsByTheManager   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5	      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value��%c   '        �� 5
   
   "  6   .�5      ��  �@�FocusVisualStyle 61   Z� 5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��250 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��20,10,20,10q�6;   .+�5      �� $��Sub-Department:��6      MyTextBlockStyle#��[  6/   $��Center=�6Y   $��0,0,10,0q�6t   �� 5      -   5         ��Name$ SubDepartmentComboBox��5      $	��200��66   $��0,0,10,0q�6B   �� 5      -   5        $	��Get��5        MyButtonStyle#��[ 6#   $��80��6J   6U   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ CompletedRequestsDataGrid��5      $��1��5      $��
20,0,20,10q�5          AutoGenerateColumns$ False��5!      	   
IsReadOnly$
	 True��5"      
 �� AlternationCount$
 1000000��5#         SelectionMode$ Single=�5$       � FocusVisualStyle 5&      Z�    Columns 5(      4  .System.Windows.Controls.DataGridTemplateColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 64      CellTemplate 5*      �� 5+      .R�5,      �� ��6(   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType DataGridRow �� Path$ AlternationIndex�5-      5/      0  *System.Windows.Controls.DataGridTextColumn  51      $ Employee Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *EmployeeName+  52      $ Start��6%    64   �� *Start+  53      $	 End��6%    62   �� *End+  54      $ 
Department��6%    69   �� *SubDepartment+56      � 59   
   $��2��6   $��
20,0,20,10q�6   .+�5:      �� $
��Auto=�6   .��5;      �� $��
0,10,10,10q�6   .+�5<      �� $��Reason��6    #��[  6.   $
��Bold"�6X   $��0,0,0,5q�6j   �� 5=      -   5         ��Name$ ReasonTextbox��5=        MyTextBoxStyle#��[ 5>       �� 
IsReadOnly$
 True��5?      $��13(�5@      $��0,0,0,20q�5A      �� 5C      $��
My Message��6    #��[  62   $
��Bold"�6\   $��0,0,0,5q�6n   �� 5D      -   5        $ ManagerMessageTextbox��5D      #��[ 5E      $
 True��5F      $��13(�5G      $��0,0,0,20q�5H      5I      5J      5K      5L      5M      