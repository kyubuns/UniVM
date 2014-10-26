using System;
using UnityEngine;

namespace UniVM
{
  [RequireComponent(typeof(UILabel))]
  [AddComponentMenu("UniVM/Binding/UILabel/Text")]
  public sealed class UILabelTextBinding : Binding<string, UILabel, StringProperty>
  {
    protected override string GetComponentValue(UILabel component)
    {
      return component.text;
    }

    protected override void UpdateComponent(UILabel component, string value)
    {
      component.text = value;
    }
  }
}
