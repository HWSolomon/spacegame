using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityAttractor : MonoBehaviour {

    public float gravity = -10;
    
    public void Attract (Transform body)
    {
        Vector2 gravityUp = (body.position - transform.position).normalized;
        Vector2 bodyUp = body.up;

        body.GetComponent<Rigidbody2D>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 500 * Time.deltaTime);
    }
}
