using System.Runtime.InteropServices;

namespace ChickenWithLips.RmlUi;

public interface Element
{
    public IntPtr NativePtr { get; }
    public string TagName { get; }
}

public abstract class Element<T> : RmlBase<T>, Element
    where T : class
{
    #region Properties

    public string TagName => Marshal.PtrToStringAuto(Native.Element.GetTagName(NativePtr));

    #endregion

    #region Methods

    protected Element(IntPtr ptr, bool automaticallyRegisterInCache)
        : base(ptr, automaticallyRegisterInCache)
    {
    }

    #endregion
}
