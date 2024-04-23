# Bomb Rush Cyberfunk Mod/Plugin Template

I took YuriLewd's Bomb Rush Cyberfunk plugin template, configured it for VSCode, added scripts to automate annoying tasks, wrote this README, hosted as a Github Template repo.

## Assumptions

This guide assumes you can use git w/github.

This guide should work in Visual Studio 2022, JetBrains Rider, and VSCode.

*I no longer recommend VSCode for beginners.  Use Visual Studio 2022 instead.  I still personally use VSCode a ton, because I have years of built-up muscle memory, and I have the technical skill to work through any jank.*

## Setup

Install dotnet: https://dotnet.microsoft.com/en-us/download

Install an IDE: Visual Studio 2022 (recommended), JetBrains Rider (also great), or VSCode (I love it, but prepare for some jank)
<!--https://code.visualstudio.com/-->

Install Unity Editor 2021.3.20f1: https://unity.com/releases/editor/whats-new/2021.3.20

On Github, click "Use this template" to clone this code into your own repository in your own github account. *you must be logged in to github to see this button*

Use Git, Github Desktop, or your chosen IDE to clone your newly-created GitHub repository.  Open it in your chosen IDE.

_**VSCode only:**_ Install recommended extensions for this project.  VSCode should auto-prompt for this(?) `.vscode/extensions.json`

Use your IDE's "Replace in Files" feature to find-and-replace `SafeProjectName` in every file in the project. Replace it with a C# namespace for your plugin, something like `DDRCypherMinigame` or whatever. No funky punctuation or spaces, can't start with a number.

*See also: [C#'s naming rules](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/identifier-names#naming-rules)*

Open `Plugin.cs` and customize strings.  Where it says `Username` replace with your username or similar, no funky punctuation or spaces, can't start with a number.

Download pdb2mdb, put it at `./scripts/pdb2mdb.exe`: https://docs.bepinex.dev/articles/advanced/debug/plugins_vs.html

<!-- Generate publicized game dll.  PowerShell script `./scripts/generate-publicized-assemblies.ps1` may do the trick. If it's confused about install location of BRC,
pass as `./scripts/generate-publicized-assemblies.ps1 -brcInstallDirectory PATH_HERE` or jump to next step to fix `.csproj` variables and then come back. -->

Create two environment variables:

- In Start menu, go to "Edit Environment Variables for your account"
- Add `BRCPath` environment variable with path where Bomb Rush Cyberfunk is installed. It might look something like this: `E:\Games\SteamLibrary\steamapps\common\BombRushCyberfunk`
- Add `BepInExDirectory` environment variable with path to your BepInEx directory. It might look something like this: `C:\Users\myusername\AppData\Roaming\Thunderstore Mod Manager\DataFolder\BombRushCyberfunk\profiles\Default\BepInEx`
- Restart your IDE to be sure it sees the latest values.

"Build" the code: "Build->Build Solution" in Visual Studio 2022, Ctrl+Shift+B in VSCode.  If there are errors about missing assemblies or classes,
your environment variables are probably wrong.

*If Visual Studio does not show "Build Solution," you probably need to open the solution / `.sln` file. This might require some clicking around.*

## Debugging

You can _optionally_ attach a debugger to the game while it's running your mods, allowing you to set breakpoints, inspect objects, etc.

This requires additional setup, but I wrote a script to do it for you.

The script `./scripts/convert-to-debug-build.ps1` will convert your game to a debug build.

_**BE CAREFUL**, back up your stuff, the script might break everything!_

See also: I followed this guide: https://github.com/dnSpy/dnSpy/wiki/Debugging-Unity-Games#turning-a-release-build-into-a-debug-build  

With the game running, in VSCode run command "Attach Unity Debugger."  In Rider use "Run"->"Attach to Unity Process"

VSCode's debugger appears to have a bug where breakpoints can get stuck enabled. That is, I hit a breakpoint, try to remove it and resume, but the game keeps hitting the breakpoint every frame.  Restarting the debugger might fix it. (Ctrl+Shift+F5)

See also: https://code.visualstudio.com/docs/csharp/debugging

## See also

*Note: these links are informational, but if they describe other templates or starter projects, those may be different than this one! So use them with caution. They're for learning.*

Youtube guide: https://www.youtube.com/watch?v=KopYonyplXs  
Links to project template: https://github.com/mroshaw/UnityModVSTemplate/tree/main/Templates/ProjectTemplates/C%23/Unity%20Mod%20(BepInEx)

BepInEx guide: https://docs.bepinex.dev/articles/dev_guide/plugin_tutorial/index.html
*Note: you don't need to use their template if you are using this template!  This template is preconfigured with all the necessary boilerplate.*

Guide to ripping and running the game in-editor: https://github.com/cspotcode/bomb-rush-cyberfunk-modding/

## Thanks

YuriLewd for sharing this template and other guidance on Discord

LazyDuchess's helpful README explaining BepInEx.AssemblyPublicizer: https://github.com/LazyDuchess/BRC-PhotoStorage#building-from-source

NotNite for information about attaching a debugger and other guidance

All the modders on Team Reptile's Discord
