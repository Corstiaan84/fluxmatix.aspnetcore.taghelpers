# Fluxmatix.AspNetCore.Taghelpers 

Fluxmatix.AspNetCore.Taghelpers is a collection of handy ASP.NET Core TagHelpers that I initially created when building [BuiltWithDot.Net](https://builtwithdot.net).



## Table of Contents

- [Background](#background)
  - [Fluxmatix.AspNetCore.TagHelpers.QuillEditor](#MultiMarkdownOverview) 
  - [Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg](#Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg) 
- [Install](#install)
  - Fluxmatix.AspNetCore.TagHelpers.QuillEditor
  - Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg
- [Usage](#usage)
  - Fluxmatix.AspNetCore.TagHelpers.QuillEditor
    - Single editor
    - Multiple editors on the same page
  - Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg
    - Dimensions
    - Masks
- [Contribute](#contribute)
- [License](#license)



## Background

TagHelpers in ASP.NET Core are tiny bundles of joy. They allow developers to create html controls that extend regular html tags or create custom tags that render custom html.



### Fluxmatix.AspNetCore.TagHelpers.QuillEditor

This taghelpers enables developers to easily add the popular [Quill WYSIWYG](https://quilljs.com/) editor to a form, with model binding. It also takes care of all the javascript and css files that the editor requires.

The `Fluxmatix.AspNetCore.TagHelpers.QuillEditor.Sample` web project is included in the source to play around with the options and see the editor in action.

### Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg

This taghelpers enables developers to easily transform any regular `img` tag into a image resizing beast by sending the `src` through the [images.weserv.nl](https://images.weserv.nl/) proxy.

The `Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg.Sample` web project is included in the source to play around with the options and see the image resizing in action.

## Install

### Fluxmatix.AspNetCore.TagHelpers.QuillEditor

In your ASP.NET Core project run:

```bash
Install-Package Fluxmatix.AspNetCore.TagHelpers.QuillEditor	
```

### Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg

In your ASP.NET Core project run:

```bash
Install-Package Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg
```

## Usage

### Fluxmatix.AspNetCore.TagHelpers.QuillEditor

#### Single editor

```

```

#### Multiple editors on the same page

```

```

### Fluxmatix.AspNetCore.TagHelpers.ResizeProxyImg

#### Dimensions

```

```

#### Masks

```

```

## Contribute

See [the contribute file](contribute.md)!

PRs accepted.

Small note: If editing the Readme, please conform to the [standard-readme](https://github.com/RichardLitt/standard-readme) specification.

## License

