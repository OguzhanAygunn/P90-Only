using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] UIStartPanel StartPanel;
    [SerializeField] UICoinPanel  CoinPanel;
    [SerializeField] UIShopPanel  ShopPanel;
    [SerializeField] UILosePanel  LosePanel;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    public void ShopPanelSlotsDisableOP()
    {
        ShopPanel.DisableStlotsOP();
    }

    public void LosePanelActive()
    {
        LosePanel.ActiveOP();
    }

    public void CoinPanelScaleEffectOP()
    {
        CoinPanel.ScaleEffectOP();
        CoinPanel.TextUpdate();
    }

}
