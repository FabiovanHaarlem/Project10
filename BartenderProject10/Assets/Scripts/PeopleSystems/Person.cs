﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField]
    private List<MixedBeverage> m_MixedBeverages;
    private MixedBeverage m_MixedBeverage;
    private List<AddOn> m_AddOns;
    private Dictionary<Beverages, int> m_Beverages;
    [SerializeField]
    private FeedbackCloud m_FeedbackCloud;

    private int m_BeverageRating;

    private float m_NewBeverageTimer;
    private bool m_NewBeverage;

    private void Awake()
    {
        m_Beverages = new Dictionary<Beverages, int>();
        m_NewBeverage = true;
        m_NewBeverageTimer = Random.Range(3f, 6f);
    }

    private void ChooseMixedBeverage()
    {
        m_BeverageRating = 0;
        m_MixedBeverage = m_MixedBeverages[Random.Range(0, m_MixedBeverages.Count - 1)];
        for (int i = 0; i < m_MixedBeverage.m_Beverages.Count; i++)
        {
            m_Beverages.Add(m_MixedBeverage.m_Beverages[i].m_Beverage, m_MixedBeverage.m_Beverages[i].m_AmountInShots);
            m_BeverageRating++;
        }
        Debug.Log(m_MixedBeverage.m_BeverageName);
        ShowBeverage();
    }

    private void ShowBeverage()
    {
        m_FeedbackCloud.Activate(m_MixedBeverage.m_BeverageIcon);
    }

    private void CheckBeverage(Glas glas)
    {
        int playerRating = 0;

        foreach (KeyValuePair<Beverages, int> beverage in m_Beverages)
        {
            if (glas.GetGlasContents().ContainsKey(beverage.Key))
            {
                if (glas.GetGlasContents()[beverage.Key] == beverage.Value)
                {
                    playerRating += 1;
                }
            }
        }

        if (playerRating == m_BeverageRating || playerRating == m_BeverageRating - 1 || playerRating == m_BeverageRating + 1)
        {
            BeverageIsRight();
        }
        else
        {
            BeverageIsWrong();
        }

        m_NewBeverage = true;
        m_NewBeverageTimer = Random.Range(3f, 6f);
    }

    private void Update()
    {
        if (m_NewBeverage)
        {
            m_NewBeverageTimer -= Time.deltaTime;
            if (m_NewBeverageTimer <= 0f)
            {
                ChooseMixedBeverage();
                m_NewBeverage = false;
            }
        }
    }

    private void BeverageIsRight()
    {
        m_FeedbackCloud.RightDrink();
    }

    private void BeverageIsWrong()
    {
        m_FeedbackCloud.WrongDrink();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Glas"))
        {
            Glas glas = other.gameObject.GetComponent<Glas>();
            CheckBeverage(glas);
        }
    }
}
