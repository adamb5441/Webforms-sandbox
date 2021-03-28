<%@ Page Title="List" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="List.aspx.vb" Inherits="Account_List" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:ListView ID="ListView1" runat="server" OnItemEditing="OnItemEditing" 
        OnItemCanceling="OnItemCanceling" OnItemUpdating="OnItemUpdating" GroupPlaceholderID="groupPlaceHolder1"
        ItemPlaceholderID="itemPlaceHolder1">
        <LayoutTemplate>
            <table cellpadding="2" cellspacing="0" border="1" style="width: 200px; border: dashed 2px #04AFEF;
                background-color: #B0E2F5">
                <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <GroupTemplate>
            <tr>
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
            </tr>
        </GroupTemplate>
        <ItemTemplate>
            <td>
                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
            </td>        
            <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
            </td>        
            <td>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
            </td>        
            <td>
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:Label>
            </td>
            <td>
                <asp:LinkButton href = '<%# Eval("Link") %>' ID="Button1" runat="server" Text='Update' />
            </td>
        </ItemTemplate>
        <EditItemTemplate>
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("UserName") %>' Visible="false"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("FirstName") %>' Visible="false"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label8" runat="server" Text='<%# Eval("LastName") %>' Visible="false"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label9" runat="server" Text='<%# Eval("Email") %>' Visible="false"></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label10" runat="server" Text='<%# Eval("PhoneNumber") %>' Visible="false"></asp:Label>
            </td>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>