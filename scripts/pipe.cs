using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class pipe : MonoBehaviour
{
    public float speed;
    public float restartPos;
    public float startPos;
    public float maxTop, maxBottom;

    // Start is called before the first frame update
    void Start()
    {
        var pos = transform.position;
        pos.y = Random.Range(maxTop, maxBottom);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.x -= speed * Time.deltaTime;
        if (pos.x < restartPos)
        {
            pos.x = startPos;
            pos.y = Random.Range(maxTop, maxBottom);

        }

        transform.position = pos;
    }
}
