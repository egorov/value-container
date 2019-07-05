using System;
using Packaging;
using Xunit;

namespace Tests
{
  public class SampleObjectValidatorConsumerImplTests
  {
    private SampleObjectValidatorConsumer consumer;
    public SampleObjectValidatorConsumerImplTests()
    {
      this.consumer = new SampleObjectValidatorConsumerImpl();
    }

    [Fact]
    public void should_set_and_consume()
    {     
      CallCounterValidator validator = new CallCounterValidator();
      Assert.Equal(0, validator.get());

      this.consumer.set(validator);
      this.consumer.consume();

      Assert.Equal(1, validator.get());
    }

    [Fact]
    public void set_should_throw()
    {
      Action set = () => this.consumer.set(null);

      ArgumentNullException error = Assert.Throws<ArgumentNullException>(set);
      Assert.Equal("Value cannot be null.\r\nParameter name: value", error.Message);
    }
  }

  public class CallCounterValidator : ObjectValidator, Provider<int>
  {
    public void validate(object value)
    {
      this.value += 1;
    }

    private int value;
    public int get() 
    {
      return this.value;
    }
  }

  public interface SampleObjectValidatorConsumer : Consumer<ObjectValidator>
  {
    void consume();
  }

  public class SampleObjectValidatorConsumerImpl : SampleObjectValidatorConsumer
  {
    private Value<ObjectValidator> objectValidator;

    public SampleObjectValidatorConsumerImpl()
    {
      this.objectValidator = new ValueContainer<ObjectValidator>();
    }

    public void set(ObjectValidator value)
    {
      this.objectValidator.set(value);
    }

    public void consume()
    {
      this.objectValidator.validate();

      ObjectValidator validator = this.objectValidator.get();

      validator.validate(validator);
    }
  }
}