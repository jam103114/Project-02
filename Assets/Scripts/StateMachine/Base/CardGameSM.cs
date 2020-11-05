﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameSM : StateMachine
{
    [SerializeField] InputController _input;
    public InputController Input => _input;
    private void Start()
    {
        ChangeState<SetupCardGameState>();
        //set starting state here
    }
}
