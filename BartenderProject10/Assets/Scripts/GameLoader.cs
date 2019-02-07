using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    private AudioSource m_Music;
    [SerializeField]
    private List<string> m_Scenes;
    [SerializeField]
    private List<AudioClip> m_Songs;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        m_Music = GetComponent<AudioSource>();
        int randomNumber = Random.Range(0, m_Songs.Count);
        m_Music.clip = m_Songs[randomNumber];
        m_Music.Play();
        randomNumber = Random.Range(0, m_Scenes.Count);
        SceneManager.LoadScene(m_Scenes[randomNumber]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            m_Music.Stop();
            int randomNumber = Random.Range(0, m_Songs.Count);
            m_Music.clip = m_Songs[randomNumber];
            m_Music.Play();

            randomNumber = Random.Range(0, m_Scenes.Count);
            SceneManager.LoadScene(m_Scenes[randomNumber]);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
