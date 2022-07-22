using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
    public  GameState state;
    public static event Action<GameState> OnGameStateChanged;
	void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UpdateGameState(GameState.DrawCard); // sets initial state
    }
    
    public void UpdateGameState(GameState newState) // updates current gamestate
    {
        state = newState; // sets new state with logic assigned to it
        switch (state)
        {
            case GameState.DrawCard:
                HandlePlayerTurn();
                break;
            case GameState.EnemyDrawCard:
                HandleEnemyDrawCard();
                break;
            case GameState.Decide:
                HandleDecision();
                break;
            case GameState.Victory:
                HandleVictoryDisplay();
                break;
            case GameState.Defeat:
                HandleDefeatDisplay();
                break;
            case GameState.Draw:
                HandleDrawDisplay();
                break;
            default:
                throw new ArgumentOutOfRangeException("NO STATE", newState, null);
               
        }
        if (OnGameStateChanged != null)
        {
            OnGameStateChanged(newState);
        }
        
    }

    private void HandleDecision()
    {
       
    }

    private  void HandleDrawDisplay()
    {
        
    }

    private void HandleDefeatDisplay()
    {
        
    }

    private void HandleVictoryDisplay()
    {
        
    }

    private void HandleEnemyDrawCard()
    {
        
    }

    private void HandlePlayerTurn()
    {
        
    }

    public enum GameState // enums for game states
    {
        DrawCard,
        EnemyDrawCard,
        Decide,
        Victory,
        Defeat,
        Draw,

    }
}
