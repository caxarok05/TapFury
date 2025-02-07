using System.Collections;
using UnityEngine;

namespace Scripts.Logic
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}

