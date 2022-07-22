using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour {

	private void Start()
	{
		GameManager.OnGameStateChanged += OnDrawState;
	}

    private void OnDrawState(GameManager.GameState obj)
    {
        DrawNewCard();
    }
    private void DrawNewCard()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.DrawCard);
    }
}
