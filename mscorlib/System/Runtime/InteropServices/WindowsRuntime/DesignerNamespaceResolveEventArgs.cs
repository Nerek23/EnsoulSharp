using System;
using System.Collections.ObjectModel;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	/// <summary>Provides data for the <see cref="E:System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMetadata.DesignerNamespaceResolve" /> event.</summary>
	// Token: 0x020009CC RID: 2508
	[ComVisible(false)]
	public class DesignerNamespaceResolveEventArgs : EventArgs
	{
		/// <summary>Gets the name of the namespace to resolve.</summary>
		/// <returns>The name of the namespace to resolve.</returns>
		// Token: 0x17001145 RID: 4421
		// (get) Token: 0x060063CD RID: 25549 RVA: 0x00153159 File Offset: 0x00151359
		public string NamespaceName
		{
			get
			{
				return this._NamespaceName;
			}
		}

		/// <summary>Gets a collection of assembly file paths; when the event handler for the <see cref="E:System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMetadata.DesignerNamespaceResolve" /> event is invoked, the collection is empty, and the event handler is responsible for adding the necessary assembly files.</summary>
		/// <returns>A collection of assembly files that define the requested namespace.</returns>
		// Token: 0x17001146 RID: 4422
		// (get) Token: 0x060063CE RID: 25550 RVA: 0x00153161 File Offset: 0x00151361
		public Collection<string> ResolvedAssemblyFiles
		{
			get
			{
				return this._ResolvedAssemblyFiles;
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.WindowsRuntime.DesignerNamespaceResolveEventArgs" /> class.</summary>
		/// <param name="namespaceName">The name of the namespace to resolve.</param>
		// Token: 0x060063CF RID: 25551 RVA: 0x00153169 File Offset: 0x00151369
		public DesignerNamespaceResolveEventArgs(string namespaceName)
		{
			this._NamespaceName = namespaceName;
			this._ResolvedAssemblyFiles = new Collection<string>();
		}

		// Token: 0x04002C74 RID: 11380
		private string _NamespaceName;

		// Token: 0x04002C75 RID: 11381
		private Collection<string> _ResolvedAssemblyFiles;
	}
}
