using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.IConnectionPointContainer" /> instead.</summary>
	// Token: 0x0200094F RID: 2383
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IConnectionPointContainer instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("B196B284-BAB4-101A-B69C-00AA00341D07")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMIConnectionPointContainer
	{
		/// <summary>Creates an enumerator of all the connection points supported in the connectable object, one connection point per IID.</summary>
		/// <param name="ppEnum">On successful return, contains the interface pointer of the enumerator.</param>
		// Token: 0x06006164 RID: 24932
		void EnumConnectionPoints(out UCOMIEnumConnectionPoints ppEnum);

		/// <summary>Asks the connectable object if it has a connection point for a particular IID, and if so, returns the <see langword="IConnectionPoint" /> interface pointer to that connection point.</summary>
		/// <param name="riid">A reference to the outgoing interface IID whose connection point is being requested.</param>
		/// <param name="ppCP">On successful return, contains the connection point that manages the outgoing interface <paramref name="riid" />.</param>
		// Token: 0x06006165 RID: 24933
		void FindConnectionPoint(ref Guid riid, out UCOMIConnectionPoint ppCP);
	}
}
