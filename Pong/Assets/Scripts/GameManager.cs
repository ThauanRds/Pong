using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerScore;
    public int AIScore;

    [Header("UI")]
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI AIScoreText;
    public GameObject gameOverPanel;
    public GameObject iaMessage;
    public GameObject playerMessage;


    [Header("Audios")]
    public AudioSource audioSource;
    public AudioClip scoreSFX;

    void Awake()
    {
        Time.timeScale = 1;

        AIScore = 0;
        playerScore = 0;
    }
    
    public void PlayerPoint()
    {
        JuiceText(playerScoreText);

        playerScore++;
        playerScoreText.text = playerScore.ToString();
        if (playerScore == 5)
        {
            gameOverPanel.SetActive(true);
            playerMessage.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void AIPoint()
    {
        JuiceText(AIScoreText);

        AIScore++;
        AIScoreText.text = AIScore.ToString();
        if(AIScore == 5)
        {
            gameOverPanel.SetActive(true);
            iaMessage.SetActive(true);  
            Time.timeScale = 0;
        }
    }

    void JuiceText(TextMeshProUGUI text)
    {
        audioSource.PlayOneShot(scoreSFX);

        text.transform.DOKill();
        text.transform.localScale = Vector3.one;
        text.transform.DOScale(1.5f, 0.5f).SetLoops(2, LoopType.Yoyo);

        //text.DOColor(Color.yellow, 0.5f).SetLoops(2, LoopType.Yoyo);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}
