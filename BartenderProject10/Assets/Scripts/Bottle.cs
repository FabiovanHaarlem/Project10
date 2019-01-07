using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField]
    private Beverages m_Beverage;
    [SerializeField]
    private ObjectPool m_ObjectPool;
    [SerializeField]
    private Material m_WaterColor;
    [SerializeField]
    private Transform m_BottleOpening;
    [SerializeField]
    private Transform m_WaterBallTarget;

    private float m_MinTippingPoint;
    private float m_MaxTippingPoint;

    private float m_PourSpeed;

    private void Awake()
    {
        m_MinTippingPoint = 90f;
        m_MaxTippingPoint = 270f;
        m_PourSpeed = 0.015f;
        m_WaterBallTarget.transform.position = new Vector3(m_BottleOpening.position.x, m_BottleOpening.position.y + 0.3f, m_BottleOpening.position.z);
    }

    private void Update()
    {
        CheckIfTipping();
    }

    private void CheckIfTipping()
    {
        Vector3 angle = transform.localEulerAngles;
        m_PourSpeed -= Time.deltaTime;

        if (Vector3.Dot(transform.up, Vector3.down) > 0)
        {
            if (m_PourSpeed <= 0f)
            {
                Pour();
                m_PourSpeed = 0.015f;
            }
        }
    }

    private void Pour()
    {
        WaterBall waterBall =  m_ObjectPool.GetWaterBall();
        waterBall.Activate(m_BottleOpening.position, m_WaterBallTarget.transform.position, m_Beverage);
    }
}
