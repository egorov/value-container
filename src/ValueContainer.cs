using System;

namespace Packaging
{
  public class ValueContainer<T> : Value<T>
  {
    private string message = 
      $"Set the container Value with valid {typeof(T)} first!";
    private CustomValidators validators;

    public ValueContainer() : this(new ObjectValidators()) {}

    public ValueContainer(CustomValidators validators)
    {
      if(validators == null)
        throw new ArgumentNullException(nameof(validators));

      this.validators = validators;
      this.type = typeof(T);
    }
    
    private Type type;
    private T value;
    public T Value {
      get {
        return this.value;
      }
      set {
        if(value == null)
          throw new ArgumentNullException(nameof(value));

        this.value = value;

        this.validateCustom();
      }
    }

    public void validate()
    {
      if(this.value == null)
        throw new InvalidOperationException(message);

      try{
        this.validateCustom();
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

    private void validateCustom()
    {
      if(!this.validators.ContainsKey(this.type))
        return;

      ObjectValidator validator = this.validators[this.type];
      validator.validate(this.value);
    }
  }
}