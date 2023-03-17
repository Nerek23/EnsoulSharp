using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Reflection.Emit
{
	/// <summary>Creates or associates parameter information.</summary>
	// Token: 0x0200062E RID: 1582
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_ParameterBuilder))]
	[ComVisible(true)]
	public class ParameterBuilder : _ParameterBuilder
	{
		/// <summary>Specifies the marshaling for this parameter.</summary>
		/// <param name="unmanagedMarshal">The marshaling information for this parameter.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="unmanagedMarshal" /> is <see langword="null" />.</exception>
		// Token: 0x06004B97 RID: 19351 RVA: 0x001122FC File Offset: 0x001104FC
		[SecuritySafeCritical]
		[Obsolete("An alternate API is available: Emit the MarshalAs custom attribute instead. http://go.microsoft.com/fwlink/?linkid=14202")]
		public virtual void SetMarshal(UnmanagedMarshal unmanagedMarshal)
		{
			if (unmanagedMarshal == null)
			{
				throw new ArgumentNullException("unmanagedMarshal");
			}
			byte[] array = unmanagedMarshal.InternalGetBytes();
			TypeBuilder.SetFieldMarshal(this.m_methodBuilder.GetModuleBuilder().GetNativeHandle(), this.m_pdToken.Token, array, array.Length);
		}

		/// <summary>Sets the default value of the parameter.</summary>
		/// <param name="defaultValue">The default value of this parameter.</param>
		/// <exception cref="T:System.ArgumentException">The parameter is not one of the supported types.  
		///  -or-  
		///  The type of <paramref name="defaultValue" /> does not match the type of the parameter.  
		///  -or-  
		///  The parameter is of type <see cref="T:System.Object" /> or other reference type, <paramref name="defaultValue" /> is not <see langword="null" />, and the value cannot be assigned to the reference type.</exception>
		// Token: 0x06004B98 RID: 19352 RVA: 0x00112344 File Offset: 0x00110544
		[SecuritySafeCritical]
		public virtual void SetConstant(object defaultValue)
		{
			TypeBuilder.SetConstantValue(this.m_methodBuilder.GetModuleBuilder(), this.m_pdToken.Token, (this.m_iPosition == 0) ? this.m_methodBuilder.ReturnType : this.m_methodBuilder.m_parameterTypes[this.m_iPosition - 1], defaultValue);
		}

		/// <summary>Set a custom attribute using a specified custom attribute blob.</summary>
		/// <param name="con">The constructor for the custom attribute.</param>
		/// <param name="binaryAttribute">A byte blob representing the attributes.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="con" /> or <paramref name="binaryAttribute" /> is <see langword="null" />.</exception>
		// Token: 0x06004B99 RID: 19353 RVA: 0x00112398 File Offset: 0x00110598
		[SecuritySafeCritical]
		[ComVisible(true)]
		public void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
		{
			if (con == null)
			{
				throw new ArgumentNullException("con");
			}
			if (binaryAttribute == null)
			{
				throw new ArgumentNullException("binaryAttribute");
			}
			TypeBuilder.DefineCustomAttribute(this.m_methodBuilder.GetModuleBuilder(), this.m_pdToken.Token, ((ModuleBuilder)this.m_methodBuilder.GetModule()).GetConstructorToken(con).Token, binaryAttribute, false, false);
		}

		/// <summary>Set a custom attribute using a custom attribute builder.</summary>
		/// <param name="customBuilder">An instance of a helper class to define the custom attribute.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="con" /> is <see langword="null" />.</exception>
		// Token: 0x06004B9A RID: 19354 RVA: 0x00112403 File Offset: 0x00110603
		[SecuritySafeCritical]
		public void SetCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			if (customBuilder == null)
			{
				throw new ArgumentNullException("customBuilder");
			}
			customBuilder.CreateCustomAttribute((ModuleBuilder)this.m_methodBuilder.GetModule(), this.m_pdToken.Token);
		}

		// Token: 0x06004B9B RID: 19355 RVA: 0x00112434 File Offset: 0x00110634
		private ParameterBuilder()
		{
		}

		// Token: 0x06004B9C RID: 19356 RVA: 0x0011243C File Offset: 0x0011063C
		[SecurityCritical]
		internal ParameterBuilder(MethodBuilder methodBuilder, int sequence, ParameterAttributes attributes, string strParamName)
		{
			this.m_iPosition = sequence;
			this.m_strParamName = strParamName;
			this.m_methodBuilder = methodBuilder;
			this.m_strParamName = strParamName;
			this.m_attributes = attributes;
			this.m_pdToken = new ParameterToken(TypeBuilder.SetParamInfo(this.m_methodBuilder.GetModuleBuilder().GetNativeHandle(), this.m_methodBuilder.GetToken().Token, sequence, attributes, strParamName));
		}

		/// <summary>Retrieves the token for this parameter.</summary>
		/// <returns>The token for this parameter.</returns>
		// Token: 0x06004B9D RID: 19357 RVA: 0x001124AB File Offset: 0x001106AB
		public virtual ParameterToken GetToken()
		{
			return this.m_pdToken;
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004B9E RID: 19358 RVA: 0x001124B3 File Offset: 0x001106B3
		void _ParameterBuilder.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004B9F RID: 19359 RVA: 0x001124BA File Offset: 0x001106BA
		void _ParameterBuilder.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Maps a set of names to a corresponding set of dispatch identifiers.</summary>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="rgszNames">Passed-in array of names to be mapped.</param>
		/// <param name="cNames">Count of the names to be mapped.</param>
		/// <param name="lcid">The locale context in which to interpret the names.</param>
		/// <param name="rgDispId">Caller-allocated array which receives the IDs corresponding to the names.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004BA0 RID: 19360 RVA: 0x001124C1 File Offset: 0x001106C1
		void _ParameterBuilder.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		/// <summary>Provides access to properties and methods exposed by an object.</summary>
		/// <param name="dispIdMember">Identifies the member.</param>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="lcid">The locale context in which to interpret arguments.</param>
		/// <param name="wFlags">Flags describing the context of the call.</param>
		/// <param name="pDispParams">Pointer to a structure containing an array of arguments, an array of argument DISPIDs for named arguments, and counts for the number of elements in the arrays.</param>
		/// <param name="pVarResult">Pointer to the location where the result is to be stored.</param>
		/// <param name="pExcepInfo">Pointer to a structure that contains exception information.</param>
		/// <param name="puArgErr">The index of the first argument that has an error.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004BA1 RID: 19361 RVA: 0x001124C8 File Offset: 0x001106C8
		void _ParameterBuilder.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000BEB RID: 3051
		// (get) Token: 0x06004BA2 RID: 19362 RVA: 0x001124CF File Offset: 0x001106CF
		internal int MetadataTokenInternal
		{
			get
			{
				return this.m_pdToken.Token;
			}
		}

		/// <summary>Retrieves the name of this parameter.</summary>
		/// <returns>Read-only. Retrieves the name of this parameter.</returns>
		// Token: 0x17000BEC RID: 3052
		// (get) Token: 0x06004BA3 RID: 19363 RVA: 0x001124DC File Offset: 0x001106DC
		public virtual string Name
		{
			get
			{
				return this.m_strParamName;
			}
		}

		/// <summary>Retrieves the signature position for this parameter.</summary>
		/// <returns>Read-only. Retrieves the signature position for this parameter.</returns>
		// Token: 0x17000BED RID: 3053
		// (get) Token: 0x06004BA4 RID: 19364 RVA: 0x001124E4 File Offset: 0x001106E4
		public virtual int Position
		{
			get
			{
				return this.m_iPosition;
			}
		}

		/// <summary>Retrieves the attributes for this parameter.</summary>
		/// <returns>Read-only. Retrieves the attributes for this parameter.</returns>
		// Token: 0x17000BEE RID: 3054
		// (get) Token: 0x06004BA5 RID: 19365 RVA: 0x001124EC File Offset: 0x001106EC
		public virtual int Attributes
		{
			get
			{
				return (int)this.m_attributes;
			}
		}

		/// <summary>Retrieves whether this is an input parameter.</summary>
		/// <returns>Read-only. Retrieves whether this is an input parameter.</returns>
		// Token: 0x17000BEF RID: 3055
		// (get) Token: 0x06004BA6 RID: 19366 RVA: 0x001124F4 File Offset: 0x001106F4
		public bool IsIn
		{
			get
			{
				return (this.m_attributes & ParameterAttributes.In) > ParameterAttributes.None;
			}
		}

		/// <summary>Retrieves whether this parameter is an output parameter.</summary>
		/// <returns>Read-only. Retrieves whether this parameter is an output parameter.</returns>
		// Token: 0x17000BF0 RID: 3056
		// (get) Token: 0x06004BA7 RID: 19367 RVA: 0x00112501 File Offset: 0x00110701
		public bool IsOut
		{
			get
			{
				return (this.m_attributes & ParameterAttributes.Out) > ParameterAttributes.None;
			}
		}

		/// <summary>Retrieves whether this parameter is optional.</summary>
		/// <returns>Read-only. Specifies whether this parameter is optional.</returns>
		// Token: 0x17000BF1 RID: 3057
		// (get) Token: 0x06004BA8 RID: 19368 RVA: 0x0011250E File Offset: 0x0011070E
		public bool IsOptional
		{
			get
			{
				return (this.m_attributes & ParameterAttributes.Optional) > ParameterAttributes.None;
			}
		}

		// Token: 0x040020CF RID: 8399
		private string m_strParamName;

		// Token: 0x040020D0 RID: 8400
		private int m_iPosition;

		// Token: 0x040020D1 RID: 8401
		private ParameterAttributes m_attributes;

		// Token: 0x040020D2 RID: 8402
		private MethodBuilder m_methodBuilder;

		// Token: 0x040020D3 RID: 8403
		private ParameterToken m_pdToken;
	}
}
