using System;
using System.Globalization;
using System.IO;
using System.Numerics;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Bson
{
	// Token: 0x02000111 RID: 273
	[Obsolete("BSON reading and writing has been moved to its own package. See https://www.nuget.org/packages/Newtonsoft.Json.Bson for more details.")]
	public class BsonWriter : JsonWriter
	{
		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000DA4 RID: 3492 RVA: 0x000368ED File Offset: 0x00034AED
		// (set) Token: 0x06000DA5 RID: 3493 RVA: 0x000368FA File Offset: 0x00034AFA
		public DateTimeKind DateTimeKindHandling
		{
			get
			{
				return this._writer.DateTimeKindHandling;
			}
			set
			{
				this._writer.DateTimeKindHandling = value;
			}
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x00036908 File Offset: 0x00034B08
		public BsonWriter(Stream stream)
		{
			ValidationUtils.ArgumentNotNull(stream, "stream");
			this._writer = new BsonBinaryWriter(new BinaryWriter(stream));
		}

		// Token: 0x06000DA7 RID: 3495 RVA: 0x0003692C File Offset: 0x00034B2C
		public BsonWriter(BinaryWriter writer)
		{
			ValidationUtils.ArgumentNotNull(writer, "writer");
			this._writer = new BsonBinaryWriter(writer);
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x0003694B File Offset: 0x00034B4B
		public override void Flush()
		{
			this._writer.Flush();
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x00036958 File Offset: 0x00034B58
		protected override void WriteEnd(JsonToken token)
		{
			base.WriteEnd(token);
			this.RemoveParent();
			if (base.Top == 0)
			{
				this._writer.WriteToken(this._root);
			}
		}

		// Token: 0x06000DAA RID: 3498 RVA: 0x00036980 File Offset: 0x00034B80
		public override void WriteComment(string text)
		{
			throw JsonWriterException.Create(this, "Cannot write JSON comment as BSON.", null);
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x0003698E File Offset: 0x00034B8E
		public override void WriteStartConstructor(string name)
		{
			throw JsonWriterException.Create(this, "Cannot write JSON constructor as BSON.", null);
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x0003699C File Offset: 0x00034B9C
		public override void WriteRaw(string json)
		{
			throw JsonWriterException.Create(this, "Cannot write raw JSON as BSON.", null);
		}

		// Token: 0x06000DAD RID: 3501 RVA: 0x000369AA File Offset: 0x00034BAA
		public override void WriteRawValue(string json)
		{
			throw JsonWriterException.Create(this, "Cannot write raw JSON as BSON.", null);
		}

		// Token: 0x06000DAE RID: 3502 RVA: 0x000369B8 File Offset: 0x00034BB8
		public override void WriteStartArray()
		{
			base.WriteStartArray();
			this.AddParent(new BsonArray());
		}

		// Token: 0x06000DAF RID: 3503 RVA: 0x000369CB File Offset: 0x00034BCB
		public override void WriteStartObject()
		{
			base.WriteStartObject();
			this.AddParent(new BsonObject());
		}

		// Token: 0x06000DB0 RID: 3504 RVA: 0x000369DE File Offset: 0x00034BDE
		public override void WritePropertyName(string name)
		{
			base.WritePropertyName(name);
			this._propertyName = name;
		}

		// Token: 0x06000DB1 RID: 3505 RVA: 0x000369EE File Offset: 0x00034BEE
		public override void Close()
		{
			base.Close();
			if (base.CloseOutput)
			{
				BsonBinaryWriter writer = this._writer;
				if (writer == null)
				{
					return;
				}
				writer.Close();
			}
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x00036A0E File Offset: 0x00034C0E
		private void AddParent(BsonToken container)
		{
			this.AddToken(container);
			this._parent = container;
		}

		// Token: 0x06000DB3 RID: 3507 RVA: 0x00036A1E File Offset: 0x00034C1E
		private void RemoveParent()
		{
			this._parent = this._parent.Parent;
		}

		// Token: 0x06000DB4 RID: 3508 RVA: 0x00036A31 File Offset: 0x00034C31
		private void AddValue(object value, BsonType type)
		{
			this.AddToken(new BsonValue(value, type));
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x00036A40 File Offset: 0x00034C40
		internal void AddToken(BsonToken token)
		{
			if (this._parent != null)
			{
				BsonObject bsonObject = this._parent as BsonObject;
				if (bsonObject != null)
				{
					bsonObject.Add(this._propertyName, token);
					this._propertyName = null;
					return;
				}
				((BsonArray)this._parent).Add(token);
				return;
			}
			else
			{
				if (token.Type != BsonType.Object && token.Type != BsonType.Array)
				{
					throw JsonWriterException.Create(this, "Error writing {0} value. BSON must start with an Object or Array.".FormatWith(CultureInfo.InvariantCulture, token.Type), null);
				}
				this._parent = token;
				this._root = token;
				return;
			}
		}

		// Token: 0x06000DB6 RID: 3510 RVA: 0x00036AD0 File Offset: 0x00034CD0
		public override void WriteValue(object value)
		{
			if (value is BigInteger)
			{
				BigInteger bigInteger = (BigInteger)value;
				base.SetWriteState(JsonToken.Integer, null);
				this.AddToken(new BsonBinary(bigInteger.ToByteArray(), BsonBinaryType.Binary));
				return;
			}
			base.WriteValue(value);
		}

		// Token: 0x06000DB7 RID: 3511 RVA: 0x00036B0F File Offset: 0x00034D0F
		public override void WriteNull()
		{
			base.WriteNull();
			this.AddToken(BsonEmpty.Null);
		}

		// Token: 0x06000DB8 RID: 3512 RVA: 0x00036B22 File Offset: 0x00034D22
		public override void WriteUndefined()
		{
			base.WriteUndefined();
			this.AddToken(BsonEmpty.Undefined);
		}

		// Token: 0x06000DB9 RID: 3513 RVA: 0x00036B35 File Offset: 0x00034D35
		public override void WriteValue(string value)
		{
			base.WriteValue(value);
			this.AddToken((value == null) ? BsonEmpty.Null : new BsonString(value, true));
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x00036B55 File Offset: 0x00034D55
		public override void WriteValue(int value)
		{
			base.WriteValue(value);
			this.AddValue(value, BsonType.Integer);
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x00036B6C File Offset: 0x00034D6C
		[CLSCompliant(false)]
		public override void WriteValue(uint value)
		{
			if (value > 2147483647U)
			{
				throw JsonWriterException.Create(this, "Value is too large to fit in a signed 32 bit integer. BSON does not support unsigned values.", null);
			}
			base.WriteValue(value);
			this.AddValue(value, BsonType.Integer);
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x00036B98 File Offset: 0x00034D98
		public override void WriteValue(long value)
		{
			base.WriteValue(value);
			this.AddValue(value, BsonType.Long);
		}

		// Token: 0x06000DBD RID: 3517 RVA: 0x00036BAF File Offset: 0x00034DAF
		[CLSCompliant(false)]
		public override void WriteValue(ulong value)
		{
			if (value > 9223372036854775807UL)
			{
				throw JsonWriterException.Create(this, "Value is too large to fit in a signed 64 bit integer. BSON does not support unsigned values.", null);
			}
			base.WriteValue(value);
			this.AddValue(value, BsonType.Long);
		}

		// Token: 0x06000DBE RID: 3518 RVA: 0x00036BDF File Offset: 0x00034DDF
		public override void WriteValue(float value)
		{
			base.WriteValue(value);
			this.AddValue(value, BsonType.Number);
		}

		// Token: 0x06000DBF RID: 3519 RVA: 0x00036BF5 File Offset: 0x00034DF5
		public override void WriteValue(double value)
		{
			base.WriteValue(value);
			this.AddValue(value, BsonType.Number);
		}

		// Token: 0x06000DC0 RID: 3520 RVA: 0x00036C0B File Offset: 0x00034E0B
		public override void WriteValue(bool value)
		{
			base.WriteValue(value);
			this.AddToken(value ? BsonBoolean.True : BsonBoolean.False);
		}

		// Token: 0x06000DC1 RID: 3521 RVA: 0x00036C29 File Offset: 0x00034E29
		public override void WriteValue(short value)
		{
			base.WriteValue(value);
			this.AddValue(value, BsonType.Integer);
		}

		// Token: 0x06000DC2 RID: 3522 RVA: 0x00036C40 File Offset: 0x00034E40
		[CLSCompliant(false)]
		public override void WriteValue(ushort value)
		{
			base.WriteValue(value);
			this.AddValue(value, BsonType.Integer);
		}

		// Token: 0x06000DC3 RID: 3523 RVA: 0x00036C58 File Offset: 0x00034E58
		public override void WriteValue(char value)
		{
			base.WriteValue(value);
			string value2 = value.ToString(CultureInfo.InvariantCulture);
			this.AddToken(new BsonString(value2, true));
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x00036C88 File Offset: 0x00034E88
		public override void WriteValue(byte value)
		{
			base.WriteValue(value);
			this.AddValue(value, BsonType.Integer);
		}

		// Token: 0x06000DC5 RID: 3525 RVA: 0x00036C9F File Offset: 0x00034E9F
		[CLSCompliant(false)]
		public override void WriteValue(sbyte value)
		{
			base.WriteValue(value);
			this.AddValue(value, BsonType.Integer);
		}

		// Token: 0x06000DC6 RID: 3526 RVA: 0x00036CB6 File Offset: 0x00034EB6
		public override void WriteValue(decimal value)
		{
			base.WriteValue(value);
			this.AddValue(value, BsonType.Number);
		}

		// Token: 0x06000DC7 RID: 3527 RVA: 0x00036CCC File Offset: 0x00034ECC
		public override void WriteValue(DateTime value)
		{
			base.WriteValue(value);
			value = DateTimeUtils.EnsureDateTime(value, base.DateTimeZoneHandling);
			this.AddValue(value, BsonType.Date);
		}

		// Token: 0x06000DC8 RID: 3528 RVA: 0x00036CF1 File Offset: 0x00034EF1
		public override void WriteValue(DateTimeOffset value)
		{
			base.WriteValue(value);
			this.AddValue(value, BsonType.Date);
		}

		// Token: 0x06000DC9 RID: 3529 RVA: 0x00036D08 File Offset: 0x00034F08
		public override void WriteValue(byte[] value)
		{
			if (value == null)
			{
				this.WriteNull();
				return;
			}
			base.WriteValue(value);
			this.AddToken(new BsonBinary(value, BsonBinaryType.Binary));
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x00036D28 File Offset: 0x00034F28
		public override void WriteValue(Guid value)
		{
			base.WriteValue(value);
			this.AddToken(new BsonBinary(value.ToByteArray(), BsonBinaryType.Uuid));
		}

		// Token: 0x06000DCB RID: 3531 RVA: 0x00036D44 File Offset: 0x00034F44
		public override void WriteValue(TimeSpan value)
		{
			base.WriteValue(value);
			this.AddToken(new BsonString(value.ToString(), true));
		}

		// Token: 0x06000DCC RID: 3532 RVA: 0x00036D66 File Offset: 0x00034F66
		public override void WriteValue(Uri value)
		{
			if (value == null)
			{
				this.WriteNull();
				return;
			}
			base.WriteValue(value);
			this.AddToken(new BsonString(value.ToString(), true));
		}

		// Token: 0x06000DCD RID: 3533 RVA: 0x00036D91 File Offset: 0x00034F91
		public void WriteObjectId(byte[] value)
		{
			ValidationUtils.ArgumentNotNull(value, "value");
			if (value.Length != 12)
			{
				throw JsonWriterException.Create(this, "An object id must be 12 bytes", null);
			}
			base.SetWriteState(JsonToken.Undefined, null);
			this.AddValue(value, BsonType.Oid);
		}

		// Token: 0x06000DCE RID: 3534 RVA: 0x00036DC3 File Offset: 0x00034FC3
		public void WriteRegex(string pattern, string options)
		{
			ValidationUtils.ArgumentNotNull(pattern, "pattern");
			base.SetWriteState(JsonToken.Undefined, null);
			this.AddToken(new BsonRegex(pattern, options));
		}

		// Token: 0x04000440 RID: 1088
		private readonly BsonBinaryWriter _writer;

		// Token: 0x04000441 RID: 1089
		private BsonToken _root;

		// Token: 0x04000442 RID: 1090
		private BsonToken _parent;

		// Token: 0x04000443 RID: 1091
		private string _propertyName;
	}
}
