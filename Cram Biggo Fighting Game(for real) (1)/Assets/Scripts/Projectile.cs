using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Hitboxes
{
    public float speed;
    public Rigidbody rb;
    private Vector3 direction;
    public float moveSpeed;
    public static float GetAngle(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
        {
            n += 360;
        }
        return n;
    }
    public void make(Vector3 direction)
    {
        this.direction = direction;
        transform.eulerAngles = new Vector3(GetAngle(direction), 0, 0);
        Destroy(gameObject, 10f);
    }

    public override void OnHit(Hurtboxes h)
    {
        h.health.percent += fDamage;
        Debug.Log(v3Knockback * (1 + h.health.percent / 100));
        h.rb.AddForce(v3Knockback * (1 + h.health.percent / 100));
        Destroy(this.gameObject);
    }
    void Update()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
