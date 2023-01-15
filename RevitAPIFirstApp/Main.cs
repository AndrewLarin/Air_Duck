using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPIFirstApp
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<MechanicalSystem> fInstances = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_DuctSystem)
                .WhereElementIsNotElementType()
                .Cast<MechanicalSystem>()
                .ToList();
            TaskDialog.Show("Quantity_DuctSystem", fInstances.Count.ToString());
            return Result.Succeeded;
        }
    }
}
