using UnityEngine;

public class WaterBall : MonoBehaviour
{
    public Beverages m_Beverage;
    public Extras m_AddOns;
    private Renderer m_Renderer;
    private Rigidbody m_Rigidbody;

    private float m_DisableTimer;
    private bool m_Disable;

    private void Awake()
    {
        m_Renderer = GetComponent<Renderer>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void Activate(Vector3 pos, Vector3 target, Beverages beverage, Material beverageColor)
    {
        transform.position = pos;
        m_Beverage = beverage;
        gameObject.SetActive(true);
        Vector3 dir = (target - transform.position).normalized;
        m_Rigidbody.AddForce(dir * 1.2f, ForceMode.Impulse);
        m_DisableTimer = 0.5f;
        m_Disable = false;
        ChangeMaterial(beverageColor);
    }

    public void Activate(Vector3 pos, Vector3 target, Extras addOn)
    {
        transform.position = pos;
        m_AddOns = addOn;
        gameObject.SetActive(true);
        Vector3 dir = (target - transform.position).normalized;
        m_Rigidbody.AddForce(dir * 1.2f, ForceMode.Impulse);
        m_DisableTimer = 0.5f;
        m_Disable = false;
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
        m_Rigidbody.velocity = new Vector3(0f, 0f, 0f);
    }

    private void Update()
    {
        if (m_Disable)
        {
            m_DisableTimer -= Time.deltaTime;
            if (m_DisableTimer <= 0f)
            {
                Deactivate();
            }
        }
    }

    public void ChangeMaterial(Material beverageColor)
    {
        m_Renderer.material = beverageColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Glas"))
        {
            m_Disable = true;
        }
    }
}
