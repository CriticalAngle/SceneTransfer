using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace CriticalAngleStudios
{
    public class SceneTransferScriptGenerator : AssetModificationProcessor
    {
        [MenuItem("Scene Transfer/Generate Scene Aliases")]
        public static void Generate()
        {
            var editorBuildSettingScenes = EditorBuildSettings.scenes;
            var scenes = new SceneAsset[editorBuildSettingScenes.Length];

            if (scenes.Length == 0)
            {
                Debug.LogError("There are no scenes in the Build Settings. The way that scenes aliases are generated is via the scenes in the build settings. Please add your scenes to the `Scenes In Build` list in order for this script to function properly.");
                return;
            }
            
            for (var i = 0; i < editorBuildSettingScenes.Length; i++)
                scenes[i] = AssetDatabase.LoadAssetAtPath<SceneAsset>(editorBuildSettingScenes[i].path);
            
            if (scenes.Any(scene => scene == null))
            {
                Debug.LogError(
                    "There is a scene in your build settings that has been deleted. Make sure to remove it before generating scene aliases.");
                return;
            }

            // Generate script contents to be connected to the partial class `GameScenes.cs`
            var scriptContents = "namespace CriticalAngleStudios\n{\n   public partial class GameScenes\n   {\n" +
                         GeneratedScenes(scenes) + "   }\n}";

            // Create file at the constant file path `Assets/SceneTransfer/Scripts/GeneratedGameScenes.cs`
            File.WriteAllText(Path.Combine(Application.dataPath, "SceneTransfer", "Scripts", "GeneratedGameScenes.cs"), scriptContents);

            // Reload scripts
            AssetDatabase.Refresh();
        }

        private static string GeneratedScenes(IEnumerable<SceneAsset> scenes)
        {
            var result = "";

            // Add alias to the string
            // Format is as follows:
            // `public static readonly GameScenes {formattedSceneName} = new({sceneName});
            foreach (var scene in scenes)
            {
                var sceneName = scene.name;
                var formattedSceneName = sceneName.Where(char.IsLetterOrDigit);
                result += $"        public static readonly GameScenes {new string(formattedSceneName.ToArray())} = new(\"{sceneName}\");\n";
            }

            return result;
        }
    }
}