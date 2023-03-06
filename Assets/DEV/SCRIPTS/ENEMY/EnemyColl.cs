using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColl : MonoBehaviour
{
    Transform PlayerPos;
    ENEMY Enemy;
    bool RadarActive = true;
    [SerializeField] GameObject BulletDestroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        Enemy = GetComponent<ENEMY>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        PlayerRadar();
    }

    void PlayerRadar()
    {
        if (!RadarActive || !PlayerPos)
            return;

        float radius = Enemy.values.PlayerRadarRadius;
        if (transform.position.z - radius < PlayerPos.position.z 
            &&Enemy.state == ENEMY.State.idle)
        {
            Enemy.ChangeState(ENEMY.State.run);
            Enemy.BornOP();
        }
    }

    void CollBullet(Transform BulletPos)
    {
        Instantiate(BulletDestroyEffect,BulletPos.position,Quaternion.identity);
        Destroy(BulletPos.gameObject);
        Enemy.components.HealthPanel.TakeHitOP();
        Enemy.HealthControl();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet") && Enemy.IsAlive)
            CollBullet(other.transform);
    }
}
