package crc649ee09f68c265a75d;


public class DayViewRenderer
	extends crc649ee09f68c265a75d.DayViewBaseRenderer_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("DevExpress.XamarinForms.Scheduler.Android.DayViewRenderer, DevExpress.XamarinForms.Scheduler.Android", DayViewRenderer.class, __md_methods);
	}


	public DayViewRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == DayViewRenderer.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Scheduler.Android.DayViewRenderer, DevExpress.XamarinForms.Scheduler.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public DayViewRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == DayViewRenderer.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Scheduler.Android.DayViewRenderer, DevExpress.XamarinForms.Scheduler.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public DayViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == DayViewRenderer.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Scheduler.Android.DayViewRenderer, DevExpress.XamarinForms.Scheduler.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
