using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting.Contexts
{
	/// <summary>Provides the default implementations of the <see cref="T:System.Runtime.Remoting.Contexts.IContextAttribute" /> and <see cref="T:System.Runtime.Remoting.Contexts.IContextProperty" /> interfaces.</summary>
	// Token: 0x020007E2 RID: 2018
	[SecurityCritical]
	[AttributeUsage(AttributeTargets.Class)]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	[Serializable]
	public class ContextAttribute : Attribute, IContextAttribute, IContextProperty
	{
		/// <summary>Creates an instance of the <see cref="T:System.Runtime.Remoting.Contexts.ContextAttribute" /> class with the specified name.</summary>
		/// <param name="name">The name of the context attribute.</param>
		// Token: 0x060057AA RID: 22442 RVA: 0x00134337 File Offset: 0x00132537
		public ContextAttribute(string name)
		{
			this.AttributeName = name;
		}

		/// <summary>Gets the name of the context attribute.</summary>
		/// <returns>The name of the context attribute.</returns>
		// Token: 0x17000EA2 RID: 3746
		// (get) Token: 0x060057AB RID: 22443 RVA: 0x00134346 File Offset: 0x00132546
		public virtual string Name
		{
			[SecurityCritical]
			get
			{
				return this.AttributeName;
			}
		}

		/// <summary>Returns a Boolean value indicating whether the context property is compatible with the new context.</summary>
		/// <param name="newCtx">The new context in which the property has been created.</param>
		/// <returns>
		///   <see langword="true" /> if the context property is okay with the new context; otherwise, <see langword="false" />.</returns>
		// Token: 0x060057AC RID: 22444 RVA: 0x0013434E File Offset: 0x0013254E
		[SecurityCritical]
		public virtual bool IsNewContextOK(Context newCtx)
		{
			return true;
		}

		/// <summary>Called when the context is frozen.</summary>
		/// <param name="newContext">The context to freeze.</param>
		// Token: 0x060057AD RID: 22445 RVA: 0x00134351 File Offset: 0x00132551
		[SecurityCritical]
		public virtual void Freeze(Context newContext)
		{
		}

		/// <summary>Returns a Boolean value indicating whether this instance is equal to the specified object.</summary>
		/// <param name="o">The object to compare with this instance.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="o" /> is not <see langword="null" /> and if the object names are equivalent; otherwise, <see langword="false" />.</returns>
		// Token: 0x060057AE RID: 22446 RVA: 0x00134354 File Offset: 0x00132554
		[SecuritySafeCritical]
		public override bool Equals(object o)
		{
			IContextProperty contextProperty = o as IContextProperty;
			return contextProperty != null && this.AttributeName.Equals(contextProperty.Name);
		}

		/// <summary>Returns the hashcode for this instance of <see cref="T:System.Runtime.Remoting.Contexts.ContextAttribute" />.</summary>
		/// <returns>The hashcode for this instance of <see cref="T:System.Runtime.Remoting.Contexts.ContextAttribute" />.</returns>
		// Token: 0x060057AF RID: 22447 RVA: 0x0013437E File Offset: 0x0013257E
		[SecuritySafeCritical]
		public override int GetHashCode()
		{
			return this.AttributeName.GetHashCode();
		}

		/// <summary>Returns a Boolean value indicating whether the context parameter meets the context attribute's requirements.</summary>
		/// <param name="ctx">The context in which to check.</param>
		/// <param name="ctorMsg">The <see cref="T:System.Runtime.Remoting.Activation.IConstructionCallMessage" /> to which to add the context property.</param>
		/// <returns>
		///   <see langword="true" /> if the passed in context is okay; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">Either <paramref name="ctx" /> or <paramref name="ctorMsg" /> is <see langword="null" />.</exception>
		// Token: 0x060057B0 RID: 22448 RVA: 0x0013438C File Offset: 0x0013258C
		[SecurityCritical]
		public virtual bool IsContextOK(Context ctx, IConstructionCallMessage ctorMsg)
		{
			if (ctx == null)
			{
				throw new ArgumentNullException("ctx");
			}
			if (ctorMsg == null)
			{
				throw new ArgumentNullException("ctorMsg");
			}
			if (!ctorMsg.ActivationType.IsContextful)
			{
				return true;
			}
			object property = ctx.GetProperty(this.AttributeName);
			return property != null && this.Equals(property);
		}

		/// <summary>Adds the current context property to the given message.</summary>
		/// <param name="ctorMsg">The <see cref="T:System.Runtime.Remoting.Activation.IConstructionCallMessage" /> to which to add the context property.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="ctorMsg" /> parameter is <see langword="null" />.</exception>
		// Token: 0x060057B1 RID: 22449 RVA: 0x001343E0 File Offset: 0x001325E0
		[SecurityCritical]
		public virtual void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
		{
			if (ctorMsg == null)
			{
				throw new ArgumentNullException("ctorMsg");
			}
			ctorMsg.ContextProperties.Add(this);
		}

		/// <summary>Indicates the name of the context attribute.</summary>
		// Token: 0x040027B9 RID: 10169
		protected string AttributeName;
	}
}
