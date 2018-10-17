# Fluxmatix.AspNetCore.Taghelpers 

Fluxmatix.AspNetCore.Taghelpers is a collection of handy ASP.NET Core TagHelpers that I initially created when building [BuiltWithDot.Net](https://builtwithdot.net).



## Table of Contents

- [Background](#background)
  - [Background Fluxmatix.AspNetCore.TagHelpers.QuillEditor](#Background Fluxmatix.AspNetCore.TagHelpers.QuillEditor) 
  - [Background Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg](#Background Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg) 
- [Install](#install)
  - [Install Fluxmatix.AspNetCore.TagHelpers.QuillEditor](#Install Fluxmatix.AspNetCore.TagHelpers.QuillEditor)
  - [Install Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg](#Install Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg)
- [Usage](#usage)
  - [Usage Fluxmatix.AspNetCore.TagHelpers.QuillEditor](#Usage Fluxmatix.AspNetCore.TagHelpers.QuillEditor)
    - [Single editor](#Single editor)
    - [Multiple editors on the same page](#Multiple editors on the same page)
    - [Using Razor view sections](#Using Razor view sections)
  - [Usage Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg](#Usage Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg)
    - [Dimensions](#Dimensions)
    - [Masks](#Masks)
- [Contribute](#contribute)
- [License](#license)



## Background

TagHelpers in ASP.NET Core are tiny bundles of joy. They allow developers to create html controls that extend regular html tags or create custom tags that render custom html.

### Background Fluxmatix.AspNetCore.TagHelpers.QuillEditor

This taghelpers enables developers to easily add the popular [Quill WYSIWYG](https://quilljs.com/) editor to a form, with model binding. It also takes care of all the javascript and css files that the editor requires.

The `Fluxmatix.AspNetCore.TagHelpers.QuillEditor.Sample` web project is included in the source to play around with the options and see the editor in action.

### Background Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg

This taghelpers enables developers to easily transform any regular `img` tag into an image resizing beast by sending the `src` through the [images.weserv.nl](https://images.weserv.nl/) proxy.

The `Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg.Sample` web project is included in the source to play around with the options and see the image resizing in action.

## Install

### Install Fluxmatix.AspNetCore.TagHelpers.QuillEditor

In your ASP.NET Core project run:

```bash
Install-Package Fluxmatix.AspNetCore.TagHelpers.QuillEditor	
```

### Install Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg

In your ASP.NET Core project run:

```bash
Install-Package Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg
```

## Usage

### Usage Fluxmatix.AspNetCore.TagHelpers.QuillEditor

Register the Quill editor taghelper in `Startup.cs`:

```
using Fluxmatix.AspNetCore.TagHelpers.QuillEditor;

...

public void ConfigureServices(IServiceCollection services)
{
	// your code...

    services.AddQuillEditor();

    // or set some options like so:

    //services.AddQuillEditor(obj =>
    //{
    //    obj.Theme = "bubble";
    //});
    
    // rest of your code...
}

public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    // your code...

    app.UseQuillEditor();
    
    // rest of your code...
}
```

Inside `_ViewImports.cshtml` add the following line:

```
@addTagHelper *, Fluxmatix.AspNetCore.TagHelpers.QuillEditor
```

Register the Quill stylesheets in the head of your page/view

```
<head>
	...
	<quill-editor-style-sheets></quill-editor-style-sheets>
	...
</head>
```

#### Single editor

Add the Quill editor to a `form` and add the Quill javascripts at the end of your `body` tag:

```
@model Fluxmatix.AspNetCore.TagHelpers.QuillEditor.Sample.Models.SampleModel
...
<body>
	<form asp-action="ShowContent" asp-controller="Home">
        <quill-editor asp-for="Content1" style="height: 400px;"></quill-editor>
        <button type="submit">Show content</button>
	</form>
	...
	<quill-editor-script></quill-editor-script>
</body>
```

#### Multiple editors on the same page

To add multiple Quill editor to the same page, make sure to set element ids on both the Quill javascripts tag and the individual Quill editor tags. Notice the corresponding ids on both the javascript tag and the editor tags.

Javascript:

```
<quill-editor-script for-editors="editor1,editor2,editor3"></quill-editor-script>
```

Editors:

```
@model Fluxmatix.AspNetCore.TagHelpers.QuillEditor.Sample.Models.SampleModel
...
<form asp-action="ShowContentMultiple" asp-controller="Home">
    <quill-editor asp-for="Content1" id="editor1" style="height: 200px;"></quill-editor>
    <quill-editor asp-for="Content2" id="editor2" style="height: 200px;"></quill-editor>
    <quill-editor asp-for="Content3" id="editor3" style="height: 200px;"></quill-editor>
    <button type="submit">Show content</button>
</form>
```

#### Using Razor view sections

For non-trivial apps you'll probably want to use Razor view sections to organise your views more cleanly. This is an example of using the Quill editor with Razor view sections.

```
@model Fluxmatix.AspNetCore.TagHelpers.QuillEditor.Sample.Models.SampleModel
...
@section Stylesheets {
    <quill-editor-style-sheets></quill-editor-style-sheets>
}

@section Scripts {
    <quill-editor-script></quill-editor-script>
}

<form asp-action="ShowContent" asp-controller="Home">
    <quill-editor asp-for="Content1" style="height: 400px;"></quill-editor>
    <button type="submit">Show content</button>
</form>
```

### Usage Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg

Inside `_ViewImports.cshtml` add the following line:

```
@addTagHelper *, Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg
```

#### Dimensions

Add the `resize-height` and/or the `resize-width` attributes on any `img` tag:

```
<img src="https://www.what-dog.net/Images/faces2/scroll001.jpg" resize-width="400" resize-height="400" />
```

#### Masks

Set any of the available [masks](https://images.weserv.nl/#mask) using the `mask` attribute:

```
<img src="https://www.what-dog.net/Images/faces2/scroll001.jpg" mask="circle" />
```

Or combine size and mask:

```
<img src="https://www.what-dog.net/Images/faces2/scroll001.jpg" mask="triangle" resize-width="200" />
```

## Contribute

PRs accepted.

## License

GNU GPLv3