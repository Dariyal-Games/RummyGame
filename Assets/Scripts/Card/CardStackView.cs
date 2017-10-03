using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardStack))]
public class CardStackView : MonoBehaviour
{
    CardStack stack;
    Dictionary<int, GameObject> fetcedCards;

    public bool isFaceDown;
    public Vector3 start;
    public Vector3 offset;
    public Vector3 selectedOffset;
    public GameObject cardPrefab;

    Vector3 lastAddedCardPosition;
    bool isInteractable;

    private void Start()
    {
        fetcedCards = new Dictionary<int, GameObject>();
        stack = GetComponent<CardStack>();

        ShowCards();
        lastAddedCardPosition = start;

        stack.CardRemoved += Stack_CardRemoved;
        stack.CardAdded += Stack_CardAdded;
        stack.InteractabilityChanged += Stack_InteractabilityChanged;
    }

    private void Stack_InteractabilityChanged(object sender, InteractabilityChangedEventArgs e)
    {
        isInteractable = e.NewValue;
    }

    private void Stack_CardRemoved(object sender, CardRemovedEventArgs e)
    {
        if (fetcedCards.ContainsKey(e.CardIndex))
        {
            RemoveCard(e.CardIndex);
        }
    }

    private void Stack_CardAdded(object sender, CardAddedEventArgs e)
    {
        if (!fetcedCards.ContainsKey(e.CardIndex))
        {
            Vector3 position = lastAddedCardPosition;
            if (fetcedCards.Count > 0)
                position += offset;
            AddCard(position, e.CardIndex, fetcedCards.Count);
        }
    }

    private void ShowCards()
    {
        if (stack.HasCards)
        {
            int cardCount = 0;

            foreach (int i in stack.GetCards())
            {
                Vector3 position = start + cardCount * offset;

                AddCard(position, i, cardCount);

                cardCount++;
            }
        }
    }

    void AddCard(Vector3 position, int cardIndex, int positionIndex)
    {
        if (fetcedCards.ContainsKey(cardIndex))
        {
            return;
        }

        GameObject card = Instantiate(cardPrefab);
        card.transform.position = position;

        CardModel cardModel = card.GetComponent<CardModel>();
        cardModel.cardIndex = cardIndex;
        cardModel.ToggleFace(!isFaceDown);
        cardModel.Selected += CardModel_Selected;
        cardModel.Deselected += CardModel_Deselected;

        SpriteRenderer spriteRenderer = card.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 51 - positionIndex;

        fetcedCards.Add(cardIndex, card);

        lastAddedCardPosition = position;
    }

    private void RemoveCard(int cardIndex)
    {
        Destroy(fetcedCards[cardIndex]);
        fetcedCards.Remove(cardIndex);
    }

    private void CardModel_Deselected(object sender, DeselectedEventArgs e)
    {
        if (isInteractable)
            e.SelectedObject.transform.position -= selectedOffset;
    }

    private void CardModel_Selected(object sender, SelectedEventArgs e)
    {
        if (isInteractable)
            e.SelectedObject.transform.position += selectedOffset;
    }
}
