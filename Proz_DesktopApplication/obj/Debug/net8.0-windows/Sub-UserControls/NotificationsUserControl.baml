   M S B A M L   `   `   `  ����  Proz_DesktopApplicationG    AProz_DesktopApplication.Sub_UserControls.NotificationsUserControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5	      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value��%c   '        �� 5
   
   "  6   .�5      ��  �@�FocusVisualStyle 61   Z� 5      5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6/   .+�5      �� $��Filter by Day:��6   $��Center=�6.   $��0,0,10,0q�6I   �� 5      -   5         ��Name$ DaysComboBox��5      $	��200��6-   5      �� 5   
   $ 
Horizontal=�6   $��0,0,0,10q�6/   .+�5      �� $��Priority��6   $��Center=�6(   $��0,0,10,0q�6C   �� 5       -   5        $ PriorityComboBox��5       $	��200��61   �� 5!      -   5        $	��Get��5!      $��10,0,0,0q�6#      MyButtonStyle#��[  65   6\   5"      5#      &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ NotificationsDataGrid��5%      $��1��5&         AutoGenerateColumns$ False��5'      	   
IsReadOnly$
	 True��5(      
 �� AlternationCount$
 1000000��5)         SelectionMode$ Single=�5*       � FocusVisualStyle 5+      Z�    Columns 5-      4  .System.Windows.Controls.DataGridTemplateColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 64      CellTemplate 5/      �� 50      .R�51      �� ��6(   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType DataGridRow �� Path$ AlternationIndex�52      54      0  *System.Windows.Controls.DataGridTextColumn  55      $ Title��6%   $	 150 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Title+6N     56      $ Message��6%   $	 250 6R    66   �� *	Message+6R     57      $ 
Created At��6%   $	 150 6W    69   �� *	CreatedAt+6W     58      $ Seen At��6%   $	 150 6Q    66   �� *SeenAt+6Q     59      $
 Type��6%   $	 100 6L    63   �� *Type+6L     5:      $ Priority��6%   $	 100 6T    67   �� *
Priority+6T   5<      5=      5>      