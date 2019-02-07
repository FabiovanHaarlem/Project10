using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<WaterBall> m_WaterBalls;
    private List<GlasFeedback> m_GlasFeedbacks;
    private List<AddOn> m_Addons;
    [SerializeField]
    private List<GameObject> m_AddonsPrefabs;

    private void Awake()
    {
        m_WaterBalls = new List<WaterBall>();
        m_GlasFeedbacks = new List<GlasFeedback>();
        m_Addons = new List<AddOn>();

        for (int i = 0; i < 400; i++)
        {
            GameObject waterball = Instantiate(Resources.Load("Prefabs/Dev/Waterball")) as GameObject;
            m_WaterBalls.Add(waterball.GetComponent<WaterBall>());
            waterball.SetActive(false);
        }

        for (int i = 0; i < 10; i++)
        {
            GameObject glasFeedback = Instantiate(Resources.Load("Prefabs/Dev/GlasFeedback")) as GameObject;
            m_GlasFeedbacks.Add(glasFeedback.GetComponent<GlasFeedback>());
            glasFeedback.SetActive(false);
        }

        CreateAllAddons();
    }

    private void CreateAllAddons()
    {
        for (int i = 0; i < m_AddonsPrefabs.Count; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject addon = Instantiate(m_AddonsPrefabs[i]);
                m_Addons.Add(addon.GetComponent<AddOn>());
                addon.SetActive(false);
            }
        }
    }

    public AddOn GetAddon(Extras wantedAddon)
    {
        AddOn addon = m_Addons[0];
        for (int i = 0; i < m_Addons.Count; i++)
        {
            if (wantedAddon == m_Addons[i].m_Extra)
            {
                addon = m_Addons[i];
                if (!m_Addons[i].gameObject.activeInHierarchy)
                {
                    addon = m_Addons[i];
                    break;
                }
            }
        }
        return addon;
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

    public GlasFeedback GetGlasFeedback()
    {
        GlasFeedback glasFeedback = m_GlasFeedbacks[0];
        for (int i = 0; i < m_GlasFeedbacks.Count; i++)
        {
            if (!m_GlasFeedbacks[i].gameObject.activeInHierarchy)
            {
                glasFeedback = m_GlasFeedbacks[i];
                break;
            }
        }

        return glasFeedback;
    }
}
