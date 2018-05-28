using imbSCI.Core.files.folders;
using imbSCI.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace imbSCI.Core.syntax.converter.core
{

    

    public class conversionRuleSet:List<conversionRule>
    {

        public conversionRule Add()
        {
            conversionRule rule = new conversionRule();
            Add(rule);
            return rule;
        }

        public void process()
        {
            var fileList = inputFolder.findFiles("*" + inputExtension, System.IO.SearchOption.AllDirectories);

            foreach (String fl in fileList) {

                String code = File.ReadAllText(fl);

                foreach (conversionRule r in this)
                {
                    if (r.multiline) code = r.ProcessLine(code);
                }

                List<String> codeLines = code.SplitSmart(Environment.NewLine, "",false, false);
           
                List<String> codeOutput = new List<string>();

                foreach (String l in codeLines) {

                    String lo = l;
                    foreach (conversionRule r in this)
                    {
                        if (!r.multiline)
                        {
                            lo = r.ProcessLine(lo);
                            
                        }
                    }
                    codeOutput.Add(lo);

                }

                String fn = Path.GetFileNameWithoutExtension(fl);

                String directoryInfo = fl.removeEndsWith(Path.GetFileName(fl));
                String dir = directoryInfo.removeStartsWith(inputFolder.path);

                var of = outputFolder.Add(dir, "", "");

                String op = of.pathFor(fn.add(outputExtension, "."), Data.enums.getWritableFileMode.newOrExisting);

                File.WriteAllLines(op, codeOutput);

            }


        }


        public conversionRuleSet(folderNode _in, folderNode _out)
        {
            inputFolder = _in;
            outputFolder = _out;
        }

        public String inputExtension { get; set; } = ".java";

        public String outputExtension { get; set; } = ".cs";

        public folderNode inputFolder { get; set; } 

        public folderNode outputFolder { get; set; } 


    }
}
