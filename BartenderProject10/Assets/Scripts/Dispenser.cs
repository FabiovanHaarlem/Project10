using UnityEngine;

public class Dispenser : MonoBehaviour
{
    [SerializeField]
    private Extras m_Addon;
    private ObjectPool m_ObjectPool;

    private void Start()
    {
        m_ObjectPool = GameObject.Find("_System").GetComponent<ObjectPool>();
    }

    public void Pour()
    {
        AddOn addon = m_ObjectPool.GetAddon(m_Addon);
        addon.transform.position = transform.position;
        addon.transform.rotation = transform.rotation;
        addon.gameObject.SetActive(true);
    }
}
