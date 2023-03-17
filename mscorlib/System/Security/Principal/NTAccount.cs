using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Principal
{
	/// <summary>Represents a user or group account.</summary>
	// Token: 0x0200030A RID: 778
	[ComVisible(false)]
	public sealed class NTAccount : IdentityReference
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Principal.NTAccount" /> class by using the specified domain name and account name.</summary>
		/// <param name="domainName">The name of the domain. This parameter can be <see langword="null" /> or an empty string. Domain names that are null values are treated like an empty string.</param>
		/// <param name="accountName">The name of the account. This parameter cannot be <see langword="null" /> or an empty string.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="accountName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="accountName" /> is an empty string.  
		/// -or-  
		/// <paramref name="accountName" /> is too long.  
		/// -or-  
		/// <paramref name="domainName" /> is too long.</exception>
		// Token: 0x060027F4 RID: 10228 RVA: 0x00092B34 File Offset: 0x00090D34
		public NTAccount(string domainName, string accountName)
		{
			if (accountName == null)
			{
				throw new ArgumentNullException("accountName");
			}
			if (accountName.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_StringZeroLength"), "accountName");
			}
			if (accountName.Length > 256)
			{
				throw new ArgumentException(Environment.GetResourceString("IdentityReference_AccountNameTooLong"), "accountName");
			}
			if (domainName != null && domainName.Length > 255)
			{
				throw new ArgumentException(Environment.GetResourceString("IdentityReference_DomainNameTooLong"), "domainName");
			}
			if (domainName == null || domainName.Length == 0)
			{
				this._Name = accountName;
				return;
			}
			this._Name = domainName + "\\" + accountName;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Principal.NTAccount" /> class by using the specified name.</summary>
		/// <param name="name">The name used to create the <see cref="T:System.Security.Principal.NTAccount" /> object. This parameter cannot be <see langword="null" /> or an empty string.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="name" /> is an empty string.  
		/// -or-  
		/// <paramref name="name" /> is too long.</exception>
		// Token: 0x060027F5 RID: 10229 RVA: 0x00092BE0 File Offset: 0x00090DE0
		public NTAccount(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_StringZeroLength"), "name");
			}
			if (name.Length > 512)
			{
				throw new ArgumentException(Environment.GetResourceString("IdentityReference_AccountNameTooLong"), "name");
			}
			this._Name = name;
		}

		/// <summary>Returns an uppercase string representation of this <see cref="T:System.Security.Principal.NTAccount" /> object.</summary>
		/// <returns>The uppercase string representation of this <see cref="T:System.Security.Principal.NTAccount" /> object.</returns>
		// Token: 0x17000545 RID: 1349
		// (get) Token: 0x060027F6 RID: 10230 RVA: 0x00092C47 File Offset: 0x00090E47
		public override string Value
		{
			get
			{
				return this.ToString();
			}
		}

		/// <summary>Returns a value that indicates whether the specified type is a valid translation type for the <see cref="T:System.Security.Principal.NTAccount" /> class.</summary>
		/// <param name="targetType">The type being queried for validity to serve as a conversion from <see cref="T:System.Security.Principal.NTAccount" />. The following target types are valid:  
		///  - <see cref="T:System.Security.Principal.NTAccount" />  
		///  - <see cref="T:System.Security.Principal.SecurityIdentifier" /></param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="targetType" /> is a valid translation type for the <see cref="T:System.Security.Principal.NTAccount" /> class; otherwise <see langword="false" />.</returns>
		// Token: 0x060027F7 RID: 10231 RVA: 0x00092C4F File Offset: 0x00090E4F
		public override bool IsValidTargetType(Type targetType)
		{
			return targetType == typeof(SecurityIdentifier) || targetType == typeof(NTAccount);
		}

		/// <summary>Translates the account name represented by the <see cref="T:System.Security.Principal.NTAccount" /> object into another <see cref="T:System.Security.Principal.IdentityReference" />-derived type.</summary>
		/// <param name="targetType">The target type for the conversion from <see cref="T:System.Security.Principal.NTAccount" />. The target type must be a type that is considered valid by the <see cref="M:System.Security.Principal.NTAccount.IsValidTargetType(System.Type)" /> method.</param>
		/// <returns>The converted identity.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="targetType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="targetType" /> is not an <see cref="T:System.Security.Principal.IdentityReference" /> type.</exception>
		/// <exception cref="T:System.Security.Principal.IdentityNotMappedException">Some or all identity references could not be translated.</exception>
		/// <exception cref="T:System.SystemException">The source account name is too long.  
		///  -or-  
		///  A Win32 error code was returned.</exception>
		// Token: 0x060027F8 RID: 10232 RVA: 0x00092C7C File Offset: 0x00090E7C
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, ControlPrincipal = true)]
		public override IdentityReference Translate(Type targetType)
		{
			if (targetType == null)
			{
				throw new ArgumentNullException("targetType");
			}
			if (targetType == typeof(NTAccount))
			{
				return this;
			}
			if (targetType == typeof(SecurityIdentifier))
			{
				IdentityReferenceCollection identityReferenceCollection = NTAccount.Translate(new IdentityReferenceCollection(1)
				{
					this
				}, targetType, true);
				return identityReferenceCollection[0];
			}
			throw new ArgumentException(Environment.GetResourceString("IdentityReference_MustBeIdentityReference"), "targetType");
		}

		/// <summary>Returns a value that indicates whether this <see cref="T:System.Security.Principal.NTAccount" /> object is equal to a specified object.</summary>
		/// <param name="o">An object to compare with this <see cref="T:System.Security.Principal.NTAccount" /> object, or <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="o" /> is an object with the same underlying type and value as this <see cref="T:System.Security.Principal.NTAccount" /> object; otherwise, <see langword="false" />.</returns>
		// Token: 0x060027F9 RID: 10233 RVA: 0x00092CF8 File Offset: 0x00090EF8
		public override bool Equals(object o)
		{
			if (o == null)
			{
				return false;
			}
			NTAccount ntaccount = o as NTAccount;
			return !(ntaccount == null) && this == ntaccount;
		}

		/// <summary>Serves as a hash function for the current <see cref="T:System.Security.Principal.NTAccount" /> object. The <see cref="M:System.Security.Principal.NTAccount.GetHashCode" /> method is suitable for hashing algorithms and data structures like a hash table.</summary>
		/// <returns>A hash value for the current <see cref="T:System.Security.Principal.NTAccount" /> object.</returns>
		// Token: 0x060027FA RID: 10234 RVA: 0x00092D23 File Offset: 0x00090F23
		public override int GetHashCode()
		{
			return StringComparer.InvariantCultureIgnoreCase.GetHashCode(this._Name);
		}

		/// <summary>Returns the account name, in Domain \ Account format, for the account represented by the <see cref="T:System.Security.Principal.NTAccount" /> object.</summary>
		/// <returns>The account name, in Domain \ Account format.</returns>
		// Token: 0x060027FB RID: 10235 RVA: 0x00092D35 File Offset: 0x00090F35
		public override string ToString()
		{
			return this._Name;
		}

		// Token: 0x060027FC RID: 10236 RVA: 0x00092D40 File Offset: 0x00090F40
		[SecurityCritical]
		internal static IdentityReferenceCollection Translate(IdentityReferenceCollection sourceAccounts, Type targetType, bool forceSuccess)
		{
			bool flag = false;
			IdentityReferenceCollection identityReferenceCollection = NTAccount.Translate(sourceAccounts, targetType, out flag);
			if (forceSuccess && flag)
			{
				IdentityReferenceCollection identityReferenceCollection2 = new IdentityReferenceCollection();
				foreach (IdentityReference identityReference in identityReferenceCollection)
				{
					if (identityReference.GetType() != targetType)
					{
						identityReferenceCollection2.Add(identityReference);
					}
				}
				throw new IdentityNotMappedException(Environment.GetResourceString("IdentityReference_IdentityNotMapped"), identityReferenceCollection2);
			}
			return identityReferenceCollection;
		}

		// Token: 0x060027FD RID: 10237 RVA: 0x00092DC4 File Offset: 0x00090FC4
		[SecurityCritical]
		internal static IdentityReferenceCollection Translate(IdentityReferenceCollection sourceAccounts, Type targetType, out bool someFailed)
		{
			if (sourceAccounts == null)
			{
				throw new ArgumentNullException("sourceAccounts");
			}
			if (targetType == typeof(SecurityIdentifier))
			{
				return NTAccount.TranslateToSids(sourceAccounts, out someFailed);
			}
			throw new ArgumentException(Environment.GetResourceString("IdentityReference_MustBeIdentityReference"), "targetType");
		}

		/// <summary>Compares two <see cref="T:System.Security.Principal.NTAccount" /> objects to determine whether they are equal. They are considered equal if they have the same canonical name representation as the one returned by the <see cref="P:System.Security.Principal.NTAccount.Value" /> property or if they are both <see langword="null" />.</summary>
		/// <param name="left">The left operand to use for the equality comparison. This parameter can be <see langword="null" />.</param>
		/// <param name="right">The right operand to use for the equality comparison. This parameter can be <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise <see langword="false" />.</returns>
		// Token: 0x060027FE RID: 10238 RVA: 0x00092E04 File Offset: 0x00091004
		public static bool operator ==(NTAccount left, NTAccount right)
		{
			return (left == null && right == null) || (left != null && right != null && left.ToString().Equals(right.ToString(), StringComparison.OrdinalIgnoreCase));
		}

		/// <summary>Compares two <see cref="T:System.Security.Principal.NTAccount" /> objects to determine whether they are not equal. They are considered not equal if they have different canonical name representations than the one returned by the <see cref="P:System.Security.Principal.NTAccount.Value" /> property or if one of the objects is <see langword="null" /> and the other is not.</summary>
		/// <param name="left">The left operand to use for the inequality comparison. This parameter can be <see langword="null" />.</param>
		/// <param name="right">The right operand to use for the inequality comparison. This parameter can be <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise <see langword="false" />.</returns>
		// Token: 0x060027FF RID: 10239 RVA: 0x00092E37 File Offset: 0x00091037
		public static bool operator !=(NTAccount left, NTAccount right)
		{
			return !(left == right);
		}

		// Token: 0x06002800 RID: 10240 RVA: 0x00092E44 File Offset: 0x00091044
		[SecurityCritical]
		private static IdentityReferenceCollection TranslateToSids(IdentityReferenceCollection sourceAccounts, out bool someFailed)
		{
			if (sourceAccounts == null)
			{
				throw new ArgumentNullException("sourceAccounts");
			}
			if (sourceAccounts.Count == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EmptyCollection"), "sourceAccounts");
			}
			SafeLsaPolicyHandle safeLsaPolicyHandle = SafeLsaPolicyHandle.InvalidHandle;
			SafeLsaMemoryHandle invalidHandle = SafeLsaMemoryHandle.InvalidHandle;
			SafeLsaMemoryHandle invalidHandle2 = SafeLsaMemoryHandle.InvalidHandle;
			IdentityReferenceCollection result;
			try
			{
				Win32Native.UNICODE_STRING[] array = new Win32Native.UNICODE_STRING[sourceAccounts.Count];
				int num = 0;
				foreach (IdentityReference identityReference in sourceAccounts)
				{
					NTAccount ntaccount = identityReference as NTAccount;
					if (ntaccount == null)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_ImproperType"), "sourceAccounts");
					}
					array[num].Buffer = ntaccount.ToString();
					if (array[num].Buffer.Length * 2 + 2 > 65535)
					{
						throw new SystemException();
					}
					array[num].Length = (ushort)(array[num].Buffer.Length * 2);
					array[num].MaximumLength = array[num].Length + 2;
					num++;
				}
				safeLsaPolicyHandle = Win32.LsaOpenPolicy(null, PolicyRights.POLICY_LOOKUP_NAMES);
				someFailed = false;
				uint num2;
				if (Win32.LsaLookupNames2Supported)
				{
					num2 = Win32Native.LsaLookupNames2(safeLsaPolicyHandle, 0, sourceAccounts.Count, array, ref invalidHandle, ref invalidHandle2);
				}
				else
				{
					num2 = Win32Native.LsaLookupNames(safeLsaPolicyHandle, sourceAccounts.Count, array, ref invalidHandle, ref invalidHandle2);
				}
				if (num2 == 3221225495U || num2 == 3221225626U)
				{
					throw new OutOfMemoryException();
				}
				if (num2 == 3221225506U)
				{
					throw new UnauthorizedAccessException();
				}
				if (num2 == 3221225587U || num2 == 263U)
				{
					someFailed = true;
				}
				else if (num2 != 0U)
				{
					int errorCode = Win32Native.LsaNtStatusToWinError((int)num2);
					throw new SystemException(Win32Native.GetMessage(errorCode));
				}
				IdentityReferenceCollection identityReferenceCollection = new IdentityReferenceCollection(sourceAccounts.Count);
				if (num2 == 0U || num2 == 263U)
				{
					if (Win32.LsaLookupNames2Supported)
					{
						invalidHandle2.Initialize((uint)sourceAccounts.Count, (uint)Marshal.SizeOf(typeof(Win32Native.LSA_TRANSLATED_SID2)));
						Win32.InitializeReferencedDomainsPointer(invalidHandle);
						Win32Native.LSA_TRANSLATED_SID2[] array2 = new Win32Native.LSA_TRANSLATED_SID2[sourceAccounts.Count];
						invalidHandle2.ReadArray<Win32Native.LSA_TRANSLATED_SID2>(0UL, array2, 0, array2.Length);
						int i = 0;
						while (i < sourceAccounts.Count)
						{
							Win32Native.LSA_TRANSLATED_SID2 lsa_TRANSLATED_SID = array2[i];
							switch (lsa_TRANSLATED_SID.Use)
							{
							case 1:
							case 2:
							case 4:
							case 5:
							case 9:
								identityReferenceCollection.Add(new SecurityIdentifier(lsa_TRANSLATED_SID.Sid, true));
								break;
							case 3:
							case 6:
							case 7:
							case 8:
								goto IL_282;
							default:
								goto IL_282;
							}
							IL_294:
							i++;
							continue;
							IL_282:
							someFailed = true;
							identityReferenceCollection.Add(sourceAccounts[i]);
							goto IL_294;
						}
					}
					else
					{
						invalidHandle2.Initialize((uint)sourceAccounts.Count, (uint)Marshal.SizeOf(typeof(Win32Native.LSA_TRANSLATED_SID)));
						Win32.InitializeReferencedDomainsPointer(invalidHandle);
						Win32Native.LSA_REFERENCED_DOMAIN_LIST lsa_REFERENCED_DOMAIN_LIST = invalidHandle.Read<Win32Native.LSA_REFERENCED_DOMAIN_LIST>(0UL);
						SecurityIdentifier[] array3 = new SecurityIdentifier[lsa_REFERENCED_DOMAIN_LIST.Entries];
						for (int j = 0; j < lsa_REFERENCED_DOMAIN_LIST.Entries; j++)
						{
							Win32Native.LSA_TRUST_INFORMATION lsa_TRUST_INFORMATION = (Win32Native.LSA_TRUST_INFORMATION)Marshal.PtrToStructure(new IntPtr((long)lsa_REFERENCED_DOMAIN_LIST.Domains + (long)(j * Marshal.SizeOf(typeof(Win32Native.LSA_TRUST_INFORMATION)))), typeof(Win32Native.LSA_TRUST_INFORMATION));
							array3[j] = new SecurityIdentifier(lsa_TRUST_INFORMATION.Sid, true);
						}
						Win32Native.LSA_TRANSLATED_SID[] array4 = new Win32Native.LSA_TRANSLATED_SID[sourceAccounts.Count];
						invalidHandle2.ReadArray<Win32Native.LSA_TRANSLATED_SID>(0UL, array4, 0, array4.Length);
						int k = 0;
						while (k < sourceAccounts.Count)
						{
							Win32Native.LSA_TRANSLATED_SID lsa_TRANSLATED_SID2 = array4[k];
							switch (lsa_TRANSLATED_SID2.Use)
							{
							case 1:
							case 2:
							case 4:
							case 5:
							case 9:
								identityReferenceCollection.Add(new SecurityIdentifier(array3[lsa_TRANSLATED_SID2.DomainIndex], lsa_TRANSLATED_SID2.Rid));
								break;
							case 3:
							case 6:
							case 7:
							case 8:
								goto IL_3C8;
							default:
								goto IL_3C8;
							}
							IL_3DA:
							k++;
							continue;
							IL_3C8:
							someFailed = true;
							identityReferenceCollection.Add(sourceAccounts[k]);
							goto IL_3DA;
						}
					}
				}
				else
				{
					for (int l = 0; l < sourceAccounts.Count; l++)
					{
						identityReferenceCollection.Add(sourceAccounts[l]);
					}
				}
				result = identityReferenceCollection;
			}
			finally
			{
				safeLsaPolicyHandle.Dispose();
				invalidHandle.Dispose();
				invalidHandle2.Dispose();
			}
			return result;
		}

		// Token: 0x04000FD8 RID: 4056
		private readonly string _Name;

		// Token: 0x04000FD9 RID: 4057
		internal const int MaximumAccountNameLength = 256;

		// Token: 0x04000FDA RID: 4058
		internal const int MaximumDomainNameLength = 255;
	}
}
