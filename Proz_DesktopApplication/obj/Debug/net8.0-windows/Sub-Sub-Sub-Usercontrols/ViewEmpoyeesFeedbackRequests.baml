   M S B A M L   `   `   `  ����R  NProz_DesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols0Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols  5      S    MProz_DesktopApplication.Sub_Sub_Sub_Usercontrols.ViewEmpoyeesFeedbackRequests   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Plocal>clr-namespace:Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols     5        � 	Resources  5
      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value��%c   '        �� 5   
   "  6   .�5      ��  �@�FocusVisualStyle 61   Z� 5      5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��250 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0,0,0,10q�6;   .+�5      �� $��Sub-Department:��6      MyTextBlockStyle#��[  6/   $��Center=�6Y   $��0,0,10,0q�6t   �� 5      -   5         ��Name$ SubDepartmentComboBox��5      $	��200��66   $��0,0,10,0q�6B   �� 5      -   5        $	��Get��5        MyButtonStyle#��[ 6#   $��80��6J   6U   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ FeedbackRequestsDataGrid��5      $��1��5          AutoGenerateColumns$ False��5!      	 �� AlternationCount$	 1000000��5"      
   
IsReadOnly$

 True��5#         SelectionMode$ Single=�5$       � FocusVisualStyle 5&      Z�    Columns 5'      4  .System.Windows.Controls.DataGridTemplateColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 64      CellTemplate 5)      �� 5*      .R�5+      �� ��6(   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType DataGridRow �� Path$ AlternationIndex�5,      5.      0  *System.Windows.Controls.DataGridTextColumn  5/      $ Employee Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *EmployeeName+  50      $
 Type��6%    63   �� *Type+  51      $ Title��6%    64   �� *Title+  52      $
 Date��6%    63   �� *Date+54      �� 57   
   $��2��6   $
��Auto=�6$   .��58      �� $��
0,10,10,10q�6   .+�59      �� $��Description:��6   #��[  60   $��0,0,0,5q�6Z   �� 5:      -   5         ��Name$ DescriptionTextbox��5:        MyTextBoxStyle#��[ 66    �� 
IsReadOnly$
 True��6^   $��Medium"�6p   $��13(�6�   $��0,0,0,20q�6�   �� 5<      $��Answer:��6   #��[  6+   $��0,0,0,5q�6U   �� 5=      -   5        $ AnswerTextbox��5=      #��[ 61    �� TextWrapping$
 Wrap=�6Z    �� AcceptsReturn$
 True��6n   " �� VerticalScrollBarVisibility$
 Auto=�6�   $��0,0,0,20q�6�    �� 	MaxLength$
 1500��6�   �� 5?      $ 
Horizontal=�6   $��Right=�66   .+�5@      �� -   5        $��Submit Answer��5@      #��[ 65   $	��150��6\   6h   5A      5B      5C      5D      5E      