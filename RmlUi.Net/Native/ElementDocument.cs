using System.Runtime.InteropServices;

namespace ChickenWithLips.RmlUi.Native;

internal static class ElementDocument
{
    [DllImport("RmlUi.Native", EntryPoint = "rml_ElementDocument_Show")]
    public static extern void Show(IntPtr document, ModalFlag modalFlag, FocusFlag focusFlag);

    [DllImport("RmlUi.Native", EntryPoint = "rml_ElementDocument_Hide")]
    public static extern void Hide(IntPtr document);

    [DllImport("RmlUi.Native", EntryPoint = "rml_ElementDocument_Close")]
    public static extern void Close(IntPtr document);
}
