using System.Collections;
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

    private void Awake()
    {
        //m_GlasContents = new List<GlasBeveragePiece>();
        m_GlasContents = new Dictionary<Beverages, int>();
        m_GlasFeedback = new List<GlasFeedback>();
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

            m_ShotProgress += Time.deltaTime;
            if (m_ShotProgress >= 1f)
            {
                m_GlasContents[waterBall.m_Beverage]++;
                m_ShotProgress = 0f;
                Debug.Log("Shot");
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
