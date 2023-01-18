using System.Runtime.InteropServices;

namespace ChickenWithLips.RmlUi.Native;

internal static class Context
{
    [DllImport("RmlUi.Native", EntryPoint = "rml_Context_New")]
    public static extern IntPtr Create(string name, Vector2i dimensions, IntPtr renderInterface);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Context_Delete")]
    public static extern void Delete(IntPtr context);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Context_Update")]
    public static extern void Update(IntPtr context);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Context_Render")]
    public static extern void Render(IntPtr context);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Context_LoadDocument")]
    public static extern IntPtr LoadDocument(IntPtr context, string documentPath);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Context_LoadDocumentFromMemory")]
    public static extern IntPtr LoadDocumentFromMemory(IntPtr context, string documentRml, string sourceUrl);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Context_LoadDocumentFromMemory")]
    public static extern bool IsMouseInteracting(IntPtr context);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Context_ProcessMouseLeave")]
    public static extern bool ProcessMouseLeave(IntPtr context);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Context_ProcessMouseMove")]
    public static extern bool ProcessMouseMove(IntPtr context, int x, int y, int keyModifierState);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Context_ProcessMouseButtonDown")]
    public static extern bool ProcessMouseButtonDown(IntPtr context, int buttonIndex, int keyModifierState);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Context_ProcessMouseButtonUp")]
    public static extern bool ProcessMouseButtonUp(IntPtr context, int buttonIndex, int keyModifierState);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Context_AddEventListener")]
    public static extern void AddEventListener(IntPtr context, string name, IntPtr eventListener, bool inCapturePhase);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Context_RemoveEventListener")]
    public static extern void RemoveEventListener(IntPtr context, string name, IntPtr eventListener, bool inCapturePhase);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Context_GetName")]
    public static extern IntPtr GetName(IntPtr context);
}
