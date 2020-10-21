using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamagePlayEffect", menuName = "CardData/PlayEffects/Damage")]
public class DamagePlayerEffect : CardEffect
{
    [SerializeField] int _damageAmount = 1;

    public override void Activate(ITargetable target)
    {
        IDamageable objectToDamage = target as IDamageable;

        if (objectToDamage != null)
        {
            objectToDamage.TakeDamage(_damageAmount);
            Debug.Log("Damaged the target by: " + _damageAmount);
        }
        else
        {
            Debug.Log("Target is not damageable...");
        }
    }
}
