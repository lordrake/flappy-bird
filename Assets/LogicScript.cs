using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject gameStartScreen;
    public AudioSource successSFX;
    public AudioSource gameOverSFX;
    public GameObject playButton;


    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }
    [ContextMenu("Increase Score")]
    public void addScore(int scoreIncrement)
    {
        playerScore += scoreIncrement;
        scoreText.text = playerScore.ToString();
        successSFX.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverSFX.Play();
        gameOverScreen.SetActive(true);
        Pause();
        
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        
    }
    
    public void Play()
    {
        playerScore = 0;
        scoreText.text = playerScore.ToString();
        playButton.SetActive(false);
        gameStartScreen.SetActive(false);
        Time.timeScale = 1f;
        
    }
}
