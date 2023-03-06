using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloorFromCubes : MonoBehaviour
{
    Transform[] AllChild;
    Transform PlayerPos;

    List<Vector3> DefaultChildsPos    = new List<Vector3>();
    List<Vector3> DefaultChildsScale  = new List<Vector3>();
    List<Vector3> DefaultChildsRotate = new List<Vector3>();

    [SerializeField] private float Distance;
    public bool active;
    public Ease ease;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;

        AllChild = GetComponentsInChildren<Transform>();
        AllChild[0] = null;


        foreach(Transform pos in AllChild)
        {
            if (pos)
            {
                DefaultChildsPos.Add(pos.position);
                DefaultChildsScale.Add(pos.localScale);
                DefaultChildsRotate.Add(pos.eulerAngles);


                pos.localScale = Vector3.zero;
                pos.transform.position   += new Vector3(Random.Range(-5, 5), Random.Range(15, 25), Random.Range(4, 6));
                pos.transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            }
        }
    }
    private void FixedUpdate() => DistanceController();

    void DistanceController()
    {
        if (!PlayerPos)
            return;

        if(Vector3.Distance(transform.position,PlayerPos.position) < Distance)
        {
            StartCoroutine(nameof(ActiveOP));
        }
    }


    IEnumerator ActiveOP()
    {
        active = true;
        int index = 0;
        while (index < AllChild.Length-1)
        {
            Transform child = AllChild[index + 1];
            Vector3 Scale  = DefaultChildsScale[index];
            Vector3 Pos    = DefaultChildsPos[index];
            Vector3 Rotate = DefaultChildsRotate[index];

            child.DOScale(Scale,0.5f).SetEase(ease);
            child.DORotate(Rotate,0.5f).SetEase(ease);
            child.DOMove(Pos,0.5f).SetEase(ease);

            yield return new WaitForSeconds(0.02f);
            index++;
        }
        Destroy(this);
    }
}
