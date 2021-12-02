using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceLightScript : MonoBehaviour
{
    public float interval = 0.1f;
    public float minAngle = 136;
    public float maxAngle = 137;
    private float timeLeft;

    Light lt;

    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();

        timeLeft = interval;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0.0)
        {
            // time to change!
            timeLeft = interval;
            lt.spotAngle = Random.Range(minAngle, maxAngle);
        }
    }
    //from this tutorial https://docs.unity3d.com/ScriptReference/Light-spotAngle.html
}
