using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDefendPlayEffect", menuName = "CardData/PlayEffects/Defend")]
public class DefendPlayerEffect : CardEffect
{
    [SerializeField] int _pDefAmount = 1;
    [SerializeField] int _mDefAmount = 1;
    [SerializeField] PlayerCharacter pcs = null;

    public override void Activate(ITargetable target)
    {
        pcs = GameObject.FindObjectOfType<PlayerCharacter>();
        if (pcs != null)
        {
            pcs.AddPhyDef(_pDefAmount);
            pcs.AddMagDef(_mDefAmount);
            Debug.Log("Physical defense add to the target by: " + _pDefAmount + " physical defense.");
            Debug.Log("Magic defense add to the target by: " + _mDefAmount + " magic defense.");
        }
        else
        {
            Debug.Log("Target is not defendable...");
        }
    }
}
