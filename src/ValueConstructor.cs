namespace Checking
{
  public class ValueConstructor<T> : ValueContainer<T>
  {
    public ValueConstructor(T value) : base() 
    {
      this.set(value);
    }
  }
}