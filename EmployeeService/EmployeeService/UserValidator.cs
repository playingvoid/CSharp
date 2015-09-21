using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Selectors;

namespace EmployeeService
{
	public class UserValidator : UserNamePasswordValidator
	{
		public override void Validate(string userName, string password)
		{
			if ((null == userName || null == password) || userName != "varun" || password != "raj")
			{
				throw new UnauthorizedAccessException("Unauthorize access");
			}
		}
	}
}