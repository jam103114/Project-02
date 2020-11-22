using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTurnCardGameState : CardGameState
{
    [SerializeField] TextMeshProUGUI _playerTurnTextUI = null;
    //[SerializeField] Creature _creature = null;
    [SerializeField] DeckTester _deckTester = null;

    int _playerTurnCount = 0;

    public override void Enter()
    {
        _playerTurnTextUI.gameObject.SetActive(true);
        //multiply draw by num of cards played
        _deckTester.Draw();

        _playerTurnCount++;
        _playerTurnTextUI.text = "Player Turn: " + _playerTurnCount.ToString();
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        _deckTester.SwitchButtonsOn();
    }

    public override void Exit()
    {
        _playerTurnTextUI.gameObject.SetActive(false);
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
        //Debug.Log("Player Turn: Exiting...");
        _deckTester.SwitchButtonsOff();
    }

    public void OnPressedConfirm()
    {
            StateMachine.ChangeState<CalculatePlayerDamageTurnGameState>();
    }
}
