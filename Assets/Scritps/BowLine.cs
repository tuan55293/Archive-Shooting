using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowLine : MonoBehaviour
{
    public Transform startPos;
    public Transform arrowPos;
    public Transform endPos;
    public Material material;
    public Color color;

    LineRenderer m_line1;
    LineRenderer m_line2;

    GameObject m_obj1;
    GameObject m_obj2;

    private void Start()
    {
        m_obj1 = new GameObject();
        m_obj1.AddComponent<LineRenderer>();
        m_line1 = m_obj1.GetComponent<LineRenderer>();
        m_line1.startWidth = 0.02f;
        m_line1.endWidth = 0.02f;
        m_line1.material = material;
        m_line1.startColor = color;
        m_line1.endColor = color;
        m_obj1.name = "Line_01";

        m_obj2 = new GameObject();
        m_obj2.AddComponent<LineRenderer>();
        m_line2 = m_obj2.GetComponent<LineRenderer>();
        m_line2.startWidth = 0.02f;
        m_line2.endWidth = 0.02f;
        m_line2.material = material;
        m_line2.startColor = color;
        m_line2.endColor = color;
        m_obj2.name = "Line_02";

    }
    private void Update()
    {
        m_line1.SetPosition(0, startPos.position);
        m_line1.SetPosition(1, arrowPos.position);
        m_line2.SetPosition(0, arrowPos.position);
        m_line2.SetPosition(1, endPos.position); 
    }
}
