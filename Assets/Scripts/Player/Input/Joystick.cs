using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace AngelsAgainstDemons
{
    public abstract class Joystick : GameInput, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Image _joystickTapArea;
        [SerializeField] private Image _joystickFon;
        [SerializeField] private Image _joystick;

        [SerializeField] private Color _colorInactiveJoystick;
        [SerializeField] private Color _colorActiveJoystick;

        [SerializeField] private Button _changeFormButton;

        private Vector2 _joystickFonStartPosition;
        private bool _isActiveJoystick = false;        

        private Vector2 joystickFonPosition;

        private bool _isActive = true;

        private void Start()
        {
            if (_isActive)
            {
                SwitchJoysticSettings();

                _joystickFonStartPosition = _joystickFon.rectTransform.anchoredPosition;
            }
        }

        private void SwitchJoysticSettings()
        {
            if (_isActiveJoystick)
            {
                _joystick.color = _colorActiveJoystick;
                _joystickFon.color = _colorActiveJoystick;
                _isActiveJoystick = false;
            }
            else
            {
                _joystick.color = _colorInactiveJoystick;
                _joystickFon.color = _colorInactiveJoystick;
                _isActiveJoystick = true;
            }
        }


        public void OnDrag(PointerEventData eventData)
        {
            if (_isActive && RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickFon.rectTransform, eventData.position, null, out joystickFonPosition))
            {
                joystickFonPosition.x = (joystickFonPosition.x * 2.0f) / _joystickFon.rectTransform.sizeDelta.x;
                joystickFonPosition.y = (joystickFonPosition.y * 2.0f) / _joystickFon.rectTransform.sizeDelta.y;

                JoystickDirection = new Vector2(joystickFonPosition.x, joystickFonPosition.y);
                JoystickDirection = JoystickDirection.magnitude > 1.0f ? JoystickDirection.normalized : JoystickDirection;

                _joystick.rectTransform.anchoredPosition = new Vector2(JoystickDirection.x * (_joystickFon.rectTransform.sizeDelta.x / 2.0f), JoystickDirection.y * (_joystickFon.rectTransform.sizeDelta.y / 2.0f));                
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_isActive)
            {
                SwitchJoysticSettings();

                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickTapArea.rectTransform, eventData.position, null, out joystickFonPosition))
                {
                    _joystickFon.rectTransform.anchoredPosition = new Vector2(joystickFonPosition.x, joystickFonPosition.y);
                }
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_isActive)
            {
                _joystickFon.rectTransform.anchoredPosition = _joystickFonStartPosition;

                SwitchJoysticSettings();

                JoystickDirection = Vector2.zero;
                _joystick.rectTransform.anchoredPosition = Vector2.zero;
            }
        }

        public void HideInputOnDevice()
        {
            _isActive = false;
            _joystickTapArea.gameObject.SetActive(false);
            _joystickFon.gameObject.SetActive(false);
            _joystick.gameObject.SetActive(false);
        }        

        public Button GetJumpButton()
        {
            return _changeFormButton;
        }

        private void OnDestroy()
        {

        }
    }
}