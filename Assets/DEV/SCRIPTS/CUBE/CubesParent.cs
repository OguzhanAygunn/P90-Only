using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesParent : MonoBehaviour
{
    Cube[] Cubes;
    Transform PlayerPos;
    [SerializeField] private float Distance;
    [SerializeField] bool DisableCubes;
    bool active;
    // Start is called before the first frame update

    private void Awake()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        Cubes = GetComponentsInChildren<Cube>();

        if (DisableCubes)
            foreach(Cube cube in Cubes)
                cube.enabled = false;
    }

    private void FixedUpdate()
    {
        DistanceOP();
    }

    void DistanceOP()
    {
        if (active || DisableCubes || !PlayerPos) return;

        if(Vector3.Distance(transform.position,PlayerPos.position) < Distance)
        {
            foreach (Cube cube in Cubes)
            {
                cube.ToDefaultTransformValues();
            }
            active = true;
        }
    }
}
