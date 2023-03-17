using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.Game" /> notify event.
	/// </summary>
	// Token: 0x020000D7 RID: 215
	public class GameNotifyEventArgs : EventArgs
	{
		// Token: 0x060004F3 RID: 1267 RVA: 0x0000B378 File Offset: 0x0000A778
		internal GameNotifyEventArgs(GameEventId eventId, int networkId, byte[] packetData)
		{
			this.m_eventId = eventId;
			this.m_networkId = networkId;
			this.m_packetData = packetData;
		}

		/// <summary>
		/// 	Gets the event id.
		/// </summary>
		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060004F4 RID: 1268 RVA: 0x0000B3A0 File Offset: 0x0000A7A0
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
		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060004F5 RID: 1269 RVA: 0x0000B3B4 File Offset: 0x0000A7B4
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
		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060004F6 RID: 1270 RVA: 0x0000B3C8 File Offset: 0x0000A7C8
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
