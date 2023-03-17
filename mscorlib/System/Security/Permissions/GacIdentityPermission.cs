using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Defines the identity permission for files originating in the global assembly cache. This class cannot be inherited.</summary>
	// Token: 0x020002E5 RID: 741
	[ComVisible(true)]
	[Serializable]
	public sealed class GacIdentityPermission : CodeAccessPermission, IBuiltInPermission
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.GacIdentityPermission" /> class with fully restricted <see cref="T:System.Security.Permissions.PermissionState" />.</summary>
		/// <param name="state">One of the <see cref="T:System.Security.Permissions.PermissionState" /> values.</param>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="state" /> is not a valid <see cref="T:System.Security.Permissions.PermissionState" /> value.</exception>
		// Token: 0x0600268B RID: 9867 RVA: 0x0008BBBF File Offset: 0x00089DBF
		public GacIdentityPermission(PermissionState state)
		{
			if (state != PermissionState.Unrestricted && state != PermissionState.None)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidPermissionState"));
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.GacIdentityPermission" /> class.</summary>
		// Token: 0x0600268C RID: 9868 RVA: 0x0008BBDE File Offset: 0x00089DDE
		public GacIdentityPermission()
		{
		}

		/// <summary>Creates and returns an identical copy of the current permission.</summary>
		/// <returns>A copy of the current permission.</returns>
		// Token: 0x0600268D RID: 9869 RVA: 0x0008BBE6 File Offset: 0x00089DE6
		public override IPermission Copy()
		{
			return new GacIdentityPermission();
		}

		/// <summary>Indicates whether the current permission is a subset of the specified permission.</summary>
		/// <param name="target">A permission object to test for the subset relationship. The permission must be of the same type as the current permission.</param>
		/// <returns>
		///   <see langword="true" /> if the current permission is a subset of the specified permission; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="target" /> is not <see langword="null" /> and is not of the same type as the current permission.</exception>
		// Token: 0x0600268E RID: 9870 RVA: 0x0008BBED File Offset: 0x00089DED
		public override bool IsSubsetOf(IPermission target)
		{
			if (target == null)
			{
				return false;
			}
			if (!(target is GacIdentityPermission))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			return true;
		}

		/// <summary>Creates and returns a permission that is the intersection of the current permission and the specified permission.</summary>
		/// <param name="target">A permission to intersect with the current permission. It must be of the same type as the current permission.</param>
		/// <returns>A new permission that represents the intersection of the current permission and the specified permission. The new permission is <see langword="null" /> if the intersection is empty.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="target" /> is not <see langword="null" /> and is not of the same type as the current permission.</exception>
		// Token: 0x0600268F RID: 9871 RVA: 0x0008BC21 File Offset: 0x00089E21
		public override IPermission Intersect(IPermission target)
		{
			if (target == null)
			{
				return null;
			}
			if (!(target is GacIdentityPermission))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			return this.Copy();
		}

		/// <summary>Creates and returns a permission that is the union of the current permission and the specified permission.</summary>
		/// <param name="target">A permission to combine with the current permission. It must be of the same type as the current permission.</param>
		/// <returns>A new permission that represents the union of the current permission and the specified permission.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="target" /> is not <see langword="null" /> and is not of the same type as the current permission.</exception>
		// Token: 0x06002690 RID: 9872 RVA: 0x0008BC5A File Offset: 0x00089E5A
		public override IPermission Union(IPermission target)
		{
			if (target == null)
			{
				return this.Copy();
			}
			if (!(target is GacIdentityPermission))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			return this.Copy();
		}

		/// <summary>Creates an XML encoding of the permission and its current state.</summary>
		/// <returns>A <see cref="T:System.Security.SecurityElement" /> that represents the XML encoding of the permission, including any state information.</returns>
		// Token: 0x06002691 RID: 9873 RVA: 0x0008BC98 File Offset: 0x00089E98
		public override SecurityElement ToXml()
		{
			return CodeAccessPermission.CreatePermissionElement(this, "System.Security.Permissions.GacIdentityPermission");
		}

		/// <summary>Creates a permission from an XML encoding.</summary>
		/// <param name="securityElement">A <see cref="T:System.Security.SecurityElement" /> that contains the XML encoding to use to create the permission.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="securityElement" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="securityElement" /> is not a valid permission element.  
		/// -or-  
		/// The version number of <paramref name="securityElement" /> is not valid.</exception>
		// Token: 0x06002692 RID: 9874 RVA: 0x0008BCB2 File Offset: 0x00089EB2
		public override void FromXml(SecurityElement securityElement)
		{
			CodeAccessPermission.ValidateElement(securityElement, this);
		}

		// Token: 0x06002693 RID: 9875 RVA: 0x0008BCBB File Offset: 0x00089EBB
		int IBuiltInPermission.GetTokenIndex()
		{
			return GacIdentityPermission.GetTokenIndex();
		}

		// Token: 0x06002694 RID: 9876 RVA: 0x0008BCC2 File Offset: 0x00089EC2
		internal static int GetTokenIndex()
		{
			return 15;
		}
	}
}
