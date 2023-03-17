using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Specifies the paths that are used to search for DLLs that provide functions for platform invokes.</summary>
	// Token: 0x02000906 RID: 2310
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Method, AllowMultiple = false)]
	[ComVisible(false)]
	[__DynamicallyInvokable]
	public sealed class DefaultDllImportSearchPathsAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.DefaultDllImportSearchPathsAttribute" /> class, specifying the paths to use when searching for the targets of platform invokes.</summary>
		/// <param name="paths">A bitwise combination of enumeration values that specify the paths that the LoadLibraryEx function searches during platform invokes.</param>
		// Token: 0x06005F1B RID: 24347 RVA: 0x00147018 File Offset: 0x00145218
		[__DynamicallyInvokable]
		public DefaultDllImportSearchPathsAttribute(DllImportSearchPath paths)
		{
			this._paths = paths;
		}

		/// <summary>Gets a bitwise combination of enumeration values that specify the paths that the LoadLibraryEx function searches during platform invokes.</summary>
		/// <returns>A bitwise combination of enumeration values that specify search paths for platform invokes.</returns>
		// Token: 0x170010CA RID: 4298
		// (get) Token: 0x06005F1C RID: 24348 RVA: 0x00147027 File Offset: 0x00145227
		[__DynamicallyInvokable]
		public DllImportSearchPath Paths
		{
			[__DynamicallyInvokable]
			get
			{
				return this._paths;
			}
		}

		// Token: 0x04002A56 RID: 10838
		internal DllImportSearchPath _paths;
	}
}
