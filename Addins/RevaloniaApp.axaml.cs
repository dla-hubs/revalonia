using Autodesk.Revit.UI;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Revalonia.Addins.Views;


namespace Revalonia.Addins
{

    public partial class RevaloniaApp : Application
    {
        public static new IClassicDesktopStyleApplicationLifetime ApplicationLifetime { get; set; }


        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }


        public override void OnFrameworkInitializationCompleted()
        {


            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
               // desktop.ShutdownMode = ShutdownMode.OnLastWindowClose;
              desktop.MainWindow = new MainWindow();
            }

    

            base.OnFrameworkInitializationCompleted();
        }
    }
}
