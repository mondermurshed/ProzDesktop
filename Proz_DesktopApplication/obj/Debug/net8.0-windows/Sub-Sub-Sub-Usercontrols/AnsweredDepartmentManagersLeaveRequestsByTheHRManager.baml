   M S B A M L   `   `   `  ����  Proz_DesktopApplicationl    fProz_DesktopApplication.Sub_Sub_Sub_Usercontrols.AnsweredDepartmentManagersLeaveRequestsByTheHRManager   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5	      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value��%c   '        �� 5
   
   "  6   .�5      ��  �@�FocusVisualStyle 61   Z� 5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��250 �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ CompletedRequestsDataGrid��5      $��1��5      $��20,20,20,10q�5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5       �� AlternationCount$ 1000000��5      	   SelectionMode$	 Single=�5       
 � FocusVisualStyle
 5"      Z�    Columns 5$      4  .System.Windows.Controls.DataGridTemplateColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 64      CellTemplate 5&      �� 5'      .R�5(      �� ��6(   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType DataGridRow �� Path$ AlternationIndex�5)      5+      0  *System.Windows.Controls.DataGridTextColumn  5-      $ Manager Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *ManagerName+  5.      $ Start��6%    64   �� *Start+  5/      $	 End��6%    62   �� *End+  50      $ HR Final Status��6%    6>   �� *HRManagerStatus+52      � 55   
   $��2��6   $��
20,0,20,10q�6   .+�56      �� $
��Auto=�6   .��57      �� $��
0,10,10,10q�6   .+�58      �� $��Reason��6       MyTextBlockStyle#��[  6.   $
��Bold"�6X   $��0,0,0,5q�6j   �� 59      -   5         ��Name$ ReasonTextbox��59        MyTextBoxStyle#��[ 5:       �� 
IsReadOnly$
 True��5;      $��13(�5<      $��0,0,0,20q�5=      �� 5?      $��HR Final Message��6    #��[  68   $
��Bold"�6b   $��0,0,0,5q�6t   �� 5@      -   5        $ HRFinalMessageTextbox��5@      #��[ 5A      $
 True��5B      $��13(�5C      $��0,0,0,20q�5D      �� 5E      -   5         ��Name$ NeededApprovalCheckbox��5E      $��Was Needed Approval ?��6?   ${�False��6_   5F      5G      5H      5I      5J      