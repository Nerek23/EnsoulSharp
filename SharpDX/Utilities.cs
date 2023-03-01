using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using SharpDX.Direct3D;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x02000035 RID: 53
	public static class Utilities
	{
		// Token: 0x06000190 RID: 400 RVA: 0x00005143 File Offset: 0x00003343
		public unsafe static void CopyMemory(IntPtr dest, IntPtr src, int sizeInBytesToCopy)
		{
			Interop.memcpy((void*)dest, (void*)src, sizeInBytesToCopy);
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00005158 File Offset: 0x00003358
		public unsafe static bool CompareMemory(IntPtr from, IntPtr against, int sizeToCompare)
		{
			byte* ptr = (byte*)((void*)from);
			byte* ptr2 = (byte*)((void*)against);
			for (int i = sizeToCompare >> 3; i > 0; i--)
			{
				if (*(long*)ptr != *(long*)ptr2)
				{
					return false;
				}
				ptr += 8;
				ptr2 += 8;
			}
			for (int i = sizeToCompare & 7; i > 0; i--)
			{
				if (*ptr != *ptr2)
				{
					return false;
				}
				ptr++;
				ptr2++;
			}
			return true;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x000051B0 File Offset: 0x000033B0
		public unsafe static void ClearMemory(IntPtr dest, byte value, int sizeInBytesToClear)
		{
			Interop.memset((void*)dest, value, sizeInBytesToClear);
		}

		// Token: 0x06000193 RID: 403 RVA: 0x000051BF File Offset: 0x000033BF
		public static int SizeOf<T>() where T : struct
		{
			return sizeof(T);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000051C7 File Offset: 0x000033C7
		public static int SizeOf<T>(T[] array) where T : struct
		{
			if (array != null)
			{
				return array.Length * sizeof(T);
			}
			return 0;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x000051D8 File Offset: 0x000033D8
		public unsafe static void Pin<T>(ref T source, Action<IntPtr> pinAction) where T : struct
		{
			fixed (T* value = &source)
			{
				pinAction((IntPtr)((void*)value));
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x000051F4 File Offset: 0x000033F4
		public unsafe static void Pin<T>(T[] source, Action<IntPtr> pinAction) where T : struct
		{
			IntPtr obj;
			if (source != null)
			{
				fixed (T* value = &source[0])
				{
					obj = (IntPtr)((void*)value);
				}
			}
			else
			{
				obj = IntPtr.Zero;
			}
			pinAction(obj);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00005220 File Offset: 0x00003420
		public unsafe static byte[] ToByteArray<T>(T[] source) where T : struct
		{
			if (source == null)
			{
				return null;
			}
			byte[] array = new byte[Utilities.SizeOf<T>() * source.Length];
			if (source.Length == 0)
			{
				return array;
			}
			byte[] array2;
			void* pDest;
			if ((array2 = array) == null || array2.Length == 0)
			{
				pDest = null;
			}
			else
			{
				pDest = (void*)(&array2[0]);
			}
			Interop.Write<T>(pDest, source, 0, source.Length);
			array2 = null;
			return array;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00005270 File Offset: 0x00003470
		public static void Swap<T>(ref T left, ref T right)
		{
			T t = left;
			left = right;
			right = t;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00005297 File Offset: 0x00003497
		public unsafe static T Read<T>(IntPtr source) where T : struct
		{
			return *(T*)((void*)source);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000052A4 File Offset: 0x000034A4
		public unsafe static void Read<T>(IntPtr source, ref T data) where T : struct
		{
			data = *(T*)((void*)source);
		}

		// Token: 0x0600019B RID: 411 RVA: 0x000052A4 File Offset: 0x000034A4
		public unsafe static void ReadOut<T>(IntPtr source, out T data) where T : struct
		{
			data = *(T*)((void*)source);
		}

		// Token: 0x0600019C RID: 412 RVA: 0x000052B2 File Offset: 0x000034B2
		public unsafe static IntPtr ReadAndPosition<T>(IntPtr source, ref T data) where T : struct
		{
			return (IntPtr)Interop.Read<T>((void*)source, ref data);
		}

		// Token: 0x0600019D RID: 413 RVA: 0x000052C5 File Offset: 0x000034C5
		public unsafe static IntPtr Read<T>(IntPtr source, T[] data, int offset, int count) where T : struct
		{
			return (IntPtr)Interop.Read<T>((void*)source, data, offset, count);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x000052DA File Offset: 0x000034DA
		public unsafe static void Write<T>(IntPtr destination, ref T data) where T : struct
		{
			*(T*)((void*)destination) = data;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x000052E8 File Offset: 0x000034E8
		public unsafe static IntPtr WriteAndPosition<T>(IntPtr destination, ref T data) where T : struct
		{
			return (IntPtr)Interop.Write<T>((void*)destination, ref data);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x000052FB File Offset: 0x000034FB
		public unsafe static IntPtr Write<T>(IntPtr destination, T[] data, int offset, int count) where T : struct
		{
			return (IntPtr)Interop.Write<T>((void*)destination, data, offset, count);
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00005310 File Offset: 0x00003510
		public unsafe static void ConvertToIntArray(bool[] array, int* dest)
		{
			for (int i = 0; i < array.Length; i++)
			{
				dest[i] = (array[i] ? 1 : 0);
			}
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0000533C File Offset: 0x0000353C
		public static RawBool[] ConvertToIntArray(bool[] array)
		{
			RawBool[] array2 = new RawBool[array.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = array[i];
			}
			return array2;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00005370 File Offset: 0x00003570
		public unsafe static bool[] ConvertToBoolArray(int* array, int length)
		{
			bool[] array2 = new bool[length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = (array[i] != 0);
			}
			return array2;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x000053A0 File Offset: 0x000035A0
		public static bool[] ConvertToBoolArray(RawBool[] array)
		{
			bool[] array2 = new bool[array.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = array[i];
			}
			return array2;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x000053D4 File Offset: 0x000035D4
		public static Guid GetGuidFromType(Type type)
		{
			return type.GetTypeInfo().GUID;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x000053E4 File Offset: 0x000035E4
		public static bool IsAssignableToGenericType(Type givenType, Type genericType)
		{
			foreach (Type type in givenType.GetTypeInfo().ImplementedInterfaces)
			{
				if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == genericType)
				{
					return true;
				}
			}
			if (givenType.GetTypeInfo().IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
			{
				return true;
			}
			Type baseType = givenType.GetTypeInfo().BaseType;
			return !(baseType == null) && Utilities.IsAssignableToGenericType(baseType, genericType);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0000548C File Offset: 0x0000368C
		public unsafe static IntPtr AllocateMemory(int sizeInBytes, int align = 16)
		{
			int num = align - 1;
			IntPtr intPtr = Marshal.AllocHGlobal(sizeInBytes + num + IntPtr.Size);
			byte* ptr = (byte*)((byte*)((void*)intPtr) + sizeof(void*)) + num & ~num;
			((IntPtr*)ptr)[(IntPtr)(-1) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = intPtr;
			return new IntPtr((void*)ptr);
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000054D4 File Offset: 0x000036D4
		public static IntPtr AllocateClearedMemory(int sizeInBytes, byte clearValue = 0, int align = 16)
		{
			IntPtr intPtr = Utilities.AllocateMemory(sizeInBytes, align);
			Utilities.ClearMemory(intPtr, clearValue, sizeInBytes);
			return intPtr;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x000054E5 File Offset: 0x000036E5
		public static bool IsMemoryAligned(IntPtr memoryPtr, int align = 16)
		{
			return (memoryPtr.ToInt64() & (long)(align - 1)) == 0L;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x000054F7 File Offset: 0x000036F7
		public unsafe static void FreeMemory(IntPtr alignedBuffer)
		{
			if (alignedBuffer == IntPtr.Zero)
			{
				return;
			}
			Marshal.FreeHGlobal(*(IntPtr*)((byte*)((void*)alignedBuffer) + (IntPtr)(-1) * (IntPtr)sizeof(IntPtr)));
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00005520 File Offset: 0x00003720
		public static string PtrToStringAnsi(IntPtr pointer, int maxLength)
		{
			string text = Marshal.PtrToStringAnsi(pointer);
			if (text != null && text.Length > maxLength)
			{
				text = text.Substring(0, maxLength);
			}
			return text;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000554C File Offset: 0x0000374C
		public static string PtrToStringUni(IntPtr pointer, int maxLength)
		{
			string text = Marshal.PtrToStringUni(pointer);
			if (text != null && text.Length > maxLength)
			{
				text = text.Substring(0, maxLength);
			}
			return text;
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00005576 File Offset: 0x00003776
		public static IntPtr StringToHGlobalAnsi(string s)
		{
			return Marshal.StringToHGlobalAnsi(s);
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0000557E File Offset: 0x0000377E
		public static IntPtr StringToHGlobalUni(string s)
		{
			return Marshal.StringToHGlobalUni(s);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00005588 File Offset: 0x00003788
		public static IntPtr StringToCoTaskMemUni(string s)
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
			IntPtr intPtr = Marshal.AllocCoTaskMem(num);
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			Utilities.CopyStringToUnmanaged(intPtr, s);
			return intPtr;
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x000055DC File Offset: 0x000037DC
		private unsafe static void CopyStringToUnmanaged(IntPtr ptr, string str)
		{
			fixed (string text = str)
			{
				char* ptr2 = text;
				if (ptr2 != null)
				{
					ptr2 += RuntimeHelpers.OffsetToStringData / 2;
				}
				Utilities.CopyMemory(ptr, new IntPtr((void*)ptr2), (str.Length + 1) * 2);
			}
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00005611 File Offset: 0x00003811
		public static IntPtr GetIUnknownForObject(object obj)
		{
			if (obj != null)
			{
				return Marshal.GetIUnknownForObject(obj);
			}
			return IntPtr.Zero;
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00005622 File Offset: 0x00003822
		public static object GetObjectForIUnknown(IntPtr iunknownPtr)
		{
			if (!(iunknownPtr == IntPtr.Zero))
			{
				return Marshal.GetObjectForIUnknown(iunknownPtr);
			}
			return null;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000563C File Offset: 0x0000383C
		public static string Join<T>(string separator, T[] array)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(separator);
					}
					stringBuilder.Append(array[i]);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00005688 File Offset: 0x00003888
		public static string Join(string separator, IEnumerable elements)
		{
			List<string> list = new List<string>();
			foreach (object obj in elements)
			{
				list.Add(obj.ToString());
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < list.Count; i++)
			{
				string value = list[i];
				if (i > 0)
				{
					stringBuilder.Append(separator);
				}
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00005728 File Offset: 0x00003928
		public static string Join(string separator, IEnumerator elements)
		{
			List<string> list = new List<string>();
			while (elements.MoveNext())
			{
				object obj = elements.Current;
				list.Add(obj.ToString());
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < list.Count; i++)
			{
				string value = list[i];
				if (i > 0)
				{
					stringBuilder.Append(separator);
				}
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0000578F File Offset: 0x0000398F
		public static string BlobToString(Blob blob)
		{
			if (blob == null)
			{
				return null;
			}
			string result = Marshal.PtrToStringAnsi(blob.BufferPointer);
			blob.Dispose();
			return result;
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x000057A7 File Offset: 0x000039A7
		public unsafe static IntPtr IntPtrAdd(IntPtr ptr, int offset)
		{
			return new IntPtr((void*)((byte*)((void*)ptr) + offset));
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000057B8 File Offset: 0x000039B8
		public static byte[] ReadStream(Stream stream)
		{
			int num = 0;
			return Utilities.ReadStream(stream, ref num);
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x000057D0 File Offset: 0x000039D0
		public static byte[] ReadStream(Stream stream, ref int readLength)
		{
			if (readLength == 0)
			{
				readLength = (int)(stream.Length - stream.Position);
			}
			int num = readLength;
			if (num == 0)
			{
				return new byte[0];
			}
			byte[] array = new byte[num];
			int num2 = 0;
			if (num > 0)
			{
				do
				{
					num2 += stream.Read(array, num2, readLength - num2);
				}
				while (num2 < readLength);
			}
			return array;
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00005822 File Offset: 0x00003A22
		public static bool Compare(IEnumerable left, IEnumerable right)
		{
			return left == right || (left != null && right != null && Utilities.Compare(left.GetEnumerator(), right.GetEnumerator()));
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00005844 File Offset: 0x00003A44
		public static bool Compare(IEnumerator leftIt, IEnumerator rightIt)
		{
			if (leftIt == rightIt)
			{
				return true;
			}
			if (leftIt == null || rightIt == null)
			{
				return false;
			}
			bool flag;
			bool flag2;
			do
			{
				flag = leftIt.MoveNext();
				flag2 = rightIt.MoveNext();
				if (!flag || !flag2)
				{
					goto IL_37;
				}
			}
			while (object.Equals(leftIt.Current, rightIt.Current));
			return false;
			IL_37:
			return flag == flag2;
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00005890 File Offset: 0x00003A90
		public static bool Compare(ICollection left, ICollection right)
		{
			if (left == right)
			{
				return true;
			}
			if (left == null || right == null)
			{
				return false;
			}
			if (left.Count != right.Count)
			{
				return false;
			}
			int num = 0;
			IEnumerator enumerator = left.GetEnumerator();
			IEnumerator enumerator2 = right.GetEnumerator();
			while (enumerator.MoveNext() && enumerator2.MoveNext())
			{
				if (!object.Equals(enumerator.Current, enumerator2.Current))
				{
					return false;
				}
				num++;
			}
			return num == left.Count;
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00005902 File Offset: 0x00003B02
		public static T GetCustomAttribute<T>(MemberInfo memberInfo, bool inherited = false) where T : Attribute
		{
			return memberInfo.GetCustomAttribute(inherited);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000590B File Offset: 0x00003B0B
		public static IEnumerable<T> GetCustomAttributes<T>(MemberInfo memberInfo, bool inherited = false) where T : Attribute
		{
			return memberInfo.GetCustomAttributes(inherited);
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00005914 File Offset: 0x00003B14
		public static bool IsAssignableFrom(Type toType, Type fromType)
		{
			return toType.GetTypeInfo().IsAssignableFrom(fromType.GetTypeInfo());
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00005927 File Offset: 0x00003B27
		public static bool IsEnum(Type typeToTest)
		{
			return typeToTest.GetTypeInfo().IsEnum;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00005934 File Offset: 0x00003B34
		public static bool IsValueType(Type typeToTest)
		{
			return typeToTest.GetTypeInfo().IsValueType;
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00005944 File Offset: 0x00003B44
		private static MethodInfo GetMethod(Type type, string name, Type[] typeArgs)
		{
			foreach (MethodInfo methodInfo in type.GetTypeInfo().GetDeclaredMethods(name))
			{
				if (methodInfo.GetParameters().Length == typeArgs.Length)
				{
					ParameterInfo[] parameters = methodInfo.GetParameters();
					bool flag = true;
					for (int i = 0; i < typeArgs.Length; i++)
					{
						if (parameters[i].ParameterType != typeArgs[i])
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						return methodInfo;
					}
				}
			}
			return null;
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x000059DC File Offset: 0x00003BDC
		public static GetValueFastDelegate<T> BuildPropertyGetter<T>(Type customEffectType, PropertyInfo propertyInfo)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(T).MakeByRefType());
			ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object));
			MemberExpression memberExpression = Expression.Property(Expression.Convert(parameterExpression2, customEffectType), propertyInfo);
			Expression right;
			if (propertyInfo.PropertyType == typeof(bool))
			{
				right = Expression.Condition(memberExpression, Expression.Constant(1), Expression.Constant(0));
			}
			else
			{
				right = Expression.Convert(memberExpression, typeof(T));
			}
			return Expression.Lambda<GetValueFastDelegate<T>>(Expression.Assign(parameterExpression, right), new ParameterExpression[]
			{
				parameterExpression2,
				parameterExpression
			}).Compile();
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00005A84 File Offset: 0x00003C84
		public static SetValueFastDelegate<T> BuildPropertySetter<T>(Type customEffectType, PropertyInfo propertyInfo)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(T).MakeByRefType());
			ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object));
			Expression left = Expression.Property(Expression.Convert(parameterExpression2, customEffectType), propertyInfo);
			Expression right;
			if (propertyInfo.PropertyType == typeof(bool))
			{
				right = Expression.NotEqual(parameterExpression, Expression.Constant(0));
			}
			else
			{
				right = Expression.Convert(parameterExpression, propertyInfo.PropertyType);
			}
			return Expression.Lambda<SetValueFastDelegate<T>>(Expression.Assign(left, right), new ParameterExpression[]
			{
				parameterExpression2,
				parameterExpression
			}).Compile();
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00005B1C File Offset: 0x00003D1C
		private static MethodInfo FindExplicitConverstion(Type sourceType, Type targetType)
		{
			if (sourceType == targetType)
			{
				return null;
			}
			List<MethodInfo> list = new List<MethodInfo>();
			Type type = sourceType;
			while (type != null)
			{
				list.AddRange(type.GetTypeInfo().DeclaredMethods);
				type = type.GetTypeInfo().BaseType;
			}
			type = targetType;
			while (type != null)
			{
				list.AddRange(type.GetTypeInfo().DeclaredMethods);
				type = type.GetTypeInfo().BaseType;
			}
			foreach (MethodInfo methodInfo in list)
			{
				if (methodInfo.Name == "op_Explicit" && methodInfo.ReturnType == targetType && Utilities.IsAssignableFrom(methodInfo.GetParameters()[0].ParameterType, sourceType))
				{
					return methodInfo;
				}
			}
			return null;
		}

		// Token: 0x060001C6 RID: 454
		[DllImport("ole32.dll", ExactSpelling = true)]
		private static extern Result CoCreateInstance([MarshalAs(UnmanagedType.LPStruct)] [In] Guid rclsid, IntPtr pUnkOuter, Utilities.CLSCTX dwClsContext, [MarshalAs(UnmanagedType.LPStruct)] [In] Guid riid, out IntPtr comObject);

		// Token: 0x060001C7 RID: 455 RVA: 0x00005C08 File Offset: 0x00003E08
		internal static void CreateComInstance(Guid clsid, Utilities.CLSCTX clsctx, Guid riid, ComObject comObject)
		{
			IntPtr nativePointer;
			Utilities.CoCreateInstance(clsid, IntPtr.Zero, clsctx, riid, out nativePointer).CheckError();
			comObject.NativePointer = nativePointer;
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00005C34 File Offset: 0x00003E34
		internal static bool TryCreateComInstance(Guid clsid, Utilities.CLSCTX clsctx, Guid riid, ComObject comObject)
		{
			IntPtr nativePointer;
			Result result = Utilities.CoCreateInstance(clsid, IntPtr.Zero, clsctx, riid, out nativePointer);
			comObject.NativePointer = nativePointer;
			return result.Success;
		}

		// Token: 0x060001C9 RID: 457
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool CloseHandle(IntPtr handle);

		// Token: 0x060001CA RID: 458 RVA: 0x00005C60 File Offset: 0x00003E60
		public static IntPtr GetProcAddress(IntPtr handle, string dllFunctionToImport)
		{
			IntPtr procAddress_ = Utilities.GetProcAddress_(handle, dllFunctionToImport);
			if (procAddress_ == IntPtr.Zero)
			{
				throw new SharpDXException(dllFunctionToImport, new object[0]);
			}
			return procAddress_;
		}

		// Token: 0x060001CB RID: 459
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress", ExactSpelling = true, SetLastError = true)]
		private static extern IntPtr GetProcAddress_(IntPtr hModule, string procName);

		// Token: 0x060001CC RID: 460 RVA: 0x00005C90 File Offset: 0x00003E90
		public static int ComputeHashFNVModified(byte[] data)
		{
			uint num = 2166136261U;
			foreach (byte b in data)
			{
				num = (num ^ (uint)b) * 16777619U;
			}
			num += num << 13;
			num ^= num >> 7;
			num += num << 3;
			num ^= num >> 17;
			return (int)(num + (num << 5));
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00005CE2 File Offset: 0x00003EE2
		public static void Dispose<T>(ref T comObject) where T : class, IDisposable
		{
			if (comObject != null)
			{
				comObject.Dispose();
				comObject = default(T);
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00005D04 File Offset: 0x00003F04
		public static T[] ToArray<T>(IEnumerable<T> source)
		{
			return new Utilities.Buffer<T>(source).ToArray();
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00005D1F File Offset: 0x00003F1F
		public static bool Any<T>(IEnumerable<T> source)
		{
			return source.GetEnumerator().MoveNext();
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00005D2C File Offset: 0x00003F2C
		public static IEnumerable<TResult> SelectMany<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
		{
			foreach (TSource arg in source)
			{
				foreach (TResult tresult in selector(arg))
				{
					yield return tresult;
				}
				IEnumerator<TResult> enumerator2 = null;
			}
			IEnumerator<TSource> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00005D43 File Offset: 0x00003F43
		public static IEnumerable<TSource> Distinct<TSource>(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer = null)
		{
			if (comparer == null)
			{
				comparer = EqualityComparer<TSource>.Default;
			}
			Dictionary<TSource, object> values = new Dictionary<TSource, object>(comparer);
			foreach (TSource tsource in source)
			{
				if (!values.ContainsKey(tsource))
				{
					values.Add(tsource, null);
					yield return tsource;
				}
			}
			IEnumerator<TSource> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00005D5A File Offset: 0x00003F5A
		public static bool IsTypeInheritFrom(Type type, string parentType)
		{
			while (type != null)
			{
				if (type.FullName == parentType)
				{
					return true;
				}
				type = type.GetTypeInfo().BaseType;
			}
			return false;
		}

		// Token: 0x02000036 RID: 54
		[Flags]
		public enum CLSCTX : uint
		{
			// Token: 0x04000065 RID: 101
			ClsctxInprocServer = 1U,
			// Token: 0x04000066 RID: 102
			ClsctxInprocHandler = 2U,
			// Token: 0x04000067 RID: 103
			ClsctxLocalServer = 4U,
			// Token: 0x04000068 RID: 104
			ClsctxInprocServer16 = 8U,
			// Token: 0x04000069 RID: 105
			ClsctxRemoteServer = 16U,
			// Token: 0x0400006A RID: 106
			ClsctxInprocHandler16 = 32U,
			// Token: 0x0400006B RID: 107
			ClsctxReserved1 = 64U,
			// Token: 0x0400006C RID: 108
			ClsctxReserved2 = 128U,
			// Token: 0x0400006D RID: 109
			ClsctxReserved3 = 256U,
			// Token: 0x0400006E RID: 110
			ClsctxReserved4 = 512U,
			// Token: 0x0400006F RID: 111
			ClsctxNoCodeDownload = 1024U,
			// Token: 0x04000070 RID: 112
			ClsctxReserved5 = 2048U,
			// Token: 0x04000071 RID: 113
			ClsctxNoCustomMarshal = 4096U,
			// Token: 0x04000072 RID: 114
			ClsctxEnableCodeDownload = 8192U,
			// Token: 0x04000073 RID: 115
			ClsctxNoFailureLog = 16384U,
			// Token: 0x04000074 RID: 116
			ClsctxDisableAaa = 32768U,
			// Token: 0x04000075 RID: 117
			ClsctxEnableAaa = 65536U,
			// Token: 0x04000076 RID: 118
			ClsctxFromDefaultContext = 131072U,
			// Token: 0x04000077 RID: 119
			ClsctxInproc = 3U,
			// Token: 0x04000078 RID: 120
			ClsctxServer = 21U,
			// Token: 0x04000079 RID: 121
			ClsctxAll = 23U
		}

		// Token: 0x02000037 RID: 55
		public enum CoInit
		{
			// Token: 0x0400007B RID: 123
			MultiThreaded,
			// Token: 0x0400007C RID: 124
			ApartmentThreaded = 2,
			// Token: 0x0400007D RID: 125
			DisableOle1Dde = 4,
			// Token: 0x0400007E RID: 126
			SpeedOverMemory = 8
		}

		// Token: 0x02000038 RID: 56
		internal struct Buffer<TElement>
		{
			// Token: 0x060001D3 RID: 467 RVA: 0x00005D88 File Offset: 0x00003F88
			internal Buffer(IEnumerable<TElement> source)
			{
				TElement[] array = null;
				int num = 0;
				ICollection<TElement> collection = source as ICollection<TElement>;
				if (collection != null)
				{
					num = collection.Count;
					if (num > 0)
					{
						array = new TElement[num];
						collection.CopyTo(array, 0);
					}
				}
				else
				{
					foreach (TElement telement in source)
					{
						if (array == null)
						{
							array = new TElement[4];
						}
						else if (array.Length == num)
						{
							TElement[] array2 = new TElement[checked(num * 2)];
							Array.Copy(array, 0, array2, 0, num);
							array = array2;
						}
						array[num] = telement;
						num++;
					}
				}
				this.items = array;
				this.count = num;
			}

			// Token: 0x060001D4 RID: 468 RVA: 0x00005E3C File Offset: 0x0000403C
			internal TElement[] ToArray()
			{
				if (this.count == 0)
				{
					return new TElement[0];
				}
				if (this.items.Length == this.count)
				{
					return this.items;
				}
				TElement[] array = new TElement[this.count];
				Array.Copy(this.items, 0, array, 0, this.count);
				return array;
			}

			// Token: 0x0400007F RID: 127
			internal TElement[] items;

			// Token: 0x04000080 RID: 128
			internal int count;
		}
	}
}
