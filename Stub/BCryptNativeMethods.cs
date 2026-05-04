using System;
using System.Runtime.InteropServices;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x0200000F RID: 15
	internal sealed class BCryptNativeMethods
	{
		// Token: 0x0600003B RID: 59
		[DllImport("bcrypt.dll")]
		public static extern uint BCryptOpenAlgorithmProvider(out IntPtr phAlgorithm, [MarshalAs(UnmanagedType.LPWStr)] string pszAlgId, [MarshalAs(UnmanagedType.LPWStr)] string pszImplementation, uint dwFlags);

		// Token: 0x0600003C RID: 60
		[DllImport("bcrypt.dll")]
		public static extern uint BCryptCloseAlgorithmProvider(IntPtr hAlgorithm, uint flags);

		// Token: 0x0600003D RID: 61
		[DllImport("bcrypt.dll")]
		public static extern uint BCryptGetProperty(IntPtr hObject, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, IntPtr pbOutput, uint cbOutput, ref uint pcbResult, uint flags);

		// Token: 0x0600003E RID: 62
		[DllImport("bcrypt.dll")]
		internal static extern uint BCryptSetProperty(IntPtr hObject, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, byte[] pbInput, uint cbInput, uint dwFlags);

		// Token: 0x0600003F RID: 63
		[DllImport("bcrypt.dll")]
		private static extern uint BCryptImportKey(IntPtr hAlgorithm, IntPtr hImportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, out IntPtr phKey, IntPtr pbKeyObject, uint cbKeyObject, IntPtr pbInput, uint cbInput, uint dwFlags);

		// Token: 0x06000040 RID: 64 RVA: 0x000072A4 File Offset: 0x000054A4
		public static uint BCryptImportKey_KeyDataBlob(IntPtr hAlgorithm, IntPtr hImportKey, out IntPtr phKey, IntPtr pbKeyObject, uint cbKeyObject, IntPtr pbInput, uint cbInput)
		{
			return BCryptNativeMethods.BCryptImportKey(hAlgorithm, hImportKey, BCryptNativeMethods.BCRYPT_KEY_DATA_BLOB, out phKey, pbKeyObject, cbKeyObject, pbInput, cbInput, 0U);
		}

		// Token: 0x06000041 RID: 65
		[DllImport("bcrypt.dll")]
		public static extern uint BCryptDestroyKey(IntPtr hKey);

		// Token: 0x06000042 RID: 66
		[DllImport("bcrypt.dll")]
		internal static extern uint BCryptDecrypt(IntPtr hKey, byte[] pbInput, uint cbInput, ref BCryptInternalStructs.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO pPaddingInfo, byte[] pbIV, uint cbIV, byte[] pbOutput, uint cbOutput, ref int pcbResult, uint dwFlags);

		// Token: 0x06000043 RID: 67 RVA: 0x000038B4 File Offset: 0x00001AB4
		public BCryptNativeMethods()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003958 File Offset: 0x00001B58
		static BCryptNativeMethods()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			BCryptNativeMethods.BCRYPT_KEY_DATA_BLOB = "KeyDataBlob";
		}

		// Token: 0x0400003A RID: 58
		private static string BCRYPT_KEY_DATA_BLOB;
	}
}
