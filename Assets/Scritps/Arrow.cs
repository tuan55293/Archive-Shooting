using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    bool m_isFiring = false;
    Rigidbody2D m_rb;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (m_isFiring)
        {
            Vector2 vec = m_rb.velocity;
            float alpha = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, alpha);
        }
    }

    public void Fire(float force)
    {
        if (m_rb == null) return;
        m_rb.isKinematic = false;
        transform.parent = null;
        m_isFiring = true;

        m_rb.AddRelativeForce(new Vector2(force, 0),ForceMode2D.Force);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TargetController tg = collision.GetComponent<TargetController>();

        if (collision.gameObject.CompareTag("apple"))
        {
            var c2d = collision.GetComponent<Collider2D>();
            if (c2d)
            {
                c2d.enabled = false;
            }
            collision.transform.SetParent(transform);
        }
        else if (collision.gameObject.CompareTag("Head"))
        {
            //game over;
        }
        if (tg)
        {
            tg.Fall();
        }
    }
}
