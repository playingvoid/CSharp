using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace EmployeeService
{
	[DataContract(Name = "ActiveEmployee", Namespace = "http://schemas.datacontract.org/2004/07/Domain.Model")]
	public class ActiveEmployee
	{
		[DataMember(Name = "ContactPhoneNo", Order = 1, EmitDefaultValue = false)]
		public string ContactPhoneNo { get; set; }

		[DataMember(Name = "FirstName", Order = 2, EmitDefaultValue = false)]
		public string FirstName { get; set; }

		[DataMember(Name = "HRStatus", Order = 3, EmitDefaultValue = false)]
		public string HRStatus { get; set; }

		[DataMember(Name = "LDAPId", Order = 4, EmitDefaultValue = false)]
		public string LDAPId { get; set; }

		[DataMember(Name = "LastName", Order = 5, EmitDefaultValue = false)]
		public string LastName { get; set; }

		[DataMember(Name = "MiddleName", Order = 6, EmitDefaultValue = false)]
		public string MiddleName { get; set; }

		[DataMember(Name = "ModifiedDate", Order = 7, EmitDefaultValue = false)]
		public string ModifiedDate { get; set; }

		[DataMember(Name = "WorkEmail", Order = 8, EmitDefaultValue = false)]
		public string WorkEmail { get; set; }

		[DataMember(Name = "WorkforceId", Order = 9, EmitDefaultValue = false)]
		public string WorkforceId { get; set; }

		public ActiveEmployee()
		{

		}
		public ActiveEmployee(string firstName, string middleName, string lastName, string contactPhoneNo, string hrStatus, string lDAPId, string modifiedDate, string workEmail, string workforceId)
		{
			ContactPhoneNo = contactPhoneNo;
			FirstName = firstName;
			MiddleName = middleName;
			LastName = lastName;
			HRStatus = hrStatus;
			LDAPId = lDAPId;
			ModifiedDate = modifiedDate;
			WorkEmail = workEmail;
			WorkforceId = workforceId;
		}
	}
}