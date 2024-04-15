using UnityEngine;
using UnityEngine.EventSystems;

public class HoverToShowHideUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject objectToShow1;
    [SerializeField] private GameObject objectToShow2;
    [SerializeField] GameObject hitSoundPrefab; // Ссылка на префаб звука

    private void Start()
    {
        hitSoundPrefab = Resources.Load<GameObject>("HitSound");
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
            objectToShow1.SetActive(true);
            Instantiate(hitSoundPrefab, transform.position, transform.rotation);
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
