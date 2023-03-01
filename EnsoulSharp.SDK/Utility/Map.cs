using System;
using System.Collections.Generic;
using SharpDX;

namespace EnsoulSharp.SDK.Utility
{
	// Token: 0x0200007F RID: 127
	public class Map
	{
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060004C6 RID: 1222 RVA: 0x00023C23 File Offset: 0x00021E23
		// (set) Token: 0x060004C7 RID: 1223 RVA: 0x00023C2B File Offset: 0x00021E2B
		public Vector2 Grid { get; private set; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x00023C34 File Offset: 0x00021E34
		// (set) Token: 0x060004C9 RID: 1225 RVA: 0x00023C3C File Offset: 0x00021E3C
		public string Name { get; private set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x00023C45 File Offset: 0x00021E45
		// (set) Token: 0x060004CB RID: 1227 RVA: 0x00023C4D File Offset: 0x00021E4D
		public string ShortName { get; private set; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x00023C56 File Offset: 0x00021E56
		// (set) Token: 0x060004CD RID: 1229 RVA: 0x00023C5E File Offset: 0x00021E5E
		public int StartingLevel { get; private set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x00023C67 File Offset: 0x00021E67
		// (set) Token: 0x060004CF RID: 1231 RVA: 0x00023C6F File Offset: 0x00021E6F
		public MapType Type { get; private set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x00023C78 File Offset: 0x00021E78
		// (set) Token: 0x060004D1 RID: 1233 RVA: 0x00023C7F File Offset: 0x00021E7F
		private static Map _currentMap { get; set; }

		// Token: 0x060004D2 RID: 1234 RVA: 0x00023C88 File Offset: 0x00021E88
		public static Map GetMap()
		{
			if (Map._currentMap != null)
			{
				return Map._currentMap;
			}
			if (Map.MapById.ContainsKey((int)Game.MapId))
			{
				Map._currentMap = Map.MapById[(int)Game.MapId];
				return Map._currentMap;
			}
			return new Map
			{
				Name = "Unknown",
				ShortName = "unknown",
				Type = MapType.Unknown,
				Grid = new Vector2(0f, 0f),
				StartingLevel = 1
			};
		}

		// Token: 0x040002A2 RID: 674
		private static readonly Dictionary<int, Map> MapById = new Dictionary<int, Map>
		{
			{
				8,
				new Map
				{
					Name = "The Crystal Scar",
					ShortName = "crystalScar",
					Type = MapType.CrystalScar,
					Grid = new Vector2(6947f, 6609f),
					StartingLevel = 3
				}
			},
			{
				10,
				new Map
				{
					Name = "The Twisted Treeline",
					ShortName = "twistedTreeline",
					Type = MapType.TwistedTreeline,
					Grid = new Vector2(7718f, 7237f),
					StartingLevel = 1
				}
			},
			{
				11,
				new Map
				{
					Name = "Summoner's Rift",
					ShortName = "summonerRift",
					Type = MapType.SummonersRift,
					Grid = new Vector2(6991f, 7223f),
					StartingLevel = 1
				}
			},
			{
				12,
				new Map
				{
					Name = "Howling Abyss",
					ShortName = "howlingAbyss",
					Type = MapType.HowlingAbyss,
					Grid = new Vector2(6560f, 6309f),
					StartingLevel = 3
				}
			}
		};
	}
}
