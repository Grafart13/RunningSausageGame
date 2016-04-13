using UnityEngine;
using System.Collections;

public class ThirdPersonCam : MonoBehaviour {
    private const float X_MIN_ANGLE = 0.0f;
    private const float X_MAX_ANGLE = 50.0f;

    public Transform lookAt;
    public Transform camTransorm;

    public Camera cam;

    public float distance = 10.0f;
    public float currentX = 0.0f;
    public float currentY = 0.0f;
    public float lookSenvitivity = 5f;


    // Use this for initialization
    void Start () {
        camTransorm = transform;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        currentX -= Input.GetAxis("Mouse Y") * lookSenvitivity;
        currentY += Input.GetAxis("Mouse X") * lookSenvitivity;
        currentX = Mathf.Clamp(currentX, X_MIN_ANGLE, X_MAX_ANGLE);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentX, currentY, 0);
        camTransorm.position = lookAt.position + rotation * dir;
        camTransorm.LookAt(lookAt.position);


    }
}
