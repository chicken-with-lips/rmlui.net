namespace ChickenWithLips.RmlUi;

public class ElementDataGridExpandButton : Element<ElementDataGridExpandButton>
{
    #region Methods

    protected ElementDataGridExpandButton(IntPtr ptr, bool automaticallyRegisterInCache)
        : base(ptr, automaticallyRegisterInCache)
    {
    }

    internal static ElementDataGridExpandButton? Create(IntPtr ptr)
    {
        return GetOrCreateCache(ptr, ptr => new ElementDataGridExpandButton(ptr, false));
    }

    #endregion
}
