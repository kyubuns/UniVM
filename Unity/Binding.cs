using System;
using UnityEngine;

namespace UniVM
{
	[Serializable]
	public abstract class Binding : MonoBehaviour
	{
		public string Path;

		public IProperty Property { get; set; }
	}

    [Serializable]
    public abstract class Binding<T, TComponent, TProperty> : Binding
		where TComponent : Component
		where TProperty : Property<T>
    {
		private TComponent component;

		public new TProperty Property { get; set; }

		private Action OnPropertyChange;

		void Awake()
		{
			component = GetComponent<TComponent>();
			OnPropertyChange = () => UpdateComponent(component, Property.Value);
		}

		void Start()
		{
			this.Property = base.Property as TProperty;
			Property.OnChange += OnPropertyChange;
		}

		void OnDestroy()
		{
			Property.OnChange -= OnPropertyChange;
		}

		void Update()
		{
			Property.Value = GetComponentValue(component);
		}

		protected abstract T GetComponentValue(TComponent component);
		protected abstract void UpdateComponent(TComponent component, T value);
    }
}
