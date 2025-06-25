using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen; // Arraste aqui o Canvas com a tela de Game Over

    void Start()
    {
        if (gameOverScreen != null)
            gameOverScreen.SetActive(false); // Esconde a tela no início
    }

    public void GameOver()
    {
        if (gameOverScreen != null)
            gameOverScreen.SetActive(true); // Mostra a tela de Game Over

        // Para a pontuação (se existir ScoreManager na cena)
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
            scoreManager.StopScore();
    }

    public void Retry()
    {
        // Recarrega a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
