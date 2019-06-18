# Unity_FrameRateSettings

Set Application.targetFrameRate from Inspector &amp; CommandLineArgs.

## Import to Your Project

You can import this asset from UnityPackage.

- [FrameRateSettings.unitypackage](https://github.com/XJINE/Unity_FrameRateSettings/blob/master/FrameRateSettings.unitypackage)

### Dependencies

You have to import following assets to use this asset.

- [Unity_SingletonMonoBehaviour](https://github.com/XJINE/Unity_SingletonMonoBehaviour)
- [Unity_CommandLineArgs](https://github.com/XJINE/Unity_CommandLineArgs)

## How to Use

### Settings

You can set ```vSyncCount``` and ```targetFrameRate``` from Inspector or CommandLineArgs when you start the apps.
For example, one of the CommandLineArgs settings is like this.

```
-vSyncCount 0 -targetFrameRate 30
```