using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPointer : MonoBehaviour
{
    public Camera sceneCamera;
    GameObject centerEye;
    private Vector3 targetPosition;
    private float step;
    // Start is called before the first frame update
    void Start()
    {
        centerEye = GameObject.Find("CenterEyeAnchor");
    }

    // Update is called once per frame
    void Update()
    {
        step = 5.0f * Time.deltaTime;
        targetPosition = sceneCamera.transform.position + sceneCamera.transform.forward * 0.07f;
        targetPosition.y = 0.07F;
        transform.position = Vector3.Lerp(transform.position, targetPosition, step);
    }
}








