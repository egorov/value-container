using System;
using Checking;
using Xunit;

namespace Tests
{
  public class SampleObjectValueConstructorTests
  {
    private SampleObjectValidatorConsumer value;

    public SampleObjectValueConstructorTests()
    {
      this.value = new SampleObjectValidatorConsumerImpl();
      
    }

    [Fact]
    public void should_construct()
    {
      Value<SampleObjectValidatorConsumer> container = 
        new ValueConstructor<SampleObjectValidatorConsumer>(this.value);
      container.validate();

      Assert.Equal(this.value, container.get());
    }

    [Fact]
    public void should_set()
    {
      SampleObjectValidatorConsumer another = 
        new SampleObjectValidatorConsumerImpl();

      Value<SampleObjectValidatorConsumer> container = 
        new ValueConstructor<SampleObjectValidatorConsumer>(this.value);

      Assert.Equal(this.value, container.get());

      container.set(another);
      container.validate();

      Assert.Equal(another, container.get());
    }

    [Fact]
    public void should_throw()
    {
      Action construct = 
        () => new ValueConstructor<SampleObjectValidatorConsumer>(null);

      ArgumentNullException error = 
        Assert.Throws<ArgumentNullException>(construct);
      
      Assert.Equal("Value cannot be null.\r\nParameter name: value", error.Message);
    }
  }
}