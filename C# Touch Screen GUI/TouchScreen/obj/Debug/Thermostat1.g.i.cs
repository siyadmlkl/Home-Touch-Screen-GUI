#pragma checksum "..\..\Thermostat1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "85808943EAC7EB9D30231A2875B3848C1ADBC8595F07220CB0A4280B897F0B8D"
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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using TouchScreen;


namespace TouchScreen {
    
    
    /// <summary>
    /// Thermostat1
    /// </summary>
    public partial class Thermostat1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\Thermostat1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Display;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Thermostat1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button IncTemp;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Thermostat1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DecTemp;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Thermostat1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ACsw;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Thermostat1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Liv_ACsw;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Thermostat1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ACspeed;
        
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
            System.Uri resourceLocater = new System.Uri("/TouchScreen;component/thermostat1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Thermostat1.xaml"
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
            this.Display = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.IncTemp = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\Thermostat1.xaml"
            this.IncTemp.Click += new System.Windows.RoutedEventHandler(this.IncTemp_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DecTemp = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\Thermostat1.xaml"
            this.DecTemp.Click += new System.Windows.RoutedEventHandler(this.DecTemp_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ACsw = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Thermostat1.xaml"
            this.ACsw.Click += new System.Windows.RoutedEventHandler(this.ACsw_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Liv_ACsw = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\Thermostat1.xaml"
            this.Liv_ACsw.Click += new System.Windows.RoutedEventHandler(this.ACsw_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ACspeed = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\Thermostat1.xaml"
            this.ACspeed.Click += new System.Windows.RoutedEventHandler(this.ACspeed_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 27 "..\..\Thermostat1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

