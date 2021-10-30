using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        
        if(GameObject.FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    
}
