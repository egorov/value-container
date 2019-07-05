using System;
using Packaging;
using Xunit;

namespace Tests
{
  public class StringValueContainerTests
  {
    private ValueContainer<string> container;

    public StringValueContainerTests()
    {
      this.container = new ValueContainer<string>();
    }

    [Fact]
    public void should_implement()
    {
      Assert.IsAssignableFrom<Provider<string>>(this.container);
      Assert.IsAssignableFrom<Consumer<string>>(this.container);
      Assert.IsAssignableFrom<Validator>(this.container);
    }

    [Fact]
    public void should_set_Value()
    {
      string expected = "Hello Container!";
      this.container.Value = expected;
      this.container.validate();

      Assert.Equal(expected, this.container.Value);
    }

    [Fact]
    public void set_should_throw_standard_message()
    {
      Action set = () => this.container.Value = null;
      
      ArgumentNullException error = Assert.Throws<ArgumentNullException>(set);

      Assert.Equal("Value cannot be null.\r\nParameter name: value", error.Message);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void set_should_throw(string value)
    {
      Action set = () => this.container.Value = value;
      
      ArgumentNullException error = Assert.Throws<ArgumentNullException>(set);
      string expected = 
        "Value cannot be null.\r\nParameter name: value can\'t be null, empty or whitespace string!";

      Assert.Equal(expected, error.Message);
    }

    [Fact]
    public void validate_should_throw()
    {
      Action validate = () => this.container.validate();

      InvalidOperationException error = 
        Assert.Throws<InvalidOperationException>(validate);

      string expected = 
        "Set the container Value with valid System.String first!";
      Assert.Equal(expected, error.Message);
      Assert.Null(this.container.Value);
    }

    [Fact]
    public void constructor_should_throw()
    {
      Action construct = () => new ValueContainer<string>(null);

      ArgumentNullException error = Assert.Throws<ArgumentNullException>(construct);
      string expected = "Value cannot be null.\r\nParameter name: validators";

      Assert.Equal(expected, error.Message);
    }
  }
}
