using UnityEngine;
using UnityEngine.SceneManagement;

namespace CriticalAngleStudios
{
    public static class SceneTransfer
    {
        public static void ToScene(GameScenes scene, LoadSceneMode mode = LoadSceneMode.Single) =>
            SceneManager.LoadScene(scene.Value, mode);

        public static AsyncOperation ToSceneAsync(GameScenes scene, LoadSceneMode mode = LoadSceneMode.Single) =>
            SceneManager.LoadSceneAsync(scene.Value, mode);
    }
}