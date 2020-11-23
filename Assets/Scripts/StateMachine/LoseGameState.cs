using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGameState : CardGameState
{
    [SerializeField] GameObject MainGame = null;
    [SerializeField] GameObject LoseGame = null;
    public override void Enter()
    {
        MainGame.SetActive(false);
        LoseGame.SetActive(true);
    }

    public override void Exit()
    {
        
    }
}
