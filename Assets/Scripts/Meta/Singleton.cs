using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected bool destroyOnLoad = true;

    protected virtual void Awake()
    {
        //Check if the instance is already set
        if (Instance == null)
        {
            //Set the instance
            Instance = GetComponent<T>();

            //Set the persistent status
            if (!destroyOnLoad) DontDestroyOnLoad(gameObject);
        } else
        {
            Debug.LogWarning("Only 1 instance of a singleton object should exist in a scene!");

            //Destroy any NOT so single singleton
            Destroy(gameObject);
        }
    }
}
