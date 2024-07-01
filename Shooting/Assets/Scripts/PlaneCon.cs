using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCon : MonoBehaviour
{
    public KeyCode m_PitchMinus = KeyCode.S,
        m_PitchPlus = KeyCode.W,
        m_YawPlus = KeyCode.A,
        m_YawMinu = KeyCode.D,
       m_RollPlus = KeyCode.Q,
       m_RollMinu = KeyCode.E,
       m_Move = KeyCode.Space,
       m_SpeedUp = KeyCode.PageUp,
       m_SpeedDown = KeyCode.PageDown;
    public float m_Speed = 10, m_maxSpeed = 200, m_ChangeStep = 10, m_RotateSpeed = 30;
    public bool m_IsMove = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (Input.GetKeyDown(m_Move))
        {

            m_IsMove = !m_IsMove;
        }
        if (m_IsMove)
        {
            Vector3 dir = Vector3.zero;
            //x축
            if (Input.GetKey(m_PitchPlus))
            {
                dir += Vector3.right ; ;
            }
            else if (Input.GetKey(m_PitchMinus))
            {
                dir += Vector3.left;
            }
            //y축
            if (Input.GetKey(m_YawPlus))
            {
                dir += Vector3.down; ;

            }
            else if (Input.GetKey(m_YawMinu))
            {
                dir += Vector3.up ; ;
            }
            //z축
            if (Input.GetKey(m_RollPlus))
            {
                dir += Vector3.forward; ;
            }
            else if (Input.GetKey(m_RollMinu))
            {
                dir += Vector3.back ; ;
            }
            //속도 증가
            if (Input.GetKeyDown(m_SpeedUp))
            {
                m_Speed += m_ChangeStep;
                if (m_Speed > m_maxSpeed)
                {
                    m_Speed = m_maxSpeed;
                }
            }
            else if (Input.GetKeyDown(m_SpeedDown))
            {
                m_Speed -= m_ChangeStep;
                if (m_Speed < 0)
                {
                    m_Speed = 10;
                }

            }
            transform.Rotate(dir * m_RotateSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * m_Speed/10 * Time.deltaTime);
        }

    }
}
