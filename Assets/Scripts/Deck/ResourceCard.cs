using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewResourceCard", menuName = "CardData/ResourceCard")]
public class ResourceCard : ScriptableObject
{
    [System.Serializable] public enum Type { sword, shield, staff, barrier };
    public Type _type;
    public Type CardType => _type;

    [SerializeField] int _cost = 1;
    public int Cost => _cost;


    [SerializeField] Sprite _graphic = null;
    public Sprite Graphic => _graphic;

    [SerializeField] int _physicalAttackMod = 0;
    public int PhysicalAttackMod => _physicalAttackMod;

    [SerializeField] int _physicalDefenseMod = 0;
    public int PhysicalDefenseMod => _physicalDefenseMod;

    [SerializeField] int _magicAttackMod = 0;
    public int MagicAttackMod => _magicAttackMod;

    [SerializeField] int _magicDefenseMod = 0;
    public int MagicDefenseMod => _magicDefenseMod;



    //[SerializeField] CardEffect _playEffect = null;
    //public CardEffect PlayEffect => _playEffect;

}
