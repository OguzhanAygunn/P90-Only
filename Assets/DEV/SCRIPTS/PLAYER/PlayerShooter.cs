using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerShooter : MonoBehaviour
{
    [Header("Bullet stats")]
    public GameObject   Bullet;
    public GameObject[] BulletEffects;
    public Transform    BulletSpawnPos;
    public float        BulletSpawnTime;
    public float        BulletPower;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(ShootOP));
    }

    void EffectSpawn()
    {
        int random = Random.Range(0, BulletEffects.Length);
        Instantiate(BulletEffects[random],BulletSpawnPos.position,Quaternion.identity);
    }

    void BulletSpawn()
    {
        Rigidbody BulletRigid = Instantiate(Bullet, BulletSpawnPos.position, Quaternion.identity).GetComponent<Rigidbody>();
        BulletRigid.velocity = Vector3.forward * BulletPower;
        Destroy(BulletRigid.gameObject,1);
    }

    IEnumerator ShootOP()
    {
        while (true)
        {
            if (GameManager.Instance.GameStart)
            {
                BulletSpawn();
                EffectSpawn();
            }
            yield return new WaitForSeconds(BulletSpawnTime);
        }
    }


}
