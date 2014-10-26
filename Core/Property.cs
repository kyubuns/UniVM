using UnityEngine;
using System;

namespace UniVM
{
  public interface IProperty
  {
    event Action OnChange;
  }

  public abstract class Property<T> : IProperty
  {
    protected T value;
    public abstract T Value { get; set; }

    public event Action OnChange;

    protected void Notify()
    {
      if (OnChange != null)
      {
        OnChange();
      }
    }

    protected virtual bool CompareDifference(T t1, T t2)
    {
      return t1.Equals(t2);
    }
  }

  public abstract class ClassProperty<T> : Property<T> where T : class
  {
    public override T Value
    {
      get
      {
        return this.value;
      }
      set
      {
        if (value == null && this.value == null) return;

        if (value != null && this.value != null)
        {
          if (CompareDifference(value, this.value))
          {
            this.value = value;
            Notify();
          }

          return;
        }

        this.value = value;
        Notify();
      }
    }
  }

  public sealed class StringProperty : ClassProperty<string>
  {
    protected override bool CompareDifference(string t1, string t2)
    {
      return t1 != t2;
    }
  }
}
