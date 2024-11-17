using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.IO.Compression;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Runtime.InteropServices;

namespace simpleIO
{
	public class Private
	{
		public static string nowtime()
		{
			// 获取当前时间
			DateTime now = DateTime.Now;

			// 格式化日期时间为所需的字符串格式
			string formattedDateTime = now.ToString("yyyyMMddHHmm");
			return formattedDateTime;
		}
		/// <summary>
		/// 复制目录
		/// </summary>
		/// <param name="sourceDir">源目录</param>
		/// <param name="destDir">目标目录</param>
		public static void CopyDirectory(string sourceDir, string destDir)
		{
			// 获取源目录中的所有文件和子目录
			var files = Directory.GetFiles(sourceDir);
			var dirs = Directory.GetDirectories(sourceDir);

			// 复制所有文件
			foreach (var file in files)
			{
				var destFile = Path.Combine(destDir, Path.GetFileName(file));
				File.Copy(file, destFile, true); // true表示覆盖现有文件
			}

			// 递归复制所有子目录
			foreach (var dir in dirs)
			{
				var destSubDir = Path.Combine(destDir, Path.GetFileName(dir));
				CopyDirectory(dir, destSubDir); // 递归调用
			}
		}
		/// <summary>
		/// 获取readme文件
		/// </summary>
		public static void GetReadme()
		{
			string rd = "本项目总结了C#语言中的一些常用语法和一些其他功能，目前正在开发中（ver0.0.1）\r\n如有任何使用问题，请将问题的信息发送到13724102835@163.com\r\n本项目完全开源和免费\r\n——————\r\n代码树状图：\r\nClass: Private 记录私有的一些方法\r\n  Method: nowtime 获取当前时间（yyMMddHHmm）\r\n  Method: CopyDirectory 复制整个目录\r\n  Method: GetReadme 获取该文档（使用该方法后在目录下生成）\r\n  Method: GetSourcecode 获取原代码（使用该方法后在目录下生成）\r\n\r\nClass: IO 关于系统IO的一些操作\r\n\r\nClass: Stream IO的子类，用于控制台\r\n  Method: print 在控制台上输出文本\r\n  Method: readl 读取用户输入的文字\r\n\r\nClass: Dir IO的子类，用于操作目录\r\n  Method: Exist 是否存在\r\n  Method: CreateDirectory 创建目录\r\n  Method: DeleteDirectory 删除目录\r\n  Method: GetFilesFromDirectory 获取目录下的文件\r\n  Method: GetThisProcessesPath 获取该程序的路径\r\n  Method: GetThisProcessesFileName 获取该程序的完整路径\r\n  Method: Copy 复制目录\r\n  Method: Cut 剪切目录\r\n\r\nClass: Files IO的子类，关于文件的操作\r\n  Method: Exist 判断文件是否存在\r\n  Method: Create 创建文件\r\n  Method: Delete 删除文件\r\n  Method: Copy 复制文件\r\n  Method: Cut 剪切文件\r\n  Method: FileName 获取该文件的单一文件名\r\n  Method: FullName 获取该文件的完整文件名\r\n\r\nClass: Text IO的子类，用于文本相关的操作\r\n  Method: Write 将文本写入文件\r\n  Method: WriteToBat 将文本写道bat，自动转码\r\n  Method: Read 读取文件内容\r\n  Method: ReadByLines 逐行读取\r\n  Method: AddTextToFile 将文本添加到已有文件\r\n  Method: GetXmlNodeValue 获取xml文件指定节点值\r\n  Method: GenerateXmlFile 生成xml文件\r\n  Method: GenerateJsonFile 生成json文件\r\n  Method: DeserializeFromJson 解析json文件\r\n  Method: ReJson 从json文件中提取单一变量\r\n  Method: SimpleToJson 将单一变量json化\r\n  Method: AddToJson 添加新的数据到旧json\r\n  Method: ReadCsvFile 读取csv文件内容\r\n  Method: WriteToCsv 将内容写入csv\r\n\r\nClass: Clipborad Text的子类，用于操作剪贴板\r\n  Method: OpenClipboard 系统函数，打开剪贴板\r\n  Method: EmptyClipboard 系统函数，清空剪贴板\r\n  Method: SetClipboardData 系统函数，设定剪贴板内容\r\n  Method: GetClipboardData 系统函数，获取剪贴板内容\r\n  Method: CloseClipboard 系统函数，关闭剪贴板\r\n  Method: SetClipboardText 设置剪贴板内容\r\n  Method: GetClipboardText 获取剪贴板内容\r\n\r\nClass: Log 用于记录日志\r\n  Method: rec 记录\r\n  Method: rec 记录（+1重载）\r\n  Method: getlog 获取日志内容\r\n  Method: LoadLogs \r\n  Method: GetLogEntryAtTime 通过时间戳获取日志\r\n  Method: deletelog 删除日志中的某一项\r\n  Method: RemoveLogEntryByTimestamp\r\n  Method: ReadLogEntries\r\n  Method: ReadLogs \r\n\r\nClass: LogEntry\r\n\r\nClass: Internet 关于网络的操作\r\n  Method: DownloadFileAsync 异步下载文件\r\n  Method: GetDownloadInfo 获取下载文件的信息\r\n  Method: TcpReceive 接受tcp信息（服务端）\r\n  Method: TcpInfo 获取接收的信息\r\n  Method: ClearMsg 定时清理信息缓存\r\n  Method: TcpClient tcp发送端\r\n\r\nClass: Security 关于字符串的加密与解密\r\n  Method: Encrypt 加密\r\n  Method: Decrypt 解密\r\n\r\nClass: Progress 调用外部程序的操作\r\n  Method: GetCSharpAnalyzed 解析C#代码文件\r\n  Method: Held 线程休眠\r\n  Method: start 调用外部程序（+4重载）\r\n  Method: start\r\n  Method: start\r\n  Method: start\r\n  Method: kill 结束某个指定进程\r\n\r\nClass: Zip 与zip格式压缩包相关的操作\r\n  Method: Unzip 解压\r\n  Method: Tozip 将目录压缩为压缩包";
			IO.Text.Write("readme.txt", rd);
		}
		/// <summary>
		/// 获取原代码
		/// </summary>
		public static void GetSourcecode()
		{
			string sc = "using Newtonsoft.Json;\r\nusing Newtonsoft.Json.Linq;\r\nusing System.Diagnostics;\r\nusing System.Net.Sockets;\r\nusing System.Net;\r\nusing System.Reflection;\r\nusing System.Text;\r\nusing System.Text.Json;\r\nusing System.Xml;\r\nusing System.Xml.Linq;\r\nusing System.Xml.Serialization;\r\nusing System.Security.Cryptography.X509Certificates;\r\nusing System.Security.Cryptography;\r\nusing System.IO.Compression;\r\nusing Microsoft.CodeAnalysis.CSharp.Syntax;\r\nusing Microsoft.CodeAnalysis.CSharp;\r\nusing Microsoft.CodeAnalysis;\r\nusing System.Runtime.InteropServices;\r\n\r\nnamespace simpleIO\r\n{\r\n\tpublic class Private\r\n\t{\r\n\t\tpublic static string nowtime()\r\n\t\t{\r\n\t\t\t// 获取当前时间\r\n\t\t\tDateTime now = DateTime.Now;\r\n\r\n\t\t\t// 格式化日期时间为所需的字符串格式\r\n\t\t\tstring formattedDateTime = now.ToString(\"yyyyMMddHHmm\");\r\n\t\t\treturn formattedDateTime;\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 复制目录\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"sourceDir\">源目录</param>\r\n\t\t/// <param name=\"destDir\">目标目录</param>\r\n\t\tpublic static void CopyDirectory(string sourceDir, string destDir)\r\n\t\t{\r\n\t\t\t// 获取源目录中的所有文件和子目录\r\n\t\t\tvar files = Directory.GetFiles(sourceDir);\r\n\t\t\tvar dirs = Directory.GetDirectories(sourceDir);\r\n\r\n\t\t\t// 复制所有文件\r\n\t\t\tforeach (var file in files)\r\n\t\t\t{\r\n\t\t\t\tvar destFile = Path.Combine(destDir, Path.GetFileName(file));\r\n\t\t\t\tFile.Copy(file, destFile, true); // true表示覆盖现有文件\r\n\t\t\t}\r\n\r\n\t\t\t// 递归复制所有子目录\r\n\t\t\tforeach (var dir in dirs)\r\n\t\t\t{\r\n\t\t\t\tvar destSubDir = Path.Combine(destDir, Path.GetFileName(dir));\r\n\t\t\t\tCopyDirectory(dir, destSubDir); // 递归调用\r\n\t\t\t}\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 获取readme文件\r\n\t\t/// </summary>\r\n\t\tpublic static void GetReadme()\r\n\t\t{\r\n\t\t\tstring rd = \"本项目总结了C#语言中的一些常用语法和一些其他功能，目前正在开发中（ver0.0.1）\\r\\n如有任何使用问题，请将问题的信息发送到13724102835@163.com\\r\\n本项目完全开源和免费\\r\\n——————\\r\\n代码树状图：\\r\\nClass: Private 记录私有的一些方法\\r\\n  Method: nowtime 获取当前时间（yyMMddHHmm）\\r\\n  Method: CopyDirectory 复制整个目录\\r\\n  Method: GetReadme 获取该文档（使用该方法后在目录下生成）\\r\\n  Method: GetSourcecode 获取原代码（使用该方法后在目录下生成）\\r\\n\\r\\nClass: IO 关于系统IO的一些操作\\r\\n\\r\\nClass: Stream IO的子类，用于控制台\\r\\n  Method: print 在控制台上输出文本\\r\\n  Method: readl 读取用户输入的文字\\r\\n\\r\\nClass: Dir IO的子类，用于操作目录\\r\\n  Method: Exist 是否存在\\r\\n  Method: CreateDirectory 创建目录\\r\\n  Method: DeleteDirectory 删除目录\\r\\n  Method: GetFilesFromDirectory 获取目录下的文件\\r\\n  Method: GetThisProcessesPath 获取该程序的路径\\r\\n  Method: GetThisProcessesFileName 获取该程序的完整路径\\r\\n  Method: Copy 复制目录\\r\\n  Method: Cut 剪切目录\\r\\n\\r\\nClass: Files IO的子类，关于文件的操作\\r\\n  Method: Exist 判断文件是否存在\\r\\n  Method: Create 创建文件\\r\\n  Method: Delete 删除文件\\r\\n  Method: Copy 复制文件\\r\\n  Method: Cut 剪切文件\\r\\n  Method: FileName 获取该文件的单一文件名\\r\\n  Method: FullName 获取该文件的完整文件名\\r\\n\\r\\nClass: Text IO的子类，用于文本相关的操作\\r\\n  Method: Write 将文本写入文件\\r\\n  Method: WriteToBat 将文本写道bat，自动转码\\r\\n  Method: Read 读取文件内容\\r\\n  Method: ReadByLines 逐行读取\\r\\n  Method: AddTextToFile 将文本添加到已有文件\\r\\n  Method: GetXmlNodeValue 获取xml文件指定节点值\\r\\n  Method: GenerateXmlFile 生成xml文件\\r\\n  Method: GenerateJsonFile 生成json文件\\r\\n  Method: DeserializeFromJson 解析json文件\\r\\n  Method: ReJson 从json文件中提取单一变量\\r\\n  Method: SimpleToJson 将单一变量json化\\r\\n  Method: AddToJson 添加新的数据到旧json\\r\\n  Method: ReadCsvFile 读取csv文件内容\\r\\n  Method: WriteToCsv 将内容写入csv\\r\\n\\r\\nClass: Clipborad Text的子类，用于操作剪贴板\\r\\n  Method: OpenClipboard 系统函数，打开剪贴板\\r\\n  Method: EmptyClipboard 系统函数，清空剪贴板\\r\\n  Method: SetClipboardData 系统函数，设定剪贴板内容\\r\\n  Method: GetClipboardData 系统函数，获取剪贴板内容\\r\\n  Method: CloseClipboard 系统函数，关闭剪贴板\\r\\n  Method: SetClipboardText 设置剪贴板内容\\r\\n  Method: GetClipboardText 获取剪贴板内容\\r\\n\\r\\nClass: Log 用于记录日志\\r\\n  Method: rec 记录\\r\\n  Method: rec 记录（+1重载）\\r\\n  Method: getlog 获取日志内容\\r\\n  Method: LoadLogs \\r\\n  Method: GetLogEntryAtTime 通过时间戳获取日志\\r\\n  Method: deletelog 删除日志中的某一项\\r\\n  Method: RemoveLogEntryByTimestamp\\r\\n  Method: ReadLogEntries\\r\\n  Method: ReadLogs \\r\\n\\r\\nClass: LogEntry\\r\\n\\r\\nClass: Internet 关于网络的操作\\r\\n  Method: DownloadFileAsync 异步下载文件\\r\\n  Method: GetDownloadInfo 获取下载文件的信息\\r\\n  Method: TcpReceive 接受tcp信息（服务端）\\r\\n  Method: TcpInfo 获取接收的信息\\r\\n  Method: ClearMsg 定时清理信息缓存\\r\\n  Method: TcpClient tcp发送端\\r\\n\\r\\nClass: Security 关于字符串的加密与解密\\r\\n  Method: Encrypt 加密\\r\\n  Method: Decrypt 解密\\r\\n\\r\\nClass: Progress 调用外部程序的操作\\r\\n  Method: GetCSharpAnalyzed 解析C#代码文件\\r\\n  Method: Held 线程休眠\\r\\n  Method: start 调用外部程序（+4重载）\\r\\n  Method: start\\r\\n  Method: start\\r\\n  Method: start\\r\\n  Method: kill 结束某个指定进程\\r\\n\\r\\nClass: Zip 与zip格式压缩包相关的操作\\r\\n  Method: Unzip 解压\\r\\n  Method: Tozip 将目录压缩为压缩包\";\r\n\t\t\tIO.Text.Write(\"readme.txt\", rd);\r\n\t\t}\r\n\t\tpublic static void GetSourcecode()\r\n\t\t{\r\n\t\t\tstring sc = \"\";\r\n\t\t\tIO.Text.Write(\"simIO.cs\", sc);\r\n\t\t}\r\n\r\n\t}\r\n\tpublic class IO\r\n\t{\r\n\t\t/// <summary>\r\n\t\t/// 用于控制台的简单操作\r\n\t\t/// </summary>\r\n\t\tpublic class Stream\r\n\t\t{\r\n\t\t\tpublic bool Endl = true;\r\n\t\t\t/// <summary>\r\n\t\t\t/// 在控制台中输出文字\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"towrite\">要输出的文字</param>\r\n\t\t\tpublic static string print(string towrite, bool endl)\r\n\t\t\t{\r\n\t\t\t\ttry\r\n\t\t\t\t{\r\n\t\t\t\t\tif (endl) { Console.WriteLine(towrite + \"\\n\"); }\r\n\t\t\t\t\telse { Console.WriteLine(towrite); }\r\n\t\t\t\t\treturn \"\";\r\n\t\t\t\t}\r\n\t\t\t\tcatch (Exception e)\r\n\t\t\t\t{\r\n\t\t\t\t\treturn e.Message;\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 返回用户输入的文字\r\n\t\t\t/// </summary>\r\n\t\t\t/// <returns>返回文字</returns>\r\n\t\t\tpublic static string readl()\r\n\t\t\t{\r\n\t\t\t\ttry\r\n\t\t\t\t{\r\n\t\t\t\t\treturn Console.ReadLine();\r\n\t\t\t\t}\r\n\t\t\t\tcatch (Exception e)\r\n\t\t\t\t{\r\n\t\t\t\t\treturn e.Message;\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 用于目录的操作\r\n\t\t/// </summary>\r\n\t\tpublic class Dir\r\n\t\t{\r\n\t\t\t/// <summary>\r\n\t\t\t/// 判断目录是否存在\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">路径</param>\r\n\t\t\t/// <returns>布尔值</returns>\r\n\t\t\tpublic static bool Exist(string path)\r\n\t\t\t{\r\n\t\t\t\treturn Directory.Exists(path);\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 创建目录\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">目录路径</param>\r\n\t\t\t/// <returns>异常信息，如果没有就是没有异常</returns>\r\n\t\t\tpublic static string CreateDirectory(string path)\r\n\t\t\t{\r\n\t\t\t\ttry\r\n\t\t\t\t{\r\n\t\t\t\t\tDirectory.CreateDirectory(path);\r\n\t\t\t\t\treturn \"\";\r\n\t\t\t\t}\r\n\t\t\t\tcatch (Exception e)\r\n\t\t\t\t{\r\n\t\t\t\t\treturn e.Message;\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 删除目录\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">目录路径</param>\r\n\t\t\t/// <returns>异常信息，如果没有就是没有异常</returns>\r\n\t\t\tpublic static string DeleteDirectory(string path)\r\n\t\t\t{\r\n\t\t\t\ttry\r\n\t\t\t\t{\r\n\t\t\t\t\tDirectory.Delete(path);\r\n\t\t\t\t\treturn \"\";\r\n\t\t\t\t}\r\n\t\t\t\tcatch (Exception e) { return e.Message; }\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 从目录中获取文件列表\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">目录路径</param>\r\n\t\t\t/// <returns>文件列表</returns>\r\n\t\t\tpublic static FileInfo[] GetFilesFromDirectory(string path)\r\n\t\t\t{\r\n\t\t\t\tDirectoryInfo dir = new DirectoryInfo(path);\r\n\t\t\t\treturn dir.GetFiles();\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 获取当前程序所在目录路径\r\n\t\t\t/// </summary>\r\n\t\t\t/// <returns>当前程序目录所在路径</returns>\r\n\t\t\tpublic static string GetThisProcessesPath()\r\n\t\t\t{\r\n\t\t\t\tstring assemblyPath = Assembly.GetExecutingAssembly().Location;\r\n\t\t\t\treturn Path.GetDirectoryName(assemblyPath);\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 获取当前程序所在路径\r\n\t\t\t/// </summary>\r\n\t\t\t/// <returns>当前程序所在完整路径</returns>\r\n\t\t\tpublic static string GetThisProcessesFileName()\r\n\t\t\t{\r\n\t\t\t\tstring assemblyPath = Assembly.GetExecutingAssembly().Location;\r\n\t\t\t\treturn assemblyPath;\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 复制目录及其子文件\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"source\">源目录</param>\r\n\t\t\t/// <param name=\"destination\">目标目录</param>\r\n\t\t\tpublic static void Copy(string source, string destination)\r\n\t\t\t{\r\n\t\t\t\tif (!Directory.Exists(destination))\r\n\t\t\t\t{\r\n\t\t\t\t\tDirectory.CreateDirectory(destination);\r\n\t\t\t\t}\r\n\t\t\t\tPrivate.CopyDirectory(source, destination);\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 剪切目录及其子文件\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"source\">源目录</param>\r\n\t\t\t/// <param name=\"destination\">目标目录</param>\r\n\t\t\tpublic static void Cut(string source, string destination)\r\n\t\t\t{\r\n\t\t\t\tCopy(source, destination);\r\n\t\t\t\tDirectory.Delete(source, true);\r\n\t\t\t}\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 执行有关文件的操作\r\n\t\t/// </summary>\r\n\t\tpublic class Files\r\n\t\t{\r\n\t\t\t/// <summary>\r\n\t\t\t/// 判断文件是否存在\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">文件路径</param>\r\n\t\t\t/// <returns>布尔值</returns>\r\n\t\t\tpublic static bool Exist(string path)\r\n\t\t\t{\r\n\t\t\t\treturn File.Exists(path);\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 创建一个空文件\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">路径</param>\r\n\t\t\tpublic static void Create(string path)\r\n\t\t\t{\r\n\t\t\t\tFile.Create(path);\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 删除一个已有文件\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">路径</param>\r\n\t\t\t/// <returns>是否已经删除</returns>\r\n\t\t\tpublic static bool Delete(string path)\r\n\t\t\t{\r\n\t\t\t\tFile.Delete(path);\r\n\t\t\t\tif (File.Exists(path))\r\n\t\t\t\t{\r\n\t\t\t\t\treturn false;\r\n\t\t\t\t}\r\n\t\t\t\telse\r\n\t\t\t\t{\r\n\t\t\t\t\treturn true;\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 复制文件到指定位置\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">原位置</param>\r\n\t\t\t/// <param name=\"destination\">目标位置</param>\r\n\t\t\tpublic static void Copy(string path, string destination)\r\n\t\t\t{\r\n\t\t\t\tFile.Copy(path, destination);\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 剪切文件到指定位置\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">原路径</param>\r\n\t\t\t/// <param name=\"destination\">目标路径</param>\r\n\t\t\tpublic static void Cut(string path, string destination)\r\n\t\t\t{\r\n\t\t\t\tFile.Copy(path, destination);\r\n\t\t\t\tDelete(path);\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 获得文件名字\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">路径</param>\r\n\t\t\t/// <returns>文件名字</returns>\r\n\t\t\tpublic static string FileName(string path)\r\n\t\t\t{\r\n\t\t\t\tFileInfo fi = new FileInfo(path);\r\n\t\t\t\treturn fi.Name;\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 获得文件完整路径\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">路径</param>\r\n\t\t\t/// <returns>完整路径</returns>\r\n\t\t\tpublic static string FullName(string path)\r\n\t\t\t{\r\n\t\t\t\tFileInfo fi = new FileInfo(path);\r\n\t\t\t\treturn fi.FullName;\r\n\t\t\t}\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 关于文本的操作\r\n\t\t/// </summary>\r\n\t\tpublic class Text\r\n\t\t{ \r\n\t\t\t/// <summary>\r\n\t\t\t/// 与剪贴板相关的操作\r\n\t\t\t/// </summary>\r\n            class Clipborad\r\n\t{\r\n\t\t// 导入Windows API函数\r\n\t\t[DllImport(\"user32.dll\", SetLastError = true)]\r\n\t\tprivate static extern bool OpenClipboard(IntPtr hWndNewOwner);\r\n\r\n\t\t[DllImport(\"user32.dll\", SetLastError = true)]\r\n\t\tprivate static extern bool EmptyClipboard();\r\n\r\n\t\t[DllImport(\"user32.dll\", SetLastError = true)]\r\n\t\tprivate static extern IntPtr SetClipboardData(uint uFormat, IntPtr hData);\r\n\r\n\t\t[DllImport(\"user32.dll\", SetLastError = true)]\r\n\t\tprivate static extern IntPtr GetClipboardData(uint uFormat);\r\n\r\n\t\t[DllImport(\"user32.dll\", SetLastError = true)]\r\n\t\tprivate static extern bool CloseClipboard();\r\n\r\n\t\t// 剪贴板格式常量\r\n\t\tprivate const uint CF_UNICODETEXT = 0x000D;\r\n\r\n\t\t/// <summary>\r\n\t\t/// 将文本添加到剪贴板\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"text\">要设置的文字</param>\r\n\t\tpublic static void SetClipboardText(string text)\r\n\t\t{\r\n\t\t\tif (OpenClipboard(IntPtr.Zero))\r\n\t\t\t{\r\n\t\t\t\tEmptyClipboard();\r\n\r\n\t\t\t\tIntPtr hGlobal = Marshal.AllocHGlobal((text.Length + 1) * Marshal.SizeOf(typeof(char)));\r\n\t\t\t\ttry\r\n\t\t\t\t{\r\n\t\t\t\t\tMarshal.Copy(text.ToCharArray(), 0, hGlobal, text.Length);\r\n\t\t\t\t\tMarshal.WriteInt32(hGlobal, text.Length * Marshal.SizeOf(typeof(char)), 0); // Null-terminate the string\r\n\r\n\t\t\t\t\tSetClipboardData(CF_UNICODETEXT, hGlobal);\r\n\t\t\t\t}\r\n\t\t\t\tfinally\r\n\t\t\t\t{\r\n\t\t\t\t\tMarshal.FreeHGlobal(hGlobal);\r\n\t\t\t\t\tCloseClipboard();\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t}\r\n\r\n\t\t/// <summary>\r\n\t\t/// 从剪贴板获取文本\r\n\t\t/// </summary>\r\n\t\t/// <returns>获取到的文本</returns>\r\n\t\tpublic static string GetClipboardText()\r\n\t\t{\r\n\t\t\tif (OpenClipboard(IntPtr.Zero))\r\n\t\t\t{\r\n\t\t\t\tIntPtr ptr = GetClipboardData(CF_UNICODETEXT);\r\n\r\n\t\t\t\tif (ptr != IntPtr.Zero)\r\n\t\t\t\t{\r\n\t\t\t\t\tint size = Marshal.ReadInt32(ptr, -4); // Size of the string, including null terminator\r\n\t\t\t\t\tbyte[] data = new byte[size];\r\n\t\t\t\t\tMarshal.Copy(ptr, data, 0, size);\r\n\r\n\t\t\t\t\tstring text = Encoding.Unicode.GetString(data).TrimEnd('\\0'); // Remove null terminator\r\n\t\t\t\t\tCloseClipboard();\r\n\t\t\t\t\treturn text;\r\n\t\t\t\t}\r\n\t\t\t\telse\r\n\t\t\t\t{\r\n\t\t\t\t\tCloseClipboard();\r\n\t\t\t\t\treturn null;\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t\telse\r\n\t\t\t{\r\n\t\t\t\treturn null;\r\n\t\t\t}\r\n\t\t}\r\n\t}\r\n\t/// <summary>\r\n\t/// 将文字写入到文本文档中\r\n\t/// </summary>\r\n\t/// <param name=\"path\">路径</param>\r\n\t/// <param name=\"text\">内容</param>\r\n\tpublic static void Write(string path, string text)\r\n\t\t\t{\r\n\t\t\t\tStreamWriter writer = new StreamWriter(path);\r\n\t\t\t\twriter.Write(text);\r\n\t\t\t\twriter.Close();\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 根据命令生成bat文件\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">bat文件完整路径</param>\r\n\t\t\t/// <param name=\"Text\">内容</param>\r\n\t\t\tpublic static void WriteToBat(string path, string Text)\r\n\t\t\t{\r\n\t\t\t\tstring content= \"cd \" + Path.GetDirectoryName(path) + \"\\n\" + Text;\r\n\t\t\t\tFile.WriteAllText(path, content, Encoding.ASCII);\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 读取文本文档中的内容\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">路径</param>\r\n\t\t\t/// <returns>内容</returns>\r\n\t\t\tpublic static string Read(string path)\r\n\t\t\t{\r\n\t\t\t\tStreamReader reader = new StreamReader(path);\r\n\t\t\t\tstring sr = reader.ReadToEnd();\r\n\t\t\t\treader.Close();\r\n\t\t\t\treturn sr;\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 逐行读取文本文档中的内容\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">路径</param>\r\n\t\t\t/// <returns>内容</returns>\r\n\t\t\tpublic static string[] ReadByLines(string path)\r\n\t\t\t{\r\n\t\t\t\treturn File.ReadAllLines(path);\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 添加内容到文件末尾\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">路径</param>\r\n\t\t\t/// <param name=\"text\">内容</param>\r\n\t\t\tpublic static void AddTextToFile(string path, string text)\r\n\t\t\t{\r\n\t\t\t\tstring content = Read(path);\r\n\t\t\t\tFile.Delete(path);\r\n\t\t\t\tWrite(path, content + text);\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 从XML文件中获取指定节点的值\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"xmlFilePath\">XML文件的路径</param>\r\n\t\t\t/// <param name=\"searchNodeName\">要搜索的节点名称</param>\r\n\t\t\t/// <param name=\"searchValue\">要搜索的节点值</param>\r\n\t\t\t/// <param name=\"targetNodeName\">目标节点名称（即找到搜索节点后，要获取其值的节点名称）</param>\r\n\t\t\t/// <returns>返回目标节点的值，如果未找到则返回null</returns>\r\n\t\t\tpublic static string GetXmlNodeValue(string xmlFilePath, string searchNodeName, string searchValue, string targetNodeName)\r\n\t\t\t{\r\n\t\t\t\t// 检查文件是否存在，如果不存在则抛出异常\r\n\t\t\t\tif (!File.Exists(xmlFilePath))\r\n\t\t\t\t{\r\n\t\t\t\t\tthrow new FileNotFoundException($\"The file '{xmlFilePath}' was not found.\");\r\n\t\t\t\t}\r\n\r\n\t\t\t\t// 使用XDocument加载XML文件\r\n\t\t\t\tXDocument xmlDoc = XDocument.Load(xmlFilePath);\r\n\r\n\t\t\t\t// 使用LINQ to XML查询匹配搜索节点名称和值的节点\r\n\t\t\t\t// 注意：这里我们假设searchNodeName对应的节点是直接包含文本值的简单元素\r\n\t\t\t\t// 如果节点结构更复杂（例如有子节点），则需要调整查询逻辑\r\n\t\t\t\tvar nodes = xmlDoc.Descendants(searchNodeName) // 获取所有searchNodeName节点\r\n\t\t\t\t\t.Where(node => node.Value == searchValue) // 筛选出值等于searchValue的节点\r\n\t\t\t\t\t.Select(searchNode => searchNode.Parent) // 获取匹配节点的父节点（因为我们想获取的是与<name>平级的<email>节点）\r\n\t\t\t\t\t.Select(parentNode => parentNode.Element(targetNodeName)); // 从父节点中获取targetNodeName节点\r\n\r\n\t\t\t\t// 获取查询结果中的第一个元素（如果有的话），否则返回null\r\n\t\t\t\tvar resultNode = nodes.FirstOrDefault();\r\n\r\n\t\t\t\t// 返回目标节点的值（如果找到的话），否则返回null\r\n\t\t\t\treturn resultNode?.Value;\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 生成XML文件\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"filePath\">XML文件的路径</param>\r\n\t\t\t/// <param name=\"data\">要序列化为XML的对象</param>\r\n\t\t\tpublic static void GenerateXmlFile(string filePath, object data)\r\n\t\t\t{\r\n\t\t\t\t// 创建一个XmlSerializer实例，指定要序列化的类型\r\n\t\t\t\tXmlSerializer serializer = new XmlSerializer(data.GetType());\r\n\r\n\t\t\t\t// 使用StringWriter将序列化数据写入内存中的字符串\r\n\t\t\t\tusing (StringWriter writer = new StringWriter())\r\n\t\t\t\t{\r\n\t\t\t\t\t// 序列化对象到StringWriter\r\n\t\t\t\t\tserializer.Serialize(writer, data);\r\n\r\n\t\t\t\t\t// 获取序列化后的XML字符串\r\n\t\t\t\t\tstring xmlString = writer.ToString();\r\n\r\n\t\t\t\t\t// 将XML字符串写入文件\r\n\t\t\t\t\tFile.WriteAllText(filePath, xmlString);\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 生成JSON文件\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"filePath\">JSON文件的路径</param>\r\n\t\t\t/// <param name=\"data\">要序列化为JSON的数据</param>\r\n\t\t\t/// <typeparam name=\"T\">数据的类型</typeparam>\r\n\t\t\tpublic static string GenerateJsonFile<T>(string filePath, T data, bool needwrite)\r\n\t\t\t{\r\n\t\t\t\t// 将数据序列化为JSON字符串\r\n\t\t\t\tstring jsonString = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);\r\n\r\n\t\t\t\t// 将JSON字符串写入文件\r\n\t\t\t\tif (needwrite) { File.WriteAllText(filePath, jsonString); }\r\n\t\t\t\treturn jsonString;\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 反序列化指定路径的JSON文件为指定类型的对象。\r\n\t\t\t/// </summary>\r\n\t\t\t/// <typeparam name=\"T\">要反序列化的目标类型。</typeparam>\r\n\t\t\t/// <param name=\"filePath\">JSON文件的路径。</param>\r\n\t\t\t/// <returns>反序列化后的对象。</returns>\r\n\t\t\t/// <exception cref=\"FileNotFoundException\">如果指定的文件不存在。</exception>\r\n\t\t\t/// <exception cref=\"JsonException\">如果JSON内容无法反序列化为指定的类型。</exception>\r\n\t\t\tpublic static T DeserializeFromJson<T>(string filePath)\r\n\t\t\t{\r\n\t\t\t\t// 检查文件是否存在\r\n\t\t\t\tif (!File.Exists(filePath))\r\n\t\t\t\t{\r\n\t\t\t\t\tthrow new FileNotFoundException($\"The file '{filePath}' was not found.\", filePath);\r\n\t\t\t\t}\r\n\r\n\t\t\t\t// 读取文件内容\r\n\t\t\t\tstring jsonContent = File.ReadAllText(filePath);\r\n\r\n\t\t\t\t// 使用JsonConvert反序列化JSON字符串为指定类型的对象\r\n\t\t\t\tT deserializedObject = JsonConvert.DeserializeObject<T>(jsonContent);\r\n\r\n\t\t\t\treturn deserializedObject;\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 简单地从json文件中提取信息\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">路径</param>\r\n\t\t\t/// <param name=\"param\">要提取的参数信息</param>\r\n\t\t\t/// <returns></returns>\r\n\t\t\tpublic static string ReJson(string path, string param)\r\n\t\t\t{\r\n\t\t\t\t// 读取JSON文件内容\r\n\t\t\t\tstring jsonContent = File.ReadAllText(path);\r\n\r\n\t\t\t\t// 解析JSON内容到JObject\r\n\t\t\t\tJObject jsonObject = JObject.Parse(jsonContent);\r\n\r\n\t\t\t\t// 提取信息\r\n\t\t\t\treturn jsonObject[param].ToString();\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 生成一段json字符串\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">路径</param>\r\n\t\t\t/// <param name=\"headword\">头信息</param>\r\n\t\t\t/// <param name=\"param\">参数</param>\r\n\t\t\t/// <returns></returns>\r\n\t\t\tpublic static string SimpleToJson(string path, string headword, string param)\r\n\t\t\t{\r\n\t\t\t\tstring jsonString = headword + \"{:\" + param + \"}\";\r\n\r\n\t\t\t\tvar options = new JsonSerializerOptions\r\n\t\t\t\t{\r\n\t\t\t\t\tWriteIndented = true\r\n\t\t\t\t};\r\n\r\n\t\t\t\tstring formattedJsonString = System.Text.Json.JsonSerializer.Serialize(JsonDocument.Parse(jsonString).RootElement, options);\r\n\r\n\t\t\t\treturn formattedJsonString;\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 将信息添加到json文件\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"path\">文件路径</param>\r\n\t\t\t/// <param name=\"headword\">头信息</param>\r\n\t\t\t/// <param name=\"param\">参数</param>\r\n\t\t\tpublic static void AddToJson(string path, string headword, string param)\r\n\t\t\t{\r\n\t\t\t\tAddTextToFile(path, SimpleToJson(path, headword, param));\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 读取csv文件\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"filePath\"></param>\r\n\t\t\t/// <param name=\"split\"></param>\r\n\t\t\t/// <returns></returns>\r\n\t\t\tpublic static List<string[]> ReadCsvFile(string filePath, char split)\r\n\t\t\t{\r\n\t\t\t\tvar lines = new List<string[]>();\r\n\r\n\t\t\t\ttry\r\n\t\t\t\t{\r\n\t\t\t\t\tusing (StreamReader reader = new StreamReader(filePath))\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\tstring headerLine = reader.ReadLine(); // 读取标题行（可选）\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t   // 如果需要处理标题行，可以在这里处理，比如打印出来或者保存到另一个变量中\r\n\r\n\t\t\t\t\t\tstring line;\r\n\t\t\t\t\t\twhile ((line = reader.ReadLine()) != null)\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t// 使用逗号作为分隔符拆分每行（注意：这不会处理包含逗号的数据字段）\r\n\t\t\t\t\t\t\tstring[] values = line.Split(split);\r\n\r\n\t\t\t\t\t\t\t// 去除每个字段两端的空白字符（可选）\r\n\t\t\t\t\t\t\tfor (int i = 0; i < values.Length; i++)\r\n\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\tvalues[i] = values[i].Trim();\r\n\t\t\t\t\t\t\t}\r\n\r\n\t\t\t\t\t\t\tlines.Add(values);\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t\tcatch (Exception ex)\r\n\t\t\t\t{\r\n\r\n\t\t\t\t}\r\n\r\n\t\t\t\treturn lines;\r\n\t\t\t}\r\n\t\t\t/// <summary>\r\n\t\t\t/// 将内容写入CSV文件\r\n\t\t\t/// </summary>\r\n\t\t\t/// <param name=\"filePath\">CSV文件的路径</param>\r\n\t\t\t/// <param name=\"data\">要写入CSV文件的内容，每个字符串数组代表一行</param>\r\n\t\t\tpublic static void WriteToCsv(string filePath, List<string[]> data)\r\n\t\t\t{\r\n\t\t\t\t// 检查输入参数是否有效\r\n\t\t\t\tif (string.IsNullOrEmpty(filePath))\r\n\t\t\t\t\tthrow new ArgumentNullException(nameof(filePath), \"文件路径不能为空\");\r\n\t\t\t\tif (data == null || data.Count == 0)\r\n\t\t\t\t\tthrow new ArgumentNullException(nameof(data), \"数据不能为空\");\r\n\r\n\t\t\t\t// 使用StringBuilder来构建CSV内容\r\n\t\t\t\tStringBuilder csvContent = new StringBuilder();\r\n\r\n\t\t\t\t// 遍历数据列表，将每行写入StringBuilder\r\n\t\t\t\tforeach (var row in data)\r\n\t\t\t\t{\r\n\t\t\t\t\t// 使用逗号分隔每个单元格的内容，并对特殊字符进行转义（例如，逗号、换行符等）\r\n\t\t\t\t\tstring rowContent = string.Join(\",\", Array.ConvertAll(row, cell => cell.Contains(\",\") || cell.Contains(\"\\n\") || cell.Contains(\"\\r\") || cell.Contains(\"\\\"\") ? \"\\\"\" + cell.Replace(\"\\\"\", \"\\\"\\\"\") + \"\\\"\" : cell));\r\n\t\t\t\t\tcsvContent.AppendLine(rowContent);\r\n\t\t\t\t}\r\n\r\n\t\t\t\t// 将StringBuilder的内容写入文件\r\n\t\t\t\tFile.WriteAllText(filePath, csvContent.ToString(), Encoding.UTF8);\r\n\t\t\t}\r\n\t\t}\r\n\t}\r\n\t/// <summary>\r\n\t/// 日志管理系统\r\n\t/// </summary>\r\n\tpublic class Log\r\n\t{\r\n\t\tprivate static List<LogEntry> Logs = new List<LogEntry>();\r\n\t\tpublic class LogEntry\r\n\t\t{\r\n\t\t\tpublic DateTime Timestamp { get; set; }\r\n\t\t\tpublic string Message { get; set; }\r\n\t\t}\r\n\t\tprivate static readonly string LogFilePath = \"logs.json\";\r\n\t\t/// <summary>\r\n\t\t/// 记录日志\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"message\">信息</param>\r\n\t\t/// <param name=\"path\">本程序的路径</param>\r\n\t\tpublic static void rec(string message, string path)\r\n\t\t{\r\n\t\t\tList<LogEntry> logs = new List<LogEntry>();\r\n\r\n\t\t\t// 如果logs.json文件已经存在，则读取现有的日志条目\r\n\t\t\tif (File.Exists(LogFilePath))\r\n\t\t\t{\r\n\t\t\t\tstring jsona = File.ReadAllText(LogFilePath);\r\n\t\t\t\tlogs = JsonConvert.DeserializeObject<List<LogEntry>>(jsona);\r\n\t\t\t}\r\n\r\n\t\t\t// 添加新的日志条目\r\n\t\t\tlogs.Add(new LogEntry\r\n\t\t\t{\r\n\t\t\t\tTimestamp = DateTime.Now,\r\n\t\t\t\tMessage = \"INFO：\" + path + \"：\" + message,\r\n\t\t\t});\r\n\r\n\t\t\t// 将日志条目序列化为JSON字符串并写回文件\r\n\t\t\tstring json = JsonConvert.SerializeObject(logs, Newtonsoft.Json.Formatting.Indented);\r\n\t\t\tFile.WriteAllText(LogFilePath, json);\r\n\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 记录日志\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"message\">信息</param>\r\n\t\t/// <param name=\"excutetime\">执行所用的时间</param>\r\n\t\t/// <param name=\"path\">路径</param>\r\n\t\tpublic static void rec(string message, int excutetime, string path)\r\n\t\t{\r\n\t\t\trec(message + \"：FinishedTimeSnap：\" + excutetime, path);\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 获取某一时间点的日志信息\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"dt\">时间点</param>\r\n\t\t/// <returns>日志信息</returns>\r\n\t\tpublic static string getlog(DateTime dt)\r\n\t\t{\r\n\t\t\tvar specificTime = dt;\r\n\t\t\tLoadLogs();\r\n\t\t\tLogEntry logEntry = GetLogEntryAtTime(specificTime);\r\n\t\t\tif (logEntry != null)\r\n\t\t\t{\r\n\t\t\t\treturn logEntry.Message + \"：\" + logEntry.Timestamp;\r\n\t\t\t}\r\n\t\t\telse\r\n\t\t\t{\r\n\t\t\t\treturn \"0\";\r\n\t\t\t}\r\n\t\t}\r\n\t\tprivate static void LoadLogs()\r\n\t\t{\r\n\t\t\t// 如果logs.json文件已经存在，则读取现有的日志条目\r\n\t\t\tif (File.Exists(LogFilePath))\r\n\t\t\t{\r\n\t\t\t\tstring json = File.ReadAllText(LogFilePath);\r\n\t\t\t\tLogs = JsonConvert.DeserializeObject<List<LogEntry>>(json);\r\n\t\t\t}\r\n\t\t}\r\n\t\tprivate static LogEntry GetLogEntryAtTime(DateTime time)\r\n\t\t{\r\n\t\t\t// 使用LINQ查询找到与时间点相匹配的日志条目（这里使用精确匹配，你可以根据需要调整）\r\n\t\t\treturn Logs.FirstOrDefault(log => log.Timestamp == time);\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 删除某个指定log\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"dt\">时间戳</param>\r\n\t\tpublic static void deletelog(DateTime dt)\r\n\t\t{\r\n\t\t\tRemoveLogEntryByTimestamp(dt);\r\n\r\n\t\t\t// 验证删除结果（可选）\r\n\t\t\tList<LogEntry> logs = ReadLogEntries();\r\n\t\t\tforeach (var log in logs)\r\n\t\t\t{\r\n\t\t\t\tConsole.WriteLine($\"Timestamp: {log.Timestamp}, Message: {log.Message}\");\r\n\t\t\t}\r\n\t\t}\r\n\t\tprivate static void RemoveLogEntryByTimestamp(DateTime timestampToRemove)\r\n\t\t{\r\n\t\t\tList<LogEntry> logs = new List<LogEntry>();\r\n\r\n\t\t\t// 如果logs.json文件存在，则读取现有的日志条目\r\n\t\t\tif (File.Exists(LogFilePath))\r\n\t\t\t{\r\n\t\t\t\tstring qjson = File.ReadAllText(LogFilePath);\r\n\t\t\t\tlogs = JsonConvert.DeserializeObject<List<LogEntry>>(qjson);\r\n\t\t\t}\r\n\r\n\t\t\t// 移除与指定时间点匹配的日志条目\r\n\t\t\tlogs = logs.Where(log => log.Timestamp != timestampToRemove).ToList();\r\n\r\n\t\t\t// 将更新后的日志条目序列化为JSON字符串并写回文件\r\n\t\t\tstring json = JsonConvert.SerializeObject(logs, Newtonsoft.Json.Formatting.Indented);\r\n\t\t\tFile.WriteAllText(LogFilePath, json);\r\n\t\t}\r\n\t\tprivate static List<LogEntry> ReadLogEntries()\r\n\t\t{\r\n\t\t\tList<LogEntry> logs = new List<LogEntry>();\r\n\r\n\t\t\t// 如果logs.json文件存在，则读取现有的日志条目\r\n\t\t\tif (File.Exists(LogFilePath))\r\n\t\t\t{\r\n\t\t\t\tstring json = File.ReadAllText(LogFilePath);\r\n\t\t\t\tlogs = JsonConvert.DeserializeObject<List<LogEntry>>(json);\r\n\t\t\t}\r\n\r\n\t\t\treturn logs;\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 读取日志中的条目\r\n\t\t/// </summary>\r\n\t\t/// <returns>返回日志列表</returns>\r\n\t\t/// <exception cref=\"FileNotFoundException\"></exception>\r\n\t\tpublic static List<LogEntry> ReadLogs()\r\n\t\t{\r\n\t\t\tif (File.Exists(\"logs.json\"))\r\n\t\t\t{\r\n\t\t\t\tstring json = File.ReadAllText(\"logs.json\");\r\n\t\t\t\tList<LogEntry> logs = JsonConvert.DeserializeObject<List<LogEntry>>(json);\r\n\r\n\t\t\t\treturn logs;\r\n\t\t\t}\r\n\t\t\telse\r\n\t\t\t{\r\n\t\t\t\tthrow new FileNotFoundException();\r\n\t\t\t}\r\n\t\t}\r\n\t}\r\n\t/// <summary>\r\n\t/// 关于互联网的一些相关操作\r\n\t/// </summary>\r\n\tpublic class Internet\r\n\t{\r\n\t\t/// <summary>\r\n\t\t/// 从Internet下载文件\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"fileUrl\">文件在网络上的路径</param>\r\n\t\t/// <param name=\"savePath\">保存的路径</param>\r\n\t\t/// <returns>下载所用时间会被保存到\"downloadinfo\"中</returns>\r\n\t\tpublic static async Task DownloadFileAsync(string fileUrl, string savePath)\r\n\t\t{\r\n\t\t\tStopwatch sw = new Stopwatch();\r\n\t\t\tsw.Start();\r\n\t\t\tusing (HttpClient client = new HttpClient())\r\n\t\t\t{\r\n\t\t\t\t// 发送HTTP GET请求以获取文件\r\n\t\t\t\tHttpResponseMessage response = await client.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead);\r\n\t\t\t\tresponse.EnsureSuccessStatusCode(); // 确保请求成功\r\n\r\n\t\t\t\t// 获取响应的内容流\r\n\t\t\t\tusing (Stream contentStream = await response.Content.ReadAsStreamAsync())\r\n\t\t\t\tusing (Stream fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None))\r\n\t\t\t\t{\r\n\t\t\t\t\t// 将内容流复制到文件流\r\n\t\t\t\t\tawait contentStream.CopyToAsync(fileStream);\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t\tsw.Stop();\r\n\t\t\tTimeSpan ts = sw.Elapsed;\r\n\t\t\tif (File.Exists(\"downloadinfo\"))\r\n\t\t\t{\r\n\t\t\t\tFile.Delete(\"downloadinfo\");\r\n\t\t\t}\r\n\t\t\tFile.WriteAllText(\"downloadinfo\", ts.TotalMilliseconds.ToString());\r\n\t\t}/// <summary>\r\n\t\t /// 获取下载时长\r\n\t\t /// </summary>\r\n\t\t /// <returns>返回的下载时长。请用tryparse方法对返回值进行转化</returns>\r\n\t\tpublic static string GetDownloadInfo()\r\n\t\t{\r\n\t\t\ttry\r\n\t\t\t{\r\n\t\t\t\treturn IO.Text.Read(\"downloadinfo\");\r\n\t\t\t}\r\n\t\t\tcatch (Exception ex)\r\n\t\t\t{\r\n\t\t\t\treturn ex.Message;\r\n\t\t\t}\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 创建tcp服务端并监听\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"ipadress\">tcp地址</param>\r\n\t\t/// <param name=\"port\">端口</param>\r\n\t\t/// <param name=\"messagereturn\">回显发送信息</param>\r\n\t\t/// <returns>tcp获取的信息将会保存到\"message(时间).msg\"中，以中文冒号分隔每一行</returns>\r\n\t\tpublic static async Task TcpReceive(string ipadress, int port, string messagereturn)\r\n\t\t{\r\n\t\t\tTcpListener server = null;\r\n\t\t\ttry\r\n\t\t\t{\r\n\t\t\t\t// 设置本地终结点\r\n\t\t\t\tIPAddress localAddr = IPAddress.Parse(ipadress);\r\n\t\t\t\tserver = new TcpListener(localAddr, port);\r\n\r\n\t\t\t\t// 启动服务器监听\r\n\t\t\t\tserver.Start();\r\n\r\n\t\t\t\twhile (true)\r\n\t\t\t\t{\r\n\t\t\t\t\t// 接受客户端连接\r\n\t\t\t\t\tTcpClient client = await server.AcceptTcpClientAsync();\r\n\r\n\t\t\t\t\t// 读取客户端发送的消息\r\n\t\t\t\t\tNetworkStream stream = client.GetStream();\r\n\t\t\t\t\tbyte[] buffer = new byte[256];\r\n\t\t\t\t\tint bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);\r\n\t\t\t\t\tstring message = Encoding.UTF8.GetString(buffer, 0, bytesRead);\r\n\t\t\t\t\tIO.Text.AddTextToFile(\"message.msg\", message + \"：\\n\");\r\n\r\n\t\t\t\t\t// 发送回应消息给客户端\r\n\t\t\t\t\tbyte[] msg = Encoding.UTF8.GetBytes(messagereturn);\r\n\t\t\t\t\tawait stream.WriteAsync(msg, 0, msg.Length);\r\n\r\n\t\t\t\t\t// 关闭客户端连接\r\n\t\t\t\t\tclient.Close();\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t\tcatch (SocketException e)\r\n\t\t\t{\r\n\t\t\t\tthrow e;\r\n\t\t\t}\r\n\t\t\tfinally\r\n\t\t\t{\r\n\t\t\t\t// 停止服务器监听\r\n\t\t\t\tserver?.Stop();\r\n\t\t\t}\r\n\t\t\treturn;\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 获取tcp接收的消息\r\n\t\t/// </summary>\r\n\t\t/// <returns>消息列表</returns>\r\n\t\tpublic static List<string> TcpInfo()\r\n\t\t{\r\n\t\t\tList<string> list = new List<string>();\r\n\t\t\tstring[] strs = IO.Text.ReadByLines(\"message.msg\");\r\n\t\t\tforeach (string str in strs)\r\n\t\t\t{\r\n\t\t\t\tlist.Add(str);\r\n\t\t\t}\r\n\t\t\treturn list;\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 清理昨天的msg文件，如果需要的话可以将此文件每日备份并重新命名\r\n\t\t/// </summary>\r\n\t\t/// <returns>true为成功，false为失败或没到时间</returns>\r\n\t\t/// <exception cref=\"FileNotFoundException\">文件不存在</exception>\r\n\t\tpublic static bool ClearMsg()\r\n\t\t{\r\n\t\t\tstring filePath = \"message.msg\"; // 请将此路径替换为实际的文件路径\r\n\r\n\t\t\t// 检查文件是否存在\r\n\t\t\tif (File.Exists(filePath))\r\n\t\t\t{\r\n\t\t\t\t// 获取文件的最后修改时间\r\n\t\t\t\tFileInfo fileInfo = new FileInfo(filePath);\r\n\t\t\t\tDateTime lastWriteTime = fileInfo.LastWriteTime;\r\n\r\n\t\t\t\t// 获取当前时间\r\n\t\t\t\tDateTime currentTime = DateTime.Now;\r\n\r\n\t\t\t\t// 计算时间差\r\n\t\t\t\tTimeSpan timeDifference = currentTime - lastWriteTime;\r\n\r\n\t\t\t\t// 检查时间差是否超过24小时\r\n\t\t\t\tif (timeDifference.TotalHours >= 24)\r\n\t\t\t\t{\r\n\t\t\t\t\ttry\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\t// 删除文件\r\n\t\t\t\t\t\tFile.Delete(filePath);\r\n\t\t\t\t\t\treturn true;\r\n\t\t\t\t\t}\r\n\t\t\t\t\tcatch (Exception ex)\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\tthrow ex;\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t\telse\r\n\t\t\t\t{\r\n\t\t\t\t\treturn false;\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t\telse\r\n\t\t\t{\r\n\t\t\t\tthrow new FileNotFoundException();\r\n\t\t\t}\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 设置一个tcp客户端\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"ipadress\">目标服务器地址</param>\r\n\t\t/// <param name=\"port\">端口</param>\r\n\t\t/// <param name=\"message\">要发送的消息</param>\r\n\t\t/// <returns></returns>\r\n\t\tpublic static async Task TcpClient(string ipadress, int port, string message)\r\n\t\t{\r\n\t\t\ttry\r\n\t\t\t{\r\n\t\t\t\t// 设置服务器终结点\r\n\t\t\t\tstring server = ipadress;\r\n\t\t\t\tTcpClient client = new TcpClient();\r\n\r\n\t\t\t\t// 连接到服务器\r\n\t\t\t\tawait client.ConnectAsync(server, port);\r\n\r\n\t\t\t\t// 发送消息到服务器\r\n\t\t\t\tNetworkStream stream = client.GetStream();\r\n\t\t\t\tbyte[] data = Encoding.UTF8.GetBytes(message);\r\n\t\t\t\tawait stream.WriteAsync(data, 0, data.Length);\r\n\r\n\t\t\t\t// 接收服务器的回应消息\r\n\t\t\t\tbyte[] buffer = new byte[256];\r\n\t\t\t\tint bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);\r\n\t\t\t\tstring response = Encoding.UTF8.GetString(buffer, 0, bytesRead);\r\n\r\n\t\t\t\t// 关闭连接\r\n\t\t\t\tstream.Close();\r\n\t\t\t\tclient.Close();\r\n\t\t\t}\r\n\t\t\tcatch (ArgumentNullException e)\r\n\t\t\t{\r\n\t\t\t\tthrow e;\r\n\t\t\t}\r\n\t\t\tcatch (SocketException e)\r\n\t\t\t{\r\n\t\t\t\tthrow e;\r\n\t\t\t}\r\n\t\t}\r\n\t}\r\n\tpublic static class Security\r\n\t{\r\n\t\t#region 加密字符串 \r\n\r\n\t\t/// <summary> /// 加密字符串  \r\n\r\n\t\t/// </summary> \r\n\r\n\t\t/// <param name=\"str\">要加密的字符串</param> \r\n\r\n\t\t/// <returns>加密后的字符串</returns> \r\n\r\n\t\tstatic string Encrypt(string str, string encryptKey)\r\n\t\t{\r\n\t\t\tDESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象  \r\n\r\n\r\n\r\n\t\t\tbyte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥   \r\n\r\n\r\n\r\n\t\t\tbyte[] data = Encoding.Unicode.GetBytes(str);//定义字节数组，用来存储要加密的字符串 \r\n\r\n\r\n\r\n\t\t\tMemoryStream MStream = new MemoryStream(); //实例化内存流对象     \r\n\r\n\r\n\r\n\t\t\t//使用内存流实例化加密流对象  \r\n\r\n\t\t\tCryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);\r\n\r\n\r\n\r\n\t\t\tCStream.Write(data, 0, data.Length);  //向加密流中写入数据     \r\n\r\n\r\n\r\n\t\t\tCStream.FlushFinalBlock();              //释放加密流     \r\n\r\n\r\n\r\n\t\t\treturn Convert.ToBase64String(MStream.ToArray());//返回加密后的字符串 \r\n\r\n\t\t}\r\n\r\n\t\t#endregion\r\n\t\t#region 解密字符串  \r\n\r\n\t\t/// <summary> \r\n\r\n\t\t/// 解密字符串  \r\n\r\n\t\t/// </summary> \r\n\r\n\t\t/// <param name=\"str\">要解密的字符串</param> \r\n\r\n\t\t/// <returns>解密后的字符串</returns> \r\n\r\n\t\tstatic string Decrypt(string str, string encryptKey)\r\n\r\n\t\t{\r\n\r\n\t\t\tDESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象   \r\n\r\n\r\n\r\n\t\t\tbyte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥   \r\n\r\n\r\n\r\n\t\t\tbyte[] data = Convert.FromBase64String(str);//定义字节数组，用来存储要解密的字符串 \r\n\r\n\r\n\r\n\t\t\tMemoryStream MStream = new MemoryStream(); //实例化内存流对象     \r\n\r\n\r\n\r\n\t\t\t//使用内存流实例化解密流对象      \r\n\r\n\t\t\tCryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);\r\n\r\n\r\n\r\n\t\t\tCStream.Write(data, 0, data.Length);      //向解密流中写入数据    \r\n\r\n\r\n\r\n\t\t\tCStream.FlushFinalBlock();               //释放解密流     \r\n\r\n\r\n\r\n\t\t\treturn Encoding.Unicode.GetString(MStream.ToArray());       //返回解密后的字符串 \r\n\r\n\t\t}\r\n\r\n\t\t#endregion\r\n\r\n\t}\r\n\t/// <summary>\r\n\t/// 与外部程序有关的操作\r\n\t/// </summary>\r\n\tpublic static class Progress\r\n\t{\r\n\t\t/// <summary>\r\n\t\t/// 解析C#代码\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"path\">代码路径</param>\r\n\t\tpublic static void GetCSharpAnalyzed(string path)\r\n\t\t{\r\n\t\t\ttry\r\n\t\t\t{\r\n\t\t\t\tstring code = IO.Text.Read(path);\r\n\r\n\t\t\t\tSyntaxTree tree = CSharpSyntaxTree.ParseText(code);\r\n\t\t\t\tSyntaxNode root = tree.GetRoot();\r\n\r\n\t\t\t\tvar classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();\r\n\r\n\t\t\t\tforeach (var classDecl in classDeclarations)\r\n\t\t\t\t{\r\n\t\t\t\t\tConsole.WriteLine($\"Class: {classDecl.Identifier.Text}\");\r\n\r\n\t\t\t\t\tvar methodDeclarations = classDecl.DescendantNodes().OfType<MethodDeclarationSyntax>();\r\n\t\t\t\t\tforeach (var methodDecl in methodDeclarations)\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\tConsole.WriteLine($\"  Method: {methodDecl.Identifier.Text}\");\r\n\t\t\t\t\t}\r\n\r\n\t\t\t\t\tConsole.WriteLine();\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t\tcatch(Exception ex)\r\n\t\t\t{\r\n\t\t\t\tthrow ex;\r\n\t\t\t}\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 等待\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"Millionseconds\">等待时间</param>\r\n\t\tpublic static void Held(int Millionseconds)\r\n\t\t{\r\n\t\t\tThread.Sleep(Millionseconds);\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 调用外部程序\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"path\">程序路径</param>\r\n\t\tpublic static void start(string path)\r\n\t\t{\r\n\t\t\tProcessStartInfo processStartInfo = new ProcessStartInfo(path);\r\n\t\t\tProcess.Start(processStartInfo);\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 调用外部程序\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"path\">路径</param>\r\n\t\t/// <param name=\"runas\">是否以管理员权限运行</param>\r\n\t\tpublic static void start(string path, bool runas)\r\n\t\t{\r\n\t\t\tProcessStartInfo processStartInfo = new ProcessStartInfo(path);\r\n\t\t\tif (runas) { processStartInfo.Verb = \"runas\"; }\r\n\t\t\tProcess.Start(processStartInfo);\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 调用外部程序\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"path\">路径</param>\r\n\t\t/// <param name=\"param\">参数</param>\r\n\t\tpublic static void start(string path, string param)\r\n\t\t{\r\n\t\t\tProcessStartInfo processStartInfo = new ProcessStartInfo(path, param);\r\n\t\t\tProcess.Start(processStartInfo);\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 调用外部程序\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"path\">路径</param>\r\n\t\t/// <param name=\"runas\">是否以管理员权限运行</param>\r\n\t\t/// <param name=\"param\">参数</param>\r\n\t\tpublic static void start(string path, bool runas, string param)\r\n\t\t{\r\n\t\t\tProcessStartInfo processStartInfo = new ProcessStartInfo(path, param);\r\n\t\t\tif (runas) { processStartInfo.Verb = \"runas\"; }\r\n\t\t\tProcess.Start(processStartInfo);\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 结束指定进程\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"processname\">进程名字（通常以可执行文件去掉后缀名构成）</param>\r\n\t\tpublic static void kill(string processname)\r\n\t\t{\r\n\t\t\tProcess[] processes = Process.GetProcessesByName(processname);\r\n\t\t\tforeach (Process process in processes)\r\n\t\t\t{\r\n\t\t\t\tprocess.Kill();\r\n\t\t\t}\r\n\t\t}\r\n\t}\r\n\t/// <summary>\r\n\t/// 与压缩文件有关的操作\r\n\t/// </summary>\r\n\tpublic static class Zip\r\n\t{\r\n\t\t/// <summary>\r\n\t\t/// 解压文件\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"zipPath\">压缩包位置</param>\r\n\t\t/// <param name=\"extractPath\">解压路径</param>\r\n\t\t/// <returns>是否成功</returns>\r\n\t\t/// <exception cref=\"FileNotFoundException\">文件不存在</exception>\r\n\t\tpublic static bool Unzip(string zipPath,string extractPath)\r\n\t\t{\r\n\t\t\t// 确保ZIP文件存在\r\n\t\t\tif (File.Exists(zipPath))\r\n\t\t\t{\r\n\t\t\t\t// 解压ZIP文件\r\n\t\t\t\tZipFile.ExtractToDirectory(zipPath, extractPath);\r\n\t\t\t\treturn true;\r\n\t\t\t}\r\n\t\t\telse\r\n\t\t\t{\r\n\t\t\t\tthrow new FileNotFoundException();\r\n\t\t\t}\r\n\t\t}\r\n\t\t/// <summary>\r\n\t\t/// 压缩目录到zip\r\n\t\t/// </summary>\r\n\t\t/// <param name=\"sourceDirectory\">源目录</param>\r\n\t\t/// <param name=\"zipFilePath\">压缩包位置</param>\r\n\t\t/// <returns>是否成功</returns>\r\n\t\tpublic static bool Tozip(string sourceDirectory, string zipFilePath)\r\n\t\t{\r\n\t\t\t\r\n\r\n\t\t\tusing (FileStream zipToCreate = new FileStream(zipFilePath, FileMode.Create))\r\n\t\t\tusing (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create))\r\n\t\t\t{\r\n\t\t\t\tstring[] files = Directory.GetFiles(sourceDirectory);\r\n\r\n\t\t\t\tforeach (string file in files)\r\n\t\t\t\t{\r\n\t\t\t\t\tstring entryName = Path.GetRelativePath(sourceDirectory, file).Replace(\"\\\\\", \"/\");\r\n\t\t\t\t\tZipArchiveEntry readFileInArchive = archive.CreateEntryFromFile(file, entryName, CompressionLevel.Fastest);\r\n\t\t\t\t}\r\n\r\n\t\t\t\treturn true;\r\n\t\t\t}\r\n\t\t}\r\n\t}\r\n}\r\n\r\n";
			IO.Text.Write("simIO.cs", sc);
		}

	}
	public class IO
	{
		/// <summary>
		/// 用于控制台的简单操作
		/// </summary>
		public class Stream
		{
			public bool Endl = true;
			/// <summary>
			/// 在控制台中输出文字
			/// </summary>
			/// <param name="towrite">要输出的文字</param>
			public static string print(string towrite, bool endl)
			{
				try
				{
					if (endl) { Console.WriteLine(towrite + "\n"); }
					else { Console.WriteLine(towrite); }
					return "";
				}
				catch (Exception e)
				{
					return e.Message;
				}
			}
			/// <summary>
			/// 返回用户输入的文字
			/// </summary>
			/// <returns>返回文字</returns>
			public static string readl()
			{
				try
				{
					return Console.ReadLine();
				}
				catch (Exception e)
				{
					return e.Message;
				}
			}
		}
		/// <summary>
		/// 用于目录的操作
		/// </summary>
		public class Dir
		{
			/// <summary>
			/// 判断目录是否存在
			/// </summary>
			/// <param name="path">路径</param>
			/// <returns>布尔值</returns>
			public static bool Exist(string path)
			{
				return Directory.Exists(path);
			}
			/// <summary>
			/// 创建目录
			/// </summary>
			/// <param name="path">目录路径</param>
			/// <returns>异常信息，如果没有就是没有异常</returns>
			public static string CreateDirectory(string path)
			{
				try
				{
					Directory.CreateDirectory(path);
					return "";
				}
				catch (Exception e)
				{
					return e.Message;
				}
			}
			/// <summary>
			/// 删除目录
			/// </summary>
			/// <param name="path">目录路径</param>
			/// <returns>异常信息，如果没有就是没有异常</returns>
			public static string DeleteDirectory(string path)
			{
				try
				{
					Directory.Delete(path);
					return "";
				}
				catch (Exception e) { return e.Message; }
			}
			/// <summary>
			/// 从目录中获取文件列表
			/// </summary>
			/// <param name="path">目录路径</param>
			/// <returns>文件列表</returns>
			public static FileInfo[] GetFilesFromDirectory(string path)
			{
				DirectoryInfo dir = new DirectoryInfo(path);
				return dir.GetFiles();
			}
			/// <summary>
			/// 获取当前程序所在目录路径
			/// </summary>
			/// <returns>当前程序目录所在路径</returns>
			public static string GetThisProcessesPath()
			{
				string assemblyPath = Assembly.GetExecutingAssembly().Location;
				return Path.GetDirectoryName(assemblyPath);
			}
			/// <summary>
			/// 获取当前程序所在路径
			/// </summary>
			/// <returns>当前程序所在完整路径</returns>
			public static string GetThisProcessesFileName()
			{
				string assemblyPath = Assembly.GetExecutingAssembly().Location;
				return assemblyPath;
			}
			/// <summary>
			/// 复制目录及其子文件
			/// </summary>
			/// <param name="source">源目录</param>
			/// <param name="destination">目标目录</param>
			public static void Copy(string source, string destination)
			{
				if (!Directory.Exists(destination))
				{
					Directory.CreateDirectory(destination);
				}
				Private.CopyDirectory(source, destination);
			}
			/// <summary>
			/// 剪切目录及其子文件
			/// </summary>
			/// <param name="source">源目录</param>
			/// <param name="destination">目标目录</param>
			public static void Cut(string source, string destination)
			{
				Copy(source, destination);
				Directory.Delete(source, true);
			}
		}
		/// <summary>
		/// 执行有关文件的操作
		/// </summary>
		public class Files
		{
			/// <summary>
			/// 判断文件是否存在
			/// </summary>
			/// <param name="path">文件路径</param>
			/// <returns>布尔值</returns>
			public static bool Exist(string path)
			{
				return File.Exists(path);
			}
			/// <summary>
			/// 创建一个空文件
			/// </summary>
			/// <param name="path">路径</param>
			public static void Create(string path)
			{
				File.Create(path);
			}
			/// <summary>
			/// 删除一个已有文件
			/// </summary>
			/// <param name="path">路径</param>
			/// <returns>是否已经删除</returns>
			public static bool Delete(string path)
			{
				File.Delete(path);
				if (File.Exists(path))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			/// <summary>
			/// 复制文件到指定位置
			/// </summary>
			/// <param name="path">原位置</param>
			/// <param name="destination">目标位置</param>
			public static void Copy(string path, string destination)
			{
				File.Copy(path, destination);
			}
			/// <summary>
			/// 剪切文件到指定位置
			/// </summary>
			/// <param name="path">原路径</param>
			/// <param name="destination">目标路径</param>
			public static void Cut(string path, string destination)
			{
				File.Copy(path, destination);
				Delete(path);
			}
			/// <summary>
			/// 获得文件名字
			/// </summary>
			/// <param name="path">路径</param>
			/// <returns>文件名字</returns>
			public static string FileName(string path)
			{
				FileInfo fi = new FileInfo(path);
				return fi.Name;
			}
			/// <summary>
			/// 获得文件完整路径
			/// </summary>
			/// <param name="path">路径</param>
			/// <returns>完整路径</returns>
			public static string FullName(string path)
			{
				FileInfo fi = new FileInfo(path);
				return fi.FullName;
			}
		}
		/// <summary>
		/// 关于文本的操作
		/// </summary>
		public class Text
		{ 
			/// <summary>
			/// 与剪贴板相关的操作
			/// </summary>
            class Clipborad
	{
		// 导入Windows API函数
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool OpenClipboard(IntPtr hWndNewOwner);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool EmptyClipboard();

		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr SetClipboardData(uint uFormat, IntPtr hData);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr GetClipboardData(uint uFormat);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool CloseClipboard();

