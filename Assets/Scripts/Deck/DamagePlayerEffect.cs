using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamagePlayEffect", menuName = "CardData/PlayEffects/Damage")]
public class DamagePlayerEffect : CardEffect
{
    [SerializeField] int _pDamageAmount = 1;
    [SerializeField] int _mDamageAmount = 1;

    public override void Activate(ITargetable target)
    {
        IDamageable objectToDamage = target as IDamageable;

        if (objectToDamage != null)
        {
            objectToDamage.TakePhysicalDamage(_pDamageAmount);
            objectToDamage.TakeMagicDamage(_mDamageAmount);
            Debug.Log("Damaged the target by: " + _pDamageAmount + " physical damage.");
            Debug.Log("Damaged the target by: " + _mDamageAmount + " magic damage.");
        }
        else
        {
            Debug.Log("Target is not damageable...");
        }
    }
}
