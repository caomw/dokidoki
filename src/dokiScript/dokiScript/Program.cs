using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PerCederberg.Grammatica.Runtime;

namespace UnlimitedCodeWorks {
    public class Program {
        class Analyzer : DokiScriptAnalyzer {

        }
   
        static void Main(string[] args)
        {
            new Program().parse(@"H:\abc.txt");
        }

        public void parse(string path)
        {
            DokiScriptParser parser = null;
            Node node = null;
            
            using (StreamReader reader = File.OpenText(path)) {
                parser = new DokiScriptParser(reader, new Analyzer());
                node = parser.Parse();
            }

            return;
        }
    }
}
