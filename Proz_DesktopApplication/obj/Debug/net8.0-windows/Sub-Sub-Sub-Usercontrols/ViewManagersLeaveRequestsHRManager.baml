   M S B A M L   `   `   `  ����  Proz_DesktopApplicationY    SProz_DesktopApplication.Sub_Sub_Sub_Usercontrols.ViewManagersLeaveRequestsHRManager   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5	      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value��%c   '        �� 5
   
   "  6   .�5      ��  �@�FocusVisualStyle 61   Z� 5      5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $	��250 �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ManagersRequestsDataGrid��5      $��0��5      $��0,0,0,20q�5         AutoGenerateColumns$ False��5       �� AlternationCount$ 1000000��5         
IsReadOnly$
 True��5      	   SelectionMode$	 Single=�5      
 � FocusVisualStyle
 5      Z�    Columns 5       4  .System.Windows.Controls.DataGridTemplateColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 64      CellTemplate 5"      �� 5#      .R�5$      �� ��6(   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType DataGridRow �� Path$ AlternationIndex�5%      5'      0  *System.Windows.Controls.DataGridTextColumn  5(      $ Manager Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *ManagerName+  5)      $ Start��6%    64   �� *Start+  5*      $	 End��6%    62   �� *End+5,      �� 5/   
   $��1��6   $
��Auto=�6$   .��50      �� $��0,0,10,0q�6   .+�51      �� $��Reason��6      MyTextBlockStyle#��[  6*   $
��Bold"�6T   $��0,0,0,5q�6f   �� 52      -   5         ��Name$ ReasonTextbox��52        MyTextBoxStyle#��[ 53       �� 
IsReadOnly$
 True��54      $��13(�55      $��0,0,0,20q�56      �� 58      $��HR Final Message��6   #��[  64   $
��Bold"�6^   $��0,0,0,5q�6p   �� 59      -   5        $ HRMessageTextbox��59      #��[ 5:       �� TextWrapping$
 Wrap=�5;       �� AcceptsReturn$
 True��5<      " �� VerticalScrollBarVisibility$
 Auto=�5=      $��0,0,0,20q�5>      �� 5?      -   5         ��Name$ NeedsApprovalCheckbox��5?   G   $��Needed Approval��6    d� 	IsChecked$ FalseY�65   6G   �� 5@       �� Orientation$ 
Horizontal=�6   $��Right=�66   .+�5A      �� -   5        $��Approve��5A        MyButtonStyle#��[ 6/   $	��120��6V   6b   �� 5B      -   5        $��Reject��5B      #��[ 6.   $	��120��6U   $��10,0,0,0q�6a   6s   5C      5D      5E      5F      5G      