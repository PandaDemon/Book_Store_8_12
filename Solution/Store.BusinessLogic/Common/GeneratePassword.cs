using System;
using System.Security.Cryptography;
using System.Text;

namespace Store.BusinessLogic.Common
{
	public class GeneratePassword
	{
		public const int PasswordLength = 6;
		public const string ValidSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz";

		public static string PasswordGenerate(int length)
		{
			var stringBuilder = new StringBuilder();
			using (var randonGenerator = new RNGCryptoServiceProvider())
			{
				byte[] uintBuffer = new byte[sizeof(uint)];

				for (int i = 0; i < length; i++)
				{
					randonGenerator.GetBytes(uintBuffer);
					uint numberOfCharacter = BitConverter.ToUInt32(uintBuffer, 0);
					stringBuilder.Append(ValidSymbols[(int)(numberOfCharacter % (uint)ValidSymbols.Length)]);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
