using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml;
using System.Configuration;

namespace EmployeeService
{
	public class EmployeeCreator
	{
		public static List<ActiveEmployee> ReadActiveEmloyees()
		{
			List<ActiveEmployee> activeEmployees = new List<ActiveEmployee>();

			string filename = ConfigurationManager.AppSettings [ "filename" ];

			XElement activeEmployeesXMLElement = XElement.Load(filename);

			XNamespace mna = activeEmployeesXMLElement.GetDefaultNamespace();

			IEnumerable<XElement> activeEmployeesElements =
				from el in activeEmployeesXMLElement.Descendants(mna + "ActiveEmployee")
				select el;

			foreach (XElement activeEmployeeElement in activeEmployeesElements)
			{
				string contactPhoneNo = activeEmployeeElement.Element(mna + "ContactPhoneNo").Value;
				string firstName = activeEmployeeElement.Element(mna + "FirstName").Value;
				string hRStatus = activeEmployeeElement.Element(mna + "HRStatus").Value;
				string lDAPId = activeEmployeeElement.Element(mna + "LDAPId").Value;
				string lastName = activeEmployeeElement.Element(mna + "LastName").Value;
				string middleName = activeEmployeeElement.Element(mna + "MiddleName").Value;
				string modifiedDate = activeEmployeeElement.Element(mna + "ModifiedDate").Value;
				string workEmail = activeEmployeeElement.Element(mna + "WorkEmail").Value;
				string workforceId = activeEmployeeElement.Element(mna + "WorkforceId").Value;

				ActiveEmployee activeEmployee = new ActiveEmployee(firstName, middleName, lastName, contactPhoneNo, hRStatus, lDAPId, modifiedDate, workEmail, workforceId);

				activeEmployees.Add(activeEmployee);
			}

			return activeEmployees;
		}

		public static List<ActiveEmployee> ReadActiveEmloyees2()
		{
			List<ActiveEmployee> activeEmployees = new List<ActiveEmployee>();

			string filename = ConfigurationManager.AppSettings [ "filename" ];

			XmlReader xmlReader = XmlReader.Create(filename);
			
			XElement activeEmployeesXMLElement = XElement.Load(xmlReader);

			XmlNameTable nameTable = xmlReader.NameTable;

			XmlNamespaceManager namespaceManager = new XmlNamespaceManager(nameTable);

			XNamespace mna = activeEmployeesXMLElement.GetDefaultNamespace();

			namespaceManager.AddNamespace("ns", mna.ToString());

			IEnumerable<XElement> activeEmployeesElements =
				from el in activeEmployeesXMLElement.Descendants(mna + "ActiveEmployee")
				select el;

			foreach (XElement activeEmployeeElement in activeEmployeesElements)
			{
				string contactPhoneNo = activeEmployeeElement.XPathSelectElement("ns:ContactPhoneNo", namespaceManager).Value;
				string firstName = activeEmployeeElement.XPathSelectElement("ns:FirstName", namespaceManager).Value;
				string hRStatus = activeEmployeeElement.XPathSelectElement("ns:HRStatus", namespaceManager).Value;
				string lDAPId = activeEmployeeElement.XPathSelectElement("ns:LDAPId", namespaceManager).Value;
				string lastName = activeEmployeeElement.XPathSelectElement("ns:LastName", namespaceManager).Value;
				string middleName = activeEmployeeElement.XPathSelectElement("ns:MiddleName", namespaceManager).Value;
				string modifiedDate = activeEmployeeElement.XPathSelectElement("ns:ModifiedDate", namespaceManager).Value;
				string workEmail = activeEmployeeElement.XPathSelectElement("ns:WorkEmail", namespaceManager).Value;
				string workforceId = activeEmployeeElement.XPathSelectElement("ns:WorkforceId", namespaceManager).Value;

				ActiveEmployee activeEmployee = new ActiveEmployee(firstName, middleName, lastName, contactPhoneNo, hRStatus, lDAPId, modifiedDate, workEmail, workforceId);

				activeEmployees.Add(activeEmployee);
			}

			return activeEmployees;
		}
	}
}