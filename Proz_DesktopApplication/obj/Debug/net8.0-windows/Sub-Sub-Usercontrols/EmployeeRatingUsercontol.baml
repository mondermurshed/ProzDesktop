   M S B A M L   `   `   `  ����R  NProz_DesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:Proz_DesktopApplication.Sub_Sub_Usercontrols,Proz_DesktopApplication.Sub_Sub_Usercontrols  5      L    FProz_DesktopApplication.Sub_Sub_Usercontrols.EmployeeRatingUsercontrol   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      Flocal:clr-namespace:Proz_DesktopApplication.Sub_Sub_Usercontrols  5        � 	Resources  5      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value��%c   '        �� 5   
   "  6   .�5      ��  �@�FocusVisualStyle 61   Z� 5      5      .��5      �  � RowDefinitions 5   
   �� 5      $	��250 �6   �� 5      $��* �6   .+�5   
   � $��0��6    5      �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ EmployeesDataGrid��5      $��20,40,20,20q�5         AutoGenerateColumns$ False��5        �� AlternationCount$ 1000000��5!         SelectionUnit$ FullRow=�5"      	   
IsReadOnly$
	 True��5$      
   SelectionMode$
 Single=�5%       � FocusVisualStyle 5#      Z�    Columns 5'      4  .System.Windows.Controls.DataGridTemplateColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 68      CellTemplate 5)      �� 5*      .R�5+   "   �� ��6,   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType DataGridRow �� Path$ AlternationIndex�5,      5.      0  *System.Windows.Controls.DataGridTextColumn  50      $ 	Full Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *
FullName+52      53      � 56   
   $��1��6   $��20,20,20,20q�6   .+�57      �� $
��Auto=�6   $��Disabled=�6>   .��58      ��  �� Orientation$ Vertical=�6   $��0,0,10,0q�64   .+�5;      ��    MyTextBlockStyle#��[  6    $��Target��6J   $��0,0,0,5q�6X   �� 5<      -   5         ��Name$ TargetTextbox��5<        MyTextBoxStyle#��[ 5=       �� 
IsReadOnly$
 True��5>      $��Medium"�5?      $��13(�5@      $��0,0,0,20q�5A      �� 5F      $ Vertical=�6!   $��0,0,0,10q�68   .+�5G      �� $ 
Horizontal=�6%   $��Center=�6>   $��Center=�6Y   .+�5H      �� #��[  6(   $	��Bad��6R   $
��Left=�6^   $��Center=�6y   $
��Bold"�6�   
���\\��6�   �� 5I      -   5         ��Name$ PerformanceSlider��5I   %     MySlider#��[ 6@   $	��300��5J   %    � Minimum$ -1Q�5K   %    � Maximum$ 1Q�5L   %    �� TickFrequency$ 1Q�5M   %    �� IsSnapToTickEnabled$
 True��5N   %    � Value$ 0Q�5O   %    � SmallChange$ 1Q�5P   %    � LargeChange$ 1Q�5Q   %   $��Center=�5R   %   $��	10,0,10,0q�5S   %   �� 5T      $��	Excellent��6(   $��Right=�69   $��Center=�6U   $
��Bold"�6p   
���"�"�#��[  6�   5U      �� 5V      #��[  6$   $��Default��6N   $��Center=�6]   
�������$
��Bold"�6�   $��0,5,28,0q�6�   5X      �� 5[      $��Comment��6    #��[  6/   $��0,0,0,5q�6Y   �� 5\      -   5        $ CommentTextbox��5\      #��[ 5]      $��80��5^        �� TextWrapping$
  Wrap=�5_      ! �� AcceptsReturn$
! True��5`      "" �� VerticalScrollBarVisibility$
" Auto=�5a      $��13(�5b      $��0,0,0,20q�5c      �� 5f      -   5        # ��Name$# SubmitRatingButton��5f        MyButtonStyle#��[ 5g      $��Submit Rating��5h      $��Right=�5i      $	��160��5j      5k      5l      5m      5n      5o      5p      