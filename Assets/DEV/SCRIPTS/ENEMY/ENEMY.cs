using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ENEMY : MonoBehaviour
{
    [System.Serializable]
    public class Components
    {
        public Rigidbody Rigidbody;
        public Collider Collider;
        public Animator Animator;
        public SkinnedMeshRenderer Renderer;
        public EnemyAnim EnemyAnim;
        public EnemyColl EnemyColl;
        public EnemyMove EnemyMove;
        public EnemyRotate EnemyRotate;
        public HealthPanel HealthPanel;
    }
    public Components components;

    [System.Serializable]
    public class Values
    {
        public float MoveSpeed;
        public float RotateSpeed;
        public float PlayerRadarRadius;
    }
    public Values values;

    
    [HideInInspector] public Transform Target;
    [HideInInspector] public bool IsAlive = true;
    public enum State{idle,run,death}
    public State state = State.idle;
    public GameObject body;
    private Rigidbody[] BodyRigidies;
    private Vector3 DefaultScale;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        BodyRigidies = GetComponentsInChildren<Rigidbody>();
        DefaultScale = transform.localScale;
        transform.localScale = DefaultScale / 10f;
    }

    public void BornOP()
    {
        transform.DOScale(DefaultScale,1f).SetEase(Ease.OutElastic).OnComplete( () => {
            components.Rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
        });
    }
    public void ChangeState(State state)
    {
        this.state = state;
    }

    public void HealthControl()
    {
        if(components.HealthPanel.health <= 0 && IsAlive)
        {
            DeathOP();
        }
    }

    void DeathOP()
    {
        if (!IsAlive)
            return;

        IsAlive = false;
        components.EnemyMove.enabled   = false;
        components.EnemyAnim.enabled   = false;
        components.EnemyColl.enabled   = false;
        components.EnemyRotate.enabled = false; 
        CoinSpawner.Instance.CoinSpawn(transform,100,Vector3.up);
        RagdoolActiveOP();
        transform.DOScale(Vector3.zero,1f).SetDelay(1.5f).OnComplete( () => {
            Destroy(gameObject);
        });
    }

    void RagdoolActiveOP()
    {
        components.Animator.enabled = false;
        components.Renderer.material.color = Color.black;
    }
}
