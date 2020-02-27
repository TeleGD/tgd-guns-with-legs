using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blower : MonoBehaviour
{
    private bool activated;
    private float waitTime;
    public float limitTime=200;
    public float activatedTime = 100;
    public Vector3 force;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        waitTime = 0;
    
    }

    // Update is called once per frame
    void Update()
    {
        
        if (waitTime >= limitTime+activatedTime)
        {
            activated = false;
            waitTime = 0;

        }else if (waitTime >= limitTime)
        {
            activated = true;
        }
        waitTime += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {

        if (activated)
        {

            other.GetComponent<PlayerController>().setExternalForce(force);
            activated = false;
        }
    }
}
