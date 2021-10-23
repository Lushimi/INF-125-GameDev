using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotat_e : MonoBehaviour
{

    [SerializeField]
    internal Transform source;
    [SerializeField]
    internal Camera cam;

    private Transform facing;
    // Start is called before the first frame update
    void Start()
    {
        facing = source.transform.Find("Facing");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Transform>().position = source.position + facing.position;
    }
}
