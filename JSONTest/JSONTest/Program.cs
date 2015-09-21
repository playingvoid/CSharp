using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace JSONTest
{
	class Program
	{
		static void Main(string [ ] args)
		{
			string appData = @"{""Person=ActiveEmployee"":[""FirstName=./$$FirstName"",""LastName=./$$LastName"", ""MiddleName=./$$MiddleName"", ""WorkEmail=./$$WorkEmail"", ""LDAPId=./$$LDAPId"", ""ModifiedDate=./$$ModifiedDate"", ""ContactPhoneNo=./$$ContactPhoneNo"", ""WorkForceId=./$$WorkForceId"", ""HRStatus=./$$HRStatus""], ""Card=ActiveCard"":[""CardNo=./$$CardNo""]}";
			JavaScriptSerializer jss = new JavaScriptSerializer();
			//var objectMapDictionary = (IDictionary<string, object>)jss.DeserializeObject(appData);
			var objectMapDictionary = jss.Deserialize<IDictionary<string, IList<string>>> (appData);

			Console.WriteLine("sds");
		}
	}
}
