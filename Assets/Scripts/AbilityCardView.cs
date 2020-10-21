﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityCardView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _nameTextUI = null;
    [SerializeField] TextMeshProUGUI _costTextUI = null;
    [SerializeField] Image _graphicUI = null;
    // Start is called before the first frame update
    public void Display(AbilityCard abilityCard)
    {
        _nameTextUI.text = abilityCard.Name;
        _costTextUI.text = abilityCard.Cost.ToString();
        _graphicUI.sprite = abilityCard.Graphic;
    }
}
