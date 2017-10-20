# dotNetExt - .NET Extension Method Library

dotNetExt is a Extension Method Library for the .NET Framework that extends the BCL Types with helper methods that make simple tasks simpler. So far there are extensions for the Object, IEnumerable<> and String BCL Types. The library is flexible so you can Import All Extension Methods or just the Extension Methods for the BCL Type(s) you want.

**FYI, this project was migrated here from Codeplex before it shutdown.**


## Nuget Package

[http://nuget.org/packages/dotnetext](http://nuget.org/packages/dotnetext)

![](images/dotNetExt-Nuget-Install-Package.png)

## Library Usage

You can include the entire library of Extension Methods by Importing the dotNetExt namespace. Alternatively you can Import just the Extension Methods you want (grouped by Base Class Library Type) by including that specific extension collections namespace.

C#:

    // Include All Extension Methods
    using dotNetExt;

VB.NET

    '' Include All Extension Methods
    imports dotNetExt

## dotNetExt Extension Methods

Importing this namespace you will import Extension Methods for the following base types:

* System.Boolean
* System.Byte
* System.Char
* System.DateTime
* System.EventHandler
* System.IComparable
* System.Int32
* System.Object
* System.String
* System.TimeSpan
* System.Collections.IEnumerable
* System.Collections.Generic.Dictionary
* System.Collections.Generic.IDictionary
* System.Collections.Generic.IEnumerable
* System.Collections.Specialized.NameValueCollection
* System.IO.Stream
* System.Linq.IQueryable
* System.Text.StringBuilder

dotNetExt also includes the following objects and their own related extension methods:

* **dotNetExt.Validation.ValidationArgument<>** - This is for validating method parameters more easily in a DRY fashion.
* **dotNetExt.PaginatedList**
* **dotNetExt.Transient** - Retry and SqlRetry methods - This is for easily implementing "retry logic" on web service or database calls when transient errors occur.