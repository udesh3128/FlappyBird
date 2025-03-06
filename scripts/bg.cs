using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bg : MonoBehaviour
{
    public float speed;
    public float restartPos;
    public float startPos;
    public float maxTop, maxBottom;

    // Start is called before the first frame update
    void Start()
    {
        var pos = transform.localPosition;
        pos.y = Random.Range(maxTop, maxBottom);
        transform.localPosition = pos;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.localPosition;
        pos.x -= speed * Time.deltaTime;
        if (pos.x < restartPos)
        {
            pos.x = startPos;
            pos.y = Random.Range(maxTop, maxBottom);

        }

        transform.localPosition = pos;
    }
}
