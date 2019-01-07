using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    #region TriggerEvents
    public delegate void OnTriggerEvent();
    public event OnTriggerEvent E_OnTriggerEvent;

    public delegate void OnTriggerUpEvent();
    public event OnTriggerEvent E_OnTriggerUpEvent;

    public delegate void OnTriggerDownEvent();
    public event OnTriggerEvent E_OnTriggerDownEvent;
    #endregion

    #region TrackpadPressEvents
    public delegate void OnTrackpadPressEvent();
    public event OnTrackpadPressEvent E_OnTrackpadPressEvent;

    public delegate void OnTrackpadPressUpEvent();
    public event OnTrackpadPressUpEvent E_OnTrackpadPressUpEvent;

    public delegate void OnTrackpadPressDownEvent();
    public event OnTrackpadPressDownEvent E_OnTrackpadPressDownEvent;
    #endregion

    private SteamVR_TrackedObject m_TrackedObject;
    private SteamVR_Controller.Device m_Controller
    {
        get { return SteamVR_Controller.Input((int)m_TrackedObject.index); }
    }

    private void Update()
    {
        m_TrackedObject = GetComponent<SteamVR_TrackedObject>();
        GetInputs();
    }

    private void GetInputs()
    {
        if (m_Controller.GetHairTriggerDown())
            OnTriggerDown();
        else if (m_Controller.GetHairTriggerUp())
            OnTriggerUp();
        else if (m_Controller.GetHairTrigger())
            OnTrigger();

        if (m_Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            OnTrackpadPressDown();
        else if (m_Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            OnTrackpadPressUp();
        else if (m_Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            OnTrackpadPress();
    }

    private void OnTrigger()
    {
        if (E_OnTriggerEvent != null)
            E_OnTriggerEvent.Invoke();
    }

    private void OnTriggerUp()
    {
        if (E_OnTriggerUpEvent != null)
            E_OnTriggerUpEvent.Invoke();
    }

    private void OnTriggerDown()
    {
        if (E_OnTriggerDownEvent != null)
            E_OnTriggerDownEvent.Invoke();
    }

    private void OnTrackpadPress()
    {
        if (E_OnTrackpadPressEvent != null)
            E_OnTrackpadPressEvent.Invoke();
    }

    private void OnTrackpadPressUp()
    {
        if (E_OnTrackpadPressUpEvent != null)
            E_OnTrackpadPressUpEvent.Invoke();
    }

    private void OnTrackpadPressDown()
    {
        if (E_OnTrackpadPressDownEvent != null)
            E_OnTrackpadPressDownEvent.Invoke();
    }
}
