using UnityEngine;

public class AddOn : MonoBehaviour
{
    public Extras m_Extra;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DisableCollider"))
        {
            gameObject.SetActive(false);
        }
    }
}
