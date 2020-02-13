using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableWeapon : MonoBehaviour
{
    public int weaponId;
    private bool canPickup = true;

    private void OnTriggerEnter(Collider other)
    {
        if(canPickup && other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().SetWeapon(weaponId);
            StartCoroutine(PickupCooldown());
        }
    }

    private IEnumerator PickupCooldown()
    {
        canPickup = false;
        transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(10);
        canPickup = true;
        transform.GetChild(0).gameObject.SetActive(true);

    }

    private void Update()
    {
        if(canPickup)
        {
            transform.GetChild(0).Rotate(0, Time.deltaTime * 90, 0);
            transform.GetChild(0).localPosition = Vector3.up * (1 + Mathf.Sin(Time.time) * 0.5f);
        }
    }
}
