using System;
using System.Collections.Generic;
using System.Text;

namespace Store.BusinessLogic.Models
{
	public class JwtModel
	{
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }

		public JwtModel(string accessToken, string refreshToken)
		{
			AccessToken = accessToken;
			RefreshToken = refreshToken;
		}
	}
}
