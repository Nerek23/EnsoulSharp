using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.Game" /> notify event.
	/// </summary>
	// Token: 0x020000D7 RID: 215
	public class GameNotifyEventArgs : EventArgs
	{
		// Token: 0x060004E8 RID: 1256 RVA: 0x0000B288 File Offset: 0x0000A688
		internal GameNotifyEventArgs(GameEventId eventId, int networkId, byte[] packetData)
		{
			this.m_eventId = eventId;
			this.m_networkId = networkId;
			this.m_packetData = packetData;
		}

		/// <summary>
		/// 	Gets the event id.
		/// </summary>
		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060004E9 RID: 1257 RVA: 0x0000B2B0 File Offset: 0x0000A6B0
		public GameEventId EventId
		{
			get
			{
				return this.m_eventId;
			}
		}

		/// <summary>
		/// 	Gets the relative object network id.
		/// </summary>
		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060004EA RID: 1258 RVA: 0x0000B2C4 File Offset: 0x0000A6C4
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
		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x0000B2D8 File Offset: 0x0000A6D8
		public byte[] PacketData
		{
			get
			{
				return this.m_packetData;
			}
		}

		// Token: 0x040003BD RID: 957
		private GameEventId m_eventId;

		// Token: 0x040003BE RID: 958
		private int m_networkId;

		// Token: 0x040003BF RID: 959
		private byte[] m_packetData;
	}
}
