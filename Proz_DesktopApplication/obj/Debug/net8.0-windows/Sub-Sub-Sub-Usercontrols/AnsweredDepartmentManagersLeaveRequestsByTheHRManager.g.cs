﻿#pragma checksum "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredDepartmentManagersLeaveRequestsByTheHRManager.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27829017AD2253A2095830912E513D8B80D34E38"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// AnsweredDepartmentManagersLeaveRequestsByTheHRManager
    /// </summary>
    public partial class AnsweredDepartmentManagersLeaveRequestsByTheHRManager : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredDepartmentManagersLeaveRequestsByTheHRManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CompletedRequestsDataGrid;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredDepartmentManagersLeaveRequestsByTheHRManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ReasonTextbox;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredDepartmentManagersLeaveRequestsByTheHRManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HRFinalMessageTextbox;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredDepartmentManagersLeaveRequestsByTheHRManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox NeededApprovalCheckbox;
        
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
            System.Uri resourceLocater = new System.Uri("/Proz_DesktopApplication;component/sub-sub-sub-usercontrols/answereddepartmentman" +
                    "agersleaverequestsbythehrmanager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredDepartmentManagersLeaveRequestsByTheHRManager.xaml"
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
            this.CompletedRequestsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 33 "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredDepartmentManagersLeaveRequestsByTheHRManager.xaml"
            this.CompletedRequestsDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CompletedRequestsDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ReasonTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.HRFinalMessageTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.NeededApprovalCheckbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

