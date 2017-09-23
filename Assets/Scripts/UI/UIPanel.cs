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
		public CanvasGroup CanvasGroup;

		protected virtual void Start()
		{
			if (ShowOnStart)
				Show();
			else
				Hide();
		}

		public bool IsVisible()
		{
			return CanvasGroup.alpha > 0;
		}

		/// <summary>
		/// Active the UI panel and call show events
		/// </summary>
		public virtual void Show()
		{
			OnShowEvent.Invoke();
			CanvasGroup.alpha = 1;
			CanvasGroup.blocksRaycasts = true;
		}

		/// <summary>
		/// Unactive the UI panel and call hide events
		/// </summary>
		public virtual void Hide()
		{
			CanvasGroup.alpha = 0;
			CanvasGroup.blocksRaycasts = false;
			OnHideEvent.Invoke();
		}

		public virtual void Toggle()
		{
			((CanvasGroup.alpha > 0) ? (Action)Hide : Show)();
		}
	}
}