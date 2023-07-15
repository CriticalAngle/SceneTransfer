# SceneTransfer
A basic script generator to give aliases to all of your scenes to use in code for transitioning scenes.

SceneTransfer works by looking at all of the scenes in your build settings, then generates a C# script with a class called `GameScenes` that houses aliases for each of your scenes. The aliases are instances of the `GameScenes` class, and each has a `this.Value` to get the string value of the scene name. This `Value` property is handy for scene management without the `SceneTransfer` script.

## Install
1. Download the latest unitypackage from the releases tab
2. Open your Unity project
3. Double-click on the unitypackage to import the package
4. Import all

## Usage
1. First, you must have all of your scenes added to the build settings
2. In the file menu of Unity, click `Scene Transfer > Generate Scene Aliases`
3. Let Unity recompile the project
4. Now, you can access `CriticalAngleStudios.GameScenes.<YourSceneName>` to get an instance of `GameScenes` for each scene

### *IMPORTANT: You must repeat step 2 every time you reorder your scenes in the build settings, rename a scene, delete a scene, or add a scene in order to keep the generated aliases up-to-date.*

In order to switch scenes, you can either use the Unity default method of scene transitions, like so:
```cs
SceneManager.LoadScene(GameScenes.MainMenuScene.Value);
```
or the SceneTransfer method:
```cs
SceneTransfer.ToScene(GameScenes.MainMenuScene);
// Async alternative that returns a built-in AsyncOperation instance
AsyncOperation operation = SceneTransfer.ToSceneAsync(GameScenes.MainMenuScene);
```
They both accomplish the same thing essentially, so it's up to personal preference.

And that's it! Hope your life is now slightly easier!
