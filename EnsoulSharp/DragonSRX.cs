using System;
using System.Collections.Generic;
using EnsoulSharp.Native;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to dragon srx.
	/// </summary>
	// Token: 0x020000EF RID: 239
	public class DragonSRX
	{
		// Token: 0x0600057C RID: 1404 RVA: 0x00006704 File Offset: 0x00005B04
		internal unsafe DragonSRX(UIMetricMultiDragonKillsSRX* srx)
		{
			this.m_srx = srx;
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x00006720 File Offset: 0x00005B20
		internal unsafe UIMetricMultiDragonKillsSRX* GetPtr()
		{
			return this.m_srx;
		}

		/// <summary>
		/// 	Gets the center element.
		/// </summary>
		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600057E RID: 1406 RVA: 0x00006734 File Offset: 0x00005B34
		public DragonSRXSlot Center
		{
			get
			{
				return new DragonSRXSlot(<Module>.EnsoulSharp.Native.UIMetricMultiDragonKillsSRX.GetSoulSlotIconInfo(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the elements one.
		/// </summary>
		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x00006754 File Offset: 0x00005B54
		public unsafe DragonSRXSlot[] ElementsOne
		{
			get
			{
				List<DragonSRXSlot> list = new List<DragonSRXSlot>();
				StlArray<EnsoulSharp::Native::IconSlotInfo>* ptr = <Module>.EnsoulSharp.Native.UIMetricMultiDragonKillsSRX.GetTeamSlotsIconInfo(this.GetPtr());
				uint num = 0U;
				if (0 < *(int*)(ptr + 4 / sizeof(StlArray<EnsoulSharp::Native::IconSlotInfo>)))
				{
					int num2 = 0;
					do
					{
						list.Add(new DragonSRXSlot(*(int*)ptr + num2));
						num += 1U;
						num2 += 24;
					}
					while (num < (uint)(*(int*)(ptr + 4 / sizeof(StlArray<EnsoulSharp::Native::IconSlotInfo>))));
				}
				return list.ToArray();
			}
		}

		/// <summary>
		/// 	Gets the elements two.
		/// </summary>
		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000580 RID: 1408 RVA: 0x000067A4 File Offset: 0x00005BA4
		public unsafe DragonSRXSlot[] ElementsTwo
		{
			get
			{
				List<DragonSRXSlot> list = new List<DragonSRXSlot>();
				StlArray<EnsoulSharp::Native::IconSlotInfo>* ptr = <Module>.EnsoulSharp.Native.UIMetricMultiDragonKillsSRX.GetTeamSlotsIconInfo(this.GetPtr()) + 12;
				uint num = 0U;
				if (0 < *(int*)(ptr + 4 / sizeof(StlArray<EnsoulSharp::Native::IconSlotInfo>)))
				{
					int num2 = 0;
					do
					{
						list.Add(new DragonSRXSlot(*(int*)ptr + num2));
						num += 1U;
						num2 += 24;
					}
					while (num < (uint)(*(int*)(ptr + 4 / sizeof(StlArray<EnsoulSharp::Native::IconSlotInfo>))));
				}
				return list.ToArray();
			}
		}

		// Token: 0x040003E1 RID: 993
		private unsafe UIMetricMultiDragonKillsSRX* m_srx;
	}
}
