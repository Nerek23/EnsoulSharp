using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Allows security actions for <see cref="T:System.Security.Permissions.EnvironmentPermission" /> to be applied to code using declarative security. This class cannot be inherited.</summary>
	// Token: 0x020002C4 RID: 708
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class EnvironmentPermissionAttribute : CodeAccessSecurityAttribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.EnvironmentPermissionAttribute" /> class with the specified <see cref="T:System.Security.Permissions.SecurityAction" />.</summary>
		/// <param name="action">One of the <see cref="T:System.Security.Permissions.SecurityAction" /> values.</param>
		/// <exception cref="T:System.ArgumentException">The <paramref name="action" /> parameter is not a valid value of <see cref="T:System.Security.Permissions.SecurityAction" />.</exception>
		// Token: 0x0600253D RID: 9533 RVA: 0x0008793C File Offset: 0x00085B3C
		public EnvironmentPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		/// <summary>Gets or sets read access for the environment variables specified by the string value.</summary>
		/// <returns>A list of environment variables for read access.</returns>
		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x0600253E RID: 9534 RVA: 0x00087945 File Offset: 0x00085B45
		// (set) Token: 0x0600253F RID: 9535 RVA: 0x0008794D File Offset: 0x00085B4D
		public string Read
		{
			get
			{
				return this.m_read;
			}
			set
			{
				this.m_read = value;
			}
		}

		/// <summary>Gets or sets write access for the environment variables specified by the string value.</summary>
		/// <returns>A list of environment variables for write access.</returns>
		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06002540 RID: 9536 RVA: 0x00087956 File Offset: 0x00085B56
		// (set) Token: 0x06002541 RID: 9537 RVA: 0x0008795E File Offset: 0x00085B5E
		public string Write
		{
			get
			{
				return this.m_write;
			}
			set
			{
				this.m_write = value;
			}
		}

		/// <summary>Sets full access for the environment variables specified by the string value.</summary>
		/// <returns>A list of environment variables for full access.</returns>
		/// <exception cref="T:System.NotSupportedException">The get method is not supported for this property.</exception>
		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x06002542 RID: 9538 RVA: 0x00087967 File Offset: 0x00085B67
		// (set) Token: 0x06002543 RID: 9539 RVA: 0x00087978 File Offset: 0x00085B78
		public string All
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_GetMethod"));
			}
			set
			{
				this.m_write = value;
				this.m_read = value;
			}
		}

		/// <summary>Creates and returns a new <see cref="T:System.Security.Permissions.EnvironmentPermission" />.</summary>
		/// <returns>An <see cref="T:System.Security.Permissions.EnvironmentPermission" /> that corresponds to this attribute.</returns>
		// Token: 0x06002544 RID: 9540 RVA: 0x00087988 File Offset: 0x00085B88
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new EnvironmentPermission(PermissionState.Unrestricted);
			}
			EnvironmentPermission environmentPermission = new EnvironmentPermission(PermissionState.None);
			if (this.m_read != null)
			{
				environmentPermission.SetPathList(EnvironmentPermissionAccess.Read, this.m_read);
			}
			if (this.m_write != null)
			{
				environmentPermission.SetPathList(EnvironmentPermissionAccess.Write, this.m_write);
			}
			return environmentPermission;
		}

		// Token: 0x04000E2D RID: 3629
		private string m_read;

		// Token: 0x04000E2E RID: 3630
		private string m_write;
	}
}
