using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    [Header("Speeds")]
    public float zSpeed;
    public float xSpeed;

    [Header("Clamp")]
    public float xMin;
    public float xMax;

    [Header("Sensitivity"), Range(1,10)]
    public float xSensitivity;

    Vector3 pos;
    float DefaultYaxis;
    public Ease ease;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        DefaultYaxis = pos.y;
        yMoveOP();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        MoveOP();
    }

    void MoveOP()
    {
        if (!GameManager.Instance.GameStart)
            return;

        pos.z = transform.position.z;
        pos.y = transform.position.y;
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 delta = touch.deltaPosition;
            pos.x += (delta.x * Time.fixedDeltaTime) * xSensitivity;
            pos.x = Mathf.Clamp(pos.x, xMin, xMax);
        }
        transform.position = Vector3.Lerp(transform.position, pos , xSpeed * Time.fixedDeltaTime);

        if (GameManager.Instance.GameStart)
        {
            transform.position += Vector3.forward * zSpeed * Time.fixedDeltaTime;
        }
    }

    void yMoveOP()
    {
        transform.DOMoveY(DefaultYaxis, 0.5f).SetEase(ease).OnComplete(() => {
            transform.DOMoveY(DefaultYaxis + 0.5f, 0.5f).SetEase(ease).OnComplete( () => {
                yMoveOP();
            });
        });
    }

    public void FinishPhaseActiveOP()
    {
        int childCount = GameObject.FindGameObjectWithTag("Finish").transform.childCount;
        Transform pos = GameObject.FindGameObjectWithTag("Finish").transform.GetChild(childCount-1).transform;
        transform.DOMove(pos.position,2f);
    }
}
