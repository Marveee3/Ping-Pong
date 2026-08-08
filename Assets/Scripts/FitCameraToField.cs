using UnityEngine;

public class FitCameraToField : MonoBehaviour
{
    public float halfX = 9.0f;
    public float halfY = 4.8f;

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float aspect = (float)Screen.width / Mathf.Max(1, Screen.height);
        cam.orthographicSize = Mathf.Max(halfY, halfX / aspect);
    }
}
