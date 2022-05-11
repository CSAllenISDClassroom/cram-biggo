using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitboxes : Hitboxes
{
    public GameObject actualHb;
    public bool active;
    public Vector3 movement;
    public void OnTriggerEnter(Collider other)
    {
        if (layerMask == (layerMask | (1 << other.transform.gameObject.layer)))
        {
            if (active)
            {
                Hurtboxes h = other.GetComponent<Hurtboxes>();
                if (h != null)
                {
                    h.health.percent += fDamage;
                    Debug.Log(v3Knockback * (1 + h.health.percent / 100));
                    h.rb.AddForce(v3Knockback * (1 + h.health.percent / 100));
                }
            }
        }
    }
    public void Setactive(float damage, Vector3 v)
    {
        actualHb.SetActive(true);
        active = true;
        fDamage = damage;
        v3Knockback = v;
    }
    public void DeActivate()
    {
        actualHb.SetActive(false);
        active = false;
    }
}
