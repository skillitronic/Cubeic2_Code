using UnityEngine;

public class PauseLogic : MonoBehaviour
{
    [SerializeField] private bool isPaused;
    public GameObject pausePanel;
    public void MakePause()
    {
        isPaused = !isPaused;
        CheckForPause(isPaused, pausePanel);
    }
    public void Resume()
    {
        isPaused = false;
        CheckForPause(isPaused, pausePanel);
    }
    public void CheckForPause(bool isPaused, GameObject pausePanel)
    {
        if (isPaused == true)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
}
