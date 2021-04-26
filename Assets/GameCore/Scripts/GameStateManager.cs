using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] GameState currentState = GameState.None;
    public static System.Action GameStateChanged;
    public static GameStateManager instance;
    public static GameState CurrentState
    {
        get => instance.currentState;
        set
        {
            if (instance.currentState != value)
            {
                instance.currentState = value;
                if(GameStateChanged!=null)
                    GameStateChanged.Invoke();
            }
        }
    }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        CurrentState = GameState.Idle;
    }
}
public enum GameState
{
    None,
    Idle,
    Play,
    GameOver
}