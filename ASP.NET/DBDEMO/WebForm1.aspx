<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DBDEMO.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvEmp" runat="server" OnSelectedIndexChanged="gvEmp_SelectedIndexChanged" />
            <br />
            EMP_ID: <asp:TextBox ID="txtid" runat="server" />
            <br />
            EMP_NAME: <asp:TextBox ID="txtname" runat="server" />
             <br />
            EMP_CITY: <asp:TextBox ID="txtcity" runat="server" />
             <br />
           EMP_SALARY: <asp:TextBox ID="txtsalary" runat="server" />
             <br />
            <asp:Button ID="btninsert" runat="server" Text="Insert" OnClick="btninsert_Click" />
            <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Clik" />
            <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" />
            <asp:Button ID="btnselect" runat="server" Text="Display" OnClick="btnselect_Click"  />
        </div>
    </form>
</body>
</html>
