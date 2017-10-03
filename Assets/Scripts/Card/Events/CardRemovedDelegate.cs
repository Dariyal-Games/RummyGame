using System;

public delegate void CardRemovedEventHandler(object sender, CardRemovedEventArgs e);

public class CardRemovedEventArgs : EventArgs
{
    public int CardIndex { get; private set; }

    public CardRemovedEventArgs(int cardIndex)
    {
        CardIndex = cardIndex;
    }
}


