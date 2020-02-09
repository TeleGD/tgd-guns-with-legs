using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionControler : MonoBehaviour
{
    public ParticleSystem particles;
    public GameObject explosionDecal;
    public bool disableOnImpact = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Instantiate(particles, transform.position, Quaternion.identity);

            Vector3 decalPos = new Vector3(transform.position.x, 0.01f, transform.position.z);
            Quaternion decalRot = Quaternion.Euler(270, Random.Range(0, 360), 0);
            Instantiate(explosionDecal, decalPos, decalRot);
            Camera.main.GetComponent<CameraConstrainer>().ShakeScreen();

            if(disableOnImpact)
                gameObject.SetActive(false);
        }
    }
}