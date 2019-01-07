using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private ControllerInput m_ControllerInput;
    private GameObject m_Item;

    private void Awake()
    {
        m_ControllerInput = GetComponent<ControllerInput>();
        m_ControllerInput.E_OnTriggerEvent += GrabItem;
        m_ControllerInput.E_OnTriggerUpEvent += ReleaseItem;
    }

    private void GrabItem()
    {
        m_Item.transform.parent = transform;
        m_Item.GetComponent<Rigidbody>().useGravity = false;
    }

    private void ReleaseItem()
    {
        if (m_Item != null)
        {
            m_Item.transform.parent = null;
            m_Item = null;
            m_Item.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_Item == null)
        m_Item = other.gameObject;
    }
}
