<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebSharpCompiler._Default" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="height: 82px">

        <asp:Label ID="problemNo" runat="server" Text="Label">1</asp:Label>
        <br />
        <asp:Label ID="problemLbl" runat="server" Text="Label" TextMode="Multiline">Switch the code as shown below as you desired, which gives return function must give 5 as output!</asp:Label>
        

        <br />
        <asp:Label ID="answerLbl" runat="server" Text="Label" TextMode="Multiline" Visible="False"></asp:Label>

        <br />
        <asp:Label ID="checkLbl" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        <asp:Button ID="NextQuestionBtn" runat="server" OnClick="NextQuestionBtn_Click" Text="Next Question" style="height: 26px" />

    </div>
    <h2>Code</h2>
    <div style="margin-left: auto; margin-right: 17px; text-align: right; width: 112px; height: 3px; margin-top: 0px;">
    <asp:Label ID="Label2" runat="server" Text="Output"></asp:Label>
</div>
    <div style="margin-left: 0px; margin-right: auto; text-align: left; width: 112px;">
    <asp:Label ID="Label1" runat="server" Text="Input"></asp:Label>
</div>
    
    <p>
       
        <asp:TextBox ID="txtCode" runat="server" Height="400px" Width="49%" Style="text-align: left" TextMode="MultiLine">
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

    <asp:TextBox ID="ResultOutput" runat="server" Width="49%" TextMode="MultiLine" Style="text-align:right" Height="400px" ReadOnly="True"></asp:TextBox>
        
    </p>
    <p>
        <%--<asp:Button ID="btnCompile" runat="server" onclick="btnCompile_Click" Text="Compile"/>--%>
    </p>
        
    <h2>Error Output
    </h2>
    <p>
        
        <asp:ListBox ID="lstCompilerOutput" runat="server" Width="100%" Height="63px"></asp:ListBox>
        <asp:TextBox ID="TextBox1" runat="server" Visible="False">0</asp:TextBox>
    </p>
</asp:Content>
