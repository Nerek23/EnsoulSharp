using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200002A RID: 42
	internal static class StoredPaths
	{
		// Token: 0x060001CC RID: 460 RVA: 0x0000B8A2 File Offset: 0x00009AA2
		static StoredPaths()
		{
			AIBaseClient.OnNewPath += StoredPaths.OnPathTrackNewPath;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000B8C0 File Offset: 0x00009AC0
		private static void OnPathTrackNewPath(AIBaseClient sender, AIBaseClientNewPathEventArgs args)
		{
			if (sender == null || !sender.IsValid || sender.Type != GameObjectType.AIHeroClient)
			{
				return;
			}
			if (!StoredPaths.Paths.ContainsKey(sender.NetworkId))
			{
				StoredPaths.Paths.Add(sender.NetworkId, new List<StoredPaths.StoredPath>());
			}
			StoredPaths.StoredPath item = new StoredPaths.StoredPath
			{
				Tick = Variables.GameTimeTickCount,
				Path = args.Path.ToList<Vector3>().ToVector2()
			};
			StoredPaths.Paths[sender.NetworkId].Add(item);
			if (StoredPaths.Paths[sender.NetworkId].Count > 50)
			{
				StoredPaths.Paths[sender.NetworkId].RemoveRange(0, 40);
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000B97D File Offset: 0x00009B7D
		public static StoredPaths.StoredPath GetCurrentPath(AIBaseClient unit)
		{
			if (!(unit != null) || !StoredPaths.Paths.ContainsKey(unit.NetworkId))
			{
				return new StoredPaths.StoredPath();
			}
			return StoredPaths.Paths[unit.NetworkId].LastOrDefault<StoredPaths.StoredPath>();
		}

		// Token: 0x040000E0 RID: 224
		private static readonly Dictionary<int, List<StoredPaths.StoredPath>> Paths = new Dictionary<int, List<StoredPaths.StoredPath>>();

		// Token: 0x02000457 RID: 1111
		public class StoredPath
		{
			// Token: 0x170001AD RID: 429
			// (get) Token: 0x06001495 RID: 5269 RVA: 0x0004B836 File Offset: 0x00049A36
			public double Time
			{
				get
				{
					return (double)(Variables.GameTimeTickCount - this.Tick) / 1000.0;
				}
			}

			// Token: 0x04000B3C RID: 2876
			public List<Vector2> Path;

			// Token: 0x04000B3D RID: 2877
			public int Tick;
		}
	}
}
