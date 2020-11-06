using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonTurnGameState : CardGameState
{
    bool _event = false;
    bool _enemy = false;
    int _randomChoice = 1;
    [SerializeField] GameObject _dungeonEvent = null;
    [SerializeField] Creature _creature;


    /// <summary>
    /// NEED TO DO check dungeon deck size and determine if it is 0, if 0
    /// then instaniate boss and enter combat and mark the creature as boss
    /// </summary>
    public override void Enter()
    {
        Debug.Log("Entering Dungeon Turn");
    }

    public override void Tick()
    {


        if (_event == true)
        {
            Debug.Log("You chose a Dungeon Card");
            _event = false;
            StateMachine.ChangeState<DungeonEventGameState>();
        }
        else if (_enemy == true)
        {
            Debug.Log("You Chose an Enemy Card");
            _enemy = false;
            StateMachine.ChangeState<SetupCardGameState>();
        }
    }

    public override void Exit()
    {
        Debug.Log("Leving Dungeon Turn");
    }

    //THIS FUNCTION IS TEMP!!!!!!!!!!!!!!!!!!
    public void RandomChoice()
    {
        _randomChoice = Random.Range(1, 3);
        Debug.Log(_randomChoice);
        if (_randomChoice == 1)
        {
            DungeonEventPress();
        }
        else if (_randomChoice == 2)
        {
            EnemyCardPress();
        }

    }
    /////////////////////////////////////////
    public void DungeonEventPress()
    {
        _dungeonEvent.SetActive(true);
        _event = true;
    }

    public void EnemyCardPress()
    {

        _enemy = true;
    }
}
