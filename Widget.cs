using System;
using UnityEngine;

namespace Gruel.Widget {
	public abstract class Widget : MonoBehaviour {
	
#region Properties
		/// <summary>
		/// Whether the widget is active or not.
		/// </summary>
		public bool Active {
			get => _active;
			set => SetActive(value);
		}

		public bool Initialized => _initialized;

		/// <summary>
		/// Priority used to determine which Widget is rendered ontop of others.
		/// 0 is the highest priority.
		/// </summary>
		public int OrderPriority {
			get => _orderPriority;
			protected set => _orderPriority = value;
		}
#endregion Properties

#region Fields
		[Header("Widget")]
		[SerializeField] protected int _orderPriority = 1;
		
		protected bool _active;
		protected bool _initialized;
#endregion Fields

#region Public Methods
		/// <summary>
		/// Initialize widget.
		/// </summary>
		/// <param name="onInitialized"></param>
		public virtual void Init(Action onInitialized = null) {
			_initialized = true;
			onInitialized?.Invoke();
		}

		/// <summary>
		/// Destroys the widget.
		/// It's up to the widget to destroy itself.
		/// This allows it to do any necessary cleanup or out animations before it gets destroyed.
		/// </summary>
		public virtual void Remove(Action onRemoved = null) {
			Destroy(gameObject);
			onRemoved?.Invoke();
		}
#endregion Public Methods
		
#region Protected Methods
		protected virtual void SetActive(bool active) {
			_active = active;
		}
#endregion Protected Methods

	}
}