using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Threading;
using Microsoft.Win32;

namespace System.Runtime.InteropServices
{
	/// <summary>Provides a collection of methods for allocating unmanaged memory, copying unmanaged memory blocks, and converting managed to unmanaged types, as well as other miscellaneous methods used when interacting with unmanaged code.</summary>
	// Token: 0x02000923 RID: 2339
	[__DynamicallyInvokable]
	public static class Marshal
	{
		// Token: 0x06005FA5 RID: 24485 RVA: 0x00147FC0 File Offset: 0x001461C0
		private static bool IsWin32Atom(IntPtr ptr)
		{
			long num = (long)ptr;
			return (num & -65536L) == 0L;
		}

		// Token: 0x06005FA6 RID: 24486 RVA: 0x00147FE0 File Offset: 0x001461E0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		private static bool IsNotWin32Atom(IntPtr ptr)
		{
			long num = (long)ptr;
			return (num & -65536L) != 0L;
		}

		// Token: 0x06005FA7 RID: 24487
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetSystemMaxDBCSCharSize();

		/// <summary>Copies all characters up to the first null character from an unmanaged ANSI string to a managed <see cref="T:System.String" />, and widens each ANSI character to Unicode.</summary>
		/// <param name="ptr">The address of the first character of the unmanaged string.</param>
		/// <returns>A managed string that holds a copy of the unmanaged ANSI string. If <paramref name="ptr" /> is <see langword="null" />, the method returns a null string.</returns>
		// Token: 0x06005FA8 RID: 24488 RVA: 0x00148000 File Offset: 0x00146200
		[SecurityCritical]
		public unsafe static string PtrToStringAnsi(IntPtr ptr)
		{
			if (IntPtr.Zero == ptr)
			{
				return null;
			}
			if (Marshal.IsWin32Atom(ptr))
			{
				return null;
			}
			if (Win32Native.lstrlenA(ptr) == 0)
			{
				return string.Empty;
			}
			return new string((sbyte*)((void*)ptr));
		}

