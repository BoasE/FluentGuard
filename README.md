# FluentGuard
Tiny guard library for fluent precondition assertion. Current it is implemented for use with .net standard / core. Maybe a support for TypeScript and Java may be added.

You can follow my assumptions on this topic on my [blog post](https://medium.com/@Haggy/preconditions-in-net-softwaredevelopment-e1566b71b344). 

Feel free to fork !

# Description
Offers a fluent way for making preconditions in a guard style.
The idea is to have preconditions always in the same syntax and have less code.  


# Examples

## NotNull Check
```csharp
Preconditions
            .For(DomainObjectId, nameof(DomainObjectId))
            .NotNull();
```


## Using lambdas instead of hardcoded name
```csharp
Preconditions
            .For(()=> DomainObjectId)
            .NotNull();
```

Multiple checks 

```csharp
Preconditions
            .For(DomainObjectId, nameof(DomainObjectId))
            .NotNull()
            .MinLength(3);
```

## Validate annotations 
In .net you can annotate your dtos with attributes from [System.ComponentModel.DataAnnotations](https://msdn.microsoft.com/de-de/library/system.componentmodel.dataannotations(v=vs.110).aspx)

These classes can look like this:
```csharp
public class MyValueObject
{
    [Required]
    [MinLength(2)]
    public string Text { get; set; }

    [Range(1,20)]
    public int Value { get; set; }
}
```

FluentGuard offers the ability to validate that all defined conditions are met
```csharp
Preconditions
            .For(()=>myDto)
            .ValidateModel();
```

## Custom Messages
You can also pass a custom message which will be used for the exceprion message.

```csharp
Preconditions
            .For(DomainObjectId, nameof(DomainObjectId))
            .NotNull(message:"DomainObject has to be not null");
```

# How to extend
When you want to add a new validation rule without extending this repository you can just create ExtensionMethods for the given Validation rule. See for example the [StringValidationExtensions](https://github.com/Gentlehag/FluentGuard/blob/master/src/BE.FluentGuard/StringValidationExtensions.cs)

```csharp
        public static ValidationRule<string> MinLength(this ValidationRule<string> rule, int length)
        {
            if (string.IsNullOrWhiteSpace(rule.Value) || rule.Value.Length < length)
            {
                throw new ArgumentOutOfRangeException(rule.Name, rule.Value.Length, $"The value should be at least {length} characters long!");
            }
            return rule;
        }
```

# Next Steps
- Implement TypeScript


#Nuget Package
https://www.nuget.org/packages/FluentGuard
