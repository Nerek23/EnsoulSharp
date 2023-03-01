using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000F5 RID: 245
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("DrMundo", SpellSlot.W, 0)]
	public class DamageDrMundoW : DamageSpell
	{
		// Token: 0x060008EE RID: 2286 RVA: 0x00037ECA File Offset: 0x000360CA
		public DamageDrMundoW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x00037EE0 File Offset: 0x000360E0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageDrMundoW.damages[level] + (double)(0.07f * source.BonusHealth);
		}

		// Token: 0x040005D5 RID: 1493
		private static readonly double[] damages = new double[]
		{
			20.0,
			35.0,
			50.0,
			65.0,
			80.0
		};
	}
}
