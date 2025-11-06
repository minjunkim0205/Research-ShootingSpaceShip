using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreUI;
    public TextMeshProUGUI bestScoreUI;
    public int currentScore;
    public int bestScore;

    AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        currentScoreUI.text = "Best : 0";
        bestScore = PlayerPrefs.GetInt("Best Shooting Score", 0);
        bestScoreUI.text = "Best : " + bestScore;
    }

    void Update()
    {

    }

    public void PlayEffectSound(AudioClip sound)
    {
        audioSrc.PlayOneShot(sound);
    }
    
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
}
