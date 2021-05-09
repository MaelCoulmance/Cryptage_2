#nullable enable 

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Cryptage.Visual;


namespace Cryptage.Commons.Util.Generic
{
    public static class FileManager
    {
        public static List<string> ReadFile(string path, string? separator = null)
        {
            if (path.Equals("") || !path.EndsWith(".txt"))
                throw new ArgumentException("Incorrect file path", nameof(path));

            List<string> res = new List<string>();

            try
            {
                StreamReader file = new StreamReader(path);

                string[] data = (separator is not null)
                    ? file.ReadToEnd().Split(separator)
                    : file.ReadToEnd().Split(" ");

                res.AddRange(data);

                file.Close();
            }
            catch (Exception e)
            {
                Error err = new Error("Erreur le fichier source entré est introuvable.",
                    path,
                    "Exception in function FileManager.ReadFile: \n" + e.Message);
                MainWindow.Error = err;
            } 

            return res;
        }
        
        
        public static void WriteFile(string path, string? wordSeparator, int? lineSeparator, List<string> arg)
        {
            if (path.Equals("") || !path.EndsWith(".txt"))
                throw new ArgumentException("Incorrect file path", nameof(path));

            if (lineSeparator < 0)
                throw new ArgumentOutOfRangeException(nameof(lineSeparator), "Line separator cannot be negative");

            try
            {
                StreamWriter file = new StreamWriter(path);

                for (int i = 0, j = 1; i < arg.Count; i++, j++)
                {
                    file.Write(arg[i]);
                    if (wordSeparator is not null)
                        file.Write(wordSeparator);
                    else 
                        file.Write(" ");

                    if (j == lineSeparator)
                    {
                        file.WriteLine(" ");
                        j = 0;
                    } else if (lineSeparator is null) 
                        file.WriteLine("");
                }
                
                file.Close();
            }
            catch (Exception e)
            {
                Error err = new Error($"A problem occurs while writing in file {path}",
                    nameof(WriteFile),
                    e.Message);
                MainWindow.Error = err;
            }
        }
        
        public static void WriteFileWithOriginalText(string path, string? wordSeparatorCode,
            string? wordSeparatorSource, int? lineSeparatorCode, int? lineSeparatorSource, List<string> argCode,
            List<string> argSource)
        {
            if (path.Equals("") || !path.EndsWith(".txt"))
                throw new ArgumentException("Incorrect file path", nameof(path));

            if (lineSeparatorCode < 0 || lineSeparatorSource < 0)
                throw new ArgumentOutOfRangeException(
                    (lineSeparatorCode < 0) ? nameof(lineSeparatorCode) : nameof(lineSeparatorSource),
                    "Line separator cannot be negative");

            try
            {
                StreamWriter file = new StreamWriter(path);

                file.WriteLine("Texte source :");
                file.WriteLine(" ");

                for (int i = 0, j = 1; i < argSource.Count; i++, j++)
                {
                    file.Write(argSource[i]);
                    if (wordSeparatorSource is not null)
                        file.Write(wordSeparatorSource);
                    else 
                        file.Write(" ");

                    if (j == lineSeparatorSource)
                    {
                        file.WriteLine(" ");
                        j = 0;
                    }
                    else if (lineSeparatorSource is null)
                    {
                        file.WriteLine(" ");
                    }
                }

                file.WriteLine(" ");
                file.WriteLine("################################################################################");
                file.WriteLine(" ");
                file.WriteLine("Texte crypté:");
                file.WriteLine(" ");
                
                for (int i = 0, j = 1; i < argCode.Count; i++, j++)
                {
                    file.Write(argCode[i]);
                    if (wordSeparatorCode is not null)
                        file.Write(wordSeparatorCode);
                    else 
                        file.Write(" ");

                    if (j == lineSeparatorCode)
                    {
                        file.WriteLine(" ");
                        j = 0;
                    }
                    else if (lineSeparatorCode is null)
                    {
                        file.WriteLine(" ");
                    }
                }

                file.Close();
            }
            catch (Exception e)
            {
                Error err = new Error($"A problem occurs while writing in file {path}",
                    nameof(WriteFileWithOriginalText),
                    e.Message);
                MainWindow.Error = err;
            }
        }
    }
}