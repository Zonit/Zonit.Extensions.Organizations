## Zonit.Extensions.Organizations

An abstraction for organizational management for Blazor.

**Nuget Package Abstraction**
```
Install-Package Zonit.Extensions.Organizations.Abstractions 
```
![NuGet Version](https://img.shields.io/nuget/v/Zonit.Extensions.Organizations.Abstractions.svg)
![NuGet](https://img.shields.io/nuget/dt/Zonit.Extensions.Organizations.Abstractions.svg)


**Nuget Package Extensions**
```
Install-Package Zonit.Extensions.Organizations
```
![NuGet Version](https://img.shields.io/nuget/v/Zonit.Extensions.Organizations.svg)
![NuGet](https://img.shields.io/nuget/dt/Zonit.Extensions.Organizations.svg)

**Install**
Add this in ``Routes.razor``
```razor
@using Zonit.Extensions

<ZonitOrganizationsExtension />
```

Services in ``Program.cs``
```cs
builder.Services.AddOrganizationsExtension();
```