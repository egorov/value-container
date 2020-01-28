using System;
using Checking;
using Xunit;

namespace Tests
{
  public class SampleObjectValueAdapterTests
  {
    private SampleObjectValidatorConsumer value;

    public SampleObjectValueAdapterTests()
    {
      this.value = new SampleObjectValidatorConsumerImpl();
      
    }

    [Fact]
    public void should_construct_with_value()
    {
      Value<SampleObjectValidatorConsumer> container = 
        new ValueAdapter<SampleObjectValidatorConsumer>(this.value);
      container.validate();

      Assert.Equal(this.value, container.get());
    }

    [Fact]
    public void should_construct_with_value_and_validators()
    {
      Value<SampleObjectValidatorConsumer> container = 
        new ValueAdapter<SampleObjectValidatorConsumer>(this.value, new ObjectValidators());
      container.validate();

      Assert.Equal(this.value, container.get());
    }

    [Fact]
    public void should_set()
    {
      SampleObjectValidatorConsumer another = 
        new SampleObjectValidatorConsumerImpl();

      Value<SampleObjectValidatorConsumer> container = 
        new ValueAdapter<SampleObjectValidatorConsumer>(this.value);

      Assert.Equal(this.value, container.get());

      container.set(another);
      container.validate();

      Assert.Equal(another, container.get());
    }

    [Fact]
    public void should_throw_value_is_null()
    {
      Action construct = 
        () => new ValueAdapter<SampleObjectValidatorConsumer>(null);

      ArgumentNullException error = 
        Assert.Throws<ArgumentNullException>(construct);
      
      Assert.StartsWith("Value cannot be null", error.Message);
    }

    [Fact]
    public void should_throw_validators_is_null()
    {
      Action construct = 
        () => new ValueAdapter<SampleObjectValidatorConsumer>(new SampleObjectValidatorConsumerImpl(), null);

      ArgumentNullException error = 
        Assert.Throws<ArgumentNullException>(construct);
      
      Assert.StartsWith("Value cannot be null", error.Message);
    }
  }
}