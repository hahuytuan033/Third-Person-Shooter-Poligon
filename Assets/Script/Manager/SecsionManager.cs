using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tundayne
{
    public class SecsionManager : MonoBehaviour
    {
        public GameEvent onGameStart;
        public GameEvent onSceneLoadedAdditive;
        public GameEvent onSceneLoadedSingle;

        public void LoadSceneAsyncAdditive(string lvl)
        {
            StartCoroutine(LoadSceneAsyncAdditive_Actual(lvl));
        }

        public void LoadSceneAsyncSingle(string lvl)
        {
            StartCoroutine(LoadSceneAsyncSingle_Actual(lvl));
        }

        IEnumerator LoadSceneAsyncAdditive_Actual(string lvl)
        {
            yield return SceneManager.LoadSceneAsync(lvl, LoadSceneMode.Additive);
            if (onSceneLoadedAdditive != null)
            {
                onSceneLoadedAdditive.Raise();
            }
        }

        IEnumerator LoadSceneAsyncSingle_Actual(string lvl)
        {
            yield return SceneManager.LoadSceneAsync(lvl, LoadSceneMode.Single);
            if (onSceneLoadedSingle != null)
            {
                onSceneLoadedSingle.Raise();
            }
        }
    }
}

