using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UIShopPanel : MonoBehaviour
{
    [SerializeField] GameObject[] Slots;
    // Start is called before the first frame update
    void Start()
    {
        var sequence = DOTween.Sequence();

        foreach(GameObject slot in Slots)
        {
            slot.transform.eulerAngles = Vector3.right * 90;
        }

        foreach(GameObject slot in Slots)
        {
            sequence.Append(slot.transform.DORotate(Vector3.zero,0.5f));
        }
    }

    public void DisableStlotsOP()
    {
        foreach(GameObject slot in Slots)
        {
            slot.transform.DORotate(Vector3.right * 90, 0.6f).OnComplete( () => gameObject.SetActive(false));
        }
    }
}
