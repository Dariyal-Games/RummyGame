using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugChangeCard : MonoBehaviour
{

    public GameObject card;

    private CardFlipper flipper;
    private CardModel cardModel;
    private int cardIndex;

    private void Awake()
    {
        cardModel = card.GetComponent<CardModel>();
        flipper = card.GetComponent<CardFlipper>();
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10f, 10f, 100f, 28f), "Hit"))
        {

            if (cardIndex >= cardModel.cardFaces.Length)
            {
                cardIndex = 0;
                flipper.FlipCard(cardModel.cardFaces[cardModel.cardFaces.Length - 1], cardModel.cardBack, -1);
            }
            else
            {
                if (cardIndex > 0)
                {
                    flipper.FlipCard(cardModel.cardFaces[cardIndex - 1], cardModel.cardFaces[cardIndex], cardIndex);
                }
                else
                {
                    flipper.FlipCard(cardModel.cardBack, cardModel.cardFaces[cardIndex], cardIndex);
                }
                cardIndex++;
            }
        }
    }
}
