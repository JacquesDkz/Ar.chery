using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;


public class ArrowGenerator : MonoBehaviour
{
    [SerializeField] private GameManager m_GameManager;
    [SerializeField] private GameObject m_Prefab;
    [SerializeField] private int m_Speed;
    [SerializeField] private ARRaycastManager m_RaycastManager;
    private static bool m_Enabled;
    private static int m_Counter;
    private Transform m_CameraTransform;

    private void Awake()
    {
        m_Enabled = false;
        m_Counter = 0;
        m_CameraTransform = Camera.main.GetComponent<Transform>();
    }


    public void ToShoot(Vector2 screenPosition)
    {
        transform.position = new Vector3(screenPosition.x, screenPosition.y, m_CameraTransform.position.z);
        GameObject.Instantiate(m_Prefab, transform.position, m_CameraTransform.rotation);
        m_Counter++;
    }

    public void OnHit()
    {
        m_Counter--;
        m_GameManager.UpdateScore();
    }

    public int GetCounter()
    { return m_Counter; }

    public bool IsEnable()
    { return m_Enabled; }

    public void SetEnable(bool value)
        { m_Enabled = value; }

    public int GetSpeed()
        { return m_Speed; }
}
