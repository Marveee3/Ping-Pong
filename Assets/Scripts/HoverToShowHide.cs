using UnityEngine;
using UnityEngine.EventSystems;

public class HoverToShowHideUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject objectToShow1;
    [SerializeField] private GameObject objectToShow2;

    private AudioSource audioSource;
    private AudioClip hitSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        GameObject prefab = Resources.Load<GameObject>("HitSound");
        if (prefab != null)
        {
            AudioSource prefabSource = prefab.GetComponent<AudioSource>();
            if (prefabSource != null)
            {
                hitSound = prefabSource.clip;
                audioSource.volume = prefabSource.volume;
            }
        }

        // Скрываем объекты при старте
        if (objectToShow1 != null)
            objectToShow1.SetActive(false);
        if (objectToShow2 != null)
            objectToShow2.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // При наведении курсора показываем объекты
        if (objectToShow1 != null)
        {
            objectToShow1.SetActive(true);
            if (hitSound != null && audioSource != null)
                audioSource.PlayOneShot(hitSound);
        }
        if (objectToShow2 != null)
            objectToShow2.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // При убирании курсора скрываем объекты
        if (objectToShow1 != null)
            objectToShow1.SetActive(false);
        if (objectToShow2 != null)
            objectToShow2.SetActive(false);
    }
}
