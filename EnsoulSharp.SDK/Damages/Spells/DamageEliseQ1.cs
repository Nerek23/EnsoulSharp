using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200016F RID: 367
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Elise", SpellSlot.Q, 1)]
	public class DamageEliseQ1 : DamageSpell
	{
		// Token: 0x06000A64 RID: 2660 RVA: 0x0003A955 File Offset: 0x00038B55
		public DamageEliseQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x0003A972 File Offset: 0x00038B72
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageEliseQ1.damages[level] + (0.08 + 0.0003 * (double)source.TotalMagicalDamage) * (double)(target.MaxHealth - target.Health);
		}

		// Token: 0x04000666 RID: 1638
		private static readonly double[] damages = new double[]
		{
			60.0,
			90.0,
			120.0,
			150.0,
			180.0
		};
	}
}
