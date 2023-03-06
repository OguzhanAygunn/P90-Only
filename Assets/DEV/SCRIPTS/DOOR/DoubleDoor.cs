using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoor : MonoBehaviour
{
    Collider[] Colliders;
    DOOR[] Doors;
    // Start is called before the first frame update
    void Start()
    {
        Colliders = GetComponentsInChildren<Collider>();
        Doors = GetComponentsInChildren<DOOR>();
    }

    public void DisableDoors()
    {
        foreach(Collider collider in Colliders)
        {
            collider.enabled = false;
        }

        foreach(DOOR door in Doors)
        {
            door.DisableDoor();
        }
    }
}
