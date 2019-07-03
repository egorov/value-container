using System;

namespace Packaging
{
  public class ValueContainer<T> : Value<T>
  {
    private static readonly ObjectValidators validators = new ObjectValidators();
    
    private T value;
    public T Value {
      get {
        return this.value;
      }
      set {
        if(value == null)
          throw new ArgumentNullException(nameof(value));

        Type type = typeof(T);

        if(validators.ContainsKey(type))
        {
          ObjectValidator validator = validators[type];
          validator.validate(value);
        }

        this.value = value;
      }
    }

    private static readonly string message = "Set the valid value first!";
    public void validate()
    {
        if(this.value == null)
          throw new InvalidOperationException(message);

        try{
          Type type = typeof(T);

          if(validators.ContainsKey(type))
          {
            ObjectValidator validator = validators[type];
            validator.validate(value);
          }
        }
        catch(ArgumentNullException)
        {
          throw new InvalidOperationException(message);
        }
        catch(ArgumentException)
        {
          throw new InvalidOperationException(message);
        }
    }
  }
}