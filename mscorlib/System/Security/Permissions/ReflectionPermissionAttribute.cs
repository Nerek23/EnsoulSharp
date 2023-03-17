using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Allows security actions for <see cref="T:System.Security.Permissions.ReflectionPermission" /> to be applied to code using declarative security.</summary>
	// Token: 0x020002C9 RID: 713
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class ReflectionPermissionAttribute : CodeAccessSecurityAttribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.ReflectionPermissionAttribute" /> class with the specified <see cref="T:System.Security.Permissions.SecurityAction" />.</summary>
		/// <param name="action">One of the <see cref="T:System.Security.Permissions.SecurityAction" /> values.</param>
		// Token: 0x06002577 RID: 9591 RVA: 0x00087D87 File Offset: 0x00085F87
		public ReflectionPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		/// <summary>Gets or sets the current allowed uses of reflection.</summary>
		/// <returns>One or more of the <see cref="T:System.Security.Permissions.ReflectionPermissionFlag" /> values combined using a bitwise OR.</returns>
		/// <exception cref="T:System.ArgumentException">An attempt is made to set this property to an invalid value. See <see cref="T:System.Security.Permissions.ReflectionPermissionFlag" /> for the valid values.</exception>
		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06002578 RID: 9592 RVA: 0x00087D90 File Offset: 0x00085F90
		// (set) Token: 0x06002579 RID: 9593 RVA: 0x00087D98 File Offset: 0x00085F98
		public ReflectionPermissionFlag Flags
		{
			get
			{
				return this.m_flag;
			}
			set
			{
				this.m_flag = value;
			}
		}

		/// <summary>Gets or sets a value that indicates whether reflection on members that are not visible is allowed.</summary>
		/// <returns>
		///   <see langword="true" /> if reflection on members that are not visible is allowed; otherwise, <see langword="false" />.</returns>
		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x0600257A RID: 9594 RVA: 0x00087DA1 File Offset: 0x00085FA1
		// (set) Token: 0x0600257B RID: 9595 RVA: 0x00087DAE File Offset: 0x00085FAE
		[Obsolete("This API has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		public bool TypeInformation
		{
			get
			{
				return (this.m_flag & ReflectionPermissionFlag.TypeInformation) > ReflectionPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | ReflectionPermissionFlag.TypeInformation) : (this.m_flag & ~ReflectionPermissionFlag.TypeInformation));
			}
		}

		/// <summary>Gets or sets a value that indicates whether invocation of operations on non-public members is allowed.</summary>
		/// <returns>
		///   <see langword="true" /> if invocation of operations on non-public members is allowed; otherwise, <see langword="false" />.</returns>
		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x0600257C RID: 9596 RVA: 0x00087DCC File Offset: 0x00085FCC
		// (set) Token: 0x0600257D RID: 9597 RVA: 0x00087DD9 File Offset: 0x00085FD9
		public bool MemberAccess
		{
			get
			{
				return (this.m_flag & ReflectionPermissionFlag.MemberAccess) > ReflectionPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | ReflectionPermissionFlag.MemberAccess) : (this.m_flag & ~ReflectionPermissionFlag.MemberAccess));
			}
		}

		/// <summary>Gets or sets a value that indicates whether use of certain features in <see cref="N:System.Reflection.Emit" />, such as emitting debug symbols, is allowed.</summary>
		/// <returns>
		///   <see langword="true" /> if use of the affected features is allowed; otherwise, <see langword="false" />.</returns>
		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x0600257E RID: 9598 RVA: 0x00087DF7 File Offset: 0x00085FF7
		// (set) Token: 0x0600257F RID: 9599 RVA: 0x00087E04 File Offset: 0x00086004
		[Obsolete("This permission is no longer used by the CLR.")]
		public bool ReflectionEmit
		{
			get
			{
				return (this.m_flag & ReflectionPermissionFlag.ReflectionEmit) > ReflectionPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | ReflectionPermissionFlag.ReflectionEmit) : (this.m_flag & ~ReflectionPermissionFlag.ReflectionEmit));
			}
		}

		/// <summary>Gets or sets a value that indicates whether restricted invocation of non-public members is allowed. Restricted invocation means that the grant set of the assembly that contains the non-public member that is being invoked must be equal to, or a subset of, the grant set of the invoking assembly.</summary>
		/// <returns>
		///   <see langword="true" /> if restricted invocation of non-public members is allowed; otherwise, <see langword="false" />.</returns>
		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x06002580 RID: 9600 RVA: 0x00087E22 File Offset: 0x00086022
		// (set) Token: 0x06002581 RID: 9601 RVA: 0x00087E2F File Offset: 0x0008602F
		public bool RestrictedMemberAccess
		{
			get
			{
				return (this.m_flag & ReflectionPermissionFlag.RestrictedMemberAccess) > ReflectionPermissionFlag.NoFlags;
			}
			set
			{
				this.m_flag = (value ? (this.m_flag | ReflectionPermissionFlag.RestrictedMemberAccess) : (this.m_flag & ~ReflectionPermissionFlag.RestrictedMemberAccess));
			}
		}

		/// <summary>Creates and returns a new <see cref="T:System.Security.Permissions.ReflectionPermission" />.</summary>
		/// <returns>A <see cref="T:System.Security.Permissions.ReflectionPermission" /> that corresponds to this attribute.</returns>
		// Token: 0x06002582 RID: 9602 RVA: 0x00087E4D File Offset: 0x0008604D
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new ReflectionPermission(PermissionState.Unrestricted);
			}
			return new ReflectionPermission(this.m_flag);
		}

		// Token: 0x04000E41 RID: 3649
		private ReflectionPermissionFlag m_flag;
	}
}
