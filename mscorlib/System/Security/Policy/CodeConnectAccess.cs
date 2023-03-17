using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	/// <summary>Specifies the network resource access that is granted to code.</summary>
	// Token: 0x02000331 RID: 817
	[ComVisible(true)]
	[Serializable]
	public class CodeConnectAccess
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.CodeConnectAccess" /> class.</summary>
		/// <param name="allowScheme">The URI scheme represented by the current instance.</param>
		/// <param name="allowPort">The port represented by the current instance.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="allowScheme" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="allowScheme" /> is an empty string ("").  
		/// -or-  
		/// <paramref name="allowScheme" /> contains characters that are not permitted in schemes.  
		/// -or-  
		/// <paramref name="allowPort" /> is less than 0.  
		/// -or-  
		/// <paramref name="allowPort" /> is greater than 65,535.</exception>
		// Token: 0x06002968 RID: 10600 RVA: 0x000987B5 File Offset: 0x000969B5
		public CodeConnectAccess(string allowScheme, int allowPort)
		{
			if (!CodeConnectAccess.IsValidScheme(allowScheme))
			{
				throw new ArgumentOutOfRangeException("allowScheme");
			}
			this.SetCodeConnectAccess(allowScheme.ToLower(CultureInfo.InvariantCulture), allowPort);
		}

		/// <summary>Returns a <see cref="T:System.Security.Policy.CodeConnectAccess" /> instance that represents access to the specified port using the code's scheme of origin.</summary>
		/// <param name="allowPort">The port represented by the returned instance.</param>
		/// <returns>A <see cref="T:System.Security.Policy.CodeConnectAccess" /> instance for the specified port.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="allowPort" /> is less than 0.  
		/// -or-  
		/// <paramref name="allowPort" /> is greater than 65,535.</exception>
		// Token: 0x06002969 RID: 10601 RVA: 0x000987E4 File Offset: 0x000969E4
		public static CodeConnectAccess CreateOriginSchemeAccess(int allowPort)
		{
			CodeConnectAccess codeConnectAccess = new CodeConnectAccess();
			codeConnectAccess.SetCodeConnectAccess(CodeConnectAccess.OriginScheme, allowPort);
			return codeConnectAccess;
		}

		/// <summary>Returns a <see cref="T:System.Security.Policy.CodeConnectAccess" /> instance that represents access to the specified port using any scheme.</summary>
		/// <param name="allowPort">The port represented by the returned instance.</param>
		/// <returns>A <see cref="T:System.Security.Policy.CodeConnectAccess" /> instance for the specified port.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="allowPort" /> is less than 0.  
		/// -or-  
		/// <paramref name="allowPort" /> is greater than 65,535.</exception>
		// Token: 0x0600296A RID: 10602 RVA: 0x00098804 File Offset: 0x00096A04
		public static CodeConnectAccess CreateAnySchemeAccess(int allowPort)
		{
			CodeConnectAccess codeConnectAccess = new CodeConnectAccess();
			codeConnectAccess.SetCodeConnectAccess(CodeConnectAccess.AnyScheme, allowPort);
			return codeConnectAccess;
		}

		// Token: 0x0600296B RID: 10603 RVA: 0x00098824 File Offset: 0x00096A24
		private CodeConnectAccess()
		{
		}

		// Token: 0x0600296C RID: 10604 RVA: 0x0009882C File Offset: 0x00096A2C
		private void SetCodeConnectAccess(string lowerCaseScheme, int allowPort)
		{
			this._LowerCaseScheme = lowerCaseScheme;
			if (allowPort == CodeConnectAccess.DefaultPort)
			{
				this._LowerCasePort = "$default";
			}
			else if (allowPort == CodeConnectAccess.OriginPort)
			{
				this._LowerCasePort = "$origin";
			}
			else
			{
				if (allowPort < 0 || allowPort > 65535)
				{
					throw new ArgumentOutOfRangeException("allowPort");
				}
				this._LowerCasePort = allowPort.ToString(CultureInfo.InvariantCulture);
			}
			this._IntPort = allowPort;
		}

		/// <summary>Gets the URI scheme represented by the current instance.</summary>
		/// <returns>A <see cref="T:System.String" /> that identifies a URI scheme, converted to lowercase.</returns>
		// Token: 0x17000593 RID: 1427
		// (get) Token: 0x0600296D RID: 10605 RVA: 0x0009889A File Offset: 0x00096A9A
		public string Scheme
		{
			get
			{
				return this._LowerCaseScheme;
			}
		}

		/// <summary>Gets the port represented by the current instance.</summary>
		/// <returns>A <see cref="T:System.Int32" /> value that identifies a computer port used in conjunction with the <see cref="P:System.Security.Policy.CodeConnectAccess.Scheme" /> property.</returns>
		// Token: 0x17000594 RID: 1428
		// (get) Token: 0x0600296E RID: 10606 RVA: 0x000988A2 File Offset: 0x00096AA2
		public int Port
		{
			get
			{
				return this._IntPort;
			}
		}

		/// <summary>Returns a value indicating whether two <see cref="T:System.Security.Policy.CodeConnectAccess" /> objects represent the same scheme and port.</summary>
		/// <param name="o">The object to compare to the current <see cref="T:System.Security.Policy.CodeConnectAccess" /> object.</param>
		/// <returns>
		///   <see langword="true" /> if the two objects represent the same scheme and port; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600296F RID: 10607 RVA: 0x000988AC File Offset: 0x00096AAC
		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			CodeConnectAccess codeConnectAccess = o as CodeConnectAccess;
			return codeConnectAccess != null && this.Scheme == codeConnectAccess.Scheme && this.Port == codeConnectAccess.Port;
		}

		/// <summary>Serves as a hash function for a particular type.</summary>
		/// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
		// Token: 0x06002970 RID: 10608 RVA: 0x000988F0 File Offset: 0x00096AF0
		public override int GetHashCode()
		{
			return this.Scheme.GetHashCode() + this.Port.GetHashCode();
		}

		// Token: 0x06002971 RID: 10609 RVA: 0x00098918 File Offset: 0x00096B18
		internal CodeConnectAccess(string allowScheme, string allowPort)
		{
			if (allowScheme == null || allowScheme.Length == 0)
			{
				throw new ArgumentNullException("allowScheme");
			}
			if (allowPort == null || allowPort.Length == 0)
			{
				throw new ArgumentNullException("allowPort");
			}
			this._LowerCaseScheme = allowScheme.ToLower(CultureInfo.InvariantCulture);
			if (this._LowerCaseScheme == CodeConnectAccess.OriginScheme)
			{
				this._LowerCaseScheme = CodeConnectAccess.OriginScheme;
			}
			else if (this._LowerCaseScheme == CodeConnectAccess.AnyScheme)
			{
				this._LowerCaseScheme = CodeConnectAccess.AnyScheme;
			}
			else if (!CodeConnectAccess.IsValidScheme(this._LowerCaseScheme))
			{
				throw new ArgumentOutOfRangeException("allowScheme");
			}
			this._LowerCasePort = allowPort.ToLower(CultureInfo.InvariantCulture);
			if (this._LowerCasePort == "$default")
			{
				this._IntPort = CodeConnectAccess.DefaultPort;
				return;
			}
			if (this._LowerCasePort == "$origin")
			{
				this._IntPort = CodeConnectAccess.OriginPort;
				return;
			}
			this._IntPort = int.Parse(allowPort, CultureInfo.InvariantCulture);
			if (this._IntPort < 0 || this._IntPort > 65535)
			{
				throw new ArgumentOutOfRangeException("allowPort");
			}
			this._LowerCasePort = this._IntPort.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x17000595 RID: 1429
		// (get) Token: 0x06002972 RID: 10610 RVA: 0x00098A53 File Offset: 0x00096C53
		internal bool IsOriginScheme
		{
			get
			{
				return this._LowerCaseScheme == CodeConnectAccess.OriginScheme;
			}
		}

		// Token: 0x17000596 RID: 1430
		// (get) Token: 0x06002973 RID: 10611 RVA: 0x00098A62 File Offset: 0x00096C62
		internal bool IsAnyScheme
		{
			get
			{
				return this._LowerCaseScheme == CodeConnectAccess.AnyScheme;
			}
		}

		// Token: 0x17000597 RID: 1431
		// (get) Token: 0x06002974 RID: 10612 RVA: 0x00098A71 File Offset: 0x00096C71
		internal bool IsDefaultPort
		{
			get
			{
				return this.Port == CodeConnectAccess.DefaultPort;
			}
		}

		// Token: 0x17000598 RID: 1432
		// (get) Token: 0x06002975 RID: 10613 RVA: 0x00098A80 File Offset: 0x00096C80
		internal bool IsOriginPort
		{
			get
			{
				return this.Port == CodeConnectAccess.OriginPort;
			}
		}

		// Token: 0x17000599 RID: 1433
		// (get) Token: 0x06002976 RID: 10614 RVA: 0x00098A8F File Offset: 0x00096C8F
		internal string StrPort
		{
			get
			{
				return this._LowerCasePort;
			}
		}

		// Token: 0x06002977 RID: 10615 RVA: 0x00098A98 File Offset: 0x00096C98
		internal static bool IsValidScheme(string scheme)
		{
			if (scheme == null || scheme.Length == 0 || !CodeConnectAccess.IsAsciiLetter(scheme[0]))
			{
				return false;
			}
			for (int i = scheme.Length - 1; i > 0; i--)
			{
				if (!CodeConnectAccess.IsAsciiLetterOrDigit(scheme[i]) && scheme[i] != '+' && scheme[i] != '-' && scheme[i] != '.')
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06002978 RID: 10616 RVA: 0x00098B05 File Offset: 0x00096D05
		private static bool IsAsciiLetterOrDigit(char character)
		{
			return CodeConnectAccess.IsAsciiLetter(character) || (character >= '0' && character <= '9');
		}

		// Token: 0x06002979 RID: 10617 RVA: 0x00098B20 File Offset: 0x00096D20
		private static bool IsAsciiLetter(char character)
		{
			return (character >= 'a' && character <= 'z') || (character >= 'A' && character <= 'Z');
		}

		// Token: 0x04001092 RID: 4242
		private string _LowerCaseScheme;

		// Token: 0x04001093 RID: 4243
		private string _LowerCasePort;

		// Token: 0x04001094 RID: 4244
		private int _IntPort;

		// Token: 0x04001095 RID: 4245
		private const string DefaultStr = "$default";

		// Token: 0x04001096 RID: 4246
		private const string OriginStr = "$origin";

		// Token: 0x04001097 RID: 4247
		internal const int NoPort = -1;

		// Token: 0x04001098 RID: 4248
		internal const int AnyPort = -2;

		/// <summary>Contains the value used to represent the default port.</summary>
		// Token: 0x04001099 RID: 4249
		public static readonly int DefaultPort = -3;

		/// <summary>Contains the value used to represent the port value in the URI where code originated.</summary>
		// Token: 0x0400109A RID: 4250
		public static readonly int OriginPort = -4;

		/// <summary>Contains the value used to represent the scheme in the URL where the code originated.</summary>
		// Token: 0x0400109B RID: 4251
		public static readonly string OriginScheme = "$origin";

		/// <summary>Contains the string value that represents the scheme wildcard.</summary>
		// Token: 0x0400109C RID: 4252
		public static readonly string AnyScheme = "*";
	}
}
