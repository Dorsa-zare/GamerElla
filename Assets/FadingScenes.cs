using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    public float fadeDuration = 1f;

    private void Start()
    {
        // Start with fade from black
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(int sceneIndex)
    {
        StartCoroutine(FadeOut(sceneIndex));
    }

    IEnumerator FadeIn()
    {
        float t = fadeDuration;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            fadeGroup.alpha = t / fadeDuration;
            yield return null;
        }
        fadeGroup.alpha = 0f;
    }

    IEnumerator FadeOut(int sceneIndex)
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeGroup.alpha = t / fadeDuration;
            yield return null;
        }

        SceneManager.LoadScene(sceneIndex);
    }
}