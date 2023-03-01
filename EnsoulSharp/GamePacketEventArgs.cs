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
		// Token: 0x060004EC RID: 1260 RVA: 0x0000C5F0 File Offset: 0x0000B9F0
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
		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x0000C620 File Offset: 0x0000BA20
		// (set) Token: 0x060004EE RID: 1262 RVA: 0x0000C634 File Offset: 0x0000BA34
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
		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x0000C648 File Offset: 0x0000BA48
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
		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060004F0 RID: 1264 RVA: 0x0000C65C File Offset: 0x0000BA5C
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
		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060004F1 RID: 1265 RVA: 0x0000C670 File Offset: 0x0000BA70
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
