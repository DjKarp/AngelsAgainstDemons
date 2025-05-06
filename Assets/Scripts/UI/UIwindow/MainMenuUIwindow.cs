using UnityEngine;
using UnityEngine.UI;

namespace AngelsAgainstDemons
{
    public class MainMenuUIwindow : UIwindow
    {
        [SerializeField] private Button _playButtonCC;
        [SerializeField] private Button _playButtonRG;
        [SerializeField] private Toggle _joystickToggle;

        public override void Init()
        {
            base.Init();

            _playButtonCC.onClick.AddListener(() => PlayGameWhitCharacterController());
            _playButtonRG.onClick.AddListener(() => StartGameWhitRigidbody());
        }

        private void PlayGameWhitCharacterController()
        {
            RootUI.ChangeWindowUI(RootUI.GameplayUIwindow);
            GameplayEntryPoint.Initialize(true, _joystickToggle.isOn);
        }

        private void StartGameWhitRigidbody()
        {
            RootUI.ChangeWindowUI(RootUI.GameplayUIwindow);
            GameplayEntryPoint.Initialize(false, _joystickToggle.isOn);
        }

        private void OnDestroy()
        {
            _playButtonCC.onClick.RemoveAllListeners();
            _playButtonCC.onClick.RemoveAllListeners();
        }
    }
}
