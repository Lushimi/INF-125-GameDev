using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : EntityControl
{
    [SerializeField]
    internal BossData Boss;

    // Start is called before the first frame update
    void Start()
    {
        Boss.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
