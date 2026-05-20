using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Target object position
    [Header("Target Object")]
    public Transform target;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //If target position on the y axis is greater
        //than the camera position
        if (target.position.y > transform.position.y)
        {
            //The camera will follow the position of the target
            transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
        }
    }
}