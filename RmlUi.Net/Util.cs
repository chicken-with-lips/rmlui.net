using ChickenWithLips.RmlUi.Exceptions;

namespace ChickenWithLips.RmlUi;

internal static class Util
{
    public static Element GetOrThrowElementByTypeName(IntPtr elementPtr, string elementType)
    {
        var element = GetElementByTypeName(elementPtr, elementType);

        if (null == element) {
            throw new UnknownElementTypeException(elementType);
        }

        return element;
    }

    public static Element? GetElementByTypeName(IntPtr elementPtr, string elementType)
    {
        if (elementType == "ElementDocument") {
            return ElementDocument.Create(elementPtr);
        } else if (elementType == "ElementDataGrid") {
            return ElementDataGrid.Create(elementPtr);
        } else if (elementType == "ElementDataGridCell") {
            return ElementDataGridCell.Create(elementPtr);
        } else if (elementType == "ElementDataGridExpandButton") {
            return ElementDataGridExpandButton.Create(elementPtr);
        } else if (elementType == "ElementDataGridRow") {
            return ElementDataGridRow.Create(elementPtr);
        } else if (elementType == "ElementDocument") {
            return ElementDocument.Create(elementPtr);
        } else if (elementType == "ElementForm") {
            return ElementForm.Create(elementPtr);
        } else if (elementType == "ElementFormControl") {
            return ElementFormControl.Create(elementPtr);
        } else if (elementType == "ElementFormControlDataSelect") {
            return ElementFormControlDataSelect.Create(elementPtr);
        } else if (elementType == "ElementFormControlInput") {
            return ElementFormControlInput.Create(elementPtr);
        } else if (elementType == "ElementFormControlSelect") {
            return ElementFormControlSelect.Create(elementPtr);
        } else if (elementType == "ElementFormControlTextArea") {
            return ElementFormControlTextArea.Create(elementPtr);
        } else if (elementType == "ElementProgress") {
            return ElementProgress.Create(elementPtr);
        } else if (elementType == "ElementTabSet") {
            return ElementTabSet.Create(elementPtr);
        } else if (elementType == "ElementText") {
            return ElementText.Create(elementPtr);
        } else if (elementType == "Element") {
            return ElementGeneric.Create(elementPtr);
        }

        return null;
    }
}
