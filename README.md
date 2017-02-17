# FluentGuard
Tiny guard library for fluent precondition assertion. Current it is implemented for use with c#. Maybe a support for TypeScript and Java may be added.

Also in the near future a .net core  / .net standard release will be aviable.

Feel free to fork !

# Description
Offers a fluent way for making preconditions in a guard style.
The idea is to have preconditions always in the same syntax and have less code.  


# Examples

NotNull Check
```
Preconditions
            .For(DomainObjectId, nameof(DomainObjectId))
            .NotNull();
```


Using lambdas instead of hardcoded name
```
Preconditions
            .For(()=> DomainObjectId)
            .NotNull();
```

Multiple checks 
```
Preconditions
            .For(DomainObjectId, nameof(DomainObjectId))
            .NotNull()
            .MinLength(3);
```

Validaten models annotated with [System.ComponentModel.DataAnnotations](https://msdn.microsoft.com/de-de/library/system.componentmodel.dataannotations(v=vs.110).aspx)
```
Preconditions
            .For(()=>Model)
            .NotNull()
            .ValidateModel();
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
