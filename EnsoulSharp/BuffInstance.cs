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
		// Token: 0x06000422 RID: 1058 RVA: 0x0000655C File Offset: 0x0000595C
		internal unsafe BuffInstance(BuffInstanceClient* buff)
		{
			this.m_buff = buff;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00006578 File Offset: 0x00005978
		internal unsafe BuffInstanceClient* GetPtr()
		{
			return this.m_buff;
		}

		/// <summary>
		/// 	Gets a value indicating whether the buff is valid.
		/// </summary>
		/// <remarks>We suggest you can use this property check whether the buff is valid before any other calls.</remarks>
		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x0000658C File Offset: 0x0000598C
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
		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x000065C0 File Offset: 0x000059C0
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
		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x000065D8 File Offset: 0x000059D8
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
		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x000065F0 File Offset: 0x000059F0
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
		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000428 RID: 1064 RVA: 0x0000660C File Offset: 0x00005A0C
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
		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x00006628 File Offset: 0x00005A28
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
		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x00006644 File Offset: 0x00005A44
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
		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x0000667C File Offset: 0x00005A7C
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
		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x00006694 File Offset: 0x00005A94
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
		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x000066C4 File Offset: 0x00005AC4
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
