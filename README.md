# Revalonia - _Implementing Avalonia UI Framework for Revit_
# [DEPRECATED]

## Motivation

Revalonia was an experimental project to implement a multi-platform MVVM UI
Framework Avalonia to create an easy-to-use add-ins (plugin) template that looks
good out of the box. The project was inspired by Speckle2 UI, which uses
Avalonia to enable the same Speckle UI to be deployed for multiple hosting apps
in multi-platforms - to both Windows & Mac.

The advantage seemed twofold; the MVVM stack just seems like the right way to
develop complex add-ins that are maintainable. And on other hand, by being able
to apply a different UI theme; Avalonia UI simply seems to look a lot better
without much styling compared to WPF, which just tends to look very dull and
dated. If you look at many of those deployed add-ins for Revit every today,
quite frankly, they look like from the 90s…

## PoC that failed

In short, the proof of concept for this project failed. Therefore, the code in
this repository should only be used for experiments and is by no means
production-ready. In other words, this repository serves as a cautionary example
against using Avalonia UI to develop an add-in for Revit.

Unlike WPF, Avalonia requires AvaloniaApp to be built before any windows can be
rendered. During the build process, it sets up the general behaviors of the app
like lifecycle, UI themes, targeted platforms, etc… Also, by design, one hosting
platform can build only one Avalonia App. Such behavior makes sense for a mobile
app or a UI for any sort of IoT device, say running on Raspberry Pi.

But, if you are building an Avalonia App from the hosting app, in this case,
Revit; you’ll quickly run into an issue. Let’s look at Speckle as an example. If
you’ve used it before, you probably noticed you have Speckle main window is
already ready to be used when you open a project on Revit. How is this done?

- When Revit starts (before you open a project or family) ⇒ An Avalonia App for
  Speckle is built. (you can even render a window at this time, but this would
  just block the rest of the process…)
- When the project opens ⇒ Speckle creates a dockable window
- By design, you can not only terminate the Avalonia App. Currently, the only
  way to terminate the Avalonia App hosted on Revit is to terminate Revit
  itself.

At first glance, there may not seem to be any major issues with this behavior.
However, what if there is both Speckle and another add-in that uses Avalonia?
One app will either take over the behavior, such as the UI theme, of the other
app or simply return an error because Avalonia can only build one Avalonia app
from the same hosting app. Again, this limitation is by design in Avalonia. And
this is the very reason why Avalonia UI framework is probably not an appropriate
solution for building an add-in for Revit unless the current design limitation
changes in the future. Why would you risk building something that could be taken
over or interfere with other add-ins by design?

## What’s Next….?

I started this project with a simple vision to create a user-friendly, visually
appealing template for developing Revit add-ins. However, my initial approach
just proved to be wrong or not efficient (at least for now).

I’ve considered raising an issue on Avalonia to solve this issue on the
framework level, but given the most use case scenarios of the framework, I
figured that wasn’t necessary unless I get some community supports for changing
the fundamental behavior of the app.

Anyway, who knows what it might open up? So, this repository contains simple
sample code for implementing Avalonia on Revit for experimental purposes. See
the "Get Started" section below for reference.

Anyway, I’ll still continue to find and try to implement a modern UI framework
to develop a Revit add-in as opposed to simply following the conventional/
recommended dev. with WPF. I just see lots of advantages in developing with such
a modern framework for various reasons, which just go beyond simply developing a
mandate Revit add-in…

Look out for this repository etc for the upcoming release of an awesome template
for developing a Revit add-in.

## Get Started (Experimental)

1. Clone this repository `git clone https://github.com/dla-hubs/revalonia`
2. Move the manifesto file (__Revalonia.Addin__) saved under `/Assets` to your
   Revit plugin folder. The path should look like something like
   `C:\ProgramData\Autodesk\Revit\Addins\2023 <depenging on a version of your revit>`
3. Open Revalonia.csproj with Visual Studio
4. Relink the missing links to Revit.dll & RevitUi.dll to a version of Revit you
   have installed (only tested with 2023 but should work with the older versions
   too)
5. Run Build to make sure it can build successful
6. Run Debug and terminate immediately after it finished building
7. Open the Revalonia.addin with a text editor of your choice
8. Change the link to the .dll file to the Revalonia.dll file at the folder
   created during the debug process in step 6.
9. Now, you run Debug again and it should start Revit (you need a valid license
   of Revit to be able to test this…)
10. After, it opens create an empty project.
11. The add-in should have created a toolbar called Revalonia at the toolbar
    ribbon.
12. Click on and click on the icon to activate the add-in.
13. Now it should open a window with the text in the middle “Welcome to
    Revalonia!”
