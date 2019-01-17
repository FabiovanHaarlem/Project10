using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField]
    private List<MixedBeverage> m_MixedBeverages;
    private MixedBeverage m_MixedBeverage;
    private List<AddOn> m_AddOns;
    private Dictionary<Beverages, int> m_Beverages;

    private int m_BeverageRating;

    private void Awake()
    {
        m_Beverages = new Dictionary<Beverages, int>();
    }

    private void Start()
    {
        ChooseMixedBeverage();
    }

    private void ChooseMixedBeverage()
    {
        m_BeverageRating = 0;
        m_MixedBeverage = m_MixedBeverages[0];
        for (int i = 0; i < m_MixedBeverage.m_Beverages.Count; i++)
        {
            m_Beverages.Add(m_MixedBeverage.m_Beverages[i].m_Beverage, m_MixedBeverage.m_Beverages[i].m_AmountInShots);
            m_BeverageRating++;
        }
    }

    private void ShowBeverage()
    {

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
    }

    private void BeverageIsRight()
    {
        
    }

    private void BeverageIsWrong()
    {
        
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
