using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    Transform CoinPanelPos;
    private void Awake() => CoinPanelPos = Camera.main.gameObject.transform.GetChild(0).transform;
    public void ToCoinPanel()
    {
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<Collider>());

        transform.parent = CoinPanelPos;
        transform.DOScale(Vector3.zero,1f).SetEase(Ease.InCubic);
        transform.DOLocalMove(Vector3.zero, 1).OnComplete(() => {
            DATAOP.CoinCountUpdate(1);
            UIManager.Instance.CoinPanelScaleEffectOP();
            Destroy(gameObject);
        });
    }
}
