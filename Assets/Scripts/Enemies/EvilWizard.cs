using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizard : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        patrol();
    }
}
