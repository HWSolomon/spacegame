using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityBody : MonoBehaviour {

    public FauxGravityAttractor attractor;
    private Transform myTransform;

    void Start()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        myTransform = transform;
    }

    void Update()
    {
        attractor.Attract(myTransform);
    }
}
