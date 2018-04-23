<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GetSelectedValuesAllColumns._Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v8.2, Version=8.2.4.0, Culture=neutral, PublicKeyToken=9b171c9fd64da1d1"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.2, Version=8.2.4.0, Culture=neutral, PublicKeyToken=9b171c9fd64da1d1"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server">
        </dxwgv:ASPxGridView>
        <dxe:ASPxButton ID="ASPxButton1" runat="server" OnClick="ASPxButton1_Click" Text="Get Selected Values">
        </dxe:ASPxButton>
    </div>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </form>
</body>
</html>
