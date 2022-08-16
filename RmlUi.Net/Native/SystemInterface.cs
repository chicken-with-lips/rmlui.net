using System.Runtime.InteropServices;
using System.Text;

namespace ChickenWithLips.RmlUi.Native;

internal static class SystemInterface
{
    [DllImport("RmlUi.Native", EntryPoint = "rml_SystemInterface_New")]
    public static extern IntPtr Create(OnGetElapsedTime onGetElapsedTime, OnTranslateString onTranslateString, OnLogMessage onLogMessage);

    internal delegate double OnGetElapsedTime();

    internal delegate string OnTranslateString(ref int changeCount, string input);

    internal delegate bool OnLogMessage(LogType type, string message);
}
