using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner Instance;

    public GameObject Coin;

    void Awake() => Instance = (!Instance) ? this : Instance;
    public void CoinSpawn(Transform Pos, int Count = 10,Vector3 offset = new Vector3())
    {
        while(Count > 0)
        {
            GameObject coinobj = Instantiate(Coin, Pos.position + offset, Quaternion.identity).gameObject;
            Rigidbody coinRigid = coinobj.GetComponent<Rigidbody>();
            coinRigid.velocity = new Vector3(Random.Range(-1,2),Random.Range(4,6),Random.Range(6,15));
            coinRigid.AddTorque(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
            Count--;
        }
    }
}
