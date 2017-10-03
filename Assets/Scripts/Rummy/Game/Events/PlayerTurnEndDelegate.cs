using System;

public delegate void PlayerTurnEndEventHandler(object sender, PlayerTurnEndEventArgs e);

public class PlayerTurnEndEventArgs : EventArgs
{
    public int PlayerID { get; private set; }

    public PlayerTurnEndEventArgs(int id)
    {
        PlayerID = id;
    }
}
