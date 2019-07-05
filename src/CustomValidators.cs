using System;
using System.Collections.Generic;

namespace Packaging
{
  public interface CustomValidators : IDictionary<Type, ObjectValidator> {}
}