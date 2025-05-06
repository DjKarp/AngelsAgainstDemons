using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AngelsAgainstDemons
{
    public class GameEntryPoint
    {
        public static GameEntryPoint Instance;        

        private CorutinesInScene _corutinesInScene;
        private RootUI _rootUI;

        private GameEntryPoint()
        {
            _corutinesInScene = new GameObject("[Coroutines]").AddComponent<CorutinesInScene>();
            Object.DontDestroyOnLoad(_corutinesInScene.gameObject);

            var rootUIprefab = Resources.Load<RootUI>("RootUI");
            _rootUI = Object.Instantiate(rootUIprefab);
            Object.DontDestroyOnLoad(_rootUI);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutoStartGame()
        {
            Application.targetFrameRate = 60;

            Instance = new GameEntryPoint();
            Instance.StartGame();
        }

        private void StartGame()
        {
            _corutinesInScene.StartCoroutine(LoadAndStartGame());
        }

        private IEnumerator LoadScene(string sceneName)
        {
            AsyncOperation LoadAsync = SceneManager.LoadSceneAsync(sceneName);

            while (!LoadAsync.isDone)
            {
                yield return new WaitForEndOfFrame();
            }

            yield return LoadAsync;
        }

        private IEnumerator LoadAndStartGame()
        {
            yield return LoadScene(Scenes.Scene_Bootstrap);
            yield return new WaitForEndOfFrame();
            yield return LoadScene(Scenes.Scene_Game);

            var sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();

            sceneEntryPoint?.Run(_rootUI);
        }
    }
}
