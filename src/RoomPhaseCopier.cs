using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Microsoft.VisualBasic;
using System.Linq;

namespace PhaseRoomAutomator
{
    [Transaction(TransactionMode.Manual)]
    public class RoomPhaseCopier : IExternalCommand
    {
        private string PromptInput(string title, string instruction)
        {
            return Interaction.InputBox(instruction, title, "");
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            View activeView = doc.ActiveView;

            // Ask user only for the *source* phase. Target phase = phase of active view
            string src = PromptInput("Source Phase", "Name of Phase to copy FROM:");
            if (string.IsNullOrEmpty(src)) return Result.Cancelled;

            Phase source = doc.Phases.Cast<Phase>().FirstOrDefault(p => p.Name == src);
            if (source == null)
            {
                TaskDialog.Show("Error", $"Phase '{src}' not found.");
                return Result.Cancelled;
            }

            using (Transaction t = new Transaction(doc, "Copy Rooms to Active View"))
            {
                t.Start();
                foreach (SpatialElement r in new FilteredElementCollector(doc)
                    .OfCategory(BuiltInCategory.OST_Rooms).WhereElementIsNotElementType())
                {
                    if (r.get_Parameter(BuiltInParameter.ROOM_PHASE).AsElementId() == source.Id)
                    {
                        Level lvl = doc.GetElement(r.LevelId) as Level;
                        LocationPoint lp = r.Location as LocationPoint;
                        if (lp == null) continue;

                        // Create placed room in the active view location (inherits active view’s phase)
                        SpatialElement newR = doc.Create.NewRoom(lvl, new UV(lp.Point.X, lp.Point.Y));

                        // --- Copy Number and Name *after* creating the new room (safe!) ---
                        newR.Number = r.Number;
                        newR.Name = r.Name;
                    }
                }
                t.Commit();
            }

            TaskDialog.Show("Done", "Rooms copied into current view’s phase with Number & Name.");
            return Result.Succeeded;
        }
    }
}
