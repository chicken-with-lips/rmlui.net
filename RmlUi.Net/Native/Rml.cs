using System.Runtime.InteropServices;

namespace ChickenWithLips.RmlUi.Native;

internal static class Rml
{
    [DllImport("RmlUi.Native", EntryPoint = "rml_Initialise")]
    public static extern void Initialise();

    [DllImport("RmlUi.Native", EntryPoint = "rml_Shutdown")]
    public static extern void Shutdown();

    [DllImport("RmlUi.Native", EntryPoint = "rml_SetRenderInterface")]
    public static extern void SetRenderInterface(IntPtr renderInterface);

    [DllImport("RmlUi.Native", EntryPoint = "rml_SetSystemInterface")]
    public static extern void SetSystemInterface(IntPtr systemInterface);

    [DllImport("RmlUi.Native", EntryPoint = "rml_LoadFontFace")]
    public static extern bool LoadFontFace(string fileName, bool fallbackFace, FontWeight weight);

    [DllImport("RmlUi.Native", EntryPoint = "rml_CreateEventListener")]
    public static extern IntPtr CreateEventListener(OnProcessEvent onProcessEvent, OnAttachEvent onAttachEvent, OnDetachEvent onDetachEvent);

    [DllImport("RmlUi.Native", EntryPoint = "rml_ReleaseEventListener")]
    public static extern void ReleaseEventListener(IntPtr eventListener);

    [DllImport("RmlUi.Native", EntryPoint = "rml_RemoveContext")]
    public static extern bool RemoveContext(string name);

    internal delegate void OnProcessEvent(IntPtr eventPtr);
    internal delegate void OnAttachEvent(IntPtr elementPtr, string elementType);
    internal delegate void OnDetachEvent(IntPtr elementPtr, string elementType);
}
