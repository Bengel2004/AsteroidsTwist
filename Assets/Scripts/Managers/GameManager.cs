using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public SceneLoader sceneManager;
    public GameStateFSM gameStates;

    public bool gameIsPlaying = false;
    public int playerLevel;
    public static System.Action endGameSystems;

    public void OnDeath()
    {
        EndGame();
    }

    public void OnReset()
    {
        endGameSystems.Invoke();
    }

    public void MainMenu()
    {
        OnReset();
        gameStates.SwitchState(new GStart());
    }

    public void StartGame()
    {
        gameStates.SwitchState(new GRunning());
    }

    public void EndGame()
    {
        gameStates.SwitchState(new GEndGame());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        gameStates.SwitchState(new GStart());
        sceneManager = GetComponent<SceneLoader>();
    }

    private void OnEnable()
    {
        GameManager.Instance.playerLevel = 0;
        endGameSystems += ScoreManager.Instance.SetHighScore;
        endGameSystems += sceneManager.ResetScene;
    }

    private void OnDisable()
    {
        endGameSystems -= ScoreManager.Instance.SetHighScore;
        endGameSystems -= sceneManager.ResetScene;
    }



}
