using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionControler : MonoBehaviour
{
    public ParticleSystem particles;
    public bool disableOnImpact = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            if(disableOnImpact)
                gameObject.SetActive(false);
        }
    }
}