using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002FD RID: 765
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vayne", SpellSlot.E, 1)]
	public class DamageVayneE1 : DamageSpell
	{
		// Token: 0x06000F10 RID: 3856 RVA: 0x00042C31 File Offset: 0x00040E31
		public DamageVayneE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000F11 RID: 3857 RVA: 0x00042C4E File Offset: 0x00040E4E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVayneE1.damages[level] + 0.75 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x0400081A RID: 2074
		private static readonly double[] damages = new double[]
		{
			75.0,
			127.5,
			180.0,
			232.5,
			285.0
		};
	}
}
