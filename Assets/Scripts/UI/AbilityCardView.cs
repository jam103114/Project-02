using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityCardView : MonoBehaviour
{
    private TextMeshProUGUI _nameTextUI = null;
    private TextMeshProUGUI _costTextUI = null;
    private Image _graphicUI = null;
    // Start is called before the first frame update
    public void Display(AbilityCard abilityCard)
    {
        _nameTextUI = this.gameObject.transform.Find("Name_TMP").GetComponent<TextMeshProUGUI>();
        _nameTextUI.text = abilityCard.Name;
        _costTextUI = this.gameObject.transform.Find("Cost_TMP").GetComponent<TextMeshProUGUI>();
        _costTextUI.text = abilityCard.Cost.ToString();
        _graphicUI = this.gameObject.transform.Find("Sprite_img").GetComponent<Image>();
        _graphicUI.sprite = abilityCard.Graphic;
    }
}
