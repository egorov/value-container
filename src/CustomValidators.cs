using System;
using System.Collections.Generic;

namespace Checking
{
  public interface CustomValidators : IDictionary<Type, ObjectValidator> {}
}