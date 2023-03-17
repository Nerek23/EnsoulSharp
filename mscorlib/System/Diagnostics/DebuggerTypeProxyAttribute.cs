using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	/// <summary>Specifies the display proxy for a type.</summary>
	// Token: 0x020003C1 RID: 961
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class DebuggerTypeProxyAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.DebuggerTypeProxyAttribute" /> class using the type of the proxy.</summary>
		/// <param name="type">The proxy type.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="type" /> is <see langword="null" />.</exception>
		// Token: 0x060031F1 RID: 12785 RVA: 0x000C01D2 File Offset: 0x000BE3D2
		[__DynamicallyInvokable]
		public DebuggerTypeProxyAttribute(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			this.typeName = type.AssemblyQualifiedName;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.DebuggerTypeProxyAttribute" /> class using the type name of the proxy.</summary>
		/// <param name="typeName">The type name of the proxy type.</param>
		// Token: 0x060031F2 RID: 12786 RVA: 0x000C01FA File Offset: 0x000BE3FA
		[__DynamicallyInvokable]
		public DebuggerTypeProxyAttribute(string typeName)
		{
			this.typeName = typeName;
		}

		/// <summary>Gets the type name of the proxy type.</summary>
		/// <returns>The type name of the proxy type.</returns>
		// Token: 0x1700075F RID: 1887
		// (get) Token: 0x060031F3 RID: 12787 RVA: 0x000C0209 File Offset: 0x000BE409
		[__DynamicallyInvokable]
		public string ProxyTypeName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.typeName;
			}
		}

		/// <summary>Gets or sets the target type for the attribute.</summary>
		/// <returns>The target type for the attribute.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <see cref="P:System.Diagnostics.DebuggerTypeProxyAttribute.Target" /> is set to <see langword="null" />.</exception>
		// Token: 0x17000760 RID: 1888
		// (get) Token: 0x060031F5 RID: 12789 RVA: 0x000C023A File Offset: 0x000BE43A
		// (set) Token: 0x060031F4 RID: 12788 RVA: 0x000C0211 File Offset: 0x000BE411
		[__DynamicallyInvokable]
		public Type Target
		{
			[__DynamicallyInvokable]
			get
			{
				return this.target;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.targetName = value.AssemblyQualifiedName;
				this.target = value;
			}
		}

		/// <summary>Gets or sets the name of the target type.</summary>
		/// <returns>The name of the target type.</returns>
		// Token: 0x17000761 RID: 1889
		// (get) Token: 0x060031F6 RID: 12790 RVA: 0x000C0242 File Offset: 0x000BE442
		// (set) Token: 0x060031F7 RID: 12791 RVA: 0x000C024A File Offset: 0x000BE44A
		[__DynamicallyInvokable]
		public string TargetTypeName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.targetName;
			}
			[__DynamicallyInvokable]
			set
			{
				this.targetName = value;
			}
		}

		// Token: 0x040015ED RID: 5613
		private string typeName;

		// Token: 0x040015EE RID: 5614
		private string targetName;

		// Token: 0x040015EF RID: 5615
		private Type target;
	}
}
