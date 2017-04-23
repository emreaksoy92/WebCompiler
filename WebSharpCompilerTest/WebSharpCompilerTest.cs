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

            
            string programText= @"
                using System;
                using System.Collections.Generic;
                using System.Web;
                using System.Web.UI;
                using System.Web.UI.WebControls;
 
                namespace CodeCompile
                {
                public partial class _Default : System.Web.UI.Page
                {
                    protected void Page_Load(object sender, EventArgs e)
                    {
             
                    }
                    public int myFunc()
                    {
                        return 5;
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
                using System;
                using System.Collections.Generic;
                using System.Web;
                using System.Web.UI;
                using System.Web.UI.WebControls;
 
                namespace CodeCompile
                {
                public partial class _Default : System.Web.UI.Page
                {
                    protected void Page_Load(object sender, EventArgs e)
                    {
             
                    }
                    public int myFunc()
                    {
                        return 5;
                   }
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
                using System.Collections.Generic;
                using System.Web;
                using System.Web.UI;
                using System.Web.UI.WebControls;
 
                namespace CodeCompile
                {
                public partial class _Default : System.Web.UI.Page
                {
                    protected void Page_Load(object sender, EventArgs e)
                    {
             
                    }
                    public int myFunc()
                    {
                        return 5;
                   }
                }      
        }";

            List<string> compilerErrors = compiler.CompileError((programText));

            Assert.AreEqual(compilerErrors.Count, 0);
        }

    }
}
