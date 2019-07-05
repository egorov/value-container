using System;
using System.Collections.Generic;

namespace Checking
{
  public class ObjectValidators : Dictionary<Type, ObjectValidator>, CustomValidators
  {
    public ObjectValidators()
    {
      this.Add(typeof(string), new StringValidator());
    }
  }
}