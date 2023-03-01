using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200012B RID: 299
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Annie", SpellSlot.W, 0)]
	public class DamageAnnieW : DamageSpell
	{
		// Token: 0x06000990 RID: 2448 RVA: 0x000391B6 File Offset: 0x000373B6
		public DamageAnnieW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x000391CC File Offset: 0x000373CC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAnnieW.damages[level] + 0.85 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000613 RID: 1555
		private static readonly double[] damages = new double[]
		{
			70.0,
			115.0,
			160.0,
			205.0,
			250.0
		};
	}
}
