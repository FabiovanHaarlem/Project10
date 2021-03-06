﻿using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField]
    private Beverages m_Beverage;
    private ObjectPool m_ObjectPool;
    [SerializeField]
    private Material m_WaterColor;
    [SerializeField]
    private Transform m_BottleOpening;
    [SerializeField]
    private Transform m_WaterBallTarget;
    [SerializeField]
    private Renderer m_Renderer;

    private Quaternion m_DefaultRotation;
    private Vector3 m_DefaultPosition;

    private float m_MinTippingPoint;
    private float m_MaxTippingPoint;

    private float m_PourSpeed;

    private void Awake()
    {
        m_MinTippingPoint = 90f;
        m_MaxTippingPoint = 270f;
        m_PourSpeed = 0.015f;
        m_WaterBallTarget.transform.position = new Vector3(m_BottleOpening.position.x, m_BottleOpening.position.y + 0.3f, m_BottleOpening.position.z);
        m_DefaultPosition = transform.position;
        m_DefaultRotation = transform.rotation;
    }

    private void Start()
    {
        m_ObjectPool = GameObject.Find("_System").GetComponent<ObjectPool>();
        if (m_Renderer != null)
        {
            m_Renderer.material.SetFloat("_FillAmount", 0.45f);
            m_Renderer.material.SetColor("_TopColor", m_WaterColor.color);
        }
    }

    private void Update()
    {
        CheckIfTipping();

        if (!gameObject.activeInHierarchy)
        {
            RespawnBottle();
        }
    }

    private void RespawnBottle()
    {
        transform.position = m_DefaultPosition;
        transform.rotation = m_DefaultRotation;
    }

    private void CheckIfTipping()
    {
        Vector3 angle = transform.localEulerAngles;
        m_PourSpeed -= Time.deltaTime;

        if (Vector3.Dot(transform.up, Vector3.down) > 0)
        {
            if (m_PourSpeed <= 0f)
            {
                Pour();
                m_PourSpeed = 0.015f;
            }
        }
    }

    private void Pour()
    {
        WaterBall waterBall =  m_ObjectPool.GetWaterBall();
        waterBall.Activate(m_BottleOpening.position, transform.up, m_Beverage, m_WaterColor);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DisableCollider"))
        {
            RespawnBottle();
        }
    }
}
