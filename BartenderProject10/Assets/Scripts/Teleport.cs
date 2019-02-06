using UnityEngine;

public class Teleport : MonoBehaviour
{
    private ControllerInput m_ControllerInput;
    private Vector3 m_SelectedPosition;
    [SerializeField]
    private GameObject m_Rig;
    [SerializeField]
    private GameObject m_Laser;

    private void Start()
    {
        m_ControllerInput = GetComponent<ControllerInput>();
        m_ControllerInput.E_OnTrackpadPressEvent += Aim;
        m_ControllerInput.E_OnTrackpadPressUpEvent += TeleportToLocation;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Aim();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            TeleportToLocation();
        }
    }

    private void Aim()
    {
        m_Laser.SetActive(true);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 10.0f);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10.0f))
        {
            if (hit.collider.gameObject.CompareTag("Moveable"))
            {
                m_SelectedPosition = hit.point;
            }
        }
    }

    private void TeleportToLocation()
    {
        m_Laser.SetActive(false);
        if (m_SelectedPosition != Vector3.zero)
        {
            m_Rig.transform.position = new Vector3(m_SelectedPosition.x, m_SelectedPosition.y - 0.3f, m_SelectedPosition.z);
            m_SelectedPosition = new Vector3();
        }
    }
}
