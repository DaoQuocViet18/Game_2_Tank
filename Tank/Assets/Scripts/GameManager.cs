using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game")]
    public GameObject End_Screen;
    public GameObject Health_Screen;
    private AudioSource playerAudio;
    public AudioClip End_Sound;

    [Header("Score")]
    public GameObject Canvas;
    public TextMeshProUGUI scoreText_1;
    public TextMeshProUGUI scoreText_2;
    private int score_1 = 0;
    private int score_2 = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(Canvas);
    }

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
        Health_Screen.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void Score (int Player)
    {
        if (Player == 1)
        {
            score_2++;
            scoreText_2.text = "" + score_2;
        }
        else if (Player == 2)
        {
            score_1++;
            scoreText_1.text ="" + score_1;
        }
    }
}
