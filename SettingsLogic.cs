using UnityEngine;

public class SettingsLogic : MonoBehaviour
{
    public GameObject settingsPanel, settingsButton, holdToFlyPanel;
    public Sprite settingsSprite, backSprite;
    [SerializeField] private bool isSettingsOpened = true;

    private void Awake()
    {
        isSettingsOpened = true;
    }
    public void OpenCloseSettings()
    {
        isSettingsOpened = !isSettingsOpened;
        if (isSettingsOpened == false)
        {
            holdToFlyPanel.SetActive(false);
            settingsPanel.SetActive(false);
            settingsButton.GetComponent<SVGImage>().sprite = settingsSprite;

        } else
        {
            holdToFlyPanel.SetActive(true);
            settingsPanel.SetActive(true);
            settingsButton.GetComponent<SVGImage>().sprite = backSprite;
        }
    }
}
