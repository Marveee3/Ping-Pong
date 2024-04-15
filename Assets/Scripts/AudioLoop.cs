using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoop : MonoBehaviour
{
    private static bool scriptStarted = false;

    void Awake()
    {
        if (!scriptStarted)
        {
            DontDestroyOnLoad(gameObject);
            scriptStarted = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