		/// <summary>Allocates a managed <see cref="T:System.String" />, copies a specified number of characters from an unmanaged ANSI string into it, and widens each ANSI character to Unicode.</summary>
		/// <param name="ptr">The address of the first character of the unmanaged string.</param>
		/// <param name="len">The byte count of the input string to copy.</param>
		/// <returns>A managed string that holds a copy of the native ANSI string if the value of the <paramref name="ptr" /> parameter is not <see langword="null" />; otherwise, this method returns <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="len" /> is less than zero.</exception>
		// Token: 0x06005FA9 RID: 24489 RVA: 0x00148041 File Offset: 0x00146241
		[SecurityCritical]
		public unsafe static string PtrToStringAnsi(IntPtr ptr, int len)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new ArgumentNullException("ptr");
			}
			if (len < 0)
			{
				throw new ArgumentException("len");
			}
			return new string((sbyte*)((void*)ptr), 0, len);
		}

		/// <summary>Allocates a managed <see cref="T:System.String" /> and copies a specified number of characters from an unmanaged Unicode string into it.</summary>
		/// <param name="ptr">The address of the first character of the unmanaged string.</param>
		/// <param name="len">The number of Unicode characters to copy.</param>
		/// <returns>A managed string that holds a copy of the unmanaged string if the value of the <paramref name="ptr" /> parameter is not <see langword="null" />; otherwise, this method returns <see langword="null" />.</returns>
		// Token: 0x06005FAA RID: 24490 RVA: 0x00148077 File Offset: 0x00146277
		[SecurityCritical]
		public unsafe static string PtrToStringUni(IntPtr ptr, int len)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new ArgumentNullException("ptr");
			}
			if (len < 0)
			{
				throw new ArgumentException("len");
			}
			return new string((char*)((void*)ptr), 0, len);
		}

		/// <summary>Allocates a managed <see cref="T:System.String" /> and copies the specified number of characters from a string stored in unmanaged memory into it.</summary>
		/// <param name="ptr">For Unicode platforms, the address of the first Unicode character.  
		///  -or-  
		///  For ANSI plaforms, the address of the first ANSI character.</param>
		/// <param name="len">The number of characters to copy.</param>
		/// <returns>A managed string that holds a copy of the native string if the value of the <paramref name="ptr" /> parameter is not <see langword="null" />; otherwise, this method returns <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="len" /> is less than zero.</exception>
		// Token: 0x06005FAB RID: 24491 RVA: 0x001480AD File Offset: 0x001462AD
		[SecurityCritical]
		public static string PtrToStringAuto(IntPtr ptr, int len)
		{
			return Marshal.PtrToStringUni(ptr, len);
		}

		/// <summary>Allocates a managed <see cref="T:System.String" /> and copies all characters up to the first null character from an unmanaged Unicode string into it.</summary>
		/// <param name="ptr">The address of the first character of the unmanaged string.</param>
		/// <returns>A managed string that holds a copy of the unmanaged string if the value of the <paramref name="ptr" /> parameter is not <see langword="null" />; otherwise, this method returns <see langword="null" />.</returns>
		// Token: 0x06005FAC RID: 24492 RVA: 0x001480B6 File Offset: 0x001462B6
		[SecurityCritical]
		public unsafe static string PtrToStringUni(IntPtr ptr)
		{
			if (IntPtr.Zero == ptr)
			{
				return null;
			}
			if (Marshal.IsWin32Atom(ptr))
			{
				return null;
			}
			return new string((char*)((void*)ptr));
		}

		/// <summary>Allocates a managed <see cref="T:System.String" /> and copies all characters up to the first null character from a string stored in unmanaged memory into it.</summary>
		/// <param name="ptr">For Unicode platforms, the address of the first Unicode character.  
		///  -or-  
		///  For ANSI plaforms, the address of the first ANSI character.</param>
		/// <returns>A managed string that holds a copy of the unmanaged string if the value of the <paramref name="ptr" /> parameter is not <see langword="null" />; otherwise, this method returns <see langword="null" />.</returns>
		// Token: 0x06005FAD RID: 24493 RVA: 0x001480DC File Offset: 0x001462DC
		[SecurityCritical]
		public static string PtrToStringAuto(IntPtr ptr)
		{
			return Marshal.PtrToStringUni(ptr);
		}

		/// <summary>Returns the unmanaged size of an object in bytes.</summary>
		/// <param name="structure">The object whose size is to be returned.</param>
		/// <returns>The size of the specified object in unmanaged code.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="structure" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06005FAE RID: 24494 RVA: 0x001480E4 File Offset: 0x001462E4
		[ComVisible(true)]
		public static int SizeOf(object structure)
		{
			if (structure == null)
			{
				throw new ArgumentNullException("structure");
			}
			return Marshal.SizeOfHelper(structure.GetType(), true);
		}

		/// <summary>[Supported in the .NET Framework 4.5.1 and later versions]  
		///  Returns the unmanaged size of an object of a specified type in bytes.</summary>
		/// <param name="structure">The object whose size is to be returned.</param>
		/// <typeparam name="T">The type of the <paramref name="structure" /> parameter.</typeparam>
		/// <returns>The size, in bytes, of the specified object in unmanaged code.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="structure" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06005FAF RID: 24495 RVA: 0x00148100 File Offset: 0x00146300
		public static int SizeOf<T>(T structure)
		{
			return Marshal.SizeOf(structure);
		}

		/// <summary>Returns the size of an unmanaged type in bytes.</summary>
		/// <param name="t">The type whose size is to be returned.</param>
		/// <returns>The size of the specified type in unmanaged code.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="t" /> parameter is a generic type definition.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="t" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06005FB0 RID: 24496 RVA: 0x00148110 File Offset: 0x00146310
		public static int SizeOf(Type t)
		{
			if (t == null)
			{
				throw new ArgumentNullException("t");
			}
			if (!(t is RuntimeType))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"), "t");
			}
			if (t.IsGenericType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "t");
			}
			return Marshal.SizeOfHelper(t, true);
		}

		/// <summary>[Supported in the .NET Framework 4.5.1 and later versions]  
		///  Returns the size of an unmanaged type in bytes.</summary>
		/// <typeparam name="T">The type whose size is to be returned.</typeparam>
		/// <returns>The size, in bytes, of the type that is specified by the <typeparamref name="T" /> generic type parameter.</returns>
		// Token: 0x06005FB1 RID: 24497 RVA: 0x00148172 File Offset: 0x00146372
		public static int SizeOf<T>()
		{
			return Marshal.SizeOf(typeof(T));
		}

		// Token: 0x06005FB2 RID: 24498 RVA: 0x00148184 File Offset: 0x00146384
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		internal static uint AlignedSizeOf<T>() where T : struct
		{
			uint num = Marshal.SizeOfType(typeof(T));
			if (num == 1U || num == 2U)
			{
				return num;
			}
			if (IntPtr.Size == 8 && num == 4U)
			{
				return num;
			}
			return Marshal.AlignedSizeOfType(typeof(T));
		}

		// Token: 0x06005FB3 RID: 24499
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern uint SizeOfType(Type type);

		// Token: 0x06005FB4 RID: 24500
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint AlignedSizeOfType(Type type);

		// Token: 0x06005FB5 RID: 24501
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int SizeOfHelper(Type t, bool throwIfNotMarshalable);

		/// <summary>Returns the field offset of the unmanaged form of the managed class.</summary>
		/// <param name="t">A value type or formatted reference type that specifies the managed class. You must apply the <see cref="T:System.Runtime.InteropServices.StructLayoutAttribute" /> to the class.</param>
		/// <param name="fieldName">The field within the <paramref name="t" /> parameter.</param>
		/// <returns>The offset, in bytes, for the <paramref name="fieldName" /> parameter within the specified class that is declared by platform invoke.</returns>
		/// <exception cref="T:System.ArgumentException">The class cannot be exported as a structure or the field is nonpublic. Beginning with the .NET Framework version 2.0, the field may be private.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="t" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06005FB6 RID: 24502 RVA: 0x001481C8 File Offset: 0x001463C8
		public static IntPtr OffsetOf(Type t, string fieldName)
		{
			if (t == null)
			{
				throw new ArgumentNullException("t");
			}
			FieldInfo field = t.GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_OffsetOfFieldNotFound", new object[]
				{
					t.FullName
				}), "fieldName");
			}
			RtFieldInfo rtFieldInfo = field as RtFieldInfo;
			if (rtFieldInfo == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeFieldInfo"), "fieldName");
			}
			return Marshal.OffsetOfHelper(rtFieldInfo);
		}

		/// <summary>[Supported in the .NET Framework 4.5.1 and later versions]  
		///  Returns the field offset of the unmanaged form of a specified managed class.</summary>
		/// <param name="fieldName">The name of the field in the <paramref name="T" /> type.</param>
		/// <typeparam name="T">A managed value type or formatted reference type. You must apply the <see cref="T:System.Runtime.InteropServices.StructLayoutAttribute" /> attribute to the class.</typeparam>
		/// <returns>The offset, in bytes, for the <paramref name="fieldName" /> parameter within the specified class that is declared by platform invoke.</returns>
		// Token: 0x06005FB7 RID: 24503 RVA: 0x0014824B File Offset: 0x0014644B
		public static IntPtr OffsetOf<T>(string fieldName)
		{
			return Marshal.OffsetOf(typeof(T), fieldName);
		}

		// Token: 0x06005FB8 RID: 24504
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr OffsetOfHelper(IRuntimeFieldInfo f);

		/// <summary>Gets the address of the element at the specified index inside the specified array.</summary>
		/// <param name="arr">The array that contains the desired element.</param>
		/// <param name="index">The index in the <paramref name="arr" /> parameter of the desired element.</param>
		/// <returns>The address of <paramref name="index" /> inside <paramref name="arr" />.</returns>
		// Token: 0x06005FB9 RID: 24505
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr UnsafeAddrOfPinnedArrayElement(Array arr, int index);

		/// <summary>[Supported in the .NET Framework 4.5.1 and later versions]  
		///  Gets the address of the element at the specified index in an array of a specified type.</summary>
		/// <param name="arr">The array that contains the desired element.</param>
		/// <param name="index">The index of the desired element in the <paramref name="arr" /> array.</param>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <returns>The address of <paramref name="index" /> in <paramref name="arr" />.</returns>
		// Token: 0x06005FBA RID: 24506 RVA: 0x0014825D File Offset: 0x0014645D
		[SecurityCritical]
		public static IntPtr UnsafeAddrOfPinnedArrayElement<T>(T[] arr, int index)
		{
			return Marshal.UnsafeAddrOfPinnedArrayElement(arr, index);
		}

		/// <summary>Copies data from a one-dimensional, managed 32-bit signed integer array to an unmanaged memory pointer.</summary>
		/// <param name="source">The one-dimensional array to copy from.</param>
		/// <param name="startIndex">The zero-based index in the source array where copying should start.</param>
		/// <param name="destination">The memory pointer to copy to.</param>
		/// <param name="length">The number of array elements to copy.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> and <paramref name="length" /> are not valid.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="startIndex" /> or <paramref name="length" /> is <see langword="null" />.</exception>
		// Token: 0x06005FBB RID: 24507 RVA: 0x00148266 File Offset: 0x00146466
		[SecurityCritical]
		public static void Copy(int[] source, int startIndex, IntPtr destination, int length)
		{
			Marshal.CopyToNative(source, startIndex, destination, length);
		}

		/// <summary>Copies data from a one-dimensional, managed character array to an unmanaged memory pointer.</summary>
		/// <param name="source">The one-dimensional array to copy from.</param>
		/// <param name="startIndex">The zero-based index in the source array where copying should start.</param>
		/// <param name="destination">The memory pointer to copy to.</param>
		/// <param name="length">The number of array elements to copy.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> and <paramref name="length" /> are not valid.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="startIndex" />, <paramref name="destination" />, or <paramref name="length" /> is <see langword="null" />.</exception>
		// Token: 0x06005FBC RID: 24508 RVA: 0x00148271 File Offset: 0x00146471
		[SecurityCritical]
		public static void Copy(char[] source, int startIndex, IntPtr destination, int length)
		{
			Marshal.CopyToNative(source, startIndex, destination, length);
		}

		/// <summary>Copies data from a one-dimensional, managed 16-bit signed integer array to an unmanaged memory pointer.</summary>
		/// <param name="source">The one-dimensional array to copy from.</param>
		/// <param name="startIndex">The zero-based index in the source array where copying should start.</param>
		/// <param name="destination">The memory pointer to copy to.</param>
		/// <param name="length">The number of array elements to copy.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> and <paramref name="length" /> are not valid.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="source" />, <paramref name="startIndex" />, <paramref name="destination" />, or <paramref name="length" /> is <see langword="null" />.</exception>
		// Token: 0x06005FBD RID: 24509 RVA: 0x0014827C File Offset: 0x0014647C
		[SecurityCritical]
		public static void Copy(short[] source, int startIndex, IntPtr destination, int length)
		{
			Marshal.CopyToNative(source, startIndex, destination, length);
		}

		/// <summary>Copies data from a one-dimensional, managed 64-bit signed integer array to an unmanaged memory pointer.</summary>
		/// <param name="source">The one-dimensional array to copy from.</param>
		/// <param name="startIndex">The zero-based index in the source array where copying should start.</param>
		/// <param name="destination">The memory pointer to copy to.</param>
		/// <param name="length">The number of array elements to copy.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> and <paramref name="length" /> are not valid.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="source" />, <paramref name="startIndex" />, <paramref name="destination" />, or <paramref name="length" /> is <see langword="null" />.</exception>
		// Token: 0x06005FBE RID: 24510 RVA: 0x00148287 File Offset: 0x00146487
		[SecurityCritical]
		public static void Copy(long[] source, int startIndex, IntPtr destination, int length)
		{
			Marshal.CopyToNative(source, startIndex, destination, length);
		}

		/// <summary>Copies data from a one-dimensional, managed single-precision floating-point number array to an unmanaged memory pointer.</summary>
		/// <param name="source">The one-dimensional array to copy from.</param>
		/// <param name="startIndex">The zero-based index in the source array where copying should start.</param>
		/// <param name="destination">The memory pointer to copy to.</param>
		/// <param name="length">The number of array elements to copy.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> and <paramref name="length" /> are not valid.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="source" />, <paramref name="startIndex" />, <paramref name="destination" />, or <paramref name="length" /> is <see langword="null" />.</exception>
		// Token: 0x06005FBF RID: 24511 RVA: 0x00148292 File Offset: 0x00146492
		[SecurityCritical]
		public static void Copy(float[] source, int startIndex, IntPtr destination, int length)
		{
			Marshal.CopyToNative(source, startIndex, destination, length);
		}

		/// <summary>Copies data from a one-dimensional, managed double-precision floating-point number array to an unmanaged memory pointer.</summary>
		/// <param name="source">The one-dimensional array to copy from.</param>
		/// <param name="startIndex">The zero-based index in the source array where copying should start.</param>
		/// <param name="destination">The memory pointer to copy to.</param>
		/// <param name="length">The number of array elements to copy.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> and <paramref name="length" /> are not valid.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="source" />, <paramref name="startIndex" />, <paramref name="destination" />, or <paramref name="length" /> is <see langword="null" />.</exception>
		// Token: 0x06005FC0 RID: 24512 RVA: 0x0014829D File Offset: 0x0014649D
		[SecurityCritical]
		public static void Copy(double[] source, int startIndex, IntPtr destination, int length)
		{
			Marshal.CopyToNative(source, startIndex, destination, length);
		}

		/// <summary>Copies data from a one-dimensional, managed 8-bit unsigned integer array to an unmanaged memory pointer.</summary>
		/// <param name="source">The one-dimensional array to copy from.</param>
		/// <param name="startIndex">The zero-based index in the source array where copying should start.</param>
		/// <param name="destination">The memory pointer to copy to.</param>
		/// <param name="length">The number of array elements to copy.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> and <paramref name="length" /> are not valid.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="source" />, <paramref name="startIndex" />, <paramref name="destination" />, or <paramref name="length" /> is <see langword="null" />.</exception>
		// Token: 0x06005FC1 RID: 24513 RVA: 0x001482A8 File Offset: 0x001464A8
		[SecurityCritical]
		public static void Copy(byte[] source, int startIndex, IntPtr destination, int length)
		{
			Marshal.CopyToNative(source, startIndex, destination, length);
		}

		/// <summary>Copies data from a one-dimensional, managed <see cref="T:System.IntPtr" /> array to an unmanaged memory pointer.</summary>
		/// <param name="source">The one-dimensional array to copy from.</param>
		/// <param name="startIndex">The zero-based index in the source array where copying should start.</param>
		/// <param name="destination">The memory pointer to copy to.</param>
		/// <param name="length">The number of array elements to copy.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="source" />, <paramref name="destination" />, <paramref name="startIndex" />, or <paramref name="length" /> is <see langword="null" />.</exception>
		// Token: 0x06005FC2 RID: 24514 RVA: 0x001482B3 File Offset: 0x001464B3
		[SecurityCritical]
		public static void Copy(IntPtr[] source, int startIndex, IntPtr destination, int length)
		{
			Marshal.CopyToNative(source, startIndex, destination, length);
		}

		// Token: 0x06005FC3 RID: 24515
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CopyToNative(object source, int startIndex, IntPtr destination, int length);

		/// <summary>Copies data from an unmanaged memory pointer to a managed 32-bit signed integer array.</summary>
		/// <param name="source">The memory pointer to copy from.</param>
		/// <param name="destination">The array to copy to.</param>
		/// <param name="startIndex">The zero-based index in the destination array where copying should start.</param>
		/// <param name="length">The number of array elements to copy.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="source" />, <paramref name="destination" />, <paramref name="startIndex" />, or <paramref name="length" /> is <see langword="null" />.</exception>
		// Token: 0x06005FC4 RID: 24516 RVA: 0x001482BE File Offset: 0x001464BE
		[SecurityCritical]
		public static void Copy(IntPtr source, int[] destination, int startIndex, int length)
		{
			Marshal.CopyToManaged(source, destination, startIndex, length);
		}

		/// <summary>Copies data from an unmanaged memory pointer to a managed character array.</summary>
		/// <param name="source">The memory pointer to copy from.</param>
		/// <param name="destination">The array to copy to.</param>
		/// <param name="startIndex">The zero-based index in the destination array where copying should start.</param>
		/// <param name="length">The number of array elements to copy.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="source" />, <paramref name="destination" />, <paramref name="startIndex" />, or <paramref name="length" /> is <see langword="null" />.</exception>
		// Token: 0x06005FC5 RID: 24517 RVA: 0x001482C9 File Offset: 0x001464C9
		[SecurityCritical]
		public static void Copy(IntPtr source, char[] destination, int startIndex, int length)
		{
			Marshal.CopyToManaged(source, destination, startIndex, length);
		}

		/// <summary>Copies data from an unmanaged memory pointer to a managed 16-bit signed integer array.</summary>
		/// <param name="source">The memory pointer to copy from.</param>
		/// <param name="destination">The array to copy to.</param>
		/// <param name="startIndex">The zero-based index in the destination array where copying should start.</param>
		/// <param name="length">The number of array elements to copy.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="source" />, <paramref name="destination" />, <paramref name="startIndex" />, or <paramref name="length" /> is <see langword="null" />.</exception>
		// Token: 0x06005FC6 RID: 24518 RVA: 0x001482D4 File Offset: 0x001464D4
		[SecurityCritical]
		public static void Copy(IntPtr source, short[] destination, int startIndex, int length)
		{
			Marshal.CopyToManaged(source, destination, startIndex, length);
		}

		/// <summary>Copies data from an unmanaged memory pointer to a managed 64-bit signed integer array.</summary>
		/// <param name="source">The memory pointer to copy from.</param>
		/// <param name="destination">The array to copy to.</param>
		/// <param name="startIndex">The zero-based index in the destination array where copying should start.</param>
		/// <param name="length">The number of array elements to copy.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="source" />, <paramref name="destination" />, <paramref name="startIndex" />, or <paramref name="length" /> is <see langword="null" />.</exception>
		// Token: 0x06005FC7 RID: 24519 RVA: 0x001482DF File Offset: 0x001464DF
		[SecurityCritical]
		public static void Copy(IntPtr source, long[] destination, int startIndex, int length)
		{
			Marshal.CopyToManaged(source, destination, startIndex, length);
		}

		/// <summary>Copies data from an unmanaged memory pointer to a managed single-precision floating-point number array.</summary>
		/// <param name="source">The memory pointer to copy from.</param>
		/// <param name="destination">The array to copy to.</param>
		/// <param name="startIndex">The zero-based index in the destination array where copying should start.</param>
		/// <param name="length">The number of array elements to copy.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="source" />, <paramref name="destination" />, <paramref name="startIndex" />, or <paramref name="length" /> is <see langword="null" />.</exception>
		// Token: 0x06005FC8 RID: 24520 RVA: 0x001482EA File Offset: 0x001464EA
		[SecurityCritical]
		public static void Copy(IntPtr source, float[] destination, int startIndex, int length)
		{
			Marshal.CopyToManaged(source, destination, startIndex, length);
		}

		/// <summary>Copies data from an unmanaged memory pointer to a managed double-precision floating-point number array.</summary>
		/// <param name="source">The memory pointer to copy from.</param>
		/// <param name="destination">The array to copy to.</param>
		/// <param name="startIndex">The zero-based index in the destination array where copying should start.</param>
		/// <param name="length">The number of array elements to copy.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="source" />, <paramref name="destination" />, <paramref name="startIndex" />, or <paramref name="length" /> is <see langword="null" />.</exception>
		// Token: 0x06005FC9 RID: 24521 RVA: 0x001482F5 File Offset: 0x001464F5
		[SecurityCritical]
		public static void Copy(IntPtr source, double[] destination, int startIndex, int length)
		{
			Marshal.CopyToManaged(source, destination, startIndex, length);
		}

		/// <summary>Copies data from an unmanaged memory pointer to a managed 8-bit unsigned integer array.</summary>
		/// <param name="source">The memory pointer to copy from.</param>
		/// <param name="destination">The array to copy to.</param>
		/// <param name="startIndex">The zero-based index in the destination array where copying should start.</param>
		/// <param name="length">The number of array elements to copy.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="source" />, <paramref name="destination" />, <paramref name="startIndex" />, or <paramref name="length" /> is <see langword="null" />.</exception>
		// Token: 0x06005FCA RID: 24522 RVA: 0x00148300 File Offset: 0x00146500
		[SecurityCritical]
		public static void Copy(IntPtr source, byte[] destination, int startIndex, int length)
		{
			Marshal.CopyToManaged(source, destination, startIndex, length);
		}

		/// <summary>Copies data from an unmanaged memory pointer to a managed <see cref="T:System.IntPtr" /> array.</summary>
		/// <param name="source">The memory pointer to copy from.</param>
		/// <param name="destination">The array to copy to.</param>
		/// <param name="startIndex">The zero-based index in the destination array where copying should start.</param>
		/// <param name="length">The number of array elements to copy.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="source" />, <paramref name="destination" />, <paramref name="startIndex" />, or <paramref name="length" /> is <see langword="null" />.</exception>
		// Token: 0x06005FCB RID: 24523 RVA: 0x0014830B File Offset: 0x0014650B
		[SecurityCritical]
		public static void Copy(IntPtr source, IntPtr[] destination, int startIndex, int length)
		{
			Marshal.CopyToManaged(source, destination, startIndex, length);
		}

		// Token: 0x06005FCC RID: 24524
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CopyToManaged(IntPtr source, object destination, int startIndex, int length);

		/// <summary>Reads a single byte at a given offset (or index) from unmanaged memory.</summary>
		/// <param name="ptr">The base address in unmanaged memory of the source object.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before reading.</param>
		/// <returns>The byte read from unmanaged memory at the given offset.</returns>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="ptr" /> is an <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object. This method does not accept <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> parameters.</exception>
		// Token: 0x06005FCD RID: 24525
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("mscoree.dll", EntryPoint = "ND_RU1")]
		public static extern byte ReadByte([MarshalAs(UnmanagedType.AsAny)] [In] object ptr, int ofs);

		/// <summary>Reads a single byte at a given offset (or index) from unmanaged memory.</summary>
		/// <param name="ptr">The base address in unmanaged memory from which to read.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before reading.</param>
		/// <returns>The byte read from unmanaged memory at the given offset.</returns>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		// Token: 0x06005FCE RID: 24526 RVA: 0x00148318 File Offset: 0x00146518
		[SecurityCritical]
		public unsafe static byte ReadByte(IntPtr ptr, int ofs)
		{
			byte result;
			try
			{
				byte* ptr2 = (byte*)((void*)ptr) + ofs;
				result = *ptr2;
			}
			catch (NullReferenceException)
			{
				throw new AccessViolationException();
			}
			return result;
		}

		/// <summary>Reads a single byte from unmanaged memory.</summary>
		/// <param name="ptr">The address in unmanaged memory from which to read.</param>
		/// <returns>The byte read from unmanaged memory.</returns>
		/// <exception cref="T:System.AccessViolationException">
		///   <paramref name="ptr" /> is not a recognized format.  
		/// -or-  
		/// <paramref name="ptr" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="ptr" /> is invalid.</exception>
		// Token: 0x06005FCF RID: 24527 RVA: 0x0014834C File Offset: 0x0014654C
		[SecurityCritical]
		public static byte ReadByte(IntPtr ptr)
		{
			return Marshal.ReadByte(ptr, 0);
		}

		/// <summary>Reads a 16-bit signed integer at a given offset from unmanaged memory.</summary>
		/// <param name="ptr">The base address in unmanaged memory of the source object.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before reading.</param>
		/// <returns>The 16-bit signed integer read from unmanaged memory at the given offset.</returns>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="ptr" /> is an <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object. This method does not accept <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> parameters.</exception>
		// Token: 0x06005FD0 RID: 24528
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("mscoree.dll", EntryPoint = "ND_RI2")]
		public static extern short ReadInt16([MarshalAs(UnmanagedType.AsAny)] [In] object ptr, int ofs);

		/// <summary>Reads a 16-bit signed integer at a given offset from unmanaged memory.</summary>
		/// <param name="ptr">The base address in unmanaged memory from which to read.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before reading.</param>
		/// <returns>The 16-bit signed integer read from unmanaged memory at the given offset.</returns>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		// Token: 0x06005FD1 RID: 24529 RVA: 0x00148358 File Offset: 0x00146558
		[SecurityCritical]
		public unsafe static short ReadInt16(IntPtr ptr, int ofs)
		{
			short result;
			try
			{
				byte* ptr2 = (byte*)((void*)ptr) + ofs;
				if ((ptr2 & 1) == 0)
				{
					result = *(short*)ptr2;
				}
				else
				{
					short num;
					byte* ptr3 = (byte*)(&num);
					*ptr3 = *ptr2;
					ptr3[1] = ptr2[1];
					result = num;
				}
			}
			catch (NullReferenceException)
			{
				throw new AccessViolationException();
			}
			return result;
		}

		/// <summary>Reads a 16-bit signed integer from unmanaged memory.</summary>
		/// <param name="ptr">The address in unmanaged memory from which to read.</param>
		/// <returns>The 16-bit signed integer read from unmanaged memory.</returns>
		/// <exception cref="T:System.AccessViolationException">
		///   <paramref name="ptr" /> is not a recognized format.  
		/// -or-  
		/// <paramref name="ptr" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="ptr" /> is invalid.</exception>
		// Token: 0x06005FD2 RID: 24530 RVA: 0x001483A8 File Offset: 0x001465A8
		[SecurityCritical]
		public static short ReadInt16(IntPtr ptr)
		{
			return Marshal.ReadInt16(ptr, 0);
		}

		/// <summary>Reads a 32-bit signed integer at a given offset from unmanaged memory.</summary>
		/// <param name="ptr">The base address in unmanaged memory of the source object.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before reading.</param>
		/// <returns>The 32-bit signed integer read from unmanaged memory at the given offset.</returns>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="ptr" /> is an <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object. This method does not accept <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> parameters.</exception>
		// Token: 0x06005FD3 RID: 24531
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("mscoree.dll", EntryPoint = "ND_RI4")]
		public static extern int ReadInt32([MarshalAs(UnmanagedType.AsAny)] [In] object ptr, int ofs);

		/// <summary>Reads a 32-bit signed integer at a given offset from unmanaged memory.</summary>
		/// <param name="ptr">The base address in unmanaged memory from which to read.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before reading.</param>
		/// <returns>The 32-bit signed integer read from unmanaged memory.</returns>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		// Token: 0x06005FD4 RID: 24532 RVA: 0x001483B4 File Offset: 0x001465B4
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public unsafe static int ReadInt32(IntPtr ptr, int ofs)
		{
			int result;
			try
			{
				byte* ptr2 = (byte*)((void*)ptr) + ofs;
				if ((ptr2 & 3) == 0)
				{
					result = *(int*)ptr2;
				}
				else
				{
					int num;
					byte* ptr3 = (byte*)(&num);
					*ptr3 = *ptr2;
					ptr3[1] = ptr2[1];
					ptr3[2] = ptr2[2];
					ptr3[3] = ptr2[3];
					result = num;
				}
			}
			catch (NullReferenceException)
			{
				throw new AccessViolationException();
			}
			return result;
		}

		/// <summary>Reads a 32-bit signed integer from unmanaged memory.</summary>
		/// <param name="ptr">The address in unmanaged memory from which to read.</param>
		/// <returns>The 32-bit signed integer read from unmanaged memory.</returns>
		/// <exception cref="T:System.AccessViolationException">
		///   <paramref name="ptr" /> is not a recognized format.  
		/// -or-  
		/// <paramref name="ptr" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="ptr" /> is invalid.</exception>
		// Token: 0x06005FD5 RID: 24533 RVA: 0x00148414 File Offset: 0x00146614
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int ReadInt32(IntPtr ptr)
		{
			return Marshal.ReadInt32(ptr, 0);
		}

		/// <summary>Reads a processor native sized integer from unmanaged memory.</summary>
		/// <param name="ptr">The base address in unmanaged memory of the source object.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before reading.</param>
		/// <returns>The integer read from unmanaged memory at the given offset.</returns>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="ptr" /> is an <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object. This method does not accept <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> parameters.</exception>
		// Token: 0x06005FD6 RID: 24534 RVA: 0x0014841D File Offset: 0x0014661D
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static IntPtr ReadIntPtr([MarshalAs(UnmanagedType.AsAny)] [In] object ptr, int ofs)
		{
			return (IntPtr)Marshal.ReadInt64(ptr, ofs);
		}

		/// <summary>Reads a processor native sized integer at a given offset from unmanaged memory.</summary>
		/// <param name="ptr">The base address in unmanaged memory from which to read.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before reading.</param>
		/// <returns>The integer read from unmanaged memory at the given offset.</returns>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		// Token: 0x06005FD7 RID: 24535 RVA: 0x0014842B File Offset: 0x0014662B
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static IntPtr ReadIntPtr(IntPtr ptr, int ofs)
		{
			return (IntPtr)Marshal.ReadInt64(ptr, ofs);
		}

		/// <summary>Reads a processor native-sized integer from unmanaged memory.</summary>
		/// <param name="ptr">The address in unmanaged memory from which to read.</param>
		/// <returns>The integer read from unmanaged memory. A 32 bit integer is returned on 32 bit machines and a 64 bit integer is returned on 64 bit machines.</returns>
		/// <exception cref="T:System.AccessViolationException">
		///   <paramref name="ptr" /> is not a recognized format.  
		/// -or-  
		/// <paramref name="ptr" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="ptr" /> is invalid.</exception>
		// Token: 0x06005FD8 RID: 24536 RVA: 0x00148439 File Offset: 0x00146639
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static IntPtr ReadIntPtr(IntPtr ptr)
		{
			return (IntPtr)Marshal.ReadInt64(ptr, 0);
		}

		/// <summary>Reads a 64-bit signed integer at a given offset from unmanaged memory.</summary>
		/// <param name="ptr">The base address in unmanaged memory of the source object.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before reading.</param>
		/// <returns>The 64-bit signed integer read from unmanaged memory at the given offset.</returns>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="ptr" /> is an <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object. This method does not accept <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> parameters.</exception>
		// Token: 0x06005FD9 RID: 24537
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("mscoree.dll", EntryPoint = "ND_RI8")]
		public static extern long ReadInt64([MarshalAs(UnmanagedType.AsAny)] [In] object ptr, int ofs);

		/// <summary>Reads a 64-bit signed integer at a given offset from unmanaged memory.</summary>
		/// <param name="ptr">The base address in unmanaged memory from which to read.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before reading.</param>
		/// <returns>The 64-bit signed integer read from unmanaged memory at the given offset.</returns>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		// Token: 0x06005FDA RID: 24538 RVA: 0x00148448 File Offset: 0x00146648
		[SecurityCritical]
		public unsafe static long ReadInt64(IntPtr ptr, int ofs)
		{
			long result;
			try
			{
				byte* ptr2 = (byte*)((void*)ptr) + ofs;
				if ((ptr2 & 7) == 0)
				{
					result = *(long*)ptr2;
				}
				else
				{
					long num;
					byte* ptr3 = (byte*)(&num);
					*ptr3 = *ptr2;
					ptr3[1] = ptr2[1];
					ptr3[2] = ptr2[2];
					ptr3[3] = ptr2[3];
					ptr3[4] = ptr2[4];
					ptr3[5] = ptr2[5];
					ptr3[6] = ptr2[6];
					ptr3[7] = ptr2[7];
					result = num;
				}
			}
			catch (NullReferenceException)
			{
				throw new AccessViolationException();
			}
			return result;
		}

		/// <summary>Reads a 64-bit signed integer from unmanaged memory.</summary>
		/// <param name="ptr">The address in unmanaged memory from which to read.</param>
		/// <returns>The 64-bit signed integer read from unmanaged memory.</returns>
		/// <exception cref="T:System.AccessViolationException">
		///   <paramref name="ptr" /> is not a recognized format.  
		/// -or-  
		/// <paramref name="ptr" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="ptr" /> is invalid.</exception>
		// Token: 0x06005FDB RID: 24539 RVA: 0x001484C8 File Offset: 0x001466C8
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static long ReadInt64(IntPtr ptr)
		{
			return Marshal.ReadInt64(ptr, 0);
		}

		/// <summary>Writes a single byte value to unmanaged memory at a specified offset.</summary>
		/// <param name="ptr">The base address in unmanaged memory to write to.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before writing.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		// Token: 0x06005FDC RID: 24540 RVA: 0x001484D4 File Offset: 0x001466D4
		[SecurityCritical]
		public unsafe static void WriteByte(IntPtr ptr, int ofs, byte val)
		{
			try
			{
				byte* ptr2 = (byte*)((void*)ptr) + ofs;
				*ptr2 = val;
			}
			catch (NullReferenceException)
			{
				throw new AccessViolationException();
			}
		}

		/// <summary>Writes a single byte value to unmanaged memory at a specified offset.</summary>
		/// <param name="ptr">The base address in unmanaged memory of the target object.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before writing.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="ptr" /> is an <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object. This method does not accept <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> parameters.</exception>
		// Token: 0x06005FDD RID: 24541
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("mscoree.dll", EntryPoint = "ND_WU1")]
		public static extern void WriteByte([MarshalAs(UnmanagedType.AsAny)] [In] [Out] object ptr, int ofs, byte val);

		/// <summary>Writes a single byte value to unmanaged memory.</summary>
		/// <param name="ptr">The address in unmanaged memory to write to.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">
		///   <paramref name="ptr" /> is not a recognized format.  
		/// -or-  
		/// <paramref name="ptr" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="ptr" /> is invalid.</exception>
		// Token: 0x06005FDE RID: 24542 RVA: 0x00148508 File Offset: 0x00146708
		[SecurityCritical]
		public static void WriteByte(IntPtr ptr, byte val)
		{
			Marshal.WriteByte(ptr, 0, val);
		}

		/// <summary>Writes a 16-bit signed integer value into unmanaged memory at a specified offset.</summary>
		/// <param name="ptr">The base address in unmanaged memory to write to.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before writing.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		// Token: 0x06005FDF RID: 24543 RVA: 0x00148514 File Offset: 0x00146714
		[SecurityCritical]
		public unsafe static void WriteInt16(IntPtr ptr, int ofs, short val)
		{
			try
			{
				byte* ptr2 = (byte*)((void*)ptr) + ofs;
				if ((ptr2 & 1) == 0)
				{
					*(short*)ptr2 = val;
				}
				else
				{
					byte* ptr3 = (byte*)(&val);
					*ptr2 = *ptr3;
					ptr2[1] = ptr3[1];
				}
			}
			catch (NullReferenceException)
			{
				throw new AccessViolationException();
			}
		}

		/// <summary>Writes a 16-bit signed integer value to unmanaged memory at a specified offset.</summary>
		/// <param name="ptr">The base address in unmanaged memory of the target object.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before writing.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="ptr" /> is an <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object. This method does not accept <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> parameters.</exception>
		// Token: 0x06005FE0 RID: 24544
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("mscoree.dll", EntryPoint = "ND_WI2")]
		public static extern void WriteInt16([MarshalAs(UnmanagedType.AsAny)] [In] [Out] object ptr, int ofs, short val);

		/// <summary>Writes a 16-bit integer value to unmanaged memory.</summary>
		/// <param name="ptr">The address in unmanaged memory to write to.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">
		///   <paramref name="ptr" /> is not a recognized format.  
		/// -or-  
		/// <paramref name="ptr" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="ptr" /> is invalid.</exception>
		// Token: 0x06005FE1 RID: 24545 RVA: 0x00148560 File Offset: 0x00146760
		[SecurityCritical]
		public static void WriteInt16(IntPtr ptr, short val)
		{
			Marshal.WriteInt16(ptr, 0, val);
		}

		/// <summary>Writes a 16-bit signed integer value to unmanaged memory at a specified offset.</summary>
		/// <param name="ptr">The base address in the native heap to write to.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before writing.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		// Token: 0x06005FE2 RID: 24546 RVA: 0x0014856A File Offset: 0x0014676A
		[SecurityCritical]
		public static void WriteInt16(IntPtr ptr, int ofs, char val)
		{
			Marshal.WriteInt16(ptr, ofs, (short)val);
		}

		/// <summary>Writes a 16-bit signed integer value to unmanaged memory at a specified offset.</summary>
		/// <param name="ptr">The base address in unmanaged memory of the target object.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before writing.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="ptr" /> is an <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object. This method does not accept <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> parameters.</exception>
		// Token: 0x06005FE3 RID: 24547 RVA: 0x00148575 File Offset: 0x00146775
		[SecurityCritical]
		public static void WriteInt16([In] [Out] object ptr, int ofs, char val)
		{
			Marshal.WriteInt16(ptr, ofs, (short)val);
		}

		/// <summary>Writes a character as a 16-bit integer value to unmanaged memory.</summary>
		/// <param name="ptr">The address in unmanaged memory to write to.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">
		///   <paramref name="ptr" /> is not a recognized format.  
		/// -or-  
		/// <paramref name="ptr" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="ptr" /> is invalid.</exception>
		// Token: 0x06005FE4 RID: 24548 RVA: 0x00148580 File Offset: 0x00146780
		[SecurityCritical]
		public static void WriteInt16(IntPtr ptr, char val)
		{
			Marshal.WriteInt16(ptr, 0, (short)val);
		}

		/// <summary>Writes a 32-bit signed integer value into unmanaged memory at a specified offset.</summary>
		/// <param name="ptr">The base address in unmanaged memory to write to.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before writing.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		// Token: 0x06005FE5 RID: 24549 RVA: 0x0014858C File Offset: 0x0014678C
		[SecurityCritical]
		public unsafe static void WriteInt32(IntPtr ptr, int ofs, int val)
		{
			try
			{
				byte* ptr2 = (byte*)((void*)ptr) + ofs;
				if ((ptr2 & 3) == 0)
				{
					*(int*)ptr2 = val;
				}
				else
				{
					byte* ptr3 = (byte*)(&val);
					*ptr2 = *ptr3;
					ptr2[1] = ptr3[1];
					ptr2[2] = ptr3[2];
					ptr2[3] = ptr3[3];
				}
			}
			catch (NullReferenceException)
			{
				throw new AccessViolationException();
			}
		}

		/// <summary>Writes a 32-bit signed integer value to unmanaged memory at a specified offset.</summary>
		/// <param name="ptr">The base address in unmanaged memory of the target object.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before writing.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="ptr" /> is an <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object. This method does not accept <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> parameters.</exception>
		// Token: 0x06005FE6 RID: 24550
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("mscoree.dll", EntryPoint = "ND_WI4")]
		public static extern void WriteInt32([MarshalAs(UnmanagedType.AsAny)] [In] [Out] object ptr, int ofs, int val);

		/// <summary>Writes a 32-bit signed integer value to unmanaged memory.</summary>
		/// <param name="ptr">The address in unmanaged memory to write to.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">
		///   <paramref name="ptr" /> is not a recognized format.  
		/// -or-  
		/// <paramref name="ptr" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="ptr" /> is invalid.</exception>
		// Token: 0x06005FE7 RID: 24551 RVA: 0x001485E8 File Offset: 0x001467E8
		[SecurityCritical]
		public static void WriteInt32(IntPtr ptr, int val)
		{
			Marshal.WriteInt32(ptr, 0, val);
		}

		/// <summary>Writes a processor native-sized integer value to unmanaged memory at a specified offset.</summary>
		/// <param name="ptr">The base address in unmanaged memory to write to.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before writing.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		// Token: 0x06005FE8 RID: 24552 RVA: 0x001485F2 File Offset: 0x001467F2
		[SecurityCritical]
		public static void WriteIntPtr(IntPtr ptr, int ofs, IntPtr val)
		{
			Marshal.WriteInt64(ptr, ofs, (long)val);
		}

		/// <summary>Writes a processor native sized integer value to unmanaged memory.</summary>
		/// <param name="ptr">The base address in unmanaged memory of the target object.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before writing.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="ptr" /> is an <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object. This method does not accept <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> parameters.</exception>
		// Token: 0x06005FE9 RID: 24553 RVA: 0x00148601 File Offset: 0x00146801
		[SecurityCritical]
		public static void WriteIntPtr([MarshalAs(UnmanagedType.AsAny)] [In] [Out] object ptr, int ofs, IntPtr val)
		{
			Marshal.WriteInt64(ptr, ofs, (long)val);
		}

		/// <summary>Writes a processor native sized integer value into unmanaged memory.</summary>
		/// <param name="ptr">The address in unmanaged memory to write to.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">
		///   <paramref name="ptr" /> is not a recognized format.  
		/// -or-  
		/// <paramref name="ptr" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="ptr" /> is invalid.</exception>
		// Token: 0x06005FEA RID: 24554 RVA: 0x00148610 File Offset: 0x00146810
		[SecurityCritical]
		public static void WriteIntPtr(IntPtr ptr, IntPtr val)
		{
			Marshal.WriteInt64(ptr, 0, (long)val);
		}

		/// <summary>Writes a 64-bit signed integer value to unmanaged memory at a specified offset.</summary>
		/// <param name="ptr">The base address in unmanaged memory to write.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before writing.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		// Token: 0x06005FEB RID: 24555 RVA: 0x00148620 File Offset: 0x00146820
		[SecurityCritical]
		public unsafe static void WriteInt64(IntPtr ptr, int ofs, long val)
		{
			try
			{
				byte* ptr2 = (byte*)((void*)ptr) + ofs;
				if ((ptr2 & 7) == 0)
				{
					*(long*)ptr2 = val;
				}
				else
				{
					byte* ptr3 = (byte*)(&val);
					*ptr2 = *ptr3;
					ptr2[1] = ptr3[1];
					ptr2[2] = ptr3[2];
					ptr2[3] = ptr3[3];
					ptr2[4] = ptr3[4];
					ptr2[5] = ptr3[5];
					ptr2[6] = ptr3[6];
					ptr2[7] = ptr3[7];
				}
			}
			catch (NullReferenceException)
			{
				throw new AccessViolationException();
			}
		}

		/// <summary>Writes a 64-bit signed integer value to unmanaged memory at a specified offset.</summary>
		/// <param name="ptr">The base address in unmanaged memory of the target object.</param>
		/// <param name="ofs">An additional byte offset, which is added to the <paramref name="ptr" /> parameter before writing.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">Base address (<paramref name="ptr" />) plus offset byte (<paramref name="ofs" />) produces a null or invalid address.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="ptr" /> is an <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> object. This method does not accept <see cref="T:System.Runtime.InteropServices.ArrayWithOffset" /> parameters.</exception>
		// Token: 0x06005FEC RID: 24556
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("mscoree.dll", EntryPoint = "ND_WI8")]
		public static extern void WriteInt64([MarshalAs(UnmanagedType.AsAny)] [In] [Out] object ptr, int ofs, long val);

		/// <summary>Writes a 64-bit signed integer value to unmanaged memory.</summary>
		/// <param name="ptr">The address in unmanaged memory to write to.</param>
		/// <param name="val">The value to write.</param>
		/// <exception cref="T:System.AccessViolationException">
		///   <paramref name="ptr" /> is not a recognized format.  
		/// -or-  
		/// <paramref name="ptr" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="ptr" /> is invalid.</exception>
		// Token: 0x06005FED RID: 24557 RVA: 0x0014869C File Offset: 0x0014689C
		[SecurityCritical]
		public static void WriteInt64(IntPtr ptr, long val)
		{
			Marshal.WriteInt64(ptr, 0, val);
		}

		/// <summary>Returns the error code returned by the last unmanaged function that was called using platform invoke that has the <see cref="F:System.Runtime.InteropServices.DllImportAttribute.SetLastError" /> flag set.</summary>
		/// <returns>The last error code set by a call to the Win32 SetLastError function.</returns>
		// Token: 0x06005FEE RID: 24558
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetLastWin32Error();

		// Token: 0x06005FEF RID: 24559
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void SetLastWin32Error(int error);

		/// <summary>Returns the HRESULT corresponding to the last error incurred by Win32 code executed using <see cref="T:System.Runtime.InteropServices.Marshal" />.</summary>
		/// <returns>The HRESULT corresponding to the last Win32 error code.</returns>
		// Token: 0x06005FF0 RID: 24560 RVA: 0x001486A8 File Offset: 0x001468A8
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int GetHRForLastWin32Error()
		{
			int lastWin32Error = Marshal.GetLastWin32Error();
			if (((long)lastWin32Error & (long)((ulong)-2147483648)) == (long)((ulong)-2147483648))
			{
				return lastWin32Error;
			}
			return (lastWin32Error & 65535) | -2147024896;
		}

		/// <summary>Executes one-time method setup tasks without calling the method.</summary>
		/// <param name="m">The method to be checked.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="m" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="m" /> parameter is not a <see cref="T:System.Reflection.MethodInfo" /> object.</exception>
		// Token: 0x06005FF1 RID: 24561 RVA: 0x001486DC File Offset: 0x001468DC
		[SecurityCritical]
		public static void Prelink(MethodInfo m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			RuntimeMethodInfo runtimeMethodInfo = m as RuntimeMethodInfo;
			if (runtimeMethodInfo == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeMethodInfo"));
			}
			Marshal.InternalPrelink(runtimeMethodInfo);
		}

		// Token: 0x06005FF2 RID: 24562
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void InternalPrelink(IRuntimeMethodInfo m);

		/// <summary>Performs a pre-link check for all methods on a class.</summary>
		/// <param name="c">The class whose methods are to be checked.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="c" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06005FF3 RID: 24563 RVA: 0x00148724 File Offset: 0x00146924
		[SecurityCritical]
		public static void PrelinkAll(Type c)
		{
			if (c == null)
			{
				throw new ArgumentNullException("c");
			}
			MethodInfo[] methods = c.GetMethods();
			if (methods != null)
			{
				for (int i = 0; i < methods.Length; i++)
				{
					Marshal.Prelink(methods[i]);
				}
			}
		}

		/// <summary>Calculates the number of bytes in unmanaged memory that are required to hold the parameters for the specified method.</summary>
		/// <param name="m">The method to be checked.</param>
		/// <returns>The number of bytes required to represent the method parameters in unmanaged memory.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="m" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="m" /> parameter is not a <see cref="T:System.Reflection.MethodInfo" /> object.</exception>
		// Token: 0x06005FF4 RID: 24564 RVA: 0x00148768 File Offset: 0x00146968
		[SecurityCritical]
		public static int NumParamBytes(MethodInfo m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			RuntimeMethodInfo runtimeMethodInfo = m as RuntimeMethodInfo;
			if (runtimeMethodInfo == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeMethodInfo"));
			}
			return Marshal.InternalNumParamBytes(runtimeMethodInfo);
		}

		// Token: 0x06005FF5 RID: 24565
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int InternalNumParamBytes(IRuntimeMethodInfo m);

		/// <summary>Retrieves a computer-independent description of an exception, and information about the state that existed for the thread when the exception occurred.</summary>
		/// <returns>A pointer to an EXCEPTION_POINTERS structure.</returns>
		// Token: 0x06005FF6 RID: 24566
		[SecurityCritical]
		[ComVisible(true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetExceptionPointers();

		/// <summary>Retrieves a code that identifies the type of the exception that occurred.</summary>
		/// <returns>The type of the exception.</returns>
		// Token: 0x06005FF7 RID: 24567
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetExceptionCode();

		/// <summary>Marshals data from a managed object to an unmanaged block of memory.</summary>
		/// <param name="structure">A managed object that holds the data to be marshaled. This object must be a structure or an instance of a formatted class.</param>
		/// <param name="ptr">A pointer to an unmanaged block of memory, which must be allocated before this method is called.</param>
		/// <param name="fDeleteOld">
		///   <see langword="true" /> to call the <see cref="M:System.Runtime.InteropServices.Marshal.DestroyStructure(System.IntPtr,System.Type)" /> method on the <paramref name="ptr" /> parameter before this method copies the data. The block must contain valid data. Note that passing <see langword="false" /> when the memory block already contains data can lead to a memory leak.</param>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="structure" /> is a reference type that is not a formatted class.  
		/// -or-  
		/// <paramref name="structure" /> is an instance of a generic type (in the .NET Framework 4.5 and earlier versions only).</exception>
		// Token: 0x06005FF8 RID: 24568
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[ComVisible(true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void StructureToPtr(object structure, IntPtr ptr, bool fDeleteOld);

		/// <summary>[Supported in the .NET Framework 4.5.1 and later versions]  
		///  Marshals data from a managed object of a specified type to an unmanaged block of memory.</summary>
		/// <param name="structure">A managed object that holds the data to be marshaled. The object must be a structure or an instance of a formatted class.</param>
		/// <param name="ptr">A pointer to an unmanaged block of memory, which must be allocated before this method is called.</param>
		/// <param name="fDeleteOld">
		///   <see langword="true" /> to call the <see cref="M:System.Runtime.InteropServices.Marshal.DestroyStructure``1(System.IntPtr)" /> method on the <paramref name="ptr" /> parameter before this method copies the data. The block must contain valid data. Note that passing <see langword="false" /> when the memory block already contains data can lead to a memory leak.</param>
		/// <typeparam name="T">The type of the managed object.</typeparam>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="structure" /> is a reference type that is not a formatted class.</exception>
		// Token: 0x06005FF9 RID: 24569 RVA: 0x001487AF File Offset: 0x001469AF
		[SecurityCritical]
		public static void StructureToPtr<T>(T structure, IntPtr ptr, bool fDeleteOld)
		{
			Marshal.StructureToPtr(structure, ptr, fDeleteOld);
		}

		/// <summary>Marshals data from an unmanaged block of memory to a managed object.</summary>
		/// <param name="ptr">A pointer to an unmanaged block of memory.</param>
		/// <param name="structure">The object to which the data is to be copied. This must be an instance of a formatted class.</param>
		/// <exception cref="T:System.ArgumentException">Structure layout is not sequential or explicit.  
		///  -or-  
		///  Structure is a boxed value type.</exception>
		// Token: 0x06005FFA RID: 24570 RVA: 0x001487BE File Offset: 0x001469BE
		[SecurityCritical]
		[ComVisible(true)]
		public static void PtrToStructure(IntPtr ptr, object structure)
		{
			Marshal.PtrToStructureHelper(ptr, structure, false);
		}

		/// <summary>[Supported in the .NET Framework 4.5.1 and later versions]  
		///  Marshals data from an unmanaged block of memory to a managed object of the specified type.</summary>
		/// <param name="ptr">A pointer to an unmanaged block of memory.</param>
		/// <param name="structure">The object to which the data is to be copied.</param>
		/// <typeparam name="T">The type of <paramref name="structure" />. This must be a formatted class.</typeparam>
		/// <exception cref="T:System.ArgumentException">Structure layout is not sequential or explicit.</exception>
		// Token: 0x06005FFB RID: 24571 RVA: 0x001487C8 File Offset: 0x001469C8
		[SecurityCritical]
		public static void PtrToStructure<T>(IntPtr ptr, T structure)
		{
			Marshal.PtrToStructure(ptr, structure);
		}

		/// <summary>Marshals data from an unmanaged block of memory to a newly allocated managed object of the specified type.</summary>
		/// <param name="ptr">A pointer to an unmanaged block of memory.</param>
		/// <param name="structureType">The type of object to be created. This object must represent a formatted class or a structure.</param>
		/// <returns>A managed object containing the data pointed to by the <paramref name="ptr" /> parameter.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="structureType" /> parameter layout is not sequential or explicit.  
		///  -or-  
		///  The <paramref name="structureType" /> parameter is a generic type definition.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="structureType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.MissingMethodException">The class specified by <paramref name="structureType" /> does not have an accessible default constructor.</exception>
		// Token: 0x06005FFC RID: 24572 RVA: 0x001487D8 File Offset: 0x001469D8
		[SecurityCritical]
		[ComVisible(true)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static object PtrToStructure(IntPtr ptr, Type structureType)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			if (structureType == null)
			{
				throw new ArgumentNullException("structureType");
			}
			if (structureType.IsGenericType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "structureType");
			}
			RuntimeType runtimeType = structureType.UnderlyingSystemType as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "type");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			object obj = runtimeType.CreateInstanceDefaultCtor(false, false, false, ref stackCrawlMark);
			Marshal.PtrToStructureHelper(ptr, obj, true);
			return obj;
		}

		/// <summary>[Supported in the .NET Framework 4.5.1 and later versions]  
		///  Marshals data from an unmanaged block of memory to a newly allocated managed object of the type specified by a generic type parameter.</summary>
		/// <param name="ptr">A pointer to an unmanaged block of memory.</param>
		/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a formatted class or a structure.</typeparam>
		/// <returns>A managed object that contains the data that the <paramref name="ptr" /> parameter points to.</returns>
		/// <exception cref="T:System.ArgumentException">The layout of <typeparamref name="T" /> is not sequential or explicit.</exception>
		/// <exception cref="T:System.MissingMethodException">The class specified by <typeparamref name="T" /> does not have an accessible default constructor.</exception>
		// Token: 0x06005FFD RID: 24573 RVA: 0x00148866 File Offset: 0x00146A66
		[SecurityCritical]
		public static T PtrToStructure<T>(IntPtr ptr)
		{
			return (T)((object)Marshal.PtrToStructure(ptr, typeof(T)));
		}

		// Token: 0x06005FFE RID: 24574
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PtrToStructureHelper(IntPtr ptr, object structure, bool allowValueClasses);

		/// <summary>Frees all substructures that the specified unmanaged memory block points to.</summary>
		/// <param name="ptr">A pointer to an unmanaged block of memory.</param>
		/// <param name="structuretype">Type of a formatted class. This provides the layout information necessary to delete the buffer in the <paramref name="ptr" /> parameter.</param>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="structureType" /> has an automatic layout. Use sequential or explicit instead.</exception>
		// Token: 0x06005FFF RID: 24575
		[SecurityCritical]
		[ComVisible(true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void DestroyStructure(IntPtr ptr, Type structuretype);

		/// <summary>[Supported in the .NET Framework 4.5.1 and later versions]  
		///  Frees all substructures of a specified type that the specified unmanaged memory block points to.</summary>
		/// <param name="ptr">A pointer to an unmanaged block of memory.</param>
		/// <typeparam name="T">The type of the formatted structure. This provides the layout information necessary to delete the buffer in the <paramref name="ptr" /> parameter.</typeparam>
		/// <exception cref="T:System.ArgumentException">
		///   <typeparamref name="T" /> has an automatic layout. Use sequential or explicit instead.</exception>
		// Token: 0x06006000 RID: 24576 RVA: 0x0014887D File Offset: 0x00146A7D
		[SecurityCritical]
		public static void DestroyStructure<T>(IntPtr ptr)
		{
			Marshal.DestroyStructure(ptr, typeof(T));
		}

		/// <summary>Returns the instance handle (HINSTANCE) for the specified module.</summary>
		/// <param name="m">The module whose HINSTANCE is desired.</param>
		/// <returns>The HINSTANCE for <paramref name="m" />; or -1 if the module does not have an HINSTANCE.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="m" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06006001 RID: 24577 RVA: 0x00148890 File Offset: 0x00146A90
		[SecurityCritical]
		public static IntPtr GetHINSTANCE(Module m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			RuntimeModule runtimeModule = m as RuntimeModule;
			if (runtimeModule == null)
			{
				ModuleBuilder moduleBuilder = m as ModuleBuilder;
				if (moduleBuilder != null)
				{
					runtimeModule = moduleBuilder.InternalModule;
				}
			}
			if (runtimeModule == null)
			{
				throw new ArgumentNullException(Environment.GetResourceString("Argument_MustBeRuntimeModule"));
			}
			return Marshal.GetHINSTANCE(runtimeModule.GetNativeHandle());
		}

		// Token: 0x06006002 RID: 24578
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern IntPtr GetHINSTANCE(RuntimeModule m);

		/// <summary>Throws an exception with a specific failure HRESULT value.</summary>
		/// <param name="errorCode">The HRESULT corresponding to the desired exception.</param>
		// Token: 0x06006003 RID: 24579 RVA: 0x001488FC File Offset: 0x00146AFC
		[SecurityCritical]
		public static void ThrowExceptionForHR(int errorCode)
		{
			if (errorCode < 0)
			{
				Marshal.ThrowExceptionForHRInternal(errorCode, IntPtr.Zero);
			}
		}

		/// <summary>Throws an exception with a specific failure HRESULT, based on the specified IErrorInfo.aspx) interface.</summary>
		/// <param name="errorCode">The HRESULT corresponding to the desired exception.</param>
		/// <param name="errorInfo">A pointer to the IErrorInfo interface that provides more information about the error. You can specify IntPtr(0) to use the current IErrorInfo interface, or IntPtr(-1) to ignore the current IErrorInfo interface and construct the exception just from the error code.</param>
		// Token: 0x06006004 RID: 24580 RVA: 0x0014890D File Offset: 0x00146B0D
		[SecurityCritical]
		public static void ThrowExceptionForHR(int errorCode, IntPtr errorInfo)
		{
			if (errorCode < 0)
			{
				Marshal.ThrowExceptionForHRInternal(errorCode, errorInfo);
			}
		}

		// Token: 0x06006005 RID: 24581
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ThrowExceptionForHRInternal(int errorCode, IntPtr errorInfo);

		/// <summary>Converts the specified HRESULT error code to a corresponding <see cref="T:System.Exception" /> object.</summary>
		/// <param name="errorCode">The HRESULT to be converted.</param>
		/// <returns>An object that represents the converted HRESULT.</returns>
		// Token: 0x06006006 RID: 24582 RVA: 0x0014891A File Offset: 0x00146B1A
		[SecurityCritical]
		public static Exception GetExceptionForHR(int errorCode)
		{
			if (errorCode < 0)
			{
				return Marshal.GetExceptionForHRInternal(errorCode, IntPtr.Zero);
			}
			return null;
		}

		/// <summary>Converts the specified HRESULT error code to a corresponding <see cref="T:System.Exception" /> object, with additional error information passed in an IErrorInfo interface for the exception object.</summary>
		/// <param name="errorCode">The HRESULT to be converted.</param>
		/// <param name="errorInfo">A pointer to the <see langword="IErrorInfo" /> interface that provides more information about the error. You can specify IntPtr(0) to use the current <see langword="IErrorInfo" /> interface, or IntPtr(-1) to ignore the current <see langword="IErrorInfo" /> interface and construct the exception just from the error code.</param>
		/// <returns>An object that represents the converted HRESULT and information obtained from <paramref name="errorInfo" />.</returns>
		// Token: 0x06006007 RID: 24583 RVA: 0x0014892D File Offset: 0x00146B2D
		[SecurityCritical]
		public static Exception GetExceptionForHR(int errorCode, IntPtr errorInfo)
		{
			if (errorCode < 0)
			{
				return Marshal.GetExceptionForHRInternal(errorCode, errorInfo);
			}
			return null;
		}

		// Token: 0x06006008 RID: 24584
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Exception GetExceptionForHRInternal(int errorCode, IntPtr errorInfo);

		/// <summary>Converts the specified exception to an HRESULT.</summary>
		/// <param name="e">The exception to convert to an HRESULT.</param>
		/// <returns>The HRESULT mapped to the supplied exception.</returns>
		// Token: 0x06006009 RID: 24585
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetHRForException(Exception e);

		// Token: 0x0600600A RID: 24586
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int GetHRForException_WinRT(Exception e);

		/// <summary>Gets a pointer to a runtime-generated function that marshals a call from unmanaged to managed code.</summary>
		/// <param name="pfnMethodToWrap">A pointer to the method to marshal.</param>
		/// <param name="pbSignature">A pointer to the method signature.</param>
		/// <param name="cbSignature">The number of bytes in <paramref name="pbSignature" />.</param>
		/// <returns>A pointer to a function that will marshal a call from <paramref name="pfnMethodToWrap" /> to managed code.</returns>
		// Token: 0x0600600B RID: 24587
		[SecurityCritical]
		[Obsolete("The GetUnmanagedThunkForManagedMethodPtr method has been deprecated and will be removed in a future release.", false)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetUnmanagedThunkForManagedMethodPtr(IntPtr pfnMethodToWrap, IntPtr pbSignature, int cbSignature);

		/// <summary>Gets a pointer to a runtime-generated function that marshals a call from managed to unmanaged code.</summary>
		/// <param name="pfnMethodToWrap">A pointer to the method to marshal.</param>
		/// <param name="pbSignature">A pointer to the method signature.</param>
		/// <param name="cbSignature">The number of bytes in <paramref name="pbSignature" />.</param>
		/// <returns>A pointer to the function that will marshal a call from the <paramref name="pfnMethodToWrap" /> parameter to unmanaged code.</returns>
		// Token: 0x0600600C RID: 24588
		[SecurityCritical]
		[Obsolete("The GetManagedThunkForUnmanagedMethodPtr method has been deprecated and will be removed in a future release.", false)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetManagedThunkForUnmanagedMethodPtr(IntPtr pfnMethodToWrap, IntPtr pbSignature, int cbSignature);

		/// <summary>Converts a fiber cookie into the corresponding <see cref="T:System.Threading.Thread" /> instance.</summary>
		/// <param name="cookie">An integer that represents a fiber cookie.</param>
		/// <returns>A thread that corresponds to the <paramref name="cookie" /> parameter.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="cookie" /> parameter is 0.</exception>
		// Token: 0x0600600D RID: 24589 RVA: 0x0014893C File Offset: 0x00146B3C
		[SecurityCritical]
		[Obsolete("The GetThreadFromFiberCookie method has been deprecated.  Use the hosting API to perform this operation.", false)]
		public static Thread GetThreadFromFiberCookie(int cookie)
		{
			if (cookie == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ArgumentZero"), "cookie");
			}
			return Marshal.InternalGetThreadFromFiberCookie(cookie);
		}

		// Token: 0x0600600E RID: 24590
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Thread InternalGetThreadFromFiberCookie(int cookie);

		/// <summary>Allocates memory from the unmanaged memory of the process by using the pointer to the specified number of bytes.</summary>
		/// <param name="cb">The required number of bytes in memory.</param>
		/// <returns>A pointer to the newly allocated memory. This memory must be released using the <see cref="M:System.Runtime.InteropServices.Marshal.FreeHGlobal(System.IntPtr)" /> method.</returns>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory to satisfy the request.</exception>
		// Token: 0x0600600F RID: 24591 RVA: 0x0014895C File Offset: 0x00146B5C
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static IntPtr AllocHGlobal(IntPtr cb)
		{
			UIntPtr sizetdwBytes = new UIntPtr((ulong)cb.ToInt64());
			IntPtr intPtr = Win32Native.LocalAlloc_NoSafeHandle(0, sizetdwBytes);
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			return intPtr;
		}

		/// <summary>Allocates memory from the unmanaged memory of the process by using the specified number of bytes.</summary>
		/// <param name="cb">The required number of bytes in memory.</param>
		/// <returns>A pointer to the newly allocated memory. This memory must be released using the <see cref="M:System.Runtime.InteropServices.Marshal.FreeHGlobal(System.IntPtr)" /> method.</returns>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory to satisfy the request.</exception>
		// Token: 0x06006010 RID: 24592 RVA: 0x00148993 File Offset: 0x00146B93
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static IntPtr AllocHGlobal(int cb)
		{
			return Marshal.AllocHGlobal((IntPtr)cb);
		}

		/// <summary>Frees memory previously allocated from the unmanaged memory of the process.</summary>
		/// <param name="hglobal">The handle returned by the original matching call to <see cref="M:System.Runtime.InteropServices.Marshal.AllocHGlobal(System.IntPtr)" />.</param>
		// Token: 0x06006011 RID: 24593 RVA: 0x001489A0 File Offset: 0x00146BA0
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void FreeHGlobal(IntPtr hglobal)
		{
			if (Marshal.IsNotWin32Atom(hglobal) && IntPtr.Zero != Win32Native.LocalFree(hglobal))
			{
				Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
			}
		}

		/// <summary>Resizes a block of memory previously allocated with <see cref="M:System.Runtime.InteropServices.Marshal.AllocHGlobal(System.IntPtr)" />.</summary>
		/// <param name="pv">A pointer to memory allocated with <see cref="M:System.Runtime.InteropServices.Marshal.AllocHGlobal(System.IntPtr)" />.</param>
		/// <param name="cb">The new size of the allocated block. This is not a pointer; it is the byte count you are requesting, cast to type <see cref="T:System.IntPtr" />. If you pass a pointer, it is treated as a size.</param>
		/// <returns>A pointer to the reallocated memory. This memory must be released using <see cref="M:System.Runtime.InteropServices.Marshal.FreeHGlobal(System.IntPtr)" />.</returns>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory to satisfy the request.</exception>
		// Token: 0x06006012 RID: 24594 RVA: 0x001489C8 File Offset: 0x00146BC8
		[SecurityCritical]
		public static IntPtr ReAllocHGlobal(IntPtr pv, IntPtr cb)
		{
			IntPtr intPtr = Win32Native.LocalReAlloc(pv, cb, 2);
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			return intPtr;
		}

		/// <summary>Copies the contents of a managed <see cref="T:System.String" /> into unmanaged memory, converting into ANSI format as it copies.</summary>
		/// <param name="s">A managed string to be copied.</param>
		/// <returns>The address, in unmanaged memory, to where <paramref name="s" /> was copied, or 0 if <paramref name="s" /> is <see langword="null" />.</returns>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory available.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="s" /> parameter exceeds the maximum length allowed by the operating system.</exception>
		// Token: 0x06006013 RID: 24595 RVA: 0x001489F4 File Offset: 0x00146BF4
		[SecurityCritical]
		public unsafe static IntPtr StringToHGlobalAnsi(string s)
		{
			if (s == null)
			{
				return IntPtr.Zero;
			}
			int num = (s.Length + 1) * Marshal.SystemMaxDBCSCharSize;
			if (num < s.Length)
			{
				throw new ArgumentOutOfRangeException("s");
			}
			UIntPtr sizetdwBytes = new UIntPtr((uint)num);
			IntPtr intPtr = Win32Native.LocalAlloc_NoSafeHandle(0, sizetdwBytes);
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			s.ConvertToAnsi((byte*)((void*)intPtr), num, false, false);
			return intPtr;
		}

		/// <summary>Copies the contents of a managed <see cref="T:System.String" /> into unmanaged memory.</summary>
		/// <param name="s">A managed string to be copied.</param>
		/// <returns>The address, in unmanaged memory, to where the <paramref name="s" /> was copied, or 0 if <paramref name="s" /> is <see langword="null" />.</returns>
		/// <exception cref="T:System.OutOfMemoryException">The method could not allocate enough native heap memory.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="s" /> parameter exceeds the maximum length allowed by the operating system.</exception>
		// Token: 0x06006014 RID: 24596 RVA: 0x00148A64 File Offset: 0x00146C64
		[SecurityCritical]
		public unsafe static IntPtr StringToHGlobalUni(string s)
		{
			if (s == null)
			{
				return IntPtr.Zero;
			}
			int num = (s.Length + 1) * 2;
			if (num < s.Length)
			{
				throw new ArgumentOutOfRangeException("s");
			}
			UIntPtr sizetdwBytes = new UIntPtr((uint)num);
			IntPtr intPtr = Win32Native.LocalAlloc_NoSafeHandle(0, sizetdwBytes);
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			fixed (string text = s)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				string.wstrcpy((char*)((void*)intPtr), ptr, s.Length + 1);
			}
			return intPtr;
		}

		/// <summary>Copies the contents of a managed <see cref="T:System.String" /> into unmanaged memory, converting into ANSI format if required.</summary>
		/// <param name="s">A managed string to be copied.</param>
		/// <returns>The address, in unmanaged memory, to where the string was copied, or 0 if <paramref name="s" /> is <see langword="null" />.</returns>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory available.</exception>
		// Token: 0x06006015 RID: 24597 RVA: 0x00148AE6 File Offset: 0x00146CE6
		[SecurityCritical]
		public static IntPtr StringToHGlobalAuto(string s)
		{
			return Marshal.StringToHGlobalUni(s);
		}

		/// <summary>Retrieves the name of a type library.</summary>
		/// <param name="pTLB">The type library whose name is to be retrieved.</param>
		/// <returns>The name of the type library that the <paramref name="pTLB" /> parameter points to.</returns>
		// Token: 0x06006016 RID: 24598 RVA: 0x00148AEE File Offset: 0x00146CEE
		[SecurityCritical]
		[Obsolete("Use System.Runtime.InteropServices.Marshal.GetTypeLibName(ITypeLib pTLB) instead. http://go.microsoft.com/fwlink/?linkid=14202&ID=0000011.", false)]
		public static string GetTypeLibName(UCOMITypeLib pTLB)
		{
			return Marshal.GetTypeLibName((ITypeLib)pTLB);
		}

		/// <summary>Retrieves the name of a type library.</summary>
		/// <param name="typelib">The type library whose name is to be retrieved.</param>
		/// <returns>The name of the type library that the <paramref name="typelib" /> parameter points to.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="typelib" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06006017 RID: 24599 RVA: 0x00148AFC File Offset: 0x00146CFC
		[SecurityCritical]
		public static string GetTypeLibName(ITypeLib typelib)
		{
			if (typelib == null)
			{
				throw new ArgumentNullException("typelib");
			}
			string result = null;
			string text = null;
			int num = 0;
			string text2 = null;
			typelib.GetDocumentation(-1, out result, out text, out num, out text2);
			return result;
		}

		// Token: 0x06006018 RID: 24600 RVA: 0x00148B30 File Offset: 0x00146D30
		[SecurityCritical]
		internal static string GetTypeLibNameInternal(ITypeLib typelib)
		{
			if (typelib == null)
			{
				throw new ArgumentNullException("typelib");
			}
			ITypeLib2 typeLib = typelib as ITypeLib2;
			if (typeLib != null)
			{
				Guid managedNameGuid = Marshal.ManagedNameGuid;
				object obj;
				try
				{
					typeLib.GetCustData(ref managedNameGuid, out obj);
				}
				catch (Exception)
				{
					obj = null;
				}
				if (obj != null && obj.GetType() == typeof(string))
				{
					string text = (string)obj;
					text = text.Trim();
					if (text.EndsWith(".DLL", StringComparison.OrdinalIgnoreCase))
					{
						text = text.Substring(0, text.Length - 4);
					}
					else if (text.EndsWith(".EXE", StringComparison.OrdinalIgnoreCase))
					{
						text = text.Substring(0, text.Length - 4);
					}
					return text;
				}
			}
			return Marshal.GetTypeLibName(typelib);
		}

		/// <summary>Retrieves the library identifier (LIBID) of a type library.</summary>
		/// <param name="pTLB">The type library whose LIBID is to be retrieved.</param>
		/// <returns>The LIBID of the type library that the <paramref name="pTLB" /> parameter points to.</returns>
		// Token: 0x06006019 RID: 24601 RVA: 0x00148BEC File Offset: 0x00146DEC
		[SecurityCritical]
		[Obsolete("Use System.Runtime.InteropServices.Marshal.GetTypeLibGuid(ITypeLib pTLB) instead. http://go.microsoft.com/fwlink/?linkid=14202&ID=0000011.", false)]
		public static Guid GetTypeLibGuid(UCOMITypeLib pTLB)
		{
			return Marshal.GetTypeLibGuid((ITypeLib)pTLB);
		}

		/// <summary>Retrieves the library identifier (LIBID) of a type library.</summary>
		/// <param name="typelib">The type library whose LIBID is to be retrieved.</param>
		/// <returns>The LIBID of the specified type library.</returns>
		// Token: 0x0600601A RID: 24602 RVA: 0x00148BFC File Offset: 0x00146DFC
		[SecurityCritical]
		public static Guid GetTypeLibGuid(ITypeLib typelib)
		{
			Guid result = default(Guid);
			Marshal.FCallGetTypeLibGuid(ref result, typelib);
			return result;
		}

		// Token: 0x0600601B RID: 24603
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FCallGetTypeLibGuid(ref Guid result, ITypeLib pTLB);

		/// <summary>Retrieves the LCID of a type library.</summary>
		/// <param name="pTLB">The type library whose LCID is to be retrieved.</param>
		/// <returns>The LCID of the type library that the <paramref name="pTLB" /> parameter points to.</returns>
		// Token: 0x0600601C RID: 24604 RVA: 0x00148C1A File Offset: 0x00146E1A
		[SecurityCritical]
		[Obsolete("Use System.Runtime.InteropServices.Marshal.GetTypeLibLcid(ITypeLib pTLB) instead. http://go.microsoft.com/fwlink/?linkid=14202&ID=0000011.", false)]
		public static int GetTypeLibLcid(UCOMITypeLib pTLB)
		{
			return Marshal.GetTypeLibLcid((ITypeLib)pTLB);
		}

		/// <summary>Retrieves the LCID of a type library.</summary>
		/// <param name="typelib">The type library whose LCID is to be retrieved.</param>
		/// <returns>The LCID of the type library that the <paramref name="typelib" /> parameter points to.</returns>
		// Token: 0x0600601D RID: 24605
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetTypeLibLcid(ITypeLib typelib);

		// Token: 0x0600601E RID: 24606
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void GetTypeLibVersion(ITypeLib typeLibrary, out int major, out int minor);

		// Token: 0x0600601F RID: 24607 RVA: 0x00148C28 File Offset: 0x00146E28
		[SecurityCritical]
		internal static Guid GetTypeInfoGuid(ITypeInfo typeInfo)
		{
			Guid result = default(Guid);
			Marshal.FCallGetTypeInfoGuid(ref result, typeInfo);
			return result;
		}

		// Token: 0x06006020 RID: 24608
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FCallGetTypeInfoGuid(ref Guid result, ITypeInfo typeInfo);

		/// <summary>Retrieves the library identifier (LIBID) that is assigned to a type library when it was exported from the specified assembly.</summary>
		/// <param name="asm">The assembly from which the type library was exported.</param>
		/// <returns>The LIBID that is assigned to a type library when it is exported from the specified assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="asm" /> is <see langword="null" />.</exception>
		// Token: 0x06006021 RID: 24609 RVA: 0x00148C48 File Offset: 0x00146E48
		[SecurityCritical]
		public static Guid GetTypeLibGuidForAssembly(Assembly asm)
		{
			if (asm == null)
			{
				throw new ArgumentNullException("asm");
			}
			RuntimeAssembly runtimeAssembly = asm as RuntimeAssembly;
			if (runtimeAssembly == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeAssembly"), "asm");
			}
			Guid result = default(Guid);
			Marshal.FCallGetTypeLibGuidForAssembly(ref result, runtimeAssembly);
			return result;
		}

		// Token: 0x06006022 RID: 24610
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FCallGetTypeLibGuidForAssembly(ref Guid result, RuntimeAssembly asm);

		// Token: 0x06006023 RID: 24611
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void _GetTypeLibVersionForAssembly(RuntimeAssembly inputAssembly, out int majorVersion, out int minorVersion);

		/// <summary>Retrieves the version number of a type library that will be exported from the specified assembly.</summary>
		/// <param name="inputAssembly">A managed assembly.</param>
		/// <param name="majorVersion">The major version number.</param>
		/// <param name="minorVersion">The minor version number.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="inputAssembly" /> is <see langword="null" />.</exception>
		// Token: 0x06006024 RID: 24612 RVA: 0x00148CA0 File Offset: 0x00146EA0
		[SecurityCritical]
		public static void GetTypeLibVersionForAssembly(Assembly inputAssembly, out int majorVersion, out int minorVersion)
		{
			if (inputAssembly == null)
			{
				throw new ArgumentNullException("inputAssembly");
			}
			RuntimeAssembly runtimeAssembly = inputAssembly as RuntimeAssembly;
			if (runtimeAssembly == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeAssembly"), "inputAssembly");
			}
			Marshal._GetTypeLibVersionForAssembly(runtimeAssembly, out majorVersion, out minorVersion);
		}

		/// <summary>Retrieves the name of the type represented by an ITypeInfo object.</summary>
		/// <param name="pTI">An object that represents an <see langword="ITypeInfo" /> pointer.</param>
		/// <returns>The name of the type that the <paramref name="pTI" /> parameter points to.</returns>
		// Token: 0x06006025 RID: 24613 RVA: 0x00148CEE File Offset: 0x00146EEE
		[SecurityCritical]
		[Obsolete("Use System.Runtime.InteropServices.Marshal.GetTypeInfoName(ITypeInfo pTLB) instead. http://go.microsoft.com/fwlink/?linkid=14202&ID=0000011.", false)]
		public static string GetTypeInfoName(UCOMITypeInfo pTI)
		{
			return Marshal.GetTypeInfoName((ITypeInfo)pTI);
		}

		/// <summary>Retrieves the name of the type represented by an ITypeInfo object.</summary>
		/// <param name="typeInfo">An object that represents an <see langword="ITypeInfo" /> pointer.</param>
		/// <returns>The name of the type that the <paramref name="typeInfo" /> parameter points to.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="typeInfo" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06006026 RID: 24614 RVA: 0x00148CFC File Offset: 0x00146EFC
		[SecurityCritical]
		public static string GetTypeInfoName(ITypeInfo typeInfo)
		{
			if (typeInfo == null)
			{
				throw new ArgumentNullException("typeInfo");
			}
			string result = null;
			string text = null;
			int num = 0;
			string text2 = null;
			typeInfo.GetDocumentation(-1, out result, out text, out num, out text2);
			return result;
		}

		// Token: 0x06006027 RID: 24615 RVA: 0x00148D30 File Offset: 0x00146F30
		[SecurityCritical]
		internal static string GetTypeInfoNameInternal(ITypeInfo typeInfo, out bool hasManagedName)
		{
			if (typeInfo == null)
			{
				throw new ArgumentNullException("typeInfo");
			}
			ITypeInfo2 typeInfo2 = typeInfo as ITypeInfo2;
			if (typeInfo2 != null)
			{
				Guid managedNameGuid = Marshal.ManagedNameGuid;
				object obj;
				try
				{
					typeInfo2.GetCustData(ref managedNameGuid, out obj);
				}
				catch (Exception)
				{
					obj = null;
				}
				if (obj != null && obj.GetType() == typeof(string))
				{
					hasManagedName = true;
					return (string)obj;
				}
			}
			hasManagedName = false;
			return Marshal.GetTypeInfoName(typeInfo);
		}

		// Token: 0x06006028 RID: 24616 RVA: 0x00148DAC File Offset: 0x00146FAC
		[SecurityCritical]
		internal static string GetManagedTypeInfoNameInternal(ITypeLib typeLib, ITypeInfo typeInfo)
		{
			bool flag;
			string typeInfoNameInternal = Marshal.GetTypeInfoNameInternal(typeInfo, out flag);
			if (flag)
			{
				return typeInfoNameInternal;
			}
			return Marshal.GetTypeLibNameInternal(typeLib) + "." + typeInfoNameInternal;
		}

		// Token: 0x06006029 RID: 24617
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Type GetLoadedTypeForGUID(ref Guid guid);

		/// <summary>Converts an unmanaged ITypeInfo object into a managed <see cref="T:System.Type" /> object.</summary>
		/// <param name="piTypeInfo">The <see langword="ITypeInfo" /> interface to marshal.</param>
		/// <returns>A managed type that represents the unmanaged <see langword="ITypeInfo" /> object.</returns>
		// Token: 0x0600602A RID: 24618 RVA: 0x00148DD8 File Offset: 0x00146FD8
		[SecurityCritical]
		public static Type GetTypeForITypeInfo(IntPtr piTypeInfo)
		{
			ITypeInfo typeInfo = null;
			ITypeLib typeLib = null;
			Assembly assembly = null;
			int num = 0;
			if (piTypeInfo == IntPtr.Zero)
			{
				return null;
			}
			typeInfo = (ITypeInfo)Marshal.GetObjectForIUnknown(piTypeInfo);
			Guid typeInfoGuid = Marshal.GetTypeInfoGuid(typeInfo);
			Type type = Marshal.GetLoadedTypeForGUID(ref typeInfoGuid);
			if (type != null)
			{
				return type;
			}
			try
			{
				typeInfo.GetContainingTypeLib(out typeLib, out num);
			}
			catch (COMException)
			{
				typeLib = null;
			}
			if (typeLib != null)
			{
				AssemblyName assemblyNameFromTypelib = TypeLibConverter.GetAssemblyNameFromTypelib(typeLib, null, null, null, null, AssemblyNameFlags.None);
				string fullName = assemblyNameFromTypelib.FullName;
				Assembly[] assemblies = Thread.GetDomain().GetAssemblies();
				int num2 = assemblies.Length;
				for (int i = 0; i < num2; i++)
				{
					if (string.Compare(assemblies[i].FullName, fullName, StringComparison.Ordinal) == 0)
					{
						assembly = assemblies[i];
					}
				}
				if (assembly == null)
				{
					TypeLibConverter typeLibConverter = new TypeLibConverter();
					assembly = typeLibConverter.ConvertTypeLibToAssembly(typeLib, Marshal.GetTypeLibName(typeLib) + ".dll", TypeLibImporterFlags.None, new ImporterCallback(), null, null, null, null);
				}
				type = assembly.GetType(Marshal.GetManagedTypeInfoNameInternal(typeLib, typeInfo), true, false);
				if (type != null && !type.IsVisible)
				{
					type = null;
				}
			}
			else
			{
				type = typeof(object);
			}
			return type;
		}

		/// <summary>Returns the type associated with the specified class identifier (CLSID).</summary>
		/// <param name="clsid">The CLSID of the type to return.</param>
		/// <returns>
		///   <see langword="System.__ComObject" /> regardless of whether the CLSID is valid.</returns>
		// Token: 0x0600602B RID: 24619 RVA: 0x00148F08 File Offset: 0x00147108
		[SecuritySafeCritical]
		public static Type GetTypeFromCLSID(Guid clsid)
		{
			return RuntimeType.GetTypeFromCLSIDImpl(clsid, null, false);
		}

		/// <summary>Returns a <see cref="T:System.Runtime.InteropServices.ComTypes.ITypeInfo" /> interface from a managed type.</summary>
		/// <param name="t">The type whose <see langword="ITypeInfo" /> interface is being requested.</param>
		/// <returns>A pointer to the <see langword="ITypeInfo" /> interface for the <paramref name="t" /> parameter.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="t" /> is not a visible type to COM.  
		/// -or-  
		/// <paramref name="t" /> is a Windows Runtime type.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.COMException">A type library is registered for the assembly that contains the type, but the type definition cannot be found.</exception>
		// Token: 0x0600602C RID: 24620
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetITypeInfoForType(Type t);

		/// <summary>Returns an IUnknown interface from a managed object.</summary>
		/// <param name="o">The object whose <see langword="IUnknown" /> interface is requested.</param>
		/// <returns>The <see langword="IUnknown" /> pointer for the <paramref name="o" /> parameter.</returns>
		// Token: 0x0600602D RID: 24621 RVA: 0x00148F12 File Offset: 0x00147112
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static IntPtr GetIUnknownForObject(object o)
		{
			return Marshal.GetIUnknownForObjectNative(o, false);
		}

		/// <summary>Returns an IUnknown interface from a managed object, if the caller is in the same context as that object.</summary>
		/// <param name="o">The object whose <see langword="IUnknown" /> interface is requested.</param>
		/// <returns>The <see langword="IUnknown" /> pointer for the specified object, or <see langword="null" /> if the caller is not in the same context as the specified object.</returns>
		// Token: 0x0600602E RID: 24622 RVA: 0x00148F1B File Offset: 0x0014711B
		[SecurityCritical]
		public static IntPtr GetIUnknownForObjectInContext(object o)
		{
			return Marshal.GetIUnknownForObjectNative(o, true);
		}

		// Token: 0x0600602F RID: 24623
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetIUnknownForObjectNative(object o, bool onlyInContext);

		// Token: 0x06006030 RID: 24624
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr GetRawIUnknownForComObjectNoAddRef(object o);

		/// <summary>Returns an IDispatch interface from a managed object.</summary>
		/// <param name="o">The object whose <see langword="IDispatch" /> interface is requested.</param>
		/// <returns>The <see langword="IDispatch" /> pointer for the <paramref name="o" /> parameter.</returns>
		/// <exception cref="T:System.InvalidCastException">
		///   <paramref name="o" /> does not support the requested interface.</exception>
		// Token: 0x06006031 RID: 24625 RVA: 0x00148F24 File Offset: 0x00147124
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static IntPtr GetIDispatchForObject(object o)
		{
			return Marshal.GetIDispatchForObjectNative(o, false);
		}

		/// <summary>Returns an IDispatch interface pointer from a managed object, if the caller is in the same context as that object.</summary>
		/// <param name="o">The object whose <see langword="IDispatch" /> interface is requested.</param>
		/// <returns>The <see langword="IDispatch" /> interface pointer for the specified object, or <see langword="null" /> if the caller is not in the same context as the specified object.</returns>
		/// <exception cref="T:System.InvalidCastException">
		///   <paramref name="o" /> does not support the requested interface.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="o" /> is <see langword="null" />.</exception>
		// Token: 0x06006032 RID: 24626 RVA: 0x00148F2D File Offset: 0x0014712D
		[SecurityCritical]
		public static IntPtr GetIDispatchForObjectInContext(object o)
		{
			return Marshal.GetIDispatchForObjectNative(o, true);
		}

		// Token: 0x06006033 RID: 24627
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetIDispatchForObjectNative(object o, bool onlyInContext);

		/// <summary>Returns a pointer to an IUnknown interface that represents the specified interface on the specified object. Custom query interface access is enabled by default.</summary>
		/// <param name="o">The object that provides the interface.</param>
		/// <param name="T">The type of interface that is requested.</param>
		/// <returns>The interface pointer that represents the specified interface for the object.</returns>
		/// <exception cref="T:System.ArgumentException">The <typeparamref name="T" /> parameter is not an interface.  
		///  -or-  
		///  The type is not visible to COM.  
		///  -or-  
		///  The <typeparamref name="T" /> parameter is a generic type definition.</exception>
		/// <exception cref="T:System.InvalidCastException">The <paramref name="o" /> parameter does not support the requested interface.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="o" /> parameter is <see langword="null" />.  
		///  -or-  
		///  The <typeparamref name="T" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06006034 RID: 24628 RVA: 0x00148F36 File Offset: 0x00147136
		[SecurityCritical]
		public static IntPtr GetComInterfaceForObject(object o, Type T)
		{
			return Marshal.GetComInterfaceForObjectNative(o, T, false, true);
		}

		/// <summary>[Supported in the .NET Framework 4.5.1 and later versions]  
		///  Returns a pointer to an IUnknown interface that represents the specified interface on an object of the specified type. Custom query interface access is enabled by default.</summary>
		/// <param name="o">The object that provides the interface.</param>
		/// <typeparam name="T">The type of <paramref name="o" />.</typeparam>
		/// <typeparam name="TInterface">The type of interface to return.</typeparam>
		/// <returns>The interface pointer that represents the <paramref name="TInterface" /> interface.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="TInterface" /> parameter is not an interface.  
		///  -or-  
		///  The type is not visible to COM.  
		///  -or-  
		///  The <typeparamref name="T" /> parameter is an open generic type.</exception>
		/// <exception cref="T:System.InvalidCastException">The <paramref name="o" /> parameter does not support the <paramref name="TInterface" /> interface.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="o" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06006035 RID: 24629 RVA: 0x00148F41 File Offset: 0x00147141
		[SecurityCritical]
		public static IntPtr GetComInterfaceForObject<T, TInterface>(T o)
		{
			return Marshal.GetComInterfaceForObject(o, typeof(TInterface));
		}

		/// <summary>Returns a pointer to an IUnknown interface that represents the specified interface on the specified object. Custom query interface access is controlled by the specified customization mode.</summary>
		/// <param name="o">The object that provides the interface.</param>
		/// <param name="T">The type of interface that is requested.</param>
		/// <param name="mode">One of the enumeration values that indicates whether to apply an <see langword="IUnknown::QueryInterface" /> customization that is supplied by an <see cref="T:System.Runtime.InteropServices.ICustomQueryInterface" />.</param>
		/// <returns>The interface pointer that represents the interface for the object.</returns>
		/// <exception cref="T:System.ArgumentException">The <typeparamref name="T" /> parameter is not an interface.  
		///  -or-  
		///  The type is not visible to COM.  
		///  -or-  
		///  The <typeparamref name="T" /> parameter is a generic type definition.</exception>
		/// <exception cref="T:System.InvalidCastException">The object <paramref name="o" /> does not support the requested interface.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="o" /> parameter is <see langword="null" />.  
		///  -or-  
		///  The <typeparamref name="T" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06006036 RID: 24630 RVA: 0x00148F58 File Offset: 0x00147158
		[SecurityCritical]
		public static IntPtr GetComInterfaceForObject(object o, Type T, CustomQueryInterfaceMode mode)
		{
			bool fEnalbeCustomizedQueryInterface = mode == CustomQueryInterfaceMode.Allow;
			return Marshal.GetComInterfaceForObjectNative(o, T, false, fEnalbeCustomizedQueryInterface);
		}

		/// <summary>Returns an interface pointer that represents the specified interface for an object, if the caller is in the same context as that object.</summary>
		/// <param name="o">The object that provides the interface.</param>
		/// <param name="t">The type of interface that is requested.</param>
		/// <returns>The interface pointer specified by <paramref name="t" /> that represents the interface for the specified object, or <see langword="null" /> if the caller is not in the same context as the object.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="t" /> is not an interface.  
		/// -or-  
		/// The type is not visible to COM.</exception>
		/// <exception cref="T:System.InvalidCastException">
		///   <paramref name="o" /> does not support the requested interface.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="o" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="t" /> is <see langword="null" />.</exception>
		// Token: 0x06006037 RID: 24631 RVA: 0x00148F77 File Offset: 0x00147177
		[SecurityCritical]
		public static IntPtr GetComInterfaceForObjectInContext(object o, Type t)
		{
			return Marshal.GetComInterfaceForObjectNative(o, t, true, true);
		}

		// Token: 0x06006038 RID: 24632
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetComInterfaceForObjectNative(object o, Type t, bool onlyInContext, bool fEnalbeCustomizedQueryInterface);

		/// <summary>Returns an instance of a type that represents a COM object by a pointer to its IUnknown interface.</summary>
		/// <param name="pUnk">A pointer to the <see langword="IUnknown" /> interface.</param>
		/// <returns>An object that represents the specified unmanaged COM object.</returns>
		// Token: 0x06006039 RID: 24633
		[SecurityCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern object GetObjectForIUnknown(IntPtr pUnk);

		/// <summary>Creates a unique Runtime Callable Wrapper (RCW) object for a given IUnknown interface.</summary>
		/// <param name="unknown">A managed pointer to an <see langword="IUnknown" /> interface.</param>
		/// <returns>A unique RCW for the specified <see langword="IUnknown" /> interface.</returns>
		// Token: 0x0600603A RID: 24634
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern object GetUniqueObjectForIUnknown(IntPtr unknown);

		/// <summary>Returns a managed object of a specified type that represents a COM object.</summary>
		/// <param name="pUnk">A pointer to the <see langword="IUnknown" /> interface of the unmanaged object.</param>
		/// <param name="t">The type of the requested managed class.</param>
		/// <returns>An instance of the class corresponding to the <see cref="T:System.Type" /> object that represents the requested unmanaged COM object.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="t" /> is not attributed with <see cref="T:System.Runtime.InteropServices.ComImportAttribute" />.  
		/// -or-  
		/// <paramref name="t" /> is a Windows Runtime type.</exception>
		// Token: 0x0600603B RID: 24635
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern object GetTypedObjectForIUnknown(IntPtr pUnk, Type t);

		/// <summary>Aggregates a managed object with the specified COM object.</summary>
		/// <param name="pOuter">The outer <see langword="IUnknown" /> pointer.</param>
		/// <param name="o">An object to aggregate.</param>
		/// <returns>The inner <see langword="IUnknown" /> pointer of the managed object.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="o" /> is a Windows Runtime object.</exception>
		// Token: 0x0600603C RID: 24636
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr CreateAggregatedObject(IntPtr pOuter, object o);

		/// <summary>[Supported in the .NET Framework 4.5.1 and later versions]  
		///  Aggregates a managed object of the specified type with the specified COM object.</summary>
		/// <param name="pOuter">The outer IUnknown pointer.</param>
		/// <param name="o">The managed object to aggregate.</param>
		/// <typeparam name="T">The type of the managed object to aggregate.</typeparam>
		/// <returns>The inner IUnknown pointer of the managed object.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="o" /> is a Windows Runtime object.</exception>
		// Token: 0x0600603D RID: 24637 RVA: 0x00148F82 File Offset: 0x00147182
		[SecurityCritical]
		public static IntPtr CreateAggregatedObject<T>(IntPtr pOuter, T o)
		{
			return Marshal.CreateAggregatedObject(pOuter, o);
		}

		/// <summary>Notifies the runtime to clean up all Runtime Callable Wrappers (RCWs) allocated in the current context.</summary>
		// Token: 0x0600603E RID: 24638
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void CleanupUnusedObjectsInCurrentContext();

		/// <summary>Indicates whether runtime callable wrappers (RCWs) from any context are available for cleanup.</summary>
		/// <returns>
		///   <see langword="true" /> if there are any RCWs available for cleanup; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600603F RID: 24639
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool AreComObjectsAvailableForCleanup();

		/// <summary>Indicates whether a specified object represents a COM object.</summary>
		/// <param name="o">The object to check.</param>
		/// <returns>
		///   <see langword="true" /> if the <paramref name="o" /> parameter is a COM type; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="o" /> is <see langword="null" />.</exception>
		// Token: 0x06006040 RID: 24640
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsComObject(object o);

		/// <summary>Allocates a block of memory of specified size from the COM task memory allocator.</summary>
		/// <param name="cb">The size of the block of memory to be allocated.</param>
		/// <returns>An integer representing the address of the block of memory allocated. This memory must be released with <see cref="M:System.Runtime.InteropServices.Marshal.FreeCoTaskMem(System.IntPtr)" />.</returns>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory to satisfy the request.</exception>
		// Token: 0x06006041 RID: 24641 RVA: 0x00148F90 File Offset: 0x00147190
		[SecurityCritical]
		public static IntPtr AllocCoTaskMem(int cb)
		{
			IntPtr intPtr = Win32Native.CoTaskMemAlloc(new UIntPtr((uint)cb));
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			return intPtr;
		}

		/// <summary>Copies the contents of a managed <see cref="T:System.String" /> to a block of memory allocated from the unmanaged COM task allocator.</summary>
		/// <param name="s">A managed string to be copied.</param>
		/// <returns>An integer representing a pointer to the block of memory allocated for the string, or 0 if s is <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="s" /> parameter exceeds the maximum length allowed by the operating system.</exception>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory available.</exception>
		// Token: 0x06006042 RID: 24642 RVA: 0x00148FC0 File Offset: 0x001471C0
		[SecurityCritical]
		public unsafe static IntPtr StringToCoTaskMemUni(string s)
		{
			if (s == null)
			{
				return IntPtr.Zero;
			}
			int num = (s.Length + 1) * 2;
			if (num < s.Length)
			{
				throw new ArgumentOutOfRangeException("s");
			}
			IntPtr intPtr = Win32Native.CoTaskMemAlloc(new UIntPtr((uint)num));
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			fixed (string text = s)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				string.wstrcpy((char*)((void*)intPtr), ptr, s.Length + 1);
			}
			return intPtr;
		}

		/// <summary>Copies the contents of a managed <see cref="T:System.String" /> to a block of memory allocated from the unmanaged COM task allocator.</summary>
		/// <param name="s">A managed string to be copied.</param>
		/// <returns>The allocated memory block, or 0 if <paramref name="s" /> is <see langword="null" />.</returns>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory available.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The length for <paramref name="s" /> is out of range.</exception>
		// Token: 0x06006043 RID: 24643 RVA: 0x0014903B File Offset: 0x0014723B
		[SecurityCritical]
		public static IntPtr StringToCoTaskMemAuto(string s)
		{
			return Marshal.StringToCoTaskMemUni(s);
		}

		/// <summary>Copies the contents of a managed <see cref="T:System.String" /> to a block of memory allocated from the unmanaged COM task allocator.</summary>
		/// <param name="s">A managed string to be copied.</param>
		/// <returns>An integer representing a pointer to the block of memory allocated for the string, or 0 if <paramref name="s" /> is <see langword="null" />.</returns>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory available.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="s" /> parameter exceeds the maximum length allowed by the operating system.</exception>
		// Token: 0x06006044 RID: 24644 RVA: 0x00149044 File Offset: 0x00147244
		[SecurityCritical]
		public unsafe static IntPtr StringToCoTaskMemAnsi(string s)
		{
			if (s == null)
			{
				return IntPtr.Zero;
			}
			int num = (s.Length + 1) * Marshal.SystemMaxDBCSCharSize;
			if (num < s.Length)
			{
				throw new ArgumentOutOfRangeException("s");
			}
			IntPtr intPtr = Win32Native.CoTaskMemAlloc(new UIntPtr((uint)num));
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			s.ConvertToAnsi((byte*)((void*)intPtr), num, false, false);
			return intPtr;
		}

		/// <summary>Frees a block of memory allocated by the unmanaged COM task memory allocator.</summary>
		/// <param name="ptr">The address of the memory to be freed.</param>
		// Token: 0x06006045 RID: 24645 RVA: 0x001490AD File Offset: 0x001472AD
		[SecurityCritical]
		public static void FreeCoTaskMem(IntPtr ptr)
		{
			if (Marshal.IsNotWin32Atom(ptr))
			{
				Win32Native.CoTaskMemFree(ptr);
			}
		}

		/// <summary>Resizes a block of memory previously allocated with <see cref="M:System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Int32)" />.</summary>
		/// <param name="pv">A pointer to memory allocated with <see cref="M:System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Int32)" />.</param>
		/// <param name="cb">The new size of the allocated block.</param>
		/// <returns>An integer representing the address of the reallocated block of memory. This memory must be released with <see cref="M:System.Runtime.InteropServices.Marshal.FreeCoTaskMem(System.IntPtr)" />.</returns>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory to satisfy the request.</exception>
		// Token: 0x06006046 RID: 24646 RVA: 0x001490C0 File Offset: 0x001472C0
		[SecurityCritical]
		public static IntPtr ReAllocCoTaskMem(IntPtr pv, int cb)
		{
			IntPtr intPtr = Win32Native.CoTaskMemRealloc(pv, new UIntPtr((uint)cb));
			if (intPtr == IntPtr.Zero && cb != 0)
			{
				throw new OutOfMemoryException();
			}
			return intPtr;
		}

		/// <summary>Decrements the reference count of the Runtime Callable Wrapper (RCW) associated with the specified COM object.</summary>
		/// <param name="o">The COM object to release.</param>
		/// <returns>The new value of the reference count of the RCW associated with <paramref name="o" />. This value is typically zero since the RCW keeps just one reference to the wrapped COM object regardless of the number of managed clients calling it.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="o" /> is not a valid COM object.</exception>
		/// <exception cref="T:System.NullReferenceException">
		///   <paramref name="o" /> is <see langword="null" />.</exception>
		// Token: 0x06006047 RID: 24647 RVA: 0x001490F4 File Offset: 0x001472F4
		[SecurityCritical]
		public static int ReleaseComObject(object o)
		{
			__ComObject _ComObject = null;
			try
			{
				_ComObject = (__ComObject)o;
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ObjNotComObject"), "o");
			}
			return _ComObject.ReleaseSelf();
		}

		// Token: 0x06006048 RID: 24648
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int InternalReleaseComObject(object o);

		/// <summary>Releases all references to a Runtime Callable Wrapper (RCW) by setting its reference count to 0.</summary>
		/// <param name="o">The RCW to be released.</param>
		/// <returns>The new value of the reference count of the RCW associated with the <paramref name="o" /> parameter, which is 0 (zero) if the release is successful.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="o" /> is not a valid COM object.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="o" /> is <see langword="null" />.</exception>
		// Token: 0x06006049 RID: 24649 RVA: 0x00149138 File Offset: 0x00147338
		[SecurityCritical]
		public static int FinalReleaseComObject(object o)
		{
			if (o == null)
			{
				throw new ArgumentNullException("o");
			}
			__ComObject _ComObject = null;
			try
			{
				_ComObject = (__ComObject)o;
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ObjNotComObject"), "o");
			}
			_ComObject.FinalReleaseSelf();
			return 0;
		}

		// Token: 0x0600604A RID: 24650
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void InternalFinalReleaseComObject(object o);

		/// <summary>Retrieves data that is referenced by the specified key from the specified COM object.</summary>
		/// <param name="obj">The COM object that contains the data that you want.</param>
		/// <param name="key">The key in the internal hash table of <paramref name="obj" /> to retrieve the data from.</param>
		/// <returns>The data represented by the <paramref name="key" /> parameter in the internal hash table of the <paramref name="obj" /> parameter.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="obj" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="key" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="obj" /> is not a COM object.  
		/// -or-  
		/// <paramref name="obj" /> is a Windows Runtime object.</exception>
		// Token: 0x0600604B RID: 24651 RVA: 0x0014918C File Offset: 0x0014738C
		[SecurityCritical]
		public static object GetComObjectData(object obj, object key)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			__ComObject _ComObject = null;
			try
			{
				_ComObject = (__ComObject)obj;
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ObjNotComObject"), "obj");
			}
			if (obj.GetType().IsWindowsRuntimeObject)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ObjIsWinRTObject"), "obj");
			}
			return _ComObject.GetData(key);
		}

		/// <summary>Sets data referenced by the specified key in the specified COM object.</summary>
		/// <param name="obj">The COM object in which to store the data.</param>
		/// <param name="key">The key in the internal hash table of the COM object in which to store the data.</param>
		/// <param name="data">The data to set.</param>
		/// <returns>
		///   <see langword="true" /> if the data was set successfully; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="obj" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="key" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="obj" /> is not a COM object.  
		/// -or-  
		/// <paramref name="obj" /> is a Windows Runtime object.</exception>
		// Token: 0x0600604C RID: 24652 RVA: 0x00149210 File Offset: 0x00147410
		[SecurityCritical]
		public static bool SetComObjectData(object obj, object key, object data)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			__ComObject _ComObject = null;
			try
			{
				_ComObject = (__ComObject)obj;
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ObjNotComObject"), "obj");
			}
			if (obj.GetType().IsWindowsRuntimeObject)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ObjIsWinRTObject"), "obj");
			}
			return _ComObject.SetData(key, data);
		}

		/// <summary>Wraps the specified COM object in an object of the specified type.</summary>
		/// <param name="o">The object to be wrapped.</param>
		/// <param name="t">The type of wrapper to create.</param>
		/// <returns>The newly wrapped object that is an instance of the desired type.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="t" /> must derive from <see langword="__ComObject" />.  
		/// -or-  
		/// <paramref name="t" /> is a Windows Runtime type.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="t" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidCastException">
		///   <paramref name="o" /> cannot be converted to the destination type because it does not support all required interfaces.</exception>
		// Token: 0x0600604D RID: 24653 RVA: 0x00149294 File Offset: 0x00147494
		[SecurityCritical]
		public static object CreateWrapperOfType(object o, Type t)
		{
			if (t == null)
			{
				throw new ArgumentNullException("t");
			}
			if (!t.IsCOMObject)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_TypeNotComObject"), "t");
			}
			if (t.IsGenericType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "t");
			}
			if (t.IsWindowsRuntimeObject)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_TypeIsWinRTType"), "t");
			}
			if (o == null)
			{
				return null;
			}
			if (!o.GetType().IsCOMObject)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ObjNotComObject"), "o");
			}
			if (o.GetType().IsWindowsRuntimeObject)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ObjIsWinRTObject"), "o");
			}
			if (o.GetType() == t)
			{
				return o;
			}
			object obj = Marshal.GetComObjectData(o, t);
			if (obj == null)
			{
				obj = Marshal.InternalCreateWrapperOfType(o, t);
				if (!Marshal.SetComObjectData(o, t, obj))
				{
					obj = Marshal.GetComObjectData(o, t);
				}
			}
			return obj;
		}

		/// <summary>[Supported in the .NET Framework 4.5.1 and later versions]  
		///  Wraps the specified COM object in an object of the specified type.</summary>
		/// <param name="o">The object to be wrapped.</param>
		/// <typeparam name="T">The type of object to wrap.</typeparam>
		/// <typeparam name="TWrapper">The type of object to return.</typeparam>
		/// <returns>The newly wrapped object.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <typeparamref name="T" /> must derive from <see langword="__ComObject" />.  
		/// -or-  
		/// <typeparamref name="T" /> is a Windows Runtime type.</exception>
		/// <exception cref="T:System.InvalidCastException">
		///   <paramref name="o" /> cannot be converted to the <paramref name="TWrapper" /> because it does not support all required interfaces.</exception>
		// Token: 0x0600604E RID: 24654 RVA: 0x0014938B File Offset: 0x0014758B
		[SecurityCritical]
		public static TWrapper CreateWrapperOfType<T, TWrapper>(T o)
		{
			return (TWrapper)((object)Marshal.CreateWrapperOfType(o, typeof(TWrapper)));
		}

		// Token: 0x0600604F RID: 24655
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern object InternalCreateWrapperOfType(object o, Type t);

		/// <summary>Releases the thread cache.</summary>
		// Token: 0x06006050 RID: 24656 RVA: 0x001493A7 File Offset: 0x001475A7
		[SecurityCritical]
		[Obsolete("This API did not perform any operation and will be removed in future versions of the CLR.", false)]
		public static void ReleaseThreadCache()
		{
		}

		/// <summary>Indicates whether a type is visible to COM clients.</summary>
		/// <param name="t">The type to check for COM visibility.</param>
		/// <returns>
		///   <see langword="true" /> if the type is visible to COM; otherwise, <see langword="false" />.</returns>
		// Token: 0x06006051 RID: 24657
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsTypeVisibleFromCom(Type t);

		/// <summary>Requests a pointer to a specified interface from a COM object.</summary>
		/// <param name="pUnk">The interface to be queried.</param>
		/// <param name="iid">The interface identifier (IID) of the requested interface.</param>
		/// <param name="ppv">When this method returns, contains a reference to the returned interface.</param>
		/// <returns>An HRESULT that indicates the success or failure of the call.</returns>
		// Token: 0x06006052 RID: 24658
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int QueryInterface(IntPtr pUnk, ref Guid iid, out IntPtr ppv);

		/// <summary>Increments the reference count on the specified interface.</summary>
		/// <param name="pUnk">The interface reference count to increment.</param>
		/// <returns>The new value of the reference count on the <paramref name="pUnk" /> parameter.</returns>
		// Token: 0x06006053 RID: 24659
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int AddRef(IntPtr pUnk);

		/// <summary>Decrements the reference count on the specified interface.</summary>
		/// <param name="pUnk">The interface to release.</param>
		/// <returns>The new value of the reference count on the interface specified by the <paramref name="pUnk" /> parameter.</returns>
		// Token: 0x06006054 RID: 24660
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int Release(IntPtr pUnk);

		/// <summary>Frees a <see langword="BSTR" /> using the COM SysFreeString function.</summary>
		/// <param name="ptr">The address of the BSTR to be freed.</param>
		// Token: 0x06006055 RID: 24661 RVA: 0x001493A9 File Offset: 0x001475A9
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static void FreeBSTR(IntPtr ptr)
		{
			if (Marshal.IsNotWin32Atom(ptr))
			{
				Win32Native.SysFreeString(ptr);
			}
		}

		/// <summary>Allocates a BSTR and copies the contents of a managed <see cref="T:System.String" /> into it.</summary>
		/// <param name="s">The managed string to be copied.</param>
		/// <returns>An unmanaged pointer to the <see langword="BSTR" />, or 0 if <paramref name="s" /> is null.</returns>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory available.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The length for <paramref name="s" /> is out of range.</exception>
		// Token: 0x06006056 RID: 24662 RVA: 0x001493BC File Offset: 0x001475BC
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static IntPtr StringToBSTR(string s)
		{
			if (s == null)
			{
				return IntPtr.Zero;
			}
			if (s.Length + 1 < s.Length)
			{
				throw new ArgumentOutOfRangeException("s");
			}
			IntPtr intPtr = Win32Native.SysAllocStringLen(s, s.Length);
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			return intPtr;
		}

		/// <summary>Allocates a managed <see cref="T:System.String" /> and copies a binary string (BSTR) stored in unmanaged memory into it.</summary>
		/// <param name="ptr">The address of the first character of the unmanaged string.</param>
		/// <returns>A managed string that holds a copy of the unmanaged string.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="ptr" /> equals <see cref="F:System.IntPtr.Zero" />.</exception>
		// Token: 0x06006057 RID: 24663 RVA: 0x0014940E File Offset: 0x0014760E
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static string PtrToStringBSTR(IntPtr ptr)
		{
			return Marshal.PtrToStringUni(ptr, (int)Win32Native.SysStringLen(ptr));
		}

		/// <summary>Converts an object to a COM VARIANT.</summary>
		/// <param name="obj">The object for which to get a COM VARIANT.</param>
		/// <param name="pDstNativeVariant">A pointer to receive the VARIANT that corresponds to the <paramref name="obj" /> parameter.</param>
		/// <exception cref="T:System.ArgumentException">The <paramref name="obj" /> parameter is an instance of a generic type.</exception>
		// Token: 0x06006058 RID: 24664
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void GetNativeVariantForObject(object obj, IntPtr pDstNativeVariant);

		/// <summary>[Supported in the .NET Framework 4.5.1 and later versions]  
		///  Converts an object of a specified type to a COM VARIANT.</summary>
		/// <param name="obj">The object for which to get a COM VARIANT.</param>
		/// <param name="pDstNativeVariant">A pointer to receive the VARIANT that corresponds to the <paramref name="obj" /> parameter.</param>
		/// <typeparam name="T">The type of the object to convert.</typeparam>
		// Token: 0x06006059 RID: 24665 RVA: 0x0014941C File Offset: 0x0014761C
		[SecurityCritical]
		public static void GetNativeVariantForObject<T>(T obj, IntPtr pDstNativeVariant)
		{
			Marshal.GetNativeVariantForObject(obj, pDstNativeVariant);
		}

		/// <summary>Converts a COM VARIANT to an object.</summary>
		/// <param name="pSrcNativeVariant">A pointer to a COM VARIANT.</param>
		/// <returns>An object that corresponds to the <paramref name="pSrcNativeVariant" /> parameter.</returns>
		/// <exception cref="T:System.Runtime.InteropServices.InvalidOleVariantTypeException">
		///   <paramref name="pSrcNativeVariant" /> is not a valid VARIANT type.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="pSrcNativeVariant" /> has an unsupported type.</exception>
		// Token: 0x0600605A RID: 24666
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern object GetObjectForNativeVariant(IntPtr pSrcNativeVariant);

		/// <summary>[Supported in the .NET Framework 4.5.1 and later versions]  
		///  Converts a COM VARIANT to an object of a specified type.</summary>
		/// <param name="pSrcNativeVariant">A pointer to a COM VARIANT.</param>
		/// <typeparam name="T">The type to which to convert the COM VARIANT.</typeparam>
		/// <returns>An object of the specified type that corresponds to the <paramref name="pSrcNativeVariant" /> parameter.</returns>
		/// <exception cref="T:System.Runtime.InteropServices.InvalidOleVariantTypeException">
		///   <paramref name="pSrcNativeVariant" /> is not a valid VARIANT type.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="pSrcNativeVariant" /> has an unsupported type.</exception>
		// Token: 0x0600605B RID: 24667 RVA: 0x0014942A File Offset: 0x0014762A
		[SecurityCritical]
		public static T GetObjectForNativeVariant<T>(IntPtr pSrcNativeVariant)
		{
			return (T)((object)Marshal.GetObjectForNativeVariant(pSrcNativeVariant));
		}

		/// <summary>Converts an array of COM VARIANTs to an array of objects.</summary>
		/// <param name="aSrcNativeVariant">A pointer to the first element of an array of COM VARIANTs.</param>
		/// <param name="cVars">The count of COM VARIANTs in <paramref name="aSrcNativeVariant" />.</param>
		/// <returns>An object array that corresponds to <paramref name="aSrcNativeVariant" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="cVars" /> is a negative number.</exception>
		// Token: 0x0600605C RID: 24668
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern object[] GetObjectsForNativeVariants(IntPtr aSrcNativeVariant, int cVars);

		/// <summary>[Supported in the .NET Framework 4.5.1 and later versions]  
		///  Converts an array of COM VARIANTs to an array of a specified type.</summary>
		/// <param name="aSrcNativeVariant">A pointer to the first element of an array of COM VARIANTs.</param>
		/// <param name="cVars">The count of COM VARIANTs in <paramref name="aSrcNativeVariant" />.</param>
		/// <typeparam name="T">The type of the array to return.</typeparam>
		/// <returns>An array of <typeparamref name="T" /> objects that corresponds to <paramref name="aSrcNativeVariant" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="cVars" /> is a negative number.</exception>
		// Token: 0x0600605D RID: 24669 RVA: 0x00149438 File Offset: 0x00147638
		[SecurityCritical]
		public static T[] GetObjectsForNativeVariants<T>(IntPtr aSrcNativeVariant, int cVars)
		{
			object[] objectsForNativeVariants = Marshal.GetObjectsForNativeVariants(aSrcNativeVariant, cVars);
			T[] array = null;
			if (objectsForNativeVariants != null)
			{
				array = new T[objectsForNativeVariants.Length];
				Array.Copy(objectsForNativeVariants, array, objectsForNativeVariants.Length);
			}
			return array;
		}

		/// <summary>Gets the first slot in the virtual function table (v-table or VTBL) that contains user-defined methods.</summary>
		/// <param name="t">A type that represents an interface.</param>
		/// <returns>The first VTBL slot that contains user-defined methods. The first slot is 3 if the interface is based on IUnknown, and 7 if the interface is based on IDispatch.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="t" /> is not visible from COM.</exception>
		// Token: 0x0600605E RID: 24670
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetStartComSlot(Type t);

		/// <summary>Retrieves the last slot in the virtual function table (v-table or VTBL) of a type when exposed to COM.</summary>
		/// <param name="t">A type that represents an interface or class.</param>
		/// <returns>The last VTBL slot of the interface when exposed to COM. If the <paramref name="t" /> parameter is a class, the returned VTBL slot is the last slot in the interface that is generated from the class.</returns>
		// Token: 0x0600605F RID: 24671
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetEndComSlot(Type t);

		/// <summary>Retrieves a <see cref="T:System.Reflection.MemberInfo" /> object for the specified virtual function table (v-table or VTBL) slot.</summary>
		/// <param name="t">The type for which the <see cref="T:System.Reflection.MemberInfo" /> is to be retrieved.</param>
		/// <param name="slot">The VTBL slot.</param>
		/// <param name="memberType">On successful return, one of the enumeration values that specifies the type of the member.</param>
		/// <returns>The object that represents the member at the specified VTBL slot.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="t" /> is not visible from COM.</exception>
		// Token: 0x06006060 RID: 24672
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern MemberInfo GetMethodInfoForComSlot(Type t, int slot, ref ComMemberType memberType);

		/// <summary>Retrieves the virtual function table (v-table or VTBL) slot for a specified <see cref="T:System.Reflection.MemberInfo" /> type when that type is exposed to COM.</summary>
		/// <param name="m">An object that represents an interface method.</param>
		/// <returns>The VTBL slot <paramref name="m" /> identifier when it is exposed to COM.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="m" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="m" /> parameter is not a <see cref="T:System.Reflection.MemberInfo" /> object.  
		///  -or-  
		///  The <paramref name="m" /> parameter is not an interface method.</exception>
		// Token: 0x06006061 RID: 24673 RVA: 0x00149468 File Offset: 0x00147668
		[SecurityCritical]
		public static int GetComSlotForMethodInfo(MemberInfo m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			if (!(m is RuntimeMethodInfo))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeMethodInfo"), "m");
			}
			if (!m.DeclaringType.IsInterface)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeInterfaceMethod"), "m");
			}
			if (m.DeclaringType.IsGenericType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "m");
			}
			return Marshal.InternalGetComSlotForMethodInfo((IRuntimeMethodInfo)m);
		}

		// Token: 0x06006062 RID: 24674
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int InternalGetComSlotForMethodInfo(IRuntimeMethodInfo m);

		/// <summary>Returns the globally unique identifier (GUID) for the specified type, or generates a GUID using the algorithm used by the Type Library Exporter (Tlbexp.exe).</summary>
		/// <param name="type">The type to generate a GUID for.</param>
		/// <returns>An identifier for the specified type.</returns>
		// Token: 0x06006063 RID: 24675 RVA: 0x001494F8 File Offset: 0x001476F8
		[SecurityCritical]
		public static Guid GenerateGuidForType(Type type)
		{
			Guid result = default(Guid);
			Marshal.FCallGenerateGuidForType(ref result, type);
			return result;
		}

		// Token: 0x06006064 RID: 24676
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FCallGenerateGuidForType(ref Guid result, Type type);

		/// <summary>Returns a programmatic identifier (ProgID) for the specified type.</summary>
		/// <param name="type">The type to get a ProgID for.</param>
		/// <returns>The ProgID of the specified type.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="type" /> parameter is not a class that can be create by COM. The class must be public, have a public default constructor, and be COM visible.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="type" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06006065 RID: 24677 RVA: 0x00149518 File Offset: 0x00147718
		[SecurityCritical]
		public static string GenerateProgIdForType(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (type.IsImport)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_TypeMustNotBeComImport"), "type");
			}
			if (type.IsGenericType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "type");
			}
			if (!RegistrationServices.TypeRequiresRegistrationHelper(type))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_TypeMustBeComCreatable"), "type");
			}
			IList<CustomAttributeData> customAttributes = CustomAttributeData.GetCustomAttributes(type);
			for (int i = 0; i < customAttributes.Count; i++)
			{
				if (customAttributes[i].Constructor.DeclaringType == typeof(ProgIdAttribute))
				{
					IList<CustomAttributeTypedArgument> constructorArguments = customAttributes[i].ConstructorArguments;
					string text = (string)constructorArguments[0].Value;
					if (text == null)
					{
						text = string.Empty;
					}
					return text;
				}
			}
			return type.FullName;
		}

		/// <summary>Gets an interface pointer identified by the specified moniker.</summary>
		/// <param name="monikerName">The moniker corresponding to the desired interface pointer.</param>
		/// <returns>An object containing a reference to the interface pointer identified by the <paramref name="monikerName" /> parameter. A moniker is a name, and in this case, the moniker is defined by an interface.</returns>
		/// <exception cref="T:System.Runtime.InteropServices.COMException">An unrecognized HRESULT was returned by the unmanaged <see langword="BindToMoniker" /> method.</exception>
		// Token: 0x06006066 RID: 24678 RVA: 0x00149604 File Offset: 0x00147804
		[SecurityCritical]
		public static object BindToMoniker(string monikerName)
		{
			object result = null;
			IBindCtx pbc = null;
			Marshal.CreateBindCtx(0U, out pbc);
			IMoniker pmk = null;
			uint num;
			Marshal.MkParseDisplayName(pbc, monikerName, out num, out pmk);
			Marshal.BindMoniker(pmk, 0U, ref Marshal.IID_IUnknown, out result);
			return result;
		}

		/// <summary>Obtains a running instance of the specified object from the running object table (ROT).</summary>
		/// <param name="progID">The programmatic identifier (ProgID) of the object that was requested.</param>
		/// <returns>The object that was requested; otherwise <see langword="null" />. You can cast this object to any COM interface that it supports.</returns>
		/// <exception cref="T:System.Runtime.InteropServices.COMException">The object was not found.</exception>
		// Token: 0x06006067 RID: 24679 RVA: 0x0014963C File Offset: 0x0014783C
		[SecurityCritical]
		public static object GetActiveObject(string progID)
		{
			object result = null;
			Guid guid;
			try
			{
				Marshal.CLSIDFromProgIDEx(progID, out guid);
			}
			catch (Exception)
			{
				Marshal.CLSIDFromProgID(progID, out guid);
			}
			Marshal.GetActiveObject(ref guid, IntPtr.Zero, out result);
			return result;
		}

		// Token: 0x06006068 RID: 24680
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("ole32.dll", PreserveSig = false)]
		private static extern void CLSIDFromProgIDEx([MarshalAs(UnmanagedType.LPWStr)] string progId, out Guid clsid);

		// Token: 0x06006069 RID: 24681
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("ole32.dll", PreserveSig = false)]
		private static extern void CLSIDFromProgID([MarshalAs(UnmanagedType.LPWStr)] string progId, out Guid clsid);

		// Token: 0x0600606A RID: 24682
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("ole32.dll", PreserveSig = false)]
		private static extern void CreateBindCtx(uint reserved, out IBindCtx ppbc);

		// Token: 0x0600606B RID: 24683
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("ole32.dll", PreserveSig = false)]
		private static extern void MkParseDisplayName(IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] string szUserName, out uint pchEaten, out IMoniker ppmk);

		// Token: 0x0600606C RID: 24684
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("ole32.dll", PreserveSig = false)]
		private static extern void BindMoniker(IMoniker pmk, uint grfOpt, ref Guid iidResult, [MarshalAs(UnmanagedType.Interface)] out object ppvResult);

		// Token: 0x0600606D RID: 24685
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("oleaut32.dll", PreserveSig = false)]
		private static extern void GetActiveObject(ref Guid rclsid, IntPtr reserved, [MarshalAs(UnmanagedType.Interface)] out object ppunk);

		// Token: 0x0600606E RID: 24686
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool InternalSwitchCCW(object oldtp, object newtp);

		// Token: 0x0600606F RID: 24687
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern object InternalWrapIUnknownWithComObject(IntPtr i);

		// Token: 0x06006070 RID: 24688 RVA: 0x00149680 File Offset: 0x00147880
		[SecurityCritical]
		private static IntPtr LoadLicenseManager()
		{
			Assembly assembly = Assembly.Load("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
			Type type = assembly.GetType("System.ComponentModel.LicenseManager");
			if (type == null || !type.IsVisible)
			{
				return IntPtr.Zero;
			}
			return type.TypeHandle.Value;
		}

		/// <summary>Changes the strength of an object's COM Callable Wrapper (CCW) handle.</summary>
		/// <param name="otp">The object whose CCW holds a reference counted handle. The handle is strong if the reference count on the CCW is greater than zero; otherwise, it is weak.</param>
		/// <param name="fIsWeak">
		///   <see langword="true" /> to change the strength of the handle on the <paramref name="otp" /> parameter to weak, regardless of its reference count; <see langword="false" /> to reset the handle strength on <paramref name="otp" /> to be reference counted.</param>
		// Token: 0x06006071 RID: 24689
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ChangeWrapperHandleStrength(object otp, bool fIsWeak);

		// Token: 0x06006072 RID: 24690
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void InitializeWrapperForWinRT(object o, ref IntPtr pUnk);

		// Token: 0x06006073 RID: 24691
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void InitializeManagedWinRTFactoryObject(object o, RuntimeType runtimeClassType);

		// Token: 0x06006074 RID: 24692
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern object GetNativeActivationFactory(Type type);

		// Token: 0x06006075 RID: 24693
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void _GetInspectableIids(ObjectHandleOnStack obj, ObjectHandleOnStack guids);

		// Token: 0x06006076 RID: 24694 RVA: 0x001496CC File Offset: 0x001478CC
		[SecurityCritical]
		internal static Guid[] GetInspectableIids(object obj)
		{
			Guid[] result = null;
			__ComObject _ComObject = obj as __ComObject;
			if (_ComObject != null)
			{
				Marshal._GetInspectableIids(JitHelpers.GetObjectHandleOnStack<__ComObject>(ref _ComObject), JitHelpers.GetObjectHandleOnStack<Guid[]>(ref result));
			}
			return result;
		}

		// Token: 0x06006077 RID: 24695
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void _GetCachedWinRTTypeByIid(ObjectHandleOnStack appDomainObj, Guid iid, out IntPtr rthHandle);

		// Token: 0x06006078 RID: 24696 RVA: 0x001496FC File Offset: 0x001478FC
		[SecurityCritical]
		internal static Type GetCachedWinRTTypeByIid(AppDomain ad, Guid iid)
		{
			IntPtr handle;
			Marshal._GetCachedWinRTTypeByIid(JitHelpers.GetObjectHandleOnStack<AppDomain>(ref ad), iid, out handle);
			return Type.GetTypeFromHandleUnsafe(handle);
		}

		// Token: 0x06006079 RID: 24697
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void _GetCachedWinRTTypes(ObjectHandleOnStack appDomainObj, ref int epoch, ObjectHandleOnStack winrtTypes);

		// Token: 0x0600607A RID: 24698 RVA: 0x00149720 File Offset: 0x00147920
		[SecurityCritical]
		internal static Type[] GetCachedWinRTTypes(AppDomain ad, ref int epoch)
		{
			IntPtr[] array = null;
			Marshal._GetCachedWinRTTypes(JitHelpers.GetObjectHandleOnStack<AppDomain>(ref ad), ref epoch, JitHelpers.GetObjectHandleOnStack<IntPtr[]>(ref array));
			Type[] array2 = new Type[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = Type.GetTypeFromHandleUnsafe(array[i]);
			}
			return array2;
		}

		// Token: 0x0600607B RID: 24699 RVA: 0x00149768 File Offset: 0x00147968
		[SecurityCritical]
		internal static Type[] GetCachedWinRTTypes(AppDomain ad)
		{
			int num = 0;
			return Marshal.GetCachedWinRTTypes(ad, ref num);
		}

		/// <summary>Converts an unmanaged function pointer to a delegate.</summary>
		/// <param name="ptr">The unmanaged function pointer to be converted.</param>
		/// <param name="t">The type of the delegate to be returned.</param>
		/// <returns>A delegate instance that can be cast to the appropriate delegate type.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="t" /> parameter is not a delegate or is generic.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="ptr" /> parameter is <see langword="null" />.  
		///  -or-  
		///  The <paramref name="t" /> parameter is <see langword="null" />.</exception>
		// Token: 0x0600607C RID: 24700 RVA: 0x00149780 File Offset: 0x00147980
		[SecurityCritical]
		public static Delegate GetDelegateForFunctionPointer(IntPtr ptr, Type t)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new ArgumentNullException("ptr");
			}
			if (t == null)
			{
				throw new ArgumentNullException("t");
			}
			if (t as RuntimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"), "t");
			}
			if (t.IsGenericType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "t");
			}
			Type baseType = t.BaseType;
			if (baseType == null || (baseType != typeof(Delegate) && baseType != typeof(MulticastDelegate)))
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeDelegate"), "t");
			}
			return Marshal.GetDelegateForFunctionPointerInternal(ptr, t);
		}

		/// <summary>[Supported in the .NET Framework 4.5.1 and later versions]  
		///  Converts an unmanaged function pointer to a delegate of a specified type.</summary>
		/// <param name="ptr">The unmanaged function pointer to convert.</param>
		/// <typeparam name="TDelegate">The type of the delegate to return.</typeparam>
		/// <returns>A instance of the specified delegate type.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="TDelegate" /> generic parameter is not a delegate, or it is an open generic type.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="ptr" /> parameter is <see langword="null" />.</exception>
		// Token: 0x0600607D RID: 24701 RVA: 0x00149849 File Offset: 0x00147A49
		[SecurityCritical]
		public static TDelegate GetDelegateForFunctionPointer<TDelegate>(IntPtr ptr)
		{
			return (TDelegate)((object)Marshal.GetDelegateForFunctionPointer(ptr, typeof(TDelegate)));
		}

		// Token: 0x0600607E RID: 24702
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Delegate GetDelegateForFunctionPointerInternal(IntPtr ptr, Type t);

		/// <summary>Converts a delegate into a function pointer that is callable from unmanaged code.</summary>
		/// <param name="d">The delegate to be passed to unmanaged code.</param>
		/// <returns>A value that can be passed to unmanaged code, which, in turn, can use it to call the underlying managed delegate.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="d" /> parameter is a generic type definition.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="d" /> parameter is <see langword="null" />.</exception>
		// Token: 0x0600607F RID: 24703 RVA: 0x00149860 File Offset: 0x00147A60
		[SecurityCritical]
		public static IntPtr GetFunctionPointerForDelegate(Delegate d)
		{
			if (d == null)
			{
				throw new ArgumentNullException("d");
			}
			return Marshal.GetFunctionPointerForDelegateInternal(d);
		}

		/// <summary>[Supported in the .NET Framework 4.5.1 and later versions]  
		///  Converts a delegate of a specified type to a function pointer that is callable from unmanaged code.</summary>
		/// <param name="d">The delegate to be passed to unmanaged code.</param>
		/// <typeparam name="TDelegate">The type of delegate to convert.</typeparam>
		/// <returns>A value that can be passed to unmanaged code, which, in turn, can use it to call the underlying managed delegate.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="d" /> parameter is a generic type definition.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="d" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06006080 RID: 24704 RVA: 0x00149876 File Offset: 0x00147A76
		[SecurityCritical]
		public static IntPtr GetFunctionPointerForDelegate<TDelegate>(TDelegate d)
		{
			return Marshal.GetFunctionPointerForDelegate((Delegate)((object)d));
		}

		// Token: 0x06006081 RID: 24705
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr GetFunctionPointerForDelegateInternal(Delegate d);

		/// <summary>Allocates an unmanaged binary string (BSTR) and copies the contents of a managed <see cref="T:System.Security.SecureString" /> object into it.</summary>
		/// <param name="s">The managed object to copy.</param>
		/// <returns>The address, in unmanaged memory, where the <paramref name="s" /> parameter was copied to, or 0 if a null object was supplied.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="s" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The current computer is not running Windows 2000 Service Pack 3 or later.</exception>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory available.</exception>
		// Token: 0x06006082 RID: 24706 RVA: 0x00149888 File Offset: 0x00147A88
		[SecurityCritical]
		public static IntPtr SecureStringToBSTR(SecureString s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			return s.ToBSTR();
		}

		/// <summary>Copies the contents of a managed <see cref="T:System.Security.SecureString" /> object to a block of memory allocated from the unmanaged COM task allocator.</summary>
		/// <param name="s">The managed object to copy.</param>
		/// <returns>The address, in unmanaged memory, where the <paramref name="s" /> parameter was copied to, or 0 if a null object was supplied.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="s" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The current computer is not running Windows 2000 Service Pack 3 or later.</exception>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory available.</exception>
		// Token: 0x06006083 RID: 24707 RVA: 0x0014989E File Offset: 0x00147A9E
		[SecurityCritical]
		public static IntPtr SecureStringToCoTaskMemAnsi(SecureString s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			return s.ToAnsiStr(false);
		}

		/// <summary>Copies the contents of a managed <see cref="T:System.Security.SecureString" /> object to a block of memory allocated from the unmanaged COM task allocator.</summary>
		/// <param name="s">The managed object to copy.</param>
		/// <returns>The address, in unmanaged memory, where the <paramref name="s" /> parameter was copied to, or 0 if a null object was supplied.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="s" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The current computer is not running Windows 2000 Service Pack 3 or later.</exception>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory available.</exception>
		// Token: 0x06006084 RID: 24708 RVA: 0x001498B5 File Offset: 0x00147AB5
		[SecurityCritical]
		public static IntPtr SecureStringToCoTaskMemUnicode(SecureString s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			return s.ToUniStr(false);
		}

		/// <summary>Frees a BSTR pointer that was allocated using the <see cref="M:System.Runtime.InteropServices.Marshal.SecureStringToBSTR(System.Security.SecureString)" /> method.</summary>
		/// <param name="s">The address of the <see langword="BSTR" /> to free.</param>
		// Token: 0x06006085 RID: 24709 RVA: 0x001498CC File Offset: 0x00147ACC
		[SecurityCritical]
		public static void ZeroFreeBSTR(IntPtr s)
		{
			Win32Native.ZeroMemory(s, (UIntPtr)(Win32Native.SysStringLen(s) * 2U));
			Marshal.FreeBSTR(s);
		}

		/// <summary>Frees an unmanaged string pointer that was allocated using the <see cref="M:System.Runtime.InteropServices.Marshal.SecureStringToCoTaskMemAnsi(System.Security.SecureString)" /> method.</summary>
		/// <param name="s">The address of the unmanaged string to free.</param>
		// Token: 0x06006086 RID: 24710 RVA: 0x001498E7 File Offset: 0x00147AE7
		[SecurityCritical]
		public static void ZeroFreeCoTaskMemAnsi(IntPtr s)
		{
			Win32Native.ZeroMemory(s, (UIntPtr)((ulong)((long)Win32Native.lstrlenA(s))));
			Marshal.FreeCoTaskMem(s);
		}

		/// <summary>Frees an unmanaged string pointer that was allocated using the <see cref="M:System.Runtime.InteropServices.Marshal.SecureStringToCoTaskMemUnicode(System.Security.SecureString)" /> method.</summary>
		/// <param name="s">The address of the unmanaged string to free.</param>
		// Token: 0x06006087 RID: 24711 RVA: 0x00149901 File Offset: 0x00147B01
		[SecurityCritical]
		public static void ZeroFreeCoTaskMemUnicode(IntPtr s)
		{
			Win32Native.ZeroMemory(s, (UIntPtr)((ulong)((long)(Win32Native.lstrlenW(s) * 2))));
			Marshal.FreeCoTaskMem(s);
		}

		/// <summary>Copies the contents of a managed <see cref="T:System.Security.SecureString" /> into unmanaged memory, converting into ANSI format as it copies.</summary>
		/// <param name="s">The managed object to copy.</param>
		/// <returns>The address, in unmanaged memory, to where the <paramref name="s" /> parameter was copied, or 0 if a null object was supplied.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="s" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The current computer is not running Windows 2000 Service Pack 3 or later.</exception>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory available.</exception>
		// Token: 0x06006088 RID: 24712 RVA: 0x0014991D File Offset: 0x00147B1D
		[SecurityCritical]
		public static IntPtr SecureStringToGlobalAllocAnsi(SecureString s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			return s.ToAnsiStr(true);
		}

		/// <summary>Copies the contents of a managed <see cref="T:System.Security.SecureString" /> object into unmanaged memory.</summary>
		/// <param name="s">The managed object to copy.</param>
		/// <returns>The address, in unmanaged memory, where <paramref name="s" /> was copied, or 0 if <paramref name="s" /> is a <see cref="T:System.Security.SecureString" /> object whose length is 0.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="s" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The current computer is not running Windows 2000 Service Pack 3 or later.</exception>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory available.</exception>
		// Token: 0x06006089 RID: 24713 RVA: 0x00149934 File Offset: 0x00147B34
		[SecurityCritical]
		public static IntPtr SecureStringToGlobalAllocUnicode(SecureString s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			return s.ToUniStr(true);
		}

		/// <summary>Frees an unmanaged string pointer that was allocated using the <see cref="M:System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocAnsi(System.Security.SecureString)" /> method.</summary>
		/// <param name="s">The address of the unmanaged string to free.</param>
		// Token: 0x0600608A RID: 24714 RVA: 0x0014994B File Offset: 0x00147B4B
		[SecurityCritical]
		public static void ZeroFreeGlobalAllocAnsi(IntPtr s)
		{
			Win32Native.ZeroMemory(s, (UIntPtr)((ulong)((long)Win32Native.lstrlenA(s))));
			Marshal.FreeHGlobal(s);
		}

		/// <summary>Frees an unmanaged string pointer that was allocated using the <see cref="M:System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(System.Security.SecureString)" /> method.</summary>
		/// <param name="s">The address of the unmanaged string to free.</param>
		// Token: 0x0600608B RID: 24715 RVA: 0x00149965 File Offset: 0x00147B65
		[SecurityCritical]
		public static void ZeroFreeGlobalAllocUnicode(IntPtr s)
		{
			Win32Native.ZeroMemory(s, (UIntPtr)((ulong)((long)(Win32Native.lstrlenW(s) * 2))));
			Marshal.FreeHGlobal(s);
		}

		// Token: 0x04002AA0 RID: 10912
		private const int LMEM_FIXED = 0;

		// Token: 0x04002AA1 RID: 10913
		private const int LMEM_MOVEABLE = 2;

		// Token: 0x04002AA2 RID: 10914
		private const long HIWORDMASK = -65536L;

		// Token: 0x04002AA3 RID: 10915
		private static Guid IID_IUnknown = new Guid("00000000-0000-0000-C000-000000000046");

		/// <summary>Represents the default character size on the system; the default is 2 for Unicode systems and 1 for ANSI systems. This field is read-only.</summary>
		// Token: 0x04002AA4 RID: 10916
		public static readonly int SystemDefaultCharSize = 2;

		/// <summary>Represents the maximum size of a double byte character set (DBCS) size, in bytes, for the current operating system. This field is read-only.</summary>
		// Token: 0x04002AA5 RID: 10917
		public static readonly int SystemMaxDBCSCharSize = Marshal.GetSystemMaxDBCSCharSize();

		// Token: 0x04002AA6 RID: 10918
		private const string s_strConvertedTypeInfoAssemblyName = "InteropDynamicTypes";

		// Token: 0x04002AA7 RID: 10919
		private const string s_strConvertedTypeInfoAssemblyTitle = "Interop Dynamic Types";

		// Token: 0x04002AA8 RID: 10920
		private const string s_strConvertedTypeInfoAssemblyDesc = "Type dynamically generated from ITypeInfo's";

		// Token: 0x04002AA9 RID: 10921
		private const string s_strConvertedTypeInfoNameSpace = "InteropDynamicTypes";

		// Token: 0x04002AAA RID: 10922
		internal static readonly Guid ManagedNameGuid = new Guid("{0F21F359-AB84-41E8-9A78-36D110E6D2F9}");
	}
}
