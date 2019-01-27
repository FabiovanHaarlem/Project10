using UnityEngine;

public class FeedbackCloud : MonoBehaviour
{
    private SpriteRenderer m_CloudImage;
    [SerializeField]
    private Sprite m_RightDrinkSprite;
    [SerializeField]
    private Sprite m_WrongDrinkSprite;

    private void Start()
    {
        m_CloudImage = GetComponent<SpriteRenderer>();
        Disable();
    }

    public void Activate(Sprite sprite)
    {
        m_CloudImage.sprite = sprite;
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void RightDrink()
    {
        m_CloudImage.sprite = m_RightDrinkSprite;
    }

    public void WrongDrink()
    {
        m_CloudImage.sprite = m_WrongDrinkSprite;
    }
}
