using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

    float m_curSpeed;
    bool m_isFalling;

    Rigidbody2D m_rb;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        m_curSpeed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        if(m_rb && !m_isFalling)
        {
            m_rb.velocity = Vector2.down * m_curSpeed; 
        }
    }

    public void Fall()
    {
        m_isFalling = true;
        if (m_rb)
        {
            m_rb.isKinematic = false;
            m_rb.velocity = Vector2.down * 3f;
        }
    }
}
