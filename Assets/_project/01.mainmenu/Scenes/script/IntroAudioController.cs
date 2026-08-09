using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroAudioController : MonoBehaviour
{
    public AudioSource introAudio;
        void OnEnable()
        {
        introAudio.time = 0f;
        introAudio.Play();
        Invoke("CaricaGioco", introAudio.clip.length);
    }

    void CaricaGioco()
   {
        SceneManager.LoadScene("livello di gioco"); 
    }
}
