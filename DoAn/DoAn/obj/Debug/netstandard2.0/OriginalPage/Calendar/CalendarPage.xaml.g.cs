//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("DoAn.OriginalPage.Calendar.CalendarPage.xaml", "OriginalPage/Calendar/CalendarPage.xaml", typeof(global::DoAn.OriginalPage.Calendar.CalendarPage))]

namespace DoAn.OriginalPage.Calendar {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("OriginalPage/Calendar/CalendarPage.xaml")]
    public partial class CalendarPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::XCalendar.CalendarView calendar;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.CollectionView LtsTask;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(CalendarPage));
            calendar = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::XCalendar.CalendarView>(this, "calendar");
            LtsTask = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.CollectionView>(this, "LtsTask");
        }
    }
}