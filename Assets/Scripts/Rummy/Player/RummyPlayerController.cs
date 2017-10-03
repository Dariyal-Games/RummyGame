using UnityEngine;
using System.Collections;

// Rummy playercontroller.
// Player turn Consists of pick card and discard a card.
public class RummyPlayerController : MonoBehaviour
{
    public int playerID;
    public CardStack playerDeck;

    FiniteStateMachine<RummyPlayerController> stateMachine;
    RummyGameController gameController;
    bool PlayerTurn;

    public RummyGameController GameController { get { return gameController; } }

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void Initialize()
    { 
        if (playerDeck == null)
        {
            playerDeck = GetComponent<CardStack>();
            if (playerDeck == null) throw new System.NullReferenceException("playerDeck CardStack not found.");        
        }
        playerDeck.Initialize();


        gameController = FindObjectOfType<RummyGameController>();
        if (gameController == null) throw new System.NullReferenceException("Game Controller not found.");

        stateMachine = new FiniteStateMachine<RummyPlayerController>();
        stateMachine.Configure(this, RummyPlayerIdleState.Instance);
    }


    public void ChangeState(RummyPlayerState nextState)
    {
        stateMachine.ChangeState(nextState);
    }


    public void StartTurn()
    {
        //
        PlayerTurn = true;
    }

    public bool IsValidMove()
    {
        return true;
    }
}
