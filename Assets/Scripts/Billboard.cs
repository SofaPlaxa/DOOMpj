using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Transform cachedCamera;
    // Start is called before the first frame update
    void Start()
    {
        cachedCamera = Camera.main.transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(cachedCamera.position.x, transform.position.y, cachedCamera.position.z));
    }
}
