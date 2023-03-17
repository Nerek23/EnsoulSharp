using System;
using System.Runtime.InteropServices;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.Game" /> process packet event.
	/// </summary>
	// Token: 0x020000D8 RID: 216
	public class GamePacketEventArgs : EventArgs
	{
		// Token: 0x060004F7 RID: 1271 RVA: 0x0000C6E0 File Offset: 0x0000BAE0
		internal GamePacketEventArgs([MarshalAs(UnmanagedType.U1)] bool process, int eventId, int networkId, byte[] packetData)
		{
			this.m_process = process;
			this.m_eventId = eventId;
			this.m_networkId = networkId;
			this.m_packetData = packetData;
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether the event should process.
		/// </summary>
		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060004F8 RID: 1272 RVA: 0x0000C710 File Offset: 0x0000BB10
		// (set) Token: 0x060004F9 RID: 1273 RVA: 0x0000C724 File Offset: 0x0000BB24
		public bool Process
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.m_process;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				this.m_process = value;
			}
		}

		/// <summary>
		/// 	Gets the event id.
		/// </summary>
		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060004FA RID: 1274 RVA: 0x0000C738 File Offset: 0x0000BB38
		public int EventId
		{
			get
			{
				return this.m_eventId;
			}
		}

		/// <summary>
		/// 	Gets the relative object network id.
		/// </summary>
		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060004FB RID: 1275 RVA: 0x0000C74C File Offset: 0x0000BB4C
		public int NetworkId
		{
			get
			{
				return this.m_networkId;
			}
		}

		/// <summary>
		/// 	Gets the original packet data.
		/// </summary>
		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x0000C760 File Offset: 0x0000BB60
		public byte[] PacketData
		{
			get
			{
				return this.m_packetData;
			}
		}

		// Token: 0x040003C0 RID: 960
		private bool m_process;

		// Token: 0x040003C1 RID: 961
		private int m_eventId;

		// Token: 0x040003C2 RID: 962
		private int m_networkId;

		// Token: 0x040003C3 RID: 963
		private byte[] m_packetData;
	}
}
