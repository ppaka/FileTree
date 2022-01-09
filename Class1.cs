using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTree
{
    public static class Class1
    {
        public static void Process(string path, string pattern)
        {
            var patternList = new List<string>();

            if (pattern != string.Empty)
            {
                var patterns = pattern.Split(',');
                foreach (var patStr in patterns)
                {
                    var str = "." + patStr.Trim();
                    patternList.Add(str);
                }
            }

            var results = new List<string>();

            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();

            foreach (var process in patternList)
            {
                var result1 = files.Where(result => result.EndsWith(process));
                foreach (var file in result1)
                {
                    results.Add(file);
                }
            }

            if (pattern == string.Empty)
            {
                results = files;
            }

            results.Sort();

            StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\result.txt");

            foreach (var file in results)
            {
                var filePath = file.Replace(path + "\\", "");
                writer.WriteLine(filePath);
            }

            writer.Close();
        }

        public static void ShowResult()
        {
            if(File.Exists(Directory.GetCurrentDirectory() + @"\result.txt"))
            {
                System.Diagnostics.Process.Start("notepad.exe", Path.GetFullPath(Directory.GetCurrentDirectory() + @"\result.txt"));
            }
            else
            {
                SystemSounds.Beep.Play();
                MessageBox.Show(Path.GetFullPath(Directory.GetCurrentDirectory() + @"\result.txt") + " 가 존재하지 않습니다." + "\n폴더를 선택하여 작업을 완료해주세요.");
            }
        }
    }
}