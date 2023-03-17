using System;
using System.Collections.Generic;
using EnsoulSharp.Native;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each NeutralMinionCampClient object.
	/// </summary>
	// Token: 0x0200015C RID: 348
	public class NeutralMinionCampClient : GameObject
	{
		// Token: 0x06000697 RID: 1687 RVA: 0x00005D0C File Offset: 0x0000510C
		internal NeutralMinionCampClient()
		{
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x00005CF4 File Offset: 0x000050F4
		internal NeutralMinionCampClient(uint networkId, uint index) : base(networkId, index)
		{
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x000016D8 File Offset: 0x00000AD8
		internal new unsafe NeutralMinionCampClient* GetPtr()
		{
			return (NeutralMinionCampClient*)base.GetPtr();
		}

		/// <summary>
		/// 	Gets the chaos rewards.
		/// </summary>
		// Token: 0x17000176 RID: 374
		// (get) Token: 0x0600069A RID: 1690 RVA: 0x0000D8E0 File Offset: 0x0000CCE0
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
		// Token: 0x17000175 RID: 373
		// (get) Token: 0x0600069B RID: 1691 RVA: 0x0000D924 File Offset: 0x0000CD24
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
		// Token: 0x17000174 RID: 372
		// (get) Token: 0x0600069C RID: 1692 RVA: 0x0000D890 File Offset: 0x0000CC90
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
		// Token: 0x17000173 RID: 371
		// (get) Token: 0x0600069D RID: 1693 RVA: 0x0000D8AC File Offset: 0x0000CCAC
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
		// Token: 0x17000172 RID: 370
		// (get) Token: 0x0600069E RID: 1694 RVA: 0x0000D8C8 File Offset: 0x0000CCC8
		public float TimerExpiry
		{
			get
			{
				return <Module>.EnsoulSharp.Native.NeutralMinionCampCommon.GetTimerExpiry(this.GetPtr());
			}
		}
	}
}
