package crc64f2dbad459f522cbc;


public class SingleItemCustomViewProviderContainer
	extends crc64f2dbad459f522cbc.CustomViewProviderContainer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("DevExpress.XamarinForms.Scheduler.Android.Internal.SingleItemCustomViewProviderContainer, DevExpress.XamarinForms.Scheduler.Android", SingleItemCustomViewProviderContainer.class, __md_methods);
	}


	public SingleItemCustomViewProviderContainer ()
	{
		super ();
		if (getClass () == SingleItemCustomViewProviderContainer.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Scheduler.Android.Internal.SingleItemCustomViewProviderContainer, DevExpress.XamarinForms.Scheduler.Android", "", this, new java.lang.Object[] {  });
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
