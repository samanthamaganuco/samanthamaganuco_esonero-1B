using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroSequence : MonoBehaviour
{
    public AudioSource menuAudio;           // la musica del menu
    public string livelloDiGioco = "livello di gioco";
    public float attesa = 15f;              // 15 secondi REALI

    void Start()
    {
        // Parte la musica del menu
        if (menuAudio != null)
        {
            menuAudio.loop = true;
            menuAudio.Play();
        }
    }

    // CHIAMA QUESTA FUNZIONE QUANDO PREMI PLAY
    public void Avvia()
    {
        // Qui fai apparire il tuo dialogo intro
        // (non tocco nulla, lo fai tu)

        StartCoroutine(Sequenza());
    }

    IEnumerator Sequenza()
    {
        // Aspetta 15 secondi REALI
        yield return new WaitForSeconds(attesa);

        // Cambia scena
        SceneManager.LoadScene(livelloDiGioco);
    }
}