using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Security.Principal
{
	/// <summary>Represents an exception for a principal whose identity could not be mapped to a known identity.</summary>
	// Token: 0x02000311 RID: 785
	[ComVisible(false)]
	[Serializable]
	public sealed class IdentityNotMappedException : SystemException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Principal.IdentityNotMappedException" /> class.</summary>
		// Token: 0x06002834 RID: 10292 RVA: 0x00094378 File Offset: 0x00092578
		public IdentityNotMappedException() : base(Environment.GetResourceString("IdentityReference_IdentityNotMapped"))
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Principal.IdentityNotMappedException" /> class by using the specified error message.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		// Token: 0x06002835 RID: 10293 RVA: 0x0009438A File Offset: 0x0009258A
		public IdentityNotMappedException(string message) : base(message)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Principal.IdentityNotMappedException" /> class by using the specified error message and inner exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If <paramref name="inner" /> is not null, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06002836 RID: 10294 RVA: 0x00094393 File Offset: 0x00092593
		public IdentityNotMappedException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x06002837 RID: 10295 RVA: 0x0009439D File Offset: 0x0009259D
		internal IdentityNotMappedException(string message, IdentityReferenceCollection unmappedIdentities) : this(message)
		{
			this.unmappedIdentities = unmappedIdentities;
		}

		// Token: 0x06002838 RID: 10296 RVA: 0x000943AD File Offset: 0x000925AD
		internal IdentityNotMappedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		/// <summary>Gets serialization information with the data needed to create an instance of this <see cref="T:System.Security.Principal.IdentityNotMappedException" /> object.</summary>
		/// <param name="serializationInfo">The object that holds the serialized object data about the exception being thrown.</param>
		/// <param name="streamingContext">The object that contains contextual information about the source or destination.</param>
		// Token: 0x06002839 RID: 10297 RVA: 0x000943B7 File Offset: 0x000925B7
		[SecurityCritical]
		public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			base.GetObjectData(serializationInfo, streamingContext);
		}

		/// <summary>Represents the collection of unmapped identities for an <see cref="T:System.Security.Principal.IdentityNotMappedException" /> exception.</summary>
		/// <returns>The collection of unmapped identities.</returns>
		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x0600283A RID: 10298 RVA: 0x000943C1 File Offset: 0x000925C1
		public IdentityReferenceCollection UnmappedIdentities
		{
			get
			{
				if (this.unmappedIdentities == null)
				{
					this.unmappedIdentities = new IdentityReferenceCollection();
				}
				return this.unmappedIdentities;
			}
		}

		// Token: 0x0400104B RID: 4171
		private IdentityReferenceCollection unmappedIdentities;
	}
}
