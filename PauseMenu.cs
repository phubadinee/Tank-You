using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    AudioManager audioManager;
    private int points;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Pause()
    {
        // audioManager.PlaySFX(audioManager.click);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Home()
    {
        // audioManager.PlaySFX(audioManager.click);
        points = testPoints.instance.GetCurrentPoint();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        TotalPoint.instance.IncreaseTotalPoints(points);
    }
    public void Exit()
    {
        // audioManager.PlaySFX(audioManager.click);
        points = testPoints.instance.GetCurrentPoint();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void Resume()
    {
        // audioManager.PlaySFX(audioManager.click);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        // audioManager.PlaySFX(audioManager.click);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
