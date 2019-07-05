# Value assignment and validation container

Generic container for packing values with built-in value initialization check:

```csharp
  Value<Sample> sampleValue = new ValueContainer<Sample>();

  // Throws ArgumentNullException here
  sampleValue.set(null);

  // Throws InvalidOperationException here
  sampleValue.validate();
  sampleValue.set(new Sample());

  // Will not throws any exceptions now
  sampleValue.validate();

  Sample sample = sampleValue.get();

```

Do not write value initialization check any more. Instead of:

```csharp

  public class Sample
  {
    private Sample value;

    void set(Sample value)
    {
      if(value == null)
        throw new ArgumentNullException(nameof(value));
      this.value = value;
    }
  }
```

Write like this:

```csharp

  public class Sample
  {
    private Value<Sample> value;
    public Sample()
    {
      this.value = new ValueContainer<Sample>();
    }

    void set(Sample value)
    {
      this.value.set(value);
    }
  }
```

Or like this. If you use any dependency injection container:

```csharp

  public class Sample
  {
    private Value<Sample> value;
    public Sample(Value<Sample> value)
    {
      this.value = value;
    }

    void set(Sample value)
    {
      this.value.set(value);
    }
  }
```

