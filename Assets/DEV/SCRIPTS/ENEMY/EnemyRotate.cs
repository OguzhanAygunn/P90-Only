using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    ENEMY Enemy;
    GameObject Body;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<ENEMY>();
        Body = Enemy.body;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Enemy.Target)
        RotateOP();
    }

    void RotateOP()
    {
        if(Enemy.state == ENEMY.State.run)
        {

            Body.transform.rotation = Quaternion.Slerp(Body.transform.rotation,
               Quaternion.LookRotation(Enemy.Target.position - Body.transform.position), Enemy.values.RotateSpeed);

            Vector3 rot = Body.transform.eulerAngles;
            rot.x = 0;
            rot.z = 0;
            Body.transform.eulerAngles = rot;
        }
    }
}
