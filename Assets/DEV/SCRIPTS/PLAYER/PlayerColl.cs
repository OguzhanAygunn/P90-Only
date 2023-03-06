using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerColl : MonoBehaviour
{
    [Range(0.1f,10)]
    public float WallRayDistance,CoinRayDistance;
    public GameObject DeathEffect;
    [SerializeField] private LayerMask CoinLayer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RayOP();
    }

    void RayOP()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, WallRayDistance))
        {
            if (hit.collider.GetComponent<DOOR>())
            {
                DOOR door = hit.collider.GetComponent<DOOR>();
                door.CollOP();
            }
        }

        Collider[] Collider = Physics.OverlapSphere(transform.position, CoinRayDistance, CoinLayer);
        if (Collider.Length > 0)
        {
            foreach(Collider obj in Collider)
            {
                if (!obj) return;

                Coin Coin = obj.GetComponent<Coin>();
                Coin.ToCoinPanel();
            }
        }
    }

    void DeathOP()
    {
        HealthPanel hp = GetComponent<HealthPanel>();
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        hp.TakeHitOP(1000);
        GetComponent<Collider>().enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Enemy")
        {
            DeathOP();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.Instance.FinishPhase = true;
        }
    }
}
