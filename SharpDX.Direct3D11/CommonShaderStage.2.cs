using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200001A RID: 26
	public abstract class CommonShaderStage<T> : CommonShaderStage where T : DeviceChild
	{
		// Token: 0x060000FC RID: 252 RVA: 0x000056E6 File Offset: 0x000038E6
		protected CommonShaderStage(IntPtr pointer) : base(pointer)
		{
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000056F0 File Offset: 0x000038F0
		public T Get()
		{
			int num = 0;
			T result;
			this.GetShader(out result, null, ref num);
			return result;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000570C File Offset: 0x0000390C
		public T Get(ClassInstance[] classInstances)
		{
			int num = classInstances.Length;
			T result;
			this.GetShader(out result, classInstances, ref num);
			return result;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00005729 File Offset: 0x00003929
		public void Set(T shader)
		{
			this.SetShader(shader, null, 0);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00005734 File Offset: 0x00003934
		public void Set(T shader, ClassInstance[] classInstances)
		{
			this.SetShader(shader, classInstances, (classInstances == null) ? 0 : classInstances.Length);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00005747 File Offset: 0x00003947
		public void Set(T shader, ComArray<ClassInstance> classInstances)
		{
			this.SetShader(shader, classInstances, (classInstances == null) ? 0 : classInstances.Length);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000575D File Offset: 0x0000395D
		public override void SetShader(DeviceChild shader, ClassInstance[] classInstancesOut, int numClassInstances)
		{
			this.SetShader((T)((object)shader), classInstancesOut, numClassInstances);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000576D File Offset: 0x0000396D
		internal override void SetUnorderedAccessViews(int startSlot, int numBuffers, IntPtr unorderedAccessBuffer, IntPtr uavCount)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000104 RID: 260
		internal abstract void SetShader(T shaderRef, ClassInstance[] classInstancesRef, int numClassInstances);

		// Token: 0x06000105 RID: 261
		internal abstract void SetShader(T shaderRef, ComArray<ClassInstance> classInstancesRef, int numClassInstances);

		// Token: 0x06000106 RID: 262
		internal abstract void GetShader(out T pixelShaderRef, ClassInstance[] classInstancesRef, ref int numClassInstancesRef);
	}
}
