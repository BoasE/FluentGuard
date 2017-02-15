# FlowGuard
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

# Next Steps
- Add api-documentation
- Make better names
- Support .net standard
- Implement TypeScript


#Nuget Package
https://www.nuget.org/packages/FlowGuard/
