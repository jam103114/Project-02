﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTurnCardGameState : CardGameState
{
    [SerializeField] TextMeshProUGUI _playerTurnTextUI = null;
    [SerializeField] Creature _creature = null;

    int _playerTurnCount = 0;

    public override void Enter()
    {
        Debug.Log("Player Turn: ... Entering");
        _playerTurnTextUI.gameObject.SetActive(true);

        _playerTurnCount++;
        _playerTurnTextUI.text = "Player Turn: " + _playerTurnCount.ToString();
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
    }

    public override void Exit()
    {
        _playerTurnTextUI.gameObject.SetActive(false);
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
        Debug.Log("Player Turn: Exiting...");
    }

    public void OnPressedConfirm()
    {
        if(_creature._dead == true)
        {
            StateMachine.ChangeState<CombatEndGameState>();
        }
        else
        {
            StateMachine.ChangeState<EnemyTurnCardGameState>();

        }
    }
}
