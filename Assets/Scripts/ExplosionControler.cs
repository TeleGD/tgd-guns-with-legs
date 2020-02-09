using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionControler : MonoBehaviour
{
    public ParticleSystem particles;
    public GameObject exploser;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(exploser.tag))
        {
            particles.transform.position = gameObject.transform.position;
            Instantiate(particles);

            gameObject.SetActive(false);
        }
    }
}