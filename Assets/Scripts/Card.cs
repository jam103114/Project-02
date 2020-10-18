using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card 
{
    public string Name { get; protected set; } = "...";

    /*public Card(string name)
    {
        Name = name;
    }*/

    public abstract void Play();
}
