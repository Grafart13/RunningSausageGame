using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public float lookSenvitivity = 5f;
	public float xRotation;
	public float yRotation;
	public float currentXRotation;
	public float currentYRotation;
	public float xRotationVelocity;
	public float yRotationVelocity;
	public float lookSmoothDamp = 0.1f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        xRotation -= Input.GetAxis("Mouse Y") * lookSenvitivity;
        yRotation += Input.GetAxis("Mouse X") * lookSenvitivity;
        
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationVelocity, lookSmoothDamp);
        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationVelocity, lookSmoothDamp);
        //transform.rotation = Quaternion.Euler(currentXRotation, currentYRotation, 0);
    }
}
