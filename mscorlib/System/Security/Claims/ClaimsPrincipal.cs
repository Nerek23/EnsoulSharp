using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;

namespace System.Security.Claims
{
	/// <summary>An <see cref="T:System.Security.Principal.IPrincipal" /> implementation that supports multiple claims-based identities.</summary>
	// Token: 0x020002F1 RID: 753
	[ComVisible(true)]
	[Serializable]
	public class ClaimsPrincipal : IPrincipal
	{
		// Token: 0x06002742 RID: 10050 RVA: 0x0008F628 File Offset: 0x0008D828
		private static ClaimsIdentity SelectPrimaryIdentity(IEnumerable<ClaimsIdentity> identities)
		{
			if (identities == null)
			{
				throw new ArgumentNullException("identities");
			}
			ClaimsIdentity claimsIdentity = null;
			foreach (ClaimsIdentity claimsIdentity2 in identities)
			{
				if (claimsIdentity2 is WindowsIdentity)
				{
					claimsIdentity = claimsIdentity2;
					break;
				}
				if (claimsIdentity == null)
				{
					claimsIdentity = claimsIdentity2;
				}
			}
			return claimsIdentity;
		}

		// Token: 0x06002743 RID: 10051 RVA: 0x0008F68C File Offset: 0x0008D88C
		private static ClaimsPrincipal SelectClaimsPrincipal()
		{
			ClaimsPrincipal claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
			if (claimsPrincipal != null)
			{
				return claimsPrincipal;
			}
			return new ClaimsPrincipal(Thread.CurrentPrincipal);
		}

		/// <summary>Gets or sets the delegate used to select the claims identity returned by the <see cref="P:System.Security.Claims.ClaimsPrincipal.Identity" /> property.</summary>
		/// <returns>The delegate. The default is <see langword="null" />.</returns>
		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x06002744 RID: 10052 RVA: 0x0008F6B3 File Offset: 0x0008D8B3
		// (set) Token: 0x06002745 RID: 10053 RVA: 0x0008F6BA File Offset: 0x0008D8BA
		public static Func<IEnumerable<ClaimsIdentity>, ClaimsIdentity> PrimaryIdentitySelector
		{
			get
			{
				return ClaimsPrincipal.s_identitySelector;
			}
			[SecurityCritical]
			set
			{
				ClaimsPrincipal.s_identitySelector = value;
			}
		}

