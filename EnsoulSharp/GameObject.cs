using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using EnsoulSharp.Native;
using EnsoulSharp.Native.Enums;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each game object.
	/// </summary>
	// Token: 0x02000043 RID: 67
	public class GameObject : IEquatable<GameObject>
	{
		// Token: 0x060002A7 RID: 679 RVA: 0x0000B324 File Offset: 0x0000A724
		internal GameObject()
		{
			this.m_networkId = 0U;
			this.m_index = 0U;
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000B300 File Offset: 0x0000A700
		internal GameObject(uint networkId, uint index)
		{
			this.m_networkId = networkId;
			this.m_index = index;
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000B348 File Offset: 0x0000A748
		internal unsafe GameObject* GetPtr()
		{
			GameObject* ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetUnitByIndex(this.m_index);
			if (ptr != null && *<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(ptr) == (int)this.m_networkId)
			{
				return ptr;
			}
			ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetUnitByNetworkId(this.m_networkId);
			if (ptr != null)
			{
				uint* ptr2 = <Module>.EnsoulSharp.Native.GameObject.GetID(ptr);
				this.m_index = *ptr2;
				return ptr;
			}
			throw new GameObjectNotFoundException();
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000C3D0 File Offset: 0x0000B7D0
		static GameObject()
		{
			AppDomain.CurrentDomain.DomainUnload += GameObject.DomainUnloadEventHandler;
			GameObject.m_CreateNativeDelegate = new GameObject.OnCreateNativeDelegate(GameObject.OnCreateNative);
			GameObject.m_CreateNative = Marshal.GetFunctionPointerForDelegate<GameObject.OnCreateNativeDelegate>(GameObject.m_CreateNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetGameObjectCreateHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), GameObject.m_CreateNative.ToPointer());
			GameObject.m_DeleteNativeDelegate = new GameObject.OnDeleteNativeDelegate(GameObject.OnDeleteNative);
			GameObject.m_DeleteNative = Marshal.GetFunctionPointerForDelegate<GameObject.OnDeleteNativeDelegate>(GameObject.m_DeleteNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetGameObjectDeleteHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), GameObject.m_DeleteNative.ToPointer());
			GameObject.m_FloatPropertyChangeNativeDelegate = new GameObject.OnFloatPropertyChangeNativeDelegate(GameObject.OnFloatPropertyChangeNative);
			GameObject.m_FloatPropertyChangeNative = Marshal.GetFunctionPointerForDelegate<GameObject.OnFloatPropertyChangeNativeDelegate>(GameObject.m_FloatPropertyChangeNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*,char\u0020const\u0020*,float,float)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetGameObjectFloatPropertyChangeHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), GameObject.m_FloatPropertyChangeNative.ToPointer());
			GameObject.m_IntegerPropertyChangeNativeDelegate = new GameObject.OnIntegerPropertyChangeNativeDelegate(GameObject.OnIntegerPropertyChangeNative);
			GameObject.m_IntegerPropertyChangeNative = Marshal.GetFunctionPointerForDelegate<GameObject.OnIntegerPropertyChangeNativeDelegate>(GameObject.m_IntegerPropertyChangeNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*,char\u0020const\u0020*,int,int)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetGameObjectIntegerPropertyChangeHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), GameObject.m_IntegerPropertyChangeNative.ToPointer());
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000B420 File Offset: 0x0000A820
		internal static void DomainUnloadEventHandler(object sender, EventArgs args)
		{
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetGameObjectCreateHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), GameObject.m_CreateNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetGameObjectDeleteHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), GameObject.m_DeleteNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*,char\u0020const\u0020*,float,float)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetGameObjectFloatPropertyChangeHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), GameObject.m_FloatPropertyChangeNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*,char\u0020const\u0020*,int,int)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetGameObjectIntegerPropertyChangeHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), GameObject.m_IntegerPropertyChangeNative.ToPointer());
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000B8A8 File Offset: 0x0000ACA8
		[HandleProcessCorruptedStateExceptions]
		[SecurityCritical]
		internal unsafe static void OnCreateNative(GameObject* gameObject)
		{
			GameObjectCreate[] array = null;
			try
			{
				GameObject gameObject2 = ObjectManager.CreateObjectFromPointer(gameObject);
				if (gameObject2 != null)
				{
					foreach (GameObjectCreate gameObjectCreate in GameObject.CreateHandlers.ToArray())
					{
						try
						{
							gameObjectCreate(gameObject2, EventArgs.Empty);
						}
						catch (Exception ex)
						{
							Console.WriteLine();
							Console.WriteLine("========================================");
							Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
							Console.WriteLine();
							Console.WriteLine("Type: {0}", ex.GetType().FullName);
							Console.WriteLine("Message: {0}", ex.Message);
							Console.WriteLine();
							Console.WriteLine("Stracktrace:");
							Console.WriteLine(ex.StackTrace);
							Exception innerException = ex.InnerException;
							if (innerException != null)
							{
								Console.WriteLine();
								Console.WriteLine("InnerException(s):");
								do
								{
									Console.WriteLine("----------------------------------------");
									Console.WriteLine("Type: {0}", innerException.GetType().FullName);
									Console.WriteLine("Message: {0}", innerException.Message);
									Console.WriteLine();
									Console.WriteLine("Stracktrace:");
									Console.WriteLine(innerException.StackTrace);
									innerException = innerException.InnerException;
								}
								while (innerException != null);
								Console.WriteLine("----------------------------------------");
							}
							Console.WriteLine("========================================");
							Console.WriteLine();
							string newValue = "";
							Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000BB6C File Offset: 0x0000AF6C
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnDeleteNative(GameObject* gameObject)
		{
			GameObjectDelete[] array = null;
			try
			{
				GameObject gameObject2 = ObjectManager.CreateObjectFromPointer(gameObject);
				if (gameObject2 != null)
				{
					foreach (GameObjectDelete gameObjectDelete in GameObject.DeleteHandlers.ToArray())
					{
						try
						{
							gameObjectDelete(gameObject2, EventArgs.Empty);
						}
						catch (Exception ex)
						{
							Console.WriteLine();
							Console.WriteLine("========================================");
							Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
							Console.WriteLine();
							Console.WriteLine("Type: {0}", ex.GetType().FullName);
							Console.WriteLine("Message: {0}", ex.Message);
							Console.WriteLine();
							Console.WriteLine("Stracktrace:");
							Console.WriteLine(ex.StackTrace);
							Exception innerException = ex.InnerException;
							if (innerException != null)
							{
								Console.WriteLine();
								Console.WriteLine("InnerException(s):");
								do
								{
									Console.WriteLine("----------------------------------------");
									Console.WriteLine("Type: {0}", innerException.GetType().FullName);
									Console.WriteLine("Message: {0}", innerException.Message);
									Console.WriteLine();
									Console.WriteLine("Stracktrace:");
									Console.WriteLine(innerException.StackTrace);
									innerException = innerException.InnerException;
								}
								while (innerException != null);
								Console.WriteLine("----------------------------------------");
							}
							Console.WriteLine("========================================");
							Console.WriteLine();
							string newValue = "";
							Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000BE30 File Offset: 0x0000B230
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnFloatPropertyChangeNative(GameObject* gameObject, sbyte* propertyName, float oldValue, float newValue)
		{
			GameObjectFloatPropertyChange[] array = null;
			try
			{
				GameObject gameObject2 = ObjectManager.CreateObjectFromPointer(gameObject);
				if (gameObject2 != null)
				{
					GameObjectFloatPropertyChangeEventArgs args = new GameObjectFloatPropertyChangeEventArgs(new string((sbyte*)propertyName), oldValue, newValue);
					foreach (GameObjectFloatPropertyChange gameObjectFloatPropertyChange in GameObject.FloatPropertyChangeHandlers.ToArray())
					{
						try
						{
							gameObjectFloatPropertyChange(gameObject2, args);
						}
						catch (Exception ex)
						{
							Console.WriteLine();
							Console.WriteLine("========================================");
							Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
							Console.WriteLine();
							Console.WriteLine("Type: {0}", ex.GetType().FullName);
							Console.WriteLine("Message: {0}", ex.Message);
							Console.WriteLine();
							Console.WriteLine("Stracktrace:");
							Console.WriteLine(ex.StackTrace);
							Exception innerException = ex.InnerException;
							if (innerException != null)
							{
								Console.WriteLine();
								Console.WriteLine("InnerException(s):");
								do
								{
									Console.WriteLine("----------------------------------------");
									Console.WriteLine("Type: {0}", innerException.GetType().FullName);
									Console.WriteLine("Message: {0}", innerException.Message);
									Console.WriteLine();
									Console.WriteLine("Stracktrace:");
									Console.WriteLine(innerException.StackTrace);
									innerException = innerException.InnerException;
								}
								while (innerException != null);
								Console.WriteLine("----------------------------------------");
							}
							Console.WriteLine("========================================");
							Console.WriteLine();
							string newValue2 = "";
							Log.Error(ex.ToString().Replace("\r", newValue2).Replace("\n", newValue2));
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue2 = "";
				Log.Error(ex2.ToString().Replace("\r", newValue2).Replace("\n", newValue2));
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000C100 File Offset: 0x0000B500
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnIntegerPropertyChangeNative(GameObject* gameObject, sbyte* propertyName, int oldValue, int newValue)
		{
			GameObjectIntegerPropertyChange[] array = null;
			try
			{
				GameObject gameObject2 = ObjectManager.CreateObjectFromPointer(gameObject);
				if (gameObject2 != null)
				{
					GameObjectIntegerPropertyChangeEventArgs args = new GameObjectIntegerPropertyChangeEventArgs(new string((sbyte*)propertyName), oldValue, newValue);
					foreach (GameObjectIntegerPropertyChange gameObjectIntegerPropertyChange in GameObject.IntegerPropertyChangeHandlers.ToArray())
					{
						try
						{
							gameObjectIntegerPropertyChange(gameObject2, args);
						}
						catch (Exception ex)
						{
							Console.WriteLine();
							Console.WriteLine("========================================");
							Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
							Console.WriteLine();
							Console.WriteLine("Type: {0}", ex.GetType().FullName);
							Console.WriteLine("Message: {0}", ex.Message);
							Console.WriteLine();
							Console.WriteLine("Stracktrace:");
							Console.WriteLine(ex.StackTrace);
							Exception innerException = ex.InnerException;
							if (innerException != null)
							{
								Console.WriteLine();
								Console.WriteLine("InnerException(s):");
								do
								{
									Console.WriteLine("----------------------------------------");
									Console.WriteLine("Type: {0}", innerException.GetType().FullName);
									Console.WriteLine("Message: {0}", innerException.Message);
									Console.WriteLine();
									Console.WriteLine("Stracktrace:");
									Console.WriteLine(innerException.StackTrace);
									innerException = innerException.InnerException;
								}
								while (innerException != null);
								Console.WriteLine("----------------------------------------");
							}
							Console.WriteLine("========================================");
							Console.WriteLine();
							string newValue2 = "";
							Log.Error(ex.ToString().Replace("\r", newValue2).Replace("\n", newValue2));
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue2 = "";
				Log.Error(ex2.ToString().Replace("\r", newValue2).Replace("\n", newValue2));
			}
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000B864 File Offset: 0x0000AC64
		[return: MarshalAs(UnmanagedType.U1)]
		public static bool operator ==(GameObject a, GameObject b)
		{
			return object.ReferenceEquals(a, b) || (!object.ReferenceEquals(a, null) && a.Equals(b));
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000B890 File Offset: 0x0000AC90
		[return: MarshalAs(UnmanagedType.U1)]
		public static bool operator !=(GameObject a, GameObject b)
		{
			return ((!(a == b)) ? 1 : 0) != 0;
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000B3E4 File Offset: 0x0000A7E4
		[return: MarshalAs(UnmanagedType.U1)]
		public override bool Equals(object obj)
		{
			return this.Equals(obj as GameObject);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000B39C File Offset: 0x0000A79C
		[return: MarshalAs(UnmanagedType.U1)]
		public virtual bool Equals(GameObject obj)
		{
			if (object.ReferenceEquals(obj, null))
			{
				return false;
			}
			if (object.ReferenceEquals(obj, this))
			{
				return true;
			}
			int num;
			if (this.m_networkId == obj.m_networkId && this.m_index == obj.m_index)
			{
				num = 1;
			}
			else
			{
				num = 0;
			}
			return (byte)num != 0;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000B400 File Offset: 0x0000A800
		public override int GetHashCode()
		{
			uint networkId = this.m_networkId;
			return (int)((networkId == 0U) ? this.m_index : networkId);
		}

		/// <summary>
		/// 	This event is fired after an object created.
		/// </summary>
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060002B5 RID: 693 RVA: 0x0000B494 File Offset: 0x0000A894
		// (remove) Token: 0x060002B6 RID: 694 RVA: 0x0000B4AC File Offset: 0x0000A8AC
		public static event GameObjectCreate OnCreate
		{
			add
			{
				GameObject.CreateHandlers.Add(value);
			}
			remove
			{
				GameObject.CreateHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before an object deleted.
		/// </summary>
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060002B7 RID: 695 RVA: 0x0000B4C8 File Offset: 0x0000A8C8
		// (remove) Token: 0x060002B8 RID: 696 RVA: 0x0000B4E0 File Offset: 0x0000A8E0
		public static event GameObjectDelete OnDelete
		{
			add
			{
				GameObject.DeleteHandlers.Add(value);
			}
			remove
			{
				GameObject.DeleteHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired every time one float property of the object changed.
		/// </summary>
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060002B9 RID: 697 RVA: 0x0000B4FC File Offset: 0x0000A8FC
		// (remove) Token: 0x060002BA RID: 698 RVA: 0x0000B514 File Offset: 0x0000A914
		public static event GameObjectFloatPropertyChange OnFloatPropertyChange
		{
			add
			{
				GameObject.FloatPropertyChangeHandlers.Add(value);
			}
			remove
			{
				GameObject.FloatPropertyChangeHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired every time one integer property of the obejct changed.
		/// </summary>
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060002BB RID: 699 RVA: 0x0000B530 File Offset: 0x0000A930
		// (remove) Token: 0x060002BC RID: 700 RVA: 0x0000B548 File Offset: 0x0000A948
		public static event GameObjectIntegerPropertyChange OnIntegerPropertyChange
		{
			add
			{
				GameObject.IntegerPropertyChangeHandlers.Add(value);
			}
			remove
			{
				GameObject.IntegerPropertyChangeHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	Gets the index of the object.
		/// </summary>
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060002BD RID: 701 RVA: 0x0000B564 File Offset: 0x0000A964
		public int Index
		{
			get
			{
				return (int)this.m_index;
			}
		}

		/// <summary>
		/// 	Gets the network id of the object.
		/// </summary>
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060002BE RID: 702 RVA: 0x0000B578 File Offset: 0x0000A978
		public int NetworkId
		{
			get
			{
				return (int)this.m_networkId;
			}
		}

		/// <summary>
		/// 	Gets the bounding box of the object.
		/// </summary>
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060002BF RID: 703 RVA: 0x0000B58C File Offset: 0x0000A98C
		public unsafe BoundingBox BBox
		{
			get
			{
				Box* ptr = <Module>.EnsoulSharp.Native.GameObject.GetBoundingBox(this.GetPtr());
				Vector3f* ptr2 = <Module>.EnsoulSharp.Native.Box.GetMax(ptr);
				Vector3f* ptr3 = <Module>.EnsoulSharp.Native.Box.GetMin(ptr);
				Vector3 maximum = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ptr2), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ptr2), <Module>.EnsoulSharp.Native.Vector3f.GetY(ptr2));
				Vector3 minimum = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ptr3), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ptr3), <Module>.EnsoulSharp.Native.Vector3f.GetY(ptr3));
				BoundingBox result = new BoundingBox(minimum, maximum);
				return result;
			}
		}

		/// <summary>
		/// 	Gets or sets the name of the object.
		/// </summary>
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x0000B5F4 File Offset: 0x0000A9F4
		// (set) Token: 0x060002C1 RID: 705 RVA: 0x0000B648 File Offset: 0x0000AA48
		public unsafe string Name
		{
			get
			{
				StlString* ptr = <Module>.EnsoulSharp.Native.GameObject.GetName(this.GetPtr());
				sbyte* ptr2;
				if (*(ptr + 16) + 1 > 16)
				{
					ptr2 = *ptr;
				}
				else
				{
					ptr2 = ptr;
				}
				if (ptr2 != null)
				{
					sbyte* ptr3 = ptr2;
					if (*(sbyte*)ptr2 != 0)
					{
						do
						{
							ptr3 += 1 / sizeof(sbyte);
						}
						while (*(sbyte*)ptr3 != 0);
					}
					int length = (int)(ptr3 - ptr2);
					return new string((sbyte*)ptr2, 0, length, Encoding.UTF8);
				}
				return string.Empty;
			}
			set
			{
				byte[] bytes = Encoding.UTF8.GetBytes(value);
				int num = bytes.Length;
				IntPtr intPtr = Marshal.AllocHGlobal(num + 1);
				IntPtr intPtr2 = intPtr;
				Marshal.Copy(bytes, 0, intPtr, num);
				Marshal.WriteByte(intPtr2, num, 0);
				<Module>.EnsoulSharp.Native.GameObject.SetName(this.GetPtr(), (sbyte*)intPtr2.ToPointer());
				Marshal.FreeHGlobal(intPtr2);
			}
		}

		/// <summary>
		/// 	Gets the position of the object.
		/// </summary>
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x0000B698 File Offset: 0x0000AA98
		public unsafe Vector3 Position
		{
			get
			{
				Vector3f* ptr = <Module>.EnsoulSharp.Native.GameObject.GetPosition(this.GetPtr());
				Vector3 result = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ptr), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ptr), <Module>.EnsoulSharp.Native.Vector3f.GetY(ptr));
				return result;
			}
		}

		/// <summary>
		/// 	Gets the previous position of the object.
		/// </summary>
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x0000B6CC File Offset: 0x0000AACC
		[Obsolete("Please use AIBaseClient.ServerPosition instead.", false)]
		public unsafe Vector3 PreviousPosition
		{
			get
			{
				Vector3f* ptr = <Module>.EnsoulSharp.Native.GameObject.GetPreviousPosition(this.GetPtr());
				Vector3 result = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ptr), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ptr), <Module>.EnsoulSharp.Native.Vector3f.GetY(ptr));
				return result;
			}
		}

		/// <summary>
		/// 	Gets the team of the object.
		/// </summary>
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x0000B700 File Offset: 0x0000AB00
		public unsafe GameObjectTeam Team
		{
			get
			{
				return (GameObjectTeam)(*<Module>.EnsoulSharp.Native.GameObject.GetTeamID(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the type of the object.
		/// </summary>
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x0000B71C File Offset: 0x0000AB1C
		public GameObjectType Type
		{
			get
			{
				return (GameObjectType)<Module>.EnsoulSharp.Native.GameObject.GetType(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets the bounding radius of the object.
		/// </summary>
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x0000B734 File Offset: 0x0000AB34
		public float BoundingRadius
		{
			get
			{
				return <Module>.EnsoulSharp.Native.GameObjectVtbl.GetBoundingRadius(<Module>.EnsoulSharp.Native.GameObject.GetVftable(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is dead.
		/// </summary>
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x0000B754 File Offset: 0x0000AB54
		public bool IsDead
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.TScrambleWrapper<bool,bool,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.GameObject.GetDead(this.GetPtr()), true) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is visible on screen.
		/// </summary>
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x0000B774 File Offset: 0x0000AB74
		public bool IsVisibleOnScreen
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.TScrambleWrapper<bool,bool,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.GameObject.GetIsVisibleOnScreen(this.GetPtr()), false) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the obejct is local player.
		/// </summary>
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x0000B794 File Offset: 0x0000AB94
		public unsafe bool IsMe
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				AIHeroClient* ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetPlayer();
				return ptr != null && ((*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(ptr) == (int)this.m_networkId) ? 1 : 0) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is ally.
		/// </summary>
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060002CA RID: 714 RVA: 0x0000B7BC File Offset: 0x0000ABBC
		public unsafe bool IsAlly
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				AIHeroClient* ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetPlayer();
				if (ptr != null)
				{
					TeamId* ptr2 = <Module>.EnsoulSharp.Native.GameObject.GetTeamID(this.GetPtr());
					return ((*<Module>.EnsoulSharp.Native.GameObject.GetTeamID(ptr) == (int)(*ptr2)) ? 1 : 0) != 0;
				}
				return false;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is not ally.
		/// </summary>
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060002CB RID: 715 RVA: 0x0000B7EC File Offset: 0x0000ABEC
		public unsafe bool IsEnemy
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				AIHeroClient* ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetPlayer();
				if (ptr != null)
				{
					TeamId* ptr2 = <Module>.EnsoulSharp.Native.GameObject.GetTeamID(this.GetPtr());
					return ((*<Module>.EnsoulSharp.Native.GameObject.GetTeamID(ptr) != (int)(*ptr2)) ? 1 : 0) != 0;
				}
				return false;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is valid.
		/// </summary>
		/// <remarks>We suggest you can use this property check whether the object is valid before any other calls.</remarks>
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060002CC RID: 716 RVA: 0x0000B820 File Offset: 0x0000AC20
		public unsafe bool IsValid
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				GameObject* ptr = null;
				try
				{
					ptr = this.GetPtr();
				}
				catch (Exception)
				{
					return false;
				}
				return ((ptr != null) ? 1 : 0) != 0;
			}
		}

		// Token: 0x0400034E RID: 846
		protected uint m_networkId;

		// Token: 0x0400034F RID: 847
		protected uint m_index;

		// Token: 0x04000350 RID: 848
		internal static GameObject.OnCreateNativeDelegate m_CreateNativeDelegate;

		// Token: 0x04000351 RID: 849
		internal static GameObject.OnDeleteNativeDelegate m_DeleteNativeDelegate;

		// Token: 0x04000352 RID: 850
		internal static GameObject.OnFloatPropertyChangeNativeDelegate m_FloatPropertyChangeNativeDelegate;

		// Token: 0x04000353 RID: 851
		internal static GameObject.OnIntegerPropertyChangeNativeDelegate m_IntegerPropertyChangeNativeDelegate;

		// Token: 0x04000354 RID: 852
		internal static IntPtr m_CreateNative = IntPtr.Zero;

		// Token: 0x04000355 RID: 853
		internal static IntPtr m_DeleteNative = IntPtr.Zero;

		// Token: 0x04000356 RID: 854
		internal static IntPtr m_FloatPropertyChangeNative = IntPtr.Zero;

		// Token: 0x04000357 RID: 855
		internal static IntPtr m_IntegerPropertyChangeNative = IntPtr.Zero;

		// Token: 0x04000358 RID: 856
		internal static List<GameObjectCreate> CreateHandlers = new List<GameObjectCreate>();

		// Token: 0x04000359 RID: 857
		internal static List<GameObjectDelete> DeleteHandlers = new List<GameObjectDelete>();

		// Token: 0x0400035A RID: 858
		internal static List<GameObjectFloatPropertyChange> FloatPropertyChangeHandlers = new List<GameObjectFloatPropertyChange>();

		// Token: 0x0400035B RID: 859
		internal static List<GameObjectIntegerPropertyChange> IntegerPropertyChangeHandlers = new List<GameObjectIntegerPropertyChange>();

		// Token: 0x02000044 RID: 68
		// (Invoke) Token: 0x060002CE RID: 718
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnCreateNativeDelegate(GameObject* gameObject);

		// Token: 0x02000045 RID: 69
		// (Invoke) Token: 0x060002D2 RID: 722
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnDeleteNativeDelegate(GameObject* gameObject);

		// Token: 0x02000046 RID: 70
		// (Invoke) Token: 0x060002D6 RID: 726
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnFloatPropertyChangeNativeDelegate(GameObject* gameObject, sbyte* propertyName, float oldValue, float newValue);

		// Token: 0x02000047 RID: 71
		// (Invoke) Token: 0x060002DA RID: 730
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnIntegerPropertyChangeNativeDelegate(GameObject* gameObject, sbyte* propertyName, int oldValue, int newValue);
	}
}
