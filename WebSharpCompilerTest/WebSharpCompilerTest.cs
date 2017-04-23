using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSharpCompilerBusiness;//Enable us to test the business object

namespace WebSharpCompilerTest
{
    [TestClass]
    public class WebSharpCompilerTest
    {
        [TestMethod]
        public void TestCompilerNotNull()
        {
            WebSharpCompiler compiler = new WebSharpCompiler();
            Assert.IsNotNull(compiler.CompileError(""));
        }

        [TestMethod]
        public void TestCompilerSingleError()
        {
            WebSharpCompiler compiler = new WebSharpCompiler();

            // REVIEW MATT : Updated to be more readable.
            string programText= @"
                using **** System;

                namespace HelloWorld
                {
                    class HelloWorldClass
                    {
                        static void Main(string[] args)
                        {
                            Console.ReadLine();
                        }
                    }
                }";

            List<string> compilerErrors = compiler.CompileError(programText);

            Assert.AreEqual(compilerErrors.Count, 1);
        }

        [TestMethod]
        public void TestCompilerFiveErrors()
        {
            WebSharpCompiler compiler = new WebSharpCompiler();

           
            string programText = @"
                using **** System;

                namesp8ce HelloWorld
                {
                    clas HelloWorldClass
                    {
                        static void Main(string[] args)
                        {
                            Console.ReadLine();
                        }
                    }";

            List<string> compilerErrors = compiler.CompileError(programText);

            Assert.AreEqual(compilerErrors.Count, 5);
        }

        [TestMethod]
        public void TestCompilerSuccessfulCompilation()
        {
            WebSharpCompiler compiler = new WebSharpCompiler();

            
            string programText = @"
                using System;

                namespace HelloWorld
                {
                    class HelloWorldClass
                    {
                        static void Main(string[] args)
                        {
                            Console.ReadLine();
                        }
                    }
                }";

            List<string> compilerErrors = compiler.CompileError((programText));

            Assert.AreEqual(compilerErrors.Count, 0);
        }

    }
}
