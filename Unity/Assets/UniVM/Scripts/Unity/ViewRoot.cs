using UnityEngine;

namespace UniVM
{
	[AddComponentMenu("UniVM/View Root")]
    public class ViewRoot : MonoBehaviour
    {
        private Context context;
        public Context Context
        {
            get { return context; }
            set
            {
                context = value;
                if (context == null) return;

                foreach(var binding in GetComponentsInChildren<Binding>())
                    binding.Property = Context.FindProperty(binding.Path);
            }
        }
    }
}
