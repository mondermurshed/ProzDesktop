﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proz_DesktopApplication.ParentUserControls
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class Employee_UserControl : UserControl
    {
        public Employee_UserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0.0;
            var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(450));
            this.BeginAnimation(Window.OpacityProperty, fadeIn);
            
        }
    }
}
