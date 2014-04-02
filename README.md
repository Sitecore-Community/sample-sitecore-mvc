# Sample Sitecore MVC
This project contains all the examples (and more) covered in the series of videos on Sitecore MVC.

* **Part 1**: https://www.youtube.com/watch?v=i3Mwcphtz4w
* **Part 2**: https://www.youtube.com/watch?v=dW_rQp9bMmE

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