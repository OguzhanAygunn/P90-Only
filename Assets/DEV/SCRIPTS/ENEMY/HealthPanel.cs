using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class HealthPanel : MonoBehaviour
{
    public TextMeshPro Text;
    public int health;
    public Transform HealthPanelTrs;
    public GameObject Coin;
    int maxHealth;
    Vector3 HealthPanelScale;
    // Start is called before the first frame update
    void Start()
    {
        if(HealthPanelTrs)
        HealthPanelScale = HealthPanelTrs.localScale;
        maxHealth = health;
        Text = GetComponentInChildren<TextMeshPro>();
        if(Text)
        Text.text = health.ToString();
    }

    public void TakeHitOP(int hit = 1)
    {
        if (health <= 0)
            return;


        if (Text && HealthPanelTrs)
        {
            Text.text = health.ToString();
            HealthPanelTrs.DOScale(HealthPanelScale * 1.2f, 0.3f).OnComplete(() => {
                HealthPanelTrs.DOScale(HealthPanelScale, 0.3f);
            });
        }
        health -= hit;
        health = Mathf.Clamp(health,0,maxHealth);
        if(health == 0)
        {
            if(HealthPanelTrs)
            Destroy(HealthPanelTrs.gameObject);


            if (GetComponentInChildren<MeshExploder>())
            {
                BroadcastMessage("Explode");
                Destroy(gameObject);
            }

            if (gameObject.tag == "Player")
                GameManager.Instance.GameLoseOP();

            Destroy(this);
        }
    }
}
