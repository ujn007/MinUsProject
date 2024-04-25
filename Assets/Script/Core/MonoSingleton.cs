using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    private static bool isDestroyed = false;

    public static T Instance
    {
        get
        {
            if (isDestroyed)
                _instance = null;

            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<T>();

                if (_instance == null)
                    Debug.LogError($"{typeof(T).Name} singleton is not exist");
            }

            return _instance;
        }
    }
}
