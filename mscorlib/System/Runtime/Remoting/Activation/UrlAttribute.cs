using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Security;

namespace System.Runtime.Remoting.Activation
{
	/// <summary>Defines an attribute that can be used at the call site to specify the URL where the activation will happen. This class cannot be inherited.</summary>
	// Token: 0x02000872 RID: 2162
	[SecurityCritical]
	[ComVisible(true)]
	[Serializable]
	public sealed class UrlAttribute : ContextAttribute
	{
		/// <summary>Creates a new instance of the <see cref="T:System.Runtime.Remoting.Activation.UrlAttribute" /> class.</summary>
		/// <param name="callsiteURL">The call site URL.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="callsiteURL" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005C49 RID: 23625 RVA: 0x0014444C File Offset: 0x0014264C
		[SecurityCritical]
		public UrlAttribute(string callsiteURL) : base(UrlAttribute.propertyName)
		{
			if (callsiteURL == null)
			{
				throw new ArgumentNullException("callsiteURL");
			}
			this.url = callsiteURL;
		}

		/// <summary>Checks whether the specified object refers to the same URL as the current instance.</summary>
		/// <param name="o">The object to compare to the current <see cref="T:System.Runtime.Remoting.Activation.UrlAttribute" />.</param>
		/// <returns>
		///   <see langword="true" /> if the object is a <see cref="T:System.Runtime.Remoting.Activation.UrlAttribute" /> with the same value; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005C4A RID: 23626 RVA: 0x0014446E File Offset: 0x0014266E
		[SecuritySafeCritical]
		public override bool Equals(object o)
		{
			return o is IContextProperty && o is UrlAttribute && ((UrlAttribute)o).UrlValue.Equals(this.url);
		}

		/// <summary>Returns the hash value for the current <see cref="T:System.Runtime.Remoting.Activation.UrlAttribute" />.</summary>
		/// <returns>The hash value for the current <see cref="T:System.Runtime.Remoting.Activation.UrlAttribute" />.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005C4B RID: 23627 RVA: 0x00144498 File Offset: 0x00142698
		[SecuritySafeCritical]
		public override int GetHashCode()
		{
			return this.url.GetHashCode();
		}

		/// <summary>Returns a Boolean value that indicates whether the specified <see cref="T:System.Runtime.Remoting.Contexts.Context" /> meets <see cref="T:System.Runtime.Remoting.Activation.UrlAttribute" />'s requirements.</summary>
		/// <param name="ctx">The context to check against the current context attribute.</param>
		/// <param name="msg">The construction call, the parameters of which need to be checked against the current context.</param>
		/// <returns>
		///   <see langword="true" /> if the passed-in context is acceptable; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005C4C RID: 23628 RVA: 0x001444A5 File Offset: 0x001426A5
		[SecurityCritical]
		[ComVisible(true)]
		public override bool IsContextOK(Context ctx, IConstructionCallMessage msg)
		{
			return false;
		}

		/// <summary>Forces the creation of the context and the server object inside the context at the specified URL.</summary>
		/// <param name="ctorMsg">The <see cref="T:System.Runtime.Remoting.Activation.IConstructionCallMessage" /> of the server object to create.</param>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005C4D RID: 23629 RVA: 0x001444A8 File Offset: 0x001426A8
		[SecurityCritical]
		[ComVisible(true)]
		public override void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
		{
		}

		/// <summary>Gets the URL value of the <see cref="T:System.Runtime.Remoting.Activation.UrlAttribute" />.</summary>
		/// <returns>The URL value of the <see cref="T:System.Runtime.Remoting.Activation.UrlAttribute" />.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000FF6 RID: 4086
		// (get) Token: 0x06005C4E RID: 23630 RVA: 0x001444AA File Offset: 0x001426AA
		public string UrlValue
		{
			[SecurityCritical]
			get
			{
				return this.url;
			}
		}

		// Token: 0x0400294F RID: 10575
		private string url;

		// Token: 0x04002950 RID: 10576
		private static string propertyName = "UrlAttribute";
	}
}
