using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glas : MonoBehaviour
{
    [SerializeField]
    private ObjectPool m_ObjectPool;
    private List<Collider> m_Colliders;

    private List<GlasBeveragePiece> m_GlasCap;

    private void Awake()
    {
        m_Colliders = new List<Collider>();
        m_GlasCap = new List<GlasBeveragePiece>();
    }

    private void CalculatePrecentages()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WaterBall"))
        {
            WaterBall waterBall = m_ObjectPool.GetSpecificWaterBall(other);

            if (m_GlasCap.Count > 0)
            {
                for (int i = 0; i < m_GlasCap.Count; i++)
                {
                    if (m_GlasCap[i].m_Beverage == waterBall.m_Beverage)
                    {
                        m_GlasCap[i].m_Amount += 1f / m_GlasCap.Count;
                        Debug.Log("Added: " + m_GlasCap[i].m_Beverage + " " + m_GlasCap[i].m_Amount);

                        for (int j = 0; j < m_GlasCap.Count; j++)
                        {
                            if (m_GlasCap[i].m_Beverage != waterBall.m_Beverage)
                            {
                                m_GlasCap[j].m_Amount -= 1f / m_GlasCap.Count;
                                Debug.Log("Removed: " + m_GlasCap[i].m_Beverage + " " + m_GlasCap[i].m_Amount);
                                if (m_GlasCap[j].m_Amount < 0f)
                                {
                                    m_GlasCap[j].m_Amount = 0f;
                                }
                            }
                        }
                    }
                    else if (i == m_GlasCap.Count - 1)
                    {
                        float amount = m_GlasCap.Count;
                        if (amount == 0)
                        {
                            amount = 1f;
                        }
                        GlasBeveragePiece piece = new GlasBeveragePiece();
                        piece.m_Beverage = waterBall.m_Beverage;
                        piece.m_Amount = 0f;
                        m_GlasCap.Add(piece);
                    }
                }
            }
            else
            {
                float amount = m_GlasCap.Count;
                if (amount == 0)
                {
                    amount = 1f;
                }
                GlasBeveragePiece piece = new GlasBeveragePiece();
                piece.m_Beverage = waterBall.m_Beverage;
                piece.m_Amount = 0f;
                m_GlasCap.Add(piece);
            }

            waterBall.Deactivate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_Colliders.Remove(other);
    }
}