		/// <summary>Gets or sets the delegate used to select the claims principal returned by the <see cref="P:System.Security.Claims.ClaimsPrincipal.Current" /> property.</summary>
		/// <returns>The delegate. The default is <see langword="null" />.</returns>
		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x06002746 RID: 10054 RVA: 0x0008F6C2 File Offset: 0x0008D8C2
		// (set) Token: 0x06002747 RID: 10055 RVA: 0x0008F6C9 File Offset: 0x0008D8C9
		public static Func<ClaimsPrincipal> ClaimsPrincipalSelector
		{
			get
			{
				return ClaimsPrincipal.s_principalSelector;
			}
			[SecurityCritical]
			set
			{
				ClaimsPrincipal.s_principalSelector = value;
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Claims.ClaimsPrincipal" /> class.</summary>
		// Token: 0x06002748 RID: 10056 RVA: 0x0008F6D1 File Offset: 0x0008D8D1
		public ClaimsPrincipal()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Claims.ClaimsPrincipal" /> class using the specified claims identities.</summary>
		/// <param name="identities">The identities from which to initialize the new claims principal.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="identities" /> is null.</exception>
		// Token: 0x06002749 RID: 10057 RVA: 0x0008F6EF File Offset: 0x0008D8EF
		public ClaimsPrincipal(IEnumerable<ClaimsIdentity> identities)
		{
			if (identities == null)
			{
				throw new ArgumentNullException("identities");
			}
			this.m_identities.AddRange(identities);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Claims.ClaimsPrincipal" /> class from the specified identity.</summary>
		/// <param name="identity">The identity from which to initialize the new claims principal.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="identity" /> is null.</exception>
		// Token: 0x0600274A RID: 10058 RVA: 0x0008F728 File Offset: 0x0008D928
		public ClaimsPrincipal(IIdentity identity)
		{
			if (identity == null)
			{
				throw new ArgumentNullException("identity");
			}
			ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
			if (claimsIdentity != null)
			{
				this.m_identities.Add(claimsIdentity);
				return;
			}
			this.m_identities.Add(new ClaimsIdentity(identity));
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Claims.ClaimsPrincipal" /> class from the specified principal.</summary>
		/// <param name="principal">The principal from which to initialize the new claims principal.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="principal" /> is null.</exception>
		// Token: 0x0600274B RID: 10059 RVA: 0x0008F788 File Offset: 0x0008D988
		public ClaimsPrincipal(IPrincipal principal)
		{
			if (principal == null)
			{
				throw new ArgumentNullException("principal");
			}
			ClaimsPrincipal claimsPrincipal = principal as ClaimsPrincipal;
			if (claimsPrincipal == null)
			{
				this.m_identities.Add(new ClaimsIdentity(principal.Identity));
				return;
			}
			if (claimsPrincipal.Identities != null)
			{
				this.m_identities.AddRange(claimsPrincipal.Identities);
			}
		}

		/// <summary>Initializes an instance of <see cref="T:System.Security.Claims.ClaimsPrincipal" /> with the specified <see cref="T:System.IO.BinaryReader" />.</summary>
		/// <param name="reader">A <see cref="T:System.IO.BinaryReader" /> pointing to a <see cref="T:System.Security.Claims.ClaimsPrincipal" />.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="reader" /> is <see langword="null" />.</exception>
		// Token: 0x0600274C RID: 10060 RVA: 0x0008F7F9 File Offset: 0x0008D9F9
		public ClaimsPrincipal(BinaryReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			this.Initialize(reader);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Claims.ClaimsPrincipal" /> class from a serialized stream created by using <see cref="T:System.Runtime.Serialization.ISerializable" />.</summary>
		/// <param name="info">The serialized data.</param>
		/// <param name="context">The context for serialization.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="info" /> is null.</exception>
		// Token: 0x0600274D RID: 10061 RVA: 0x0008F82C File Offset: 0x0008DA2C
		[SecurityCritical]
		protected ClaimsPrincipal(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			this.Deserialize(info, context);
		}

		/// <summary>Contains any additional data provided by a derived type. Typically set when calling <see cref="M:System.Security.Claims.ClaimsIdentity.WriteTo(System.IO.BinaryWriter,System.Byte[])" />.</summary>
		/// <returns>A <see cref="T:System.Byte" /> array representing the additional serialized data.</returns>
		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x0600274E RID: 10062 RVA: 0x0008F860 File Offset: 0x0008DA60
		protected virtual byte[] CustomSerializationData
		{
			get
			{
				return this.m_userSerializationData;
			}
		}

		/// <summary>Returns a copy of this instance.</summary>
		/// <returns>A new copy of the <see cref="T:System.Security.Claims.ClaimsPrincipal" /> object.</returns>
		// Token: 0x0600274F RID: 10063 RVA: 0x0008F868 File Offset: 0x0008DA68
		public virtual ClaimsPrincipal Clone()
		{
			return new ClaimsPrincipal(this);
		}

		/// <summary>Creates a new claims identity.</summary>
		/// <param name="reader">The binary reader.</param>
		/// <returns>The created claims identity.</returns>
		// Token: 0x06002750 RID: 10064 RVA: 0x0008F870 File Offset: 0x0008DA70
		protected virtual ClaimsIdentity CreateClaimsIdentity(BinaryReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			return new ClaimsIdentity(reader);
		}

		// Token: 0x06002751 RID: 10065 RVA: 0x0008F886 File Offset: 0x0008DA86
		[OnSerializing]
		[SecurityCritical]
		private void OnSerializingMethod(StreamingContext context)
		{
			if (this is ISerializable)
			{
				return;
			}
			this.m_serializedClaimsIdentities = this.SerializeIdentities();
		}

		// Token: 0x06002752 RID: 10066 RVA: 0x0008F89D File Offset: 0x0008DA9D
		[OnDeserialized]
		[SecurityCritical]
		private void OnDeserializedMethod(StreamingContext context)
		{
			if (this is ISerializable)
			{
				return;
			}
			this.DeserializeIdentities(this.m_serializedClaimsIdentities);
			this.m_serializedClaimsIdentities = null;
		}

		/// <summary>Populates the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with data needed to serialize the current <see cref="T:System.Security.Claims.ClaimsPrincipal" /> object.</summary>
		/// <param name="info">The object to populate with data.</param>
		/// <param name="context">The destination for this serialization. Can be <see langword="null" />.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="info" /> is <see langword="null" />.</exception>
		// Token: 0x06002753 RID: 10067 RVA: 0x0008F8BB File Offset: 0x0008DABB
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Assert, SerializationFormatter = true)]
		protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			info.AddValue("System.Security.ClaimsPrincipal.Identities", this.SerializeIdentities());
			info.AddValue("System.Security.ClaimsPrincipal.Version", this.m_version);
		}

		// Token: 0x06002754 RID: 10068 RVA: 0x0008F8F0 File Offset: 0x0008DAF0
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Assert, SerializationFormatter = true)]
		private void Deserialize(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			SerializationInfoEnumerator enumerator = info.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string name = enumerator.Name;
				if (!(name == "System.Security.ClaimsPrincipal.Identities"))
				{
					if (name == "System.Security.ClaimsPrincipal.Version")
					{
						this.m_version = info.GetString("System.Security.ClaimsPrincipal.Version");
					}
				}
				else
				{
					this.DeserializeIdentities(info.GetString("System.Security.ClaimsPrincipal.Identities"));
				}
			}
		}

