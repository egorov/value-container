namespace Checking
{
  public class ValueAdapter<T> : ValueContainer<T>
  {
    public ValueAdapter(T value) 
      : this(value, new ObjectValidators())
    {
      this.set(value);
    }

    public ValueAdapter(T value, CustomValidators validators)
      : base(validators)
    {
      this.set(value);
    }
  }
}