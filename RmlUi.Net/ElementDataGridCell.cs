namespace ChickenWithLips.RmlUi;

public class ElementDataGridCell : Element<ElementDataGridCell>
{
    #region Methods

    protected ElementDataGridCell(IntPtr ptr, bool automaticallyRegisterInCache)
        : base(ptr, automaticallyRegisterInCache)
    {
    }

    internal static ElementDataGridCell? Create(IntPtr ptr)
    {
        return GetOrCreateCache(ptr, ptr => new ElementDataGridCell(ptr, false));
    }

    #endregion
}
