using System;
using System.IO;
namespace StringReverser
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine("Enter the string you would like to reverse");
			string input = Console.ReadLine();
			string reversedString = ReverseString(input);
			Console.WriteLine("The reversed string is: {0}", reversedString);
			Console.WriteLine("Would you like to save this file? \n'Y' - Yes \n'N' - No \n'E' - Exit");
			SaveOrExit(reversedString);
			
		}
		static bool OverrideChoice()
		{
			string overrideChoice = Console.ReadLine();
			if (overrideChoice.ToUpper() == "Y")
			{
				return true;
			}
			else if (overrideChoice.ToUpper() == "N")
			{
				return false;
			}
			else 
			{
				Console.WriteLine("Invalid choice. Please only enter 'Y' or 'N'");
				OverrideChoice();
				return false; //This line will never be excuted, it is only there because the compiler requires all code paths to return a bool.
			}
		}
		static void SaveOrExit(string content)
		{
			string choice = Console.ReadLine();
			switch(choice)
			{
				case "Y":
					Console.WriteLine("File Name: ");
					string fileName = Console.ReadLine() + ".txt";
					if (File.Exists(fileName + ".txt"))
					{
						Console.WriteLine("A file named 'fileName' of type txt already exists. Would you like to override it? Y/N");
						if (OverrideChoice() == true)
						{
							File.WriteAllText(@fileName , content);
							Console.WriteLine("Sucessfully written to {0}", fileName);
						}
					}
					else
					{
						File.WriteAllText(@fileName, content);
						Console.WriteLine("Sucessfully written to {0}", fileName);
					}
					break;
				case "N":
					Main();
					break;
				case "E":
					Environment.Exit(0);
					break;
				default:
					Console.WriteLine("Invalid input. Please only enter 'Y', 'N', or 'E'");
					SaveOrExit(content);
					break;
			}

		}
		static string ReverseString(string s)
		{
			char[] stringSplit = s.ToCharArray();
			Array.Reverse(stringSplit);
			string reversedString = new string(stringSplit);
			return reversedString;
		}
	}
}
