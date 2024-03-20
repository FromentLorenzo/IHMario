using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    public UnityEvent<GameObject, Checkpoint> onCheckpointEnter;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<CarIdentity>())
        {
            onCheckpointEnter.Invoke(collider.gameObject, this);
        }
    }
}
