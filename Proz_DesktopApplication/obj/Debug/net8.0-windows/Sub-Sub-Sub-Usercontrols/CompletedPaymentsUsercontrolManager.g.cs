﻿#pragma checksum "..\..\..\..\Sub-Sub-Sub-Usercontrols\CompletedPaymentsUsercontrolManager.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0E4AE21F19DA933A84CB44A7D01B60CDEF8B063A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols {
    
    
    /// <summary>
    /// CompletedPaymentsUsercontrolManager
    /// </summary>
    public partial class CompletedPaymentsUsercontrolManager : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\Sub-Sub-Sub-Usercontrols\CompletedPaymentsUsercontrolManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SubDepartmentComboBox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Sub-Sub-Sub-Usercontrols\CompletedPaymentsUsercontrolManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox YearFilter;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Sub-Sub-Sub-Usercontrols\CompletedPaymentsUsercontrolManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox OnlyPaidCheckbox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Sub-Sub-Sub-Usercontrols\CompletedPaymentsUsercontrolManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CompletedPaymentsDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Proz_DesktopApplication;component/sub-sub-sub-usercontrols/completedpaymentsuser" +
                    "controlmanager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Sub-Sub-Sub-Usercontrols\CompletedPaymentsUsercontrolManager.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SubDepartmentComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            
            #line 35 "..\..\..\..\Sub-Sub-Sub-Usercontrols\CompletedPaymentsUsercontrolManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GetButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.YearFilter = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.OnlyPaidCheckbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            
            #line 43 "..\..\..\..\Sub-Sub-Sub-Usercontrols\CompletedPaymentsUsercontrolManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReloadButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 44 "..\..\..\..\Sub-Sub-Sub-Usercontrols\CompletedPaymentsUsercontrolManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ResetYearButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CompletedPaymentsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 56 "..\..\..\..\Sub-Sub-Sub-Usercontrols\CompletedPaymentsUsercontrolManager.xaml"
            this.CompletedPaymentsDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CompletedPaymentsDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

