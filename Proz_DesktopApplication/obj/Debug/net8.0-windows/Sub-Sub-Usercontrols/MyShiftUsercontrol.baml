   M S B A M L   `   `   `  ����  Proz_DesktopApplication>    8Proz_DesktopApplication.Sub_Sub_Usercontrols.MyShiftInfo   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5	      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value��%c   '        �� 5
   
   "  6   .�5      ��  �@�FocusVisualStyle 61   Z� 5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ BreaksDataGrid��5      $��0��5      $��20,30,20,10q�5         AutoGenerateColumns$ False��5       �� AlternationCount$ 1000000��5         
IsReadOnly$
 True��5      	   SelectionMode$	 Single=�5      
   SelectionUnit$
 FullRow=�5       � FocusVisualStyle 5      Z�    Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ #��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 64      CellTemplate 5!      �� 5"      .R�5#      �� ��6(   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType DataGridRow �� Path$ AlternationIndex�5$      5&      0  *System.Windows.Controls.DataGridTextColumn  5'      $ Break Start��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
BreakStart+  5(      $ 	Break End��6%    68   �� *
BreakEnd+  5)      $ 
Break Type��6%    69   �� *	BreakType+  5*      $ Comment��6%    66   �� *	Comment+5,      � 5/   
   $��1��6   $��20,10,20,20q�6    � ColumnDefinitions 50      �� 51      $��* �6#   �� 52      $��* �6#   .+�55      �� $��0��6   $��0,0,10,0q�6)   .+�56      �� $��Shift Start Time��6      MyTextBlockStyle#��[  64   $��	ExtraBold"�6^   �� 57      -   5         ��Name$ ShiftStartTextBox��57        MyTextBoxStyle#��[ 65    �� 
IsReadOnly$
 True��6]   $��13(�6o   $��0,0,0,10q�6}   �� 59      $��Total Working Hours��6   #��[  67   $��	ExtraBold"�6a   �� 5:      -   5        $ TotalHoursTextBox��5:      #��[ 65   $
 True��6]   $��13(�6o   5;      �� 5=      $��1��6   $��10,0,0,0q�6)   .+�5>      �� $��Shift End Time��6   #��[  62   $��	ExtraBold"�6\   �� 5?      -   5        $ ShiftEndTextBox��5?      #��[ 63   $
 True��6[   $��13(�6m   $��0,0,0,10q�6{   �� 5A      $��
Shift Type��6   #��[  6.   $��	ExtraBold"�6X   �� 5B      -   5        $ ShiftTypeTextBox��5B      #��[ 64   $
 True��6\   $��13(�6n   5C      5D      5E      5F      