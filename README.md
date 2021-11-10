# AdvancedConsole
This repository contains a basic console application that illustrates the implementation concepts necessary to create an
advanced console application. Some of the features of the demo include
- Service Library
- Dependency Injection
- Options Pattern Configuration
- Extension Methods
- Logging
- IDisposable Services

The idea behind the demo is to demonstrate the concepts above as well as provide a better starting point for console applications
developed in the real world. Rather than spending time creating the foundation for a well-structured application, this
repository has a complete working example to get people off to a better start.

## Service Library
This demo includes a class library containing services the console application consumes. A real-world application may consume
a class library that handles database I/O operations or a wrapper around a REST API an application needs to interact with.

## Dependency Injection
.NET Core introduced dependency injection (DI) as a core service. The two main reasons to use DI is to improve testability
and simplify resolving object dependency. There's little reason not to do it. Unfortunately, the standard console application
template does not include DI by default. The .NET framework easily allows developers to add DI into their project as this
demo shows. There's a great [video on youtube](https://www.youtube.com/watch?v=QtDTfn8YxXg&t=49s) on dependency injection.

## Options Pattern Configuration
The recommended method of handling application configuration is using
[options pattern] (https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0)
configuration. There are several benefits identified in the linked article. This demo shows how to implement the options
pattern configuration for both the main application and for a class library.

## Extension Methods
There's a little work required to get configuration settings and the DI container setup properly. This demo shows how to
use extension methods to isolate that setup into a class. The class library has it's own extension method for setting up
the options and DI container so consumers of the class library do not need to know the details of configuration.

## Logging
This demo also uses the logging framework built into .NET Core. Logging can be an important tool for debugging and/or
monitoring the health of an application. Using a third-party logging library such as [Serilog](https://serilog.net/)
is trivial to do once the logging foundation is in place.

## IDisposable Services
Finally, the demo includes a service the console application consumes that implements IDisposable to demonstrate the
DI container calls Dispose() on objects that implement IDisposable.
