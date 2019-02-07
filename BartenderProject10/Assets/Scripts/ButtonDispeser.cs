using UnityEngine;
using UnityEngine.Events;

public class ButtonDispeser : MonoBehaviour
{
    [SerializeField]
    private UnityEvent m_ButtonPressedEvent;
    [SerializeField]
    private bool m_HoldButton;

    private void ButtonPressed()
    {
        m_ButtonPressedEvent.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (m_HoldButton)
        ButtonPressed();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!m_HoldButton)
            ButtonPressed();
    }
}
