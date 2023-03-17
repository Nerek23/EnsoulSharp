using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Reflection.Emit
{
	/// <summary>Represents the class that describes how to marshal a field from managed to unmanaged code. This class cannot be inherited.</summary>
	// Token: 0x0200063E RID: 1598
	[ComVisible(true)]
	[Obsolete("An alternate API is available: Emit the MarshalAs custom attribute instead. http://go.microsoft.com/fwlink/?linkid=14202")]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	[Serializable]
	public sealed class UnmanagedMarshal
	{
		/// <summary>Specifies a given type that is to be marshaled to unmanaged code.</summary>
		/// <param name="unmanagedType">The unmanaged type to which the type is to be marshaled.</param>
		/// <returns>An <see cref="T:System.Reflection.Emit.UnmanagedMarshal" /> object.</returns>
		/// <exception cref="T:System.ArgumentException">The argument is not a simple native type.</exception>
		// Token: 0x06004DEA RID: 19946 RVA: 0x00117646 File Offset: 0x00115846
		public static UnmanagedMarshal DefineUnmanagedMarshal(UnmanagedType unmanagedType)
		{
			if (unmanagedType == UnmanagedType.ByValTStr || unmanagedType == UnmanagedType.SafeArray || unmanagedType == UnmanagedType.CustomMarshaler || unmanagedType == UnmanagedType.ByValArray || unmanagedType == UnmanagedType.LPArray)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NotASimpleNativeType"));
			}
			return new UnmanagedMarshal(unmanagedType, Guid.Empty, 0, (UnmanagedType)0);
		}

		/// <summary>Specifies a string in a fixed array buffer (ByValTStr) to marshal to unmanaged code.</summary>
		/// <param name="elemCount">The number of elements in the fixed array buffer.</param>
		/// <returns>An <see cref="T:System.Reflection.Emit.UnmanagedMarshal" /> object.</returns>
		/// <exception cref="T:System.ArgumentException">The argument is not a simple native type.</exception>
		// Token: 0x06004DEB RID: 19947 RVA: 0x0011767E File Offset: 0x0011587E
		public static UnmanagedMarshal DefineByValTStr(int elemCount)
		{
			return new UnmanagedMarshal(UnmanagedType.ByValTStr, Guid.Empty, elemCount, (UnmanagedType)0);
		}

		/// <summary>Specifies a <see langword="SafeArray" /> to marshal to unmanaged code.</summary>
		/// <param name="elemType">The base type or the <see langword="UnmanagedType" /> of each element of the array.</param>
		/// <returns>An <see cref="T:System.Reflection.Emit.UnmanagedMarshal" /> object.</returns>
		/// <exception cref="T:System.ArgumentException">The argument is not a simple native type.</exception>
		// Token: 0x06004DEC RID: 19948 RVA: 0x0011768E File Offset: 0x0011588E
		public static UnmanagedMarshal DefineSafeArray(UnmanagedType elemType)
		{
			return new UnmanagedMarshal(UnmanagedType.SafeArray, Guid.Empty, 0, elemType);
		}

		/// <summary>Specifies a fixed-length array (ByValArray) to marshal to unmanaged code.</summary>
		/// <param name="elemCount">The number of elements in the fixed-length array.</param>
		/// <returns>An <see cref="T:System.Reflection.Emit.UnmanagedMarshal" /> object.</returns>
		/// <exception cref="T:System.ArgumentException">The argument is not a simple native type.</exception>
		// Token: 0x06004DED RID: 19949 RVA: 0x0011769E File Offset: 0x0011589E
		public static UnmanagedMarshal DefineByValArray(int elemCount)
		{
			return new UnmanagedMarshal(UnmanagedType.ByValArray, Guid.Empty, elemCount, (UnmanagedType)0);
		}

		/// <summary>Specifies an <see langword="LPArray" /> to marshal to unmanaged code. The length of an <see langword="LPArray" /> is determined at runtime by the size of the actual marshaled array.</summary>
		/// <param name="elemType">The unmanaged type to which to marshal the array.</param>
		/// <returns>An <see cref="T:System.Reflection.Emit.UnmanagedMarshal" /> object.</returns>
		/// <exception cref="T:System.ArgumentException">The argument is not a simple native type.</exception>
		// Token: 0x06004DEE RID: 19950 RVA: 0x001176AE File Offset: 0x001158AE
		public static UnmanagedMarshal DefineLPArray(UnmanagedType elemType)
		{
			return new UnmanagedMarshal(UnmanagedType.LPArray, Guid.Empty, 0, elemType);
		}

		/// <summary>Indicates an unmanaged type. This property is read-only.</summary>
		/// <returns>An <see cref="T:System.Runtime.InteropServices.UnmanagedType" /> object.</returns>
		// Token: 0x17000C7B RID: 3195
		// (get) Token: 0x06004DEF RID: 19951 RVA: 0x001176BE File Offset: 0x001158BE
		public UnmanagedType GetUnmanagedType
		{
			get
			{
				return this.m_unmanagedType;
			}
		}

		/// <summary>Gets a GUID. This property is read-only.</summary>
		/// <returns>A <see cref="T:System.Guid" /> object.</returns>
		/// <exception cref="T:System.ArgumentException">The argument is not a custom marshaler.</exception>
		// Token: 0x17000C7C RID: 3196
		// (get) Token: 0x06004DF0 RID: 19952 RVA: 0x001176C6 File Offset: 0x001158C6
		public Guid IIDGuid
		{
			get
			{
				if (this.m_unmanagedType == UnmanagedType.CustomMarshaler)
				{
					return this.m_guid;
				}
				throw new ArgumentException(Environment.GetResourceString("Argument_NotACustomMarshaler"));
			}
		}

		/// <summary>Gets a number element. This property is read-only.</summary>
		/// <returns>An integer indicating the element count.</returns>
		/// <exception cref="T:System.ArgumentException">The argument is not an unmanaged element count.</exception>
		// Token: 0x17000C7D RID: 3197
		// (get) Token: 0x06004DF1 RID: 19953 RVA: 0x001176E8 File Offset: 0x001158E8
		public int ElementCount
		{
			get
			{
				if (this.m_unmanagedType != UnmanagedType.ByValArray && this.m_unmanagedType != UnmanagedType.ByValTStr)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_NoUnmanagedElementCount"));
				}
				return this.m_numElem;
			}
		}

		/// <summary>Gets an unmanaged base type. This property is read-only.</summary>
		/// <returns>An <see langword="UnmanagedType" /> object.</returns>
		/// <exception cref="T:System.ArgumentException">The unmanaged type is not an <see langword="LPArray" /> or a <see langword="SafeArray" />.</exception>
		// Token: 0x17000C7E RID: 3198
		// (get) Token: 0x06004DF2 RID: 19954 RVA: 0x00117714 File Offset: 0x00115914
		public UnmanagedType BaseType
		{
			get
			{
				if (this.m_unmanagedType != UnmanagedType.LPArray && this.m_unmanagedType != UnmanagedType.SafeArray)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_NoNestedMarshal"));
				}
				return this.m_baseType;
			}
		}

		// Token: 0x06004DF3 RID: 19955 RVA: 0x00117740 File Offset: 0x00115940
		private UnmanagedMarshal(UnmanagedType unmanagedType, Guid guid, int numElem, UnmanagedType type)
		{
			this.m_unmanagedType = unmanagedType;
			this.m_guid = guid;
			this.m_numElem = numElem;
			this.m_baseType = type;
		}

		// Token: 0x06004DF4 RID: 19956 RVA: 0x00117768 File Offset: 0x00115968
		internal byte[] InternalGetBytes()
		{
			if (this.m_unmanagedType == UnmanagedType.SafeArray || this.m_unmanagedType == UnmanagedType.LPArray)
			{
				int num = 2;
				byte[] array = new byte[num];
				array[0] = (byte)this.m_unmanagedType;
				array[1] = (byte)this.m_baseType;
				return array;
			}
			if (this.m_unmanagedType == UnmanagedType.ByValArray || this.m_unmanagedType == UnmanagedType.ByValTStr)
			{
				int num2 = 0;
				int num3;
				if (this.m_numElem <= 127)
				{
					num3 = 1;
				}
				else if (this.m_numElem <= 16383)
				{
					num3 = 2;
				}
				else
				{
					num3 = 4;
				}
				num3++;
				byte[] array = new byte[num3];
				array[num2++] = (byte)this.m_unmanagedType;
				if (this.m_numElem <= 127)
				{
					array[num2++] = (byte)(this.m_numElem & 255);
				}
				else if (this.m_numElem <= 16383)
				{
					array[num2++] = (byte)(this.m_numElem >> 8 | 128);
					array[num2++] = (byte)(this.m_numElem & 255);
				}
				else if (this.m_numElem <= 536870911)
				{
					array[num2++] = (byte)(this.m_numElem >> 24 | 192);
					array[num2++] = (byte)(this.m_numElem >> 16 & 255);
					array[num2++] = (byte)(this.m_numElem >> 8 & 255);
					array[num2++] = (byte)(this.m_numElem & 255);
				}
				return array;
			}
			return new byte[]
			{
				(byte)this.m_unmanagedType
			};
		}

		// Token: 0x04002120 RID: 8480
		internal UnmanagedType m_unmanagedType;

		// Token: 0x04002121 RID: 8481
		internal Guid m_guid;

		// Token: 0x04002122 RID: 8482
		internal int m_numElem;

		// Token: 0x04002123 RID: 8483
		internal UnmanagedType m_baseType;
	}
}
