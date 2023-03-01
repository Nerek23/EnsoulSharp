using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000347 RID: 839
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ziggs", SpellSlot.Q, 0)]
	public class DamageZiggsQ : DamageSpell
	{
		// Token: 0x06000FED RID: 4077 RVA: 0x0004444F File Offset: 0x0004264F
		public DamageZiggsQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FEE RID: 4078 RVA: 0x00044465 File Offset: 0x00042665
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZiggsQ.damages[level] + 0.65 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400086B RID: 2155
		private static readonly double[] damages = new double[]
		{
			95.0,
			145.0,
			195.0,
			245.0,
			295.0
		};
	}
}
