using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    ENEMY Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<ENEMY>();
    }

    private void FixedUpdate()
    {
        if(Enemy.Target)
        MoveOP();
    }

    void MoveOP()
    {
        if(Enemy.state == ENEMY.State.run)
        {
            float speed = Enemy.values.MoveSpeed;
            Transform target = Enemy.Target;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        }
    }
}
