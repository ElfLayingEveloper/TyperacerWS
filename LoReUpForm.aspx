<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoReUpForm.aspx.cs" Inherits="projectnewgadi.LoReUpForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="LoRepanel" runat="server">
            <h2>Login:</h2>
            Username:
            <asp:TextBox ID="UsernameL" runat="server" autocomplete="off" ></asp:TextBox>
            <br />
            Password:  
            <asp:TextBox ID="PasswordL" runat="server" autocomplete="off"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Loginbot" runat="server" Text="Login" OnClick="Loginbot_Click" />
             <br />
             <h2>Register:</h2>
            Username:
            <asp:TextBox ID="UsernameR" runat="server" autocomplete="off"></asp:TextBox>
            <br />
            Password:
            <asp:TextBox ID="PasswordR" runat="server" autocomplete="off"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Registerbot" runat="server" Text="Register" OnClick="Registerbot_Click"/>
            <br />
            <br />
            <asp:Label ID="ResultLabel" runat="server" Text=" "></asp:Label>
            </asp:Panel>

        </div>
    </form>
</body>
</html>
