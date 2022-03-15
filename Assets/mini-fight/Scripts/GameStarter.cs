using MiniFight.Contexts;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniFight
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private UISceneContext _uiScenePrefab;
        [SerializeField] private FightSceneContext _fightScenePrefab;

        private ContextsMediator contexts;

        private async void Start()
        {
            var uiContext = await SceneLoader.LoadScene<UISceneContext>("UIScene", LoadSceneMode.Additive, _uiScenePrefab);
            var fightContext = await SceneLoader.LoadScene<FightSceneContext>("FightScene", LoadSceneMode.Additive, _fightScenePrefab);

            contexts = new ContextsMediator(uiContext, fightContext);
            contexts.Match();
            contexts.Run();
        }

        private async Task LoadSceneAsync(string sceneName, LoadSceneMode mode)
        {
            var loadAsync = SceneManager.LoadSceneAsync(sceneName, mode);

            while (!loadAsync.isDone)
            {
                await Task.Yield();
            }

            var scene = SceneManager.GetSceneByName(sceneName);

            SceneManager.SetActiveScene(scene);
        }

        private void OnDestroy()
        {
            contexts?.Dispose();
        }
    }
}