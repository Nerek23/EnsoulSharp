using System;
using System.Reflection;
using System.Security;

namespace System.Runtime.InteropServices
{
	/// <summary>Indicates how to marshal the data between managed and unmanaged code.</summary>
	// Token: 0x020008FE RID: 2302
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class MarshalAsAttribute : Attribute
	{
		// Token: 0x06005F01 RID: 24321 RVA: 0x00146DC7 File Offset: 0x00144FC7
		[SecurityCritical]
		internal static Attribute GetCustomAttribute(RuntimeParameterInfo parameter)
		{
			return MarshalAsAttribute.GetCustomAttribute(parameter.MetadataToken, parameter.GetRuntimeModule());
		}

		// Token: 0x06005F02 RID: 24322 RVA: 0x00146DDA File Offset: 0x00144FDA
		[SecurityCritical]
		internal static bool IsDefined(RuntimeParameterInfo parameter)
		{
			return MarshalAsAttribute.GetCustomAttribute(parameter) != null;
		}

		// Token: 0x06005F03 RID: 24323 RVA: 0x00146DE5 File Offset: 0x00144FE5
		[SecurityCritical]
		internal static Attribute GetCustomAttribute(RuntimeFieldInfo field)
		{
			return MarshalAsAttribute.GetCustomAttribute(field.MetadataToken, field.GetRuntimeModule());
		}

		// Token: 0x06005F04 RID: 24324 RVA: 0x00146DF8 File Offset: 0x00144FF8
		[SecurityCritical]
		internal static bool IsDefined(RuntimeFieldInfo field)
		{
			return MarshalAsAttribute.GetCustomAttribute(field) != null;
		}

		// Token: 0x06005F05 RID: 24325 RVA: 0x00146E04 File Offset: 0x00145004
		[SecurityCritical]
		internal static Attribute GetCustomAttribute(int token, RuntimeModule scope)
		{
			int num = 0;
			int sizeConst = 0;
			string text = null;
			string marshalCookie = null;
			string text2 = null;
			int iidParamIndex = 0;
			ConstArray fieldMarshal = ModuleHandle.GetMetadataImport(scope.GetNativeHandle()).GetFieldMarshal(token);
			if (fieldMarshal.Length == 0)
			{
				return null;
			}
			UnmanagedType val;
			VarEnum safeArraySubType;
			UnmanagedType arraySubType;
			MetadataImport.GetMarshalAs(fieldMarshal, out val, out safeArraySubType, out text2, out arraySubType, out num, out sizeConst, out text, out marshalCookie, out iidParamIndex);
			RuntimeType safeArrayUserDefinedSubType = (text2 == null || text2.Length == 0) ? null : RuntimeTypeHandle.GetTypeByNameUsingCARules(text2, scope);
			RuntimeType marshalTypeRef = null;
			try
			{
				marshalTypeRef = ((text == null) ? null : RuntimeTypeHandle.GetTypeByNameUsingCARules(text, scope));
			}
			catch (TypeLoadException)
			{
			}
			return new MarshalAsAttribute(val, safeArraySubType, safeArrayUserDefinedSubType, arraySubType, (short)num, sizeConst, text, marshalTypeRef, marshalCookie, iidParamIndex);
		}

		// Token: 0x06005F06 RID: 24326 RVA: 0x00146EB8 File Offset: 0x001450B8
		internal MarshalAsAttribute(UnmanagedType val, VarEnum safeArraySubType, RuntimeType safeArrayUserDefinedSubType, UnmanagedType arraySubType, short sizeParamIndex, int sizeConst, string marshalType, RuntimeType marshalTypeRef, string marshalCookie, int iidParamIndex)
		{
			this._val = val;
			this.SafeArraySubType = safeArraySubType;
			this.SafeArrayUserDefinedSubType = safeArrayUserDefinedSubType;
			this.IidParameterIndex = iidParamIndex;
			this.ArraySubType = arraySubType;
			this.SizeParamIndex = sizeParamIndex;
			this.SizeConst = sizeConst;
			this.MarshalType = marshalType;
			this.MarshalTypeRef = marshalTypeRef;
			this.MarshalCookie = marshalCookie;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.MarshalAsAttribute" /> class with the specified <see cref="T:System.Runtime.InteropServices.UnmanagedType" /> enumeration member.</summary>
		/// <param name="unmanagedType">The value the data is to be marshaled as.</param>
		// Token: 0x06005F07 RID: 24327 RVA: 0x00146F18 File Offset: 0x00145118
		[__DynamicallyInvokable]
		public MarshalAsAttribute(UnmanagedType unmanagedType)
		{
			this._val = unmanagedType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.MarshalAsAttribute" /> class with the specified <see cref="T:System.Runtime.InteropServices.UnmanagedType" /> value.</summary>
		/// <param name="unmanagedType">The value the data is to be marshaled as.</param>
		// Token: 0x06005F08 RID: 24328 RVA: 0x00146F27 File Offset: 0x00145127
		[__DynamicallyInvokable]
		public MarshalAsAttribute(short unmanagedType)
		{
			this._val = (UnmanagedType)unmanagedType;
		}

		/// <summary>Gets the <see cref="T:System.Runtime.InteropServices.UnmanagedType" /> value the data is to be marshaled as.</summary>
		/// <returns>The <see cref="T:System.Runtime.InteropServices.UnmanagedType" /> value the data is to be marshaled as.</returns>
		// Token: 0x170010C8 RID: 4296
		// (get) Token: 0x06005F09 RID: 24329 RVA: 0x00146F36 File Offset: 0x00145136
		[__DynamicallyInvokable]
		public UnmanagedType Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002A43 RID: 10819
		internal UnmanagedType _val;

		/// <summary>Indicates the element type of the <see cref="F:System.Runtime.InteropServices.UnmanagedType.SafeArray" />.</summary>
		// Token: 0x04002A44 RID: 10820
		[__DynamicallyInvokable]
		public VarEnum SafeArraySubType;

		/// <summary>Indicates the user-defined element type of the <see cref="F:System.Runtime.InteropServices.UnmanagedType.SafeArray" />.</summary>
		// Token: 0x04002A45 RID: 10821
		[__DynamicallyInvokable]
		public Type SafeArrayUserDefinedSubType;

		/// <summary>Specifies the parameter index of the unmanaged <see langword="iid_is" /> attribute used by COM.</summary>
		// Token: 0x04002A46 RID: 10822
		[__DynamicallyInvokable]
		public int IidParameterIndex;

		/// <summary>Specifies the element type of the unmanaged <see cref="F:System.Runtime.InteropServices.UnmanagedType.LPArray" /> or <see cref="F:System.Runtime.InteropServices.UnmanagedType.ByValArray" />.</summary>
		// Token: 0x04002A47 RID: 10823
		[__DynamicallyInvokable]
		public UnmanagedType ArraySubType;

		/// <summary>Indicates the zero-based parameter that contains the count of array elements, similar to <see langword="size_is" /> in COM.</summary>
		// Token: 0x04002A48 RID: 10824
		[__DynamicallyInvokable]
		public short SizeParamIndex;

		/// <summary>Indicates the number of elements in the fixed-length array or the number of characters (not bytes) in a string to import.</summary>
		// Token: 0x04002A49 RID: 10825
		[__DynamicallyInvokable]
		public int SizeConst;

		/// <summary>Specifies the fully qualified name of a custom marshaler.</summary>
		// Token: 0x04002A4A RID: 10826
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public string MarshalType;

		/// <summary>Implements <see cref="F:System.Runtime.InteropServices.MarshalAsAttribute.MarshalType" /> as a type.</summary>
		// Token: 0x04002A4B RID: 10827
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public Type MarshalTypeRef;

		/// <summary>Provides additional information to a custom marshaler.</summary>
		// Token: 0x04002A4C RID: 10828
		[__DynamicallyInvokable]
		public string MarshalCookie;
	}
}
