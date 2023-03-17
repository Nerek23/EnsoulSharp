using System;
using EnsoulSharp.Native;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each EffectEmitter object.
	/// </summary>
	// Token: 0x0200011B RID: 283
	public class EffectEmitter : GameObject
	{
		// Token: 0x0600062C RID: 1580 RVA: 0x00005D0C File Offset: 0x0000510C
		internal EffectEmitter()
		{
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x00005CF4 File Offset: 0x000050F4
		internal EffectEmitter(uint networkId, uint index) : base(networkId, index)
		{
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x000016D8 File Offset: 0x00000AD8
		internal new unsafe EffectEmitter* GetPtr()
		{
			return (EffectEmitter*)base.GetPtr();
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x0600062F RID: 1583 RVA: 0x0000964C File Offset: 0x00008A4C
		public unsafe GameObject Attachment
		{
			get
			{
				GameObjectAttachment* ptr = *<Module>.EnsoulSharp.Native.EffectEmitter.GetAttachmentPoint(this.GetPtr());
				if (ptr != null)
				{
					return ObjectManager.CreateObjectFromPointer(*(*<Module>.EnsoulSharp.Native.GameObjectAttachment.GetBindObject(ptr)));
				}
				return null;
			}
		}

		/// <summary>
		/// 	Gets the orientation of the object.
		/// </summary>
		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000630 RID: 1584 RVA: 0x00009678 File Offset: 0x00008A78
		public unsafe Matrix Orientation
		{
			get
			{
				InstanceProxy* ptr = *<Module>.EnsoulSharp.Native.EffectEmitter.GetFXParticleEmitter(this.GetPtr());
				if (ptr != null)
				{
					_D3DMATRIX* ptr2 = <Module>.EnsoulSharp.Native.InstanceProxy.GetOrientation(ptr);
					Matrix result = new Matrix(*(float*)ptr2, *(float*)(ptr2 + 4 / sizeof(_D3DMATRIX)), *(float*)(ptr2 + 8 / sizeof(_D3DMATRIX)), *(float*)(ptr2 + 12 / sizeof(_D3DMATRIX)), *(float*)(ptr2 + 16 / sizeof(_D3DMATRIX)), *(float*)(ptr2 + 20 / sizeof(_D3DMATRIX)), *(float*)(ptr2 + 24 / sizeof(_D3DMATRIX)), *(float*)(ptr2 + 28 / sizeof(_D3DMATRIX)), *(float*)(ptr2 + 32 / sizeof(_D3DMATRIX)), *(float*)(ptr2 + 36 / sizeof(_D3DMATRIX)), *(float*)(ptr2 + 40 / sizeof(_D3DMATRIX)), *(float*)(ptr2 + 44 / sizeof(_D3DMATRIX)), *(float*)(ptr2 + 48 / sizeof(_D3DMATRIX)), *(float*)(ptr2 + 52 / sizeof(_D3DMATRIX)), *(float*)(ptr2 + 56 / sizeof(_D3DMATRIX)), *(float*)(ptr2 + 60 / sizeof(_D3DMATRIX)));
					return result;
				}
				return Matrix.Zero;
			}
		}

		/// <summary>
		/// 	Gets the restart time of the object.
		/// </summary>
		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000631 RID: 1585 RVA: 0x000096F8 File Offset: 0x00008AF8
		public unsafe float RestartTime
		{
			get
			{
				InstanceProxy* ptr = *<Module>.EnsoulSharp.Native.EffectEmitter.GetFXParticleEmitter(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.InstanceProxy.GetRestartTime(ptr);
				}
				return 0f;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000632 RID: 1586 RVA: 0x00009724 File Offset: 0x00008B24
		public unsafe GameObject TargetAttachment
		{
			get
			{
				GameObjectAttachment* ptr = *<Module>.EnsoulSharp.Native.EffectEmitter.GetTargetAttachmentPoint(this.GetPtr());
				if (ptr != null)
				{
					return ObjectManager.CreateObjectFromPointer(*(*<Module>.EnsoulSharp.Native.GameObjectAttachment.GetBindObject(ptr)));
				}
				return null;
			}
		}
	}
}