		// 剪贴板格式常量
		private const uint CF_UNICODETEXT = 0x000D;

		/// <summary>
		/// 将文本添加到剪贴板
		/// </summary>
		/// <param name="text">要设置的文字</param>
		public static void SetClipboardText(string text)
		{
			if (OpenClipboard(IntPtr.Zero))
			{
				EmptyClipboard();

				IntPtr hGlobal = Marshal.AllocHGlobal((text.Length + 1) * Marshal.SizeOf(typeof(char)));
				try
				{
					Marshal.Copy(text.ToCharArray(), 0, hGlobal, text.Length);
					Marshal.WriteInt32(hGlobal, text.Length * Marshal.SizeOf(typeof(char)), 0); // Null-terminate the string

					SetClipboardData(CF_UNICODETEXT, hGlobal);
				}
				finally
				{
					Marshal.FreeHGlobal(hGlobal);
					CloseClipboard();
				}
			}
		}

		/// <summary>
		/// 从剪贴板获取文本
		/// </summary>
		/// <returns>获取到的文本</returns>
		public static string GetClipboardText()
		{
			if (OpenClipboard(IntPtr.Zero))
			{
				IntPtr ptr = GetClipboardData(CF_UNICODETEXT);

				if (ptr != IntPtr.Zero)
				{
					int size = Marshal.ReadInt32(ptr, -4); // Size of the string, including null terminator
					byte[] data = new byte[size];
					Marshal.Copy(ptr, data, 0, size);

					string text = Encoding.Unicode.GetString(data).TrimEnd('\0'); // Remove null terminator
					CloseClipboard();
					return text;
				}
				else
				{
					CloseClipboard();
					return null;
				}
			}
			else
			{
				return null;
			}
		}
	}
	/// <summary>
	/// 将文字写入到文本文档中
	/// </summary>
	/// <param name="path">路径</param>
	/// <param name="text">内容</param>
	public static void Write(string path, string text)
			{
				StreamWriter writer = new StreamWriter(path);
				writer.Write(text);
				writer.Close();
			}
			/// <summary>
			/// 根据命令生成bat文件
			/// </summary>
			/// <param name="path">bat文件完整路径</param>
			/// <param name="Text">内容</param>
			public static void WriteToBat(string path, string Text)
			{
				string content= "cd " + Path.GetDirectoryName(path) + "\n" + Text;
				File.WriteAllText(path, content, Encoding.ASCII);
			}
			/// <summary>
			/// 读取文本文档中的内容
			/// </summary>
			/// <param name="path">路径</param>
			/// <returns>内容</returns>
			public static string Read(string path)
			{
				StreamReader reader = new StreamReader(path);
				string sr = reader.ReadToEnd();
				reader.Close();
				return sr;
			}
			/// <summary>
			/// 逐行读取文本文档中的内容
			/// </summary>
			/// <param name="path">路径</param>
			/// <returns>内容</returns>
			public static string[] ReadByLines(string path)
			{
				return File.ReadAllLines(path);
			}
			/// <summary>
			/// 添加内容到文件末尾
			/// </summary>
			/// <param name="path">路径</param>
			/// <param name="text">内容</param>
			public static void AddTextToFile(string path, string text)
			{
				string content = Read(path);
				File.Delete(path);
				Write(path, content + text);
			}
			/// <summary>
			/// 从XML文件中获取指定节点的值
			/// </summary>
			/// <param name="xmlFilePath">XML文件的路径</param>
			/// <param name="searchNodeName">要搜索的节点名称</param>
			/// <param name="searchValue">要搜索的节点值</param>
			/// <param name="targetNodeName">目标节点名称（即找到搜索节点后，要获取其值的节点名称）</param>
			/// <returns>返回目标节点的值，如果未找到则返回null</returns>
			public static string GetXmlNodeValue(string xmlFilePath, string searchNodeName, string searchValue, string targetNodeName)
			{
				// 检查文件是否存在，如果不存在则抛出异常
				if (!File.Exists(xmlFilePath))
				{
					throw new FileNotFoundException($"The file '{xmlFilePath}' was not found.");
				}

				// 使用XDocument加载XML文件
				XDocument xmlDoc = XDocument.Load(xmlFilePath);

				// 使用LINQ to XML查询匹配搜索节点名称和值的节点
				// 注意：这里我们假设searchNodeName对应的节点是直接包含文本值的简单元素
				// 如果节点结构更复杂（例如有子节点），则需要调整查询逻辑
				var nodes = xmlDoc.Descendants(searchNodeName) // 获取所有searchNodeName节点
					.Where(node => node.Value == searchValue) // 筛选出值等于searchValue的节点
					.Select(searchNode => searchNode.Parent) // 获取匹配节点的父节点（因为我们想获取的是与<name>平级的<email>节点）
					.Select(parentNode => parentNode.Element(targetNodeName)); // 从父节点中获取targetNodeName节点

				// 获取查询结果中的第一个元素（如果有的话），否则返回null
				var resultNode = nodes.FirstOrDefault();

				// 返回目标节点的值（如果找到的话），否则返回null
				return resultNode?.Value;
			}
			/// <summary>
			/// 生成XML文件
			/// </summary>
			/// <param name="filePath">XML文件的路径</param>
			/// <param name="data">要序列化为XML的对象</param>
			public static void GenerateXmlFile(string filePath, object data)
			{
				// 创建一个XmlSerializer实例，指定要序列化的类型
				XmlSerializer serializer = new XmlSerializer(data.GetType());

				// 使用StringWriter将序列化数据写入内存中的字符串
				using (StringWriter writer = new StringWriter())
				{
					// 序列化对象到StringWriter
					serializer.Serialize(writer, data);

					// 获取序列化后的XML字符串
					string xmlString = writer.ToString();

					// 将XML字符串写入文件
					File.WriteAllText(filePath, xmlString);
				}
			}
			/// <summary>
			/// 生成JSON文件
			/// </summary>
			/// <param name="filePath">JSON文件的路径</param>
			/// <param name="data">要序列化为JSON的数据</param>
			/// <typeparam name="T">数据的类型</typeparam>
			public static string GenerateJsonFile<T>(string filePath, T data, bool needwrite)
			{
				// 将数据序列化为JSON字符串
				string jsonString = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);

