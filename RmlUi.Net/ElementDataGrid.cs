namespace ChickenWithLips.RmlUi;

public class ElementDataGrid : Element<ElementDataGrid>
{
    #region Methods

    protected ElementDataGrid(IntPtr ptr, bool automaticallyRegisterInCache)
        : base(ptr, automaticallyRegisterInCache)
    {
    }

    internal static ElementDataGrid? Create(IntPtr ptr)
    {
        return GetOrCreateCache(ptr, ptr => new ElementDataGrid(ptr, false));
    }

    #endregion
}
