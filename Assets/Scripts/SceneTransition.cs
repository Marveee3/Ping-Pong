using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;
    public Color fadeColor = Color.black;

    private void Start()
    {
        StartCoroutine(StartScene());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TransitionToScene(0);
        }
    }

    IEnumerator StartScene()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = fadeColor;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha);
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);
    }

    public void TransitionToScene(int sceneIndex)
    {
        StartCoroutine(Transition(sceneIndex));
    }

    IEnumerator Transition(int sceneIndex)
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 0f);

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha);
            yield return null;
        }

        SceneManager.LoadScene(sceneIndex);
    }
}
