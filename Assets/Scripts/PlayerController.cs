using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerID;
    private Rigidbody rb;
    private Animator anim;
    private float speed = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal" + playerID) * speed, 0, Input.GetAxis("Vertical" + playerID) * speed);
        rb.velocity = dir;
        
        if(dir.sqrMagnitude > 1f)
        {
            Quaternion targetRot = Quaternion.Euler(0, Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg, 0);
            transform.rotation = targetRot;
        }

        anim.SetFloat("speed", dir.magnitude);
    }
}
