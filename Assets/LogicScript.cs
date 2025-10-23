using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource successSFX;
    public AudioSource gameOverSFX;

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
    }
}
