using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatePlayerDamageTurnGameState : CardGameState
{
    bool _calculated = false;
    [SerializeField] Creature _creature = null;
    public override void Enter()
    {
        Debug.Log("Calculating Player Damage");
    }

    public override void Tick()
    {
        //Do Stuff with cards
        _calculated = true;
        if (_calculated == true)
        {
            if (_creature._dead == true)
            {
                StateMachine.ChangeState<CombatEndGameState>();
            }
            else
            {
                StateMachine.ChangeState<EnemyTurnCardGameState>();
            }
        }
    }

    public override void Exit()
    {
        Debug.Log("Leaving Player Damage Cal state");
    }
}
