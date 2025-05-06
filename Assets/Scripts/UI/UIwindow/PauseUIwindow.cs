using UnityEngine;
using UnityEngine.UI;

namespace AngelsAgainstDemons
{
    public class PauseUIwindow : UIwindow
    {
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _backButton;

        public override void Init()
        {
            base.Init();

            _menuButton.onClick.AddListener(() => MenuButtonClick());
            _backButton.onClick.AddListener(() => BackButtonClick());
        }

        private void MenuButtonClick()
        {
            RootUI.ChangeWindowUI(RootUI.MainMenuUIwindow);
        }

        private void BackButtonClick()
        {
            RootUI.ChangeWindowUIonPrevious();
        }
    }
}
