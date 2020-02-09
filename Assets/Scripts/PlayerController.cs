using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerID;
    private Rigidbody rb;
    private Animator anim;
    private float speed = 5;

    public GameObject bulletPrefab;
    public Transform muzzle;

    public float reloadTime = 0.5f;
    private float nextFireTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal" + playerID) * speed, 0, Input.GetAxis("Vertical" + playerID) * speed);
        rb.velocity = dir;
        float actualSpeed = dir.magnitude;
        if(actualSpeed > speed * 0.25f)
        {
            Quaternion targetRot = Quaternion.Euler(0, Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, Time.deltaTime * 360);
        }

        anim.SetFloat("speed", actualSpeed);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire" + playerID) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + reloadTime;
            Instantiate(bulletPrefab, muzzle.position, Quaternion.Euler(0, transform.eulerAngles.y, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            GameManager.instance.EndRound();
            gameObject.SetActive(false);
        }
    }
}
