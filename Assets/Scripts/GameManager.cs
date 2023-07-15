using System.Collections;
using System.Collections.Generic;
using CriticalAngleStudios;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void GoToScene2()
    {
        SceneTransfer.ToSceneAsync(GameScenes.Scene2);
    }

    public void GoToScene1()
    {
        SceneTransfer.ToSceneAsync(GameScenes.Scene1);
    }
}
