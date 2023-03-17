using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Resources
{
	/// <summary>The exception that is thrown when the satellite assembly for the resources of the default culture is missing.</summary>
	// Token: 0x02000365 RID: 869
	[ComVisible(true)]
	[Serializable]
	public class MissingSatelliteAssemblyException : SystemException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Resources.MissingSatelliteAssemblyException" /> class with default properties.</summary>
		// Token: 0x06002BE5 RID: 11237 RVA: 0x000A571B File Offset: 0x000A391B
		public MissingSatelliteAssemblyException() : base(Environment.GetResourceString("MissingSatelliteAssembly_Default"))
		{
			base.SetErrorCode(-2146233034);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Resources.MissingSatelliteAssemblyException" /> class with the specified error message.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		// Token: 0x06002BE6 RID: 11238 RVA: 0x000A5738 File Offset: 0x000A3938
		public MissingSatelliteAssemblyException(string message) : base(message)
		{
			base.SetErrorCode(-2146233034);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Resources.MissingSatelliteAssemblyException" /> class with a specified error message and the name of a neutral culture.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="cultureName">The name of the neutral culture.</param>
		// Token: 0x06002BE7 RID: 11239 RVA: 0x000A574C File Offset: 0x000A394C
		public MissingSatelliteAssemblyException(string message, string cultureName) : base(message)
		{
			base.SetErrorCode(-2146233034);
			this._cultureName = cultureName;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Resources.MissingSatelliteAssemblyException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06002BE8 RID: 11240 RVA: 0x000A5767 File Offset: 0x000A3967
		public MissingSatelliteAssemblyException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146233034);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Resources.MissingSatelliteAssemblyException" /> class from serialized data.</summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination of the exception.</param>
		// Token: 0x06002BE9 RID: 11241 RVA: 0x000A577C File Offset: 0x000A397C
		protected MissingSatelliteAssemblyException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		/// <summary>Gets the name of the default culture.</summary>
		/// <returns>The name of the default culture.</returns>
		// Token: 0x170005CE RID: 1486
		// (get) Token: 0x06002BEA RID: 11242 RVA: 0x000A5786 File Offset: 0x000A3986
		public string CultureName
		{
			get
			{
				return this._cultureName;
			}
		}

		// Token: 0x04001172 RID: 4466
		private string _cultureName;
	}
}
