<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Book_Author.aspx.cs" Inherits="Book_Author" Title="Book_Author List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Book Author List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="Book_AuthorDataSource"
				DataKeyNames="Book_ID, Author_ID"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Book_Author.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="BookID" DataNavigateUrlFormatString="BookEdit.aspx?ID={0}" DataNavigateUrlFields="ID" DataContainer="Book_IDSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="AuthorID" DataNavigateUrlFormatString="AuthorEdit.aspx?ID={0}" DataNavigateUrlFields="ID" DataContainer="Author_IDSource" DataTextField="Name" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Book_Author Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnBook_Author" OnClientClick="javascript:location.href='Book_AuthorEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:Book_AuthorDataSource ID="Book_AuthorDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:Book_AuthorProperty Name="Author"/> 
					<data:Book_AuthorProperty Name="Book"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:Book_AuthorDataSource>
	    		
</asp:Content>



