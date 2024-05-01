using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //[SerializeField] int defaultMovementIncriment = 1;
    public Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = currentPos;
        if (transform.position.y > 4)
        {
            Vector3 vector3 = transform.position;
            vector3.y = -4.72f;
            transform.position = vector3;
        }
        else if (transform.position.y <= -4.7)
        {
            Vector3 vector3 = transform.position;
            vector3.y = 4.2f;
            transform.position = vector3;
        }
        if (transform.position.x >= 3.15)
        {
            Vector3 vector3 = transform.position;
            vector3.x = -7.65f;
            transform.position = vector3;
        }
        if (transform.position.x <= -7.65)
        {
            Vector3 vector3 = transform.position;
            vector3.x = 3.15f;
            transform.position = vector3;
        }

    }
}
