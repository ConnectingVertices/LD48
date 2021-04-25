using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform droid;

    private Vector3 temp;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        temp = new Vector3(droid.position.x, Mathf.Min(droid.position.y + 4, 15), 15);

        transform.position = Vector3.SmoothDamp(transform.position, temp, ref velocity, 0.3f);


       

    }
}
