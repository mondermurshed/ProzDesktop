   M S B A M L   `   `   `  ����R  NProz_DesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols0Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols  5      Q    KProz_DesktopApplication.Sub_Sub_Sub_Usercontrols.TrackCurrentPaymentManager   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Plocal>clr-namespace:Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols     5        � 	Resources  5
      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value��%c   '        �� 5   
   "  6   .�5      ��  �@�FocusVisualStyle 61   Z� 5      5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,20q�6.   $��0��6@   .+�5      �� $��Sub-Department:��6      MyTextBlockStyle#��[  5      $��Center=�5      $��0,0,10,0q�5      �� 5      -   5         ��Name$ SubDepartmentComboBox��5      $	��200��5      $��0,0,10,0q�5       �� 5!      -   5        $	��Get��5!        MyButtonStyle#��[ 5"      $��80��5#      5$      5%      �� 5(   
   $��1��6   $
��Auto=�6$   .��5)      �� $ Vertical=�6   $��
0,10,10,10q�60   .+�5,      �� $��Current Payment Overview��6   $��18(�5-      $
��Bold"�5.      $��0,0,0,20q�5/      #��[  50      � 53      $��0,0,0,20q�6    � ColumnDefinitions 54      �� 55      $��* �6+   �� 56      $��* �6+   .+�59      �� $��0��6!   $��0,0,10,0q�61   .+�5:      �� $��Payment Period Start��6$   #��[  6@   �� 5;      -   5         ��Name$ PeriodStartTextBox��5;   "     MyTextBoxStyle#��[ 6>   	 �� 
IsReadOnly$
	 True��6f   $��0,5,0,0q�6x   5<      �� 5>      $��1��6!   $��10,0,0,0q�61   .+�5?      �� $��Payment Period End��6$   #��[  6>   �� 5@      -   5        $ PeriodEndTextBox��5@   "   #��[ 6<   $
	 True��6d   $��0,5,0,0q�6v   5A      5B      �� 5E      $��Salary Details��6   $
��Bold"�62   #��[  6D   $��	0,10,0,10q�6n   � 5F      $��0,0,0,20q�6    5G      �� 5H      $��* �6+   �� 5I      $��* �6+   .+�5L      �� $��0��6!   $��0,0,10,0q�61   .+�5M      �� $��Base Salary��6$   #��[  67   �� 5N      -   5        $ BaseSalaryTextBox��5N   "   #��[ 6=   $
	 True��6e   $��0,5,0,0q�6w   5O      �� 5Q      $��1��6!   $��10,0,0,0q�61   .+�5R      �� $��Company Bonus��6$   #��[  69   �� 5S      -   5        $ CompanyBonusTextBox��5S   "   #��[ 6?   $
	 True��6g   $��0,5,0,0q�6y   5T      5U      �� 5X      $��Adjustments��6   $
��Bold"�6/   #��[  6A   $��	0,10,0,10q�6k   � 5Y      $��0,0,0,20q�6    5Z      �� 5[      $��* �6+   �� 5\      $��* �6+   .+�5_      �� $��0��6!   $��0,0,10,0q�61   .+�5`      �� $��Performance Bonus��6$   #��[  6=   �� 5a      -   5        $ PerformanceBonusTextBox��5a   "   #��[ 6C   $
	 True��6k   $��0,5,0,0q�6}   5b      �� 5d      $��1��6!   $��10,0,0,0q�61   .+�5e      �� $��
Deductions��6$   #��[  66   �� 5f      -   5        $ DeductionsTextBox��5f   "   #��[ 6=   $
	 True��6e   $��0,5,0,0q�6w   5g      5h      �� 5k      $��Final Amount��6   $
��Bold"�60   #��[  6B   $��0,10,0,5q�6l   �� 5l      -	   5        $ FinalAmountTextBox��5l      #��[ 66   $
	 True��6^   $��0,0,0,20q�6p   5m      5n      5o      5q      