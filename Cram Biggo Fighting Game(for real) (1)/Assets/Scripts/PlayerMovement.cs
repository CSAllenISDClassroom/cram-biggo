using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Moves[] moves;
    public Transform[] targets;
    public Rigidbody rb;
    public CharacterController cc;
    public KeyCode up;
    public KeyCode down;
    public KeyCode right;
    public KeyCode left;
    public KeyCode jump;
    public KeyCode attack;
    public KeyCode special;
    public float speed;
    public int jumps;
    public float gravity;
    public float jumpForce;
    public Animator animator;
    bool goinU;
    bool goinD;
    bool goinR;
    bool goinL;
    public bool jumpin;
    public bool attackin;
    bool specialin;
    // Update is called once per frame
    void LockOnTarget(Transform target)
    {

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * speed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
    void Update()
    { 
        goinU = Input.GetKey(up);
        goinD = Input.GetKey(down);
        goinR = Input.GetKey(right);
        goinL = Input.GetKey(left);
        jumpin = Input.GetKeyDown(jump);
        attackin = Input.GetKey(attack);
        specialin = Input.GetKey(special);
        if (attackin || specialin)
        {
            animator.SetBool("Running", false);
            int type = 0;
            if (specialin)
            {
                type = 1;
            }
            if (goinU)
            {
                Debug.Log(type);
                moves[type].moves[0].activate(1);
            }
            else if (goinD)
            {
                Debug.Log(type);
                moves[type].moves[1].activate(1);
            }
            else if (goinR)
            {
                Debug.Log(type);
                moves[type].moves[2].activate(1);
            }
            else if (goinL)
            {
                Debug.Log(type);
                moves[type].moves[2].activate(-1);
            }
            else
            {
                Debug.Log(type);
                moves[type].moves[3].activate(1);
            }
        }
        else
        {
            animator.SetBool("Running", true);
            if (goinR)
            {
                transform.rotation = Quaternion.Euler(0f, 180f - transform.rotation.x, 0f);
                Vector3 moveDirection = new Vector3(speed, rb.velocity.y, 0.0f);
                rb.velocity = moveDirection;
            }
            if (goinL)
            {
                transform.rotation = Quaternion.Euler(0f, 0f - transform.rotation.x, 0f);
                Vector3 moveDirection = new Vector3(-speed, rb.velocity.y, 0.0f);
                rb.velocity = (moveDirection);
            }
            if (jumpin)
            {
                Vector3 moveDirection = new Vector3(0.0f, jumpForce, 0.0f);
                if (jumps > 0)
                {
                    rb.AddForce(moveDirection);
                    jumps--;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        jumps = 3;
    }
}