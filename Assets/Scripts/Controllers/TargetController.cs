using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public static ITargetable CurrentTarget;
    [SerializeField] Creature _objectToTarget = null;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ITargetable possibleTarget = _objectToTarget.GetComponent<ITargetable>();
            if (possibleTarget != null)
            {
                Debug.Log("New Target Acquired!");
                CurrentTarget = possibleTarget;
                _objectToTarget.Target();
            }
        }
    }
}
