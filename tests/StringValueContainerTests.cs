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

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void set_should_throw(string value)
    {
      Action set = () => this.container.Value = value;
      Assert.Throws<ArgumentNullException>(set);
    }

    [Fact]
    public void validate_should_throw()
    {
      Action validate = () => this.container.validate();

      Assert.Throws<InvalidOperationException>(validate);
    }
  }
}
