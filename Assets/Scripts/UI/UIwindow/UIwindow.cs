using UnityEngine;
using DG.Tweening;

namespace AngelsAgainstDemons
{
    public abstract class UIwindow : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        private Tween _tween;
        protected float DurationShowHide = 0.25f;
        public float DurationHideShow { get => DurationShowHide; }

        protected RootUI RootUI;
        protected GameplayEntryPoint GameplayEntryPoint;

        public virtual void Init()
        {
            _canvasGroup = gameObject.GetComponent<CanvasGroup>();
            Hide();
        }

        public virtual void Init(RootUI rootUI, GameplayEntryPoint gameplayEntryPoint)
        {
            RootUI = rootUI;
            GameplayEntryPoint = gameplayEntryPoint;
            Init();
        }

        public virtual void Show()
        {
            _tween = _canvasGroup
                .DOFade(1.0f, DurationShowHide).From(0.0f);
        }

        public virtual void Hide()
        {
            _tween = _canvasGroup
                .DOFade(0.0f, DurationShowHide).From(1.0f);
        }

        private void OnDisable()
        {
            _tween.Kill(true);
        }
    }
}
