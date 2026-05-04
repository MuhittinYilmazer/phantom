using System;
using System.Runtime.InteropServices;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000084 RID: 132
	internal sealed class InternalStructs64
	{
		// Token: 0x060001A8 RID: 424 RVA: 0x00013EB4 File Offset: 0x000120B4
		public static ulong GetLdr64(ulong addr)
		{
			return addr + 24UL;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0001398C File Offset: 0x00011B8C
		public static ulong GetRTL64(ulong addr)
		{
			return addr + 32UL;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x000038B4 File Offset: 0x00001AB4
		public InternalStructs64()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x060001AB RID: 427 RVA: 0x000038AD File Offset: 0x00001AAD
		static InternalStructs64()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}

		// Token: 0x02000085 RID: 133
		public struct PROCESS_BASIC_INFORMATION64
		{
			// Token: 0x04000462 RID: 1122
			public int ExitStatus;

			// Token: 0x04000463 RID: 1123
			public ulong PebBaseAddress;

			// Token: 0x04000464 RID: 1124
			public ulong AffinityMask;

			// Token: 0x04000465 RID: 1125
			public uint BasePriority;

			// Token: 0x04000466 RID: 1126
			public ulong UniqueProcessId;

			// Token: 0x04000467 RID: 1127
			public ulong InheritedFromUniqueProcessId;
		}

		// Token: 0x02000086 RID: 134
		public struct LIST_ENTRY64
		{
			// Token: 0x04000468 RID: 1128
			public ulong Flink;

			// Token: 0x04000469 RID: 1129
			public ulong Blink;
		}

		// Token: 0x02000087 RID: 135
		public struct PEB_LDR_DATA64
		{
			// Token: 0x0400046A RID: 1130
			public uint Length;

			// Token: 0x0400046B RID: 1131
			public bool Initialized;

			// Token: 0x0400046C RID: 1132
			public ulong SsHandle;

			// Token: 0x0400046D RID: 1133
			public InternalStructs64.LIST_ENTRY64 InLoadOrderModuleList;

			// Token: 0x0400046E RID: 1134
			public InternalStructs64.LIST_ENTRY64 InMemoryOrderModuleList;

			// Token: 0x0400046F RID: 1135
			public InternalStructs64.LIST_ENTRY64 InInitializationOrderModuleList;

			// Token: 0x04000470 RID: 1136
			public ulong EntryInProgress;

			// Token: 0x04000471 RID: 1137
			public bool ShutdownInProgress;

			// Token: 0x04000472 RID: 1138
			public ulong ShutdownThreadId;
		}

		// Token: 0x02000088 RID: 136
		public struct UNICODE_STRING64
		{
			// Token: 0x04000473 RID: 1139
			public ushort Length;

			// Token: 0x04000474 RID: 1140
			public ushort MaximumLength;

			// Token: 0x04000475 RID: 1141
			public ulong Buffer;
		}

		// Token: 0x02000089 RID: 137
		public struct STRING64
		{
			// Token: 0x04000476 RID: 1142
			public ushort Length;

			// Token: 0x04000477 RID: 1143
			public ushort MaximumLength;

			// Token: 0x04000478 RID: 1144
			public ulong Buffer;
		}

		// Token: 0x0200008A RID: 138
		public struct LDR_DATA_TABLE_ENTRY64_SNAP
		{
			// Token: 0x04000479 RID: 1145
			public InternalStructs64.LIST_ENTRY64 InLoadOrderLinks;

			// Token: 0x0400047A RID: 1146
			public InternalStructs64.LIST_ENTRY64 InMemoryOrderLinks;

			// Token: 0x0400047B RID: 1147
			public InternalStructs64.LIST_ENTRY64 InInitializationOrderLinks;

			// Token: 0x0400047C RID: 1148
			public ulong DllBase;

			// Token: 0x0400047D RID: 1149
			public ulong EntryPoint;

			// Token: 0x0400047E RID: 1150
			public uint SizeOfImage;

			// Token: 0x0400047F RID: 1151
			public InternalStructs64.UNICODE_STRING64 FullDllName;

			// Token: 0x04000480 RID: 1152
			public InternalStructs64.UNICODE_STRING64 BaseDllName;
		}

		// Token: 0x0200008B RID: 139
		public struct IMAGE_OPTIONAL_HEADER64
		{
			// Token: 0x04000481 RID: 1153
			public ushort Magic;

			// Token: 0x04000482 RID: 1154
			public byte MajorLinkerVersion;

			// Token: 0x04000483 RID: 1155
			public byte MinorLinkerVersion;

			// Token: 0x04000484 RID: 1156
			public uint SizeOfCode;

			// Token: 0x04000485 RID: 1157
			public uint SizeOfInitializedData;

			// Token: 0x04000486 RID: 1158
			public uint SizeOfUninitializedData;

			// Token: 0x04000487 RID: 1159
			public uint AddressOfEntryPoint;

			// Token: 0x04000488 RID: 1160
			public uint BaseOfCode;

			// Token: 0x04000489 RID: 1161
			public ulong ImageBase;

			// Token: 0x0400048A RID: 1162
			public uint SectionAlignment;

			// Token: 0x0400048B RID: 1163
			public uint FileAlignment;

			// Token: 0x0400048C RID: 1164
			public ushort MajorOperatingSystemVersion;

			// Token: 0x0400048D RID: 1165
			public ushort MinorOperatingSystemVersion;

			// Token: 0x0400048E RID: 1166
			public ushort MajorImageVersion;

			// Token: 0x0400048F RID: 1167
			public ushort MinorImageVersion;

			// Token: 0x04000490 RID: 1168
			public ushort MajorSubsystemVersion;

			// Token: 0x04000491 RID: 1169
			public ushort MinorSubsystemVersion;

			// Token: 0x04000492 RID: 1170
			public uint Win32VersionValue;

			// Token: 0x04000493 RID: 1171
			public uint SizeOfImage;

			// Token: 0x04000494 RID: 1172
			public uint SizeOfHeaders;

			// Token: 0x04000495 RID: 1173
			public uint CheckSum;

			// Token: 0x04000496 RID: 1174
			public ushort Subsystem;

			// Token: 0x04000497 RID: 1175
			public ushort DllCharacteristics;

			// Token: 0x04000498 RID: 1176
			public ulong SizeOfStackReserve;

			// Token: 0x04000499 RID: 1177
			public ulong SizeOfStackCommit;

			// Token: 0x0400049A RID: 1178
			public ulong SizeOfHeapReserve;

			// Token: 0x0400049B RID: 1179
			public ulong SizeOfHeapCommit;

			// Token: 0x0400049C RID: 1180
			public uint LoaderFlags;

			// Token: 0x0400049D RID: 1181
			public uint NumberOfRvaAndSizes;

			// Token: 0x0400049E RID: 1182
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public InternalStructs.IMAGE_DATA_DIRECTORY[] DataDirectory;
		}

		// Token: 0x0200008C RID: 140
		public struct IMAGE_NT_HEADERS64
		{
			// Token: 0x0400049F RID: 1183
			public uint Signature;

			// Token: 0x040004A0 RID: 1184
			public InternalStructs.IMAGE_FILE_HEADER FileHeader;

			// Token: 0x040004A1 RID: 1185
			public InternalStructs64.IMAGE_OPTIONAL_HEADER64 OptionalHeader;
		}

		// Token: 0x0200008D RID: 141
		public struct _RTL_DRIVE_LETTER_CURDIR
		{
			// Token: 0x040004A2 RID: 1186
			public ushort Flags;

			// Token: 0x040004A3 RID: 1187
			public ushort Length;

			// Token: 0x040004A4 RID: 1188
			public int TimeStamp;

			// Token: 0x040004A5 RID: 1189
			public InternalStructs64.STRING64 DosPath;
		}

		// Token: 0x0200008E RID: 142
		public struct _CURDIR
		{
			// Token: 0x040004A6 RID: 1190
			public InternalStructs64.UNICODE_STRING64 DosPath;

			// Token: 0x040004A7 RID: 1191
			public ulong Handle;
		}

		// Token: 0x0200008F RID: 143
		public struct RTL_USER_PROCESS_PARAMETERS64
		{
			// Token: 0x040004A8 RID: 1192
			public uint MaximumLength;

			// Token: 0x040004A9 RID: 1193
			public uint Length;

			// Token: 0x040004AA RID: 1194
			public uint Flags;

			// Token: 0x040004AB RID: 1195
			public uint DebugFlags;

			// Token: 0x040004AC RID: 1196
			public ulong ConsoleHandle;

			// Token: 0x040004AD RID: 1197
			public uint ConsoleFlags;

			// Token: 0x040004AE RID: 1198
			public ulong StandardInput;

			// Token: 0x040004AF RID: 1199
			public ulong StandardOutput;

			// Token: 0x040004B0 RID: 1200
			public ulong StandardError;

			// Token: 0x040004B1 RID: 1201
			public InternalStructs64._CURDIR CurrentDirectory;

			// Token: 0x040004B2 RID: 1202
			public InternalStructs64.UNICODE_STRING64 DllPath;

			// Token: 0x040004B3 RID: 1203
			public InternalStructs64.UNICODE_STRING64 ImagePathName;

			// Token: 0x040004B4 RID: 1204
			public InternalStructs64.UNICODE_STRING64 CommandLine;

			// Token: 0x040004B5 RID: 1205
			public ulong Environment;

			// Token: 0x040004B6 RID: 1206
			public uint StartingX;

			// Token: 0x040004B7 RID: 1207
			public uint StartingY;

			// Token: 0x040004B8 RID: 1208
			public uint CountX;

			// Token: 0x040004B9 RID: 1209
			public uint CountY;

			// Token: 0x040004BA RID: 1210
			public uint CountCharsX;

			// Token: 0x040004BB RID: 1211
			public uint CountCharsY;

			// Token: 0x040004BC RID: 1212
			public uint FillAttribute;

			// Token: 0x040004BD RID: 1213
			public uint WindowFlags;

			// Token: 0x040004BE RID: 1214
			public uint ShowWindowFlags;

			// Token: 0x040004BF RID: 1215
			public InternalStructs64.UNICODE_STRING64 WindowTitle;

			// Token: 0x040004C0 RID: 1216
			public InternalStructs64.UNICODE_STRING64 DesktopInfo;

			// Token: 0x040004C1 RID: 1217
			public InternalStructs64.UNICODE_STRING64 ShellInfo;

			// Token: 0x040004C2 RID: 1218
			public InternalStructs64.UNICODE_STRING64 RuntimeData;

			// Token: 0x040004C3 RID: 1219
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
			public InternalStructs64._RTL_DRIVE_LETTER_CURDIR[] CurrentDirectores;

			// Token: 0x040004C4 RID: 1220
			public ulong EnvironmentSize;

			// Token: 0x040004C5 RID: 1221
			public ulong EnvironmentVersion;

			// Token: 0x040004C6 RID: 1222
			public ulong PackageDependencyData;

			// Token: 0x040004C7 RID: 1223
			public uint ProcessGroupId;

			// Token: 0x040004C8 RID: 1224
			public uint LoaderThreads;

			// Token: 0x040004C9 RID: 1225
			public InternalStructs64.UNICODE_STRING64 RedirectionDllName;

			// Token: 0x040004CA RID: 1226
			public InternalStructs64.UNICODE_STRING64 HeapPartitionName;

			// Token: 0x040004CB RID: 1227
			public ulong DefaultThreadpoolCpuSetMasks;

			// Token: 0x040004CC RID: 1228
			public uint DefaultThreadpoolCpuSetMaskCount;

			// Token: 0x040004CD RID: 1229
			public uint DefaultThreadpoolThreadMaximum;
		}

		// Token: 0x02000090 RID: 144
		public struct CLIENT_ID64
		{
			// Token: 0x040004CE RID: 1230
			public ulong UniqueProcess;

			// Token: 0x040004CF RID: 1231
			public ulong UniqueThread;
		}

		// Token: 0x02000091 RID: 145
		[StructLayout(LayoutKind.Sequential)]
		public class THREAD_BASIC_INFORMATION64
		{
			// Token: 0x060001AC RID: 428 RVA: 0x000038B4 File Offset: 0x00001AB4
			public THREAD_BASIC_INFORMATION64()
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				base..ctor();
			}

			// Token: 0x060001AD RID: 429 RVA: 0x000038AD File Offset: 0x00001AAD
			static THREAD_BASIC_INFORMATION64()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x040004D0 RID: 1232
			public uint ExitStatus;

			// Token: 0x040004D1 RID: 1233
			public ulong TebBaseAddress;

			// Token: 0x040004D2 RID: 1234
			public InternalStructs64.CLIENT_ID64 ClientId;

			// Token: 0x040004D3 RID: 1235
			public ulong AffinityMask;

			// Token: 0x040004D4 RID: 1236
			public int Priority;

			// Token: 0x040004D5 RID: 1237
			public int BasePriority;
		}
	}
}
