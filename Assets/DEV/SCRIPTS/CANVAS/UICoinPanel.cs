using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UICoinPanel : MonoBehaviour
{
    Vector3 defaultScale;
    bool ScaleUP;
    Text text;
    // Start is called before the first frame update
    private void Awake()
    {
        text = GetComponentInChildren<Text>();
        defaultScale = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.DOScale(defaultScale,1f).SetEase(Ease.OutElastic);
        TextUpdate();
    }

    private void FixedUpdate()
    {
        ScaleOP();
    }

    void ScaleOP()
    {
        if (ScaleUP)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale,defaultScale*1.2f,Time.fixedDeltaTime);
            if(transform.localScale == defaultScale * 1.2f)
            {
                ScaleUP = false;
            }
        }
        else
        {
            if(transform.localScale != defaultScale)
            transform.localScale = Vector3.MoveTowards(transform.localScale, defaultScale, Time.fixedDeltaTime);
        }

    }

    public void ScaleEffectOP()
    {
        ScaleUP = true;
        TextUpdate();
    }

    public void TextUpdate()
    {
        text.text = DATAOP.CoinCountUpdate().ToString();
    }
}
