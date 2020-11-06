using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameSM : StateMachine
{
    
    [SerializeField] InputController _input = null;
    public InputController Input => _input;
    private void Start()
    {
        ChangeState<MainMenuGameState>();
        //set starting state here
    }
}
