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
		// Token: 0x06000621 RID: 1569 RVA: 0x00005C8C File Offset: 0x0000508C
		internal EffectEmitter()
		{
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x00005C74 File Offset: 0x00005074
		internal EffectEmitter(uint networkId, uint index) : base(networkId, index)
		{
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x000016D8 File Offset: 0x00000AD8
		internal new unsafe EffectEmitter* GetPtr()
		{
			return (EffectEmitter*)base.GetPtr();
		}

		/// <summary>
		/// 	Gets the orientation of the object.
		/// </summary>
		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000624 RID: 1572 RVA: 0x000095B4 File Offset: 0x000089B4
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
		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000625 RID: 1573 RVA: 0x00009634 File Offset: 0x00008A34
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
	}
}
