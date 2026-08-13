using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PrefabCutsceneFinal : MonoBehaviour
{
    public GameObject panel;          // FullScreenPanel
    public Image imageUI;             // FullImage
    public AudioSource audioUI;       // CutsceneAudio

    public Sprite fullScreenSprite;   // immagine 1
    public Sprite secondSprite;       // immagine 2
    public AudioClip audioClip;       // audio

    void OnMouseDown()
    {
        StartCoroutine(Sequence());
    }

    IEnumerator Sequence()
    {
        // --- PRIMA IMMAGINE + AUDIO ---
        panel.SetActive(true);
        imageUI.color = Color.white;
        imageUI.sprite = fullScreenSprite;

        audioUI.clip = audioClip;
        audioUI.Play();

        // Aspetta fine audio
        yield return new WaitForSeconds(audioUI.clip.length);

        // --- SECONDA IMMAGINE + AUDIO DI NUOVO ---
        imageUI.sprite = secondSprite;

        audioUI.Stop();
        audioUI.Play();   // riparte da capo

        // Aspetta fine audio
        yield return new WaitForSeconds(audioUI.clip.length);

        // --- CAMBIO SCENA ---
        SceneManager.LoadScene("mainmenu");
    }
}