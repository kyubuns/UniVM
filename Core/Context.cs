
namespace UniVM
{
    public abstract class Context
    {
        public IProperty FindProperty(string propertyName)
        {
            return GetType().GetProperty(propertyName).GetValue(this, null) as IProperty;
        }
    }
}