		// Token: 0x06002755 RID: 10069 RVA: 0x0008F964 File Offset: 0x0008DB64
		[SecurityCritical]
		private void DeserializeIdentities(string identities)
		{
			this.m_identities = new List<ClaimsIdentity>();
			if (!string.IsNullOrEmpty(identities))
			{
				List<string> list = null;
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(identities)))
				{
					list = (List<string>)binaryFormatter.Deserialize(memoryStream, null, false);
					for (int i = 0; i < list.Count; i += 2)
					{
						ClaimsIdentity claimsIdentity = null;
						using (MemoryStream memoryStream2 = new MemoryStream(Convert.FromBase64String(list[i + 1])))
						{
							claimsIdentity = (ClaimsIdentity)binaryFormatter.Deserialize(memoryStream2, null, false);
						}
						if (!string.IsNullOrEmpty(list[i]))
						{
							long value;
							if (!long.TryParse(list[i], NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out value))
							{
								throw new SerializationException(Environment.GetResourceString("Serialization_CorruptedStream"));
							}
							claimsIdentity = new WindowsIdentity(claimsIdentity, new IntPtr(value));
						}
						this.m_identities.Add(claimsIdentity);
					}
				}
			}
		}

		// Token: 0x06002756 RID: 10070 RVA: 0x0008FA74 File Offset: 0x0008DC74
		[SecurityCritical]
		private string SerializeIdentities()
		{
			List<string> list = new List<string>();
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			foreach (ClaimsIdentity claimsIdentity in this.m_identities)
			{
				if (claimsIdentity.GetType() == typeof(WindowsIdentity))
				{
					WindowsIdentity windowsIdentity = claimsIdentity as WindowsIdentity;
					list.Add(windowsIdentity.GetTokenInternal().ToInt64().ToString(NumberFormatInfo.InvariantInfo));
					using (MemoryStream memoryStream = new MemoryStream())
					{
						binaryFormatter.Serialize(memoryStream, windowsIdentity.CloneAsBase(), null, false);
						list.Add(Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length));
						continue;
					}
				}
				using (MemoryStream memoryStream2 = new MemoryStream())
				{
					list.Add("");
					binaryFormatter.Serialize(memoryStream2, claimsIdentity, null, false);
					list.Add(Convert.ToBase64String(memoryStream2.GetBuffer(), 0, (int)memoryStream2.Length));
				}
			}
			string result;
			using (MemoryStream memoryStream3 = new MemoryStream())
			{
				binaryFormatter.Serialize(memoryStream3, list, null, false);
				result = Convert.ToBase64String(memoryStream3.GetBuffer(), 0, (int)memoryStream3.Length);
			}
			return result;
		}

		/// <summary>Adds the specified claims identity to this claims principal.</summary>
		/// <param name="identity">The claims identity to add.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="identity" /> is null.</exception>
		// Token: 0x06002757 RID: 10071 RVA: 0x0008FBFC File Offset: 0x0008DDFC
		[SecurityCritical]
		public virtual void AddIdentity(ClaimsIdentity identity)
		{
			if (identity == null)
			{
				throw new ArgumentNullException("identity");
			}
			this.m_identities.Add(identity);
		}

		/// <summary>Adds the specified claims identities to this claims principal.</summary>
		/// <param name="identities">The claims identities to add.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="identities" /> is null.</exception>
		// Token: 0x06002758 RID: 10072 RVA: 0x0008FC18 File Offset: 0x0008DE18
		[SecurityCritical]
		public virtual void AddIdentities(IEnumerable<ClaimsIdentity> identities)
		{
			if (identities == null)
			{
				throw new ArgumentNullException("identities");
			}
			this.m_identities.AddRange(identities);
		}

		/// <summary>Gets a collection that contains all of the claims from all of the claims identities associated with this claims principal.</summary>
		/// <returns>The claims associated with this principal.</returns>
		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x06002759 RID: 10073 RVA: 0x0008FC34 File Offset: 0x0008DE34
		public virtual IEnumerable<Claim> Claims
		{
			get
			{
				foreach (ClaimsIdentity claimsIdentity in this.Identities)
				{
					foreach (Claim claim in claimsIdentity.Claims)
					{
						yield return claim;
					}
					IEnumerator<Claim> enumerator2 = null;
				}
				IEnumerator<ClaimsIdentity> enumerator = null;
				yield break;
				yield break;
			}
		}

		/// <summary>Gets the current claims principal.</summary>
		/// <returns>The current claims principal.</returns>
		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x0600275A RID: 10074 RVA: 0x0008FC51 File Offset: 0x0008DE51
		public static ClaimsPrincipal Current
		{
			get
			{
				if (ClaimsPrincipal.s_principalSelector != null)
				{
					return ClaimsPrincipal.s_principalSelector();
				}
				return ClaimsPrincipal.SelectClaimsPrincipal();
			}
		}

		/// <summary>Retrieves all of the claims that are matched by the specified predicate.</summary>
		/// <param name="match">The function that performs the matching logic.</param>
		/// <returns>The matching claims.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="match" /> is null.</exception>
		// Token: 0x0600275B RID: 10075 RVA: 0x0008FC6C File Offset: 0x0008DE6C
		public virtual IEnumerable<Claim> FindAll(Predicate<Claim> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			List<Claim> list = new List<Claim>();
			foreach (ClaimsIdentity claimsIdentity in this.Identities)
			{
				if (claimsIdentity != null)
				{
					foreach (Claim item in claimsIdentity.FindAll(match))
					{
						list.Add(item);
					}
				}
			}
			return list.AsReadOnly();
		}

		/// <summary>Retrieves all or the claims that have the specified claim type.</summary>
		/// <param name="type">The claim type against which to match claims.</param>
		/// <returns>The matching claims.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="type" /> is null.</exception>
		// Token: 0x0600275C RID: 10076 RVA: 0x0008FD10 File Offset: 0x0008DF10
		public virtual IEnumerable<Claim> FindAll(string type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			List<Claim> list = new List<Claim>();
			foreach (ClaimsIdentity claimsIdentity in this.Identities)
			{
				if (claimsIdentity != null)
				{
					foreach (Claim item in claimsIdentity.FindAll(type))
					{
						list.Add(item);
					}
				}
			}
			return list.AsReadOnly();
		}

		/// <summary>Retrieves the first claim that is matched by the specified predicate.</summary>
		/// <param name="match">The function that performs the matching logic.</param>
		/// <returns>The first matching claim or <see langword="null" /> if no match is found.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="match" /> is null.</exception>
		// Token: 0x0600275D RID: 10077 RVA: 0x0008FDB4 File Offset: 0x0008DFB4
		public virtual Claim FindFirst(Predicate<Claim> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			Claim claim = null;
			foreach (ClaimsIdentity claimsIdentity in this.Identities)
			{
				if (claimsIdentity != null)
				{
					claim = claimsIdentity.FindFirst(match);
					if (claim != null)
					{
						return claim;
					}
				}
			}
			return claim;
		}

		/// <summary>Retrieves the first claim with the specified claim type.</summary>
		/// <param name="type">The claim type to match.</param>
		/// <returns>The first matching claim or <see langword="null" /> if no match is found.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="type" /> is null.</exception>
		// Token: 0x0600275E RID: 10078 RVA: 0x0008FE20 File Offset: 0x0008E020
		public virtual Claim FindFirst(string type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			Claim claim = null;
			for (int i = 0; i < this.m_identities.Count; i++)
			{
				if (this.m_identities[i] != null)
				{
					claim = this.m_identities[i].FindFirst(type);
					if (claim != null)
					{
						return claim;
					}
				}
			}
			return claim;
		}

		/// <summary>Determines whether any of the claims identities associated with this claims principal contains a claim that is matched by the specified predicate.</summary>
		/// <param name="match">The function that performs the matching logic.</param>
		/// <returns>
		///   <see langword="true" /> if a matching claim exists; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="match" /> is null.</exception>
		// Token: 0x0600275F RID: 10079 RVA: 0x0008FE7C File Offset: 0x0008E07C
		public virtual bool HasClaim(Predicate<Claim> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			for (int i = 0; i < this.m_identities.Count; i++)
			{
				if (this.m_identities[i] != null && this.m_identities[i].HasClaim(match))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>Determines whether any of the claims identities associated with this claims principal contains a claim with the specified claim type and value.</summary>
		/// <param name="type">The type of the claim to match.</param>
		/// <param name="value">The value of the claim to match.</param>
		/// <returns>
		///   <see langword="true" /> if a matching claim exists; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="type" /> is null.  
		/// -or-  
		/// <paramref name="value" /> is null.</exception>
		// Token: 0x06002760 RID: 10080 RVA: 0x0008FED4 File Offset: 0x0008E0D4
		public virtual bool HasClaim(string type, string value)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			for (int i = 0; i < this.m_identities.Count; i++)
			{
				if (this.m_identities[i] != null && this.m_identities[i].HasClaim(type, value))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>Gets a collection that contains all of the claims identities associated with this claims principal.</summary>
		/// <returns>The collection of claims identities.</returns>
		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x06002761 RID: 10081 RVA: 0x0008FF39 File Offset: 0x0008E139
		public virtual IEnumerable<ClaimsIdentity> Identities
		{
			get
			{
				return this.m_identities.AsReadOnly();
			}
		}

		/// <summary>Gets the primary claims identity associated with this claims principal.</summary>
		/// <returns>The primary claims identity associated with this claims principal.</returns>
		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x06002762 RID: 10082 RVA: 0x0008FF46 File Offset: 0x0008E146
		public virtual IIdentity Identity
		{
			get
			{
				if (ClaimsPrincipal.s_identitySelector != null)
				{
					return ClaimsPrincipal.s_identitySelector(this.m_identities);
				}
				return ClaimsPrincipal.SelectPrimaryIdentity(this.m_identities);
			}
		}

		/// <summary>Returns a value that indicates whether the entity (user) represented by this claims principal is in the specified role.</summary>
		/// <param name="role">The role for which to check.</param>
		/// <returns>
		///   <see langword="true" /> if claims principal is in the specified role; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002763 RID: 10083 RVA: 0x0008FF6C File Offset: 0x0008E16C
		public virtual bool IsInRole(string role)
		{
			for (int i = 0; i < this.m_identities.Count; i++)
			{
				if (this.m_identities[i] != null && this.m_identities[i].HasClaim(this.m_identities[i].RoleClaimType, role))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002764 RID: 10084 RVA: 0x0008FFC8 File Offset: 0x0008E1C8
		private void Initialize(BinaryReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			ClaimsPrincipal.SerializationMask serializationMask = (ClaimsPrincipal.SerializationMask)reader.ReadInt32();
			int num = reader.ReadInt32();
			int num2 = 0;
			if ((serializationMask & ClaimsPrincipal.SerializationMask.HasIdentities) == ClaimsPrincipal.SerializationMask.HasIdentities)
			{
				num2++;
				int num3 = reader.ReadInt32();
				for (int i = 0; i < num3; i++)
				{
					this.m_identities.Add(this.CreateClaimsIdentity(reader));
				}
			}
			if ((serializationMask & ClaimsPrincipal.SerializationMask.UserData) == ClaimsPrincipal.SerializationMask.UserData)
			{
				int count = reader.ReadInt32();
				this.m_userSerializationData = reader.ReadBytes(count);
				num2++;
			}
			for (int j = num2; j < num; j++)
			{
				reader.ReadString();
			}
		}

		/// <summary>Serializes using a <see cref="T:System.IO.BinaryWriter" />.</summary>
		/// <param name="writer">The writer to use for data storage.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="writer" /> is <see langword="null" />.</exception>
		// Token: 0x06002765 RID: 10085 RVA: 0x0009005D File Offset: 0x0008E25D
		public virtual void WriteTo(BinaryWriter writer)
		{
			this.WriteTo(writer, null);
		}

		/// <summary>Serializes using a <see cref="T:System.IO.BinaryWriter" />.</summary>
		/// <param name="writer">The writer to use for data storage.</param>
		/// <param name="userData">Additional data provided by the derived type.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="writer" /> is <see langword="null" />.</exception>
		// Token: 0x06002766 RID: 10086 RVA: 0x00090068 File Offset: 0x0008E268
		protected virtual void WriteTo(BinaryWriter writer, byte[] userData)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			int num = 0;
			ClaimsPrincipal.SerializationMask serializationMask = ClaimsPrincipal.SerializationMask.None;
			if (this.m_identities.Count > 0)
			{
				serializationMask |= ClaimsPrincipal.SerializationMask.HasIdentities;
				num++;
			}
			if (userData != null && userData.Length != 0)
			{
				num++;
				serializationMask |= ClaimsPrincipal.SerializationMask.UserData;
			}
			writer.Write((int)serializationMask);
			writer.Write(num);
			if ((serializationMask & ClaimsPrincipal.SerializationMask.HasIdentities) == ClaimsPrincipal.SerializationMask.HasIdentities)
			{
				writer.Write(this.m_identities.Count);
				foreach (ClaimsIdentity claimsIdentity in this.m_identities)
				{
					claimsIdentity.WriteTo(writer);
				}
			}
			if ((serializationMask & ClaimsPrincipal.SerializationMask.UserData) == ClaimsPrincipal.SerializationMask.UserData)
			{
				writer.Write(userData.Length);
				writer.Write(userData);
			}
			writer.Flush();
		}

		// Token: 0x04000EEA RID: 3818
		[NonSerialized]
		private byte[] m_userSerializationData;

		// Token: 0x04000EEB RID: 3819
		[NonSerialized]
		private const string PreFix = "System.Security.ClaimsPrincipal.";

		// Token: 0x04000EEC RID: 3820
		[NonSerialized]
		private const string IdentitiesKey = "System.Security.ClaimsPrincipal.Identities";

		// Token: 0x04000EED RID: 3821
		[NonSerialized]
		private const string VersionKey = "System.Security.ClaimsPrincipal.Version";

		// Token: 0x04000EEE RID: 3822
		[OptionalField(VersionAdded = 2)]
		private string m_version = "1.0";

		// Token: 0x04000EEF RID: 3823
		[OptionalField(VersionAdded = 2)]
		private string m_serializedClaimsIdentities;

		// Token: 0x04000EF0 RID: 3824
		[NonSerialized]
		private List<ClaimsIdentity> m_identities = new List<ClaimsIdentity>();

		// Token: 0x04000EF1 RID: 3825
		[NonSerialized]
		private static Func<IEnumerable<ClaimsIdentity>, ClaimsIdentity> s_identitySelector = new Func<IEnumerable<ClaimsIdentity>, ClaimsIdentity>(ClaimsPrincipal.SelectPrimaryIdentity);

		// Token: 0x04000EF2 RID: 3826
		[NonSerialized]
		private static Func<ClaimsPrincipal> s_principalSelector = ClaimsPrincipal.ClaimsPrincipalSelector;

		// Token: 0x02000B1C RID: 2844
		private enum SerializationMask
		{
			// Token: 0x0400330E RID: 13070
			None,
			// Token: 0x0400330F RID: 13071
			HasIdentities,
			// Token: 0x04003310 RID: 13072
			UserData
		}
	}
}
