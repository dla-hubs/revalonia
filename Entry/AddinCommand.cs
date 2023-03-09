using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Avalonia.Controls;
using Revalonia.Addins.ViewModels;
using Revalonia.Addins.Views;
using System.Collections.Generic;

namespace Revalonia.Entry
{

    [Transaction(TransactionMode.Manual)]


    public class AddinCommand : IExternalCommand
    {
        public class WindowManager
        {
            public static List<Window> AddinWindow = new List<Window>();
        }

        Result IExternalCommand.Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Get application and document objects
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;


            if (WindowManager.AddinWindow.Count == 0)
            {
                var MainWindow = new MainWindow
                {
                    DataContext = new MainViewModel()

                };
                MainWindow.Show();
                MainWindow.Activate();
            }

            else
            {
                foreach (var window in WindowManager.AddinWindow)
                {
                    window.Show();
                    window.Activate();
                }
            }
            return Result.Succeeded;

        }
    }
}
