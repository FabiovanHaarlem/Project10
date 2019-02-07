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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GrabItem();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ReleaseItem();
        }
        //if (m_Item != null)
        //{
        //    m_Item.GetComponent<Rigidbody>().velocity = new Vector3();
        //}
    }

    private void GrabItem()
    {
        if (m_Item != null)
        {
            m_Item.transform.parent = transform;
            m_Item.GetComponent<Rigidbody>().useGravity = false;
            m_Item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void ReleaseItem()
    {
        if (m_Item != null)
        {
            if (m_Item.name != "Tablet")
            {
                m_Item.GetComponent<Rigidbody>().useGravity = true;
                m_Item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                m_Item.GetComponent<Rigidbody>().velocity = m_ControllerInput.GetControllerVelocity();
                m_Item.GetComponent<Rigidbody>().angularVelocity = m_ControllerInput.GetControllerAngularVelocity();
                m_Item.transform.parent = null;
                m_Item = null;
            }
            else
            {
                m_Item.transform.parent = null;
                m_Item = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Button") && !other.CompareTag("Moveable"))
        if (m_Item == null)
        m_Item = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (m_Item != null)
        {
            m_Item.transform.parent = null;
            m_Item = null;
        }
    }
}
