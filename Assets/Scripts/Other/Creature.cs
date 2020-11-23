using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Creature : MonoBehaviour, ITargetable, IDamageable
{
    [SerializeField] int _currentHealth = 4;
    [SerializeField] int _currentPDef = 1;
    [SerializeField] int _currentMDef = 1;
    [SerializeField] int _physicalAttack = 1;
    [SerializeField] int _physicalDefense = 1;
    [SerializeField] int _magicalAttack = 1;
    [SerializeField] int _magicalDefense = 1;
    public bool _dead = false;
    public bool _boss = false;
    public int _creatureCount = 0;
    private int _tempcurrentHealth;
    private int _tempcurrentPDef;
    private int _tempcurrentMDef;
    private int _tempphysicalAttack;
    private int _tempphysicalDefense;
    private int _tempmagicalAttack;
    private int _tempmagicalDefense;
    public string _name = "enemy 1";

    [SerializeField] TextMeshProUGUI tmpName = null;
    [SerializeField] TextMeshProUGUI tmpPhysicalDef = null;
    [SerializeField] TextMeshProUGUI tmpPhysicalAttack = null;
    [SerializeField] TextMeshProUGUI tmpMagicDefense = null;
    [SerializeField] TextMeshProUGUI tmpMagicAttack = null;
    [SerializeField] TextMeshProUGUI tmpCurPhyDef = null;
    [SerializeField] TextMeshProUGUI tmpCurMagDef = null;
    [SerializeField] TextMeshProUGUI tmpHP = null;

    public void Kill()
    {
        _dead = true;
        Debug.Log("Creature Died");
        gameObject.SetActive(false);
    }

    private void Update()
    {
        tmpName.text = _name;
        tmpPhysicalDef.text = _physicalDefense.ToString();
        tmpPhysicalAttack.text = _physicalAttack.ToString();
        tmpMagicDefense.text = _magicalDefense.ToString();
        tmpMagicAttack.text = _magicalAttack.ToString();
        tmpCurPhyDef.text = _currentPDef.ToString();
        tmpCurMagDef.text = _currentMDef.ToString();
        tmpHP.text = _currentHealth.ToString();
}

    public void TakePhysicalDamage(int damage)
    {
        damage = damage * _physicalAttack;
        _currentPDef = _currentPDef - damage;
        if (_currentPDef <= 0)
        {
            damage = Mathf.Abs(_currentPDef);
            _currentHealth -= damage;
            Debug.Log("Took damage. Remaining health: " + _currentHealth);
            _currentPDef = 0;
            if (_currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void TakeMagicDamage(int damage)
    {
        damage = damage * _magicalAttack;
        _currentMDef = _currentMDef - damage;
        if (_currentMDef <= 0)
        {
            damage = Mathf.Abs(_currentMDef);
            _currentHealth -= damage;
            Debug.Log("Took damage. Remaining health: " + _currentHealth);
            _currentMDef = 0;
            if (_currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Target()
    {
        Debug.Log("Creature has been targeted.");
    }

    public void NextCreature()
    {
        if (_creatureCount == 1)
        {
            _name = "enemy 2";
            _tempcurrentHealth = Random.Range(4,8);
            _currentHealth = _tempcurrentHealth;
            _tempcurrentPDef = Random.Range(1,3);
            _currentPDef = _tempcurrentPDef;
            _tempcurrentMDef = Random.Range(1, 3);
            _currentMDef = _tempcurrentMDef;
            _tempphysicalAttack = Random.Range(1, 3);
            _physicalAttack = _tempphysicalAttack;
            _tempphysicalDefense = Random.Range(1, 3);
            _physicalDefense = _tempphysicalDefense;
            _tempmagicalAttack = Random.Range(1, 3);
            _magicalAttack = _tempmagicalAttack;
            _tempmagicalDefense = Random.Range(1, 3);
            _magicalDefense = _tempmagicalDefense;
}
        else if (_creatureCount == 2)
        {
            _name = "enemy 3";
            _tempcurrentHealth = Random.Range(_tempcurrentHealth, _tempcurrentHealth + 3);
            _currentHealth = _tempcurrentHealth;
            _tempcurrentPDef = Random.Range(_tempcurrentPDef, _tempcurrentPDef + 3);
            _currentPDef = _tempcurrentPDef;
            _tempcurrentMDef = Random.Range(_tempcurrentMDef, _tempcurrentMDef + 3);
            _currentMDef = _tempcurrentMDef;
            _tempphysicalAttack = Random.Range(_tempphysicalAttack, _tempphysicalAttack + 3);
            _physicalAttack = _tempphysicalAttack;
            _tempphysicalDefense = Random.Range(_tempphysicalDefense, _tempphysicalDefense + 3);
            _physicalDefense = _tempphysicalDefense;
            _tempmagicalAttack = Random.Range(_tempmagicalAttack, _tempmagicalAttack + 3);
            _magicalAttack = _tempmagicalAttack;
            _tempmagicalDefense = Random.Range(_tempmagicalDefense, _tempmagicalDefense + 3);
            _magicalDefense = _tempmagicalDefense;
        }
        else if (_creatureCount == 3)
        {
            _name = "enemy 4";
            _tempcurrentHealth = Random.Range(_tempcurrentHealth, _tempcurrentHealth + 3);
            _currentHealth = _tempcurrentHealth;
            _tempcurrentPDef = Random.Range(_tempcurrentPDef, _tempcurrentPDef + 3);
            _currentPDef = _tempcurrentPDef;
            _tempcurrentMDef = Random.Range(_tempcurrentMDef, _tempcurrentMDef + 3);
            _currentMDef = _tempcurrentMDef;
            _tempphysicalAttack = Random.Range(_tempphysicalAttack, _tempphysicalAttack + 3);
            _physicalAttack = _tempphysicalAttack;
            _tempphysicalDefense = Random.Range(_tempphysicalDefense, _tempphysicalDefense + 3);
            _physicalDefense = _tempphysicalDefense;
            _tempmagicalAttack = Random.Range(_tempmagicalAttack, _tempmagicalAttack + 3);
            _magicalAttack = _tempmagicalAttack;
            _tempmagicalDefense = Random.Range(_tempmagicalDefense, _tempmagicalDefense + 3);
            _magicalDefense = _tempmagicalDefense;
        }
        else if (_creatureCount == 4)
        {
            _name = "Boss";
            _boss = true;
            _tempcurrentHealth = Random.Range(_tempcurrentHealth, _tempcurrentHealth + 3);
            _currentHealth = _tempcurrentHealth;
            _tempcurrentPDef = Random.Range(_tempcurrentPDef, _tempcurrentPDef + 3);
            _currentPDef = _tempcurrentPDef;
            _tempcurrentMDef = Random.Range(_tempcurrentMDef, _tempcurrentMDef + 3);
            _currentMDef = _tempcurrentMDef;
            _tempphysicalAttack = Random.Range(_tempphysicalAttack, _tempphysicalAttack + 3);
            _physicalAttack = _tempphysicalAttack;
            _tempphysicalDefense = Random.Range(_tempphysicalDefense, _tempphysicalDefense + 3);
            _physicalDefense = _tempphysicalDefense;
            _tempmagicalAttack = Random.Range(_tempmagicalAttack, _tempmagicalAttack + 3);
            _magicalAttack = _tempmagicalAttack;
            _tempmagicalDefense = Random.Range(_tempmagicalDefense, _tempmagicalDefense + 3);
            _magicalDefense = _tempmagicalDefense;
        }
    }
}
