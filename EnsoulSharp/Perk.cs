using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each perk.
	/// </summary>
	// Token: 0x020000BA RID: 186
	public class Perk
	{
		// Token: 0x060004E0 RID: 1248 RVA: 0x0000E148 File Offset: 0x0000D548
		internal Perk(int id, string name)
		{
			this.m_id = id;
			this.m_name = name;
		}

		/// <summary>
		/// 	Gets the id of the perk.
		/// </summary>
		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060004E1 RID: 1249 RVA: 0x0000E16C File Offset: 0x0000D56C
		public int Id
		{
			get
			{
				return this.m_id;
			}
		}

		/// <summary>
		/// 	Gets the name of the perk.
		/// </summary>
		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060004E2 RID: 1250 RVA: 0x0000E180 File Offset: 0x0000D580
		public string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x040003BB RID: 955
		private int m_id;

		// Token: 0x040003BC RID: 956
		private string m_name;
	}
}
