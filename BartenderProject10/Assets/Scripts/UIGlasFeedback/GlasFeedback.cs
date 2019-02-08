using UnityEngine;
using UnityEngine.UI;
using System;

public class GlasFeedback : MonoBehaviour
{
    private Beverages m_Beverage;

    [SerializeField]
    private Text m_BeverageInformation;
    private string m_BeverageName;
    private Vector3 m_CurrentTargetPosition;
    private Vector3 m_MaxPoint;
    private Vector3 m_MinPoint;
    private GameObject m_PlayerHead;
    [SerializeField]
    private GameObject m_RotateParent;
    private float m_CloudNumber;

    private void Start()
    {
        m_PlayerHead = GameObject.Find("PlayerHead");
    }

    public void Activate(Beverages beverage, Transform maxPoint, Transform minPoint, int amountOfFeedbackClouds)
    {
        m_CloudNumber = amountOfFeedbackClouds;
        m_Beverage = beverage;
        m_MaxPoint = new Vector3(maxPoint.position.x, maxPoint.position.y, maxPoint.position.z);
        m_MinPoint = new Vector3(minPoint.position.x, minPoint.position.y, minPoint.position.z);
        string beverageName = "";
        switch(beverage)
        {
            case Beverages.Acardi:
                beverageName = "Acardi";
                break;
            case Beverages.Boujie:
                beverageName = "Boujie";
                break;
            case Beverages.Coinstreau:
                beverageName = "Coinstreau";
                break;
            case Beverages.Cola:
                beverageName = "Cola";
                break;
            case Beverages.Fanta:
                beverageName = "Fanta";
                break;
            case Beverages.Cassis:
                beverageName = "Cassis";
                break;
            case Beverages.IceTea:
                beverageName = "Ice Tea";
                break;
            case Beverages.Tonic:
                beverageName = "Tonic";
                break;
            case Beverages.GrapefruitJuice:
                beverageName = "Grapefruit Juice";
                break;
            case Beverages.IncompleteVodka:
                beverageName = "Incomplete Vodka";
                break;
            case Beverages.JohnnyDaniels:
                beverageName = "Johnny Daniels";
                break;
            case Beverages.OrangeJuice:
                beverageName = "Orange Juice";
                break;
            case Beverages.Bebida:
                beverageName = "Bebida";
                break;
            case Beverages.EightUp:
                beverageName = "8 Up";
                break;
            case Beverages.SugerRush:
                beverageName = "Suger Rush";
                break;
            case Beverages.ToKilYa:
                beverageName = "To Kil Ya";
                break;
            case Beverages.Beer:
                beverageName = "Beer";
                break;
        }
        m_BeverageName = beverageName;
        gameObject.SetActive(true);
        transform.position = m_MinPoint;
        m_CurrentTargetPosition = Vector3.MoveTowards(m_MinPoint, m_MaxPoint, (m_CloudNumber * 2.0f) / 40.0f);
        transform.position = m_CurrentTargetPosition;
        m_BeverageInformation.text = m_BeverageName + Environment.NewLine + "0";    
    }

    public void Deactivate()
    {
        transform.parent = transform;
        gameObject.SetActive(false);
    }

    public void UpdateUI(float amount)
    {
        m_BeverageInformation.text = m_BeverageName + Environment.NewLine + Mathf.Round(amount) + "Shots";
        //amount = Mathf.Clamp(amount, 0, 10);
        //amount = amount / 25f;
        //m_CurrentTargetPosition = Vector3.MoveTowards(m_MinPoint, m_MaxPoint, amount);
        //transform.position = Vector3.MoveTowards(transform.position, m_CurrentTargetPosition, 1f);
    }

    private void Update()
    {
        m_RotateParent.transform.LookAt(m_PlayerHead.transform.position);
    }

    public Beverages GetBeverage()
    {
        return m_Beverage;
    }
}
