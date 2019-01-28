﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glas : MonoBehaviour
{
    [SerializeField]
    private ObjectPool m_ObjectPool;

    private List<AddOn> m_AddOns;
    //private List<GlasBeveragePiece> m_GlasContents;
    private Dictionary<Beverages, int> m_GlasContents;
    private List<GlasFeedback> m_GlasFeedback;
    private float m_ShotProgress;
    private Beverages m_LastBeverage;

    [SerializeField]
    private Transform m_MaxPoint;
    [SerializeField]
    private Transform m_MinPoint;

    private Vector3 m_DefaultPosition;
    private Quaternion m_DefaultRotation;

    private void Awake()
    {
        //m_GlasContents = new List<GlasBeveragePiece>();
        m_GlasContents = new Dictionary<Beverages, int>();
        m_GlasFeedback = new List<GlasFeedback>();
        m_DefaultPosition = transform.position;
        m_DefaultRotation = transform.rotation;
    }

    private void Start()
    {
        m_ObjectPool = GameObject.Find("_System").GetComponent<ObjectPool>();
    }

    public Dictionary<Beverages, int> GetGlasContents()
    {
        return m_GlasContents;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WaterBall"))
        {
            AddBeverage(other);
        }

        if (other.CompareTag("DisableCollider"))
        {
            ResetGlas();
        }
    }

    public void ResetGlas()
    {
        for (int i = 0; i < m_GlasFeedback.Count; i++)
        {
            m_GlasFeedback[i].Deactivate();
        }

        m_GlasContents.Clear();
        m_ShotProgress = 0.0f;
        transform.position = m_DefaultPosition;
        transform.rotation = m_DefaultRotation;
    }

    private void AddBeverage(Collider other)
    {
        WaterBall waterBall = m_ObjectPool.GetSpecificWaterBall(other);

        if (m_GlasContents.ContainsKey(waterBall.m_Beverage))
        {
            if (m_LastBeverage != waterBall.m_Beverage)
            {
                m_ShotProgress = 0f;
                m_LastBeverage = waterBall.m_Beverage;
            }

            m_ShotProgress += 0.5f * Time.deltaTime;
            if (m_ShotProgress >= 1f)
            {
                m_GlasContents[waterBall.m_Beverage]++;
                m_ShotProgress = 0f;
                Debug.Log("Shot added: " + waterBall.m_Beverage);
                UpdateBeverageUI(waterBall.m_Beverage, m_GlasContents[waterBall.m_Beverage]);
                waterBall.Deactivate();
            }
        }
        else
        {
            m_LastBeverage = waterBall.m_Beverage;
            m_GlasContents.Add(waterBall.m_Beverage, 0);
            CreateNewBeverageUI(waterBall.m_Beverage);
            waterBall.Deactivate();
        }
    }

    private void CreateNewBeverageUI(Beverages beverage)
    {
        GlasFeedback feedback = m_ObjectPool.GetGlasFeedback();
        feedback.Activate(beverage, m_MaxPoint, m_MinPoint);
        feedback.transform.parent = transform;
        m_GlasFeedback.Add(feedback);
    }

    private void UpdateBeverageUI(Beverages beverage, float amount)
    {
        for (int i = 0; i < m_GlasFeedback.Count; i++)
        {
            if (m_GlasFeedback[i].GetBeverage() == beverage)
            {
                m_GlasFeedback[i].UpdateUI(amount);
            }
        }
    }
}
