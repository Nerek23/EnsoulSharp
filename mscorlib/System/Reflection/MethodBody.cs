using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Provides access to the metadata and MSIL for the body of a method.</summary>
	// Token: 0x020005E6 RID: 1510
	[ComVisible(true)]
	public class MethodBody
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.MethodBody" /> class.</summary>
		// Token: 0x060046E5 RID: 18149 RVA: 0x0010163C File Offset: 0x000FF83C
		protected MethodBody()
		{
		}

		/// <summary>Gets a metadata token for the signature that describes the local variables for the method in metadata.</summary>
		/// <returns>An integer that represents the metadata token.</returns>
		// Token: 0x17000B06 RID: 2822
		// (get) Token: 0x060046E6 RID: 18150 RVA: 0x00101644 File Offset: 0x000FF844
		public virtual int LocalSignatureMetadataToken
		{
			get
			{
				return this.m_localSignatureMetadataToken;
			}
		}

		/// <summary>Gets the list of local variables declared in the method body.</summary>
		/// <returns>An <see cref="T:System.Collections.Generic.IList`1" /> of <see cref="T:System.Reflection.LocalVariableInfo" /> objects that describe the local variables declared in the method body.</returns>
		// Token: 0x17000B07 RID: 2823
		// (get) Token: 0x060046E7 RID: 18151 RVA: 0x0010164C File Offset: 0x000FF84C
		public virtual IList<LocalVariableInfo> LocalVariables
		{
			get
			{
				return Array.AsReadOnly<LocalVariableInfo>(this.m_localVariables);
			}
		}

		/// <summary>Gets the maximum number of items on the operand stack when the method is executing.</summary>
		/// <returns>The maximum number of items on the operand stack when the method is executing.</returns>
		// Token: 0x17000B08 RID: 2824
		// (get) Token: 0x060046E8 RID: 18152 RVA: 0x00101659 File Offset: 0x000FF859
		public virtual int MaxStackSize
		{
			get
			{
				return this.m_maxStackSize;
			}
		}

		/// <summary>Gets a value indicating whether local variables in the method body are initialized to the default values for their types.</summary>
		/// <returns>
		///   <see langword="true" /> if the method body contains code to initialize local variables to <see langword="null" /> for reference types, or to the zero-initialized value for value types; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000B09 RID: 2825
		// (get) Token: 0x060046E9 RID: 18153 RVA: 0x00101661 File Offset: 0x000FF861
		public virtual bool InitLocals
		{
			get
			{
				return this.m_initLocals;
			}
		}

		/// <summary>Returns the MSIL for the method body, as an array of bytes.</summary>
		/// <returns>An array of type <see cref="T:System.Byte" /> that contains the MSIL for the method body.</returns>
		// Token: 0x060046EA RID: 18154 RVA: 0x00101669 File Offset: 0x000FF869
		public virtual byte[] GetILAsByteArray()
		{
			return this.m_IL;
		}

		/// <summary>Gets a list that includes all the exception-handling clauses in the method body.</summary>
		/// <returns>An <see cref="T:System.Collections.Generic.IList`1" /> of <see cref="T:System.Reflection.ExceptionHandlingClause" /> objects representing the exception-handling clauses in the body of the method.</returns>
		// Token: 0x17000B0A RID: 2826
		// (get) Token: 0x060046EB RID: 18155 RVA: 0x00101671 File Offset: 0x000FF871
		public virtual IList<ExceptionHandlingClause> ExceptionHandlingClauses
		{
			get
			{
				return Array.AsReadOnly<ExceptionHandlingClause>(this.m_exceptionHandlingClauses);
			}
		}

		// Token: 0x04001D1B RID: 7451
		private byte[] m_IL;

		// Token: 0x04001D1C RID: 7452
		private ExceptionHandlingClause[] m_exceptionHandlingClauses;

		// Token: 0x04001D1D RID: 7453
		private LocalVariableInfo[] m_localVariables;

		// Token: 0x04001D1E RID: 7454
		internal MethodBase m_methodBase;

		// Token: 0x04001D1F RID: 7455
		private int m_localSignatureMetadataToken;

		// Token: 0x04001D20 RID: 7456
		private int m_maxStackSize;

		// Token: 0x04001D21 RID: 7457
		private bool m_initLocals;
	}
}
