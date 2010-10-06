<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<AdvancedMVC2.Models.NewUserModel>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
 <% Html.EnableClientValidation(); %>
 <%=Html.ValidationSummary() %>
 <%
    Html.BeginForm(); %>
<form method="post" action="AddUser">
<%=Html.EditorForModel() %>
<button type="submit">Submit</button>
<%Html.EndForm(); %>
</asp:Content>
