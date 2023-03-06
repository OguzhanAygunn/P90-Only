using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerRotate : MonoBehaviour
{
    [Header("Clamp")]
    public float zMin;
    public float zMax;
    [Header("Speed")]
    public float zRotSpeed;
    [Header("Sensitivity"), Range(1,10)]
    public float zSens;

    Vector3 rot,defaultRot;
    // Start is called before the first frame update
    void Start()
    {
        rot = transform.eulerAngles;
        defaultRot = rot;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        RotateOP();
    }

    void RotateOP()
    {
        if (GameManager.Instance.FinishPhase)
            return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 delta = (touch.deltaPosition * Time.fixedDeltaTime) * (zSens);
            rot.z += -delta.x;
            rot.z = Mathf.Clamp(rot.z,zMin,zMax);
        }
        else
        {
            rot.z = defaultRot.z;
        }
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles,rot,zRotSpeed*Time.fixedDeltaTime);
    }

    public void FinishPhaseOP()
    {
        transform.DORotate(defaultRot,1f);
    }
}
