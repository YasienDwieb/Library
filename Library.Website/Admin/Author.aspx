<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Author.aspx.cs" Inherits="Author" Title="Author List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Author List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AuthorDataSource"
				DataKeyNames="ID"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Author.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]"  />
				<asp:BoundField DataField="Country" HeaderText="Country" SortExpression="[Country]"  />
				<asp:BoundField DataField="City" HeaderText="City" SortExpression="[City]"  />
				<asp:BoundField DataField="BirthDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Birth Date" SortExpression="[BirthDate]"  />
				<asp:BoundField DataField="Position" HeaderText="Position" SortExpression="[Position]"  />
				<asp:BoundField DataField="IsAlive" HeaderText="Is Alive" SortExpression="[IsAlive]"  />
				<asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="[Mobile]"  />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]"  />
				<asp:BoundField DataField="Website" HeaderText="Website" SortExpression="[Website]"  />
				<data:BoundRadioButtonField DataField="Gender" HeaderText="Gender" SortExpression="[Gender]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Author Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAuthor" OnClientClick="javascript:location.href='AuthorEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AuthorDataSource ID="AuthorDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AuthorDataSource>
	    		
</asp:Content>



