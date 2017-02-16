/*
 * Created by SharpDevelop.
 * User: aZuZu
 * Date: 23.11.2015.
 * Time: 18:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace aCPIO_PUT
{
	class Program
	{
		/*
		#define C_IRUSR		000400
		#define C_IWUSR		000200
		#define C_IXUSR		000100
		#define C_IRGRP		000040
		#define C_IWGRP		000020
		#define C_IXGRP		000010
		#define C_IROTH		000004
		#define C_IWOTH		000002
		#define C_IXOTH		000001
		
		#define C_ISUID		004000
		#define C_ISGID		002000
		#define C_ISVTX		001000
		
		#define C_ISBLK		060000
		#define C_ISCHR		020000
		#define C_ISDIR		040000
		#define C_ISFIFO	010000
		#define C_ISSOCK	0140000
		#define C_ISLNK		0120000
		#define C_ISCTG		0110000
		#define C_ISREG		0100000
		*/
		public struct CPIO_File_H
		{
			private static char[] c_magic = new char[6];
			private static char[] c_ino = new char[8];
			private static char[] c_mode= new char[8];
			private static char[] c_uid = new char[8];
			private static char[] c_gid = new char[8];
			private static char[] c_nlink = new char[8];
			private static char[] c_mtime = new char[8];
			private static char[] c_filesize = new char[8];
			private static char[] c_devmajor = new char[8];
			private static char[] c_devminor = new char[8];
			private static char[] c_rdevmajor = new char[8];
			private static char[] c_rdevminor = new char[8];
			private static char[] c_namesize = new char[8];
			private static char[] c_checksum = new char[8];

			public char[] c_magic_gs
			{
				set
				{
					c_magic = value;
				}
				get
				{
					return c_magic;
				}
			}
			public char[] c_ino_gs
			{
				set
				{
					c_ino = value;
				}
				get
				{
					return c_ino;
				}
			}
			public char[] c_mode_gs
			{
				set
				{
					c_mode = value;
				}
				get
				{
					return c_mode;
				}
			}
			public char[] c_uid_gs
			{
				set
				{
					c_uid = value;
				}
				get
				{
					return c_uid;
				}
			}
			public char[] c_gid_gs
			{
				set
				{
					c_gid = value;
				}
				get
				{
					return c_gid;
				}
			}
			public char[] c_nlink_gs
			{
				set
				{
					c_nlink = value;
				}
				get
				{
					return c_nlink;
				}
			}
			public char[] c_mtime_gs
			{
				set
				{
					c_mtime = value;
				}
				get
				{
					return c_mtime;
				}
			}
			public char[] c_filesize_gs
			{
				set
				{
					c_filesize = value;
				}
				get
				{
					return c_filesize;
				}
			}
			public char[] c_devmajor_gs
			{
				set
				{
					c_devmajor = value;
				}
				get
				{
					return c_devmajor;
				}
			}
			public char[] c_devminor_gs
			{
				set
				{
					c_devminor = value;
				}
				get
				{
					return c_devminor;
				}
			}
			public char[] c_rdevmajor_gs
			{
				set
				{
					c_rdevmajor = value;
				}
				get
				{
					return c_rdevmajor;
				}
			}
			public char[] c_rdevminor_gs
			{
				set
				{
					c_rdevminor = value;
				}
				get
				{
					return c_rdevminor;
				}
			}
			public char[] c_namesize_gs
			{
				set
				{
					c_namesize = value;
				}
				get
				{
					return c_namesize;
				}
			}
			public char[] c_checksum_gs
			{
				set
				{
					c_checksum = value;
				}
				get
				{
					return c_checksum;
				}
			}
		}
		public static CPIO_File_H CPIO_File_Header = new CPIO_File_H();
      	public static int Chars2Int( char[] Data )
      	{
      		string Tmp = new string(Data);
      		return int.Parse(Tmp, NumberStyles.AllowHexSpecifier);
      	}
      	public static void Fill_Struct(char[] CPIO_File_Info_Data)
		{

			CPIO_File_Header.c_magic_gs = CPIO_File_Info_Data.Take(6).ToArray();
			CPIO_File_Header.c_ino_gs = CPIO_File_Info_Data.Skip(6).Take(8).ToArray();
			CPIO_File_Header.c_mode_gs = CPIO_File_Info_Data.Skip(14).Take(8).ToArray();
			CPIO_File_Header.c_uid_gs = CPIO_File_Info_Data.Skip(22).Take(8).ToArray();
			CPIO_File_Header.c_gid_gs = CPIO_File_Info_Data.Skip(30).Take(8).ToArray();
			CPIO_File_Header.c_nlink_gs = CPIO_File_Info_Data.Skip(38).Take(8).ToArray();
			CPIO_File_Header.c_mtime_gs = CPIO_File_Info_Data.Skip(46).Take(8).ToArray();
			CPIO_File_Header.c_filesize_gs = CPIO_File_Info_Data.Skip(54).Take(8).ToArray();
			CPIO_File_Header.c_devmajor_gs = CPIO_File_Info_Data.Skip(62).Take(8).ToArray();
			CPIO_File_Header.c_devminor_gs = CPIO_File_Info_Data.Skip(70).Take(8).ToArray();
			CPIO_File_Header.c_rdevmajor_gs = CPIO_File_Info_Data.Skip(78).Take(8).ToArray();
			CPIO_File_Header.c_rdevminor_gs = CPIO_File_Info_Data.Skip(86).Take(8).ToArray();
			CPIO_File_Header.c_namesize_gs = CPIO_File_Info_Data.Skip(94).Take(8).ToArray();
			CPIO_File_Header.c_checksum_gs = CPIO_File_Info_Data.Skip(102).Take(8).ToArray();
		}
		public static int C_Padding (int CPIO_Part) 
		{
			if ( (CPIO_Part % 4) == 0)
        		return 0;
			return 4 - (CPIO_Part % 4);		    
		}
        public static int ByteIndexOf(byte[] Where, byte[] What, int Start)
        {
			bool matched = false;
            for (int index = Start; index <= Where.Length - What.Length; ++index)
            {
             	matched = true;
           		for (int subIndex = 0; subIndex < What.Length; ++subIndex)
                {
                	if (What[subIndex] != Where[index + subIndex])
                 	{
                  		matched = false;
                  		break;
               		}
                }
                if (matched)
                {
                   	return index;
                }
         	}
           	return -1;
        }		
		public static void CPIO_UnPack(string What, string Where)
		{
			byte[] File_CPIO = File.ReadAllBytes(What);
			byte[] Magic = Encoding.ASCII.GetBytes("070701");
			byte[] Trailer = Encoding.ASCII.GetBytes("TRAILER!!!");
			if ( !Directory.Exists(Where) )
			{
				Directory.CreateDirectory(Where);
			}
			int file_idx = 0;
			while ( file_idx < File_CPIO.Length)
			{
				file_idx = ByteIndexOf(File_CPIO, Magic, file_idx + 110);
				Fill_Struct(Encoding.ASCII.GetChars(File_CPIO.Skip(file_idx).Take(110).ToArray()));
				string FileName = Encoding.ASCII.GetString(File_CPIO.Skip(file_idx + 110).Take(Chars2Int(CPIO_File_Header.c_namesize_gs) - 1).ToArray()).Replace("/", "\\");
				if ( FileName == Encoding.ASCII.GetString(Trailer) )
					break;				
				if ( Chars2Int(CPIO_File_Header.c_filesize_gs) == 0 )
				{
				 	new DirectoryInfo(Where + "\\" + FileName).Create();
				}
				if ( Chars2Int(CPIO_File_Header.c_filesize_gs) > 0 )
				{
					byte[] File_Data = File_CPIO.Skip(file_idx + 110 + FileName.Length + C_Padding(file_idx + 110 + FileName.Length)).Take(Chars2Int(CPIO_File_Header.c_filesize_gs)).ToArray();
					File.WriteAllBytes(Where + "\\" + FileName, File_Data);
				}
				Console.WriteLine("Extracting: " + Where + "\\" + FileName);
			}
		}
		public static void Main(string[] args)
		{
			if ( args.Length < 2 )
			{
				Console.WriteLine("aCPIO UnPack Tool, v1.02.3. (c) aZuZu. 2015.");
				Console.WriteLine(Environment.NewLine);
				Console.WriteLine("usage aCPIO_PUT [ cpio archive name ] [ directory where to unpack ]");
			} else {
				CPIO_UnPack(args[0], args[1]);
			}
		}
	}
}

