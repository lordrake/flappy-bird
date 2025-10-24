using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public int powerUpCount = 0;

    public Text powerUpText;
    public GameObject gameOverScreen;
    public GameObject gameStartScreen;
    public AudioSource successSFX;
    public AudioSource gameOverSFX;
    public GameObject playButton;

    public Text hintText;

    public int powerUpGoal = 3;


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

    public void increasePowerUpCount(int increment)
    {
        powerUpCount += increment;
        powerUpText.text = powerUpCount.ToString() + "/" + powerUpGoal;

        Debug.Log(powerUpCount);
        successSFX.Play();
    }
    
    public void resetPowerUps()
    {
        powerUpCount = 0;
        powerUpText.text = powerUpCount.ToString() + "/" + powerUpGoal;
    }
}
