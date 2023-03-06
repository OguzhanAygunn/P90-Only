using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour
{
    private Vector3 DefaultPos;
    private Vector3 DefaultRot;
    private Vector3 DefaultScale;
    private Rigidbody Rigidbody;
    // Start is called before the first frame update

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.constraints = RigidbodyConstraints.FreezeAll;

        DefaultPos = transform.position;
        DefaultRot = transform.eulerAngles;
        DefaultScale = transform.localScale;

        transform.position += Vector3.up * Random.Range(6, 12);
        transform.eulerAngles += Vector3.one * Random.Range(0, 360);
        transform.localScale = Vector3.zero;
    }

    public void ToDefaultTransformValues()
    {
        transform.DOMove(DefaultPos,1f);
        transform.DORotate(DefaultRot, 1f);
        transform.DOScale(DefaultScale, 1f).OnComplete( () => Rigidbody.constraints = RigidbodyConstraints.None);
    }
}
