using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    internal Transform toFollow;
    [SerializeField]
    internal float leashRange = 3.0f;

    float switching = 0f;
    float timetoswitch = 1.5f;
    // Update is called once per frame
    void Update()
    {
        Vector3 location = new Vector3(toFollow.position.x, toFollow.position.y, 0);
        if ((location - new Vector3(0, 0, 0)).magnitude < leashRange && switching<=0) 
        {
            gameObject.GetComponent<Transform>().position = new Vector3(location.x, location.y, -10);
        }
        else
        {
            gameObject.GetComponent<Transform>().position = new Vector3((location.normalized * leashRange).x, (location.normalized * leashRange).y,-10);
        }
    }
}
