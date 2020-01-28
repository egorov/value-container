using System;

namespace Checking
{
  public class StringValidator : ObjectValidator
  {
    private static readonly string message = 
      "Value cannot be null, empty or whitespace string!";
    public void validate(object value)
    {
      if(!(value is string))
        throw new ArgumentException("Value should be string!");

      string v = value as string;

      if(string.IsNullOrEmpty(v))
        throw new ArgumentNullException(nameof(value), message);
      
      if(string.IsNullOrWhiteSpace(v))
        throw new ArgumentNullException(nameof(value), message);
    }
  }
}