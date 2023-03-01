using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000287 RID: 647
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rengar", SpellSlot.W, 1)]
	public class DamageRengarW1 : DamageSpell
	{
		// Token: 0x06000DAE RID: 3502 RVA: 0x000403AF File Offset: 0x0003E5AF
		public DamageRengarW1()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000DAF RID: 3503 RVA: 0x000403CC File Offset: 0x0003E5CC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRengarW1.damages[Math.Min(17, source.Level - 1)] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000790 RID: 1936
		private static readonly double[] damages = new double[]
		{
			50.0,
			60.0,
			70.0,
			80.0,
			90.0,
			100.0,
			110.0,
			120.0,
			130.0,
			140.0,
			150.0,
			160.0,
			170.0,
			180.0,
			190.0,
			200.0,
			210.0,
			220.0
		};
	}
}
