using System;
using UnityEngine;
using UnityEngine.Events;

namespace Utils.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIPanel : MonoBehaviour
    {
        public UnityEvent OnShowEvent = new UnityEvent();
        public UnityEvent OnHideEvent = new UnityEvent();
        public bool ShowOnStart = false;

        protected CanvasGroup canvasGroup;

        protected virtual void Start()
        {
            canvasGroup = this.GetComponent<CanvasGroup>();

            if (ShowOnStart)
                Show();
            else
                Hide();
        }

        public bool IsVisible()
        {
            return canvasGroup.alpha > 0;
        }

        /// <summary>
        /// Active the UI panel and call show events
        /// </summary>
        public virtual void Show()
        {
            OnShowEvent.Invoke();
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
        }

        /// <summary>
        /// Unactive the UI panel and call hide events
        /// </summary>
        public virtual void Hide()
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            OnHideEvent.Invoke();
        }

        public virtual void Toggle()
        {
            ((canvasGroup.alpha > 0) ? (Action)Hide : Show)();
        }
    }
}