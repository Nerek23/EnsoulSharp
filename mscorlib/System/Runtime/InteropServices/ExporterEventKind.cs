using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Describes the callbacks that the type library exporter makes when exporting a type library.</summary>
	// Token: 0x02000941 RID: 2369
	[ComVisible(true)]
	[Serializable]
	public enum ExporterEventKind
	{
		/// <summary>Specifies that the event is invoked when a type has been exported.</summary>
		// Token: 0x04002AFC RID: 11004
		NOTIF_TYPECONVERTED,
		/// <summary>Specifies that the event is invoked when a warning occurs during conversion.</summary>
		// Token: 0x04002AFD RID: 11005
		NOTIF_CONVERTWARNING,
		/// <summary>This value is not supported in this version of the .NET Framework.</summary>
		// Token: 0x04002AFE RID: 11006
		ERROR_REFTOINVALIDASSEMBLY
	}
}
