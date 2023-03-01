using System;
using System.Runtime.InteropServices;
using EnsoulSharp.Native;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each buff instance.
	/// </summary>
	// Token: 0x02000068 RID: 104
	public class BuffInstance
	{
		// Token: 0x06000417 RID: 1047 RVA: 0x000064C4 File Offset: 0x000058C4
		internal unsafe BuffInstance(BuffInstanceClient* buff)
		{
			this.m_buff = buff;
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x000064E0 File Offset: 0x000058E0
		internal unsafe BuffInstanceClient* GetPtr()
		{
			return this.m_buff;
		}

		/// <summary>
		/// 	Gets a value indicating whether the buff is valid.
		/// </summary>
		/// <remarks>We suggest you can use this property check whether the buff is valid before any other calls.</remarks>
		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x000064F4 File Offset: 0x000058F4
		public unsafe bool IsValid
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				BuffInstanceClient* ptr = this.GetPtr();
				if (ptr != null && <Module>.EnsoulSharp.Native.BuffInstance.IsActive(ptr) != null)
				{
					double num = (double)(*<Module>.EnsoulSharp.Native.BuffInstance.GetEndTime(ptr));
					if (num > (double)Game.Time)
					{
						return true;
					}
				}
				return false;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the buff is active.
		/// </summary>
		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600041A RID: 1050 RVA: 0x00006528 File Offset: 0x00005928
		public bool IsActive
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.BuffInstance.IsActive(this.GetPtr()) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the buff is positive.
		/// </summary>
		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600041B RID: 1051 RVA: 0x00006540 File Offset: 0x00005940
		public bool IsPositive
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.BuffInstance.IsPositive(this.GetPtr()) != null;
			}
		}

		/// <summary>
		/// 	Gets the type of the buff.
		/// </summary>
		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600041C RID: 1052 RVA: 0x00006558 File Offset: 0x00005958
		public unsafe BuffType Type
		{
			get
			{
				return (BuffType)(*<Module>.EnsoulSharp.Native.BuffInstance.GetType(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the start time of the buff.
		/// </summary>
		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x00006574 File Offset: 0x00005974
		public unsafe float StartTime
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.BuffInstance.GetStartTime(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets the end time of the buff.
		/// </summary>
		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x00006590 File Offset: 0x00005990
		public unsafe float EndTime
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.BuffInstance.GetEndTime(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets the tooltip vars of the buff.
		/// </summary>
		/// <remarks>The max count is 16.</remarks>
		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x000065AC File Offset: 0x000059AC
		public unsafe float[] TooltipVars
		{
			get
			{
				float[] array = new float[16];
				BuffInstanceClient* ptr = this.GetPtr();
				int num = 0;
				do
				{
					float num2 = *(num * 4 + <Module>.EnsoulSharp.Native.BuffInstance.GetToolTipVars(ptr));
					array[num] = num2;
					num++;
				}
				while (num < 16);
				return array;
			}
		}

		/// <summary>
		/// 	Gets the count of the buff.
		/// </summary>
		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000420 RID: 1056 RVA: 0x000065E4 File Offset: 0x000059E4
		public int Count
		{
			get
			{
				return <Module>.EnsoulSharp.Native.BuffInstance.GetCount(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets the name of the buff.
		/// </summary>
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x000065FC File Offset: 0x000059FC
		public unsafe string Name
		{
			get
			{
				ScriptBaseBuff* ptr = *<Module>.EnsoulSharp.Native.BuffInstance.GetScript(this.GetPtr());
				if (ptr != null)
				{
					return new string(<Module>.EnsoulSharp.Native.ScriptBase.GetScriptName(ptr));
				}
				return "unknown";
			}
		}

		/// <summary>
		/// 	Gets the caster of the buff.
		/// </summary>
		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000422 RID: 1058 RVA: 0x0000662C File Offset: 0x00005A2C
		public unsafe GameObject Caster
		{
			get
			{
				StlArray<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffScriptInstance>\u0020>* ptr = <Module>.EnsoulSharp.Native.BuffScriptInstanceStack.GetStack(<Module>.EnsoulSharp.Native.BuffInstance.GetStack(this.GetPtr()));
				StlSharedPtr<EnsoulSharp::Native::BuffScriptInstance>* ptr2 = *(int*)ptr;
				if (ptr2 != null)
				{
					BuffScriptInstance* ptr3 = *(int*)(*(int*)(ptr + 4 / sizeof(StlArray<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffScriptInstance>\u0020>)) * 8 / sizeof(StlSharedPtr<EnsoulSharp::Native::BuffScriptInstance>) + ptr2 - 8 / sizeof(StlSharedPtr<EnsoulSharp::Native::BuffScriptInstance>));
					if (ptr3 != null)
					{
						return ObjectManager.CreateObjectFromPointer(<Module>.EnsoulSharp.Native.BuffScriptInstance.GetCaster(ptr3));
					}
				}
				return null;
			}
		}

		// Token: 0x04000397 RID: 919
		private unsafe BuffInstanceClient* m_buff;
	}
}
