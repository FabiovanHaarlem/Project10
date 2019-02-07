using UnityEngine;

public class BackgroundPeople : MonoBehaviour
{
    private Animator m_Animator;
    private float m_PlayAnimation;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.SetTrigger("Idle");
        m_PlayAnimation = Random.Range(3.0f, 8.0f);
    }

    private void Update()
    {
        m_PlayAnimation -= Time.deltaTime;
        if (m_PlayAnimation <= 0.0f)
        {
            PlayAnimation();
            m_PlayAnimation = Random.Range(3.0f, 8.0f);
        }
    }

    private void PlayAnimation()
    {
        int randomAnimation = Random.Range(0, 2);
        switch (randomAnimation)
        {
            case 0:
                m_Animator.SetTrigger("Order");
                m_Animator.SetTrigger("Idle");
                break;
            case 1:
                m_Animator.SetTrigger("TakeDrink");
                m_Animator.SetTrigger("Idle");
                break;
        }
    }

}
