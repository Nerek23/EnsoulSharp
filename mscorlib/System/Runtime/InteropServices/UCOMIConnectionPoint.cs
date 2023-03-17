using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.IConnectionPoint" /> instead.</summary>
	// Token: 0x02000950 RID: 2384
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IConnectionPoint instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("B196B286-BAB4-101A-B69C-00AA00341D07")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMIConnectionPoint
	{
		/// <summary>Returns the IID of the outgoing interface managed by this connection point.</summary>
		/// <param name="pIID">On successful return, contains the IID of the outgoing interface managed by this connection point.</param>
		// Token: 0x06006166 RID: 24934
		void GetConnectionInterface(out Guid pIID);

		/// <summary>Retrieves the <see langword="IConnectionPointContainer" /> interface pointer to the connectable object that conceptually owns this connection point.</summary>
		/// <param name="ppCPC">On successful return, contains the connectable object's <see langword="IConnectionPointContainer" /> interface.</param>
		// Token: 0x06006167 RID: 24935
		void GetConnectionPointContainer(out UCOMIConnectionPointContainer ppCPC);

		/// <summary>Establishes an advisory connection between the connection point and the caller's sink object.</summary>
		/// <param name="pUnkSink">Reference to the sink to receive calls for the outgoing interface managed by this connection point.</param>
		/// <param name="pdwCookie">On successful return, contains the connection cookie.</param>
		// Token: 0x06006168 RID: 24936
		void Advise([MarshalAs(UnmanagedType.Interface)] object pUnkSink, out int pdwCookie);

		/// <summary>Terminates an advisory connection previously established through <see cref="M:System.Runtime.InteropServices.UCOMIConnectionPoint.Advise(System.Object,System.Int32@)" />.</summary>
		/// <param name="dwCookie">The connection cookie previously returned from <see cref="M:System.Runtime.InteropServices.UCOMIConnectionPoint.Advise(System.Object,System.Int32@)" />.</param>
		// Token: 0x06006169 RID: 24937
		void Unadvise(int dwCookie);

		/// <summary>Creates an enumerator object for iteration through the connections that exist to this connection point.</summary>
		/// <param name="ppEnum">On successful return, contains the newly created enumerator.</param>
		// Token: 0x0600616A RID: 24938
		void EnumConnections(out UCOMIEnumConnections ppEnum);
	}
}
