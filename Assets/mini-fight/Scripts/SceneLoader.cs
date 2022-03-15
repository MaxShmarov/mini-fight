using MiniFight.Contexts;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniFight
{
    public static class SceneLoader
    {
        public static async Task<T> LoadScene<T>(string sceneName, LoadSceneMode mode, T contextPrefab) where T : BaseContext
        {
            var loadAsync = SceneManager.LoadSceneAsync(sceneName, mode);

            while (!loadAsync.isDone)
            {
                await Task.Yield();
            }

            var scene = SceneManager.GetSceneByName(sceneName);

            SceneManager.SetActiveScene(scene);

            var context = GameObject.Instantiate(contextPrefab);

            return context.GetComponent<T>();
        }
    }
}