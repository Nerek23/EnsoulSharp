using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200026F RID: 623
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Pyke", SpellSlot.R, 0)]
	public class DamagePykeR : DamageSpell
	{
		// Token: 0x06000D67 RID: 3431 RVA: 0x0003FBE3 File Offset: 0x0003DDE3
		public DamagePykeR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.True;
		}

		// Token: 0x06000D68 RID: 3432 RVA: 0x0003FBFC File Offset: 0x0003DDFC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamagePykeR.damages[Math.Min(17, source.Level - 1)] + 0.8 * (double)source.GetBonusAaDamage() + 1.5 * (double)source.PhysicalLethality;
			if ((double)target.Health > num)
			{
				return source.CalculatePhysicalDamage(target, num);
			}
			return num;
		}

		// Token: 0x04000777 RID: 1911
		private static readonly double[] damages = new double[]
		{
			250.0,
			250.0,
			250.0,
			250.0,
			250.0,
			250.0,
			290.0,
			330.0,
			370.0,
			400.0,
			430.0,
			450.0,
			470.0,
			490.0,
			510.0,
			530.0,
			540.0,
			550.0
		};
	}
}
