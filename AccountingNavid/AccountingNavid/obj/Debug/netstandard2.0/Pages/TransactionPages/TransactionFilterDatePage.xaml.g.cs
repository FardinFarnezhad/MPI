//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("AccountingNavid.Pages.TransactionPages.TransactionFilterDatePage.xaml", "Pages/TransactionPages/TransactionFilterDatePage.xaml", typeof(global::AccountingNavid.Pages.TransactionPages.TransactionFilterDatePage))]

namespace AccountingNavid.Pages.TransactionPages {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Pages\\TransactionPages\\TransactionFilterDatePage.xaml")]
    public partial class TransactionFilterDatePage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Plugin.CustomTitlePicker.Shared.TitlePicker YearFromDatePicker;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Plugin.CustomTitlePicker.Shared.TitlePicker MonthFromDatePicker;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Plugin.CustomTitlePicker.Shared.TitlePicker DayFromDatePicker;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.TimePicker FromTimePicker;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Plugin.CustomTitlePicker.Shared.TitlePicker YearToDatePicker;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Plugin.CustomTitlePicker.Shared.TitlePicker MonthToDatePicker;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Plugin.CustomTitlePicker.Shared.TitlePicker DayToDatePicker;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.TimePicker ToTimePicker;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(TransactionFilterDatePage));
            YearFromDatePicker = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Plugin.CustomTitlePicker.Shared.TitlePicker>(this, "YearFromDatePicker");
            MonthFromDatePicker = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Plugin.CustomTitlePicker.Shared.TitlePicker>(this, "MonthFromDatePicker");
            DayFromDatePicker = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Plugin.CustomTitlePicker.Shared.TitlePicker>(this, "DayFromDatePicker");
            FromTimePicker = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.TimePicker>(this, "FromTimePicker");
            YearToDatePicker = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Plugin.CustomTitlePicker.Shared.TitlePicker>(this, "YearToDatePicker");
            MonthToDatePicker = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Plugin.CustomTitlePicker.Shared.TitlePicker>(this, "MonthToDatePicker");
            DayToDatePicker = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Plugin.CustomTitlePicker.Shared.TitlePicker>(this, "DayToDatePicker");
            ToTimePicker = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.TimePicker>(this, "ToTimePicker");
        }
    }
}