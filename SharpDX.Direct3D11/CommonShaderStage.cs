using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000019 RID: 25
	public abstract class CommonShaderStage : CppObject
	{
		// Token: 0x060000E1 RID: 225 RVA: 0x0000543D File Offset: 0x0000363D
		protected CommonShaderStage(IntPtr pointer) : base(pointer)
		{
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00005448 File Offset: 0x00003648
		public Buffer[] GetConstantBuffers(int startSlot, int count)
		{
			Buffer[] array = new Buffer[count];
			this.GetConstantBuffers(startSlot, count, array);
			return array;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00005468 File Offset: 0x00003668
		public SamplerState[] GetSamplers(int startSlot, int count)
		{
			SamplerState[] array = new SamplerState[count];
			this.GetSamplers(startSlot, count, array);
			return array;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00005488 File Offset: 0x00003688
		public ShaderResourceView[] GetShaderResources(int startSlot, int count)
		{
			ShaderResourceView[] array = new ShaderResourceView[count];
			this.GetShaderResources(startSlot, count, array);
			return array;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000054A8 File Offset: 0x000036A8
		public unsafe void SetConstantBuffer(int slot, Buffer constantBuffer)
		{
			IntPtr intPtr = (constantBuffer == null) ? IntPtr.Zero : constantBuffer.NativePointer;
			this.SetConstantBuffers(slot, 1, new IntPtr((void*)(&intPtr)));
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000054D6 File Offset: 0x000036D6
		public void SetConstantBuffers(int slot, params Buffer[] constantBuffers)
		{
			this.SetConstantBuffers(slot, (constantBuffers == null) ? 0 : constantBuffers.Length, constantBuffers);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000054E9 File Offset: 0x000036E9
		public void SetConstantBuffers(int slot, ComArray<Buffer> constantBuffers)
		{
			this.SetConstantBuffers(slot, (constantBuffers == null) ? 0 : constantBuffers.Length, constantBuffers);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00005500 File Offset: 0x00003700
		public unsafe void SetSampler(int slot, SamplerState sampler)
		{
			IntPtr intPtr = (sampler == null) ? IntPtr.Zero : sampler.NativePointer;
			this.SetSamplers(slot, 1, new IntPtr((void*)(&intPtr)));
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000552E File Offset: 0x0000372E
		public void SetSamplers(int slot, params SamplerState[] samplers)
		{
			this.SetSamplers(slot, (samplers == null) ? 0 : samplers.Length, samplers);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00005541 File Offset: 0x00003741
		public void SetSamplers(int slot, ComArray<SamplerState> samplers)
		{
			this.SetSamplers(slot, (samplers == null) ? 0 : samplers.Length, samplers);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00005558 File Offset: 0x00003758
		public unsafe void SetShaderResource(int slot, ShaderResourceView resourceView)
		{
			IntPtr intPtr = (resourceView == null) ? IntPtr.Zero : resourceView.NativePointer;
			this.SetShaderResources(slot, 1, new IntPtr((void*)(&intPtr)));
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00005586 File Offset: 0x00003786
		public void SetShaderResources(int startSlot, params ShaderResourceView[] shaderResourceViews)
		{
			this.SetShaderResources(startSlot, shaderResourceViews.Length, shaderResourceViews);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00005593 File Offset: 0x00003793
		public void SetShaderResources(int startSlot, ComArray<ShaderResourceView> shaderResourceViews)
		{
			this.SetShaderResources(startSlot, shaderResourceViews.Length, shaderResourceViews);
		}

		// Token: 0x060000EE RID: 238
		internal abstract void GetShaderResources(int startSlot, int numViews, ShaderResourceView[] shaderResourceViewsRef);

		// Token: 0x060000EF RID: 239
		internal abstract void GetSamplers(int startSlot, int numSamplers, SamplerState[] samplersRef);

		// Token: 0x060000F0 RID: 240
		internal abstract void GetConstantBuffers(int startSlot, int numBuffers, Buffer[] constantBuffersRef);

		// Token: 0x060000F1 RID: 241 RVA: 0x000055A4 File Offset: 0x000037A4
		public unsafe void SetShaderResources(int startSlot, int numViews, params ShaderResourceView[] shaderResourceViews)
		{
			IntPtr* ptr = null;
			if (numViews > 0)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)numViews) * (UIntPtr)sizeof(IntPtr))];
				for (int i = 0; i < numViews; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = ((shaderResourceViews[i] == null) ? IntPtr.Zero : shaderResourceViews[i].NativePointer);
				}
			}
			this.SetShaderResources(startSlot, numViews, (IntPtr)((void*)ptr));
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000055FE File Offset: 0x000037FE
		public void SetShaderResources(int startSlot, int numViews, ComArray<ShaderResourceView> shaderResourceViewsRef)
		{
			this.SetShaderResources(startSlot, numViews, shaderResourceViewsRef.NativePointer);
		}

		// Token: 0x060000F3 RID: 243
		internal abstract void SetShaderResources(int startSlot, int numViews, IntPtr shaderResourceViewsRef);

		// Token: 0x060000F4 RID: 244 RVA: 0x00005610 File Offset: 0x00003810
		public unsafe void SetSamplers(int startSlot, int numSamplers, params SamplerState[] samplers)
		{
			IntPtr* ptr = null;
			if (numSamplers > 0)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)numSamplers) * (UIntPtr)sizeof(IntPtr))];
				for (int i = 0; i < numSamplers; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = ((samplers[i] == null) ? IntPtr.Zero : samplers[i].NativePointer);
				}
			}
			this.SetSamplers(startSlot, numSamplers, (IntPtr)((void*)ptr));
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000566A File Offset: 0x0000386A
		public void SetSamplers(int startSlot, int numSamplers, ComArray<SamplerState> samplers)
		{
			this.SetSamplers(startSlot, numSamplers, samplers.NativePointer);
		}

		// Token: 0x060000F6 RID: 246
		internal abstract void SetSamplers(int startSlot, int numSamplers, IntPtr samplersRef);

		// Token: 0x060000F7 RID: 247 RVA: 0x0000567C File Offset: 0x0000387C
		public unsafe void SetConstantBuffers(int startSlot, int numBuffers, params Buffer[] constantBuffers)
		{
			IntPtr* ptr = null;
			if (numBuffers > 0)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)numBuffers) * (UIntPtr)sizeof(IntPtr))];
				for (int i = 0; i < numBuffers; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = ((constantBuffers[i] == null) ? IntPtr.Zero : constantBuffers[i].NativePointer);
				}
			}
			this.SetConstantBuffers(startSlot, numBuffers, (IntPtr)((void*)ptr));
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000056D6 File Offset: 0x000038D6
		public void SetConstantBuffers(int startSlot, int numBuffers, ComArray<Buffer> constantBuffers)
		{
			this.SetConstantBuffers(startSlot, numBuffers, constantBuffers.NativePointer);
		}

		// Token: 0x060000F9 RID: 249
		internal abstract void SetConstantBuffers(int startSlot, int numBuffers, IntPtr constantBuffersRef);

		// Token: 0x060000FA RID: 250
		public abstract void SetShader(DeviceChild shader, ClassInstance[] classInstancesOut, int numClassInstances);

		// Token: 0x060000FB RID: 251
		internal abstract void SetUnorderedAccessViews(int startSlot, int numBuffers, IntPtr unorderedAccessBuffer, IntPtr uavCount);

		// Token: 0x04000034 RID: 52
		public const int ConstantBufferApiSlotCount = 14;

		// Token: 0x04000035 RID: 53
		public const int ConstantBufferComponents = 4;

		// Token: 0x04000036 RID: 54
		public const int ConstantBufferComponentBitCount = 32;

		// Token: 0x04000037 RID: 55
		public const int ConstantBufferHwSlotCount = 15;

		// Token: 0x04000038 RID: 56
		public const int ConstantBufferPartialUpdateExtentsByteAlignment = 16;

		// Token: 0x04000039 RID: 57
		public const int ConstantBufferRegisterComponents = 4;

		// Token: 0x0400003A RID: 58
		public const int ConstantBufferRegisterCount = 15;

		// Token: 0x0400003B RID: 59
		public const int ConstantBufferRegisterReadsPerInst = 1;

		// Token: 0x0400003C RID: 60
		public const int ConstantBufferRegisterReadPorts = 1;

		// Token: 0x0400003D RID: 61
		public const int FlowcontrolNestingLimit = 64;

		// Token: 0x0400003E RID: 62
		public const int ImmediateConstantBufferRegisterComponents = 4;

		// Token: 0x0400003F RID: 63
		public const int ImmediateConstantBufferRegisterCount = 1;

		// Token: 0x04000040 RID: 64
		public const int ImmediateConstantBufferRegisterReadsPerInst = 1;

		// Token: 0x04000041 RID: 65
		public const int ImmediateConstantBufferRegisterReadPorts = 1;

		// Token: 0x04000042 RID: 66
		public const int ImmediateValueComponentBitCount = 32;

		// Token: 0x04000043 RID: 67
		public const int InputResourceRegisterComponents = 1;

		// Token: 0x04000044 RID: 68
		public const int InputResourceRegisterCount = 128;

		// Token: 0x04000045 RID: 69
		public const int InputResourceRegisterReadsPerInst = 1;

		// Token: 0x04000046 RID: 70
		public const int InputResourceRegisterReadPorts = 1;

		// Token: 0x04000047 RID: 71
		public const int InputResourceSlotCount = 128;

		// Token: 0x04000048 RID: 72
		public const int SamplerRegisterComponents = 1;

		// Token: 0x04000049 RID: 73
		public const int SamplerRegisterCount = 16;

		// Token: 0x0400004A RID: 74
		public const int SamplerRegisterReadsPerInst = 1;

		// Token: 0x0400004B RID: 75
		public const int SamplerRegisterReadPorts = 1;

		// Token: 0x0400004C RID: 76
		public const int SamplerSlotCount = 16;

		// Token: 0x0400004D RID: 77
		public const int SubRoutineNestingLimit = 32;

		// Token: 0x0400004E RID: 78
		public const int TempRegisterComponents = 4;

		// Token: 0x0400004F RID: 79
		public const int TempRegisterComponentBitCount = 32;

		// Token: 0x04000050 RID: 80
		public const int TempRegisterCount = 4096;

		// Token: 0x04000051 RID: 81
		public const int TempRegisterReadsPerInst = 3;

		// Token: 0x04000052 RID: 82
		public const int TempRegisterReadPorts = 3;

		// Token: 0x04000053 RID: 83
		public const int TextureCoordRangeReductionMaximum = 10;

		// Token: 0x04000054 RID: 84
		public const int TextureCoordRangeReductionMinimum = -10;

		// Token: 0x04000055 RID: 85
		public const int TextureElOffsetMaximumNegative = -8;

		// Token: 0x04000056 RID: 86
		public const int TextureElOffsetMaximumPositive = 7;
	}
}
