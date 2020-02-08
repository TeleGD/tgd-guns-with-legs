using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConstrainer : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public float xFactor = 0.2f;
    public float yFactor = 0.1f;
    public float offset = 4f;

    public static float angleDeg = 70;
    private float angleRad = angleDeg * Mathf.PI / 180;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 focusPoint = getFocusPoint();
        Vector3 directorAxis = new Vector3(0, Mathf.Sin(angleRad), -Mathf.Cos(angleRad));

        transform.position = newCameraPos(focusPoint, directorAxis);
    }


    Vector3 newCameraPos(Vector3 focusPoint,Vector3 directorAxis)
    {
        Vector3 v = player1.transform.position - player2.transform.position;
        return focusPoint + directorAxis* offset * (1 + xFactor* Mathf.Abs(v.x) + yFactor* Mathf.Abs(v.z));
    }

    Vector3 getFocusPoint()
    {
        return (player1.transform.position + player2.transform.position) / 2;
    }


    
}
