﻿#pragma checksum "D:\Projekti\VS\emp-seminarska\Prevozi\Prevozi\CarshareDetails.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7FFC41F3D6959EE12403E336AC849244"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prevozi
{
    partial class CarshareDetails : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.SecondaryTileCommandBar = (global::Windows.UI.Xaml.Controls.CommandBar)(target);
                }
                break;
            case 2:
                {
                    this.PinUnPinCommandButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 11 "..\..\..\CarshareDetails.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.PinUnPinCommandButton).Click += this.PinUnPinCommandButton_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.CopyPhoneNumber = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 12 "..\..\..\CarshareDetails.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.CopyPhoneNumber).Click += this.CopyPhoneNumber_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.tblDetails = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.tblDetailsPrevoz = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.lvCarshareDetails = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

