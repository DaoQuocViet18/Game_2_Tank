using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    public GameObject End_Screen;

    private AudioSource playerAudio;
    public AudioClip End_Sound;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Again_Game()
    {
        End_Screen.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Start_End ()
    {
        StartCoroutine(End_Game());
    }

    IEnumerator End_Game()
    {
        playerAudio.PlayOneShot(End_Sound);
        yield return new WaitForSeconds(1f);
        End_Screen.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
