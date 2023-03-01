using System;
using System.Runtime.Serialization;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000AB RID: 171
	[Serializable]
	public class MenuHitChance : MenuList, ISerializable
	{
		// Token: 0x060005EB RID: 1515 RVA: 0x00028981 File Offset: 0x00026B81
		public MenuHitChance(string name, string displayName, HitChance hitchanceValue = HitChance.VeryHigh) : base(name, displayName, new string[]
		{
			"Very High",
			"High",
			"Medium",
			"Low"
		}, (int)(HitChance.VeryHigh - hitchanceValue))
		{
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x000289B4 File Offset: 0x00026BB4
		protected MenuHitChance(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060005ED RID: 1517 RVA: 0x000289BE File Offset: 0x00026BBE
		// (set) Token: 0x060005EE RID: 1518 RVA: 0x000289C8 File Offset: 0x00026BC8
		public HitChance HitChanceIndex
		{
			get
			{
				return HitChance.VeryHigh - base.Index;
			}
			set
			{
				int num;
				if (value < HitChance.OutOfRange)
				{
					num = 0;
				}
				else if (value - HitChance.Low >= base.Items.Length)
				{
					num = base.Items.Length - 1;
				}
				else
				{
					num = value - HitChance.Low;
				}
				if (num != base.Index)
				{
					base.Index = num;
				}
			}
		}
	}
}
