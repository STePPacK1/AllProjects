﻿#pragma checksum "..\..\..\Windows\AddTeacherWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1836252DCB60947F4BED64E3DD0BA1830F397177D18CAFAA04940B9D0811A8B7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CourseApp.Windows;
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


namespace CourseApp.Windows {
    
    
    /// <summary>
    /// AddTeacherWindow
    /// </summary>
    public partial class AddTeacherWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\Windows\AddTeacherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbl_titleW;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Windows\AddTeacherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_close;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Windows\AddTeacherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_surn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Windows\AddTeacherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_name;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Windows\AddTeacherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_patro;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Windows\AddTeacherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_phone;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Windows\AddTeacherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_add;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseApp;component/windows/addteacherwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\AddTeacherWindow.xaml"
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
            this.tbl_titleW = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.b_close = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Windows\AddTeacherWindow.xaml"
            this.b_close.Click += new System.Windows.RoutedEventHandler(this.b_close_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tb_surn = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tb_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tb_patro = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tb_phone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.b_add = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\Windows\AddTeacherWindow.xaml"
            this.b_add.Click += new System.Windows.RoutedEventHandler(this.b_add_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