				// 将JSON字符串写入文件
				if (needwrite) { File.WriteAllText(filePath, jsonString); }
				return jsonString;
			}
			/// <summary>
			/// 反序列化指定路径的JSON文件为指定类型的对象。
			/// </summary>
			/// <typeparam name="T">要反序列化的目标类型。</typeparam>
			/// <param name="filePath">JSON文件的路径。</param>
			/// <returns>反序列化后的对象。</returns>
			/// <exception cref="FileNotFoundException">如果指定的文件不存在。</exception>
			/// <exception cref="JsonException">如果JSON内容无法反序列化为指定的类型。</exception>
			public static T DeserializeFromJson<T>(string filePath)
			{
				// 检查文件是否存在
				if (!File.Exists(filePath))
				{
					throw new FileNotFoundException($"The file '{filePath}' was not found.", filePath);
				}

				// 读取文件内容
				string jsonContent = File.ReadAllText(filePath);

				// 使用JsonConvert反序列化JSON字符串为指定类型的对象
				T deserializedObject = JsonConvert.DeserializeObject<T>(jsonContent);

				return deserializedObject;
			}
			/// <summary>
			/// 简单地从json文件中提取信息
			/// </summary>
			/// <param name="path">路径</param>
			/// <param name="param">要提取的参数信息</param>
			/// <returns></returns>
			public static string ReJson(string path, string param)
			{
				// 读取JSON文件内容
				string jsonContent = File.ReadAllText(path);

				// 解析JSON内容到JObject
				JObject jsonObject = JObject.Parse(jsonContent);

				// 提取信息
				return jsonObject[param].ToString();
			}
			/// <summary>
			/// 生成一段json字符串
			/// </summary>
			/// <param name="path">路径</param>
			/// <param name="headword">头信息</param>
			/// <param name="param">参数</param>
			/// <returns></returns>
			public static string SimpleToJson(string path, string headword, string param)
			{
				string jsonString = headword + "{:" + param + "}";

				var options = new JsonSerializerOptions
				{
					WriteIndented = true
				};

				string formattedJsonString = System.Text.Json.JsonSerializer.Serialize(JsonDocument.Parse(jsonString).RootElement, options);

				return formattedJsonString;
			}
			/// <summary>
			/// 将信息添加到json文件
			/// </summary>
			/// <param name="path">文件路径</param>
			/// <param name="headword">头信息</param>
			/// <param name="param">参数</param>
			public static void AddToJson(string path, string headword, string param)
			{
				AddTextToFile(path, SimpleToJson(path, headword, param));
			}
			/// <summary>
			/// 读取csv文件
			/// </summary>
			/// <param name="filePath"></param>
			/// <param name="split"></param>
			/// <returns></returns>
			public static List<string[]> ReadCsvFile(string filePath, char split)
			{
				var lines = new List<string[]>();

				try
				{
					using (StreamReader reader = new StreamReader(filePath))
					{
						string headerLine = reader.ReadLine(); // 读取标题行（可选）
															   // 如果需要处理标题行，可以在这里处理，比如打印出来或者保存到另一个变量中

						string line;
						while ((line = reader.ReadLine()) != null)
						{
							// 使用逗号作为分隔符拆分每行（注意：这不会处理包含逗号的数据字段）
							string[] values = line.Split(split);

							// 去除每个字段两端的空白字符（可选）
							for (int i = 0; i < values.Length; i++)
							{
								values[i] = values[i].Trim();
							}

							lines.Add(values);
						}
					}
				}
				catch (Exception ex)
				{

				}

				return lines;
			}
			/// <summary>
			/// 将内容写入CSV文件
			/// </summary>
			/// <param name="filePath">CSV文件的路径</param>
			/// <param name="data">要写入CSV文件的内容，每个字符串数组代表一行</param>
			public static void WriteToCsv(string filePath, List<string[]> data)
			{
				// 检查输入参数是否有效
				if (string.IsNullOrEmpty(filePath))
					throw new ArgumentNullException(nameof(filePath), "文件路径不能为空");
				if (data == null || data.Count == 0)
					throw new ArgumentNullException(nameof(data), "数据不能为空");

				// 使用StringBuilder来构建CSV内容
				StringBuilder csvContent = new StringBuilder();

				// 遍历数据列表，将每行写入StringBuilder
				foreach (var row in data)
				{
					// 使用逗号分隔每个单元格的内容，并对特殊字符进行转义（例如，逗号、换行符等）
					string rowContent = string.Join(",", Array.ConvertAll(row, cell => cell.Contains(",") || cell.Contains("\n") || cell.Contains("\r") || cell.Contains("\"") ? "\"" + cell.Replace("\"", "\"\"") + "\"" : cell));
					csvContent.AppendLine(rowContent);
				}

				// 将StringBuilder的内容写入文件
				File.WriteAllText(filePath, csvContent.ToString(), Encoding.UTF8);
			}
		}
	}
	/// <summary>
	/// 日志管理系统
	/// </summary>
	public class Log
	{
		private static List<LogEntry> Logs = new List<LogEntry>();
		public class LogEntry
		{
			public DateTime Timestamp { get; set; }
			public string Message { get; set; }
		}
		private static readonly string LogFilePath = "logs.json";
		/// <summary>
		/// 记录日志
		/// </summary>
		/// <param name="message">信息</param>
		/// <param name="path">本程序的路径</param>
		public static void rec(string message, string path)
		{
			List<LogEntry> logs = new List<LogEntry>();

			// 如果logs.json文件已经存在，则读取现有的日志条目
			if (File.Exists(LogFilePath))
			{
				string jsona = File.ReadAllText(LogFilePath);
				logs = JsonConvert.DeserializeObject<List<LogEntry>>(jsona);
			}

			// 添加新的日志条目
			logs.Add(new LogEntry
			{
				Timestamp = DateTime.Now,
				Message = "INFO：" + path + "：" + message,
			});

			// 将日志条目序列化为JSON字符串并写回文件
			string json = JsonConvert.SerializeObject(logs, Newtonsoft.Json.Formatting.Indented);
			File.WriteAllText(LogFilePath, json);

		}
		/// <summary>
		/// 记录日志
		/// </summary>
		/// <param name="message">信息</param>
		/// <param name="excutetime">执行所用的时间</param>
		/// <param name="path">路径</param>
		public static void rec(string message, int excutetime, string path)
		{
			rec(message + "：FinishedTimeSnap：" + excutetime, path);
		}
		/// <summary>
		/// 获取某一时间点的日志信息
		/// </summary>
		/// <param name="dt">时间点</param>
		/// <returns>日志信息</returns>
		public static string getlog(DateTime dt)
		{
			var specificTime = dt;
			LoadLogs();
			LogEntry logEntry = GetLogEntryAtTime(specificTime);
			if (logEntry != null)
			{
				return logEntry.Message + "：" + logEntry.Timestamp;
			}
			else
			{
				return "0";
			}
		}
		private static void LoadLogs()
		{
			// 如果logs.json文件已经存在，则读取现有的日志条目
			if (File.Exists(LogFilePath))
			{
				string json = File.ReadAllText(LogFilePath);
				Logs = JsonConvert.DeserializeObject<List<LogEntry>>(json);
			}
		}
		private static LogEntry GetLogEntryAtTime(DateTime time)
		{
			// 使用LINQ查询找到与时间点相匹配的日志条目（这里使用精确匹配，你可以根据需要调整）
			return Logs.FirstOrDefault(log => log.Timestamp == time);
		}
		/// <summary>
		/// 删除某个指定log
		/// </summary>
		/// <param name="dt">时间戳</param>
		public static void deletelog(DateTime dt)
		{
			RemoveLogEntryByTimestamp(dt);

			// 验证删除结果（可选）
			List<LogEntry> logs = ReadLogEntries();
			foreach (var log in logs)
			{
				Console.WriteLine($"Timestamp: {log.Timestamp}, Message: {log.Message}");
			}
		}
		private static void RemoveLogEntryByTimestamp(DateTime timestampToRemove)
		{
			List<LogEntry> logs = new List<LogEntry>();

			// 如果logs.json文件存在，则读取现有的日志条目
			if (File.Exists(LogFilePath))
			{
				string qjson = File.ReadAllText(LogFilePath);
				logs = JsonConvert.DeserializeObject<List<LogEntry>>(qjson);
			}

			// 移除与指定时间点匹配的日志条目
			logs = logs.Where(log => log.Timestamp != timestampToRemove).ToList();

			// 将更新后的日志条目序列化为JSON字符串并写回文件
			string json = JsonConvert.SerializeObject(logs, Newtonsoft.Json.Formatting.Indented);
			File.WriteAllText(LogFilePath, json);
		}
		private static List<LogEntry> ReadLogEntries()
		{
			List<LogEntry> logs = new List<LogEntry>();

			// 如果logs.json文件存在，则读取现有的日志条目
			if (File.Exists(LogFilePath))
			{
				string json = File.ReadAllText(LogFilePath);
				logs = JsonConvert.DeserializeObject<List<LogEntry>>(json);
			}

			return logs;
		}
		/// <summary>
		/// 读取日志中的条目
		/// </summary>
		/// <returns>返回日志列表</returns>
		/// <exception cref="FileNotFoundException"></exception>
		public static List<LogEntry> ReadLogs()
		{
			if (File.Exists("logs.json"))
			{
				string json = File.ReadAllText("logs.json");
				List<LogEntry> logs = JsonConvert.DeserializeObject<List<LogEntry>>(json);

				return logs;
			}
			else
			{
				throw new FileNotFoundException();
			}
		}
	}
	/// <summary>
	/// 关于互联网的一些相关操作
	/// </summary>
	public class Internet
	{
		/// <summary>
		/// 从Internet下载文件
		/// </summary>
		/// <param name="fileUrl">文件在网络上的路径</param>
		/// <param name="savePath">保存的路径</param>
		/// <returns>下载所用时间会被保存到"downloadinfo"中</returns>
		public static async Task DownloadFileAsync(string fileUrl, string savePath)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			using (HttpClient client = new HttpClient())
			{
				// 发送HTTP GET请求以获取文件
				HttpResponseMessage response = await client.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead);
				response.EnsureSuccessStatusCode(); // 确保请求成功

