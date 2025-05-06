using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AngelsAgainstDemons
{
    public class FormController : MonoBehaviour
    {
        private GameObject _changeFormFX;
        private Transform _playerTransform;
        private Animator _playerAnimator;

        private bool _isFormChanged = false;

        protected Button _jumpButton;

        private Form _currentForm = Form.Human;
        private enum Form
        {
            Human,
            Angel, 
            Demon
        }

        public void Init(GameObject changeFormFX, Transform playerTransform, Button jumpButton)
        {
            _changeFormFX = changeFormFX;
            _playerTransform = playerTransform;
            _playerAnimator = _playerTransform.gameObject.GetComponent<Animator>();
            _jumpButton = jumpButton;
            if (_jumpButton != null)
                _jumpButton.onClick.AddListener(() => StartCoroutine(ChangeForm()));
        }

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !_isFormChanged)
                StartCoroutine(ChangeForm());
        }

        private IEnumerator ChangeForm()
        {
            if (!_isFormChanged)
            {
                _isFormChanged = true;
                var changeFormFX = Instantiate(_changeFormFX, _playerTransform.position + Vector3.down, Quaternion.identity);
                yield return new WaitForSeconds(0.2f);

                bool isRun = _playerAnimator.GetBool("isRun");
                bool isJump = _playerAnimator.GetBool("isJump");

                switch (_currentForm)
                {
                    case Form.Human:
                        _playerAnimator.runtimeAnimatorController = Resources.Load("Angel") as RuntimeAnimatorController;
                        _currentForm = Form.Angel;
                        break;

                    case Form.Angel:
                        _playerAnimator.runtimeAnimatorController = Resources.Load("Demon") as RuntimeAnimatorController;
                        _currentForm = Form.Demon;
                        break;

                    case Form.Demon:
                        _playerAnimator.runtimeAnimatorController = Resources.Load("Player") as RuntimeAnimatorController;
                        _currentForm = Form.Human;
                        break;
                }

                _playerAnimator.SetBool("isRun", isRun);
                _playerAnimator.SetBool("isJump", isJump);

                Destroy(changeFormFX);
                _isFormChanged = false;
            }
        }
    }
}
