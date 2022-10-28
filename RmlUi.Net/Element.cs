using System.Runtime.InteropServices;

namespace ChickenWithLips.RmlUi;

public interface Element
{
    public IntPtr NativePtr { get; }
    public string TagName { get; }

    /// <summary>
    /// Adds an event listener to this element.
    /// </summary>
    /// <param name="name">The name of the event to attach to.</param>
    /// <param name="eventListener">Listener object to be attached.</param>
    /// <param name="inCapturePhase">True if the listener is to be attached to the capture phase, false for the bubble phase.</param>
    public void AddEventListener(string name, EventListener eventListener, bool inCapturePhase = false);

    /// <summary>
    /// Adds an event listener to this element.
    /// </summary>
    /// <param name="name">The name of the event to attach to.</param>
    /// <param name="eventListener">Listener object to be attached.</param>
    /// <param name="inCapturePhase">True if the listener is to be attached to the capture phase, false for the bubble phase.</param>
    public void RemoveEventListener(string name, EventListener eventListener, bool inCapturePhase = false);

    /// <summary>
    /// Get a child element by its ID.
    /// </summary>
    /// <param name="id">ID of the the child element</param>
    /// <returns>The child of this element with the given ID, or null if no such child exists.</returns>
    public Element? GetElementById(string id);
}

public abstract class Element<T> : RmlBase<T>, Element
    where T : class
{
    #region Properties

    public string TagName => Marshal.PtrToStringAuto(Native.Element.GetTagName(NativePtr));

    /// <summary>
    /// Gets the document this element belongs to.
    /// </summary>
    public ElementDocument OwnerDocument {
        get {
            var elementType = Marshal.PtrToStringAuto(
                Native.Element.GetOwnerDocument(NativePtr, out var elementPtr)
            );

            return Util.GetOrThrowElementByTypeName(elementPtr, elementType) as ElementDocument;
        }
    }

    #endregion

    #region Methods

    protected Element(IntPtr ptr, bool automaticallyRegisterInCache)
        : base(ptr, automaticallyRegisterInCache)
    {
    }

    /// <summary>
    /// Adds an event listener to this element.
    /// </summary>
    /// <param name="name">The name of the event to attach to.</param>
    /// <param name="eventListener">Listener object to be attached.</param>
    /// <param name="inCapturePhase">True if the listener is to be attached to the capture phase, false for the bubble phase.</param>
    public void AddEventListener(string name, EventListener eventListener, bool inCapturePhase = false)
    {
        Native.Element.AddEventListener(NativePtr, name, eventListener.NativePtr, inCapturePhase);
    }

    /// <summary>
    /// Adds an event listener to this element.
    /// </summary>
    /// <param name="name">The name of the event to attach to.</param>
    /// <param name="eventListener">Listener object to be attached.</param>
    /// <param name="inCapturePhase">True if the listener is to be attached to the capture phase, false for the bubble phase.</param>
    public void RemoveEventListener(string name, EventListener eventListener, bool inCapturePhase = false)
    {
        Native.Element.RemoveEventListener(NativePtr, name, eventListener.NativePtr, inCapturePhase);
    }

    /// <summary>
    /// Get a child element by its ID.
    /// </summary>
    /// <param name="id">ID of the the child element</param>
    /// <returns>The child of this element with the given ID, or null if no such child exists.</returns>
    public Element? GetElementById(string id)
    {
        var nativeElementType = Native.Element.GetElementById(NativePtr, id, out var elementPtr);

        if (null == nativeElementType) {
            return null;
        }

        var elementType = Marshal.PtrToStringAuto(nativeElementType);

        if (null == elementType) {
            return null;
        }

        return Util.GetOrThrowElementByTypeName(elementPtr, elementType);
    }

    #endregion
}
