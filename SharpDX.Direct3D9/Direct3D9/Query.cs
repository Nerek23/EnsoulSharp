using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000BB RID: 187
	[Guid("d9771460-a695-4f26-bbd3-27b840b541cc")]
	public class Query : ComObject
	{
		// Token: 0x06000562 RID: 1378 RVA: 0x00002623 File Offset: 0x00000823
		public Query(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x00013AF3 File Offset: 0x00011CF3
		public new static explicit operator Query(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new Query(nativePointer);
			}
			return null;
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000564 RID: 1380 RVA: 0x00013B0C File Offset: 0x00011D0C
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000565 RID: 1381 RVA: 0x00013B22 File Offset: 0x00011D22
		public int DataSize
		{
			get
			{
				return this.GetDataSize();
			}
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x00013B2C File Offset: 0x00011D2C
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x00013B84 File Offset: 0x00011D84
		internal unsafe QueryType GetTypeInfo()
		{
			return calli(SharpDX.Direct3D9.QueryType(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x000105EF File Offset: 0x0000E7EF
		internal unsafe int GetDataSize()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x00013BA4 File Offset: 0x00011DA4
		public unsafe void Issue(Issue dwIssueFlags)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, dwIssueFlags, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x00013BDC File Offset: 0x00011DDC
		internal unsafe Result GetData(IntPtr dataRef, int dwSize, int dwGetDataFlags)
		{
			return calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, (void*)dataRef, dwSize, dwGetDataFlags, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x00013C08 File Offset: 0x00011E08
		public Query(Device device, QueryType type)
		{
			device.CreateQuery(type, this);
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600056C RID: 1388 RVA: 0x00013C18 File Offset: 0x00011E18
		public QueryType Type
		{
			get
			{
				return this.GetTypeInfo();
			}
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x00013C20 File Offset: 0x00011E20
		public unsafe bool GetData<T>(out T data, bool flush) where T : struct
		{
			QueryType type = this.Type;
			bool flag = true;
			switch (type)
			{
			case QueryType.VCache:
				flag = (typeof(T) != typeof(VCache));
				break;
			case QueryType.ResourceManager:
				flag = (typeof(T) != typeof(ResourceManager));
				break;
			case QueryType.VertexStats:
				flag = (typeof(T) != typeof(VertexStats));
				break;
			case QueryType.Event:
				flag = (typeof(T) != typeof(bool));
				break;
			case QueryType.Occlusion:
				flag = (typeof(T) != typeof(int) && typeof(T) != typeof(uint));
				break;
			case QueryType.Timestamp:
				flag = (typeof(T) != typeof(long) && typeof(T) != typeof(ulong));
				break;
			case QueryType.TimestampDisjoint:
				flag = (typeof(T) != typeof(bool));
				break;
			case QueryType.TimestampFreq:
				flag = (typeof(T) != typeof(long) && typeof(T) != typeof(ulong));
				break;
			case QueryType.PipelineTimings:
				flag = (typeof(T) != typeof(PipelineTimings));
				break;
			case QueryType.InterfaceTimings:
				flag = (typeof(T) != typeof(InterfaceTimings));
				break;
			case QueryType.VertexTimings:
				flag = (typeof(T) != typeof(StageTimings));
				break;
			case QueryType.BandwidthTimings:
				flag = (typeof(T) != typeof(BandwidthTimings));
				break;
			case QueryType.CacheUtilization:
				flag = (typeof(T) != typeof(CacheUtilization));
				break;
			}
			if (flag)
			{
				throw new ArgumentException(string.Format("Unsupported data size [{0}] for type [{1}]. See documentation for expecting type.", typeof(T), type));
			}
			Result data2;
			if (typeof(T) == typeof(bool))
			{
				int num = 0;
				data2 = this.GetData(new IntPtr((void*)(&num)), 4, flush ? 1 : 0);
				data = (T)((object)Convert.ChangeType(num, typeof(T)));
			}
			else
			{
				data = default(T);
				fixed (T* value = &data)
				{
					data2 = this.GetData((IntPtr)((void*)value), Utilities.SizeOf<T>(), flush ? 1 : 0);
				}
			}
			if (data2 == Result.Ok)
			{
				return true;
			}
			if (data2 == Result.False)
			{
				return false;
			}
			data2.CheckError();
			return false;
		}
	}
}
