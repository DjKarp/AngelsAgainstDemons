using UnityEngine;
using UnityEngine.UI;

namespace AngelsAgainstDemons
{
    public class ExitButton : MonoBehaviour
    {
        private Button _exitButton;

        private void Start()
        {
            _exitButton = gameObject.GetComponent<Button>();
            _exitButton.onClick.AddListener(() => Application.Quit());
        }

        private void OnDestroy()
        {
            _exitButton.onClick.RemoveAllListeners();
        }
    }
}
