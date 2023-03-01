using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000315 RID: 789
	[Guid("13d29038-c3e6-4034-9081-13b53a417992")]
	public class TransformGraph : ComObject
	{
		// Token: 0x06000DFC RID: 3580 RVA: 0x00002A7F File Offset: 0x00000C7F
		public TransformGraph(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x00026991 File Offset: 0x00024B91
		public new static explicit operator TransformGraph(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TransformGraph(nativePtr);
			}
			return null;
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000DFE RID: 3582 RVA: 0x000269A8 File Offset: 0x00024BA8
		public int InputCount
		{
			get
			{
				return this.GetInputCount();
			}
		}

		// Token: 0x06000DFF RID: 3583 RVA: 0x0000B227 File Offset: 0x00009427
		internal unsafe int GetInputCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x000269B0 File Offset: 0x00024BB0
		public unsafe void SetSingleTransformNode(TransformNode node)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TransformNode>(node);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000E01 RID: 3585 RVA: 0x000269FC File Offset: 0x00024BFC
		public unsafe void AddNode(TransformNode node)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TransformNode>(node);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x00026A48 File Offset: 0x00024C48
		public unsafe void RemoveNode(TransformNode node)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TransformNode>(node);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x00026A94 File Offset: 0x00024C94
		public unsafe void SetOutputNode(TransformNode node)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TransformNode>(node);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000E04 RID: 3588 RVA: 0x00026AE0 File Offset: 0x00024CE0
		public unsafe void ConnectNode(TransformNode fromNode, TransformNode toNode, int toNodeInputIndex)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TransformNode>(fromNode);
			value2 = CppObject.ToCallbackPtr<TransformNode>(toNode);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, (void*)value2, toNodeInputIndex, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000E05 RID: 3589 RVA: 0x00026B40 File Offset: 0x00024D40
		public unsafe void ConnectToEffectInput(int toEffectInputIndex, TransformNode node, int toNodeInputIndex)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TransformNode>(node);
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, toEffectInputIndex, (void*)value, toNodeInputIndex, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000E06 RID: 3590 RVA: 0x00026B8D File Offset: 0x00024D8D
		public unsafe void Clear()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x00026BB0 File Offset: 0x00024DB0
		public unsafe void SetPassthroughGraph(int effectInputIndex)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, effectInputIndex, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
