using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour, ITargetable, IDamageable
{
    int _currentHealth = 10;

    public void Kill()
    {
        Debug.Log("Creature Died");
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log("Took damage. Remaining health: " + _currentHealth);
        if (_currentHealth <= 0)
        {
            Kill();
        }
    }
    public void Target()
    {
        Debug.Log("Creature has been targeted.");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
