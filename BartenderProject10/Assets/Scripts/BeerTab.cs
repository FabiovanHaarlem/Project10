using UnityEngine;

public class BeerTab : MonoBehaviour
{
    private Beverages m_Beverage;
    private ObjectPool m_ObjectPool;
    [SerializeField]
    private Material m_WaterColor;
    [SerializeField]
    private Transform m_BottleOpening;
    [SerializeField]
    private Transform m_WaterBallTarget;

    private void Awake()
    {
        m_Beverage = Beverages.Beer;
    }

    private void Start()
    {
        m_ObjectPool = GameObject.Find("_System").GetComponent<ObjectPool>();
    }

    public void Pour()
    {
        WaterBall waterBall = m_ObjectPool.GetWaterBall();
        waterBall.Activate(m_BottleOpening.position, m_WaterBallTarget.transform.position, m_Beverage, m_WaterColor);
    }
}
