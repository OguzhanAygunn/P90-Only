using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Barrier : MonoBehaviour
{
    Transform PlayerPos;
    Vector3 defaultScale;
    float Distance = 35f;
    bool active;
    MeshRenderer Renderer;
    // Start is called before the first frame update
    private void Awake()
    {
        defaultScale = transform.localScale;
        Renderer = transform.GetChild(0).GetComponent<MeshRenderer>();
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        transform.localScale = Vector3.zero;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DistanceOP();
    }

    void DistanceOP()
    {
        if (active || !PlayerPos)
            return;

        if(Vector3.Distance(transform.position,PlayerPos.position) < Distance)
        {
            active = true;
            transform.DOScale(defaultScale,0.5f);
            ColorOP();
        }
    }

    void ColorOP()
    {
        Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Renderer.material.DOColor(randomColor, 0.4f).OnComplete( () => {
            ColorOP();
        });
    }
}
