using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerHitboxes[] hbs;
    public Animator animator;
    public string animationName;
    public float damage;
    public Vector3 trajectory;
    public Vector3 movement;
    public bool throwing;
    public Projectile proj;
    public Vector3 projDirect;
    // Start is called before the first frame update
    // Update is called once per frame
    public void activate(float direction)
    {
        animator.SetBool(animationName, true);
        Debug.Log(animator.GetBool(animationName));
        Vector3 tempM = new Vector3(movement.x * direction, movement.y, movement.z);
        rb.velocity = (tempM);
        foreach (PlayerHitboxes hb in hbs)
        {
            Vector3 temp = new Vector3(trajectory.x * direction, trajectory.y, trajectory.z);
            hb.Setactive(damage, temp);
        }
        StartCoroutine(DelayTillAnimation(animator.GetCurrentAnimatorStateInfo(0).length));
    }

    IEnumerator DelayTillAnimation(float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        foreach (PlayerHitboxes hb in hbs)
        {
            hb.DeActivate();
        }
        animator.SetBool(animationName, false);
        Debug.Log(animator.GetBool(animationName));
    }
}
