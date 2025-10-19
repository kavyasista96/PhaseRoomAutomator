🏗️ PhaseRoomAutomator (Revit Add-in)

Creates a Phase Room Automator tab in Revit with a Copy Rooms button.
This lets you copy rooms from a source phase into the active view’s phase, keeping the Room Name and Room Number consistent.

🧰 Requirements

Autodesk Revit 2024, 2025, or 2026

.NET Framework 4.8

Visual Studio 2022 or Developer PowerShell for VS

🧱 Build Instructions

Open Developer PowerShell for VS inside your project folder and run:

msbuild RoomsToSpaces.csproj /p:Configuration=Release


After the build completes, your compiled PhaseRoomAutomator.dll will be available inside:

bin\Release\

⚙️ Installation Steps

Copy PhaseRoomAutomator.dll and PhaseRoomAutomator.addin to your Revit Add-ins directory for each version you use:

C:\Users\<username>\AppData\Roaming\Autodesk\Revit\Addins\2024
C:\Users\<username>\AppData\Roaming\Autodesk\Revit\Addins\2025
C:\Users\<username>\AppData\Roaming\Autodesk\Revit\Addins\2026


Open the .addin file in a text editor (like Notepad) and verify that the <Assembly> path matches the correct Revit version folder, for example:

<Assembly>C:\Users\<username>\AppData\Roaming\Autodesk\Revit\Addins\2026\PhaseRoomAutomator.dll</Assembly>


Save the file and restart Revit.

You’ll now see a new ribbon tab called Phase Room Automator with the Copy Rooms button.

🧠 Usage Notes

Activate the phase/view first — the plugin copies rooms into the currently active view’s phase.

You’ll be prompted to enter the name of the source phase (e.g., “Existing” or “Phase 1”).

Only rooms that already exist in the source phase will be copied.

Each copied room keeps its name and number.

🧾 Troubleshooting

If you get a “duplicate GUID” message, open your .addin file and generate a new GUID using PowerShell:

[guid]::NewGuid()


If the Phase Room Automator tab doesn’t appear, make sure:

The .addin file references the correct Revit version path.

The PhaseRoomAutomator.dll is not blocked (right-click → Properties → Unblock).

👩‍💻 Author

Developed by Kavya Sista
GitHub: @kavyasista96

📄 License

This project is licensed under the MIT License — feel free to use, modify, and distribute it.