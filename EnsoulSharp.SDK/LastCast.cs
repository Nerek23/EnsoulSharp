using System;
using System.Collections.Generic;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000051 RID: 81
	public static class LastCast
	{
		// Token: 0x06000342 RID: 834 RVA: 0x00018C6C File Offset: 0x00016E6C
		static LastCast()
		{
			AIBaseClient.OnDoCast += LastCast.OnDoCast;
			Spellbook.OnCastSpell += LastCast.OnCastSpell;
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000343 RID: 835 RVA: 0x00018C9A File Offset: 0x00016E9A
		// (set) Token: 0x06000344 RID: 836 RVA: 0x00018CA1 File Offset: 0x00016EA1
		public static LastCastPacketSentEntry LastCastPacketSent { get; private set; }

		// Token: 0x06000345 RID: 837 RVA: 0x00018CAC File Offset: 0x00016EAC
		public static LastCastedSpellEntry GetLastCastedSpell(this AIHeroClient target)
		{
			LastCastedSpellEntry result;
			if (!LastCast.CastedSpells.TryGetValue(target.NetworkId, out result))
			{
				return new LastCastedSpellEntry();
			}
			return result;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00018CD4 File Offset: 0x00016ED4
		private static void OnDoCast(AIBaseClient sender, AIBaseClientProcessSpellCastEventArgs args)
		{
			if (sender != null && sender.IsValid && sender.Type == GameObjectType.AIHeroClient)
			{
				LastCastedSpellEntry value = new LastCastedSpellEntry(args);
				if (!LastCast.CastedSpells.ContainsKey(sender.NetworkId))
				{
					LastCast.CastedSpells.Add(sender.NetworkId, value);
					return;
				}
				LastCast.CastedSpells[sender.NetworkId] = value;
			}
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00018D38 File Offset: 0x00016F38
		private static void OnCastSpell(Spellbook sender, SpellbookCastSpellEventArgs args)
		{
			if (((sender != null) ? sender.Owner : null) != null && sender.Owner.IsValid && sender.Owner.IsMe)
			{
				AIBaseClient aibaseClient = args.Target as AIBaseClient;
				LastCast.LastCastPacketSent = new LastCastPacketSentEntry(args.Slot, Variables.GameTimeTickCount, (aibaseClient != null) ? aibaseClient.NetworkId : 0);
			}
		}

		// Token: 0x040001E2 RID: 482
		internal static readonly Dictionary<int, LastCastedSpellEntry> CastedSpells = new Dictionary<int, LastCastedSpellEntry>();
	}
}
