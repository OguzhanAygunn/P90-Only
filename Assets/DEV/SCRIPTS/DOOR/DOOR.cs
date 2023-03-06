using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class DOOR : MonoBehaviour
{
    TextMeshPro Text;
    [Range(10,90f)]
    public int Value;

    public bool IsLower;
    string s;
    MeshRenderer Renderer;

    public Color LowerColor, FasterColor;
    DoubleDoor DoubleDoor;

    Vector3 defaultPos;
    // Start is called before the first frame update
    void Start()
    {
        Renderer   = GetComponent<MeshRenderer>();
        Text       = GetComponentInChildren<TextMeshPro>();
        DoubleDoor = GetComponentInParent<DoubleDoor>();
        defaultPos = transform.position;

        s = "% " + Value.ToString();
        s += (IsLower) ? " Lower" : " Faster";
        Text.text = s;

        Renderer.material.color = (IsLower) ? LowerColor : FasterColor;
    }

    public void CollOP()
    {
        CAMERA.Instance.FieldOfViewEffect();
        PlayerShooter ps = FindObjectOfType<PlayerShooter>();
        float time = ps.BulletSpawnTime;
        float x = Value;
        x /= 100;
        time = (IsLower) ? time + (time * x) : time - (time * x);
        ps.BulletSpawnTime = time;

        DoubleDoor.DisableDoors();

    }

    public void DisableDoor()
    {
        defaultPos.y -= 5f;
        transform.DOMove(defaultPos, 1f).OnComplete( () => {
            Destroy(gameObject);
        });
    }
}
