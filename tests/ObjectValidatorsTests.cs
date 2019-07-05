using System;
using System.Collections.Generic;
using Checking;
using Xunit;

namespace Tests
{
  public class ObjectValidatorsTests
  {
    private ObjectValidators validators;

    public ObjectValidatorsTests()
    {
      this.validators = new ObjectValidators();
    }

    [Fact]
    public void should_implement()
    {
      Assert.IsAssignableFrom<IDictionary<Type, ObjectValidator>>(this.validators);
    }

    [Fact]
    public void should_supply_StringValidator()
    {
      Assert.IsAssignableFrom<StringValidator>(this.validators[typeof(string)]);
    }
  }
}