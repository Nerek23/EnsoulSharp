using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting.Messaging
{
	/// <summary>Selects the remoting surrogate that can be used to serialize an object that derives from a <see cref="T:System.MarshalByRefObject" />.</summary>
	// Token: 0x0200084E RID: 2126
	[SecurityCritical]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public class RemotingSurrogateSelector : ISurrogateSelector
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Messaging.RemotingSurrogateSelector" /> class.</summary>
		// Token: 0x06005B30 RID: 23344 RVA: 0x0013EC77 File Offset: 0x0013CE77
		public RemotingSurrogateSelector()
		{
			this._messageSurrogate = new MessageSurrogate(this);
		}

		/// <summary>Gets or sets the <see cref="T:System.Runtime.Remoting.Messaging.MessageSurrogateFilter" /> delegate for the current instance of the <see cref="T:System.Runtime.Remoting.Messaging.RemotingSurrogateSelector" />.</summary>
		/// <returns>The <see cref="T:System.Runtime.Remoting.Messaging.MessageSurrogateFilter" /> delegate for the current instance of the <see cref="T:System.Runtime.Remoting.Messaging.RemotingSurrogateSelector" />.</returns>
		// Token: 0x17000FC7 RID: 4039
		// (get) Token: 0x06005B32 RID: 23346 RVA: 0x0013ECAA File Offset: 0x0013CEAA
		// (set) Token: 0x06005B31 RID: 23345 RVA: 0x0013ECA1 File Offset: 0x0013CEA1
		public MessageSurrogateFilter Filter
		{
			get
			{
				return this._filter;
			}
			set
			{
				this._filter = value;
			}
		}

		/// <summary>Sets the object at the root of the object graph.</summary>
		/// <param name="obj">The object at the root of the object graph.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06005B33 RID: 23347 RVA: 0x0013ECB4 File Offset: 0x0013CEB4
		public void SetRootObject(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			this._rootObj = obj;
			SoapMessageSurrogate soapMessageSurrogate = this._messageSurrogate as SoapMessageSurrogate;
			if (soapMessageSurrogate != null)
			{
				soapMessageSurrogate.SetRootObject(this._rootObj);
			}
		}

		/// <summary>Returns the object at the root of the object graph.</summary>
		/// <returns>The object at the root of the object graph.</returns>
		// Token: 0x06005B34 RID: 23348 RVA: 0x0013ECF1 File Offset: 0x0013CEF1
		public object GetRootObject()
		{
			return this._rootObj;
		}

		/// <summary>Adds the specified <see cref="T:System.Runtime.Serialization.ISurrogateSelector" /> to the surrogate selector chain.</summary>
		/// <param name="selector">The next <see cref="T:System.Runtime.Serialization.ISurrogateSelector" /> to examine.</param>
		// Token: 0x06005B35 RID: 23349 RVA: 0x0013ECF9 File Offset: 0x0013CEF9
		[SecurityCritical]
		public virtual void ChainSelector(ISurrogateSelector selector)
		{
			this._next = selector;
		}

		/// <summary>Returns the appropriate surrogate for the given type in the given context.</summary>
		/// <param name="type">The <see cref="T:System.Type" /> for which the surrogate is requested.</param>
		/// <param name="context">The source or destination of serialization.</param>
		/// <param name="ssout">When this method returns, contains an <see cref="T:System.Runtime.Serialization.ISurrogateSelector" /> that is appropriate for the specified object type. This parameter is passed uninitialized.</param>
		/// <returns>The appropriate surrogate for the given type in the given context.</returns>
		// Token: 0x06005B36 RID: 23350 RVA: 0x0013ED04 File Offset: 0x0013CF04
		[SecurityCritical]
		public virtual ISerializationSurrogate GetSurrogate(Type type, StreamingContext context, out ISurrogateSelector ssout)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (type.IsMarshalByRef)
			{
				ssout = this;
				return this._remotingSurrogate;
			}
			if (RemotingSurrogateSelector.s_IMethodCallMessageType.IsAssignableFrom(type) || RemotingSurrogateSelector.s_IMethodReturnMessageType.IsAssignableFrom(type))
			{
				ssout = this;
				return this._messageSurrogate;
			}
			if (RemotingSurrogateSelector.s_ObjRefType.IsAssignableFrom(type))
			{
				ssout = this;
				return this._objRefSurrogate;
			}
			if (this._next != null)
			{
				return this._next.GetSurrogate(type, context, out ssout);
			}
			ssout = null;
			return null;
		}

		/// <summary>Returns the next <see cref="T:System.Runtime.Serialization.ISurrogateSelector" /> in the chain of surrogate selectors.</summary>
		/// <returns>The next <see cref="T:System.Runtime.Serialization.ISurrogateSelector" /> in the chain of surrogate selectors.</returns>
		// Token: 0x06005B37 RID: 23351 RVA: 0x0013ED8D File Offset: 0x0013CF8D
		[SecurityCritical]
		public virtual ISurrogateSelector GetNextSelector()
		{
			return this._next;
		}

		/// <summary>Sets up the current surrogate selector to use the SOAP format.</summary>
		// Token: 0x06005B38 RID: 23352 RVA: 0x0013ED95 File Offset: 0x0013CF95
		public virtual void UseSoapFormat()
		{
			this._messageSurrogate = new SoapMessageSurrogate(this);
			((SoapMessageSurrogate)this._messageSurrogate).SetRootObject(this._rootObj);
		}

		// Token: 0x040028F3 RID: 10483
		private static Type s_IMethodCallMessageType = typeof(IMethodCallMessage);

		// Token: 0x040028F4 RID: 10484
		private static Type s_IMethodReturnMessageType = typeof(IMethodReturnMessage);

		// Token: 0x040028F5 RID: 10485
		private static Type s_ObjRefType = typeof(ObjRef);

		// Token: 0x040028F6 RID: 10486
		private object _rootObj;

		// Token: 0x040028F7 RID: 10487
		private ISurrogateSelector _next;

		// Token: 0x040028F8 RID: 10488
		private RemotingSurrogate _remotingSurrogate = new RemotingSurrogate();

		// Token: 0x040028F9 RID: 10489
		private ObjRefSurrogate _objRefSurrogate = new ObjRefSurrogate();

		// Token: 0x040028FA RID: 10490
		private ISerializationSurrogate _messageSurrogate;

		// Token: 0x040028FB RID: 10491
		private MessageSurrogateFilter _filter;
	}
}
