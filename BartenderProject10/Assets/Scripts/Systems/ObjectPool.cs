using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<WaterBall> m_WaterBalls;

    private void Awake()
    {
        m_WaterBalls = new List<WaterBall>();

        for (int i = 0; i < 400; i++)
        {
            GameObject waterball = Instantiate(Resources.Load("Prefabs/Waterball")) as GameObject;
            m_WaterBalls.Add(waterball.GetComponent<WaterBall>());
            waterball.SetActive(false);
        }
    }

    public WaterBall GetSpecificWaterBall(Collider wantedWaterBall)
    {
        WaterBall waterball = m_WaterBalls[0];
        for (int i = 0; i < m_WaterBalls.Count; i++)
        {
            if (wantedWaterBall.gameObject.GetInstanceID() == m_WaterBalls[i].GetInstanceID())
            {
                waterball = m_WaterBalls[i];
                break;
            }
        }

        return waterball;
    }

    public WaterBall GetWaterBall()
    {
        WaterBall waterball = m_WaterBalls[0];
        for (int i = 0; i < m_WaterBalls.Count; i++)
        {
            if (!m_WaterBalls[i].gameObject.activeInHierarchy)
            {
                waterball = m_WaterBalls[i];
                break;
            }
        }

        return waterball;
    }
}
