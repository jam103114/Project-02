using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCharacter : MonoBehaviour
{
    public int _hp = 10;
    public int _MaxresourcePoints = 2;
    public int _resourcePoints = 2;
    public int _currentPDef = 1;
    public int _currentMDef = 1;
    public int _physicalAttack = 3;
    public int _physicalDefense = 3;
    public int _magicalAttack = 3;
    public int _magicalDefense = 3;
    public string _name = "enemy 1";

    [SerializeField] TextMeshProUGUI tmpName = null;
    [SerializeField] TextMeshProUGUI tmpPhysicalDef = null;
    [SerializeField] TextMeshProUGUI tmpPhysicalAttack = null;
    [SerializeField] TextMeshProUGUI tmpMagicDefense = null;
    [SerializeField] TextMeshProUGUI tmpMagicAttack = null;
    [SerializeField] TextMeshProUGUI tmpCurPhyDef = null;
    [SerializeField] TextMeshProUGUI tmpCurMagDef = null;
    [SerializeField] TextMeshProUGUI tmpHP = null;
    [SerializeField] TextMeshProUGUI tmpResourcePoints = null;

    private void Update()
    {
        tmpName.text = _name;
        tmpPhysicalDef.text = _physicalDefense.ToString();
        tmpPhysicalAttack.text = _physicalAttack.ToString();
        tmpMagicDefense.text = _magicalDefense.ToString();
        tmpMagicAttack.text = _magicalAttack.ToString();
        tmpCurPhyDef.text = _currentPDef.ToString();
        tmpCurMagDef.text = _currentMDef.ToString();
        tmpHP.text = _hp.ToString();
        tmpResourcePoints.text = _resourcePoints.ToString();
    }

    public void AddMagDef(int _md)
    {
        _md = _md * _magicalDefense;
        _currentMDef += _md;
    }

    public void AddPhyDef(int _pd)
    {
        _pd = _pd * _physicalDefense;
        _currentPDef += _pd;
    }
}
