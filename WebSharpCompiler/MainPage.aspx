<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebSharpCompiler.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Learn Web Programing</title>
    <link href="bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap-3.3.7-dist/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="bootstrap-3.3.7-dist/js/jquery-3.1.1.min.js"></script>
    <script src="bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    <link href="bootstrap-3.3.7-dist/StyleSheet.css" rel="stylesheet" />

</head>
<body>
      
   
    <form id="form1" runat="server">
         <asp:scriptmanager runat="server"></asp:scriptmanager>                 
    <div>     
        <div class="container pad0">

            <div class="row">

                <div class="row">
                      <div class="col-md-12 QuestionBox">
                         
                          <div class="col-md-1 sorusayisibox">
                                <asp:Label ID="problemNo" runat="server" Text="1" CssClass="sorusayi">1</asp:Label>
                            </div>

                            <div class="col-md-11 ">
                                <asp:Label ID="problemLbl" runat="server" Text="Label" CssClass="sorular col-md-12 margintop40">Switch the code as shown below as you desired, which gives return function must give 5 as output!</asp:Label>
                            </div>        
                      </div>
                </div>
            </div>
            <br />
            <asp:Label ID="answerLbl" runat="server" Text="Label" TextMode="Multiline" Visible="False"></asp:Label>

            <br />
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            <div class="row" >           
                <div class="col-md-12 push26"></div>
            </div>  

            <div class="row" >           
                <div class="col-md-9 push50">
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                     <ContentTemplate>
                               <asp:Button ID="hintButton"  runat="server" Text="Hint" CssClass="btn-warning  hintbutton" OnClick="hintButton_Click" />
                               <asp:Label ID="checkLbl" runat="server" Text="Label" Visible="False" CssClass="hintText"></asp:Label>
                
                     </ContentTemplate>      
                               </asp:UpdatePanel>
                     
                </div>

                <div class="col-md-3 push50">
                     
                               <asp:Button ID="nextButton"  runat="server" Text="Next" CssClass="btn btn-success btn-lg btn-block" OnClick="nextButton_Click" Width="275px"  />
                    
                </div>
            </div>
         
               <div class="row">                             
                        <div class="col-md-6 box pad20 ">
                            <div class="row">
                                <div class="col-md-12 innerBox" style="position:relative">                        
                                    	<div id="html" class="content" contenteditable="true" runat="server" >    
                                            <asp:TextBox ID="txtCode" runat="server" Height="534px" Width="95%" Style="text-align: left" TextMode="MultiLine">
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
 }           
</asp:TextBox>
                                    	</div>                               
                                          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                     <ContentTemplate>
                                        <div id="html1" class="content html1"  contenteditable="true" runat="server" visible="false">
                                        </div>
                                  </ContentTemplate>      
                               </asp:UpdatePanel>                                
                                </div>                            
                            </div>                         
                        </div>
                         
                        <div  class="col-md-6 box pad20">

                            <div class="row">
                                <div class="col-md-12 innerBox">
                                    <asp:TextBox ID="ResultOutput" runat="server" Width="95%" TextMode="MultiLine" Height="502px" ReadOnly="True"></asp:TextBox>
                                    <asp:ListBox ID="lstCompilerOutput" runat="server" Width="100%" Height="63px"></asp:ListBox>
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="False">0</asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                         <div class="row">
                <div class="col-md-12 push50"></div>
                 </div>
      	
                                     <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                     <ContentTemplate>
              <div class="row">
                  
                     
                <div class=" col-md-3">
                    
                    <button id="runButton" type="button"  class="btn btn-success btn-lg btn-block" onclick="answerButton_Click" runat="server">RUN</button>
                    

                                     
                </div>
                 <div class=" col-md-3"></div>
                 <div class=" col-md-3"></div>
                 <div class="col-md-3 right">

                      
                     <asp:Button ID="answerButton" runat="server" Text="See Answer"  CssClass="btn-danger btn-lg resultbutton" OnClick="answerButton_Click" />
      
                 </div>

                </div>
          </ContentTemplate>      
             </asp:UpdatePanel>
               </div>  
      </div>

    </form>

       
</body>
</html>

<%--<script>
    function compile(x) {
        var temp;
        if (x == 0)
        {
           temp = "html";
        } else
        {
            temp = "html1";
        }       
            var html = document.getElementById(temp).textContent,
                output = document.getElementById("iframe"),
                js="";
         

            var start = html.search("<script>");
           
            var end = html.lastIndexOf("script>");

            if (start >= 0 && end >= 0) {
                for(var i=start+8;i<end-2;i++)
                {
                    js += html[i];
                 
                }
            }
     
            working = false,
            fill=function() {
                if (working) {
                    return false;
                }
                working = true;
                var document = iframe.contentDocument,
                    script = document.createElement("script");

              

                script.innerHTML = js;
                document.body.innerHTML = html;
                document.body.appendChild(script);
                working = false;
            };
        fill.apply();
    }
</script>--%>
