﻿#pragma checksum "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredFeedbacksRequestsByTheManager.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F09A7A2D023AC0B8BC208C07F580BE1D7BD429B7"
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
    /// AnsweredFeedbacksRequestsByTheManager
    /// </summary>
    public partial class AnsweredFeedbacksRequestsByTheManager : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredFeedbacksRequestsByTheManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SubDepartmentComboBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredFeedbacksRequestsByTheManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid AnsweredFeedbacksDataGrid;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredFeedbacksRequestsByTheManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DescriptionTextbox;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredFeedbacksRequestsByTheManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AnswerTextbox;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredFeedbacksRequestsByTheManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AnswerDateTextbox;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredFeedbacksRequestsByTheManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RespondentTextbox;
        
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
            System.Uri resourceLocater = new System.Uri("/Proz_DesktopApplication;component/sub-sub-sub-usercontrols/answeredfeedbacksrequ" +
                    "estsbythemanager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredFeedbacksRequestsByTheManager.xaml"
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
            
            #line 29 "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredFeedbacksRequestsByTheManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GetButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AnsweredFeedbacksDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 39 "..\..\..\..\Sub-Sub-Sub-Usercontrols\AnsweredFeedbacksRequestsByTheManager.xaml"
            this.AnsweredFeedbacksDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.AnsweredFeedbacksDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DescriptionTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AnswerTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.AnswerDateTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.RespondentTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

