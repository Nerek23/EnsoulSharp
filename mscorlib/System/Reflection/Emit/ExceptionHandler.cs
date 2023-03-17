using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>Represents an exception handler in a byte array of IL to be passed to a method such as <see cref="M:System.Reflection.Emit.MethodBuilder.SetMethodBody(System.Byte[],System.Int32,System.Byte[],System.Collections.Generic.IEnumerable{System.Reflection.Emit.ExceptionHandler},System.Collections.Generic.IEnumerable{System.Int32})" />.</summary>
	// Token: 0x0200061B RID: 1563
	[ComVisible(false)]
	public struct ExceptionHandler : IEquatable<ExceptionHandler>
	{
		/// <summary>Gets the token of the exception type handled by this handler.</summary>
		/// <returns>The token of the exception type handled by this handler, or 0 if none exists.</returns>
		// Token: 0x17000BAD RID: 2989
		// (get) Token: 0x06004A53 RID: 19027 RVA: 0x0010CCA7 File Offset: 0x0010AEA7
		public int ExceptionTypeToken
		{
			get
			{
				return this.m_exceptionClass;
			}
		}

		/// <summary>Gets the byte offset at which the code that is protected by this exception handler begins.</summary>
		/// <returns>The byte offset at which the code that is protected by this exception handler begins.</returns>
		// Token: 0x17000BAE RID: 2990
		// (get) Token: 0x06004A54 RID: 19028 RVA: 0x0010CCAF File Offset: 0x0010AEAF
		public int TryOffset
		{
			get
			{
				return this.m_tryStartOffset;
			}
		}

		/// <summary>Gets the length, in bytes, of the code protected by this exception handler.</summary>
		/// <returns>The length, in bytes, of the code protected by this exception handler.</returns>
		// Token: 0x17000BAF RID: 2991
		// (get) Token: 0x06004A55 RID: 19029 RVA: 0x0010CCB7 File Offset: 0x0010AEB7
		public int TryLength
		{
			get
			{
				return this.m_tryEndOffset - this.m_tryStartOffset;
			}
		}

		/// <summary>Gets the byte offset at which the filter code for the exception handler begins.</summary>
		/// <returns>The byte offset at which the filter code begins, or 0 if no filter  is present.</returns>
		// Token: 0x17000BB0 RID: 2992
		// (get) Token: 0x06004A56 RID: 19030 RVA: 0x0010CCC6 File Offset: 0x0010AEC6
		public int FilterOffset
		{
			get
			{
				return this.m_filterOffset;
			}
		}

		/// <summary>Gets the byte offset of the first instruction of the exception handler.</summary>
		/// <returns>The byte offset of the first instruction of the exception handler.</returns>
		// Token: 0x17000BB1 RID: 2993
		// (get) Token: 0x06004A57 RID: 19031 RVA: 0x0010CCCE File Offset: 0x0010AECE
		public int HandlerOffset
		{
			get
			{
				return this.m_handlerStartOffset;
			}
		}

		/// <summary>Gets the length, in bytes, of the exception handler.</summary>
		/// <returns>The length, in bytes, of the exception handler.</returns>
		// Token: 0x17000BB2 RID: 2994
		// (get) Token: 0x06004A58 RID: 19032 RVA: 0x0010CCD6 File Offset: 0x0010AED6
		public int HandlerLength
		{
			get
			{
				return this.m_handlerEndOffset - this.m_handlerStartOffset;
			}
		}

		/// <summary>Gets a value that represents the kind of exception handler this object represents.</summary>
		/// <returns>One of the enumeration values that specifies the kind of exception handler.</returns>
		// Token: 0x17000BB3 RID: 2995
		// (get) Token: 0x06004A59 RID: 19033 RVA: 0x0010CCE5 File Offset: 0x0010AEE5
		public ExceptionHandlingClauseOptions Kind
		{
			get
			{
				return this.m_kind;
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.Emit.ExceptionHandler" /> class with the specified parameters.</summary>
		/// <param name="tryOffset">The byte offset of the first instruction protected by this exception handler.</param>
		/// <param name="tryLength">The number of bytes protected by this exception handler.</param>
		/// <param name="filterOffset">The byte offset of the beginning of the filter code. The filter code ends at the first instruction of the handler block. For non-filter exception handlers, specify 0 (zero) for this parameter.</param>
		/// <param name="handlerOffset">The byte offset of the first instruction of this exception handler.</param>
		/// <param name="handlerLength">The number of bytes in this exception handler.</param>
		/// <param name="kind">One of the enumeration values that specifies the kind of exception handler.</param>
		/// <param name="exceptionTypeToken">The token of the exception type handled by this exception handler. If not applicable, specify 0 (zero).</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="tryOffset" />, <paramref name="filterOffset" />, <paramref name="handlerOffset" />, <paramref name="tryLength" />, or <paramref name="handlerLength" /> are negative.</exception>
		// Token: 0x06004A5A RID: 19034 RVA: 0x0010CCF0 File Offset: 0x0010AEF0
		public ExceptionHandler(int tryOffset, int tryLength, int filterOffset, int handlerOffset, int handlerLength, ExceptionHandlingClauseOptions kind, int exceptionTypeToken)
		{
			if (tryOffset < 0)
			{
				throw new ArgumentOutOfRangeException("tryOffset", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (tryLength < 0)
			{
				throw new ArgumentOutOfRangeException("tryLength", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (filterOffset < 0)
			{
				throw new ArgumentOutOfRangeException("filterOffset", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (handlerOffset < 0)
			{
				throw new ArgumentOutOfRangeException("handlerOffset", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (handlerLength < 0)
			{
				throw new ArgumentOutOfRangeException("handlerLength", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if ((long)tryOffset + (long)tryLength > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("tryLength", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					0,
					int.MaxValue - tryOffset
				}));
			}
			if ((long)handlerOffset + (long)handlerLength > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("handlerLength", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					0,
					int.MaxValue - handlerOffset
				}));
			}
			if (kind == ExceptionHandlingClauseOptions.Clause && (exceptionTypeToken & 16777215) == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidTypeToken", new object[]
				{
					exceptionTypeToken
				}), "exceptionTypeToken");
			}
			if (!ExceptionHandler.IsValidKind(kind))
			{
				throw new ArgumentOutOfRangeException("kind", Environment.GetResourceString("ArgumentOutOfRange_Enum"));
			}
			this.m_tryStartOffset = tryOffset;
			this.m_tryEndOffset = tryOffset + tryLength;
			this.m_filterOffset = filterOffset;
			this.m_handlerStartOffset = handlerOffset;
			this.m_handlerEndOffset = handlerOffset + handlerLength;
			this.m_kind = kind;
			this.m_exceptionClass = exceptionTypeToken;
		}

		// Token: 0x06004A5B RID: 19035 RVA: 0x0010CE8A File Offset: 0x0010B08A
		internal ExceptionHandler(int tryStartOffset, int tryEndOffset, int filterOffset, int handlerStartOffset, int handlerEndOffset, int kind, int exceptionTypeToken)
		{
			this.m_tryStartOffset = tryStartOffset;
			this.m_tryEndOffset = tryEndOffset;
			this.m_filterOffset = filterOffset;
			this.m_handlerStartOffset = handlerStartOffset;
			this.m_handlerEndOffset = handlerEndOffset;
			this.m_kind = (ExceptionHandlingClauseOptions)kind;
			this.m_exceptionClass = exceptionTypeToken;
		}

		// Token: 0x06004A5C RID: 19036 RVA: 0x0010CEC1 File Offset: 0x0010B0C1
		private static bool IsValidKind(ExceptionHandlingClauseOptions kind)
		{
			return kind <= ExceptionHandlingClauseOptions.Finally || kind == ExceptionHandlingClauseOptions.Fault;
		}

		/// <summary>Serves as the default hash function.</summary>
		/// <returns>The hash code for the current object.</returns>
		// Token: 0x06004A5D RID: 19037 RVA: 0x0010CECE File Offset: 0x0010B0CE
		public override int GetHashCode()
		{
			return this.m_exceptionClass ^ this.m_tryStartOffset ^ this.m_tryEndOffset ^ this.m_filterOffset ^ this.m_handlerStartOffset ^ this.m_handlerEndOffset ^ (int)this.m_kind;
		}

		/// <summary>Indicates whether this instance of the <see cref="T:System.Reflection.Emit.ExceptionHandler" /> object is equal to a specified object.</summary>
		/// <param name="obj">The object to compare this instance to.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> and this instance are equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004A5E RID: 19038 RVA: 0x0010CF00 File Offset: 0x0010B100
		public override bool Equals(object obj)
		{
			return obj is ExceptionHandler && this.Equals((ExceptionHandler)obj);
		}

		/// <summary>Indicates whether this instance of the <see cref="T:System.Reflection.Emit.ExceptionHandler" /> object is equal to another <see cref="T:System.Reflection.Emit.ExceptionHandler" /> object.</summary>
		/// <param name="other">The exception handler object to compare this instance to.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="other" /> and this instance are equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004A5F RID: 19039 RVA: 0x0010CF18 File Offset: 0x0010B118
		public bool Equals(ExceptionHandler other)
		{
			return other.m_exceptionClass == this.m_exceptionClass && other.m_tryStartOffset == this.m_tryStartOffset && other.m_tryEndOffset == this.m_tryEndOffset && other.m_filterOffset == this.m_filterOffset && other.m_handlerStartOffset == this.m_handlerStartOffset && other.m_handlerEndOffset == this.m_handlerEndOffset && other.m_kind == this.m_kind;
		}

		/// <summary>Determines whether two specified instances of <see cref="T:System.Reflection.Emit.ExceptionHandler" /> are equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004A60 RID: 19040 RVA: 0x0010CF89 File Offset: 0x0010B189
		public static bool operator ==(ExceptionHandler left, ExceptionHandler right)
		{
			return left.Equals(right);
		}

		/// <summary>Determines whether two specified instances of <see cref="T:System.Reflection.Emit.ExceptionHandler" /> are not equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004A61 RID: 19041 RVA: 0x0010CF93 File Offset: 0x0010B193
		public static bool operator !=(ExceptionHandler left, ExceptionHandler right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04001E77 RID: 7799
		internal readonly int m_exceptionClass;

		// Token: 0x04001E78 RID: 7800
		internal readonly int m_tryStartOffset;

		// Token: 0x04001E79 RID: 7801
		internal readonly int m_tryEndOffset;

		// Token: 0x04001E7A RID: 7802
		internal readonly int m_filterOffset;

		// Token: 0x04001E7B RID: 7803
		internal readonly int m_handlerStartOffset;

		// Token: 0x04001E7C RID: 7804
		internal readonly int m_handlerEndOffset;

		// Token: 0x04001E7D RID: 7805
		internal readonly ExceptionHandlingClauseOptions m_kind;
	}
}
