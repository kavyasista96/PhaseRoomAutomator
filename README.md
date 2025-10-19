# PhaseRoomAutomator (Revit Add-in)

Creates a **Phase Room Automator** tab in Revit with a **Copy Rooms** button.  
This lets you copy rooms from a *source phase* into the *active view’s phase*, keeping the **Name** and **Number**.

---

## 🧰 Requirements
- Autodesk Revit 2026 (works for 2024–2025 too)
- .NET Framework 4.8
- Visual Studio / Developer PowerShell for VS

---

## 🧱 Build Instructions
Open **Developer PowerShell for VS** in this folder and run:
```powershell
msbuild RoomsToSpaces.csproj /p:Configuration=Release
