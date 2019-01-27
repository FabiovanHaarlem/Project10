using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> m_MixCards;
    [SerializeField]
    private SpriteRenderer m_Screen;

    private int m_Index;

    private void Awake()
    {
        m_Index = 0;
        m_Screen.sprite = m_MixCards[m_Index];
    }

    private void SwitchMixCard()
    {
        m_Index++;
        if (m_Index == m_MixCards.Count)
            m_Index = 0;

        m_Screen.sprite = m_MixCards[m_Index];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandTrigger"))
        {
            SwitchMixCard();
        }
    }
}
