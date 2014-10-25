using System;
using UnityEngine;
using UnityEngine.UI;

namespace UniVM
{
    [Serializable]
	[AddComponentMenu("UniVM/Binding/Text Binding")]
    [RequireComponent(typeof(Text))]
    public sealed class TextBinding : Binding<string, Text, StringProperty>
    {
		protected override string GetComponentValue(Text component)
		{
			return component.text;
		}

		protected override void UpdateComponent(Text component, string value)
		{
			component.text = value;
		}
	}
}
