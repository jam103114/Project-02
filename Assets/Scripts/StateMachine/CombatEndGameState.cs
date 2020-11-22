using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEndGameState : CardGameState
{
    [SerializeField] Creature _creature = null;
    public override void Enter()
    {
        //Debug.Log("Combat Ending Enter");
    }

    public override void Tick()
    {
        if (_creature._boss == true)
        {
            StateMachine.ChangeState<WinGameState>();
        }
        else 
        {
            StateMachine.ChangeState<DungeonTurnGameState>();
        }
    }

    public override void Exit()
    {
        //Debug.Log("Combat Ending Exit");
    }
}
