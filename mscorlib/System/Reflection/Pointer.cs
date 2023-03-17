using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Reflection
{
	/// <summary>Provides a wrapper class for pointers.</summary>
	// Token: 0x020005EC RID: 1516
	[CLSCompliant(false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class Pointer : ISerializable
	{
		// Token: 0x0600472D RID: 18221 RVA: 0x00102249 File Offset: 0x00100449
		private Pointer()
		{
		}

		// Token: 0x0600472E RID: 18222 RVA: 0x00102254 File Offset: 0x00100454
		[SecurityCritical]
		private Pointer(SerializationInfo info, StreamingContext context)
		{
			this._ptr = ((IntPtr)info.GetValue("_ptr", typeof(IntPtr))).ToPointer();
			this._ptrType = (RuntimeType)info.GetValue("_ptrType", typeof(RuntimeType));
		}

		/// <summary>Boxes the supplied unmanaged memory pointer and the type associated with that pointer into a managed <see cref="T:System.Reflection.Pointer" /> wrapper object. The value and the type are saved so they can be accessed from the native code during an invocation.</summary>
		/// <param name="ptr">The supplied unmanaged memory pointer.</param>
		/// <param name="type">The type associated with the <paramref name="ptr" /> parameter.</param>
		/// <returns>A pointer object.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="type" /> is not a pointer.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="type" /> is <see langword="null" />.</exception>
		// Token: 0x0600472F RID: 18223 RVA: 0x001022B0 File Offset: 0x001004B0
		[SecurityCritical]
		public unsafe static object Box(void* ptr, Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (!type.IsPointer)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBePointer"), "ptr");
			}
			RuntimeType runtimeType = type as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBePointer"), "ptr");
			}
			return new Pointer
			{
				_ptr = ptr,
				_ptrType = runtimeType
			};
		}

		/// <summary>Returns the stored pointer.</summary>
		/// <param name="ptr">The stored pointer.</param>
		/// <returns>This method returns void.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="ptr" /> is not a pointer.</exception>
		// Token: 0x06004730 RID: 18224 RVA: 0x00102328 File Offset: 0x00100528
		[SecurityCritical]
		public unsafe static void* Unbox(object ptr)
		{
			if (!(ptr is Pointer))
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBePointer"), "ptr");
			}
			return ((Pointer)ptr)._ptr;
		}

		// Token: 0x06004731 RID: 18225 RVA: 0x00102352 File Offset: 0x00100552
		internal RuntimeType GetPointerType()
		{
			return this._ptrType;
		}

		// Token: 0x06004732 RID: 18226 RVA: 0x0010235A File Offset: 0x0010055A
		[SecurityCritical]
		internal object GetPointerValue()
		{
			return (IntPtr)this._ptr;
		}

		/// <summary>Sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> object with the file name, fusion log, and additional exception information.</summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		// Token: 0x06004733 RID: 18227 RVA: 0x0010236C File Offset: 0x0010056C
		[SecurityCritical]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_ptr", new IntPtr(this._ptr));
			info.AddValue("_ptrType", this._ptrType);
		}

		// Token: 0x04001D45 RID: 7493
		[SecurityCritical]
		private unsafe void* _ptr;

		// Token: 0x04001D46 RID: 7494
		private RuntimeType _ptrType;
	}
}
