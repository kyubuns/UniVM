using UnityEngine;
using UniVM;

public class SampleContext : Context
{
	public StringProperty SampleText { get; set; }

	public SampleContext()
	{
		SampleText = new StringProperty();
	}
}

public class SampleViewModel : MonoBehaviour
{
	public ViewRoot View;
	public SampleContext Context;

	void Awake()
	{
		Context = new SampleContext();
		View.Context = Context;
	}

	void Update()
	{
		Context.SampleText.Value = "FUN for ALL, ALL for FUN.";
	}
}