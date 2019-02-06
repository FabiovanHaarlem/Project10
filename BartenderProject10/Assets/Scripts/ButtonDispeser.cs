using UnityEngine;
using UnityEngine.Events;

public class ButtonDispeser : MonoBehaviour
{
    [SerializeField]
    private UnityEvent m_ButtonPressedEvent;

    private void ButtonPressed()
    {
        m_ButtonPressedEvent.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        ButtonPressed();
    }
}
