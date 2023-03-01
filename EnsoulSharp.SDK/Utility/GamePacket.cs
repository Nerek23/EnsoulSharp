using System;
using System.IO;
using System.Linq;
using System.Text;
using SharpDX;

namespace EnsoulSharp.SDK.Utility
{
	// Token: 0x0200007A RID: 122
	public class GamePacket
	{
		// Token: 0x06000490 RID: 1168 RVA: 0x00023040 File Offset: 0x00021240
		public GamePacket(byte[] data)
		{
			this.Block = false;
			this.MemoryStream = new MemoryStream(data);
			this.BinaryReader = new BinaryReader(this.MemoryStream);
			this.BinaryWriter = new BinaryWriter(this.MemoryStream);
			this.BinaryReader.BaseStream.Position = 0L;
			this.BinaryWriter.BaseStream.Position = 0L;
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x000230AC File Offset: 0x000212AC
		public GamePacket(GamePacketEventArgs gamePacketEventArgs)
		{
			this.Block = false;
			this.MemoryStream = new MemoryStream(gamePacketEventArgs.PacketData);
			this.BinaryReader = new BinaryReader(this.MemoryStream);
			this.BinaryWriter = new BinaryWriter(this.MemoryStream);
			this.BinaryReader.BaseStream.Position = 0L;
			this.BinaryWriter.BaseStream.Position = 0L;
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x00023120 File Offset: 0x00021320
		public GamePacket(byte header)
		{
			this.Block = false;
			this.MemoryStream = new MemoryStream();
			this.BinaryReader = new BinaryReader(this.MemoryStream);
			this.BinaryWriter = new BinaryWriter(this.MemoryStream);
			this.BinaryReader.BaseStream.Position = 0L;
			this.BinaryWriter.BaseStream.Position = 0L;
			this.WriteByte(header, 1);
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000493 RID: 1171 RVA: 0x00023193 File Offset: 0x00021393
		// (set) Token: 0x06000494 RID: 1172 RVA: 0x0002319B File Offset: 0x0002139B
		public bool Block { get; set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x000231A4 File Offset: 0x000213A4
		public byte Header
		{
			get
			{
				return this.ReadByte(0L);
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000496 RID: 1174 RVA: 0x000231AE File Offset: 0x000213AE
		// (set) Token: 0x06000497 RID: 1175 RVA: 0x000231C0 File Offset: 0x000213C0
		public long Position
		{
			get
			{
				return this.BinaryReader.BaseStream.Position;
			}
			set
			{
				if (value >= 0L)
				{
					this.BinaryReader.BaseStream.Position = value;
				}
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x000231D8 File Offset: 0x000213D8
		private BinaryReader BinaryReader { get; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x000231E0 File Offset: 0x000213E0
		private BinaryWriter BinaryWriter { get; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x0600049A RID: 1178 RVA: 0x000231E8 File Offset: 0x000213E8
		public MemoryStream MemoryStream { get; }

		// Token: 0x0600049B RID: 1179 RVA: 0x000231F0 File Offset: 0x000213F0
		public string Dump(bool additionalInfo = false)
		{
			string text = string.Concat(from b in this.MemoryStream.ToArray()
			select b.ToString("X2") + " ");
			if (additionalInfo)
			{
				text = "Data: " + text;
			}
			return text;
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00023242 File Offset: 0x00021442
		public byte[] GetRawPacket()
		{
			return this.MemoryStream.ToArray();
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x0002324F File Offset: 0x0002144F
		public byte ReadByte(long position = -1L)
		{
			this.Position = position;
			return this.BinaryReader.ReadByte();
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00023263 File Offset: 0x00021463
		public float ReadFloat(long position = -1L)
		{
			this.Position = position;
			return BitConverter.ToSingle(this.BinaryReader.ReadBytes(4), 0);
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0002327E File Offset: 0x0002147E
		public int ReadInteger(long position = -1L)
		{
			this.Position = position;
			return BitConverter.ToInt32(this.BinaryReader.ReadBytes(4), 0);
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00023299 File Offset: 0x00021499
		public short ReadShort(long position = -1L)
		{
			this.Position = position;
			return BitConverter.ToInt16(this.BinaryReader.ReadBytes(2), 0);
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x000232B4 File Offset: 0x000214B4
		public string ReadString(long position = -1L)
		{
			this.Position = position;
			StringBuilder stringBuilder = new StringBuilder();
			for (long num = this.Position; num < this.Size(); num += 1L)
			{
				byte b = this.ReadByte(-1L);
				if (b == 0)
				{
					return stringBuilder.ToString();
				}
				stringBuilder.Append(Convert.ToChar(b));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x0002330B File Offset: 0x0002150B
		public int[] SearchByte(byte num)
		{
			return this.MemoryStream.ToArray().IndexOf(BitConverter.GetBytes((short)num)).ToArray<int>();
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00023328 File Offset: 0x00021528
		public int[] SearchFloat(float num)
		{
			return this.MemoryStream.ToArray().IndexOf(BitConverter.GetBytes(num)).ToArray<int>();
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00023348 File Offset: 0x00021548
		public int[][] SearchGameTile(Vector2 position)
		{
			Vector2 vector = NavMesh.WorldToGrid(position.X, position.Y);
			NavMeshCell cell = NavMesh.GetCell((int)((short)vector.X), (int)((short)vector.Y));
			int[] array = this.SearchShort((ushort)cell.GridX);
			int[] array2 = this.SearchShort((ushort)cell.GridY);
			return new int[][]
			{
				array,
				array2
			};
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x000233A5 File Offset: 0x000215A5
		public int[][] SearchGameTile(Vector3 position)
		{
			return this.SearchGameTile(position.ToVector2());
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x000233B3 File Offset: 0x000215B3
		public int[][] SearchGameTile(GameObject obj)
		{
			return this.SearchGameTile(obj.Position.ToVector2());
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x000233C8 File Offset: 0x000215C8
		public int[] SearchHexString(string hex)
		{
			hex = hex.Replace(" ", string.Empty);
			if (hex.Length % 2 != 0)
			{
				hex = "0" + hex;
			}
			return this.MemoryStream.ToArray().IndexOf((from x in Enumerable.Range(0, hex.Length)
			where x % 2 == 0
			select Convert.ToByte(hex.Substring(x, 2), 16)).ToArray<byte>()).ToArray<int>();
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00023482 File Offset: 0x00021682
		public int[] SearchInteger(int num)
		{
			return this.MemoryStream.ToArray().IndexOf(BitConverter.GetBytes(num)).ToArray<int>();
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x0002349F File Offset: 0x0002169F
		public int[] SearchObject(GameObject obj)
		{
			if (obj == null || !obj.IsValid || obj.NetworkId == 0)
			{
				return null;
			}
			return this.SearchInteger(obj.NetworkId);
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x000234C8 File Offset: 0x000216C8
		public int[] SearchObject(int networkId)
		{
			if (networkId != 0)
			{
				return this.SearchInteger(networkId);
			}
			return null;
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x000234D8 File Offset: 0x000216D8
		public int[][] SearchPosition(Vector2 position)
		{
			int[] array = this.SearchFloat(position.X);
			int[] array2 = this.SearchFloat(position.Y);
			if (array == null || array2 == null)
			{
				return null;
			}
			return new int[][]
			{
				array,
				array2
			};
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00023515 File Offset: 0x00021715
		public int[][] SearchPosition(Vector3 position)
		{
			return this.SearchPosition(position.ToVector2());
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x00023523 File Offset: 0x00021723
		public int[][] SearchPosition(GameObject obj)
		{
			return this.SearchPosition(obj.Position.ToVector2());
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00023538 File Offset: 0x00021738
		public int[][] SearchPosition(AIBaseClient unit)
		{
			int[][] array = this.SearchPosition(unit.Position.ToVector2());
			int[][] array2 = this.SearchPosition(unit.ServerPosition.ToVector2());
			if (array == null)
			{
				return array2;
			}
			if (array2 != null)
			{
				return null;
			}
			return array;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x00023574 File Offset: 0x00021774
		public int[] SearchShort(ushort num)
		{
			return this.MemoryStream.ToArray().IndexOf(BitConverter.GetBytes(num)).ToArray<int>();
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00023591 File Offset: 0x00021791
		public int[] SearchString(string str)
		{
			return this.MemoryStream.ToArray().IndexOf(str.GetBytes()).ToArray<int>();
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x000235AE File Offset: 0x000217AE
		public long Size()
		{
			return this.BinaryReader.BaseStream.Length;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x000235C0 File Offset: 0x000217C0
		public override string ToString()
		{
			return this.Dump(false);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x000235CC File Offset: 0x000217CC
		public void WriteByte(byte b, int repeat = 1)
		{
			for (int i = 0; i < repeat; i++)
			{
				this.BinaryWriter.Write(b);
			}
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x000235F1 File Offset: 0x000217F1
		public void WriteFloat(float f)
		{
			this.BinaryWriter.Write(f);
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00023600 File Offset: 0x00021800
		public void WriteHexString(string hex)
		{
			hex = hex.Replace(" ", string.Empty);
			if (hex.Length % 2 != 0)
			{
				hex = "0" + hex;
			}
			this.BinaryWriter.Write((from x in Enumerable.Range(0, hex.Length)
			where x % 2 == 0
			select Convert.ToByte(hex.Substring(x, 2), 16)).ToArray<byte>());
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x000236B0 File Offset: 0x000218B0
		public void WriteInteger(int i)
		{
			this.BinaryWriter.Write(i);
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x000236BE File Offset: 0x000218BE
		public void WriteShort(short s)
		{
			this.BinaryWriter.Write(s);
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x000236CC File Offset: 0x000218CC
		public void WriteString(string str)
		{
			this.BinaryWriter.Write(Encoding.UTF8.GetBytes(str));
		}
	}
}
