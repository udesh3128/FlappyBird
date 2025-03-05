using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    public Transform target;
    Vector3 pos;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos.x = target.position.x + offset.x;
        transform.position = pos;
    }
}
