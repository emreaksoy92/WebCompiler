using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.CSharp;

namespace WebSharpCompilerBusiness
{
    public class WebSharpCompiler
    {
        public List<string> CompileError(string programText)
        {
            List<string> messages = new List<string>();
            if (String.IsNullOrEmpty(programText))
            {
                messages.Add("program text cannot be null or empty");
            }

            CompilerResults compilerErrors = ProcessCompilation(programText);
            

            foreach (CompilerError error in compilerErrors.Errors)
            {
                messages.Add(String.Format("Line {0} Error No:{1} - {2}", error.Line, error.ErrorNumber, error.ErrorText));
            }           

            return messages;         

        }

        public string CompileResult(string programText)
        {
            CompilerResults compilerResult = ProcessCompilation(programText);

            Assembly objAssembly = compilerResult.CompiledAssembly;
            object objHelloWorld = objAssembly.CreateInstance("CodeCompile._Default");
            MethodInfo objMI = objHelloWorld.GetType().GetMethod("myFunc");
            string result = objMI.Invoke(objHelloWorld, null).ToString();

            if (String.IsNullOrEmpty(programText))
            {
                return result ="program text cannot be null or empty";
            }
            else
            {
                return result;
            }
            

        }

        public CompilerResults ProcessCompilation(string programText)
        {
            CodeDomProvider codeDomProvider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters parameters = new CompilerParameters();
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Web.dll");
            parameters.ReferencedAssemblies.Add("System.Data.dll");
            parameters.ReferencedAssemblies.Add("System.Xml.dll");
            parameters.ReferencedAssemblies.Add("mscorlib.dll");
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = true;
            System.Collections.Specialized.StringCollection assemblies = new System.Collections.Specialized.StringCollection();

            CompilerResults cr = codeDomProvider.CompileAssemblyFromSource(parameters, programText);
            return cr;
        }

      
    }
}
