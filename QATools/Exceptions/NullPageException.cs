namespace QATools.Exceptions;

public class NullPageException : Exception
{
    public NullPageException(string message) 
        : base(message)
    {
    }

    public NullPageException()
    {
    }
}
