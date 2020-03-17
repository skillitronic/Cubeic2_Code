using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Text currentLvlText, nextLvlText;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            currentLvlText.text = "" + SceneManager.GetActiveScene().buildIndex;
            nextLvlText.text = "" + (SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void ReloadLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}