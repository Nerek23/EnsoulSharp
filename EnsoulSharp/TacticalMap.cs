using System;
using EnsoulSharp.Native;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to tactical map.
	/// </summary>
	// Token: 0x02000170 RID: 368
	public class TacticalMap
	{
		/// <summary>
		/// 	Gets the center world position.
		/// </summary>
		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x0000FAF0 File Offset: 0x0000EEF0
		public unsafe static Vector3 CenterWorldPos
		{
			get
			{
				TacticalMap* ptr = <Module>.EnsoulSharp.Native.TacticalMap.GetInstance();
				if (ptr != null)
				{
					Vector3f* ptr2 = <Module>.EnsoulSharp.Native.TacticalMap.GetCenterWorldPos(ptr);
					Vector3 result = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ptr2), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ptr2), <Module>.EnsoulSharp.Native.Vector3f.GetY(ptr2));
					return result;
				}
				return Vector3.Zero;
			}
		}

		/// <summary>
		/// 	Gets the tactical map's top left offset.
		/// </summary>
		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060006A8 RID: 1704 RVA: 0x0000FB30 File Offset: 0x0000EF30
		public unsafe static Vector2 Offset
		{
			get
			{
				TacticalMap* ptr = <Module>.EnsoulSharp.Native.TacticalMap.GetInstance();
				if (ptr != null)
				{
					float y = *<Module>.EnsoulSharp.Native.TacticalMap.GetMapTopLeftY(ptr);
					float* ptr2 = <Module>.EnsoulSharp.Native.TacticalMap.GetMapTopLeftX(ptr);
					Vector2 result = new Vector2(*ptr2, y);
					return result;
				}
				return Vector2.Zero;
			}
		}

		/// <summary>
		/// 	Gets the tactical map's size.
		/// </summary>
		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060006A9 RID: 1705 RVA: 0x0000FB68 File Offset: 0x0000EF68
		public unsafe static Vector2 Size
		{
			get
			{
				TacticalMap* ptr = <Module>.EnsoulSharp.Native.TacticalMap.GetInstance();
				if (ptr != null)
				{
					float y = *<Module>.EnsoulSharp.Native.TacticalMap.GetMapHeight(ptr);
					float* ptr2 = <Module>.EnsoulSharp.Native.TacticalMap.GetMapWidth(ptr);
					Vector2 result = new Vector2(*ptr2, y);
					return result;
				}
				return Vector2.Zero;
			}
		}
	}
}
