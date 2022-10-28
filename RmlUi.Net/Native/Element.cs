using System.Runtime.InteropServices;

namespace ChickenWithLips.RmlUi.Native;

internal static class Element
{
    [DllImport("RmlUi.Native", EntryPoint = "rml_Element_GetTagName")]
    public static extern IntPtr GetTagName(IntPtr element);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Element_AddEventListener")]
    public static extern void AddEventListener(IntPtr element, string name, IntPtr eventListener, bool inCapturePhase);

    [DllImport("RmlUi.Native", EntryPoint = "rml_Element_RemoveEventListener")]
    public static extern void RemoveEventListener(IntPtr element, string name, IntPtr eventListener, bool inCapturePhase);
    
    [DllImport("RmlUi.Native", EntryPoint = "rml_Element_GetElementByID")]
    public static extern IntPtr GetElementById(IntPtr element, string id, out IntPtr foundElement);
    
    [DllImport("RmlUi.Native", EntryPoint = "rml_Element_GetOwnerDocument")]
    public static extern IntPtr GetOwnerDocument(IntPtr element, out IntPtr foundElement);
}
