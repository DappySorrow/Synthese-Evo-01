﻿#pragma checksum "..\..\UCVentesParProvince.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "348B8CB561EA3C1B7B33CB790008773EFF6DA95EF1084ADC4C5D43710156659E"
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
using UIL;


namespace UIL {
    
    
    /// <summary>
    /// UCVentesParProvince
    /// </summary>
    public partial class UCVentesParProvince : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\UCVentesParProvince.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbProvinceSomme;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\UCVentesParProvince.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbAnneesDebut;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\UCVentesParProvince.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbAnneesFin;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\UCVentesParProvince.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTypeVehicule;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\UCVentesParProvince.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnValider;
        
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
            System.Uri resourceLocater = new System.Uri("/UIL;component/ucventesparprovince.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UCVentesParProvince.xaml"
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
            
            #line 9 "..\..\UCVentesParProvince.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lbProvinceSomme = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.cbAnneesDebut = ((System.Windows.Controls.ComboBox)(target));
            
            #line 46 "..\..\UCVentesParProvince.xaml"
            this.cbAnneesDebut.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbAnneesDebut_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbAnneesFin = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cbTypeVehicule = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.btnValider = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\UCVentesParProvince.xaml"
            this.btnValider.Click += new System.Windows.RoutedEventHandler(this.btnValider_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

