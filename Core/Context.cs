using System;

namespace UniVM
{
  public abstract class Context
  {
    public IProperty FindProperty(string propertyName)
    {
      return GetType().GetProperty(propertyName).GetValue(this, null) as IProperty;
    }

    public Action FindMethod(string methodName)
    {
      var methodInfo = GetType().GetMethod(methodName);
      return () => { methodInfo.Invoke(this, null); };
    }
  }
}
