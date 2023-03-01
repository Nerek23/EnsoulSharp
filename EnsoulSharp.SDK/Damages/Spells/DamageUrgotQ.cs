using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002F8 RID: 760
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Urgot", SpellSlot.Q, 0)]
	public class DamageUrgotQ : DamageSpell
	{
		// Token: 0x06000F01 RID: 3841 RVA: 0x00042AA6 File Offset: 0x00040CA6
		public DamageUrgotQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x00042ABC File Offset: 0x00040CBC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageUrgotQ.damages[level] + 0.7 * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000814 RID: 2068
		private static readonly double[] damages = new double[]
		{
			25.0,
			70.0,
			115.0,
			160.0,
			205.0
		};
	}
}
