using System;
using Packaging;
using Xunit;

namespace Tests
{
  public class EmptyValidator : ObjectValidator
  {
    public void validate(object value)
    {
    }
  }
  public interface SampleConsumer : Consumer<ObjectValidator>
  {
    void consume();
  }

  public class SampleConsumerImpl : SampleConsumer
  {
    private Value<ObjectValidator> objectValidator;

    public SampleConsumerImpl()
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

  public class ObjectValidatorConsumerTests
  {
    private SampleConsumer consumer;
    public ObjectValidatorConsumerTests()
    {
      this.consumer = new SampleConsumerImpl();
    }

    [Fact]
    public void should_set_and_consume()
    {
      this.consumer.set(new EmptyValidator());
      this.consumer.consume();
    }

    [Fact]
    public void set_should_throw()
    {
      Action set = () => this.consumer.set(null);

      ArgumentNullException error = Assert.Throws<ArgumentNullException>(set);
      Assert.Equal("Value cannot be null.\r\nParameter name: value", error.Message);
    }
  }
}