using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cumera : MonoBehaviour
{
    public Transform target;
    public float Y;
    public float xLimit;
    public float yLimit;

    private void Update()
    {
        if (target.position.x < xLimit)
        {
            transform.position = new Vector3(target.position.x, 0, -10);
        }
        else if(target.position.x > xLimit && target.position.y > yLimit)
        {       
            transform.position = new Vector3(target.position.x, Y, -10);
        }
    }
}
