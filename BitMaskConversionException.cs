using System.Runtime.Serialization;

namespace Problem2
{
    
    public class BitMaskConversionException : Exception
    {
       public BitMaskConversionException(string message) : base(message)
        {
        }
    }
}