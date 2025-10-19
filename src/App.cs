using System.Reflection;
using Autodesk.Revit.UI;

namespace PhaseRoomAutomator
{
    public class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication app)
        {
            string tabName = "Phase Room Automator";

            // Create tab (ignore if it already exists)
            try { app.CreateRibbonTab(tabName); } catch { }

            // Create a panel
            RibbonPanel panel = app.CreateRibbonPanel(tabName, "Tools");

            // Create a button linked to your RoomPhaseCopier command
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            PushButtonData btnData = new PushButtonData(
                "RoomPhaseCopier",
                "Copy Rooms",
                assemblyPath,
                "PhaseRoomAutomator.RoomPhaseCopier"
            );

            panel.AddItem(btnData);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication app)
        {
            return Result.Succeeded;
        }
    }
}
