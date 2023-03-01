using System;
using System.Collections.Generic;
using EnsoulSharp.Native;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each NeutralMinionCampClient object.
	/// </summary>
	// Token: 0x0200015A RID: 346
	public class NeutralMinionCampClient : GameObject
	{
		// Token: 0x0600068A RID: 1674 RVA: 0x00005C8C File Offset: 0x0000508C
		internal NeutralMinionCampClient()
		{
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00005C74 File Offset: 0x00005074
		internal NeutralMinionCampClient(uint networkId, uint index) : base(networkId, index)
		{
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x000016D8 File Offset: 0x00000AD8
		internal new unsafe NeutralMinionCampClient* GetPtr()
		{
			return (NeutralMinionCampClient*)base.GetPtr();
		}

		/// <summary>
		/// 	Gets the chaos rewards.
		/// </summary>
		// Token: 0x17000170 RID: 368
		// (get) Token: 0x0600068D RID: 1677 RVA: 0x0000D7F0 File Offset: 0x0000CBF0
		public unsafe int[] ChaosRewards
		{
			get
			{
				List<int> list = new List<int>();
				StlVector<unsigned\u0020int>* ptr = <Module>.EnsoulSharp.Native.NeutralMinionCampCommon.GetChaosRewards(this.GetPtr());
				uint* ptr2 = *(int*)ptr;
				if (ptr2 != *(int*)(ptr + 4 / sizeof(StlVector<unsigned\u0020int>)))
				{
					do
					{
						list.Add((int)(*ptr2));
						ptr2++;
					}
					while (ptr2 != *(int*)(ptr + 4 / sizeof(StlVector<unsigned\u0020int>)));
				}
				return list.ToArray();
			}
		}

		/// <summary>
		/// 	Gets the order rewards.
		/// </summary>
		// Token: 0x1700016F RID: 367
		// (get) Token: 0x0600068E RID: 1678 RVA: 0x0000D834 File Offset: 0x0000CC34
		public unsafe int[] OrderRewards
		{
			get
			{
				List<int> list = new List<int>();
				StlVector<unsigned\u0020int>* ptr = <Module>.EnsoulSharp.Native.NeutralMinionCampCommon.GetOrderRewards(this.GetPtr());
				uint* ptr2 = *(int*)ptr;
				if (ptr2 != *(int*)(ptr + 4 / sizeof(StlVector<unsigned\u0020int>)))
				{
					do
					{
						list.Add((int)(*ptr2));
						ptr2++;
					}
					while (ptr2 != *(int*)(ptr + 4 / sizeof(StlVector<unsigned\u0020int>)));
				}
				return list.ToArray();
			}
		}

		/// <summary>
		/// 	Gets the name of soul.
		/// </summary>
		// Token: 0x1700016E RID: 366
		// (get) Token: 0x0600068F RID: 1679 RVA: 0x0000D7A0 File Offset: 0x0000CBA0
		public unsafe int SoulName
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.NeutralMinionCampCommon.GetSoulName(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets the owner team of soul.
		/// </summary>
		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000690 RID: 1680 RVA: 0x0000D7BC File Offset: 0x0000CBBC
		public unsafe GameObjectTeam SoulTeamOwner
		{
			get
			{
				return (GameObjectTeam)(*<Module>.EnsoulSharp.Native.NeutralMinionCampCommon.GetSoulTeamOwner(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the timer expiry of the object.
		/// </summary>
		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000691 RID: 1681 RVA: 0x0000D7D8 File Offset: 0x0000CBD8
		public float TimerExpiry
		{
			get
			{
				return <Module>.EnsoulSharp.Native.NeutralMinionCampCommon.GetTimerExpiry(this.GetPtr());
			}
		}
	}
}
