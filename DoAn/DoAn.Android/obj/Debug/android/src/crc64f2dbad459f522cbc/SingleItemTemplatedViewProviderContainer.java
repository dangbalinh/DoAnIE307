package crc64f2dbad459f522cbc;


public class SingleItemTemplatedViewProviderContainer
	extends crc64f2dbad459f522cbc.TemplatedViewProviderContainer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("DevExpress.XamarinForms.Scheduler.Android.Internal.SingleItemTemplatedViewProviderContainer, DevExpress.XamarinForms.Scheduler.Android", SingleItemTemplatedViewProviderContainer.class, __md_methods);
	}


	public SingleItemTemplatedViewProviderContainer ()
	{
		super ();
		if (getClass () == SingleItemTemplatedViewProviderContainer.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Scheduler.Android.Internal.SingleItemTemplatedViewProviderContainer, DevExpress.XamarinForms.Scheduler.Android", "", this, new java.lang.Object[] {  });
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
