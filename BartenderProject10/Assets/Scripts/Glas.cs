using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glas : MonoBehaviour
{
    [SerializeField]
    private ObjectPool m_ObjectPool;

    private List<AddOn> m_AddOns;
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
    private GameObject m_Parent;

    [SerializeField]
    private GameObject m_WholeLemonSlice;
    [SerializeField]
    private GameObject m_HalfLemonSlice;
    [SerializeField]
    private GameObject m_WholeOrangeSlice;
    [SerializeField]
    private GameObject m_HalfOrangeSlice;
    [SerializeField]
    private GameObject m_Ice;
    [SerializeField]
    private GameObject m_Cherry;

    //[SerializeField]
    //private Renderer m_Renderer;

    //private float m_FillAmount;

    private void Awake()
    {
        m_GlasContents = new Dictionary<Beverages, int>();
        m_GlasFeedback = new List<GlasFeedback>();

        m_Parent = transform.parent.gameObject;
        m_DefaultPosition = m_Parent.transform.position;
        m_DefaultRotation = m_Parent.transform.rotation;
        //m_FillAmount = 0.6f;
    }

    private void Start()
    {
        m_ObjectPool = GameObject.Find("_System").GetComponent<ObjectPool>();
        //m_Renderer.material.SetFloat("_FillAmount", m_FillAmount);
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

        if (other.gameObject.CompareTag("Addon"))
        {
            
            AddOn addon = other.gameObject.GetComponent<AddOn>();
            switch(addon.m_Extra)
            {
                case Extras.Cherry:
                    if (m_Cherry != null)
                    m_Cherry.SetActive(true);
                    break;
                case Extras.WholeLemonSlice:
                    if (m_WholeLemonSlice != null)
                        m_WholeLemonSlice.SetActive(true);
                    break;
                case Extras.WholeOrangeSlice:
                    if (m_WholeOrangeSlice != null)
                        m_WholeOrangeSlice.SetActive(true);
                    break;
                case Extras.HalfLemonSlice:
                    if (m_HalfLemonSlice != null)
                        m_HalfLemonSlice.SetActive(true);
                    break;
                case Extras.HalfOrangeSlice:
                    if (m_HalfOrangeSlice != null)
                        m_HalfOrangeSlice.SetActive(true);
                    break;
                case Extras.Ice:
                    if (m_Ice != null)
                        m_Ice.SetActive(true);
                    break;
            }
            addon.gameObject.SetActive(false);
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
        m_Parent.transform.position = m_DefaultPosition;
        m_Parent.transform.rotation = m_DefaultRotation;
        if (m_Cherry != null)
            m_Cherry.SetActive(false);
        if (m_WholeLemonSlice != null)
            m_WholeLemonSlice.SetActive(false);
        if (m_WholeOrangeSlice != null)
            m_WholeOrangeSlice.SetActive(false);
        if (m_HalfLemonSlice != null)
            m_HalfLemonSlice.SetActive(false);
        if (m_HalfOrangeSlice != null)
            m_HalfOrangeSlice.SetActive(false);
        if (m_Ice != null)
            m_Ice.SetActive(false);
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

            m_ShotProgress += 1.5f * Time.deltaTime;
            if (m_ShotProgress >= 1f)
            {
                //m_Renderer.material.SetColor("_TopColor", waterBall.GetMaterial().color);
                //m_FillAmount -= 0.025f;
                //m_Renderer.material.SetFloat("_FillAmount", m_FillAmount);
                m_GlasContents[waterBall.m_Beverage]++;
                m_ShotProgress = 0f;
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
        //m_FillAmount = Mathf.Clamp(m_FillAmount, 0.4f, 0.6f);
    }

    private void CreateNewBeverageUI(Beverages beverage)
    {
        GlasFeedback feedback = m_ObjectPool.GetGlasFeedback();
        feedback.Activate(beverage, m_MaxPoint, m_MinPoint, m_GlasFeedback.Count);
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
