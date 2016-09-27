using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace StardewValleySaveFix
{
    class Program
    {
        static T UserChoose<T>(IEnumerable<T> list, Func<T, String> descriptionGetter) {
            for (var i = 0; i < list.Count(); i++)
            {
                Console.WriteLine("{0} - {1}", i + 1, descriptionGetter(list.ElementAt(i)));
            }

            Console.Write("> ");
            int idx = Convert.ToInt32(Console.ReadLine());

            return list.ElementAt(idx - 1);
        } //Tela inicial, mostra os saves

        static void ConvertSave(Dictionary<String, String> convertMap)
        {
            var appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var savesDir = Path.Combine(appDataDir, "StardewValley\\Saves");

            var saves = Directory.GetDirectories(savesDir)
                .Select(p => Path.Combine(p, new DirectoryInfo(p).Name))
                .Where(p => File.Exists(p))
                .OrderByDescending(p => File.GetLastWriteTime(p));
            Console.WriteLine("Stardew Valley SaveFix | LeanZo e Kratscheky | Source cedida por Draivin     2.0");
            Console.WriteLine();
            Console.WriteLine("Escolha um save para aplicar a correção:");
            var save = UserChoose(saves, p => new DirectoryInfo(p).Name);

            File.Copy(save, Path.ChangeExtension(save, ".bak"), true);

            XDocument doc = XDocument.Load(save);
            var leaves =
                from e in doc.Descendants()
                where !e.Elements().Any()
                select e;
         
            foreach(var leaf in leaves)
            {
                var value = leaf.Value;
                while(convertMap.ContainsKey(value))
                {
                    value = convertMap[value];
                }

                leaf.Value = value;
            }

            doc.Save(save);

            Console.WriteLine();
            Console.WriteLine("Substituindo caracteres 0/2...");

            string text = File.ReadAllText(save);
            text = text.Replace('é', 'e');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('É', 'E');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Á', 'A');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('á', 'a');
            File.WriteAllText(save, text);
            
            text = File.ReadAllText(save);
            text = text.Replace('À', 'A');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('à', 'a');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Ã', 'A');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('ã', 'a');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Â', 'A');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('â', 'a');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Ê', 'E');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('ê', 'e');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Í', 'I');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('í', 'i');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Ó', 'O');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('ó', 'o');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Ô', 'O');
            File.WriteAllText(save, text);
            Console.WriteLine("...");
            text = File.ReadAllText(save);
            text = text.Replace('ô', 'o');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Õ', 'O');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('õ', 'o');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Ú', 'U');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('ú', 'u');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('Ç', 'C');
            File.WriteAllText(save, text);

            text = File.ReadAllText(save);
            text = text.Replace('ç', 'c');
            File.WriteAllText(save, text);

            Console.WriteLine("Substituindo caracteres 1/2...");

            var savegameinfodir = new FileInfo(save).Directory.FullName;
            var savegameinfo = Path.Combine(savegameinfodir, "SaveGameInfo");

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('é', 'e');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('É', 'E');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Á', 'A');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('á', 'a');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('À', 'A');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('à', 'a');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Ã', 'A');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('ã', 'a');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Â', 'A');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('â', 'a');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Ê', 'E');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('ê', 'e');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Í', 'I');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('í', 'i');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Ó', 'O');
            File.WriteAllText(savegameinfo, text);
            Console.WriteLine("...");
            text = File.ReadAllText(savegameinfo);
            text = text.Replace('ó', 'o');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Ô', 'O');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('ô', 'o');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Õ', 'O');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('õ', 'o');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Ú', 'U');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('ú', 'u');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('Ç', 'C');
            File.WriteAllText(savegameinfo, text);

            text = File.ReadAllText(savegameinfo);
            text = text.Replace('ç', 'c');
            File.WriteAllText(savegameinfo, text);

            Console.WriteLine("Substituindo caracteres 2/2...");
            Console.WriteLine();
            Console.WriteLine("Correção concluida");
            Console.WriteLine();
        } //Responsavel por realizar a conversao do save

        static void Main(string[] args)
        {
            FileStream stream;

            try
            {
                stream = new FileStream("update-table.json", FileMode.Open, FileAccess.Read);
            }
            catch (IOException)
            {
                Console.WriteLine("Arquivo update-table.json não foi encontrado");
                return;
            }

            var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            reader.Close();

            Dictionary<string, string> conversions = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            var running = true;
            while(running)
            {
                ConvertSave(conversions);
                Console.Write("Obrigado por usar! Quer corrigir outro save(s/n)? ");
                running = Console.ReadLine() == "s";
            }
        } //funcionamento do codigo em si
    }
}
