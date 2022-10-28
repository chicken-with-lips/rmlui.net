namespace ChickenWithLips.RmlUi;

public class ElementDataGridRow : Element<ElementDataGridRow>
{
    #region Methods

    protected ElementDataGridRow(IntPtr ptr, bool automaticallyRegisterInCache)
        : base(ptr, automaticallyRegisterInCache)
    {
    }

    internal static ElementDataGridRow? Create(IntPtr ptr)
    {
        return GetOrCreateCache(ptr, ptr => new ElementDataGridRow(ptr, false));
    }

    #endregion
}
