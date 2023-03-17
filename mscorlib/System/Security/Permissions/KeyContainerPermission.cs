using System;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Permissions
{
	/// <summary>Controls the ability to access key containers. This class cannot be inherited.</summary>
	// Token: 0x020002EB RID: 747
	[ComVisible(true)]
	[Serializable]
	public sealed class KeyContainerPermission : CodeAccessPermission, IUnrestrictedPermission, IBuiltInPermission
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.KeyContainerPermission" /> class with either restricted or unrestricted permission.</summary>
		/// <param name="state">One of the <see cref="T:System.Security.Permissions.PermissionState" /> values.</param>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="state" /> is not a valid <see cref="T:System.Security.Permissions.PermissionState" /> value.</exception>
		// Token: 0x060026BE RID: 9918 RVA: 0x0008C3D0 File Offset: 0x0008A5D0
		public KeyContainerPermission(PermissionState state)
		{
			if (state == PermissionState.Unrestricted)
			{
				this.m_flags = KeyContainerPermissionFlags.AllFlags;
			}
			else
			{
				if (state != PermissionState.None)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidPermissionState"));
				}
				this.m_flags = KeyContainerPermissionFlags.NoFlags;
			}
			this.m_accessEntries = new KeyContainerPermissionAccessEntryCollection(this.m_flags);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.KeyContainerPermission" /> class with the specified access.</summary>
		/// <param name="flags">A bitwise combination of the <see cref="T:System.Security.Permissions.KeyContainerPermissionFlags" /> values.</param>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="flags" /> is not a valid combination of the <see cref="T:System.Security.Permissions.KeyContainerPermissionFlags" /> values.</exception>
		// Token: 0x060026BF RID: 9919 RVA: 0x0008C421 File Offset: 0x0008A621
		public KeyContainerPermission(KeyContainerPermissionFlags flags)
		{
			KeyContainerPermission.VerifyFlags(flags);
			this.m_flags = flags;
			this.m_accessEntries = new KeyContainerPermissionAccessEntryCollection(this.m_flags);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.KeyContainerPermission" /> class with the specified global access and specific key container access rights.</summary>
		/// <param name="flags">A bitwise combination of the <see cref="T:System.Security.Permissions.KeyContainerPermissionFlags" /> values.</param>
		/// <param name="accessList">An array of <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> objects identifying specific key container access rights.</param>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="flags" /> is not a valid combination of the <see cref="T:System.Security.Permissions.KeyContainerPermissionFlags" /> values.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="accessList" /> is <see langword="null" />.</exception>
		// Token: 0x060026C0 RID: 9920 RVA: 0x0008C448 File Offset: 0x0008A648
		public KeyContainerPermission(KeyContainerPermissionFlags flags, KeyContainerPermissionAccessEntry[] accessList)
		{
			if (accessList == null)
			{
				throw new ArgumentNullException("accessList");
			}
			KeyContainerPermission.VerifyFlags(flags);
			this.m_flags = flags;
			this.m_accessEntries = new KeyContainerPermissionAccessEntryCollection(this.m_flags);
			for (int i = 0; i < accessList.Length; i++)
			{
				this.m_accessEntries.Add(accessList[i]);
			}
		}

		/// <summary>Gets the key container permission flags that apply to all key containers associated with the permission.</summary>
		/// <returns>A bitwise combination of the <see cref="T:System.Security.Permissions.KeyContainerPermissionFlags" /> values.</returns>
		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x060026C1 RID: 9921 RVA: 0x0008C4A4 File Offset: 0x0008A6A4
		public KeyContainerPermissionFlags Flags
		{
			get
			{
				return this.m_flags;
			}
		}

		/// <summary>Gets the collection of <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> objects associated with the current permission.</summary>
		/// <returns>A <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntryCollection" /> containing the <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> objects for this <see cref="T:System.Security.Permissions.KeyContainerPermission" />.</returns>
		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x060026C2 RID: 9922 RVA: 0x0008C4AC File Offset: 0x0008A6AC
		public KeyContainerPermissionAccessEntryCollection AccessEntries
		{
			get
			{
				return this.m_accessEntries;
			}
		}

		/// <summary>Determines whether the current permission is unrestricted.</summary>
		/// <returns>
		///   <see langword="true" /> if the current permission is unrestricted; otherwise, <see langword="false" />.</returns>
		// Token: 0x060026C3 RID: 9923 RVA: 0x0008C4B4 File Offset: 0x0008A6B4
		public bool IsUnrestricted()
		{
			if (this.m_flags != KeyContainerPermissionFlags.AllFlags)
			{
				return false;
			}
			foreach (KeyContainerPermissionAccessEntry keyContainerPermissionAccessEntry in this.AccessEntries)
			{
				if ((keyContainerPermissionAccessEntry.Flags & KeyContainerPermissionFlags.AllFlags) != KeyContainerPermissionFlags.AllFlags)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060026C4 RID: 9924 RVA: 0x0008C504 File Offset: 0x0008A704
		private bool IsEmpty()
		{
			if (this.Flags == KeyContainerPermissionFlags.NoFlags)
			{
				foreach (KeyContainerPermissionAccessEntry keyContainerPermissionAccessEntry in this.AccessEntries)
				{
					if (keyContainerPermissionAccessEntry.Flags != KeyContainerPermissionFlags.NoFlags)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		/// <summary>Determines whether the current permission is a subset of the specified permission.</summary>
		/// <param name="target">A permission to test for the subset relationship. This permission must be the same type as the current permission.</param>
		/// <returns>
		///   <see langword="true" /> if the current permission is a subset of the specified permission; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="target" /> is not <see langword="null" /> and does not specify a permission of the same type as the current permission.</exception>
		// Token: 0x060026C5 RID: 9925 RVA: 0x0008C544 File Offset: 0x0008A744
		public override bool IsSubsetOf(IPermission target)
		{
			if (target == null)
			{
				return this.IsEmpty();
			}
			if (!base.VerifyType(target))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			KeyContainerPermission keyContainerPermission = (KeyContainerPermission)target;
			if ((this.m_flags & keyContainerPermission.m_flags) != this.m_flags)
			{
				return false;
			}
			foreach (KeyContainerPermissionAccessEntry keyContainerPermissionAccessEntry in this.AccessEntries)
			{
				KeyContainerPermissionFlags applicableFlags = KeyContainerPermission.GetApplicableFlags(keyContainerPermissionAccessEntry, keyContainerPermission);
				if ((keyContainerPermissionAccessEntry.Flags & applicableFlags) != keyContainerPermissionAccessEntry.Flags)
				{
					return false;
				}
			}
			foreach (KeyContainerPermissionAccessEntry keyContainerPermissionAccessEntry2 in keyContainerPermission.AccessEntries)
			{
				KeyContainerPermissionFlags applicableFlags2 = KeyContainerPermission.GetApplicableFlags(keyContainerPermissionAccessEntry2, this);
				if ((applicableFlags2 & keyContainerPermissionAccessEntry2.Flags) != applicableFlags2)
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>Creates and returns a permission that is the intersection of the current permission and the specified permission.</summary>
		/// <param name="target">A permission to intersect with the current permission. It must be the same type as the current permission.</param>
		/// <returns>A new permission that represents the intersection of the current permission and the specified permission. This new permission is <see langword="null" /> if the intersection is empty.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="target" /> is not <see langword="null" /> and does not specify a permission of the same type as the current permission.</exception>
		// Token: 0x060026C6 RID: 9926 RVA: 0x0008C61C File Offset: 0x0008A81C
		public override IPermission Intersect(IPermission target)
		{
			if (target == null)
			{
				return null;
			}
			if (!base.VerifyType(target))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			KeyContainerPermission keyContainerPermission = (KeyContainerPermission)target;
			if (this.IsEmpty() || keyContainerPermission.IsEmpty())
			{
				return null;
			}
			KeyContainerPermissionFlags flags = keyContainerPermission.m_flags & this.m_flags;
			KeyContainerPermission keyContainerPermission2 = new KeyContainerPermission(flags);
			foreach (KeyContainerPermissionAccessEntry accessEntry in this.AccessEntries)
			{
				keyContainerPermission2.AddAccessEntryAndIntersect(accessEntry, keyContainerPermission);
			}
			foreach (KeyContainerPermissionAccessEntry accessEntry2 in keyContainerPermission.AccessEntries)
			{
				keyContainerPermission2.AddAccessEntryAndIntersect(accessEntry2, this);
			}
			if (!keyContainerPermission2.IsEmpty())
			{
				return keyContainerPermission2;
			}
			return null;
		}

		/// <summary>Creates a permission that is the union of the current permission and the specified permission.</summary>
		/// <param name="target">A permission to combine with the current permission. It must be of the same type as the current permission.</param>
		/// <returns>A new permission that represents the union of the current permission and the specified permission.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="target" /> is not <see langword="null" /> and does not specify a permission of the same type as the current permission.</exception>
		// Token: 0x060026C7 RID: 9927 RVA: 0x0008C6E8 File Offset: 0x0008A8E8
		public override IPermission Union(IPermission target)
		{
			if (target == null)
			{
				return this.Copy();
			}
			if (!base.VerifyType(target))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			KeyContainerPermission keyContainerPermission = (KeyContainerPermission)target;
			if (this.IsUnrestricted() || keyContainerPermission.IsUnrestricted())
			{
				return new KeyContainerPermission(PermissionState.Unrestricted);
			}
			KeyContainerPermissionFlags flags = this.m_flags | keyContainerPermission.m_flags;
			KeyContainerPermission keyContainerPermission2 = new KeyContainerPermission(flags);
			foreach (KeyContainerPermissionAccessEntry accessEntry in this.AccessEntries)
			{
				keyContainerPermission2.AddAccessEntryAndUnion(accessEntry, keyContainerPermission);
			}
			foreach (KeyContainerPermissionAccessEntry accessEntry2 in keyContainerPermission.AccessEntries)
			{
				keyContainerPermission2.AddAccessEntryAndUnion(accessEntry2, this);
			}
			if (!keyContainerPermission2.IsEmpty())
			{
				return keyContainerPermission2;
			}
			return null;
		}

		/// <summary>Creates and returns an identical copy of the current permission.</summary>
		/// <returns>A copy of the current permission.</returns>
		// Token: 0x060026C8 RID: 9928 RVA: 0x0008C7BC File Offset: 0x0008A9BC
		public override IPermission Copy()
		{
			if (this.IsEmpty())
			{
				return null;
			}
			KeyContainerPermission keyContainerPermission = new KeyContainerPermission(this.m_flags);
			foreach (KeyContainerPermissionAccessEntry accessEntry in this.AccessEntries)
			{
				keyContainerPermission.AccessEntries.Add(accessEntry);
			}
			return keyContainerPermission;
		}

		/// <summary>Creates an XML encoding of the permission and its current state.</summary>
		/// <returns>A <see cref="T:System.Security.SecurityElement" /> that contains an XML encoding of the permission, including state information.</returns>
		// Token: 0x060026C9 RID: 9929 RVA: 0x0008C80C File Offset: 0x0008AA0C
		public override SecurityElement ToXml()
		{
			SecurityElement securityElement = CodeAccessPermission.CreatePermissionElement(this, "System.Security.Permissions.KeyContainerPermission");
			if (!this.IsUnrestricted())
			{
				securityElement.AddAttribute("Flags", this.m_flags.ToString());
				if (this.AccessEntries.Count > 0)
				{
					SecurityElement securityElement2 = new SecurityElement("AccessList");
					foreach (KeyContainerPermissionAccessEntry keyContainerPermissionAccessEntry in this.AccessEntries)
					{
						SecurityElement securityElement3 = new SecurityElement("AccessEntry");
						securityElement3.AddAttribute("KeyStore", keyContainerPermissionAccessEntry.KeyStore);
						securityElement3.AddAttribute("ProviderName", keyContainerPermissionAccessEntry.ProviderName);
						securityElement3.AddAttribute("ProviderType", keyContainerPermissionAccessEntry.ProviderType.ToString(null, null));
						securityElement3.AddAttribute("KeyContainerName", keyContainerPermissionAccessEntry.KeyContainerName);
						securityElement3.AddAttribute("KeySpec", keyContainerPermissionAccessEntry.KeySpec.ToString(null, null));
						securityElement3.AddAttribute("Flags", keyContainerPermissionAccessEntry.Flags.ToString());
						securityElement2.AddChild(securityElement3);
					}
					securityElement.AddChild(securityElement2);
				}
			}
			else
			{
				securityElement.AddAttribute("Unrestricted", "true");
			}
			return securityElement;
		}

		/// <summary>Reconstructs a permission with a specified state from an XML encoding.</summary>
		/// <param name="securityElement">A <see cref="T:System.Security.SecurityElement" /> that contains the XML encoding used to reconstruct the permission.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="securityElement" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="securityElement" /> is not a valid permission element.  
		/// -or-  
		/// The version number of <paramref name="securityElement" /> is not supported.</exception>
		// Token: 0x060026CA RID: 9930 RVA: 0x0008C94C File Offset: 0x0008AB4C
		public override void FromXml(SecurityElement securityElement)
		{
			CodeAccessPermission.ValidateElement(securityElement, this);
			if (XMLUtil.IsUnrestricted(securityElement))
			{
				this.m_flags = KeyContainerPermissionFlags.AllFlags;
				this.m_accessEntries = new KeyContainerPermissionAccessEntryCollection(this.m_flags);
				return;
			}
			this.m_flags = KeyContainerPermissionFlags.NoFlags;
			string text = securityElement.Attribute("Flags");
			if (text != null)
			{
				KeyContainerPermissionFlags flags = (KeyContainerPermissionFlags)Enum.Parse(typeof(KeyContainerPermissionFlags), text);
				KeyContainerPermission.VerifyFlags(flags);
				this.m_flags = flags;
			}
			this.m_accessEntries = new KeyContainerPermissionAccessEntryCollection(this.m_flags);
			if (securityElement.InternalChildren != null && securityElement.InternalChildren.Count != 0)
			{
				foreach (object obj in securityElement.Children)
				{
					SecurityElement securityElement2 = (SecurityElement)obj;
					if (securityElement2 != null && string.Equals(securityElement2.Tag, "AccessList"))
					{
						this.AddAccessEntries(securityElement2);
					}
				}
			}
		}

		// Token: 0x060026CB RID: 9931 RVA: 0x0008CA22 File Offset: 0x0008AC22
		int IBuiltInPermission.GetTokenIndex()
		{
			return KeyContainerPermission.GetTokenIndex();
		}

		// Token: 0x060026CC RID: 9932 RVA: 0x0008CA2C File Offset: 0x0008AC2C
		private void AddAccessEntries(SecurityElement securityElement)
		{
			if (securityElement.InternalChildren != null && securityElement.InternalChildren.Count != 0)
			{
				foreach (object obj in securityElement.Children)
				{
					SecurityElement securityElement2 = (SecurityElement)obj;
					if (securityElement2 != null && string.Equals(securityElement2.Tag, "AccessEntry"))
					{
						int count = securityElement2.m_lAttributes.Count;
						string keyStore = null;
						string providerName = null;
						int providerType = -1;
						string keyContainerName = null;
						int keySpec = -1;
						KeyContainerPermissionFlags flags = KeyContainerPermissionFlags.NoFlags;
						for (int i = 0; i < count; i += 2)
						{
							string a = (string)securityElement2.m_lAttributes[i];
							string text = (string)securityElement2.m_lAttributes[i + 1];
							if (string.Equals(a, "KeyStore"))
							{
								keyStore = text;
							}
							if (string.Equals(a, "ProviderName"))
							{
								providerName = text;
							}
							else if (string.Equals(a, "ProviderType"))
							{
								providerType = Convert.ToInt32(text, null);
							}
							else if (string.Equals(a, "KeyContainerName"))
							{
								keyContainerName = text;
							}
							else if (string.Equals(a, "KeySpec"))
							{
								keySpec = Convert.ToInt32(text, null);
							}
							else if (string.Equals(a, "Flags"))
							{
								flags = (KeyContainerPermissionFlags)Enum.Parse(typeof(KeyContainerPermissionFlags), text);
							}
						}
						KeyContainerPermissionAccessEntry accessEntry = new KeyContainerPermissionAccessEntry(keyStore, providerName, providerType, keyContainerName, keySpec, flags);
						this.AccessEntries.Add(accessEntry);
					}
				}
			}
		}

		// Token: 0x060026CD RID: 9933 RVA: 0x0008CBA8 File Offset: 0x0008ADA8
		private void AddAccessEntryAndUnion(KeyContainerPermissionAccessEntry accessEntry, KeyContainerPermission target)
		{
			KeyContainerPermissionAccessEntry keyContainerPermissionAccessEntry = new KeyContainerPermissionAccessEntry(accessEntry);
			keyContainerPermissionAccessEntry.Flags |= KeyContainerPermission.GetApplicableFlags(accessEntry, target);
			this.AccessEntries.Add(keyContainerPermissionAccessEntry);
		}

		// Token: 0x060026CE RID: 9934 RVA: 0x0008CBE0 File Offset: 0x0008ADE0
		private void AddAccessEntryAndIntersect(KeyContainerPermissionAccessEntry accessEntry, KeyContainerPermission target)
		{
			KeyContainerPermissionAccessEntry keyContainerPermissionAccessEntry = new KeyContainerPermissionAccessEntry(accessEntry);
			keyContainerPermissionAccessEntry.Flags &= KeyContainerPermission.GetApplicableFlags(accessEntry, target);
			this.AccessEntries.Add(keyContainerPermissionAccessEntry);
		}

		// Token: 0x060026CF RID: 9935 RVA: 0x0008CC15 File Offset: 0x0008AE15
		internal static void VerifyFlags(KeyContainerPermissionFlags flags)
		{
			if ((flags & ~(KeyContainerPermissionFlags.Create | KeyContainerPermissionFlags.Open | KeyContainerPermissionFlags.Delete | KeyContainerPermissionFlags.Import | KeyContainerPermissionFlags.Export | KeyContainerPermissionFlags.Sign | KeyContainerPermissionFlags.Decrypt | KeyContainerPermissionFlags.ViewAcl | KeyContainerPermissionFlags.ChangeAcl)) != KeyContainerPermissionFlags.NoFlags)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", new object[]
				{
					(int)flags
				}));
			}
		}

		// Token: 0x060026D0 RID: 9936 RVA: 0x0008CC40 File Offset: 0x0008AE40
		private static KeyContainerPermissionFlags GetApplicableFlags(KeyContainerPermissionAccessEntry accessEntry, KeyContainerPermission target)
		{
			KeyContainerPermissionFlags keyContainerPermissionFlags = KeyContainerPermissionFlags.NoFlags;
			bool flag = true;
			int num = target.AccessEntries.IndexOf(accessEntry);
			if (num != -1)
			{
				return target.AccessEntries[num].Flags;
			}
			foreach (KeyContainerPermissionAccessEntry keyContainerPermissionAccessEntry in target.AccessEntries)
			{
				if (accessEntry.IsSubsetOf(keyContainerPermissionAccessEntry))
				{
					if (!flag)
					{
						keyContainerPermissionFlags &= keyContainerPermissionAccessEntry.Flags;
					}
					else
					{
						keyContainerPermissionFlags = keyContainerPermissionAccessEntry.Flags;
						flag = false;
					}
				}
			}
			if (flag)
			{
				keyContainerPermissionFlags = target.Flags;
			}
			return keyContainerPermissionFlags;
		}

		// Token: 0x060026D1 RID: 9937 RVA: 0x0008CCC2 File Offset: 0x0008AEC2
		private static int GetTokenIndex()
		{
			return 16;
		}

		// Token: 0x04000EB8 RID: 3768
		private KeyContainerPermissionFlags m_flags;

		// Token: 0x04000EB9 RID: 3769
		private KeyContainerPermissionAccessEntryCollection m_accessEntries;
	}
}
