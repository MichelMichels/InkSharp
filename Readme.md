<a href="https://www.nuget.org/packages/MichelMichels.InkSharp"><img src="https://img.shields.io/nuget/v/MichelMichels.InkSharp"/></a>

---

<h1 align="center">
    ✒️ InkSharp
</h1>

<br />

<div align="center">
    Easily convert <code>InkCanvas</code> input to <code>.bmp</code> files.
</div>

<br />
<br />

<details>
<summary>Table of Contents</summary>

- [Summary](#summary)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Building](#building)
- [Installation](#installation)
- [Authors](#authors)
- [License](#license)

</details>

---

## Summary

This class library provides an extended version of [`StrokeCollection`](https://docs.microsoft.com/en-us/dotnet/api/system.windows.ink.strokecollection?view=netframework-4.7.2) with the interface `IDrawing` and the implementation `Drawing`.
The purpose of this project is to provide a oneway conversion of `StrokeCollection`-objects to [`Bitmap`](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=netframework-4.7.2), [`ImageSource`](https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.imagesource?view=netframework-4.7.2) and `byte[]`.


## Prerequisites

- [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

## Getting Started

Clone the repository and start the `MichelMichels.InkSharp.Demo` project.

## Usage

1. Add an `InkCanvas` in your XAML code
2. Create a property of type `MichelMichels.InkSharp.Drawing` and bind to the property `Strokes` of the `InkCanvas`

```xml
<InkCanvas Strokes="{Binding Signature}" />
```

## Building

Use [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) to build the project. 

## Installation

Get the NuGet packages from [nuget.org](https://www.nuget.org/) or search for `MichelMichels.InkSharp` in the GUI package manager in Visual Studio.

You can also use the cli of the package manager with following command:

```cli
Install-Package MichelMichels.InkSharp
```
<br />
<hr>

## Authors

* **Michel Michels** - *Initial work* - [GitHub](https://github.com/MichelMichels)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.