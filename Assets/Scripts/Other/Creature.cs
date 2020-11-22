using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void Kill()
    {
        _dead = true;
        Debug.Log("Creature Died");
        gameObject.SetActive(false);
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
}
