using System;

public delegate void CardAddedEventHandler(object sender, CardAddedEventArgs e);

public class CardAddedEventArgs : EventArgs
{
    public int CardIndex { get; private set; }

    public CardAddedEventArgs(int cardIndex)
    {
        CardIndex = cardIndex;
    }
}