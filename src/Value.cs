namespace Checking
{
  public interface Value<T> : Provider<T>, Consumer<T>, Validator { }  
}