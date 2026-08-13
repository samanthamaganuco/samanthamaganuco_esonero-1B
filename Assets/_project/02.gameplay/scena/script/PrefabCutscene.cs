using UnityEngine;
using UnityEngine.UI;

public class PrefabCutscene : MonoBehaviour
{
    public GameObject panel;          // FullScreenPanel
    public Image imageUI;             // FullImage
    public AudioSource audioUI;       // CutsceneAudio

    public Sprite fullScreenSprite;   // Sprite del prefab
    public AudioClip audioClip;       // Audio del prefab

    private void OnMouseDown()
    {
        panel.SetActive(true);
        imageUI.sprite = fullScreenSprite;

        audioUI.clip = audioClip;
        audioUI.Play();

        StartCoroutine(CloseAfterAudio());
    }

    private System.Collections.IEnumerator CloseAfterAudio()
    {
        yield return new WaitForSeconds(audioUI.clip.length);
        panel.SetActive(false);
    }
}