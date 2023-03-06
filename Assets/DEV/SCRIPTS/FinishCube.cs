using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishCube : MonoBehaviour
{
    TextMeshPro Text;
    public int Health;
    public bool x;
    private void Awake()
    {
        Text = GetComponentInChildren<TextMeshPro>();
        Text.text = Health.ToString();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeHitOP();
            Destroy(other.gameObject);
        }
    }

    private void TakeHitOP()
    {
        if (Health == 0) return;

        Health--;
        Text.text = Health.ToString();
        if(Health <= 0)
        {
            BroadcastMessage("Explode");
            Destroy(gameObject);
        }
    }
}
