using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200002A RID: 42
	public class InfoQueueFilterDescription
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000265 RID: 613 RVA: 0x0000A636 File Offset: 0x00008836
		// (set) Token: 0x06000266 RID: 614 RVA: 0x0000A63E File Offset: 0x0000883E
		public MessageCategory[] Categories { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000267 RID: 615 RVA: 0x0000A647 File Offset: 0x00008847
		// (set) Token: 0x06000268 RID: 616 RVA: 0x0000A64F File Offset: 0x0000884F
		public MessageSeverity[] Severities { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000269 RID: 617 RVA: 0x0000A658 File Offset: 0x00008858
		// (set) Token: 0x0600026A RID: 618 RVA: 0x0000A660 File Offset: 0x00008860
		public MessageId[] Ids { get; set; }

		// Token: 0x0600026B RID: 619 RVA: 0x0000A669 File Offset: 0x00008869
		internal void __MarshalFree(ref InfoQueueFilterDescription.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000A674 File Offset: 0x00008874
		internal void __MarshalFrom(ref InfoQueueFilterDescription.__Native @ref)
		{
			this.Categories = new MessageCategory[@ref.CategorieCount];
			if (@ref.CategorieCount > 0)
			{
				Utilities.Read<MessageCategory>(@ref.PCategoryList, this.Categories, 0, @ref.CategorieCount);
			}
			this.Severities = new MessageSeverity[@ref.SeveritieCount];
			if (@ref.SeveritieCount > 0)
			{
				Utilities.Read<MessageSeverity>(@ref.PSeverityList, this.Severities, 0, @ref.SeveritieCount);
			}
			this.Ids = new MessageId[@ref.IDCount];
			if (@ref.IDCount > 0)
			{
				Utilities.Read<MessageId>(@ref.PIDList, this.Ids, 0, @ref.IDCount);
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000A71C File Offset: 0x0000891C
		internal void __MarshalTo(ref InfoQueueFilterDescription.__Native @ref)
		{
			@ref.CategorieCount = ((this.Categories == null) ? 0 : this.Categories.Length);
			if (@ref.CategorieCount > 0)
			{
				@ref.PCategoryList = Marshal.AllocHGlobal(4 * @ref.CategorieCount);
				Utilities.Write<MessageCategory>(@ref.PCategoryList, this.Categories, 0, @ref.CategorieCount);
			}
			@ref.SeveritieCount = ((this.Severities == null) ? 0 : this.Severities.Length);
			if (@ref.SeveritieCount > 0)
			{
				@ref.PSeverityList = Marshal.AllocHGlobal(4 * @ref.SeveritieCount);
				Utilities.Write<MessageSeverity>(@ref.PSeverityList, this.Severities, 0, @ref.SeveritieCount);
			}
			@ref.IDCount = ((this.Ids == null) ? 0 : this.Ids.Length);
			if (@ref.IDCount > 0)
			{
				@ref.PIDList = Marshal.AllocHGlobal(4 * @ref.IDCount);
				Utilities.Write<MessageId>(@ref.PIDList, this.Ids, 0, @ref.IDCount);
			}
		}

		// Token: 0x0400008D RID: 141
		internal int CategorieCount;

		// Token: 0x0400008E RID: 142
		internal IntPtr PCategoryList;

		// Token: 0x0400008F RID: 143
		internal int SeveritieCount;

		// Token: 0x04000090 RID: 144
		internal IntPtr PSeverityList;

		// Token: 0x04000091 RID: 145
		internal int IDCount;

		// Token: 0x04000092 RID: 146
		internal IntPtr PIDList;

		// Token: 0x0200002B RID: 43
		internal struct __Native
		{
			// Token: 0x0600026F RID: 623 RVA: 0x0000A814 File Offset: 0x00008A14
			internal void __MarshalFree()
			{
				if (this.PCategoryList != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.PCategoryList);
				}
				if (this.PSeverityList != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.PSeverityList);
				}
				if (this.PIDList != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.PIDList);
				}
			}

			// Token: 0x04000093 RID: 147
			public int CategorieCount;

			// Token: 0x04000094 RID: 148
			public IntPtr PCategoryList;

			// Token: 0x04000095 RID: 149
			public int SeveritieCount;

			// Token: 0x04000096 RID: 150
			public IntPtr PSeverityList;

			// Token: 0x04000097 RID: 151
			public int IDCount;

			// Token: 0x04000098 RID: 152
			public IntPtr PIDList;
		}
	}
}
