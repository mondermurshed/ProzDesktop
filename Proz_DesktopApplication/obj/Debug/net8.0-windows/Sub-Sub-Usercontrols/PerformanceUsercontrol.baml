   M S B A M L   `   `   `  ����  Proz_DesktopApplicationI    CProz_DesktopApplication.Sub_Sub_Usercontrols.PerformanceUsercontrol   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5	      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value��%c   '        �� 5
   
   "  6   .�5      ��  �@�FocusVisualStyle 61   Z� 5      5      .��5      �  � RowDefinitions 5   
   �� 5      $	��250 �6   �� 5      $��* �6   .+�5   
   � $��0��6    5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   $��
20,40,20,0q�62   $��0��6F   .+�5      ��    MyTextBlockStyle#��[  6   $��Month:��6F   $��Center=�6T   $��0,0,10,0q�6o   �� 5      -   5         ��Name$ MonthFilter��5      $	��120��60   $��0,0,20,0q�6<   �� 5       $ 
Horizontal=�6   .+�5!      ��   MyButtonStyle#��[ 6   $��Reload��6D   $
��20,0q�6U   �� 5"      -   5        #��[ 5"      $��10,0,0,0q�6D   $��Reset Month��6W   6m   5#      5$      &   System.Windows.Controls.DataGrid  5'      -   5          Name$ PerformanceDatagrid��5'      $��1��64   $��20,20,20,20q�5(       �� AlternationCount$ 1000000��5)      	   AutoGenerateColumns$	 False��5*      
   
IsReadOnly$

 True��5+         SelectionMode$ Single=�5,         SelectionUnit$ FullRow=�5-       � FocusVisualStyle 5/      Z�    Columns 50      4  .System.Windows.Controls.DataGridTemplateColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 68      CellTemplate 52      �� 53      .R�54   "   �� ��6,   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType DataGridRow �� Path$ AlternationIndex�55      57      0  *System.Windows.Controls.DataGridTextColumn  59      $
 Date��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Date+  5:      $ Score��6)    68   �� *Score+  5;      $ Status��6)    69   �� *Status+5=      5>      � 5A   
   $��1��6   $��20,30,20,20q�6   .+�5B      �� $
��Auto=�6   $��Disabled=�6>   .��5C      �� $��0,0,10,0q�6   .+�5D      �� #��[  6    $��	Evaluator��6J   $��	ExtraBold"�6[   $��0,0,0,5q�6r   �� 5E      -   5         ��Name$ EvaluatorTextBox��5E        MyTextBoxStyle#��[ 68    �� 
IsReadOnly$
 True��6`   $��13(�6r   $��0,0,0,20q�6�   �� 5G      #��[  6    $��Comment��6J   $��	ExtraBold"�6Y   $��0,0,0,5q�6p   �� 5H      -   5        $ CommentTextBox��5H      #��[ 66   $
 True��6^   $��13(�6p    �� TextWrapping$
 Wrap=�6~   $��0,0,0,20q�6�   5I      5J      5K      5L      5M      