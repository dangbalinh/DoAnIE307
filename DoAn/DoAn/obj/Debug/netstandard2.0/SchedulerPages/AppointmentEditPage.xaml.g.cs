//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("DoAn.SchedulerPages.AppointmentEditPage.xaml", "SchedulerPages/AppointmentEditPage.xaml", typeof(global::SchedulerExample.AppointmentPages.CustomAppointmentEditPage))]

namespace SchedulerExample.AppointmentPages {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("SchedulerPages/AppointmentEditPage.xaml")]
    public partial class CustomAppointmentEditPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.ToolbarItem saveToolbarItem;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.StackLayout root;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::DevExpress.XamarinForms.Editors.TextEdit eventNameEntry;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Switch allDaySwitch;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::DevExpress.XamarinForms.CollectionView.DXCollectionView reminderContainer;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(CustomAppointmentEditPage));
            saveToolbarItem = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ToolbarItem>(this, "saveToolbarItem");
            root = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.StackLayout>(this, "root");
            eventNameEntry = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::DevExpress.XamarinForms.Editors.TextEdit>(this, "eventNameEntry");
            allDaySwitch = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Switch>(this, "allDaySwitch");
            reminderContainer = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::DevExpress.XamarinForms.CollectionView.DXCollectionView>(this, "reminderContainer");
        }
    }
}