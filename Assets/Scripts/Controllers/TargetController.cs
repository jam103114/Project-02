using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public static ITargetable CurrentTarget;
    [SerializeField] Creature _objectToTarget = null;
    public bool _targetSetUp = false;
    void Update()
    {
        if (_targetSetUp == true)
        {
            ITargetable possibleTarget = _objectToTarget.GetComponent<ITargetable>();
            if (possibleTarget != null)
            {
                Debug.Log("New Target Acquired!");
                CurrentTarget = possibleTarget;
                _objectToTarget.Target();
            }
            _targetSetUp = false;
        }
    }
}
