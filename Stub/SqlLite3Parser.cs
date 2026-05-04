using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000B2 RID: 178
	internal sealed class SqlLite3Parser
	{
		// Token: 0x0600027D RID: 637 RVA: 0x00018CB8 File Offset: 0x00016EB8
		public SqlLite3Parser(byte[] db_bytes)
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			this.fieldNames = new List<string>();
			this.tableEntries = new List<SqlLite3Parser.TableEntry>();
			this.MasterTableEntries = new List<SqlLite3Parser.MasterTableInfo>();
			this.stringEncoding = Encoding.UTF8;
			this.pageSize = 65536;
			this.reservedEndPageSize = 0;
			base..ctor();
			if (this.stringEncoding.GetString(db_bytes, 0, 16) != "SQLite format 3\0")
			{
				throw new Exception("Unsupported format");
			}
			this.DataBaseBytes = db_bytes;
			ushort num = this.ReadUShort(16);
			if (num != 1)
			{
				this.pageSize = (int)num;
			}
			this.reservedEndPageSize = (int)this.ReadByte(20);
			int num2 = this.ReadInt(56);
			if (num2 == 2)
			{
				this.stringEncoding = Encoding.Unicode;
			}
			else if (num2 == 3)
			{
				this.stringEncoding = Encoding.BigEndianUnicode;
			}
			this.ReadMasterTable(100);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00018D98 File Offset: 0x00016F98
		public bool ReadTable(string tableName)
		{
			SqlLite3Parser.MasterTableInfo masterTableInfo = default(SqlLite3Parser.MasterTableInfo);
			foreach (SqlLite3Parser.MasterTableInfo masterTableInfo2 in this.MasterTableEntries)
			{
				if (masterTableInfo2.typename.ToLower() == "table" && masterTableInfo2.name.ToLower() == tableName.ToLower())
				{
					masterTableInfo = masterTableInfo2;
					break;
				}
			}
			bool flag;
			if (masterTableInfo.sql_creation_command == null)
			{
				flag = false;
			}
			else
			{
				this.tableEntries.Clear();
				this.fieldNames.Clear();
				string[] array = this.ExtractColumnNames(masterTableInfo.sql_creation_command);
				if (this.ReadTableFromOffset((masterTableInfo.rootpage - 1) * this.pageSize))
				{
					this.fieldNames.AddRange(array);
					flag = true;
				}
				else
				{
					flag = false;
				}
			}
			return flag;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00018E84 File Offset: 0x00017084
		public string[] GetTableNames()
		{
			List<string> list = new List<string>();
			foreach (SqlLite3Parser.MasterTableInfo masterTableInfo in this.MasterTableEntries)
			{
				if (masterTableInfo.typename.ToLower() == "table")
				{
					list.Add(masterTableInfo.table_name);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00018F04 File Offset: 0x00017104
		public int GetRowCount()
		{
			return this.tableEntries.Count;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00018F20 File Offset: 0x00017120
		public string GetTableSqlCommand(string tableName)
		{
			foreach (SqlLite3Parser.MasterTableInfo masterTableInfo in this.MasterTableEntries)
			{
				if (masterTableInfo.table_name.ToLower() == tableName.ToLower())
				{
					return masterTableInfo.sql_creation_command;
				}
			}
			return null;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00018F94 File Offset: 0x00017194
		public object GetValue(int index, string value)
		{
			if (index > this.tableEntries.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int num = this.fieldNames.IndexOf(value);
			if (num == -1)
			{
				throw new Exception("could not find value");
			}
			object obj;
			if (value.ToLower() == "id" && this.tableEntries[index].values[num] == null)
			{
				obj = this.tableEntries[index].rowId;
			}
			else
			{
				obj = this.tableEntries[index].values[num];
			}
			return obj;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00019038 File Offset: 0x00017238
		public T GetValue<T>(int index, string value)
		{
			T t;
			try
			{
				object value2 = this.GetValue(index, value);
				t = (T)((object)value2);
			}
			catch
			{
				t = default(T);
			}
			return t;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00003F93 File Offset: 0x00002193
		public void reset()
		{
			this.tableEntries.Clear();
			this.fieldNames.Clear();
			this.MasterTableEntries.Clear();
			this.ReadMasterTable(100);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00019078 File Offset: 0x00017278
		private bool ReadTableFromOffset(int offset)
		{
			byte b = this.DataBaseBytes[offset];
			bool flag;
			if (b == 2)
			{
				flag = false;
			}
			else if (b == 5)
			{
				flag = this.ParseInteriorTable(offset);
			}
			else
			{
				flag = b != 10 && b == 13 && this.ParseLeafTablePage(offset);
			}
			return flag;
		}

		// Token: 0x06000286 RID: 646 RVA: 0x000190C8 File Offset: 0x000172C8
		private bool ParseInteriorTable(int headerOffset)
		{
			int num = (int)this.ReadUShort(headerOffset + 3);
			int num2 = this.ReadInt(headerOffset + 8);
			int num3 = headerOffset + 12;
			for (int i = 0; i < num; i++)
			{
				int num4 = (int)this.ReadUShort(num3 + 2 * i);
				int num5;
				if (headerOffset < this.pageSize)
				{
					num5 = this.ReadInt(num4);
				}
				else
				{
					num5 = this.ReadInt(headerOffset + num4);
				}
				if (!this.ReadTableFromOffset((num5 - 1) * this.pageSize))
				{
					return false;
				}
			}
			return this.ReadTableFromOffset((num2 - 1) * this.pageSize);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00019168 File Offset: 0x00017368
		private bool ParseLeafTablePage(int headerOffset)
		{
			int num = (int)this.ReadUShort(headerOffset + 3);
			int num2 = headerOffset + 8;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (int)this.ReadUShort(num2 + 2 * i);
			}
			foreach (int num3 in array)
			{
				if (headerOffset >= this.pageSize)
				{
					num3 += headerOffset;
				}
				int num5;
				int num4 = (int)this.ReadVarInt(num3, out num5);
				num3 += num5;
				int num6 = (int)this.ReadVarInt(num3, out num5);
				num3 += num5;
				List<int> list = new List<int>();
				long num7 = this.ReadVarInt(num3, out num5);
				num3 += num5;
				long num8 = (long)num3 + num7 - (long)num5;
				while ((long)num3 < num8)
				{
					list.Add((int)this.ReadVarInt(num3, out num5));
					num3 += num5;
				}
				List<object> list2 = new List<object>();
				foreach (int num9 in list)
				{
					object obj;
					if (num9 == 0)
					{
						obj = null;
						num3 = num3;
					}
					else if (num9 == 1)
					{
						obj = this.ReadByte(num3);
						num3++;
					}
					else if (num9 == 2)
					{
						obj = this.ReadShort(num3);
						num3 += 2;
					}
					else if (num9 == 3)
					{
						obj = this.ReadX(num3, 3);
						num3 += 3;
					}
					else if (num9 == 4)
					{
						obj = this.ReadInt(num3);
						num3 += 4;
					}
					else if (num9 == 5)
					{
						obj = this.ReadX(num3, 6);
						num3 += 6;
					}
					else if (num9 == 6)
					{
						obj = this.ReadLong(num3);
						num3 += 8;
					}
					else if (num9 == 7)
					{
						obj = this.ReadDouble(num3);
						num3 += 8;
					}
					else if (num9 == 8)
					{
						obj = 0;
						num3 = num3;
					}
					else if (num9 == 9)
					{
						obj = 1;
						num3 = num3;
					}
					else if (num9 >= 12 && num9 % 2 == 0)
					{
						int num10 = (num9 - 12) / 2;
						byte[] array2 = new byte[num10];
						Array.Copy(this.DataBaseBytes, num3, array2, 0, num10);
						obj = array2;
						num3 += num10;
					}
					else
					{
						if (num9 < 13 || num9 % 2 != 1)
						{
							continue;
						}
						int num11 = (num9 - 13) / 2;
						obj = this.stringEncoding.GetString(this.DataBaseBytes, num3, num11);
						num3 += num11;
					}
					list2.Add(obj);
				}
				this.tableEntries.Add(new SqlLite3Parser.TableEntry(num6, list2.ToArray()));
			}
			return true;
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0001946C File Offset: 0x0001766C
		private bool ReadMasterTable(int offset)
		{
			byte b = this.DataBaseBytes[offset];
			bool flag;
			if (b == 2)
			{
				flag = false;
			}
			else if (b == 5)
			{
				flag = this.ParseMasterInteriorTable(offset);
			}
			else
			{
				flag = b != 10 && b == 13 && this.ParseMasterLeafTablePage(offset);
			}
			return flag;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x000194BC File Offset: 0x000176BC
		private bool ParseMasterInteriorTable(int headerOffset)
		{
			int num = (int)this.ReadUShort(headerOffset + 3);
			int num2 = this.ReadInt(headerOffset + 8);
			int num3 = headerOffset + 12;
			for (int i = 0; i < num; i++)
			{
				int num4 = (int)this.ReadUShort(num3 + 2 * i);
				int num5;
				if (headerOffset < this.pageSize)
				{
					num5 = this.ReadInt(num4);
				}
				else
				{
					num5 = this.ReadInt(headerOffset + num4);
				}
				if (!this.ReadMasterTable((num5 - 1) * this.pageSize))
				{
					return false;
				}
			}
			return this.ReadMasterTable((num2 - 1) * this.pageSize);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0001955C File Offset: 0x0001775C
		private bool ParseMasterLeafTablePage(int headerOffset)
		{
			int num = (int)this.ReadUShort(headerOffset + 3);
			int num2 = headerOffset + 8;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (int)this.ReadUShort(num2 + 2 * i);
			}
			foreach (int num3 in array)
			{
				if (headerOffset >= this.pageSize)
				{
					num3 += headerOffset;
				}
				int num5;
				int num4 = (int)this.ReadVarInt(num3, out num5);
				num3 += num5;
				int num6 = (int)this.ReadVarInt(num3, out num5);
				num3 += num5;
				List<int> list = new List<int>();
				long num7 = this.ReadVarInt(num3, out num5);
				num3 += num5;
				long num8 = (long)num3 + num7 - (long)num5;
				while ((long)num3 < num8)
				{
					list.Add((int)this.ReadVarInt(num3, out num5));
					num3 += num5;
				}
				if (list.Count == 5)
				{
					List<object> list2 = new List<object>();
					foreach (int num9 in list)
					{
						object obj;
						if (num9 == 0)
						{
							obj = null;
							num3 = num3;
						}
						else if (num9 == 1)
						{
							obj = this.ReadByte(num3);
							num3++;
						}
						else if (num9 == 2)
						{
							obj = this.ReadShort(num3);
							num3 += 2;
						}
						else if (num9 == 3)
						{
							obj = this.ReadX(num3, 3);
							num3 += 3;
						}
						else if (num9 == 4)
						{
							obj = this.ReadInt(num3);
							num3 += 4;
						}
						else if (num9 == 5)
						{
							obj = this.ReadX(num3, 6);
							num3 += 6;
						}
						else if (num9 == 6)
						{
							obj = this.ReadLong(num3);
							num3 += 8;
						}
						else if (num9 == 7)
						{
							obj = this.ReadDouble(num3);
							num3 += 8;
						}
						else if (num9 == 8)
						{
							obj = 0;
							num3 = num3;
						}
						else if (num9 == 9)
						{
							obj = 1;
							num3 = num3;
						}
						else if (num9 >= 12 && num9 % 2 == 0)
						{
							int num10 = (num9 - 12) / 2;
							byte[] array2 = new byte[num10];
							Array.Copy(this.DataBaseBytes, num3, array2, 0, num10);
							obj = array2;
							num3 += num10;
						}
						else
						{
							if (num9 < 13 || num9 % 2 != 1)
							{
								continue;
							}
							int num11 = (num9 - 13) / 2;
							obj = this.stringEncoding.GetString(this.DataBaseBytes, num3, num11);
							num3 += num11;
						}
						list2.Add(obj);
					}
					if (!list2.Contains(null) && list2.Count == 5 && !(list2[0].GetType() != typeof(string)) && !(list2[1].GetType() != typeof(string)) && !(list2[2].GetType() != typeof(string)) && (!(list2[3].GetType() != typeof(int)) || !(list2[3].GetType() != typeof(byte))) && !(list2[4].GetType() != typeof(string)))
					{
						string text = (string)list2[0];
						string text2 = (string)list2[1];
						string text3 = (string)list2[2];
						int num12 = ((list2.GetType() == typeof(byte)) ? ((int)list2[3]) : ((int)((byte)list2[3])));
						string text4 = (string)list2[4];
						this.MasterTableEntries.Add(new SqlLite3Parser.MasterTableInfo(num6, text, text2, text3, num12, text4));
					}
				}
			}
			return true;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x000199C0 File Offset: 0x00017BC0
		private string[] ExtractColumnNames(string createTableSql)
		{
			List<string> list = new List<string>();
			string value = Regex.Match(createTableSql, "\\((.*?)\\)", RegexOptions.Singleline).Groups[1].Value;
			string[] array = value.Split(new char[] { ',' });
			foreach (string text in array)
			{
				string value2 = Regex.Match(text.Trim(), "^\\s*(\\w+)").Groups[1].Value;
				list.Add(value2);
			}
			return list.ToArray();
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00019A54 File Offset: 0x00017C54
		private long ReadVarInt(int offset, out int bytesRead)
		{
			long num = 0L;
			bytesRead = 0;
			for (int i = 0; i < 9; i++)
			{
				byte b = this.DataBaseBytes[offset + i];
				num = (num << 7) | (long)(b & 127);
				bytesRead++;
				if ((b & 128) == 0)
				{
					break;
				}
			}
			return num;
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00019AAC File Offset: 0x00017CAC
		private ulong ReadX(int StartIndex, int size)
		{
			ulong num;
			if (size > 8 || size == 0)
			{
				num = 0UL;
			}
			else
			{
				ulong num2 = 0UL;
				int num3 = size - 1;
				for (int i = 0; i <= num3; i++)
				{
					num2 = (num2 << 8) | (ulong)this.DataBaseBytes[StartIndex + i];
				}
				num = num2;
			}
			return num;
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00019B0C File Offset: 0x00017D0C
		private ulong ReadULong(int StartIndex)
		{
			return this.ReadX(StartIndex, 8);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00019B24 File Offset: 0x00017D24
		private long ReadLong(int StartIndex)
		{
			return (long)this.ReadX(StartIndex, 8);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00019B3C File Offset: 0x00017D3C
		private uint ReadUInt(int StartIndex)
		{
			return (uint)this.ReadX(StartIndex, 4);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00019B54 File Offset: 0x00017D54
		private int ReadInt(int StartIndex)
		{
			return (int)this.ReadX(StartIndex, 4);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00019B6C File Offset: 0x00017D6C
		private ushort ReadUShort(int StartIndex)
		{
			return (ushort)this.ReadX(StartIndex, 2);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00019B84 File Offset: 0x00017D84
		private short ReadShort(int StartIndex)
		{
			return (short)this.ReadX(StartIndex, 2);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00019B9C File Offset: 0x00017D9C
		private byte ReadByte(int StartIndex)
		{
			return this.DataBaseBytes[StartIndex];
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00019BB4 File Offset: 0x00017DB4
		private double ReadDouble(int Startindex)
		{
			return BitConverter.ToDouble(this.DataBaseBytes, Startindex);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x000038AD File Offset: 0x00001AAD
		static SqlLite3Parser()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}

		// Token: 0x04000559 RID: 1369
		private List<string> fieldNames;

		// Token: 0x0400055A RID: 1370
		private List<SqlLite3Parser.TableEntry> tableEntries;

		// Token: 0x0400055B RID: 1371
		private List<SqlLite3Parser.MasterTableInfo> MasterTableEntries;

		// Token: 0x0400055C RID: 1372
		private Encoding stringEncoding;

		// Token: 0x0400055D RID: 1373
		private int pageSize;

		// Token: 0x0400055E RID: 1374
		private int reservedEndPageSize;

		// Token: 0x0400055F RID: 1375
		private byte[] DataBaseBytes;

		// Token: 0x020000B3 RID: 179
		private struct MasterTableInfo
		{
			// Token: 0x06000297 RID: 663 RVA: 0x00003FBF File Offset: 0x000021BF
			public MasterTableInfo(int _rowId, string _typename, string _name, string _table_name, int _rootpage, string _sql_creation_command)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.rowId = _rowId;
				this.typename = _typename;
				this.name = _name;
				this.table_name = _table_name;
				this.rootpage = _rootpage;
				this.sql_creation_command = _sql_creation_command;
			}

			// Token: 0x06000298 RID: 664 RVA: 0x000038AD File Offset: 0x00001AAD
			static MasterTableInfo()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x04000560 RID: 1376
			public int rowId;

			// Token: 0x04000561 RID: 1377
			public string typename;

			// Token: 0x04000562 RID: 1378
			public string name;

			// Token: 0x04000563 RID: 1379
			public string table_name;

			// Token: 0x04000564 RID: 1380
			public int rootpage;

			// Token: 0x04000565 RID: 1381
			public string sql_creation_command;
		}

		// Token: 0x020000B4 RID: 180
		private struct TableEntry
		{
			// Token: 0x06000299 RID: 665 RVA: 0x00003FF3 File Offset: 0x000021F3
			public TableEntry(int _rowId, object[] _values)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.rowId = _rowId;
				this.values = _values;
			}

			// Token: 0x0600029A RID: 666 RVA: 0x000038AD File Offset: 0x00001AAD
			static TableEntry()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x04000566 RID: 1382
			public int rowId;

			// Token: 0x04000567 RID: 1383
			public object[] values;
		}
	}
}
