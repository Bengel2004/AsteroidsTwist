using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SceneLoader SceneManager;

    public static int playerLevel;
    public static System.Action endGameSystems;

    public static void OnReset()
    {
        endGameSystems();
    }


    private void OnDisable()
    {
        endGameSystems -= ScoreManager.Instance.SetHighScore;
        endGameSystems -= SceneManager.ResetScene;
    }

    private void OnEnable()
    {
        GameManager.playerLevel = 0;
        endGameSystems += ScoreManager.Instance.SetHighScore;
        endGameSystems += SceneManager.ResetScene;
    }




}
