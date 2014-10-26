using System;
using UnityEngine;

namespace UniVM
{
  public abstract class EventBinding : MonoBehaviour
  {
    public string Path;
    public Action Event;
  }
}
