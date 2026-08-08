using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;
    public Color fadeColor = Color.black;

    public bool showBrandSplash = true;
    public float brandSplashHoldTime = 1.2f;

    private void Start()
    {
        if (showBrandSplash && SceneManager.GetActiveScene().buildIndex == 0)
            StartCoroutine(ShowBrandSplash());
        else
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

    IEnumerator ShowBrandSplash()
    {
        GameObject overlay = CreateBrandSplashOverlay();
        if (overlay == null)
        {
            StartCoroutine(StartScene());
            yield break;
        }

        yield return new WaitForSeconds(brandSplashHoldTime);

        Image bg = overlay.GetComponent<Image>();
        Image logo = overlay.transform.GetChild(0).GetComponent<Image>();

        float logoFade = fadeDuration * 0.5f;
        float timer = 0f;
        while (timer < logoFade)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / logoFade);
            Color c = logo.color;
            c.a = alpha;
            logo.color = c;
            yield return null;
        }

        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            Color c = bg.color;
            c.a = alpha;
            bg.color = c;
            yield return null;
        }

        Destroy(overlay);
    }

    GameObject CreateBrandSplashOverlay()
    {
        Sprite logo = Resources.Load<Sprite>("SplashLogo");
        if (logo == null)
            return null;

        var canvasGo = new GameObject("BrandSplash");
        Canvas canvas = canvasGo.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 999;

        CanvasScaler scaler = canvasGo.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920, 1080);

        Image bg = canvasGo.AddComponent<Image>();
        bg.color = Color.black;
        bg.raycastTarget = false;

        var logoGo = new GameObject("Logo");
        logoGo.transform.SetParent(canvasGo.transform, false);

        Image logoImage = logoGo.AddComponent<Image>();
        logoImage.sprite = logo;
        logoImage.raycastTarget = false;

        RectTransform rt = logoImage.rectTransform;
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);
        float width = 700f;
        rt.sizeDelta = new Vector2(width, width * logo.rect.height / logo.rect.width);

        return canvasGo;
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
