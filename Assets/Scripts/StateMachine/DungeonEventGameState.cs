using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEventGameState : CardGameState
{
    [SerializeField] DeckTester _deckTester = null;
    [SerializeField] PlayerCharacter player = null;
    [SerializeField] GameObject[] _toSpawn = null;
    [SerializeField] Transform _dungeonCardZone = null;
    bool _checkDone = false;
    public int _dungeonEvent = 0;
    private GameObject _currentDungeonCard = null;

    public override void Enter()
    {
        //Debug.Log("Enetering Dungeon Event");
        _dungeonEvent = Random.Range(0, 4);
    }

    public override void Tick()
    {
        //if ((_deckTester._abilityDeck.Count == 0) && (_deckTester._abilityDiscard.Count == 0) && (_deckTester._playerHand.Count == 0))
        if(player._hp <0)
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

        if (_dungeonEvent == 0)
        {
            //good event
            _currentDungeonCard = Instantiate(_toSpawn[_dungeonEvent], _dungeonCardZone.position, _dungeonCardZone.rotation);
            player._hp += 2;
            _dungeonEvent = 5;
        }
        else if (_dungeonEvent == 1)
        {
            //good event
            _currentDungeonCard = Instantiate(_toSpawn[_dungeonEvent], _dungeonCardZone.position, _dungeonCardZone.rotation);
            player._magicalAttack += 1;
            _dungeonEvent = 5;
        }
        else if (_dungeonEvent == 2)
        {
            //bad event
            _currentDungeonCard = Instantiate(_toSpawn[_dungeonEvent], _dungeonCardZone.position, _dungeonCardZone.rotation);
            player._hp -= 3;
            _dungeonEvent = 5;
        }
        else if (_dungeonEvent == 3)
        {
            //bad event
            _currentDungeonCard = Instantiate(_toSpawn[_dungeonEvent], _dungeonCardZone.position, _dungeonCardZone.rotation);
            player._physicalDefense -= 1;
            _dungeonEvent = 5;
        }

    }

    public override void Exit()
    {
        //Debug.Log("Leaving Dungeon Event");
    }

    public void DungeonEventCheck()
    {

        _checkDone = true;
        Destroy(_currentDungeonCard);
    }
}
