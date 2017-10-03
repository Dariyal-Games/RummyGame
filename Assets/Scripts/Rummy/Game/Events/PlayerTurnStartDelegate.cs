using System;

public delegate void PlayerTurnStartEventHandler(object sender, PlayerTurnStartEventArgs e);

public class PlayerTurnStartEventArgs : EventArgs
{
    public int PlayerID { get; private set; }

    public PlayerTurnStartEventArgs(int id)
    {
        PlayerID = id;
    }
}
