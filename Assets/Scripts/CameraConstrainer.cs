using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConstrainer : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public float xFactor = 0.5f;
    public float yFactor = 0.9f;

    private float shakeAmount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 focusPoint = GetFocusPoint();

        Vector3 v = player1.transform.position - player2.transform.position;
        float dist = v.magnitude;

        float angleDeg = Mathf.Lerp(40, 70, (dist - 4) * 0.15f);
        float angleRad = angleDeg * Mathf.PI / 180;
        Vector3 directorAxis = new Vector3(0, Mathf.Sin(angleRad), -Mathf.Cos(angleRad));

        Vector3 targetPos = focusPoint + directorAxis * (4 + Mathf.Max(xFactor * Mathf.Abs(v.x), yFactor * Mathf.Abs(v.z)));

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 4);
        float newAngle = Mathf.Lerp(transform.eulerAngles.x, angleDeg, Time.deltaTime * 4);
        transform.eulerAngles = new Vector3(newAngle, 0, 0);

        if (shakeAmount > 0.1f)
        { 
            transform.eulerAngles += Random.insideUnitSphere * shakeAmount * 10;
            shakeAmount -= Time.deltaTime;
        }
    }

    Vector3 GetFocusPoint()
    {
        return (player1.transform.position + player2.transform.position) / 2;
    }

    public void ShakeScreen()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float timer = 1;
        while(timer > 0.1f)
        {
            shakeAmount = timer * timer;
            timer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        shakeAmount = 0;
    }
}
