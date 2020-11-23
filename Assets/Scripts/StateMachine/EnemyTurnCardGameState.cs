using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnCardGameState : CardGameState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;

    [SerializeField] float _pauseDuration = 1.5f;
    [SerializeField] DeckTester _deckTester = null;
    [SerializeField] PlayerCharacter playerCharacter = null;
    [SerializeField] Creature creature = null;

    public override void Enter()
    {
        //Debug.Log("Enemy Turn: ...Enter");
        EnemyTurnBegan?.Invoke();
        

        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    public override void Tick()
    {
        //if ((_deckTester._abilityDeck.Count == 0) && (_deckTester._abilityDiscard.Count == 0) && (_deckTester._playerHand.Count == 0))
        if(playerCharacter._hp <= 0)
        {
            Debug.Log("You Lose");
            StateMachine.ChangeState<LoseGameState>();
        }
    }
    public override void Exit()
    {
        //Debug.Log("Enemy Turn: Exit...");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy Thinking...");
        if (creature._choice == 0)
        {
            //phy att
            creature.PAttack();
            Debug.Log("Enemy ATTACK PHY");
        }
        else if (creature._choice == 1)
        {
            //phy def
            creature.PDef();
            Debug.Log("Enemy DEF PHY");

        }
        else if (creature._choice == 2)
        {
            //mag att
            creature.MAttack();
            Debug.Log("Enemy ATTACK Mag");

        }
        else if (creature._choice == 3)
        {
            //mag def
            creature.MDef();
            Debug.Log("Enemy DEF Mag");

        }
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("Enemy performs action");
        EnemyTurnEnded?.Invoke();
        StateMachine.ChangeState<EnemyCalculateGameState>();
    }
}
