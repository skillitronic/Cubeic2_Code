using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private SaveSystem saveSystem;
    public AudioSource audioSource;
    public GameObject musicIcon;
    public AudioClip[] musics;
    [SerializeField] private int musicRandomizer;
    private bool isPaused;
    public void Awake()
    {
        saveSystem = GetComponent<SaveSystem>();
    }
    public void Start()
    {
        musicRandomizer = Random.Range(0, musics.Length);
        audioSource.clip = musics[musicRandomizer];
        if (saveSystem.localMusicSwitched == true)
        {
            audioSource.Pause();
            musicIcon.SetActive(true);
        }
        else
        {
            musicIcon.SetActive(false);
            audioSource.Play();
        }
    }
    public void StopMusic()
    {
        audioSource.Pause();
        isPaused = true;
    }
    public void ToggleMusic()
    {
        saveSystem.localMusicSwitched = !saveSystem.localMusicSwitched;
        if (saveSystem.localMusicSwitched == true)
        {
            audioSource.Pause();
            musicIcon.SetActive(true);
        }
        else
        {
            musicIcon.SetActive(false);
            audioSource.Play();
        }
        saveSystem.SaveMusicSoundData();
    }
    public void FixedUpdate()
    {
        if (audioSource.isPlaying == false && isPaused == false && saveSystem.localMusicSwitched == false)
        {
            int oldRandomNumber = musicRandomizer;
            while (musicRandomizer == oldRandomNumber)
                musicRandomizer = Random.Range(0, musics.Length);

            audioSource.clip = musics[musicRandomizer];
            audioSource.Play();
        }
    }

}
