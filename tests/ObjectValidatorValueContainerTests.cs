using System;
using Packaging;
using Xunit;

namespace Tests
{
  public class ObjectValidatorValueContainerTests
  {
    private ValueContainer<ObjectValidator> container;

    public ObjectValidatorValueContainerTests()
    {
      this.container = new ValueContainer<ObjectValidator>();
    }

    [Fact]
    public void should_implement()
    {
      Assert.IsAssignableFrom<Provider<ObjectValidator>>(this.container);
      Assert.IsAssignableFrom<Consumer<ObjectValidator>>(this.container);
      Assert.IsAssignableFrom<Validator>(this.container);
    }

    [Fact]
    public void should_set_Value()
    {
      ObjectValidator expected = new StringValidator();
      this.container.set(expected);
      this.container.validate();

      Assert.Equal(expected, this.container.get());
    }

    [Fact]
    public void set_should_throw_standard_message()
    {
      Action set = () => this.container.set(null);
      
      ArgumentNullException error = Assert.Throws<ArgumentNullException>(set);

      Assert.Equal("Value cannot be null.\r\nParameter name: value", error.Message);
    }

    [Fact]
    public void validate_should_throw()
    {
      Action validate = () => this.container.validate();

      InvalidOperationException error = 
        Assert.Throws<InvalidOperationException>(validate);

      string expected = 
        "Set the container Value with valid Packaging.ObjectValidator first!";
      Assert.Equal(expected, error.Message);
      Assert.Null(this.container.get());
    }
  }
}
