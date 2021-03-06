﻿using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.CSharp;
using System.IO;
using System.Web.UI.WebControls;
using System.Xml;

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
                if(answerLbl.Text == ResultOutput.Text)
                {
                    checkLbl.Visible = true;
                    checkLbl.Text = "Correct!";
                    checkLbl.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    checkLbl.Visible = true;
                    checkLbl.Text = "False!";
                    checkLbl.ForeColor = System.Drawing.Color.Red;
                }
            }
            else {
                checkLbl.Visible = true;
                checkLbl.Text = "False!";
                checkLbl.ForeColor = System.Drawing.Color.Red;
                ResultOutput.Text = "Error!, Check error output please !";
                foreach (string error in compilerErrors)
                {
                    lstCompilerOutput.Items.Add(error);
                }
            }
                           
        }
        public void NextLine(int i)
        {
            string SoruLine ="";
            string CevapLine = "";
            int LastLineNo = i+1;

           StreamReader file = new StreamReader(Server.MapPath(@"~\App_Data\soru.txt"));
           StreamReader file1 = new StreamReader(Server.MapPath(@"~\App_Data\cevap.txt"));

            for (int c = 0; c<LastLineNo; c++)
            {
                SoruLine = file.ReadLine();
                CevapLine = file1.ReadLine();
            }
                             
                problemLbl.Text = SoruLine.ToString();
                answerLbl.Text = CevapLine.ToString();

                problemNo.Text = (i+1).ToString();
            LastLineNo++;
          
        }

        public void NextCode(int i)
        {
            
            XmlTextReader oku = new XmlTextReader(Server.MapPath(@"~\App_Data\code.xml"));

            string[] Cevap = new string[1];
            int c = 0;

            while (oku.Read())
            {
                if (oku.NodeType == XmlNodeType.Element)
                {
                    if (oku.Name == "c")
                    {
                        Cevap[c] = oku.ReadString().ToString();
                        c++;
                        Array.Resize<string>(ref Cevap, Cevap.Length + 1);
                    }
                }
            }

            oku.Close();
            if (Cevap[i] == null)
            {
                Array.Resize<string>(ref Cevap, Cevap.Length - 1);
            }
            txtCode.Text = Cevap[i].ToString();
        }
        
       

        protected void NextQuestionBtn_Click(object sender, EventArgs e)
        {
            
            int counter = Convert.ToInt32(this.TextBox1.Text);

            if (counter == 10)
            {
                Response.Redirect("About.aspx");
            }

            if (answerLbl.Text == ResultOutput.Text)
            {             
                counter++;
                TextBox1.Text = counter.ToString();
                NextLine(counter);
                NextCode(counter);
                ResultOutput.Text = "";
            }
            else
            {
               
            }
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                checkLbl.Visible = false;             
            }

        }
    }
}
