   M S B A M L   `   `   `  ����R  NProz_DesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols0Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols  5      Z    TProz_DesktopApplication.Sub_Sub_Sub_Usercontrols.CompletedPaymentsUsercontrolManager   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Plocal>clr-namespace:Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols     5        � 	Resources  5
      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value��%c   '        �� 5   
   "  6   .�5      ��  �@�FocusVisualStyle 61   Z� 5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��
20,20,20,0q�6.   $��0��6B   .+�5      �� $��Sub-Department:��6      MyTextBlockStyle#��[  5      $��Center=�5      $��0,0,10,0q�5      �� 5      -   5         ��Name$ SubDepartmentComboBox��5      $	��200��5      $��0,0,10,0q�5      �� 5       -   5        $	��Get��5         MyButtonStyle#��[ 5!      $��80��5"      5#      5$      �� 5'   
   $ 
Horizontal=�6   $��
20,10,20,0q�6.   $��1��6B   .+�5(      �� #��[  6   $��Year:��6B   $��Center=�6O   $��0,0,10,0q�6j   �� 5)      -   5        $ 
YearFilter��5)      $	��120��6+   $��0,0,20,0q�67   �� 5*      -   5         ��Name$ OnlyPaidCheckbox��5*      $��Center=�61   $��Only show Unpaid��6L   $��0,0,20,0q�6g   �� 5+      -   5        #��[ 5+      $��Reload��6<   $
��20,0q�6M   6\   �� 5,      -   5        #��[ 5,      $��10,0,0,0q�6<   $��
Reset Year��6N   6c   5-      � 50   
   $��2��6   .+�51      &   System.Windows.Controls.DataGrid  -   5          Name$ CompletedPaymentsDataGrid��51      $��20,30,20,20q�52      	 �� AlternationCount$	 1000000��53      
   AutoGenerateColumns$
 False��54         
IsReadOnly$
 True��55         SelectionMode$ Single=�56         SelectionUnit$ FullRow=�57       � FocusVisualStyle 59      Z�    Columns 5:      4  .System.Windows.Controls.DataGridTemplateColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 68      CellTemplate 5<      �� 5=      .R�5>   "   �� ��6,   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType DataGridRow �� Path$ AlternationIndex�5?      5A      0  *System.Windows.Controls.DataGridTextColumn  5C      $ Started Date��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *PaymentPeriodStart+  5D      $ 
Ended Date��6)    6=   �� *PaymentPeriodEnd+  5E      $ 
Job Salary��6)    6=   �� *
BaseSalary+  5F      $ Company Bonus��6)    6@   �� *CompanyBonus+  5G      $ Performance Bonus��6)    6D   �� *PerformanceBonus+  5H      $ 
Deductions��6)    6=   �� *
Deductions+  5I      $ Final Amount��6)    6?   �� *FinalAmount+  5J      $ Payment Currency Type��6)    6H   �� *CurrencyType+  5K      $ Status��6)    69   �� *Status+5M      5N      5O      5P      