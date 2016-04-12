using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

    public GameObject camera01;

    public float force;
    public float xForce;
    public float yForce;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0, camera01.GetComponent<MouseLook>().currentYRotation, 0);

        xForce = Input.GetAxis("Horizontal") * force;
        yForce = Input.GetAxis("Vertical") * force;
        Debug.Log(xForce);

        transform.Translate(new Vector3(xForce, 0, yForce));
    }
}
