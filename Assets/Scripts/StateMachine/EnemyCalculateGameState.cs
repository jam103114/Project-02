using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCalculateGameState : CardGameState
{
    bool _calculated = false;
    public override void Enter()
    {
        //Debug.Log("Entering Enemy Calculations..");
    }

    public override void Tick()
    {
        //Do Stuf for enemy turn prediction HERE
        _calculated = true;
        if (_calculated == true)
        {
           // Debug.Log("Enemy Calculations are done");
            _calculated = false;
            StateMachine.ChangeState<PlayerTurnCardGameState>();
        }
    }

    public override void Exit()
    {
        //Debug.Log("Exiting Enemy Calculations.");
    }


}
