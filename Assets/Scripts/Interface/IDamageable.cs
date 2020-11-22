﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    void TakePhysicalDamage(int damage);
    void TakeMagicDamage(int damage);
    void Kill();
}
