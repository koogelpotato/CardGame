using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrawCard : MonoBehaviour {

    [SerializeField] private Transform table;
    public static CardAssembler enemyCard;
	private void Start()
	{
		GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameManager.GameState state)
    {

        if(state == GameManager.GameState.EnemyDrawCard)
        {
            CardDrawEnemy();
        }
    }
    private void CardDrawEnemy()
    {
        Transform pickedCard = GetRandomCard();
        pickedCard.SetParent(table);
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
        GameManager.Instance.UpdateGameState(GameManager.GameState.Decide);
        
    }
    private Transform GetRandomCard()
    {
         return transform.GetChild(UnityEngine.Random.Range(0, transform.childCount));
    }
    
}
