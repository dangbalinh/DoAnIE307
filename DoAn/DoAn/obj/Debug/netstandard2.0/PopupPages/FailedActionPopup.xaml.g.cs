//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:7.0.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("DoAn.PopupPages.FailedActionPopup.xaml", "PopupPages/FailedActionPopup.xaml", typeof(global::DoAn.PopupPages.FailedActionPopup))]

namespace DoAn.PopupPages {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("PopupPages/FailedActionPopup.xaml")]
    public partial class FailedActionPopup : global::Xamarin.CommunityToolkit.UI.Views.Popup {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Label TitleLabel;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Lottie.Forms.AnimationView animationView;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Button Dismiss;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(FailedActionPopup));
            TitleLabel = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "TitleLabel");
            animationView = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Lottie.Forms.AnimationView>(this, "animationView");
            Dismiss = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Button>(this, "Dismiss");
        }
    }
}