using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public static ITargetable CurrentTarget;
    [SerializeField] Creature _creatureToTarget = null;
    public bool _targetSetUp = false;
    void Update()
    {
        if (_targetSetUp == true)
        {
            ITargetable possibleTarget = _creatureToTarget.GetComponent<ITargetable>();
            if (possibleTarget != null)
            {
                Debug.Log("New Target Acquired!");
                CurrentTarget = possibleTarget;
                _creatureToTarget.Target();
            }
            _targetSetUp = false;
        }
    }
}
