using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tablet : MonoBehaviour
{
    [SerializeField]
    private List<MixedBeverage> m_MixCards;
    [SerializeField]
    private SpriteRenderer m_Screen;
    [SerializeField]
    private TextMeshProUGUI m_BeverageName;
    [SerializeField]
    private TextMeshProUGUI m_Information;

    private int m_Index;

    private void Awake()
    {
        m_Index = 0;
        m_Screen.sprite = m_MixCards[m_Index].m_BeverageIcon;
        m_BeverageName.text = m_MixCards[m_Index].name;
        m_Information.text = m_MixCards[m_Index].m_Information;
    }

    private void SwitchMixCard()
    {
        m_Index++;
        if (m_Index == m_MixCards.Count)
            m_Index = 0;

        m_Screen.sprite = m_MixCards[m_Index].m_BeverageIcon;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandTrigger"))
        {
            SwitchMixCard();
        }
    }
}
