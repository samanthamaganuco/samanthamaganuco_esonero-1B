using UnityEngine;

public class ClickObject : MonoBehaviour
{
    public AudioSource audioSource;   // Suono
    public Light glowLight;           // Luce
    public float vibrationAmount = 0.05f;  // Intensità vibrazione
    public float vibrationTime = 0.1f;     // Durata vibrazione

    Vector3 originalPos;

    void Start()
    {
        originalPos = transform.localPosition;

        if (glowLight != null)
            glowLight.enabled = false;   // La luce parte spenta
    }

    void OnMouseDown()
    {
        // SUONO
        if (audioSource != null)
            audioSource.Play();

        // LUCE
        if (glowLight != null)
            StartCoroutine(FlashLight());

        // VIBRAZIONE
        StartCoroutine(Vibrate());
    }

    System.Collections.IEnumerator FlashLight()
    {
        glowLight.enabled = true;
        yield return new WaitForSeconds(0.15f);
        glowLight.enabled = false;
    }

    System.Collections.IEnumerator Vibrate()
    {
        float t = 0f;

        while (t < vibrationTime)
        {
            t += Time.deltaTime;
            transform.localPosition = originalPos + Random.insideUnitSphere * vibrationAmount;
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
