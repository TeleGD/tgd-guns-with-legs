using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public GameObject owner;
    public float speed = 10;

    public void SetOwner(GameObject newOwner)
    {
        owner = newOwner;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.transform.root.gameObject);
        if(!other.CompareTag("Bullet") && other.transform.root.gameObject != owner)
            Destroy(gameObject);
    }
}
