using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour , IPointerDownHandler, IPointerUpHandler,  IDragHandler
{
    RectTransform m_rtBack;
    RectTransform m_rtJoystick;

    Transform Cube;
    float m_Radius;
    [SerializeField] float m_Speed = 5.0f;

    Vector3 m_VecMove;
    bool m_bTouch = false;

    void Start()
    {
        m_rtBack = transform.Find ("Joystick_BG").GetComponent<RectTransform>();
        m_rtJoystick = transform.Find ("Joystick_BG/Handle").GetComponent<RectTransform>();

        Cube = GameObject.Find("Player").transform;

        m_Radius = m_rtBack.rect.width * 0.5f; 
    }

    void Update()
    {
        if (m_bTouch) 
        {
            Cube.position += m_VecMove;
        }
    }

    void OnTouch(Vector2 vecTouch)
    {
        //  Debug.Log("Touch position "+vecTouch.x +" "+vecTouch.y);
        //Debug.Break();
        Vector2 vec = new Vector2(vecTouch.x - m_rtBack.position.x,vecTouch.y - m_rtBack.position.y);
        
        //dam bao gia tri Vec khong vuot qua Radius
        vec = Vector2.ClampMagnitude(vec, m_Radius);
        m_rtJoystick.localPosition = vec;

        //di chuyen nen can dieu khien theo ti le khoang cach cua can dieu khien
        float fSqr = (m_rtBack.position - m_rtJoystick.position).sqrMagnitude / (m_Radius * m_Radius);
        
        //chuan hoa vi tri cam ung
        Vector2 vecNormal = vec.normalized;

        m_VecMove = new Vector3(vecNormal.x * m_Speed * Time.deltaTime * fSqr, 0f, vecNormal.y * m_Speed * Time.deltaTime * fSqr);
        Cube.eulerAngles = new Vector3(0f, Mathf.Atan2(vecNormal.x, vecNormal.y) * Mathf.Rad2Deg, 0f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        m_bTouch = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        m_bTouch= true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //tro ve vi tri ban dau 
        m_rtJoystick.localPosition = Vector3.zero;
        m_bTouch= false;
    }

}





////set it parent to the main canvas
//m_rtJoystick.transform.parent = GetComponent("Canvas").transform;
////convert touch position to localposition reletive to canvas
//Vector2 localPos;
//RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent("Canva"), , null, out localPos);
////set position on canvas
//m_rtJoystick.transform.localPosition = localPos;