				// 获取响应的内容流
				using (Stream contentStream = await response.Content.ReadAsStreamAsync())
				using (Stream fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None))
				{
					// 将内容流复制到文件流
					await contentStream.CopyToAsync(fileStream);
				}
			}
			sw.Stop();
			TimeSpan ts = sw.Elapsed;
			if (File.Exists("downloadinfo"))
			{
				File.Delete("downloadinfo");
			}
			File.WriteAllText("downloadinfo", ts.TotalMilliseconds.ToString());
		}/// <summary>
		 /// 获取下载时长
		 /// </summary>
		 /// <returns>返回的下载时长。请用tryparse方法对返回值进行转化</returns>
		public static string GetDownloadInfo()
		{
			try
			{
				return IO.Text.Read("downloadinfo");
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
		/// <summary>
		/// 创建tcp服务端并监听
		/// </summary>
		/// <param name="ipadress">tcp地址</param>
		/// <param name="port">端口</param>
		/// <param name="messagereturn">回显发送信息</param>
		/// <returns>tcp获取的信息将会保存到"message(时间).msg"中，以中文冒号分隔每一行</returns>
		public static async Task TcpReceive(string ipadress, int port, string messagereturn)
		{
			TcpListener server = null;
			try
			{
				// 设置本地终结点
				IPAddress localAddr = IPAddress.Parse(ipadress);
				server = new TcpListener(localAddr, port);

				// 启动服务器监听
				server.Start();

				while (true)
				{
					// 接受客户端连接
					TcpClient client = await server.AcceptTcpClientAsync();

					// 读取客户端发送的消息
					NetworkStream stream = client.GetStream();
					byte[] buffer = new byte[256];
					int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
					string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
					IO.Text.AddTextToFile("message.msg", message + "：\n");

					// 发送回应消息给客户端
					byte[] msg = Encoding.UTF8.GetBytes(messagereturn);
					await stream.WriteAsync(msg, 0, msg.Length);

					// 关闭客户端连接
					client.Close();
				}
			}
			catch (SocketException e)
			{
				throw e;
			}
			finally
			{
				// 停止服务器监听
				server?.Stop();
			}
			return;
		}
		/// <summary>
		/// 获取tcp接收的消息
		/// </summary>
		/// <returns>消息列表</returns>
		public static List<string> TcpInfo()
		{
			List<string> list = new List<string>();
			string[] strs = IO.Text.ReadByLines("message.msg");
			foreach (string str in strs)
			{
				list.Add(str);
			}
			return list;
		}
		/// <summary>
		/// 清理昨天的msg文件，如果需要的话可以将此文件每日备份并重新命名
		/// </summary>
		/// <returns>true为成功，false为失败或没到时间</returns>
		/// <exception cref="FileNotFoundException">文件不存在</exception>
		public static bool ClearMsg()
		{
			string filePath = "message.msg"; // 请将此路径替换为实际的文件路径

			// 检查文件是否存在
			if (File.Exists(filePath))
			{
				// 获取文件的最后修改时间
				FileInfo fileInfo = new FileInfo(filePath);
				DateTime lastWriteTime = fileInfo.LastWriteTime;

				// 获取当前时间
				DateTime currentTime = DateTime.Now;

				// 计算时间差
				TimeSpan timeDifference = currentTime - lastWriteTime;

				// 检查时间差是否超过24小时
				if (timeDifference.TotalHours >= 24)
				{
					try
					{
						// 删除文件
						File.Delete(filePath);
						return true;
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
				else
				{
					return false;
				}
			}
			else
			{
				throw new FileNotFoundException();
			}
		}
		/// <summary>
		/// 设置一个tcp客户端
		/// </summary>
		/// <param name="ipadress">目标服务器地址</param>
		/// <param name="port">端口</param>
		/// <param name="message">要发送的消息</param>
		/// <returns></returns>
		public static async Task TcpClient(string ipadress, int port, string message)
		{
			try
			{
				// 设置服务器终结点
				string server = ipadress;
				TcpClient client = new TcpClient();

				// 连接到服务器
				await client.ConnectAsync(server, port);

				// 发送消息到服务器
				NetworkStream stream = client.GetStream();
				byte[] data = Encoding.UTF8.GetBytes(message);
				await stream.WriteAsync(data, 0, data.Length);

				// 接收服务器的回应消息
				byte[] buffer = new byte[256];
				int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
				string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

				// 关闭连接
				stream.Close();
				client.Close();
			}
			catch (ArgumentNullException e)
			{
				throw e;
			}
			catch (SocketException e)
			{
				throw e;
			}
		}
	}
	public static class Security
	{
		#region 加密字符串 

		/// <summary> /// 加密字符串  

		/// </summary> 

		/// <param name="str">要加密的字符串</param> 

		/// <returns>加密后的字符串</returns> 

		static string Encrypt(string str, string encryptKey)
		{
			DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象  



			byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥   



			byte[] data = Encoding.Unicode.GetBytes(str);//定义字节数组，用来存储要加密的字符串 



			MemoryStream MStream = new MemoryStream(); //实例化内存流对象     



			//使用内存流实例化加密流对象  

			CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);



			CStream.Write(data, 0, data.Length);  //向加密流中写入数据     



			CStream.FlushFinalBlock();              //释放加密流     



			return Convert.ToBase64String(MStream.ToArray());//返回加密后的字符串 

		}

		#endregion
		#region 解密字符串  

		/// <summary> 

		/// 解密字符串  

		/// </summary> 

		/// <param name="str">要解密的字符串</param> 

		/// <returns>解密后的字符串</returns> 

		static string Decrypt(string str, string encryptKey)

		{

			DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象   



			byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥   



			byte[] data = Convert.FromBase64String(str);//定义字节数组，用来存储要解密的字符串 



			MemoryStream MStream = new MemoryStream(); //实例化内存流对象     



			//使用内存流实例化解密流对象      

			CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);



			CStream.Write(data, 0, data.Length);      //向解密流中写入数据    



			CStream.FlushFinalBlock();               //释放解密流     



			return Encoding.Unicode.GetString(MStream.ToArray());       //返回解密后的字符串 

		}

		#endregion

	}
	/// <summary>
	/// 与外部程序有关的操作
	/// </summary>
	public static class Progress
	{
		/// <summary>
		/// 解析C#代码
		/// </summary>
		/// <param name="path">代码路径</param>
		public static void GetCSharpAnalyzed(string path)
		{
			try
			{
				string code = IO.Text.Read(path);

				SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
				SyntaxNode root = tree.GetRoot();

				var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

				foreach (var classDecl in classDeclarations)
				{
					Console.WriteLine($"Class: {classDecl.Identifier.Text}");

					var methodDeclarations = classDecl.DescendantNodes().OfType<MethodDeclarationSyntax>();
					foreach (var methodDecl in methodDeclarations)
					{
						Console.WriteLine($"  Method: {methodDecl.Identifier.Text}");
					}

					Console.WriteLine();
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		/// <summary>
		/// 等待
		/// </summary>
		/// <param name="Millionseconds">等待时间</param>
		public static void Held(int Millionseconds)
		{
			Thread.Sleep(Millionseconds);
		}
		/// <summary>
		/// 调用外部程序
		/// </summary>
		/// <param name="path">程序路径</param>
		public static void start(string path)
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo(path);
			Process.Start(processStartInfo);
		}
		/// <summary>
		/// 调用外部程序
		/// </summary>
		/// <param name="path">路径</param>
		/// <param name="runas">是否以管理员权限运行</param>
		public static void start(string path, bool runas)
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo(path);
			if (runas) { processStartInfo.Verb = "runas"; }
			Process.Start(processStartInfo);
		}
		/// <summary>
		/// 调用外部程序
		/// </summary>
		/// <param name="path">路径</param>
		/// <param name="param">参数</param>
		public static void start(string path, string param)
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo(path, param);
			Process.Start(processStartInfo);
		}
		/// <summary>
		/// 调用外部程序
		/// </summary>
		/// <param name="path">路径</param>
		/// <param name="runas">是否以管理员权限运行</param>
		/// <param name="param">参数</param>
		public static void start(string path, bool runas, string param)
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo(path, param);
			if (runas) { processStartInfo.Verb = "runas"; }
			Process.Start(processStartInfo);
		}
		/// <summary>
		/// 结束指定进程
		/// </summary>
		/// <param name="processname">进程名字（通常以可执行文件去掉后缀名构成）</param>
		public static void kill(string processname)
		{
			Process[] processes = Process.GetProcessesByName(processname);
			foreach (Process process in processes)
			{
				process.Kill();
			}
		}
	}
	/// <summary>
	/// 与压缩文件有关的操作
	/// </summary>
	public static class Zip
	{
		/// <summary>
		/// 解压文件
		/// </summary>
		/// <param name="zipPath">压缩包位置</param>
		/// <param name="extractPath">解压路径</param>
		/// <returns>是否成功</returns>
		/// <exception cref="FileNotFoundException">文件不存在</exception>
		public static bool Unzip(string zipPath,string extractPath)
		{
			// 确保ZIP文件存在
			if (File.Exists(zipPath))
			{
				// 解压ZIP文件
				ZipFile.ExtractToDirectory(zipPath, extractPath);
				return true;
			}
			else
			{
				throw new FileNotFoundException();
			}
		}
		/// <summary>
		/// 压缩目录到zip
		/// </summary>
		/// <param name="sourceDirectory">源目录</param>
		/// <param name="zipFilePath">压缩包位置</param>
		/// <returns>是否成功</returns>
		public static bool Tozip(string sourceDirectory, string zipFilePath)
		{
			

			using (FileStream zipToCreate = new FileStream(zipFilePath, FileMode.Create))
			using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create))
			{
				string[] files = Directory.GetFiles(sourceDirectory);

				foreach (string file in files)
				{
					string entryName = Path.GetRelativePath(sourceDirectory, file).Replace("\\", "/");
					ZipArchiveEntry readFileInArchive = archive.CreateEntryFromFile(file, entryName, CompressionLevel.Fastest);
				}

				return true;
			}
		}
	}
}

