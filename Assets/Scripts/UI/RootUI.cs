using System.Collections;
using UnityEngine;

namespace AngelsAgainstDemons
{
    public class RootUI : MonoBehaviour
    {
        public Transform SceneConteinerUI { get => gameObject.transform; }

        private UIwindow _currentWindowUI;
        private UIwindow _previousWindowUI;

        private GameplayUIwindow _gameplayUIwindow;
        private SettingsUIwindow _settingsUIwindow;
        private MainMenuUIwindow _mainMenuUIwindow;
        private PauseUIwindow _pauseUIwindow;

        public GameplayUIwindow GameplayUIwindow { get => _gameplayUIwindow; }
        public SettingsUIwindow SettingsUIwindow { get => _settingsUIwindow; }
        public MainMenuUIwindow MainMenuUIwindow { get => _mainMenuUIwindow; }
        public PauseUIwindow PauseUIwindow { get => _pauseUIwindow; }

        private GameObject _joystick;
        private GameplayEntryPoint _gameplayEntryPoint;


        public void Init(GameplayEntryPoint gameplayEntryPoint)
        {
            _gameplayEntryPoint = gameplayEntryPoint;

            _mainMenuUIwindow = Instantiate(Resources.Load<MainMenuUIwindow>("MainMenuUI"), SceneConteinerUI);
            _mainMenuUIwindow.Init(this, _gameplayEntryPoint);

            _gameplayUIwindow = Instantiate(Resources.Load<GameplayUIwindow>("GameplayUI"), SceneConteinerUI);
            _gameplayUIwindow.Init(this, _gameplayEntryPoint);

            _settingsUIwindow = Instantiate(Resources.Load<SettingsUIwindow>("SettingsUI"), SceneConteinerUI);
            _settingsUIwindow.Init(this, _gameplayEntryPoint);

            _pauseUIwindow = Instantiate(Resources.Load<PauseUIwindow>("PauseUI"), SceneConteinerUI);
            _pauseUIwindow.Init(this, _gameplayEntryPoint);

            _currentWindowUI = _mainMenuUIwindow;
            AttachUI(_currentWindowUI.gameObject);
        }

        public void InitialiseJoystick(GameObject joystikUI)
        {
            _joystick = joystikUI;
            _joystick.transform.SetSiblingIndex(0);
        }

        public void ChangeWindowUIonPrevious()
        {
            ChangeWindowUI(_previousWindowUI);
        }

        public void ChangeWindowUI(UIwindow uIwindow)
        {
            _currentWindowUI?.Hide();
            StartCoroutine(AddedNewWindowUI(uIwindow));
        }

        private IEnumerator AddedNewWindowUI(UIwindow uIwindow)
        {
            yield return new WaitForSeconds(uIwindow.DurationHideShow);

            _previousWindowUI = _currentWindowUI;
            _currentWindowUI = uIwindow;
            AttachUI(uIwindow.gameObject);
        }

        private void ClearAttachUI()
        {
            int childCount = SceneConteinerUI.childCount;
            for (int i = 0; i < childCount; i++)
                SceneConteinerUI.GetChild(i).gameObject.SetActive(false);
            if (_joystick != null)
                _joystick.SetActive(true);
        }

        private void AttachUI(GameObject sceneUI_GO)
        {
            ClearAttachUI();

            sceneUI_GO.transform.SetParent(SceneConteinerUI, false);
            sceneUI_GO.gameObject.SetActive(true);
            _currentWindowUI.Show();
        }
    }
}
