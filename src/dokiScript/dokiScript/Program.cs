using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PerCederberg.Grammatica.Runtime;

namespace UnlimitedCodeWorks {
    class Program {
        class Analyzer : DokiScriptAnalyzer {

        }
   
        static void Main(string[] args)
        {
            DokiScriptParser parser = null;
            Node node = null;
            
            using (StreamReader reader = File.OpenText(@"H:\abc.txt")) {
                parser = new DokiScriptParser(reader, new Analyzer());
                node = parser.Parse();
            }

            return;
        }
    }
}
