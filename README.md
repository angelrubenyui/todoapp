# TODO App

TodoAPP is a application implemented in [Xamarin.Forms], and it has served as a demo for the second [Meetup] of [Barcelona Mobile .NET Developers Group].

![todoapp1](/_screenshots/todoapp1.png?raw=true "Todo list") ![todoapp2](/_screenshots/todoapp2.png?raw=true "Todo list - Pull To Refresh") ![todoapp3](/_screenshots/todoapp3.png?raw=true "Todo list - Context Actions")![todoapp4](/_screenshots/todoapp4.png?raw=true "Todo list - Edit Form")

# Features

The demo implements:

- Windows Azure integration.
- Offline work.
- Item list with Pull to refresh and context actions.
- Dependency inyection.
- Automapping
...
    
# Configuration
Before launching TodoApp, it is necessary to modify the API Keys of the Azure Mobile Services backend. These keys are referenced in the constructor of **BaseAzureService** class, located in the **XForms.Framework** project.

```C#
public BaseAzureService()
{
	ApiClient = new MobileServiceClient(
		"AZURE MOBILE SERVICE URL",
		"AZURE MOBILE SERVICE API ACCESS KEY"
	);
}
```

[Xamarin.Forms]:http://xamarin.com/forms
[Meetup]:http://www.meetup.com/Barcelona-Mobile-NET-Developers-Group/
[Barcelona Mobile .NET Developers Group]:http://bcnmobilegroup.azurewebsites.net/