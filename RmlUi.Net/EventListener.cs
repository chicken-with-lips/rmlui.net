using ChickenWithLips.RmlUi.Exceptions;

namespace ChickenWithLips.RmlUi;

public class Event : RmlBase<Event>
{
    public Event(IntPtr ptr, bool automaticallyRegisterInCache = false) : base(ptr, automaticallyRegisterInCache)
    {
    }
}

public abstract class EventListener : RmlBase<EventListener>
{
    private Native.Rml.OnProcessEvent _onProcessEvent;
    private Native.Rml.OnAttachEvent _onAttachEvent;
    private Native.Rml.OnDetachEvent _onDetachEvent;

    public EventListener() : base(IntPtr.Zero)
    {
        _onProcessEvent = ProcessEventInternal;
        _onAttachEvent = AttachEventInternal;
        _onDetachEvent = DetachEventInternal;

        NativePtr = Native.Rml.CreateEventListener(
            _onProcessEvent,
            _onAttachEvent,
            _onDetachEvent
        );

        ManuallyRegisterCache(NativePtr, this);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        Native.Rml.ReleaseEventListener(NativePtr);
    }

    internal void ProcessEventInternal(IntPtr eventPtr)
    {
        Console.WriteLine("ProcessEventInternal");
    }

    internal void AttachEventInternal(IntPtr elementPtr, string elementType)
    {
        OnAttach(
            Util.GetOrThrowElementByTypeName(elementPtr, elementType)
        );
    }

    internal void DetachEventInternal(IntPtr elementPtr, string elementType)
    {
        OnDetach(
            Util.GetOrThrowElementByTypeName(elementPtr, elementType)
        );
    }

    public abstract void ProcessEvent(Event ev);

    public virtual void OnAttach(Element element)
    {
        Console.WriteLine("OnAttach: " + element.GetType().Name);
    }

    public virtual void OnDetach(Element element)
    {
    }
}
