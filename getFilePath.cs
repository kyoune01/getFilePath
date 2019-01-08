using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace HelloWorld {
	class Hello {
		static void Main(string[] args) {

//Read Path
			string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
			string listPath = appPath.Replace("getFilePath.exe","list.txt");

//Reset list
			if (System.IO.File.Exists(listPath)) System.IO.File.Delete(listPath);
			System.IO.StreamWriter sw = new System.IO.StreamWriter(listPath);

//get directri path
			string dirPath = null;
			if (args.Length == 0)
			{
				Console.Write("調べたいフォルダをドラッグ＆ドロップでEnter\n");
				dirPath = Console.ReadLine();
			}
			else
			{
				dirPath = args[0];
			}

//SearchFile to AllFile in Desktop
			System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(dirPath);
			System.IO.FileInfo[] files = di.GetFiles("*", System.IO.SearchOption.AllDirectories);

//Get file path
			foreach (System.IO.FileInfo f in files) {
//shap to FilePath
				string fileName = f.FullName;
				string kName = fileName.Replace(dirPath, "");
				string listName = kName.Replace("\\", "/");
				Console.Write(listName+"\n");
//write
				sw.Write(listName+"\r\n");
			}

//Close path
			sw.Close();
		}
	}
}
