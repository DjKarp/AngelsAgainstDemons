using UnityEngine;
using UnityEngine.UI;

namespace AngelsAgainstDemons
{
    public class GameplayUIwindow : UIwindow
    {
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _pauseButton;

        public override void Init()
        {
            base.Init();

            _menuButton.onClick.AddListener(() => MenuButtonClick());
            _pauseButton.onClick.AddListener(() => PauseButtonClick());
        }

        private void MenuButtonClick()
        {
            RootUI.ChangeWindowUI(RootUI.MainMenuUIwindow);
        }

        private void PauseButtonClick()
        {
            RootUI.ChangeWindowUI(RootUI.PauseUIwindow);
        }

        private void OnDestroy()
        {
            _menuButton.onClick.RemoveAllListeners();
            _pauseButton.onClick.RemoveAllListeners();
        }
    }
}
