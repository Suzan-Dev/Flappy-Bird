using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI scoreText;
    public GameObject gameOver;
    public GameObject playButton;

    private int score = 0;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        Time.timeScale = 1;
        player.enabled = true;

        gameOver.SetActive(false);
        playButton.SetActive(false);

        score = 0;
        scoreText.text = score.ToString();

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        Pause();

        gameOver.SetActive(true);
        playButton.SetActive(true);
    }
}
