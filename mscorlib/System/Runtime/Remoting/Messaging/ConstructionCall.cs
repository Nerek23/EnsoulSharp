using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Runtime.Serialization;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	/// <summary>Implements the <see cref="T:System.Runtime.Remoting.Activation.IConstructionCallMessage" /> interface to create a request message that constitutes a constructor call on a remote object.</summary>
	// Token: 0x0200083D RID: 2109
	[SecurityCritical]
	[CLSCompliant(false)]
	[ComVisible(true)]
	[Serializable]
	public class ConstructionCall : MethodCall, IConstructionCallMessage, IMethodCallMessage, IMethodMessage, IMessage
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Messaging.ConstructionCall" /> class from an array of remoting headers.</summary>
		/// <param name="headers">An array of remoting headers that contain key-value pairs. This array is used to initialize <see cref="T:System.Runtime.Remoting.Messaging.ConstructionCall" /> fields for those headers that belong to the namespace "http://schemas.microsoft.com/clr/soap/messageProperties".</param>
		// Token: 0x06005A76 RID: 23158 RVA: 0x0013C843 File Offset: 0x0013AA43
		public ConstructionCall(Header[] headers) : base(headers)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Messaging.ConstructionCall" /> class by copying an existing message.</summary>
		/// <param name="m">A remoting message.</param>
		// Token: 0x06005A77 RID: 23159 RVA: 0x0013C84C File Offset: 0x0013AA4C
		public ConstructionCall(IMessage m) : base(m)
		{
		}

		// Token: 0x06005A78 RID: 23160 RVA: 0x0013C855 File Offset: 0x0013AA55
		internal ConstructionCall(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x06005A79 RID: 23161 RVA: 0x0013C860 File Offset: 0x0013AA60
		[SecurityCritical]
		internal override bool FillSpecialHeader(string key, object value)
		{
			if (key != null)
			{
				if (key.Equals("__ActivationType"))
				{
					this._activationType = null;
				}
				else if (key.Equals("__ContextProperties"))
				{
					this._contextProperties = (IList)value;
				}
				else if (key.Equals("__CallSiteActivationAttributes"))
				{
					this._callSiteActivationAttributes = (object[])value;
				}
				else if (key.Equals("__Activator"))
				{
					this._activator = (IActivator)value;
				}
				else
				{
					if (!key.Equals("__ActivationTypeName"))
					{
						return base.FillSpecialHeader(key, value);
					}
					this._activationTypeName = (string)value;
				}
			}
			return true;
		}

		/// <summary>Gets the call site activation attributes for the remote object.</summary>
		/// <returns>An array of type <see cref="T:System.Object" /> containing the call site activation attributes for the remote object.</returns>
		// Token: 0x17000F79 RID: 3961
		// (get) Token: 0x06005A7A RID: 23162 RVA: 0x0013C8FF File Offset: 0x0013AAFF
		public object[] CallSiteActivationAttributes
		{
			[SecurityCritical]
			get
			{
				return this._callSiteActivationAttributes;
			}
		}

		/// <summary>Gets the type of the remote object to activate.</summary>
		/// <returns>The <see cref="T:System.Type" /> of the remote object to activate.</returns>
		// Token: 0x17000F7A RID: 3962
		// (get) Token: 0x06005A7B RID: 23163 RVA: 0x0013C907 File Offset: 0x0013AB07
		public Type ActivationType
		{
			[SecurityCritical]
			get
			{
				if (this._activationType == null && this._activationTypeName != null)
				{
					this._activationType = RemotingServices.InternalGetTypeFromQualifiedTypeName(this._activationTypeName, false);
				}
				return this._activationType;
			}
		}

		/// <summary>Gets the full type name of the remote object to activate.</summary>
		/// <returns>A <see cref="T:System.String" /> containing the full type name of the remote object to activate.</returns>
		// Token: 0x17000F7B RID: 3963
		// (get) Token: 0x06005A7C RID: 23164 RVA: 0x0013C937 File Offset: 0x0013AB37
		public string ActivationTypeName
		{
			[SecurityCritical]
			get
			{
				return this._activationTypeName;
			}
		}

		/// <summary>Gets a list of properties that define the context in which the remote object is to be created.</summary>
		/// <returns>A <see cref="T:System.Collections.IList" /> that contains a list of properties that define the context in which the remote object is to be created.</returns>
		// Token: 0x17000F7C RID: 3964
		// (get) Token: 0x06005A7D RID: 23165 RVA: 0x0013C93F File Offset: 0x0013AB3F
		public IList ContextProperties
		{
			[SecurityCritical]
			get
			{
				if (this._contextProperties == null)
				{
					this._contextProperties = new ArrayList();
				}
				return this._contextProperties;
			}
		}

		/// <summary>Gets an <see cref="T:System.Collections.IDictionary" /> interface that represents a collection of the remoting message's properties.</summary>
		/// <returns>An <see cref="T:System.Collections.IDictionary" /> interface that represents a collection of the remoting message's properties.</returns>
		// Token: 0x17000F7D RID: 3965
		// (get) Token: 0x06005A7E RID: 23166 RVA: 0x0013C95C File Offset: 0x0013AB5C
		public override IDictionary Properties
		{
			[SecurityCritical]
			get
			{
				IDictionary externalProperties;
				lock (this)
				{
					if (this.InternalProperties == null)
					{
						this.InternalProperties = new Hashtable();
					}
					if (this.ExternalProperties == null)
					{
						this.ExternalProperties = new CCMDictionary(this, this.InternalProperties);
					}
					externalProperties = this.ExternalProperties;
				}
				return externalProperties;
			}
		}

		/// <summary>Gets or sets the activator that activates the remote object.</summary>
		/// <returns>The <see cref="T:System.Runtime.Remoting.Activation.IActivator" /> that activates the remote object.</returns>
		// Token: 0x17000F7E RID: 3966
		// (get) Token: 0x06005A7F RID: 23167 RVA: 0x0013C9C8 File Offset: 0x0013ABC8
		// (set) Token: 0x06005A80 RID: 23168 RVA: 0x0013C9D0 File Offset: 0x0013ABD0
		public IActivator Activator
		{
			[SecurityCritical]
			get
			{
				return this._activator;
			}
			[SecurityCritical]
			set
			{
				this._activator = value;
			}
		}

		// Token: 0x040028B0 RID: 10416
		internal Type _activationType;

		// Token: 0x040028B1 RID: 10417
		internal string _activationTypeName;

		// Token: 0x040028B2 RID: 10418
		internal IList _contextProperties;

		// Token: 0x040028B3 RID: 10419
		internal object[] _callSiteActivationAttributes;

		// Token: 0x040028B4 RID: 10420
		internal IActivator _activator;
	}
}
