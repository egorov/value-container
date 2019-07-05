using System;
using Checking;
using Xunit;

namespace Tests
{
  public class StringValidatorTests
  {
    private StringValidator validator;

    public StringValidatorTests()
    {
      this.validator = new StringValidator();
    }

    [Fact]
    public void validate_should_pass()
    {
      this.validator.validate("Hello Validator!");
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void validate_should_throw_ArgumentNullException(string value)
    {
      Action execute = () => this.validator.validate(value);

      Assert.Throws<ArgumentNullException>(execute);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(false)]
    public void validate_should_throw_ArgumentException(object value)
    {
      Action execute = () => this.validator.validate(value);

      Assert.Throws<ArgumentException>(execute);
    }
  }
}