using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public Text txt_Score;
    [SerializeField] public Text txt_Best;
    [SerializeField] public GameObject mainScreen;
    [SerializeField] public GameObject ingameScreen;
    [SerializeField] public GameObject gameoverScreen;
    private void Awake()
    {
        GameStateManager.GameStateChanged += GameStateChanged;
    }
    private void GameStateChanged()
    {
        switch (GameStateManager.CurrentState)
        {
            case GameState.Idle:
                mainScreen?.SetActive(true);
                ingameScreen?.SetActive(false);
                gameoverScreen?.SetActive(false);
                break;
            case GameState.Play:
                mainScreen?.SetActive(false);
                ingameScreen?.SetActive(true);
                gameoverScreen?.SetActive(false);
                break;
            case GameState.GameOver:
                txt_Score.text = $"{ScoreManager.instance.score}";
                txt_Best.text = $"{ScoreManager.instance.best}";
                mainScreen?.SetActive(false);
                ingameScreen?.SetActive(false);
                gameoverScreen?.SetActive(true);
                break;
        }
    }
    public void Btn_Play()
    {
        GameStateManager.CurrentState = GameState.Play;
    }
    public void Btn_Restart()
    {
        GameStateManager.CurrentState = GameState.Play;
    }
}
