﻿#pragma checksum "..\..\..\Views\UserPageStream.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "14744A7BDBBA56E872AA51C88919E79E15CA64767A5ACEB24E122107BBFB1894"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Social_network.Views;
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


namespace Social_network.Views {
    
    
    /// <summary>
    /// UserPageStream
    /// </summary>
    public partial class UserPageStream : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Views\UserPageStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel mainStackUserContent;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Views\UserPageStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock blockFirstName;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Views\UserPageStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock blockSecondName;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Views\UserPageStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock blockEmail;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\UserPageStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock blockInterests;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\UserPageStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bFollow;
        
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
            System.Uri resourceLocater = new System.Uri("/Social_network;component/views/userpagestream.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\UserPageStream.xaml"
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
            
            #line 10 "..\..\..\Views\UserPageStream.xaml"
            ((Social_network.Views.UserPageStream)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mainStackUserContent = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.blockFirstName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.blockSecondName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.blockEmail = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.blockInterests = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.bFollow = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Views\UserPageStream.xaml"
            this.bFollow.Click += new System.Windows.RoutedEventHandler(this.bFollow_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

