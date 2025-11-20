using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreUI;
    public TextMeshProUGUI bestScoreUI;
    public TextMeshProUGUI bulletCountUI;
    public GameObject gameOverUI;
    public int currentScore;
    public int bestScore;
    public int bulletCount;

    AudioSource audioSrc;

    public static GameManager instance = null;

    public int score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
            currentScoreUI.text = "Score : " + currentScore;

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = "Best : " + bestScore;

                PlayerPrefs.SetInt("Best Shooting Score", bestScore);
            }
        }
    }

    public int bullets
    {
        get
        {
            return bulletCount;
        }
        set
        {
            bulletCount = value;
            bulletCountUI.text = "Bullet : " + bulletCount;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        gameOverUI.SetActive(false);

        bestScore = PlayerPrefs.GetInt("Best Shooting Score", 0);
        bestScoreUI.text = "Best : " + bestScore;
        currentScoreUI.text = "Score : 0";
    }

    void Update()
    {

    }

    public void PlayEffectSound(AudioClip sound)
    {
        audioSrc.PlayOneShot(sound);
    }
    /*
    public int GetScore()
    {
        return currentScore;
    }

    public void SetScore(int score)
    {
        currentScore = score;
        currentScoreUI.text = "Score : " + currentScore;

        if(currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreUI.text = "Best : " + bestScore;

            PlayerPrefs.SetInt("Best Shooting Score", bestScore);
        }
    }
    */
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
