using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsignmentShopLibrary
{

	public class Store
	{
		public List<Vendor> Vendors { get; set; }
		public List<Item> Items { get; set; }
		public string BusinessName { get; set; }
		public string FootString { get; set; }
		public string OwnerName { get; set; }
		public string Street { get; set; }
		public string Plz { get; set; }
		public string Town { get; set; }
		public string Telefon { get; set; }
		public string MobilTelefon { get; set; }


		public Store()
		{
			Vendors = new List<Vendor>();
			Items = new List<Item>();
		}

		/// <summary>
		/// Adds the actual version number to Window title
		/// </summary>
		/// <returns></returns>
		public static string AddVersionNumber()
		{
			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
			return $" { versionInfo.FileVersion}";
		}

		public static Bitmap GetImageByName(string imageName)
		{
			System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
			string resourceName = asm.GetName().Name + ".Properties.Resources";
			var rm = new System.Resources.ResourceManager(resourceName, asm);
			return (Bitmap)rm.GetObject(imageName);

		}

		static string CleanInput(string strIn)
		{
			// Replace invalid characters with empty strings.
			try
			{
				return Regex.Replace(strIn, @"[^\w\.@-]", "",
									 RegexOptions.None);
			}
			// If we timeout when replacing invalid characters, 
			// we should return Empty.
			catch (RegexMatchTimeoutException)
			{
				return String.Empty;
			}
		}

		/// <summary>
		/// Convert a number n or n/yy into a Contractnumber yynnnn
		/// </summary>
		/// <param name="aContractNumber"></param>
		/// <returns> a string </returns>
		public string ConvertNumberStringToContractID(string aContractNumber)
		{
			//Eingabe einer Nummer in gültige Vertragsnummer konvertieren YYxxxx

			if (!String.IsNullOrEmpty(aContractNumber))
			{
				int myIndex = aContractNumber.IndexOf('/'); 
				//vollständige Vertragsnummer eingegeben xxxx/YY
				if (myIndex == 5) return ConvertContractNumberToContractID(aContractNumber);

				//normale Vertragsnummer ohne führende Nullen eingegeben
				if (myIndex > 0 && myIndex < 5)
				{
					string myNumber = aContractNumber.Substring(0, myIndex-1);
					myNumber.PadLeft(myIndex - 2, '0');
					return aContractNumber.Substring(myIndex + 1, 2) + myNumber;
				}
				//es wurde nur die laufende Nummer des Vertrages eingegeben nnnn
				if (myIndex == -1 && aContractNumber.Length <= 4)
				{
					return DateTime.Today.Year.ToString().Substring(2, 2) + aContractNumber.PadLeft(4, '0');
				}
			}
			return "";
		}

		public string ConvertContractIDToFormatString(string aContractID)
		{
			//Eingabe einer Nummer in gültige Vertragsnummer konvertieren YYxxxx

			if (!String.IsNullOrEmpty(aContractID))
			{
				int myIndex = aContractID.IndexOf('/');
				//vollständige Vertragsnummer eingegeben xxxx/YY
				if (myIndex == 5) return aContractID;


				//es wurde nur die laufende Nummer des Vertrages eingegeben nnnn
				if (myIndex == -1 && aContractID.Length <= 4)
				{
					return aContractID.PadLeft(4, '0') + "/" + DateTime.Today.Year.ToString().Substring(2, 2) ;
				}
				else if (myIndex == -1 && aContractID.Length == 6)
				{
					return (aContractID.Substring(2, 4) +  "/" + aContractID.Substring(0, 2));
				}
			}
			return "";
		}

		/// <summary>
		/// Convert a Contractnumber nnnn/yy into an integer yynnnn 
		/// </summary>
		/// <param name="aContractNumber"></param>
		/// <returns></returns>
		public string ConvertContractNumberToContractID(string aContractNumber)
		{
			string myContractID;

			int myIndex = aContractNumber.IndexOf('/');
			if (myIndex != -1)
			{
				myContractID = aContractNumber.Substring(myIndex + 1, 2) + aContractNumber.Substring(0, 4);    
			}
			else
			{
				myContractID = Convert.ToString(DateTime.Today.Year).Substring(2,2) +  BuildNumberToString(aContractNumber);
			}
			return myContractID;
		}

		/// <summary>
		/// füllt eine zahl mit führenden Nullen auf max 4 Stellen
		/// </summary>
		/// <param name="aNumber"></param>
		/// <returns></returns>
		public string BuildNumberToString(string aNumber)
		{
			string myNumber = aNumber.Trim();
			int myLength = myNumber.Length;
			if (myLength <= 4 && myLength >= 1)
			{
				switch (myLength)
				{
					case 1:
						myNumber = "000" + myNumber;
						break;
					case 2:
						myNumber = "00" + myNumber;
						break;
					case 3:
						myNumber = "0" + myNumber;
						break;

					default:
						myNumber = aNumber;
						break;
				}
			  }
			  else
			  {
				myNumber = aNumber;
			  }
			return myNumber;
		}

		/// <summary>
		/// Incrementiert eine Posnummer als string
		/// </summary>
		/// <param name="anItemNumber"></param>
		/// <returns></returns>
		public string IncrementPosNumber(string anPosNumber)
		{
			int myPosNumber = Convert.ToInt32(anPosNumber);
			myPosNumber = myPosNumber + 1;
			return BuildNumberToString(Convert.ToString(myPosNumber));
		}

		/// <summary>
		/// Incrementiert eine Itemnummer als string
		/// </summary>
		/// <param name="anItemNumber"></param>
		/// <returns></returns>
		public string IncrementItemNumber(string anItemNumber)
		{
			int myItemNumber = Convert.ToInt32(anItemNumber);
			myItemNumber = myItemNumber + 1;
			return BuildNumberToString(Convert.ToString(myItemNumber));
		}

		/// <summary>
		/// Incrementiert eine ContractID erwartet yynnnn
		/// </summary>
		/// <param name="aContractID"></param>
		/// <returns></returns>
		public string IncrementContractID(string aContractID)
		{
			string myAktYear = Convert.ToString(DateTime.Today.Year).Substring(2, 2);
			if(!String.IsNullOrEmpty(aContractID))
				if (aContractID.Length == 6)
				{
					//Prüfen ob Jahreswechsel
					if (aContractID.Substring(0,2)==myAktYear)
					{
						aContractID = Convert.ToString((Convert.ToUInt32(aContractID)) + 1);
					}
					else
					{
						aContractID = Convert.ToString(DateTime.Today.Year);
						aContractID= aContractID.Substring(2,2)+"0001";
					}
				}

			return aContractID;
		}

		public static string GetPersonalFolder()
		{
			return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		}

		public static string GetAppDataFolder()
		{
			return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		}

		public string GetProgramFolder()
		{
			if (Environment.Is64BitOperatingSystem)
				return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
			else
				return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
		}

		public string ChangeKommaToPoint(decimal aValue)
		{
			string myNewValue = "";
			// Creates a CultureInfo for English in the U.S.
			CultureInfo us = new CultureInfo("en-US");
			// Display i formatted as currency for us.
			myNewValue = aValue.ToString("c", us);
			return myNewValue;
		}

		public string ChangeKommaToPoint(string aValue)
		{

			return aValue.Replace(',', '.'); 
		}

		public string ChangePointToKomma(decimal aValue)
		{
			string myNewValue = "";
			// Creates a CultureInfo for English in the U.S.
			CultureInfo de = new CultureInfo("de-DE");
			// Display i formatted as currency for us.
			myNewValue = aValue.ToString("c", de);
			return myNewValue;
		}

		//Konvertiert ASCII-Dez to String Character
		public static string ASCII8ToString(byte[] ASCIIData)
		{
			var e = Encoding.GetEncoding("437");
			return e.GetString(ASCIIData);
		}

		public string SetStringLengthToTen(string aString)
		{
			string myNewString = "";
			//für den arial Font werden zwei spaces pro fehlende Zahl hinzugefügt
			switch (aString.Length)
			{
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
					myNewString = "          " + aString; break;
				case 6:
					myNewString = "        " + aString; break;
				case 7:
					myNewString = "      " + aString; break;
				case 8:
					myNewString = "    " + aString; break;
				case 9:
					myNewString = "  " + aString; break;

				default:
					myNewString = aString; break;
			}
			if (aString.IndexOf('.') > 0)
			{
				myNewString = " " + aString;
			}

			return myNewString;
		}

		public string SetStringLengthToFour(string aString)
		{
			string myNewString = "";
			//für den arial Font werden zwei spaces pro fehlende Zahl hinzugefügt
			switch (aString.Length)
			{
				case 1:
					myNewString = "      " + aString; break;
				case 2:
					myNewString = "    " + aString; break;
				case 3:
					myNewString = "  " + aString; break;
				default:
					myNewString = aString; break;
			}
			return myNewString;
		}

		//Einen string vom Typ "0,00 €" in einen String  "0.00" wandeln
		public string ConvertCurrencyToNumber(string aCurrencyValue)
		{
			string myNumberString;
			try
			{
				if (aCurrencyValue.Length > 0)
				{
					myNumberString = aCurrencyValue.Replace(',', '.');
					myNumberString = myNumberString.Trim();
					myNumberString = myNumberString.Split(' ')[0];
				}
				else
					myNumberString = aCurrencyValue;

				return myNumberString;
			}
			catch (Exception)
			{
				return "0";
			}
		}
		//Einen string vom Typ "0,00 €" in eine Dezimalzahl wandeln
		public decimal ConvertCurrencyToDecimal(string aCurrencyValue)
		{
			string myNumberString;
			try
			{
				if (aCurrencyValue.Length > 0)
				{
					myNumberString = aCurrencyValue.Trim();
					myNumberString = myNumberString.Split(' ')[0];
				}
				else
					myNumberString = aCurrencyValue;

				return Convert.ToDecimal(myNumberString);
			}
			catch (Exception)
			{
				return 0;
			}

		}

		//Die jüngste Datei eines bestimmten Types in einm Verzeichnis ermitteln
		public string GetNewestFileName(string DirectoryName, string FileMask)
		{
			int newestIndex = 0;
			FileInfo[] Files = (new DirectoryInfo(DirectoryName)).GetFiles(FileMask);
			DateTime newestDate = Files[0].LastWriteTime;
			for (int i = 0; i < Files.Length; i++ )
			{
				if (newestDate < Files[i].LastWriteTime)
				{
					newestDate = Files[i].LastWriteTime;
					newestIndex = i;
				}
			}
			return (Files.Length > 0) ? Files[newestIndex].Name : null;
		}
		//Die älteste Datei eines bestimmten Types in einm Verzeichnis ermitteln
		public string GetOldestFileName(string DirectoryName, string FileMask)
		{
			int oldestIndex = 0;
			FileInfo[] Files = (new DirectoryInfo(DirectoryName)).GetFiles(FileMask);
			DateTime oldestDate = Files[0].LastWriteTime;

			for (int i = 1; i < Files.Length; i++)
			{
				if (oldestDate > Files[i].LastWriteTime)
				{
					oldestDate = Files[i].LastWriteTime;
					oldestIndex = i;
				}
			}
			return (Files.Length > 0) ? Files[oldestIndex].Name : null;
		}
		//Anzahl der Dateien eines bestimmten Types in einem Directory
		public int GetFilesCount(string DirectoryName, string FileMask)
		{
			FileInfo[] Files = (new DirectoryInfo(DirectoryName)).GetFiles(FileMask);
			return Files.Length;
		}
		//Feststellen, ob ein Jahreswechsel seit dem letzten Auftrag stattgefunden hat
		public bool YearChanged(string aLastContractD)
		{
			bool myYearchanged = false;
			string myAktYear = DateTime.Today.Year.ToString();
			if (aLastContractD != null)
				if (aLastContractD.Substring(0, 2) != myAktYear.Substring(2, 2))
					myYearchanged = true;
			return myYearchanged;
		}

		//Differenz zwischen dem heutigen und einem früheren Datum feststellen
		public string GetDateTimeDiff(string aDate)
		{
			DateTime oldDate = Convert.ToDateTime(aDate);
			DateTime newDate = DateTime.Now;

			// Difference in days, hours, and minutes.
			//TimeSpan ts = newDate - oldDate;
			// Difference in days.
			System.TimeSpan diff1 = newDate.Subtract(oldDate);

			// date4 gets 4/9/1996 5:55:00 PM.
			System.DateTime testDate = newDate.Subtract(diff1);

			return testDate.ToShortDateString();
		}

		//Differenz zwischen dem heutigen und einem früheren Datum feststellen
		public int DateTimeCompare(string aDateString, DateTime aDate)
		{
			DateTime oldDate = Convert.ToDateTime(aDateString);
			DateTime newDate = aDate;

			int result = DateTime.Compare(oldDate, newDate);
			return result;
		}

		//Differenz zwischen zwei Datumsstrings feststellen Format dd.mm.yyyy
		public int DateTimeCompareTwoStrings(string aDateString1, string aDateString2)
		{ 
			DateTime myDate1 =  Convert.ToDateTime(aDateString1);
			DateTime myDate2 = Convert.ToDateTime(aDateString2);

			int result = DateTime.Compare(myDate1, myDate2);
			return result;
		}

		//max Datum aus einer Liste feststellen zwischen zwei Datumsstrings feststellen Format dd.mm.yyyy
		public string DateTimeGetMaxSoldDate(List<Item> anItemList)
		{
			DateTime myDate1;
			DateTime myDate2;
			int result;
			myDate1 = Convert.ToDateTime(anItemList[0].SoldDate);
			foreach (var item in anItemList)
			{
				myDate2 = Convert.ToDateTime(item.SoldDate);
				result = DateTime.Compare(myDate1, myDate2);
				if (result < 0)
					myDate1 = myDate2;
			}
			return myDate1.ToShortDateString();
		}

		//max Datum aus einer Liste feststellen zwischen zwei Datumsstrings feststellen Format dd.mm.yyyy
		public string DateTimeGetMinSoldDate(List<Item> anItemList)
		{
			DateTime myDate1;
			DateTime myDate2;
			int result;
			myDate1 = Convert.ToDateTime(anItemList[0].SoldDate);
			foreach (var item in anItemList)
			{
				myDate2 = Convert.ToDateTime(item.SoldDate);
				result = DateTime.Compare(myDate1, myDate2);
				if (result > 0)
					myDate1 = myDate2;
			}
			return myDate1.ToShortDateString();
		}

		//max Datum aus einer Liste feststellen zwischen zwei Datumsstrings feststellen Format dd.mm.yyyy
		public string DateTimeGetMaxSoldDate(List<ItemSalesVolumeGrouped> anItemList)
		{
			DateTime myDate1;
			DateTime myDate2;
			int result;
			myDate1 = Convert.ToDateTime(anItemList[0].SoldDate);
			foreach (var item in anItemList)
			{
				myDate2 = Convert.ToDateTime(item.SoldDate);
				result = DateTime.Compare(myDate1, myDate2);
				if (result < 0)
					myDate1 = myDate2;
			}
			return myDate1.ToShortDateString();
		}

		//max Datum aus einer Liste feststellen zwischen zwei Datumsstrings feststellen Format dd.mm.yyyy
		public string DateTimeGetMinSoldDate(List<ItemSalesVolumeGrouped> anItemList)
		{
			DateTime myDate1;
			DateTime myDate2;
			int result;
			myDate1 = Convert.ToDateTime(anItemList[0].SoldDate);
			foreach (var item in anItemList)
			{
				myDate2 = Convert.ToDateTime(item.SoldDate);
				result = DateTime.Compare(myDate1, myDate2);
				if (result > 0)
					myDate1 = myDate2;
			}
			return Convert.ToString(myDate1);
		}

		public string DateTimeGetMaxPayoutDate(List<Item> anItemList)
		{
			DateTime myDate1;
			DateTime myDate2;
			int result;
			myDate1 = Convert.ToDateTime(anItemList[0].PayoutDate);
			foreach (var item in anItemList)
			{
				myDate2 = Convert.ToDateTime(item.PayoutDate);
				result = DateTime.Compare(myDate1, myDate2);
				if (result < 0)
					myDate1 = myDate2;
			}
			return myDate1.ToShortDateString();
		}

		//max Datum aus einer Liste feststellen zwischen zwei Datumsstrings feststellen Format dd.mm.yyyy
		public string DateTimeGetMinPayoutDate(List<Item> anItemList)
		{
			DateTime myDate1;
			DateTime myDate2;
			int result;
			if (anItemList.Count > 0)
			{
				myDate1 = Convert.ToDateTime(anItemList[0].PayoutDate);
				foreach (var item in anItemList)
				{
					myDate2 = Convert.ToDateTime(item.PayoutDate);
					result = DateTime.Compare(myDate1, myDate2);
					if (result > 0)
						myDate1 = myDate2;
				}
				return myDate1.ToShortDateString();
			}
			return null;
		}

		public string DateTimeGetMaxBeginDate(List<Item> anItemList)
		{
			DateTime myDate1;
			DateTime myDate2;
			int result;
			if (anItemList.Count > 0)
			{
				myDate1 = Convert.ToDateTime(anItemList[0].BeginDate);
				foreach (var item in anItemList)
				{
					myDate2 = Convert.ToDateTime(item.BeginDate);
					result = DateTime.Compare(myDate1, myDate2);
					if (result < 0)
						myDate1 = myDate2;
				}
				return myDate1.ToShortDateString();
			}return null;
		}

		public string DateTimeGetMaxBeginDate(List<ItemReport> anItemList)
		{
			DateTime myDate1;
			DateTime myDate2;
			int result;
			if (anItemList.Count > 0)
			{
				myDate1 = Convert.ToDateTime(anItemList[0].BeginDate);
				foreach (var item in anItemList)
				{
					myDate2 = Convert.ToDateTime(item.BeginDate);
					result = DateTime.Compare(myDate1, myDate2);
					if (result < 0)
						myDate1 = myDate2;
				}
				return myDate1.ToShortDateString();
			}
			return null;
		}

		//max Datum aus einer Liste feststellen zwischen zwei Datumsstrings feststellen Format dd.mm.yyyy
		public string DateTimeGetMinBeginDate(List<Item> anItemList)
		{
			DateTime myDate1;
			DateTime myDate2;
			int result;
			if (anItemList.Count > 0)
			{
				myDate1 = Convert.ToDateTime(anItemList[0].BeginDate);
				foreach (var item in anItemList)
				{
					myDate2 = Convert.ToDateTime(item.BeginDate);
					result = DateTime.Compare(myDate1, myDate2);
					if (result > 0)
						myDate1 = myDate2;
				}
				return myDate1.ToShortDateString();
			}
			return null;
		}

		public string DateTimeGetMinBeginDate(List<ItemReport> anItemList)
		{
			DateTime myDate1;
			DateTime myDate2;
			int result;
			if (anItemList.Count > 0)
			{
				myDate1 = Convert.ToDateTime(anItemList[0].BeginDate);
				foreach (var item in anItemList)
				{
					myDate2 = Convert.ToDateTime(item.BeginDate);
					result = DateTime.Compare(myDate1, myDate2);
					if (result > 0)
						myDate1 = myDate2;
				}
				return myDate1.ToShortDateString();
			}
			return null;
		}

		public string DateTimeGetMaxEndDate(List<Item> anItemList)
		{
			DateTime myDate1;
			DateTime myDate2;
			int result;
			if (anItemList.Count > 0)
			{
				myDate1 = Convert.ToDateTime(anItemList[0].EndDate);
				foreach (var item in anItemList)
				{
					myDate2 = Convert.ToDateTime(item.EndDate);
					result = DateTime.Compare(myDate1, myDate2);
					if (result < 0)
						myDate1 = myDate2;
				}
				return myDate1.ToShortDateString();
			}
			return null;
		}

		public string DateTimeGetMaxDate(List<ItemReport> anItemList)
		{
			DateTime myDate1, myMaxEndDate, myMaxSoldDate, myMaxPayoutDate;
			DateTime myDate2;
			int result;
			if (anItemList.Count > 0)
			{
				myDate1 = Convert.ToDateTime(anItemList[0].EndDate);
				foreach (var item in anItemList)
				{
					myDate2 = Convert.ToDateTime(item.EndDate);
					result = DateTime.Compare(myDate1, myDate2);
					if (result < 0)
						myDate1 = myDate2;
				}
				myMaxEndDate = myDate1;
				foreach (var item in anItemList)
				{
					if (!String.IsNullOrEmpty(item.SoldDate))
					{
						myDate1 = Convert.ToDateTime(anItemList[0].SoldDate);
						break;
					}
				}

				foreach (var item in anItemList)
				{
					if (!String.IsNullOrEmpty(item.SoldDate))
					{
						myDate2 = Convert.ToDateTime(item.SoldDate);
						result = DateTime.Compare(myDate1, myDate2);
						if (result < 0)
							myDate1 = myDate2;
					}
				}
				myMaxSoldDate = myDate1;

				foreach (var item in anItemList)
				{
					if (!String.IsNullOrEmpty(item.SoldDate))
					{
						myDate1 = Convert.ToDateTime(anItemList[0].PayoutDate);
						break;
					}
				}

				foreach (var item in anItemList)
				{
					if (!String.IsNullOrEmpty(item.PayoutDate))
					{
						myDate2 = Convert.ToDateTime(item.PayoutDate);
						result = DateTime.Compare(myDate1, myDate2);
						if (result < 0)
							myDate1 = myDate2;
					}
				}
				myMaxPayoutDate = myDate1;
				myDate1 = myMaxEndDate;
				result = DateTime.Compare(myDate1, myMaxSoldDate);
				if (result < 0)
					myDate1 = myMaxSoldDate;
				result = DateTime.Compare(myDate1, myMaxPayoutDate);
				if (result < 0)
					myDate1 = myMaxPayoutDate;
				return myDate1.ToShortDateString();
			}
			return null;
		}

		//max Datum aus einer Liste feststellen zwischen zwei Datumsstrings feststellen Format dd.mm.yyyy
		public string DateTimeGetMinEndDate(List<Item> anItemList)
		{
			DateTime myDate1;
			DateTime myDate2;
			int result;
			if (anItemList.Count > 0)
			{
				myDate1 = Convert.ToDateTime(anItemList[0].EndDate);
				foreach (var item in anItemList)
				{
					myDate2 = Convert.ToDateTime(item.EndDate);
					result = DateTime.Compare(myDate1, myDate2);
					if (result > 0)
						myDate1 = myDate2;
				}
				return myDate1.ToShortDateString();
			}
			return null;
		}

		public string ReadSerNoFromFile(string aFilename)
		{
			if (File.Exists(aFilename))
			{
				string[] myArray = File.ReadAllLines(aFilename);
				//liest die Seriennummer aus /2nd.dta
				int index = myArray.GetUpperBound(0);
				if (index > -1)
				{
					return CleanInput( myArray[0]);
				}
			}
			return "";
		}

		public string ReadLicenseNoFromFile(string aFilename)
		{
			if (File.Exists(aFilename))
			{
				string[] myArray = File.ReadAllLines(aFilename);
				//liest die Seriennummer aus /2nd.dta
				int index = myArray.GetUpperBound(0);
				if (index > 0)
				{
					return CleanInput( myArray[1]);
				}
			}
			return "";
		}

		public void WriteSernoToFile(string aSerNo, string aFile)
		{
			//schreibt die Serno (UNIX-Timestamp) im ASCII-Dez in /2nd.dta
			//string mySerno = aSerNo.ToString("x2");
			if (!String.IsNullOrEmpty(aSerNo))
			{
				FileStream bw = new FileStream(aFile, FileMode.Create, FileAccess.ReadWrite);
				File.SetAttributes(aFile, File.GetAttributes(aFile) | FileAttributes.Hidden);
				StreamWriter sw = new StreamWriter(bw);
				sw.WriteLine(aSerNo);
				sw.Close();
				bw.Close();
			}
		}

		public static Int32 DateTimeToUnixTimestamp(DateTime dateTime)
		{
			return Convert.ToInt32 ((TimeZoneInfo.ConvertTimeToUtc(dateTime) -
					 new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds);
		}

		public string StringtoMD5(string Content)
		{
			System.Security.Cryptography.MD5CryptoServiceProvider M5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
			byte[] ByteString = System.Text.Encoding.ASCII.GetBytes(Content);
			ByteString = M5.ComputeHash(ByteString);
			string FinalString = null;
			foreach (byte bt in ByteString)
			{
				FinalString += bt.ToString("x2");
			}
			return FinalString.ToUpper();
		}

		public  Hashtable GetKeyList()
		{
			Hashtable keys = new Hashtable();
			keys.Add(1, 496151368);
			keys.Add(2, 463845766);
			keys.Add(3, 134762611);
			keys.Add(4, 84009607);
			keys.Add(5, 37806417);
			keys.Add(6, 104247353);
			keys.Add(7, 125900946);
			keys.Add(8, 490731147);
			keys.Add(9, 446546251);
			keys.Add(10, 509856256);
			keys.Add(11, 481255075);
			keys.Add(12, 446822192);
			keys.Add(13, 296469941);
			keys.Add(14, 161431297);
			keys.Add(15, 530334973);
			keys.Add(16, 307923943);
			keys.Add(17, 92468009);
			keys.Add(18, 197993180);
			keys.Add(19, 31972411);
			keys.Add(20, 360431080);
			keys.Add(21, 263333362);
			keys.Add(22, 334367918);
			keys.Add(23, 530636694);
			keys.Add(24, 39482269);
			keys.Add(25, 313997393);
			keys.Add(26, 360461943);
			keys.Add(27, 270522788);
			keys.Add(28, 530241448);
			keys.Add(29, 448386950);
			keys.Add(30, 464150771);
			keys.Add(31, 409216747);
			keys.Add(32, 173955911);
			keys.Add(33, 390029765);
			keys.Add(34, 68558648);
			keys.Add(35, 532436264);
			keys.Add(36, 416878997);
			keys.Add(37, 199207868);
			keys.Add(38, 228573058);
			keys.Add(39, 434167728);
			keys.Add(40, 412794426);
			keys.Add(41, 21020829);
			keys.Add(42, 434582828);
			keys.Add(43, 4201451);
			keys.Add(44, 103742575);
			keys.Add(45, 128523757);
			keys.Add(46, 477200773);
			keys.Add(47, 330611200);
			keys.Add(48, 471626578);
			keys.Add(49, 215592072);
			keys.Add(50, 252644049);
			keys.Add(51, 496151368);
			keys.Add(52, 463845766);
			keys.Add(53, 134762611);
			keys.Add(54, 84009607);
			keys.Add(55, 37806417);
			keys.Add(56, 104247353);
			keys.Add(57, 125900946);
			keys.Add(58, 490731147);
			keys.Add(59, 446546251);
			keys.Add(60, 58049312);
			keys.Add(61, 428377964);
			keys.Add(62, 22873504);
			keys.Add(63, 378281323);
			keys.Add(64, 6473017);
			keys.Add(65, 494244269);
			keys.Add(66, 154550285);
			keys.Add(67, 195275267);
			keys.Add(68, 152485663);
			keys.Add(69, 12017519);
			keys.Add(70, 277966133);
			keys.Add(71, 463686253);
			keys.Add(72, 140419236);
			keys.Add(73, 89036748);
			keys.Add(74, 325325635);
			keys.Add(75, 331012956);
			keys.Add(76, 496296943);
			keys.Add(77, 459688599);
			keys.Add(78, 507990631);
			keys.Add(79, 380804412);
			keys.Add(80, 74978940);
			keys.Add(81, 379360816);
			keys.Add(82, 179027581);
			keys.Add(83, 494427498);
			keys.Add(84, 160523681);
			keys.Add(85, 254335350);
			keys.Add(86, 233138597);
			keys.Add(87, 92970794);
			keys.Add(88, 389166878);
			keys.Add(89, 531046176);
			keys.Add(90, 85784021);
			keys.Add(91, 460211717);
			keys.Add(92, 509758127);
			keys.Add(93, 268937960);
			keys.Add(94, 230497933);
			keys.Add(95, 266139170);
			keys.Add(96, 84296487);
			keys.Add(97, 373787582);
			keys.Add(98, 37419916);
			keys.Add(99, 469326042);
			keys.Add(00, 401627259);
			return keys;
		}

		public static string SQLEscape(string sValue)
		{
			// SQL Encoding: einfache Hochkommas
			if (!String.IsNullOrEmpty(sValue))
			{
				string temp1 = sValue.Replace("'", "''");
				temp1 = temp1.Trim();
				if (sValue == null) return null;
				else return temp1;
			}
			return sValue;
		}

		/// <summary>
		/// Replace in String LINQ konforme Zeichen
		/// </summary>
		/// <param name="sValue"></param>
		/// <returns></returns>
		public static string DataViewEscape(string sValue)
		{
			// LINQ Encoding: einfache Hochkommas
			if (!String.IsNullOrEmpty(sValue))
			{
				string temp1 = sValue;
				temp1 = sValue.Replace("*", "[*]");
				temp1 = temp1.Replace("%", "[%]");
				int index = temp1.IndexOf("'");
				if (index >= 0)
					//temp1 = temp1.Substring(0, temp1.IndexOf("'"));
					temp1 = SQLEscape(temp1);
				temp1 = temp1.Trim();
				return temp1;
			}
			else
				return sValue;
		}

		public enum Monthnames
		{
			Jan = 1,
			Feb,
			Mrz,
			Apr,
			Mai,
			Jun,
			Jul,
			Aug,
			Sep,
			Okt,
			Nov,
			Dez

		}

		public static String GetTimestamp(DateTime value)
		{
			return value.ToString("yyyy-MM-dd HH:mm:ss");
		}

		[Serializable]
		private class RegexMatchTimeoutException : Exception
		{
			public RegexMatchTimeoutException()
			{
			}

			public RegexMatchTimeoutException(string message) : base(message)
			{
			}

			public RegexMatchTimeoutException(string message, Exception innerException) : base(message, innerException)
			{
			}

			protected RegexMatchTimeoutException(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
	}
}
