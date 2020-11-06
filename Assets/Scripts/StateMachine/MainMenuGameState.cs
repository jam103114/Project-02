using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGameState : CardGameState
{
    bool _activated = false;
    public override void Enter()
    {
        Debug.Log("Main Menu");

    }

    public override void Tick()
    {
        Debug.Log("calling mm tick");
        if (_activated == true)
        {
            _activated = false;
            StateMachine.ChangeState<GameStartGameState>();
        }
    }

    public override void Exit()
    {
        Debug.Log("Leaving Main Menu");
    }

    public void OnPressStartGame()
    {
        Debug.Log("hit the button");
        _activated = true;
    }
}
