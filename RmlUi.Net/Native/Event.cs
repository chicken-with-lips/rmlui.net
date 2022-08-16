using System.Runtime.InteropServices;
using System.Text;

namespace ChickenWithLips.RmlUi.Native;

internal static class Event
{
    [DllImport("RmlUi.Native", EntryPoint = "rml_Event_GetId")]
    public static extern ushort GetId(IntPtr ev);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Event_GetPhase")]
    public static extern int GetPhase(IntPtr ev);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Event_GetCurrentElement")]
    public static extern IntPtr GetCurrentElement(IntPtr ev, out IntPtr element);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Event_GetTargetElement")]
    public static extern IntPtr GetTargetElement(IntPtr ev, out IntPtr element);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Event_StopPropagation")]
    public static extern void StopPropagation(IntPtr ev);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Event_StopImmediatePropagation")]
    public static extern void StopImmediatePropagation(IntPtr ev);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Event_IsInterruptible")]
    public static extern bool IsInterruptible(IntPtr ev);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Event_IsPropagating")]
    public static extern bool IsPropagating(IntPtr ev);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Event_IsImmediatePropagating")]
    public static extern bool IsImmediatePropagating(IntPtr ev);
}
