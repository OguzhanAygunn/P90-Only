using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    Animator animator;
    ENEMY Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<ENEMY>();
        animator = Enemy.components.Animator;
    }

    private void FixedUpdate()
    {
        BlendTreeOP();
    }

    void BlendTreeOP()
    {
        if (!Enemy.IsAlive)
            return;


        float blend = animator.GetFloat("Blend");
        float targetBlend = 0;
        switch (Enemy.state)
        {
            case ENEMY.State.idle:
                targetBlend = 0;
                break;
            case ENEMY.State.run:
                targetBlend = 1;
                break;
            case ENEMY.State.death:
                break;
        }
        blend = Mathf.MoveTowards(blend,targetBlend,Time.fixedDeltaTime);
        animator.SetFloat("Blend", blend);

    }
}
