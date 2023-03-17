using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Describes the callbacks that the type library importer makes when importing a type library.</summary>
	// Token: 0x02000940 RID: 2368
	[ComVisible(true)]
	[Serializable]
	public enum ImporterEventKind
	{
		/// <summary>Specifies that the event is invoked when a type has been imported.</summary>
		// Token: 0x04002AF8 RID: 11000
		NOTIF_TYPECONVERTED,
		/// <summary>Specifies that the event is invoked when a warning occurs during conversion.</summary>
		// Token: 0x04002AF9 RID: 11001
		NOTIF_CONVERTWARNING,
		/// <summary>This property is not supported in this version of the .NET Framework.</summary>
		// Token: 0x04002AFA RID: 11002
		ERROR_REFTOINVALIDTYPELIB
	}
}
