using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameState : CardGameState
{
    [SerializeField] GameObject MainGame = null;
    [SerializeField] GameObject WinGame = null;
    public override void Enter()
    {
        Debug.Log("YOU WIN!");
        MainGame.SetActive(false);
        WinGame.SetActive(true);
    }

    public override void Exit()
    {
        //Dont realy need?
    }
}
