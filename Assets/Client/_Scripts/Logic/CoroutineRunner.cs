using UnityEngine;

namespace Scripts.Logic
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}

