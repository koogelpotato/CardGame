using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decider : MonoBehaviour {

    private List<CardsBehaviour> cardsBehaviours = new List<CardsBehaviour>();
    private void Start()
    {
        GameManager.OnGameStateChanged += OnDecisionState;
    }

    private void OnDecisionState(GameManager.GameState state)
    {
        if(state == GameManager.GameState.Decide)
        {
            GetAllTransformsInZone();
            Decide();
            DetermineState();
        }
    }

    private void Decide()
    {
        foreach(Transform card in GetAllTransformsInZone())
        {
            cardsBehaviours.Add(card.GetComponent<CardsBehaviour>());
        }
        
    }
    private void DetermineState()
    {
            
            if (cardsBehaviours[0].ReturnCardBeats() == cardsBehaviours[transform.childCount - 1].ReturnCardsBeatenBy())
            {
                GameManager.Instance.UpdateGameState(GameManager.GameState.Defeat);
            }
            if (cardsBehaviours[0].ReturnCardsBeatenBy() == cardsBehaviours[transform.childCount - 1].ReturnCardBeats())
            {
                GameManager.Instance.UpdateGameState(GameManager.GameState.Victory);
            }
            if (cardsBehaviours[0].ReturnCardBeats() == cardsBehaviours[transform.childCount - 1].ReturnCardBeats())
            {
                GameManager.Instance.UpdateGameState(GameManager.GameState.Draw);
            }
        
    }
    private List<Transform> GetAllTransformsInZone()
    {
        List<Transform> cardsTransforms = new List<Transform>();
        for(int i = 0; i<transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<CardsBehaviour>() != null)
            {
                cardsTransforms.Add(transform.GetChild(i).GetComponent<Transform>());
            }
        }
        return cardsTransforms;
    }
   
}
