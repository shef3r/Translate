﻿#pragma checksum "C:\Users\shefer\Source\Repos\shef3r\Translate\AppWindowPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5126233C75951FD6D89A8E88551D3988FF192B95A15464BEB44C9ECC1F4CB072"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Translate
{
    partial class AppWindowPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // AppWindowPage.xaml line 1
                {
                    this.page = (global::Windows.UI.Xaml.Controls.Page)(target);
                }
                break;
            case 2: // AppWindowPage.xaml line 19
                {
                    this.maingrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // AppWindowPage.xaml line 22
                {
                    this.mainmf = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // AppWindowPage.xaml line 51
                {
                    this.fromchosen = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // AppWindowPage.xaml line 52
                {
                    this.tochosen = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // AppWindowPage.xaml line 34
                {
                    this.Translate = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Translate).Click += this.Translate_Click;
                }
                break;
            case 7: // AppWindowPage.xaml line 40
                {
                    this.output = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // AppWindowPage.xaml line 45
                {
                    this.to = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.to).SelectionChanged += this.to_SelectionChanged;
                }
                break;
            case 9: // AppWindowPage.xaml line 36
                {
                    this.MFD = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // AppWindowPage.xaml line 24
                {
                    this.input = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.input).TextChanged += this.input_TextChanged;
                }
                break;
            case 11: // AppWindowPage.xaml line 29
                {
                    this.from = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.from).SelectionChanged += this.from_SelectionChanged;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

