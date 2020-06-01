using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    float speed = 10.0f;
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                                       0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        }

        else if (Input.GetAxis("Mouse X") < 0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                                       0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        }

        transform.position = player.transform.position + offset;
        //transform. = player.transform.position + offset;
        //   transform.Rotate(Input.GetAxis("Horizontal") * 3.0f, -Input.GetAxis("Vertical") * 2.0f, Input.GetAxis("Horizontal") * 2.0f);
    }
}

