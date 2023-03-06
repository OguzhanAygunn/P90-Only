using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CAMERA : MonoBehaviour
{
    public static CAMERA Instance;

    public  Transform Target;
    public  Vector3 PosOffset;
    public  Vector3 RotateOffset;
    public  float FollowSpeed;
    public  float RotateSpeed;
    private float FieldOfView;
    private Camera Camera;
    private Vector3 FirstPos;
    private Transform AimPos;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        Camera = GetComponent<Camera>();
        FieldOfView = Camera.fieldOfView;
        FirstPos = transform.position;
        AimPos = null;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Target)
            return;

        FollowOP();
        RotateOP();
    }

    void FollowOP()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position + PosOffset, FollowSpeed);
    }

    void RotateOP()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((Target.position + RotateOffset) - transform.position), RotateSpeed * Time.deltaTime);
    }

    public void FieldOfViewEffect()
    {
        Camera.DOFieldOfView(FieldOfView * 1.5f, 1f).SetEase(Ease.OutElastic).OnComplete( () => {
            Camera.DOFieldOfView(FieldOfView, 1f).SetEase(Ease.Linear);
        });
    }

    public void FinishPhaseOP()
    {

    }
}
