using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State CurrentState => _currentState;
    protected bool InTransition { get; private set; }

    State _currentState;
    protected State _previousState;

    private void Start()
    {
        ChangeState<MainMenuGameState>();
    }
    public void ChangeState<T>() where T : State 
    {
        T targetState = GetComponent<T>();
        if (targetState == null)
        {
            Debug.LogWarning("Cannot change to state, as it " +
                "does not exist on the state Machine object." +
                " Make sure you have the dsired State attached " +
                "tothe State Machin!");
            return;
        }
        //otherwise we found our state!
        InitiateStateChange(targetState);
    }

    public void RevertState()
    {
        if (_previousState != null)
        {
            InitiateStateChange(_previousState);
        }
    }

    void InitiateStateChange(State targetState)
    {
        if (_currentState != targetState && !InTransition)
        {
            Transition(targetState);
        }
    }

    void Transition(State newState)
    {
        //Start Transition
        InTransition = true;
        //Transitioning
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
        //End Transition
        InTransition = false;
    }

    private void Update()
    {
        //simulate Update in States with 'tick'
        if (CurrentState != null && !InTransition)
        {
            CurrentState.Tick();
        }
    }
}
