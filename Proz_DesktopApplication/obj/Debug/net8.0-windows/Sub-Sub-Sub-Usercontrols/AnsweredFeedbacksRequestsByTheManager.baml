   M S B A M L   `   `   `  ����  Proz_DesktopApplication\    VProz_DesktopApplication.Sub_Sub_Sub_Usercontrols.AnsweredFeedbacksRequestsByTheManager   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5	      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value��%c   '        �� 5
   
   "  6   .�5      ��  �@�FocusVisualStyle 61   Z� 5      5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��250 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0,0,0,10q�6;   .+�5      �� $��Sub-Department:��6   $��Center=�5      $
��Bold"�5      $��0,0,10,0q�5      �� 5      -   5         ��Name$ SubDepartmentComboBox��5      $	��200��66   $��0,0,10,0q�6B   �� 5      -   5        $	��Get��5      $��80��6#   6.   5      &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ AnsweredFeedbacksDataGrid��5!      $��1��5"         AutoGenerateColumns$ False��5#      	 �� AlternationCount$	 1000000��5$      
   
IsReadOnly$

 True��5%         SelectionMode$ Single=�5&       � FocusVisualStyle 5(      Z�    Columns 5*      4  .System.Windows.Controls.DataGridTemplateColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 64      CellTemplate 5,      �� 5-      .R�5.      �� ��6(   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType DataGridRow �� Path$ AlternationIndex�5/      51      0  *System.Windows.Controls.DataGridTextColumn  52      $ Employee Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *EmployeeName+  53      $ Title��6%    64   �� *Title+  54      $
 Type��6%    63   �� *Type+  55      $
 Date��6%    63   �� *Date+57      �� 5:   
   $��2��6   $
��Auto=�6$   .��5;      �� $��
0,10,10,10q�6   .+�5<      �� $��Description:��6   $
��Bold"�60   $��0,0,0,5q�6B   �� 5=      -   5         ��Name$ DescriptionTextbox��5=       �� 
IsReadOnly$
 True��66    �� TextWrapping$
 Wrap=�6H   $��60��6\   $��0,0,0,20q�6h   �� 5?      $��Answer:��6   $
��Bold"�6+   $��0,0,0,5q�6=   �� 5@      -   5        $ AnswerTextbox��5@      $
 True��61   $
 Wrap=�6C   $��80��6W   $��0,0,0,20q�6c   �� 5B      $��Answered At:��6   $
��Bold"�60   $��0,0,0,5q�6B   �� 5C      -   5        $ AnswerDateTextbox��5C      $
 True��65   $��0,0,0,20q�6G   �� 5E      $��Answered By:��6   $
��Bold"�60   $��0,0,0,5q�6B   �� 5F      -   5        $ RespondentTextbox��5F      $
 True��65   $��0,0,0,20q�6G   5G      5H      5I      5J      