using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    Rigidbody2D m_Rigidbody;
    public float m_Speed;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
            m_Rigidbody.velocity = transform.up * m_Speed;
    }
}
