using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitboxes : MonoBehaviour
{
    public float fDamage = 20;
    public Vector3 v3Knockback = new Vector3(0, 5, 15);

    public LayerMask layerMask;

    /*private void OnTriggerEnter(Collider other)
    {
        if (layerMask == (layerMask | (1 << other.transform.gameObject.layer)))
        {
            Hurtboxes h = other.GetComponent<Hurtboxes>();
            if (h != null)
            {
                OnHit(h);
            }
        }
    }
    */
    public virtual void OnHit(Hurtboxes h)
    {
        h.health.percent += fDamage;
        Debug.Log(v3Knockback * (1 + h.health.percent / 100));
        h.rb.AddForce(v3Knockback*(1 + h.health.percent/100));
        //Destroy(this.gameObject);
    }
}