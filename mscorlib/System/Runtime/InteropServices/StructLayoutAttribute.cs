using System;
using System.Reflection;
using System.Security;

namespace System.Runtime.InteropServices
{
	/// <summary>Lets you control the physical layout of the data fields of a class or structure in memory.</summary>
	// Token: 0x02000908 RID: 2312
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class StructLayoutAttribute : Attribute
	{
		// Token: 0x06005F22 RID: 24354 RVA: 0x001471F8 File Offset: 0x001453F8
		[SecurityCritical]
		internal static Attribute GetCustomAttribute(RuntimeType type)
		{
			if (!StructLayoutAttribute.IsDefined(type))
			{
				return null;
			}
			int num = 0;
			int size = 0;
			LayoutKind layoutKind = LayoutKind.Auto;
			TypeAttributes typeAttributes = type.Attributes & TypeAttributes.LayoutMask;
			if (typeAttributes != TypeAttributes.NotPublic)
			{
				if (typeAttributes != TypeAttributes.SequentialLayout)
				{
					if (typeAttributes == TypeAttributes.ExplicitLayout)
					{
						layoutKind = LayoutKind.Explicit;
					}
				}
				else
				{
					layoutKind = LayoutKind.Sequential;
				}
			}
			else
			{
				layoutKind = LayoutKind.Auto;
			}
			CharSet charSet = CharSet.None;
			typeAttributes = (type.Attributes & TypeAttributes.StringFormatMask);
			if (typeAttributes != TypeAttributes.NotPublic)
			{
				if (typeAttributes != TypeAttributes.UnicodeClass)
				{
					if (typeAttributes == TypeAttributes.AutoClass)
					{
						charSet = CharSet.Auto;
					}
				}
				else
				{
					charSet = CharSet.Unicode;
				}
			}
			else
			{
				charSet = CharSet.Ansi;
			}
			type.GetRuntimeModule().MetadataImport.GetClassLayout(type.MetadataToken, out num, out size);
			if (num == 0)
			{
				num = 8;
			}
			return new StructLayoutAttribute(layoutKind, num, size, charSet);
		}

		// Token: 0x06005F23 RID: 24355 RVA: 0x00147297 File Offset: 0x00145497
		internal static bool IsDefined(RuntimeType type)
		{
			return !type.IsInterface && !type.HasElementType && !type.IsGenericParameter;
		}

		// Token: 0x06005F24 RID: 24356 RVA: 0x001472B4 File Offset: 0x001454B4
		internal StructLayoutAttribute(LayoutKind layoutKind, int pack, int size, CharSet charSet)
		{
			this._val = layoutKind;
			this.Pack = pack;
			this.Size = size;
			this.CharSet = charSet;
		}

		/// <summary>Initalizes a new instance of the <see cref="T:System.Runtime.InteropServices.StructLayoutAttribute" /> class with the specified <see cref="T:System.Runtime.InteropServices.LayoutKind" /> enumeration member.</summary>
		/// <param name="layoutKind">One of the enumeration values that specifes how the class or structure should be arranged.</param>
		// Token: 0x06005F25 RID: 24357 RVA: 0x001472D9 File Offset: 0x001454D9
		[__DynamicallyInvokable]
		public StructLayoutAttribute(LayoutKind layoutKind)
		{
			this._val = layoutKind;
		}

		/// <summary>Initalizes a new instance of the <see cref="T:System.Runtime.InteropServices.StructLayoutAttribute" /> class with the specified <see cref="T:System.Runtime.InteropServices.LayoutKind" /> enumeration member.</summary>
		/// <param name="layoutKind">A 16-bit integer that represents one of the <see cref="T:System.Runtime.InteropServices.LayoutKind" /> values that specifes how the class or structure should be arranged.</param>
		// Token: 0x06005F26 RID: 24358 RVA: 0x001472E8 File Offset: 0x001454E8
		public StructLayoutAttribute(short layoutKind)
		{
			this._val = (LayoutKind)layoutKind;
		}

		/// <summary>Gets the <see cref="T:System.Runtime.InteropServices.LayoutKind" /> value that specifies how the class or structure is arranged.</summary>
		/// <returns>One of the enumeration values that specifies how the class or structure is arranged.</returns>
		// Token: 0x170010CC RID: 4300
		// (get) Token: 0x06005F27 RID: 24359 RVA: 0x001472F7 File Offset: 0x001454F7
		[__DynamicallyInvokable]
		public LayoutKind Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002A60 RID: 10848
		private const int DEFAULT_PACKING_SIZE = 8;

		// Token: 0x04002A61 RID: 10849
		internal LayoutKind _val;

		/// <summary>Controls the alignment of data fields of a class or structure in memory.</summary>
		// Token: 0x04002A62 RID: 10850
		[__DynamicallyInvokable]
		public int Pack;

		/// <summary>Indicates the absolute size of the class or structure.</summary>
		// Token: 0x04002A63 RID: 10851
		[__DynamicallyInvokable]
		public int Size;

		/// <summary>Indicates whether string data fields within the class should be marshaled as <see langword="LPWSTR" /> or <see langword="LPSTR" /> by default.</summary>
		// Token: 0x04002A64 RID: 10852
		[__DynamicallyInvokable]
		public CharSet CharSet;
	}
}
