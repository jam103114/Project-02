﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTurnCardGameState : CardGameState
{
    [SerializeField] TextMeshProUGUI _playerTurnTextUI = null;
    [SerializeField] DeckTester _deckTester = null;
    [SerializeField] PlayerCharacter _playerCharacter = null;
    [SerializeField] Creature creature = null;

    public int _playerTurnCount = 0;

    public override void Enter()
    {
        _playerTurnTextUI.gameObject.SetActive(true);
        _deckTester.SetUpHand();
        _playerTurnCount++;
        _playerTurnTextUI.text = "Player Turn: " + _playerTurnCount.ToString();
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        _deckTester.SwitchButtonsOn();
    }

    public override void Exit()
    {
        _playerTurnTextUI.gameObject.SetActive(false);
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
        _deckTester.SwitchButtonsOff();
    }

    public void OnPressedConfirm()
    {
        Debug.Log("current resourse points" + _playerCharacter._resourcePoints);
        if ((_playerCharacter._resourcePoints <= 0) || (creature._dead == true))
        {
            StateMachine.ChangeState<CalculatePlayerDamageTurnGameState>();
            _playerCharacter._resourcePoints = _playerCharacter._MaxresourcePoints;
            _deckTester.numCardsPlayed = 0;
        }
    }
}
