<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Book.aspx.cs" Inherits="Book" Title="Book List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Book List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="BookDataSource"
				DataKeyNames="ID"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Book.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]"  />
				<asp:BoundField DataField="Publisher" HeaderText="Publisher" SortExpression="[Publisher]"  />
				<asp:BoundField DataField="Publish_Date" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Publish Date" SortExpression="[Publish_Date]"  />
				<data:BoundRadioButtonField DataField="IsAvailablePdf" HeaderText="Is Available Pdf" SortExpression="[IsAvailablePdf]"  />
				<data:BoundRadioButtonField DataField="IsAvailablePaper" HeaderText="Is Available Paper" SortExpression="[IsAvailablePaper]"  />
				<data:BoundRadioButtonField DataField="IsBorrowed" HeaderText="Is Borrowed" SortExpression="[IsBorrowed]"  />
				<asp:BoundField DataField="User_ID" HeaderText="UserID" SortExpression="[User_ID]"  />
				<asp:BoundField DataField="BorrowDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Borrow Date" SortExpression="[BorrowDate]"  />
				<asp:BoundField DataField="Borrow_Times" HeaderText="Borrow Times" SortExpression="[Borrow_Times]"  />
				<data:BoundRadioButtonField DataField="IsLost" HeaderText="Is Lost" SortExpression="[IsLost]"  />
				<data:HyperLinkField HeaderText="TypeID" DataNavigateUrlFormatString="BookTypeEdit.aspx?ID={0}" DataNavigateUrlFields="ID" DataContainer="Type_IDSource" DataTextField="TypeName" />
				<data:HyperLinkField HeaderText="PublisherID" DataNavigateUrlFormatString="PublisherEdit.aspx?ID={0}" DataNavigateUrlFields="ID" DataContainer="Publisher_IDSource" DataTextField="Name" />
				<asp:BoundField DataField="Papers_no" HeaderText="Papersno" SortExpression="[Papers_no]"  />
				<data:HyperLinkField HeaderText="IntroducerID" DataNavigateUrlFormatString="IntroducerEdit.aspx?ID={0}" DataNavigateUrlFields="ID" DataContainer="Introducer_IDSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Employee ID" DataNavigateUrlFormatString="EmployeeEdit.aspx?ID={0}" DataNavigateUrlFields="ID" DataContainer="EmployeeI_DSource" DataTextField="UserName" />
				<asp:BoundField DataField="Size" HeaderText="Size" SortExpression="[Size]"  />
				<asp:BoundField DataField="Price" HeaderText="Price" SortExpression="[Price]"  />
				<asp:BoundField DataField="Pdf_Link" HeaderText="Pdf Link" SortExpression="[Pdf_Link]"  />
				<data:HyperLinkField HeaderText="ImageID" DataNavigateUrlFormatString="BookImageEdit.aspx?ID={0}" DataNavigateUrlFields="ID" DataContainer="Image_IDSource" DataTextField="Name" />
				<asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="[ISBN]"  />
				<asp:BoundField DataField="CreatedOn" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created On" SortExpression="[CreatedOn]"  />
				<asp:BoundField DataField="CreatedBy" HeaderText="Created By" SortExpression="[CreatedBy]"  />
				<asp:BoundField DataField="UpdatedOn" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Updated On" SortExpression="[UpdatedOn]"  />
				<asp:BoundField DataField="UpdatedBy" HeaderText="Updated By" SortExpression="[UpdatedBy]"  />
				<asp:BoundField DataField="DeletedOn" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Deleted On" SortExpression="[DeletedOn]"  />
				<asp:BoundField DataField="DeletedBy" HeaderText="Deleted By" SortExpression="[DeletedBy]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Book Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnBook" OnClientClick="javascript:location.href='BookEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:BookDataSource ID="BookDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:BookProperty Name="BookType"/> 
					<data:BookProperty Name="Employee"/> 
					<data:BookProperty Name="BookImage"/> 
					<data:BookProperty Name="Introducer"/> 
					<data:BookProperty Name="Publisher"/> 
					<%--<data:BookProperty Name="Author_IDAuthorCollection_From_Book_Author" />--%>
					<%--<data:BookProperty Name="Book_AuthorCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:BookDataSource>
	    		
</asp:Content>



