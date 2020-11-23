using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCardGameState : CardGameState
{
    [SerializeField] int _startingCardNumber = 5;
    [SerializeField] int _numberOfPlayers = 2;
    [SerializeField] DeckTester _deckTester = null;
    [SerializeField] Creature _creaute = null;
    [SerializeField] GameObject _gameObjectCreature = null;

    bool _activated = false;

    public override void Enter()
    {
        Debug.Log("Setup: ....Entering");
        Debug.Log("Creating " + _numberOfPlayers + " players.");
        Debug.Log("Creating deck with " + _startingCardNumber + " cards.");
        _activated = false;
        _deckTester.SetUpHand();
        _creaute._creatureCount++;
        _gameObjectCreature.SetActive(true);
    }

    public override void Tick()
    {
        if (_activated == false)
        {
            _activated = true;
            StateMachine.ChangeState<EnemyCalculateGameState>();
        }
    }

    public override void Exit()
    {
        _activated = false;
        Debug.Log("Setup: Exiting...");
    }
}
