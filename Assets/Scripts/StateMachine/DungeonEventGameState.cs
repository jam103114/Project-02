using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEventGameState : CardGameState
{
    [SerializeField] DeckTester _deckTester = null;
    bool _checkDone = false;
    public override void Enter()
    {
        Debug.Log("Enetering Dungeon Event");
    }

    public override void Tick()
    {
        if ((_deckTester._abilityDeck.Count == 0) && (_deckTester._abilityDiscard.Count == 0) && (_deckTester._playerHand.Count == 0))
        {
            Debug.Log("You Lose");
            StateMachine.ChangeState<LoseGameState>();
        }
        else if (_checkDone == true)
        {
            Debug.Log("Dungeon Event resolved.");
            _checkDone = false;
            StateMachine.ChangeState<DungeonTurnGameState>();
        }
        

    }

    public override void Exit()
    {
        Debug.Log("Leaving Dungeon Event");
    }

    public void DungeonEventCheck()
    {
        _checkDone = true;
    }
}
