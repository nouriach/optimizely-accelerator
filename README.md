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

For now, the Block base model holds a field called `ComponentName`. The `ComponentName` field will uses a constant value from the static `ComponentNameConstants` file to set a name for the View Model, which will then be posted along with the other values to the frontend.

There are currently two properties in the Page base model: `Header` and `Footer`, this will allow all Page requests to access the values associated with the `Header` and `Footer` without having to hold them in their own class. 

```
public class BasePageViewModel : ISitePageViewModel
{
    public HeaderViewModel Header { get; set; }
    public FooterViewModel Footer { get; set; }
}
```

## Application Layer
The Application Layer holds all of the Request, Response & Handler logic. All Block and Page requests are managed in relevant folders. 

### Optimizely.Mediator
The Page Requests all inherit from a `BasePageRequestHandler` that manages the values for what will eventually be added to the `BasePageViewModel` described above. The `baseModel` can then be passed into the constructor of Page view model.
```
var baseModel = await base.GetBasePageData(request, cancellationToken);
```

## Framework Layer
The Framework layer hosts all of the Services that are required by the Mediator Handlers to organise the data before it is returned in the response model. The below Services were brought into the project as they represent commont requirements that most projects will have.

### Optimizely.Interfaces & Optimizely.Services
At present, the project has the following Interfaces:

`IConfigService` is used to access the global `ConfigPage` that holds fields that need to be accessible across the website, for instance the `Header` and `Footer`. 

`ILoadContentService` utilises the Optimizely `IContentLoader` repository helper load content from the database. There are a number of methods written out to get content via its `ContentReference`, `ContentArea`, `Content Link` and Generic Type.

`INavigationService` allows the developer to build out navigation components relative to where the current page is in the content tree.

`IProjectLogger` a service to log errors.

`ISiteSettings` a service that allows you to access the Start Page of the project, which in turn helps you access the `ConfigPage`

`IUrlHelper` helps you work and build out URLs

## Domain Layer
### Dept.Core
A layer that holds business rules that need to persist across the project that are unique to Dept. Examples being `Attributes`, site `Constants` & `SelectionFactories`.

### Optimizely.Core
A layer that holds business rules that need to persist across of the Optimizely CMS. Examples being `Attributes`, site `Constants` & `Helpers`.

### Optimizely.Models
The Optimizely components are stored in this layer and help define what is available to a Content Editor in the CMS. Like with View Models, each component inherits from a base class that can be extended upon to include fields that need to persist across all Blocks or Pages where relevant. 

There is also a `ConfigPage` which, like other Page components, can be created in the CMS. However, the `ConfigPage` doesn't get rendered onto the frontend but rather used to establish a set of values that can be accessed by other components and are required to be global. 
