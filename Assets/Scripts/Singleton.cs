using UnityEngine;

namespace MonkeyGame.Scripts
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        _instance = new GameObject().AddComponent<T>();
                        _instance.name = typeof(T).ToString();
                    }
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance != null)
                Destroy(this);
            DontDestroyOnLoad(this);
            
        }
    }
}
