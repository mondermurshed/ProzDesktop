   M S B A M L   `   `   `  ����  Proz_DesktopApplicationS    MProz_DesktopApplication.Sub_Sub_Sub_Usercontrols.CompletedPaymentsUsercontrol   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5	      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value��%c   '        �� 5
   
   "  6   .�5      ��  �@�FocusVisualStyle 61   Z� 5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��
20,20,20,0q�6.   $��0��6B   $��Center=�6O   .+�5      ��    MyTextBlockStyle#��[  6   $��Year:��6B   $��Center=�6O   $��0,0,10,0q�6j   �� 5      -   5         ��Name$ 
YearFilter��5      $	��120��6+   $��0,0,20,0q�67   �� 5      -   5         ��Name$ OnlyPaidCheckbox��5      $��Center=�61   $��Only show Unpaid��6L    d� 	IsChecked$ FalseY�6g   $��0,0,20,0q�5      �� 5      -   5          MyButtonStyle#��[ 5      $��Reload��6<   $
��20,0q�6M   6\   �� 5      -   5        #��[ 5      $��10,0,0,0q�6<   $��
Reset Year��6N   6c   5      � 5"   
   $��1��6   .+�5#      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 CompletedPaymentsDataGrid��5#      $��20,30,20,20q�5$      
 �� AlternationCount$
 1000000��5%         AutoGenerateColumns$ False��5&         
IsReadOnly$
 True��5'         SelectionMode$ Single=�5(         SelectionUnit$ FullRow=�5)       � FocusVisualStyle 5+      Z�    Columns 5,      4  .System.Windows.Controls.DataGridTemplateColumn  5-      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 68      CellTemplate 5.      �� 5/      .R�50   "   �� ��6,   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType DataGridRow �� Path$ AlternationIndex�51      53      0  *System.Windows.Controls.DataGridTextColumn  55      $ Started Date��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *PaymentPeriodStart+  56      $ 
Ended Date��6)    6=   �� *PaymentPeriodEnd+  57      $ 
Job Salary��6)    6=   �� *
BaseSalary+  58      $ Company Bonus��6)    6@   �� *CompanyBonus+  59      $ Performance Bonus��6)    6D   �� *PerformanceBonus+  5:      $ 
Deductions��6)    6=   �� *
Deductions+  5;      $ Final Amount��6)    6?   �� *FinalAmount+  5<      $ Payment Currency Type��6)    6H   �� *CurrencyType+  5=      $ Status��6)    69   �� *Status+5?      5@      5A      5B      