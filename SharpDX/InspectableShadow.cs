using System;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x0200001F RID: 31
	internal class InspectableShadow : ComObjectShadow
	{
		// Token: 0x060000E2 RID: 226 RVA: 0x00003D9F File Offset: 0x00001F9F
		public static IntPtr ToIntPtr(IInspectable callback)
		{
			return CppObject.ToCallbackPtr<IInspectable>(callback);
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00003DA7 File Offset: 0x00001FA7
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return InspectableShadow.Vtbl;
			}
		}

		// Token: 0x04000033 RID: 51
		private static readonly InspectableShadow.InspectableProviderVtbl Vtbl = new InspectableShadow.InspectableProviderVtbl();

		// Token: 0x02000020 RID: 32
		public class InspectableProviderVtbl : ComObjectShadow.ComObjectVtbl
		{
			// Token: 0x060000E6 RID: 230 RVA: 0x00003DC2 File Offset: 0x00001FC2
			public InspectableProviderVtbl() : base(3)
			{
				base.AddMethod(new InspectableShadow.InspectableProviderVtbl.GetIidsDelegate(InspectableShadow.InspectableProviderVtbl.GetIids));
				base.AddMethod(new InspectableShadow.InspectableProviderVtbl.GetRuntimeClassNameDelegate(InspectableShadow.InspectableProviderVtbl.GetRuntimeClassName));
				base.AddMethod(new InspectableShadow.InspectableProviderVtbl.GetTrustLevelDelegate(InspectableShadow.InspectableProviderVtbl.GetTrustLevel));
			}

			// Token: 0x060000E7 RID: 231 RVA: 0x00003E04 File Offset: 0x00002004
			private unsafe static int GetIids(IntPtr thisPtr, int* iidCount, IntPtr* iids)
			{
				try
				{
					ShadowContainer shadowContainer = (ShadowContainer)((IInspectable)CppObjectShadow.ToShadow<InspectableShadow>(thisPtr).Callback).Shadow;
					int num = shadowContainer.Guids.Length;
					iids = (IntPtr*)((void*)Marshal.AllocCoTaskMem(IntPtr.Size * num));
					*iidCount = num;
					for (int i = 0; i < num; i++)
					{
						iids[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = shadowContainer.Guids[i];
					}
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060000E8 RID: 232 RVA: 0x00003E9C File Offset: 0x0000209C
			private static int GetRuntimeClassName(IntPtr thisPtr, IntPtr className)
			{
				try
				{
					IInspectable inspectable = (IInspectable)CppObjectShadow.ToShadow<InspectableShadow>(thisPtr).Callback;
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060000E9 RID: 233 RVA: 0x00003EE8 File Offset: 0x000020E8
			private static int GetTrustLevel(IntPtr thisPtr, IntPtr trustLevel)
			{
				try
				{
					IInspectable inspectable = (IInspectable)CppObjectShadow.ToShadow<InspectableShadow>(thisPtr).Callback;
					Marshal.WriteInt32(trustLevel, 2);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x02000021 RID: 33
			// (Invoke) Token: 0x060000EB RID: 235
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private unsafe delegate int GetIidsDelegate(IntPtr thisPtr, int* iidCount, IntPtr* iids);

			// Token: 0x02000022 RID: 34
			// (Invoke) Token: 0x060000EF RID: 239
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int GetRuntimeClassNameDelegate(IntPtr thisPtr, IntPtr className);

			// Token: 0x02000023 RID: 35
			private enum TrustLevel
			{
				// Token: 0x04000035 RID: 53
				BaseTrust,
				// Token: 0x04000036 RID: 54
				PartialTrust,
				// Token: 0x04000037 RID: 55
				FullTrust
			}

			// Token: 0x02000024 RID: 36
			// (Invoke) Token: 0x060000F3 RID: 243
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int GetTrustLevelDelegate(IntPtr thisPtr, IntPtr trustLevel);
		}
	}
}
