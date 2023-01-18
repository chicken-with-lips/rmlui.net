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
        if (elementType == "class Rml::ElementDocument") {
            return ElementDocument.Create(elementPtr);
        } else if (elementType == "class Rml::ElementDataGrid") {
            return ElementDataGrid.Create(elementPtr);
        } else if (elementType == "class Rml::ElementDataGridCell") {
            return ElementDataGridCell.Create(elementPtr);
        } else if (elementType == "class Rml::ElementDataGridExpandButton") {
            return ElementDataGridExpandButton.Create(elementPtr);
        } else if (elementType == "class Rml::ElementDataGridRow") {
            return ElementDataGridRow.Create(elementPtr);
        } else if (elementType == "class Rml::ElementDocument") {
            return ElementDocument.Create(elementPtr);
        } else if (elementType == "class Rml::ElementForm") {
            return ElementForm.Create(elementPtr);
        } else if (elementType == "class Rml::ElementFormControl") {
            return ElementFormControl.Create(elementPtr);
        } else if (elementType == "class Rml::ElementFormControlDataSelect") {
            return ElementFormControlDataSelect.Create(elementPtr);
        } else if (elementType == "class Rml::ElementFormControlInput") {
            return ElementFormControlInput.Create(elementPtr);
        } else if (elementType == "class Rml::ElementFormControlSelect") {
            return ElementFormControlSelect.Create(elementPtr);
        } else if (elementType == "class Rml::ElementFormControlTextArea") {
            return ElementFormControlTextArea.Create(elementPtr);
        } else if (elementType == "class Rml::ElementProgress") {
            return ElementProgress.Create(elementPtr);
        } else if (elementType == "class Rml::ElementTabSet") {
            return ElementTabSet.Create(elementPtr);
        } else if (elementType == "class Rml::ElementText") {
            return ElementText.Create(elementPtr);
        } else if (elementType == "class Rml::Element") {
            return ElementGeneric.Create(elementPtr);
        }

        return null;
    }
}
