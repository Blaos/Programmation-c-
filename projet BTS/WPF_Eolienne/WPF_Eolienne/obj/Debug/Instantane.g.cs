﻿#pragma checksum "..\..\Instantane.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1EF4F4E7974231B682ECFB4C6168BBE88A82A13AB9085D2F397A6170B9E274E6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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


namespace WPF_Eolienne {
    
    
    /// <summary>
    /// Instantane
    /// </summary>
    public partial class Instantane : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 626 "..\..\Instantane.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox valeur_slider;
        
        #line default
        #line hidden
        
        
        #line 645 "..\..\Instantane.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Puissance;
        
        #line default
        #line hidden
        
        
        #line 717 "..\..\Instantane.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Vent;
        
        #line default
        #line hidden
        
        
        #line 773 "..\..\Instantane.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slValue;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF_Eolienne;component/instantane.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Instantane.xaml"
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
            
            #line 17 "..\..\Instantane.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 47 "..\..\Instantane.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Accueil);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 92 "..\..\Instantane.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Instantane);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 133 "..\..\Instantane.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Creation);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 171 "..\..\Instantane.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Charger);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 211 "..\..\Instantane.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Reduire);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 248 "..\..\Instantane.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Agrandir);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 287 "..\..\Instantane.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Close);
            
            #line default
            #line hidden
            return;
            case 9:
            this.valeur_slider = ((System.Windows.Controls.TextBox)(target));
            
            #line 626 "..\..\Instantane.xaml"
            this.valeur_slider.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.valeur_slider_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Puissance = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.Vent = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.slValue = ((System.Windows.Controls.Slider)(target));
            
            #line 776 "..\..\Instantane.xaml"
            this.slValue.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Slider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 843 "..\..\Instantane.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Arret);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
