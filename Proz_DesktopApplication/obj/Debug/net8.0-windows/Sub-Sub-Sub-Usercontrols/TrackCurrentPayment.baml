   M S B A M L   `   `   `  ����  Proz_DesktopApplicationJ    DProz_DesktopApplication.Sub_Sub_Sub_Usercontrols.TrackCurrentPayment   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5	      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value��%c   '        �� 5
   
   "  6   .�5      ��  �@�FocusVisualStyle 61   Z� 5      5      .��5      � $��20q�6   .+�5   
   �� $
��Auto=�6   .��5      ��  �� Orientation$ Vertical=�6   $��	0,10,0,10q�60   .+�5      �� $��Current Payment Overview��6   $��18(�5      $
��Bold"�5      $��0,0,0,20q�5         MyTextBlockStyle#��[  5      � 5      $��0,0,0,20q�6    � ColumnDefinitions 5      �� 5      $��* �6+   �� 5      $��* �6+   .+�5!      �� $��0��6!   $��0,0,10,0q�61   .+�5"      �� $��Payment Period Start��6$   #��[  6@   �� 5#      -   5         ��Name$ PeriodStartTextBox��5#   "     MyTextBoxStyle#��[ 6>    �� 
IsReadOnly$
 True��6f   $��0,5,0,0q�6x   5$      �� 5&      $��1��6!   $��10,0,0,0q�61   .+�5'      �� $��Payment Period End��6$   #��[  6>   �� 5(      -   5        $ PeriodEndTextBox��5(   "   #��[ 6<   $
 True��6d   $��0,5,0,0q�6v   5)      5*      �� 5-      $��Salary Details��6   $
��Bold"�62   #��[  6D   $��	0,10,0,10q�6n   � 5.      $��0,0,0,20q�6    5/      �� 50      $��* �6+   �� 51      $��* �6+   .+�54      �� $��0��6!   $��0,0,10,0q�61   .+�55      �� $��Base Salary��6$   #��[  67   �� 56      -   5        $ BaseSalaryTextBox��56   "   #��[ 6=   $
 True��6e   $��0,5,0,0q�6w   57      �� 59      $��1��6!   $��10,0,0,0q�61   .+�5:      �� $��Company Bonus��6$   #��[  69   �� 5;      -   5        $ CompanyBonusTextBox��5;   "   #��[ 6?   $
 True��6g   $��0,5,0,0q�6y   5<      5=      �� 5@      $��Adjustments��6   $
��Bold"�6/   #��[  6A   $��	0,10,0,10q�6k   � 5A      $��0,0,0,20q�6    5B      �� 5C      $��* �6+   �� 5D      $��* �6+   .+�5G      �� $��0��6!   $��0,0,10,0q�61   .+�5H      �� $��Performance Bonus��6$   #��[  6=   �� 5I      -   5        $ PerformanceBonusTextBox��5I   "   #��[ 6C   $
 True��6k   $��0,5,0,0q�6}   5J      �� 5L      $��1��6!   $��10,0,0,0q�61   .+�5M      �� $��
Deductions��6$   #��[  66   �� 5N      -   5        $ DeductionsTextBox��5N   "   #��[ 6=   $
 True��6e   $��0,5,0,0q�6w   5O      5P      �� 5S      $��Final Amount��6   $
��Bold"�60   #��[  6B   $��0,10,0,5q�6l   �� 5T      -   5        $ FinalAmountTextBox��5T      #��[ 66   $
 True��6^   $��0,0,0,20q�6p   5U      5V      5W      5X      