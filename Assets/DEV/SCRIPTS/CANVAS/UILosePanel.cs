using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UILosePanel : MonoBehaviour
{
    Image Image;
    // Start is called before the first frame update
    void Start()
    {
        Image = GetComponentInChildren<Image>();
        Image.enabled = false;
    }

    public void ActiveOP()
    {
        Image.enabled = true;
        Color color = Image.color;
        color.a = 1;
        Image.DOColor(color,1f).SetDelay(1f).OnComplete( () => {
            LevelManager.Instance.RestartLevel();
        });
    }
}
