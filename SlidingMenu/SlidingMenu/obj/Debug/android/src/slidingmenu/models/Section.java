package slidingmenu.models;


public class Section
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SlidingMenu.Models.Section, SlidingMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Section.class, __md_methods);
	}


	public Section () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Section.class)
			mono.android.TypeManager.Activate ("SlidingMenu.Models.Section, SlidingMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public Section (java.lang.String p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == Section.class)
			mono.android.TypeManager.Activate ("SlidingMenu.Models.Section, SlidingMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
	}

	java.util.ArrayList refList;
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
