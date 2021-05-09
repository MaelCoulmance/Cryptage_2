using System;
using System.IO;

namespace Cryptage.Commons
{
    public static class PathChecker
    {
        public static bool CorrectPath(string arg)
        {
            // A correct relative path looks like this :
            // "./file.txt" or "./file.txt/"
            // "./folder/file.txt or ./folder/file.txt"
            // "./folder1/folder2/file.txt" or "./folder1/folder2/file.txt/"
            // etc...
            
            // A correct absolute path looks like this :
            // "c:\Users\Philibert\Documents\file.txt"

            if (arg == "")
                return false;
            
            if (!(arg.EndsWith(".txt") || arg.EndsWith(".txt/") || arg.EndsWith(".txt\\")))
                return false;

            if (!(arg.StartsWith("./") || arg.StartsWith("C:\\")))
                return false;

            string[] tmp = arg.Split("\\");
            string[] tmp2 = arg.Split("/");

            if (tmp.Length < 2 && tmp2.Length < 2)
                return false;

            return true;
        }
        
        public static bool CorrectFileName(string arg)
        {
            // A correct file name looks like this:
            // file.txt
            // Example of incorrect file names:
            // fi.le.txt
            // fi/le.txt
            // file.jpg
            // file.txt.
            // etc...

            if (!arg.EndsWith(".txt"))
                return false;

            string[] tmp = arg.Split(".");
            return tmp.Length == 2;  // With the Split methods, which should have string[] tmp = {"file";"txt"}
        }
        
        public static bool ExistingFile(string arg)
        {
            try
            {
                StreamReader file = new StreamReader(arg);
                file.Read();
                file.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static bool CheckPath(string path, string mode)
        {
            if (mode == "in")
            {
                if (!ExistingFile(path))
                    return false;
                else
                    return true;
            }
            else if (mode == "out")
            {
                if (!CorrectPath(path))
                    return false;

                string[] tmp = path.Split("/");
                string[] tmp2 = path.Split("\\");
                string name = tmp[^1];
                string name2 = tmp2[^1];

                bool test1 = CorrectFileName(name);
                bool test2 = CorrectFileName(name2);

                return test1 || test2;
            }
            else
            {
                throw new ArgumentException("'mode' should be 'in' or 'out'", nameof(mode));
            }
        }
    }
}