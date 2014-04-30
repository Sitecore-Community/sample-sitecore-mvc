# Sample Sitecore MVC
This project contains all the examples (and more) covered in the series of videos on Sitecore MVC.

* **Part 1**: https://www.youtube.com/watch?v=i3Mwcphtz4w
* **Part 2**: https://www.youtube.com/watch?v=dW_rQp9bMmE

NOTE: This project shows a variety of examples (see 'What is included?') and provides comments explaining why a particular pattern might be used. You should not use it as a de facto reference for enterprise level solutions.

## Installation
1. Install a blank instance of Sitecore (this project has been tested with Sitecore 7.1 rev. 140130, but you should be able to use later verisons)
2. Download the Sample Sitecore MVC project and put it in a location outside the site web root (e.g. C:\Projects)
3. On the same level as the project folders (MVC, MVC.Data, etc), create a **Libraries** folder and copy the Sitecore.Kernel.dll and Sitecore.MVC.dll from your fresh instance of Sitecore
4. Open MVC.sln and check that it builds
5. Set up a **Publish Profile** to do a File Deploy to your Sitecore web root (or write a post-build script). To create a Publish Profile:
  1. Right-click on the MVC.Tutorial project and choose **Publish...*
  2. Create a new profile and click 'Next'
  3. Choose 'File System' in the 'Publish Method' dropdown
  4. Type the name of your Website root folder OR your site's URL (e.g. http://mvc/)
  5. Click 'Next' - if you wish to debug the solution, make sure the dropdown is set to 'Debug'
  6. Click 'Publish'
6. The solution contains a **serialization** folder under App_Data - you can either move the serialization folder into the location pointed to by the SerializationFolder setting OR change the SerializationFolder setting to the App_Data/serialization location:

```xml
<setting name="SerializationFolder" value="$(dataFolder)/serialization" />
```
7. Browse to http://{yoursite}/Unicorn.aspx (for more information about Unicorn, visit https://github.com/kamsar/Unicorn)
8. Hit the **Perform Initial Serialization of Default Configuration** button - this will turn the serialized .item files into items in the Sitecore tree
9. Log into Sitecore - you should see items beneath /sitecore/content/Home - e.g. 'silverstone'
10. Perform a smart publish, and browse to http://{yoursite}

## What is included?

### Renderings

All listed renderings are Page Editor and DMS friendly (each reads from a datasource).

#### Spotlight
* View rendering, utilises the @Html.Sitecore() helper
* Uses Sitecore's standard RenderingModel

#### Featured Car
* View rendering, utilises a custom Car model
* The Car model is represented by an item in Sitecore (/sitecore/Layout/Models) and set as the custom model on the Featured Car rendering definition item under /Sitecore/Layout/Renderings/MVC Tutorial
* Car model implements IRenderingModel, and thereby the ```Initialize()``` method that Sitecore's MVC pipelines call

#### Featured Driver
* Controller rendering, utilises a custom DriverViewModel
* Corresponding DriverController
* DriverViewModel and Driver objects populatd by a repository - DriverRepository (implements IDriverRepository)
* Scope to inject IDriverRepository if you are using an IoC container, such as Castle Windsor

#### Featured Circuit
* Controller rendering, utilises a custom Circuit model
* Corresponding CircuitController
* The Circuit model inherits from Sitecore's default RenderingModel, and the controller demonstrates how to pass the context rendering into the ```Initialize()``` method to populate it

#### Featured Location
* Unit-testable controller rendering
* Wraps and isolates the Sitecore API
* Uses dependency injection, a business logic layer, and the repository pattern
* See this blog post for in-depth information: http://mhwelander.net/2014/04/30/unit-testing-sitecore-mvc/

## Interesting points
### Using /Shared/_Layout.cshtml
In standard MVC, views can be set up to use a shared *MVC layout* (not to be confused with a Sitecore layout) to reduce duplication. In your view, you set the 'Layout' property to your MVC layout's path. That view will then be inserted into the ```@RenderBody()``` of the shared layout. However, Sitecore also has the concept of a layout, which is essentially the 'base view' into which you insert smaller view or controller renderings by assignign them to placeholders. All your page scaffolding (like the ```<head>``` of the page) can go into the Sitecore layout, and you do not need a shared MVC 'layout' at all. However, if you *did* want to set the 'Layout' property inside your view, Sitecore will not stop you - ```@RenderBody()``` will still work **when used inside the layout view, not inside renderings***.

## Image credits
* Mitsubishi Lancer Evolution VI: http://www.motorsbros.com/opt-speed-Mitsubishi-Lancer-Evolution-VI.html
* Lancia Delta Integrale: http://maydaygarage.com/2011/06/01/nostalgic-wednesdays1987-lancia-delta-integrale/
* Mazda MX5 MK3: http://www.whatcar.com/car-news/mazda-mx-5-rust-problem/1214652