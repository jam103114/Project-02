using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartGameState : CardGameState
{
    public static event Action StartGameBegan;
    public static event Action StartGameEnded;

    [SerializeField] float _pauseDuration = 1.5f;

    public override void Enter()
    {
        Debug.Log("Starting Game");
        StartGameBegan?.Invoke();
        StartCoroutine(StartingGame(_pauseDuration));

    }

    public override void Exit()
    {
        Debug.Log("Leaving Start Game");
    }

    IEnumerator StartingGame(float pauseDuration)
    {
        Debug.Log("Setting Up Dungeon Deck");
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("Done");
        StartGameEnded?.Invoke();
        StateMachine.ChangeState<DungeonTurnGameState>();
    }
}
