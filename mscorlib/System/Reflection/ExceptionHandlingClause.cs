using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Represents a clause in a structured exception-handling block.</summary>
	// Token: 0x020005E5 RID: 1509
	[ComVisible(true)]
	public class ExceptionHandlingClause
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.ExceptionHandlingClause" /> class.</summary>
		// Token: 0x060046DC RID: 18140 RVA: 0x001013F7 File Offset: 0x000FF5F7
		protected ExceptionHandlingClause()
		{
		}

		/// <summary>Gets a value indicating whether this exception-handling clause is a finally clause, a type-filtered clause, or a user-filtered clause.</summary>
		/// <returns>An <see cref="T:System.Reflection.ExceptionHandlingClauseOptions" /> value that indicates what kind of action this clause performs.</returns>
		// Token: 0x17000AFF RID: 2815
		// (get) Token: 0x060046DD RID: 18141 RVA: 0x001013FF File Offset: 0x000FF5FF
		public virtual ExceptionHandlingClauseOptions Flags
		{
			get
			{
				return this.m_flags;
			}
		}

		/// <summary>The offset within the method, in bytes, of the try block that includes this exception-handling clause.</summary>
		/// <returns>An integer that represents the offset within the method, in bytes, of the try block that includes this exception-handling clause.</returns>
		// Token: 0x17000B00 RID: 2816
		// (get) Token: 0x060046DE RID: 18142 RVA: 0x00101407 File Offset: 0x000FF607
		public virtual int TryOffset
		{
			get
			{
				return this.m_tryOffset;
			}
		}

		/// <summary>The total length, in bytes, of the try block that includes this exception-handling clause.</summary>
		/// <returns>The total length, in bytes, of the try block that includes this exception-handling clause.</returns>
		// Token: 0x17000B01 RID: 2817
		// (get) Token: 0x060046DF RID: 18143 RVA: 0x0010140F File Offset: 0x000FF60F
		public virtual int TryLength
		{
			get
			{
				return this.m_tryLength;
			}
		}

		/// <summary>Gets the offset within the method body, in bytes, of this exception-handling clause.</summary>
		/// <returns>An integer that represents the offset within the method body, in bytes, of this exception-handling clause.</returns>
		// Token: 0x17000B02 RID: 2818
		// (get) Token: 0x060046E0 RID: 18144 RVA: 0x00101417 File Offset: 0x000FF617
		public virtual int HandlerOffset
		{
			get
			{
				return this.m_handlerOffset;
			}
		}

		/// <summary>Gets the length, in bytes, of the body of this exception-handling clause.</summary>
		/// <returns>An integer that represents the length, in bytes, of the MSIL that forms the body of this exception-handling clause.</returns>
		// Token: 0x17000B03 RID: 2819
		// (get) Token: 0x060046E1 RID: 18145 RVA: 0x0010141F File Offset: 0x000FF61F
		public virtual int HandlerLength
		{
			get
			{
				return this.m_handlerLength;
			}
		}

		/// <summary>Gets the offset within the method body, in bytes, of the user-supplied filter code.</summary>
		/// <returns>The offset within the method body, in bytes, of the user-supplied filter code. The value of this property has no meaning if the <see cref="P:System.Reflection.ExceptionHandlingClause.Flags" /> property has any value other than <see cref="F:System.Reflection.ExceptionHandlingClauseOptions.Filter" />.</returns>
		/// <exception cref="T:System.InvalidOperationException">Cannot get the offset because the exception handling clause is not a filter.</exception>
		// Token: 0x17000B04 RID: 2820
		// (get) Token: 0x060046E2 RID: 18146 RVA: 0x00101427 File Offset: 0x000FF627
		public virtual int FilterOffset
		{
			get
			{
				if (this.m_flags != ExceptionHandlingClauseOptions.Filter)
				{
					throw new InvalidOperationException(Environment.GetResourceString("Arg_EHClauseNotFilter"));
				}
				return this.m_filterOffset;
			}
		}

		/// <summary>Gets the type of exception handled by this clause.</summary>
		/// <returns>A <see cref="T:System.Type" /> object that represents that type of exception handled by this clause, or <see langword="null" /> if the <see cref="P:System.Reflection.ExceptionHandlingClause.Flags" /> property is <see cref="F:System.Reflection.ExceptionHandlingClauseOptions.Filter" /> or <see cref="F:System.Reflection.ExceptionHandlingClauseOptions.Finally" />.</returns>
		/// <exception cref="T:System.InvalidOperationException">Invalid use of property for the object's current state.</exception>
		// Token: 0x17000B05 RID: 2821
		// (get) Token: 0x060046E3 RID: 18147 RVA: 0x00101448 File Offset: 0x000FF648
		public virtual Type CatchType
		{
			get
			{
				if (this.m_flags != ExceptionHandlingClauseOptions.Clause)
				{
					throw new InvalidOperationException(Environment.GetResourceString("Arg_EHClauseNotClause"));
				}
				Type result = null;
				if (!MetadataToken.IsNullToken(this.m_catchMetadataToken))
				{
					Type declaringType = this.m_methodBody.m_methodBase.DeclaringType;
					Module module = (declaringType == null) ? this.m_methodBody.m_methodBase.Module : declaringType.Module;
					result = module.ResolveType(this.m_catchMetadataToken, (declaringType == null) ? null : declaringType.GetGenericArguments(), (this.m_methodBody.m_methodBase is MethodInfo) ? this.m_methodBody.m_methodBase.GetGenericArguments() : null);
				}
				return result;
			}
		}

		/// <summary>A string representation of the exception-handling clause.</summary>
		/// <returns>A string that lists appropriate property values for the filter clause type.</returns>
		// Token: 0x060046E4 RID: 18148 RVA: 0x001014F4 File Offset: 0x000FF6F4
		public override string ToString()
		{
			if (this.Flags == ExceptionHandlingClauseOptions.Clause)
			{
				return string.Format(CultureInfo.CurrentUICulture, "Flags={0}, TryOffset={1}, TryLength={2}, HandlerOffset={3}, HandlerLength={4}, CatchType={5}", new object[]
				{
					this.Flags,
					this.TryOffset,
					this.TryLength,
					this.HandlerOffset,
					this.HandlerLength,
					this.CatchType
				});
			}
			if (this.Flags == ExceptionHandlingClauseOptions.Filter)
			{
				return string.Format(CultureInfo.CurrentUICulture, "Flags={0}, TryOffset={1}, TryLength={2}, HandlerOffset={3}, HandlerLength={4}, FilterOffset={5}", new object[]
				{
					this.Flags,
					this.TryOffset,
					this.TryLength,
					this.HandlerOffset,
					this.HandlerLength,
					this.FilterOffset
				});
			}
			return string.Format(CultureInfo.CurrentUICulture, "Flags={0}, TryOffset={1}, TryLength={2}, HandlerOffset={3}, HandlerLength={4}", new object[]
			{
				this.Flags,
				this.TryOffset,
				this.TryLength,
				this.HandlerOffset,
				this.HandlerLength
			});
		}

		// Token: 0x04001D13 RID: 7443
		private MethodBody m_methodBody;

		// Token: 0x04001D14 RID: 7444
		private ExceptionHandlingClauseOptions m_flags;

		// Token: 0x04001D15 RID: 7445
		private int m_tryOffset;

		// Token: 0x04001D16 RID: 7446
		private int m_tryLength;

		// Token: 0x04001D17 RID: 7447
		private int m_handlerOffset;

		// Token: 0x04001D18 RID: 7448
		private int m_handlerLength;

		// Token: 0x04001D19 RID: 7449
		private int m_catchMetadataToken;

		// Token: 0x04001D1A RID: 7450
		private int m_filterOffset;
	}
}
