## Get Started
Let's get started with Synethia.

### Requirements
Synethia only works on WPF applications that are targeting .NET 5.

### Installation
Synethia is delivered as a NuGet package.
You can install it using the Visual Studio NuGet Package Manager, or by running the following command:

~~~ c#
dotnet add package Synethia --version 1.0.0.2212
~~~

::: info NOTE
We also recommend you to install the Env module of [PeyrSharp](https://peyrsharp.leocorporation.dev) (PeyrSharp.Env), if you don't want to implement some method yourself.
:::

### Usage
Simply add the following C# using directive to start using the classes and methods of Synethia:

~~~ c#
using Synethia;
~~~

## Your first Synethia configuration
Once everything is installed, you can begin to use Synethia. 
Synethia stores all of the collected data in what we call a `SynethiaConfig`. Inside this class, are stored the information of each page and of specific actions you want to monitor. 
### Step 1: The Global class
We advise you to create a `Global` class that can be accessed anywhere in your app. Inside of this class, will be stored your Synethia config as a static property.
You can use the following implementation:

~~~ c#
using Synethia;

namespace YourApp 
{
    public static class Global
    {
        /*Other properties*/
        public static SynethiaConfig SynethiaConfig { get; set; }
    }
}
~~~

### Step 2: Create your default Synethia configuration
#### 2.1. The default Configuration
Next, you will need to create the default config file that will be used when the user executes the application for the first time.
It must include: 
- A list of all the pages you want to monitor using the `PageInfo` class.
- A list of all the actions you want to monitor using the `ActionInfo` class.

This default configuration must also be stored in the same `Global` class, in the form of a static readonly property.

~~~ c#
using Synethia;

namespace YourApp 
{
    public static class Global
    {
        /*Other properties*/
        public static SynethiaConfig Default => new()
	    {
	    	PagesInfo = new List<PageInfo>()
	    	{
	    		new PageInfo("Page1"), // PageInfo representing the first page
	    		new PageInfo("Page2"),
	    		new PageInfo("Page3")
	    	},
	    	ActionsInfo = new List<ActionInfo>()
	    	{
	    		new ActionInfo(0, "Page1.Button1"), // The Button1 of page 1, the action ID is 0
	    		new ActionInfo(1, "Page2.Button1"),
	    		new ActionInfo(2, "Page3.Button1")
	    	}
	    };
    }
}
~~~

::: info
We advise you to choose for the name the same name you gave to the page or to the control.
For each action ID, we strongly recommend you to put the index of the item in the list.
:::

::: warning
The order of the list cannot be changed, since you will need to specify the index of each `PageInfo` when implementing Synethia in your code base. (Step 4)
:::

#### 2.2. the path where to store the configuration
To remember all the events and interactions that occurred during the user session, Synethia needs to save the collected data somewhere. The data is stored in a JSON file; it contains the score of each page and action. We advise you to also create a readonly static `string` property in the `Global` class that will store the path to your Synethia JSON Configuration file, since you will need to save and load it.

~~~ c#
using Synethia;

namespace YourApp 
{
    public static class Global
    {
        /*Other properties*/

        // Store Synethia config in %APPDATA%\Synethia
        public static string SynethiaPath => $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Synethia\SynethiaConfig.json"
    }
}
~~~

### Step 3: Initialize your Synethia configuration
Now that you everything is set-up, you can initialize the first property you've created, `SynethiaConfig`. To do this, you will need to use the `SynethiaManager` class. This class contains various methods to save and load your Synethia configuration, but is also useful when you will need to record user activity in your app (we will get to that part soon).

You will need to slightly edit your code, by adding at the end of the line `= SynethiaManager.Load(SynethiaPath, Default)`:

~~~ c#
using Synethia;

namespace YourApp 
{
    public static class Global
    {
        /*Other properties*/
        public static SynethiaConfig SynethiaConfig { get; set; } = SynethiaManager.Load(SynethiaPath, Default);
    }
}
~~~

The load method will load the config file located at specified path. If there is no Synethia configuration, or if a problem occurs when loading the Synethia config, it will fallback to the default empty `SynethiaConfig` we made earlier.

### Step 4: Inject Synethia code in your pages
#### 4.1. Monitoring interactions
Next, you need to inject the code that wil monitor each interaction the user is making with the application. For instance, the injected code will check if the user is clicking on buttons, checking checkboxes or if they are writing text in the app.

::: info
The collected data is limited to the app. Synethia is NOT aware of the interactions the user is making OUTSIDE of the app.
:::

In the constructor of each page, add the following lines of code:

~~~ c#{9,13}
using Synethia;
using System.Windows;
using System.Windows.Controls;

namespace YourApp 
{
    public partial class Page1 : Page
    {
    	bool code = false; // checks if the code as already been implemented
    	public Page1()
    	{
    		InitializeComponent();
    		SynethiaManager.InjectSynethiaCode(this, Global.SynethiaConfig.PagesInfo, 0, ref code); // injects the code in the page
    	}
    }
}
~~~
The `InjectSynethiaCode()` methods requires four arguments:
- The `Page` to monitor, in our case, we specify the current page by using the `this` keyword.
- A `List<PageInfo>`; the list where all the `PageInfo` are stored. This why we had to put all of the Synethia configuration information in the `Global` class.
- The index of the `PageInfo` representing the specified `Page`. (see [Step 2](#step-2-create-your-default-synethia-configuration))
- A `bool` passed by reference that can be useful if the method is called multiple times, so the code doesn't get re-injected.

::: warning
Once the code is injected, there is no way of removing it.
:::

Once this is done, Synethia will immediately start to monitor specific events that occur in the page.

#### 4.2. Monitoring the total time spent
To calculate the score of each page, Synethia needs two data:
- The number of interactions made on the page
- The total amount of time spent on the page

Synethia uses UnixTime to calculate the time spent on each page. You will need to specify to Synethia when the user is using the page, and when they stop.
You can use the following implementation:

~~~ c#
// When the user uses Page1:
Global.SynethiaConfig.PagesInfo[0].EnterUnixTime = Sys.UnixTime;

// When the user leaves Page1:
Global.SynethiaConfig.PagesInfo[0].LeaveUnixTime = Sys.UnixTime;
Global.SynethiaConfig.PagesInfo[0].TotalTimeSpent += Global.SynethiaConfig.PagesInfo[0].LeaveUnixTime - Global.SynethiaConfig.PagesInfo[0].EnterUnixTime;
~~~

#### 4.3. Actions
In the event handler of the specific action, add the following code to increment the number of time it has been used:

~~~ c#
/*This is an example*/
private void Btn1_Click(object sender, RoutedEventArgs e)
{
	MessageBox.Show("You clicked Button 1!");
	Global.SynethiaConfig.ActionsInfo[0].UsageCount++; // Increment the usage counter
}
~~~


#### 4.4. Score
You can access the score of each `PageInfo` by reading the `Score` property:

Here's an example

~~~ c#
string info = $"Total time spent: {Global.SynethiaConfig.PagesInfo[0].TotalTimeSpent}\n" +
			$"Number of interaction(s): {Global.SynethiaConfig.PagesInfo[0].InteractionCount}\n" +
			$"Synethia Score: {Global.SynethiaConfig.PagesInfo[0].Score}";
~~~

### Step 5: Saving the configuration
When the user exits the application, you need to save the Synethia config in order to not loose all of the collected data.
You can call the `Save()` method of `SynethiaManager` when the main window is getting closed:


~~~ c#{4}
/*Other Window code*/
private void Window_Closed(object sender, System.EventArgs e)
{
	SynethiaManager.Save(Global.SynethiaConfig, Global.SynethiaPath);
}
~~~