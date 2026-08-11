using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject menuPanel;

    public void TornaAlMenu()
    {
        creditsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}