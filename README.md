# Retarget Maya Plugin

[<img alt="JetBrains Rider" width="32" heigth="32" src="https://user-images.githubusercontent.com/43999804/217959519-1784aa12-752e-497d-871e-118be97c45b7.png">](https://www.jetbrains.com/rider/)
[<img alt=".NET" width="32" heigth="32" src="https://user-images.githubusercontent.com/43999804/188286385-c3f75309-b7d0-4ce7-8357-93730ffc9b9c.svg">](https://dotnet.microsoft.com)
[<img alt="C#" width="32" heigth="32" src="https://user-images.githubusercontent.com/43999804/188286413-c165e68f-669b-4337-b412-ef5e2ba63e50.svg">](https://docs.microsoft.com/en-us/dotnet/csharp/)
[<img alt="XAML" width="32" heigth="32" src="https://user-images.githubusercontent.com/43999804/188286388-b5d0a802-c594-491e-84c6-efe9e898eff6.svg">](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/xaml)
[<img alt="Maya 2020.4" width="32" heigth="32" src="https://user-images.githubusercontent.com/43999804/217960177-5eb89a05-058a-4ccf-b0b3-37eb5b178d86.png">](https://www.autodesk.com/products/maya/overview)

Plugin for automating animation retargeting for a specific Maya scene.

> The plugin is designed for the Maya 2020.4

## Install

To install the plugin, you need to download it and place it in the directory with Maya plugins.

The directory with Maya plugins is located at the following path:
```
{MAYA_PATH}\bin\plug-ins\
```
> {MAYA_PATH} - the path to the folder with the Maya application.

The latest versions of the plugin are located in the [Release](https://github.com/XDenizX/RetargetMayaPlugin/releases) tab.

## Usage

Before using the plugin, you need to load it in the plugin manager.

Open the Maya menu tab: **Windows->Settings/Preferences->Plug-in Manager**.

Find the plugin with the name in the list that appears **XrayRetargetAnimationPlugin.nll.dll**.

Check the box in the **Loaded** section.

Type the following command in the Maya command prompt:
```
start_anim_retarget
```
