using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class UIStartPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Text;
    [SerializeField] Image Image;
    Vector3 defaultScale;
    // Start is called before the first frame update
    void Start()
    {
        defaultScale = transform.localScale;
        transform.localScale = Vector3.zero;

        transform.DOScale(defaultScale,1f).SetEase(Ease.OutElastic).SetDelay(1f).OnComplete( () => {
            Invoke("ScaleEffect", 0.2f);
        });
    }

    void ScaleEffect()
    {
        transform.DOScale(defaultScale / 1.2f, 0.25f).SetEase(Ease.Linear).OnComplete( () => {
            transform.DOScale(defaultScale, 0.25f).OnComplete( () => ScaleEffect());
        });
    }

    public void PressButton()
    {
        Color color = Text.color;
        color.a = 0;
        Text.DOColor(color,0.5f);
        color = Image.color;
        color.a = 0;
        Image.DOColor(color,0.5f).OnComplete( () => gameObject.SetActive(false));

        UIManager.Instance.ShopPanelSlotsDisableOP();
        GameManager.Instance.GameStart = true;
    }
}
