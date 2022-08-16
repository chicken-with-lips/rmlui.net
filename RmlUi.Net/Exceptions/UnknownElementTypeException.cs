namespace ChickenWithLips.RmlUi.Exceptions;

public class UnknownElementTypeException : RmlExceptionBase
{
    public string ElementType { get; }

    public UnknownElementTypeException(string elementType)
    {
        ElementType = elementType;
    }
}
