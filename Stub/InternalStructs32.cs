using System;
using System.Runtime.InteropServices;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000079 RID: 121
	internal sealed class InternalStructs32
	{
		// Token: 0x060001A4 RID: 420 RVA: 0x00013E84 File Offset: 0x00012084
		public static IntPtr GetLdr32(IntPtr addr)
		{
			return addr + 12;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00013E9C File Offset: 0x0001209C
		public static IntPtr GetRTL32(IntPtr addr)
		{
			return addr + 16;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x000038B4 File Offset: 0x00001AB4
		public InternalStructs32()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x000038AD File Offset: 0x00001AAD
		static InternalStructs32()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}

		// Token: 0x0200007A RID: 122
		public struct LIST_ENTRY32
		{
			// Token: 0x040003FB RID: 1019
			public uint Flink;

			// Token: 0x040003FC RID: 1020
			public uint Blink;
		}

		// Token: 0x0200007B RID: 123
		public struct PEB_LDR_DATA32
		{
			// Token: 0x040003FD RID: 1021
			public uint Length;

			// Token: 0x040003FE RID: 1022
			public bool Initialized;

			// Token: 0x040003FF RID: 1023
			public uint SsHandle;

			// Token: 0x04000400 RID: 1024
			public InternalStructs32.LIST_ENTRY32 InLoadOrderModuleList;

			// Token: 0x04000401 RID: 1025
			public InternalStructs32.LIST_ENTRY32 InMemoryOrderModuleList;

			// Token: 0x04000402 RID: 1026
			public InternalStructs32.LIST_ENTRY32 InInitializationOrderModuleList;

			// Token: 0x04000403 RID: 1027
			public uint EntryInProgress;

			// Token: 0x04000404 RID: 1028
			public bool ShutdownInProgress;

			// Token: 0x04000405 RID: 1029
			public uint ShutdownThreadId;
		}

		// Token: 0x0200007C RID: 124
		public struct UNICODE_STRING32
		{
			// Token: 0x04000406 RID: 1030
			public ushort Length;

			// Token: 0x04000407 RID: 1031
			public ushort MaximumLength;

			// Token: 0x04000408 RID: 1032
			public uint Buffer;
		}

		// Token: 0x0200007D RID: 125
		public struct LDR_DATA_TABLE_ENTRY32_SNAP
		{
			// Token: 0x04000409 RID: 1033
			public InternalStructs32.LIST_ENTRY32 InLoadOrderLinks;

			// Token: 0x0400040A RID: 1034
			public InternalStructs32.LIST_ENTRY32 InMemoryOrderLinks;

			// Token: 0x0400040B RID: 1035
			public InternalStructs32.LIST_ENTRY32 InInitializationOrderLinks;

			// Token: 0x0400040C RID: 1036
			public uint DllBase;

			// Token: 0x0400040D RID: 1037
			public uint EntryPoint;

			// Token: 0x0400040E RID: 1038
			public uint SizeOfImage;

			// Token: 0x0400040F RID: 1039
			public InternalStructs32.UNICODE_STRING32 FullDllName;

			// Token: 0x04000410 RID: 1040
			public InternalStructs32.UNICODE_STRING32 BaseDllName;
		}

		// Token: 0x0200007E RID: 126
		public struct IMAGE_OPTIONAL_HEADER32
		{
			// Token: 0x04000411 RID: 1041
			public ushort Magic;

			// Token: 0x04000412 RID: 1042
			public byte MajorLinkerVersion;

			// Token: 0x04000413 RID: 1043
			public byte MinorLinkerVersion;

			// Token: 0x04000414 RID: 1044
			public uint SizeOfCode;

			// Token: 0x04000415 RID: 1045
			public uint SizeOfInitializedData;

			// Token: 0x04000416 RID: 1046
			public uint SizeOfUninitializedData;

			// Token: 0x04000417 RID: 1047
			public uint AddressOfEntryPoint;

			// Token: 0x04000418 RID: 1048
			public uint BaseOfCode;

			// Token: 0x04000419 RID: 1049
			public uint BaseOfData;

			// Token: 0x0400041A RID: 1050
			public uint ImageBase;

			// Token: 0x0400041B RID: 1051
			public uint SectionAlignment;

			// Token: 0x0400041C RID: 1052
			public uint FileAlignment;

			// Token: 0x0400041D RID: 1053
			public ushort MajorOperatingSystemVersion;

			// Token: 0x0400041E RID: 1054
			public ushort MinorOperatingSystemVersion;

			// Token: 0x0400041F RID: 1055
			public ushort MajorImageVersion;

			// Token: 0x04000420 RID: 1056
			public ushort MinorImageVersion;

			// Token: 0x04000421 RID: 1057
			public ushort MajorSubsystemVersion;

			// Token: 0x04000422 RID: 1058
			public ushort MinorSubsystemVersion;

			// Token: 0x04000423 RID: 1059
			public uint Win32VersionValue;

			// Token: 0x04000424 RID: 1060
			public uint SizeOfImage;

			// Token: 0x04000425 RID: 1061
			public uint SizeOfHeaders;

			// Token: 0x04000426 RID: 1062
			public uint CheckSum;

			// Token: 0x04000427 RID: 1063
			public ushort Subsystem;

			// Token: 0x04000428 RID: 1064
			public ushort DllCharacteristics;

			// Token: 0x04000429 RID: 1065
			public uint SizeOfStackReserve;

			// Token: 0x0400042A RID: 1066
			public uint SizeOfStackCommit;

			// Token: 0x0400042B RID: 1067
			public uint SizeOfHeapReserve;

			// Token: 0x0400042C RID: 1068
			public uint SizeOfHeapCommit;

			// Token: 0x0400042D RID: 1069
			public uint LoaderFlags;

			// Token: 0x0400042E RID: 1070
			public uint NumberOfRvaAndSizes;

			// Token: 0x0400042F RID: 1071
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public InternalStructs.IMAGE_DATA_DIRECTORY[] DataDirectory;
		}

		// Token: 0x0200007F RID: 127
		public struct IMAGE_NT_HEADERS32
		{
			// Token: 0x04000430 RID: 1072
			public uint Signature;

			// Token: 0x04000431 RID: 1073
			public InternalStructs.IMAGE_FILE_HEADER FileHeader;

			// Token: 0x04000432 RID: 1074
			public InternalStructs32.IMAGE_OPTIONAL_HEADER32 OptionalHeader;
		}

		// Token: 0x02000080 RID: 128
		public struct STRING32
		{
			// Token: 0x04000433 RID: 1075
			public ushort Length;

			// Token: 0x04000434 RID: 1076
			public ushort MaximumLength;

			// Token: 0x04000435 RID: 1077
			public uint Buffer;
		}

		// Token: 0x02000081 RID: 129
		public struct _RTL_DRIVE_LETTER_CURDIR32
		{
			// Token: 0x04000436 RID: 1078
			public ushort Flags;

			// Token: 0x04000437 RID: 1079
			public ushort Length;

			// Token: 0x04000438 RID: 1080
			public int TimeStamp;

			// Token: 0x04000439 RID: 1081
			public InternalStructs32.STRING32 DosPath;
		}

		// Token: 0x02000082 RID: 130
		public struct _CURDIR32
		{
			// Token: 0x0400043A RID: 1082
			public InternalStructs32.UNICODE_STRING32 DosPath;

			// Token: 0x0400043B RID: 1083
			public uint Handle;
		}

		// Token: 0x02000083 RID: 131
		public struct RTL_USER_PROCESS_PARAMETERS32
		{
			// Token: 0x0400043C RID: 1084
			public uint MaximumLength;

			// Token: 0x0400043D RID: 1085
			public uint Length;

			// Token: 0x0400043E RID: 1086
			public uint Flags;

			// Token: 0x0400043F RID: 1087
			public uint DebugFlags;

			// Token: 0x04000440 RID: 1088
			public uint ConsoleHandle;

			// Token: 0x04000441 RID: 1089
			public uint ConsoleFlags;

			// Token: 0x04000442 RID: 1090
			public uint StandardInput;

			// Token: 0x04000443 RID: 1091
			public uint StandardOutput;

			// Token: 0x04000444 RID: 1092
			public uint StandardError;

			// Token: 0x04000445 RID: 1093
			public InternalStructs32._CURDIR32 CurrentDirectory;

			// Token: 0x04000446 RID: 1094
			public InternalStructs32.UNICODE_STRING32 DllPath;

			// Token: 0x04000447 RID: 1095
			public InternalStructs32.UNICODE_STRING32 ImagePathName;

			// Token: 0x04000448 RID: 1096
			public InternalStructs32.UNICODE_STRING32 CommandLine;

			// Token: 0x04000449 RID: 1097
			public uint Environment;

			// Token: 0x0400044A RID: 1098
			public uint StartingX;

			// Token: 0x0400044B RID: 1099
			public uint StartingY;

			// Token: 0x0400044C RID: 1100
			public uint CountX;

			// Token: 0x0400044D RID: 1101
			public uint CountY;

			// Token: 0x0400044E RID: 1102
			public uint CountCharsX;

			// Token: 0x0400044F RID: 1103
			public uint CountCharsY;

			// Token: 0x04000450 RID: 1104
			public uint FillAttribute;

			// Token: 0x04000451 RID: 1105
			public uint WindowFlags;

			// Token: 0x04000452 RID: 1106
			public uint ShowWindowFlags;

			// Token: 0x04000453 RID: 1107
			public InternalStructs32.UNICODE_STRING32 WindowTitle;

			// Token: 0x04000454 RID: 1108
			public InternalStructs32.UNICODE_STRING32 DesktopInfo;

			// Token: 0x04000455 RID: 1109
			public InternalStructs32.UNICODE_STRING32 ShellInfo;

			// Token: 0x04000456 RID: 1110
			public InternalStructs32.UNICODE_STRING32 RuntimeData;

			// Token: 0x04000457 RID: 1111
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
			public InternalStructs32._RTL_DRIVE_LETTER_CURDIR32[] CurrentDirectores;

			// Token: 0x04000458 RID: 1112
			public uint EnvironmentSize;

			// Token: 0x04000459 RID: 1113
			public uint EnvironmentVersion;

			// Token: 0x0400045A RID: 1114
			public uint PackageDependencyData;

			// Token: 0x0400045B RID: 1115
			public uint ProcessGroupId;

			// Token: 0x0400045C RID: 1116
			public uint LoaderThreads;

			// Token: 0x0400045D RID: 1117
			public InternalStructs32.UNICODE_STRING32 RedirectionDllName;

			// Token: 0x0400045E RID: 1118
			public InternalStructs32.UNICODE_STRING32 HeapPartitionName;

			// Token: 0x0400045F RID: 1119
			public uint DefaultThreadpoolCpuSetMasks;

			// Token: 0x04000460 RID: 1120
			public uint DefaultThreadpoolCpuSetMaskCount;

			// Token: 0x04000461 RID: 1121
			public uint DefaultThreadpoolThreadMaximum;
		}
	}
}
