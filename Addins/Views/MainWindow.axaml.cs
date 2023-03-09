using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Revalonia.Entry;

namespace Revalonia.Addins.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            AvaloniaXamlLoader.Load(this);
            AddinCommand.WindowManager.AddinWindow.Add(this);


            Closing += (s, e) =>
            {
                Hide();
                e.Cancel = true;
            };


        }

    }
}
