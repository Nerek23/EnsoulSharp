using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Lifetime;
using System.Security;

namespace System.Runtime.Remoting
{
	/// <summary>Wraps marshal-by-value object references, allowing them to be returned through an indirection.</summary>
	// Token: 0x020007A2 RID: 1954
	[ClassInterface(ClassInterfaceType.AutoDual)]
	[ComVisible(true)]
	public class ObjectHandle : MarshalByRefObject, IObjectHandle
	{
		// Token: 0x060055A7 RID: 21927 RVA: 0x0012F823 File Offset: 0x0012DA23
		private ObjectHandle()
		{
		}

		/// <summary>Initializes an instance of the <see cref="T:System.Runtime.Remoting.ObjectHandle" /> class, wrapping the given object <paramref name="o" />.</summary>
		/// <param name="o">The object that is wrapped by the new <see cref="T:System.Runtime.Remoting.ObjectHandle" />.</param>
		// Token: 0x060055A8 RID: 21928 RVA: 0x0012F82B File Offset: 0x0012DA2B
		public ObjectHandle(object o)
		{
			this.WrappedObject = o;
		}

		/// <summary>Returns the wrapped object.</summary>
		/// <returns>The wrapped object.</returns>
		// Token: 0x060055A9 RID: 21929 RVA: 0x0012F83A File Offset: 0x0012DA3A
		public object Unwrap()
		{
			return this.WrappedObject;
		}

		/// <summary>Initializes the lifetime lease of the wrapped object.</summary>
		/// <returns>An initialized <see cref="T:System.Runtime.Remoting.Lifetime.ILease" /> that allows you to control the lifetime of the wrapped object.</returns>
		// Token: 0x060055AA RID: 21930 RVA: 0x0012F844 File Offset: 0x0012DA44
		[SecurityCritical]
		public override object InitializeLifetimeService()
		{
			MarshalByRefObject marshalByRefObject = this.WrappedObject as MarshalByRefObject;
			if (marshalByRefObject != null && marshalByRefObject.InitializeLifetimeService() == null)
			{
				return null;
			}
			return (ILease)base.InitializeLifetimeService();
		}

		// Token: 0x040026F9 RID: 9977
		private object WrappedObject;
	}
}
