using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotat_e : MonoBehaviour
{

    [SerializeField]
    internal Transform source;
    [SerializeField]
    internal Camera cam;

    private float rotation_timer = 0.00f;

    private Transform facing;
    // Start is called before the first frame update
    void Start()
    {
        facing = source.transform.Find("Facing");
    }

    // Update is called once per frame
    void Update()
    {
        rotation_timer -= Time.deltaTime;
        float angle = Mathf.Atan2(facing.position.y, facing.position.x) * Mathf.Rad2Deg - 90;
        gameObject.GetComponent<Transform>().position = source.position + facing.position;
        if (rotation_timer <= 0)
        {
            gameObject.GetComponent<Transform>().eulerAngles = Vector3.forward * angle;
            rotation_timer = 0.1f;
        }
        
    }
}
