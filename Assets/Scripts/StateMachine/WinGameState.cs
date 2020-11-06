using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameState : CardGameState
{
    public override void Enter()
    {
        Debug.Log("YOU WIN!");
        //DO STUFF HERE
    }

    public override void Exit()
    {
        //Dont realy need?
    }
}
