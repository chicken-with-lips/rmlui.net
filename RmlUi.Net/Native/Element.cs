using System.Runtime.InteropServices;

namespace ChickenWithLips.RmlUi.Native;

internal static class Element
{
    [DllImport("RmlUi.Native", EntryPoint = "rml_Element_GetTagName")]
    public static extern string GetTagName(IntPtr element);
}
