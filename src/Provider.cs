namespace Packaging
{
  public interface Provider<T>
  {
    T Value { get; }
  }
}