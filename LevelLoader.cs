using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Slider slider;
    public SaveSystem saveSystem;
    private void Start()
    {
        if (saveSystem.localSavedScene == 0)
            saveSystem.localSavedScene++;
        LoadLvl();
    }
    private void LoadLvl()
    {
        StartCoroutine("LoadASync");
    }
    private IEnumerator LoadASync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(saveSystem.localSavedScene);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value -= progress;
            yield return null;
        }
    }
}