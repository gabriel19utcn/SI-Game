using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("plane script added to " + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Input.GetAxis("Verical"), 0.0f , Input.GetAxis("Horizontal"));
    }
}
