<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Book_AuthorEdit.aspx.cs" Inherits="Book_AuthorEdit" Title="Book_Author Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Book Author - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Book_ID, Author_ID" runat="server" DataSourceID="Book_AuthorDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/Book_AuthorFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/Book_AuthorFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Book_Author not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:Book_AuthorDataSource ID="Book_AuthorDataSource" runat="server"
			SelectMethod="GetByBook_IDAuthor_ID"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Book_ID" QueryStringField="Book_ID" Type="String" />
<asp:QueryStringParameter Name="Author_ID" QueryStringField="Author_ID" Type="String" />

			</Parameters>
		</data:Book_AuthorDataSource>
		
		<br />


</asp:Content>

