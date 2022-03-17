# Optimizely Accelerator Project
The aim of this solution is to provide a base project layer that all future Optimziely projects can extend on with features and requirements
unique to the client brief.

***
# Approach
The approach centred on reviewing the following projects and identifying pertinent components, base classes, extension methods & general architecture best practices:

1. A template training project created by [Andy Blyth](https://github.com/technicaldogsbody/optimizely-reactjsnet-training) 
2. The [Optimizely Foundation project](https://github.com/episerver/Foundation/tree/master/src/Foundation)

My solution adovcates clean architecture and separates the codebase into individual layers of concern. Moreover, all endpoints adopt the Mediator pattern by isolating all commands and queries into unique slices of work.

***
## Presentation Layer
The Presentation layer is responsible for the rendering of components by holding the Controllers, View Models and Views.

### Optimizely.Web
The Controllers folder divides the components into three separate folders: Base, Blocks & Pages.

The Base folder contains a `BasePageController` which all Controllers will inherit from. The `BasePageController` takes care of instantiating Mediator and the project's logging services. Moreover it holds a method called `JsonDebugCheck()` which can be used by the Frontend Devs to debug:

```
internal void JsonDebugCheck()
{
    if (Request != null && Request.Query["debug"] == "serverjson")
    {
        _logger.LogDebug(nameof(Index), "Enabling JSON");

        ViewBag.DebugJson = "serverjson";
    }
}
```

When it comes to rendering Blocks on a page, the code is set up to return the JSON to the frontend.

Once the `*.cshtml` file for a Page uses the `@Html.PropertyFor()` extension method a `BlockController` is hit, which then returns the following view in a shared `JsonDisplay.cshtml` file:

```
// Block Controller //
{
    //
    return View("~/Views/Shared/JsonDisplay.cshtml", model);
}


// JsonDisplay.cshtml //

@model Optimizely.ViewModels.Blocks.Interfaces.ISiteBlockViewModel;

<h1>@Model?.ComponentName</h1>
@try
{
    string json = JsonConvert.SerializeObject(Model);
    <pre style="display: block;">@Html.Raw(json)</pre>
}
catch (Exception e)
{
    <p>Error rendering Component : @Model?.ComponentName</p>
    <pre>@e.Message</pre>
    <pre>@e.StackTrace</pre>
    <pre>@Html.Raw(JsonConvert.SerializeObject(Model))</pre>
}


```

### Optimizely.ViewModels
All View Models, whether they are Blocks or Pages, inherit from their respective Base View Model. This allows for any properties that persist against all of the respective types can implement the same code without having to duplicate it in every instance. 

For now, the base models hold a field called `ComponentName`. The `ComponentName` field will uses a constant value from the static `ComponentNameConstants` file to set a name for the View Model, which will then be posted along with the other values to the frontend. 

## Application Layer
### Optimizely.Mediator

## Framework Layer
### Optimizely.Interfaces
### Optimizely.Services

## Domain Layer
### Dept.Core
### Optimizely.Core
### Optimizely.Models




