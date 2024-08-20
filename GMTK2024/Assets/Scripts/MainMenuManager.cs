
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject mainMenuPanel;
    public void CloseSetting()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
}
