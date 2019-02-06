using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    private Vector3 m_DefaultPosition;
    private Quaternion m_DefaultRotation;
     
    private void Start()
    {
        m_DefaultPosition = transform.position;
        m_DefaultRotation = transform.rotation;
    }

    private void ResetObject()
    {
        transform.position = m_DefaultPosition;
        transform.rotation = m_DefaultRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DisableCollider"))
        {
            ResetObject();
        }
    }
}
