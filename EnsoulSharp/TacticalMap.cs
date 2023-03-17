using System;
using EnsoulSharp.Native;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to tactical map.
	/// </summary>
	// Token: 0x02000172 RID: 370
	public class TacticalMap
	{
		/// <summary>
		/// 	Gets the center world position.
		/// </summary>
		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060006B4 RID: 1716 RVA: 0x0000FBE0 File Offset: 0x0000EFE0
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
		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060006B5 RID: 1717 RVA: 0x0000FC20 File Offset: 0x0000F020
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
		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060006B6 RID: 1718 RVA: 0x0000FC58 File Offset: 0x0000F058
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
