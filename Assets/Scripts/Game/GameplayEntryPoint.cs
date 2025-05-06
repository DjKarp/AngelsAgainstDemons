using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AngelsAgainstDemons
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        private RootUI _rootUI;
        private GameInput _inputMove;

        private Player _player;
        private PlayerRigidbody _playerRB;
        private PlayerCharacterController _playerCC;

        private Level _levelPrefab;
        private Level _level;

        private MovePlayer _movePlayer;

        private CameraController _cameraController;

        [SerializeField] private GameObject _changeFormFX;
        private FormController _formController;

        public void Run(RootUI rootUI)
        {
            _rootUI = rootUI;
            _rootUI.Init(this);
        }

        public void Initialize(bool isCharacterController, bool joystickControl)
        {
            if (_level != null)
                Destroy(_level.gameObject);

            if (_player != null)
                Destroy(_player.gameObject);

            if (isCharacterController)
            {
                _levelPrefab = Resources.Load<Level>("LevelCharacterController");
                _level = Instantiate(_levelPrefab);

                var playerCC_prefab = Resources.Load<PlayerCharacterController>("PlayerCharacterController");
                _playerCC = Instantiate(playerCC_prefab, _level.StartPointPosition, Quaternion.identity);

                _movePlayer = new MovePlayerCharacterController(_playerCC.GetComponent<CharacterController>());
                _player = _playerCC;
            }
            else
            {
                _levelPrefab = Resources.Load<Level>("LevelRigidbody");
                _level = Instantiate(_levelPrefab);

                var playerRB_prefab = Resources.Load<PlayerRigidbody>("PlayerRigidbody");
                _playerRB = Instantiate(playerRB_prefab, _level.StartPointPosition, Quaternion.identity);
                _movePlayer = new MovePlayerRigidbody(_playerRB.GetComponent<Rigidbody2D>());
                _player = _playerRB;
            }

            Button changeFormButton = null;
            if (joystickControl || (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer))
            {
                var joystickPrefab = Resources.Load<JoystickMove>("Joystick");
                var input = Instantiate(joystickPrefab, _rootUI.SceneConteinerUI) as JoystickMove;
                changeFormButton = input.GetJumpButton();
                _inputMove = input;
            }
            else
            {
                _inputMove = _player.gameObject.AddComponent<KeyboardMove>();
            }            

            _cameraController = FindFirstObjectByType<CameraController>();
            _cameraController.PlayerTransform = _player.gameObject.transform;

            _player.Init(_movePlayer, _inputMove);

            _rootUI.InitialiseJoystick(_inputMove.gameObject);

            _formController = _player.gameObject.AddComponent<FormController>();
            _formController.Init(_changeFormFX, _player.transform, changeFormButton);
        }
    }
}
