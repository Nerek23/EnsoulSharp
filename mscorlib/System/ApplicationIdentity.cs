using System;
using System.Deployment.Internal.Isolation;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System
{
	/// <summary>Provides the ability to uniquely identify a manifest-activated application. This class cannot be inherited.</summary>
	// Token: 0x020000A4 RID: 164
	[ComVisible(false)]
	[Serializable]
	public sealed class ApplicationIdentity : ISerializable
	{
		// Token: 0x06000984 RID: 2436 RVA: 0x0001EF6C File Offset: 0x0001D16C
		private ApplicationIdentity()
		{
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x0001EF74 File Offset: 0x0001D174
		[SecurityCritical]
		private ApplicationIdentity(SerializationInfo info, StreamingContext context)
		{
			string text = (string)info.GetValue("FullName", typeof(string));
			if (text == null)
			{
				throw new ArgumentNullException("fullName");
			}
			this._appId = IsolationInterop.AppIdAuthority.TextToDefinition(0U, text);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.ApplicationIdentity" /> class.</summary>
		/// <param name="applicationIdentityFullName">The full name of the application.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="applicationIdentityFullName" /> is <see langword="null" />.</exception>
		// Token: 0x06000986 RID: 2438 RVA: 0x0001EFC2 File Offset: 0x0001D1C2
		[SecuritySafeCritical]
		public ApplicationIdentity(string applicationIdentityFullName)
		{
			if (applicationIdentityFullName == null)
			{
				throw new ArgumentNullException("applicationIdentityFullName");
			}
			this._appId = IsolationInterop.AppIdAuthority.TextToDefinition(0U, applicationIdentityFullName);
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x0001EFEA File Offset: 0x0001D1EA
		[SecurityCritical]
		internal ApplicationIdentity(IDefinitionAppId applicationIdentity)
		{
			this._appId = applicationIdentity;
		}

		/// <summary>Gets the full name of the application.</summary>
		/// <returns>The full name of the application, also known as the display name.</returns>
		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000988 RID: 2440 RVA: 0x0001EFF9 File Offset: 0x0001D1F9
		public string FullName
		{
			[SecuritySafeCritical]
			get
			{
				return IsolationInterop.AppIdAuthority.DefinitionToText(0U, this._appId);
			}
		}

		/// <summary>Gets the location of the deployment manifest as a URL.</summary>
		/// <returns>The URL of the deployment manifest.</returns>
		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000989 RID: 2441 RVA: 0x0001F00C File Offset: 0x0001D20C
		public string CodeBase
		{
			[SecuritySafeCritical]
			get
			{
				return this._appId.get_Codebase();
			}
		}

		/// <summary>Returns the full name of the manifest-activated application.</summary>
		/// <returns>The full name of the manifest-activated application.</returns>
		// Token: 0x0600098A RID: 2442 RVA: 0x0001F019 File Offset: 0x0001D219
		public override string ToString()
		{
			return this.FullName;
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600098B RID: 2443 RVA: 0x0001F021 File Offset: 0x0001D221
		internal IDefinitionAppId Identity
		{
			[SecurityCritical]
			get
			{
				return this._appId;
			}
		}

		/// <summary>Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> object with the data needed to serialize the target object.</summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" />) structure for the serialization.</param>
		// Token: 0x0600098C RID: 2444 RVA: 0x0001F029 File Offset: 0x0001D229
		[SecurityCritical]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("FullName", this.FullName, typeof(string));
		}

		// Token: 0x040003C7 RID: 967
		private IDefinitionAppId _appId;
	}
}
