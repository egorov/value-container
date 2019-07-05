using System;
using System.Collections.Generic;

namespace Packaging
{
  public class ObjectValidators : Dictionary<Type, ObjectValidator>, CustomValidators
  {
    public ObjectValidators()
    {
      this.Add(typeof(string), new StringValidator());
    }
  }
}