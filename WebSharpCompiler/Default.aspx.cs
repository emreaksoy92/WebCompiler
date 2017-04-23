using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.CSharp;
using System.IO;
using System.Web.UI.WebControls;

namespace WebSharpCompiler
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void btnCompile_Click(object sender, EventArgs e)
        {           
            int counter = Convert.ToInt32(this.TextBox1.Text);

            lstCompilerOutput.Items.Clear();
            WebSharpCompilerBusiness.WebSharpCompiler compiler = new WebSharpCompilerBusiness.WebSharpCompiler();
          
            List<string> compilerErrors = compiler.CompileError(txtCode.Text);
            

            if (compilerErrors.Count == 0)
            {
                lstCompilerOutput.Items.Add("No Errors");
                
                string result = compiler.CompileResult(txtCode.Text);
                ResultOutput.Text = result;
                NextLine(counter);
                //NextCode(counter);                        
            }
            else {
                ResultOutput.Text = "error!, Check error output please !";
                foreach (string error in compilerErrors)
                {
                    lstCompilerOutput.Items.Add(error);
                }
            }
                           
        }
        public void NextLine(int i)
        {
            string CurrentLine;
            string Cevap;
            int LastLineNumber = i;
            
           StreamReader file = new StreamReader("C:\\Users\\Emre\\Desktop\\New folder\\WebSharpCompiler\\App_Data\\soru.txt");
           StreamReader file1 = new StreamReader("C:\\Users\\Emre\\Desktop\\New folder\\WebSharpCompiler\\App_Data\\cevap.txt");

            for (int c = i - 1; c < LastLineNumber; c++)
            {
                file.ReadLine();
                file1.ReadLine();
            }
            
                CurrentLine = file.ReadLine();            
                problemLbl.Text = CurrentLine.ToString();

                Cevap = file1.ReadLine();
                answerLbl.Text = Cevap.ToString();

                problemNo.Text = (LastLineNumber+1).ToString();
                LastLineNumber++;
          
        }

        public void NextCode(int i)
        {
            StreamReader file = new StreamReader("C:\\Users\\Emre\\Desktop\\New folder\\WebSharpCompiler\\App_Data\\code.txt");
            List<String> list = new List<string>();
            
            string line;

            while ((line = file.ReadLine()) != i.ToString())
            {
                list.Add(line);
                
            }
            txtCode.Text = list.ToString(); 
        }
        
        
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtCode.Text = string.Empty;
        }

        protected void NextQuestionBtn_Click(object sender, EventArgs e)
        {
            
            int counter = Convert.ToInt32(this.TextBox1.Text);

            if (answerLbl.Text == ResultOutput.Text)
            {
                checkLbl.Visible = true;
                checkLbl.Text = "Correct!";
                checkLbl.ForeColor = System.Drawing.Color.Green;
                counter++;
                TextBox1.Text = counter.ToString();
            }
            else
            {
                checkLbl.Visible = true;
                checkLbl.Text = "False!";
                checkLbl.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}
