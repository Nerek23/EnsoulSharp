using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000301 RID: 769
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vex", SpellSlot.W, 0)]
	public class DamageVexW : DamageSpell
	{
		// Token: 0x06000F1C RID: 3868 RVA: 0x00042D70 File Offset: 0x00040F70
		public DamageVexW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F1D RID: 3869 RVA: 0x00042D86 File Offset: 0x00040F86
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVexW.damages[level] + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400081F RID: 2079
		private static readonly double[] damages = new double[]
		{
			80.0,
			120.0,
			160.0,
			200.0,
			240.0
		};
	}
}
