﻿#pragma checksum "..\..\..\exterior\ProcessFiles.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B80B06603B3BABA99EB478BA5B30D859CC7F2CA8E56CA4ED1269260F21983480"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ClassScheduleProcessor.exterior;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace ClassScheduleProcessor.windows {
    
    
    /// <summary>
    /// ProcessFiles
    /// </summary>
    public partial class ProcessFiles : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\exterior\ProcessFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ClassScheduleProcessor.windows.ProcessFiles ProcessFiles_Window;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\exterior\ProcessFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Message_Label;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\exterior\ProcessFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FileLocation_Textbox;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\exterior\ProcessFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Browse_Button;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\exterior\ProcessFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Process_Button;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\exterior\ProcessFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox test_ListBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ClassScheduleProcessor;component/exterior/processfiles.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\exterior\ProcessFiles.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ProcessFiles_Window = ((ClassScheduleProcessor.windows.ProcessFiles)(target));
            return;
            case 2:
            this.Message_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.FileLocation_Textbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\..\exterior\ProcessFiles.xaml"
            this.FileLocation_Textbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FileLocation_Textbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Browse_Button = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\exterior\ProcessFiles.xaml"
            this.Browse_Button.Click += new System.Windows.RoutedEventHandler(this.Browse_Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Process_Button = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\exterior\ProcessFiles.xaml"
            this.Process_Button.Click += new System.Windows.RoutedEventHandler(this.Process_Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.test_ListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

