# Value assignment and validation container

Обобщенный контейнер для упаковки значений со встроенной проверкой инициализации значений:

```csharp
  Value<Sample> sampleValue = new ValueContainer<Sample>();

  // Если вызывать validate до вызова set,
  // то будет выброшено исключение
  // InvalidOperationException
  sampleValue.validate();
  sampleValue.set(new Sample());

  // Теперь вызов validate не выбросит исключений
  sampleValue.validate();

  Sample sample = sampleValue.get();

```

Предназначен в качестве средства избавления от необходимости писать всякий раз в методах код проверки инициализационного значения? Вместо:

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

Можно писать так:

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

Или если используется контейнер внедрения зависимостей, то так:

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

