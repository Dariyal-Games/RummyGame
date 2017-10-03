using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardStack : MonoBehaviour, IInteractable
{
    public event CardRemovedEventHandler CardRemoved;
    public event CardAddedEventHandler CardAdded;
    public event InteractabilityChangedEventHandler InteractabilityChanged;

    public bool isDeck;

    List<int> cards;
    bool isInteractable;

    public bool HasCards
    {
        get { return (CardCount > 0); }
    }

    public int CardCount
    {
        get
        {
            if (cards == null)
            {
                return 0;
            }
            else
            {
                return cards.Count;
            }
        }
    }

    public bool IsInteractable
    {
        get { return isInteractable; }
        set
        {
            if (isInteractable != value)
            {
                isInteractable = value;
                if (InteractabilityChanged != null) InteractabilityChanged(this, new InteractabilityChangedEventArgs(value));
            }
        }
    }

    public void Initialize()
    {
        cards = new List<int>();

        if (isDeck)
            CreateDeck();
    }

    public IEnumerable<int> GetCards()
    {
        foreach (int i in cards)
        {
            yield return i;
        }
    }

    public void CreateDeck()
    {
        for (int i = 0; i < 52; i++)
        {
            cards.Add(i);
        }

        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }
    }

    public int Pop()
    {
        if (cards.Count <= 0) return -1;

        int temp = cards[0];
        cards.RemoveAt(0);

        if (CardRemoved != null) CardRemoved(this, new CardRemovedEventArgs(temp));

        return temp;
    }

    public void Push(int card)
    {
        if (card == -1) return;

        cards.Add(card);

        if (CardAdded != null) CardAdded(this, new CardAddedEventArgs(card));
    }
}
