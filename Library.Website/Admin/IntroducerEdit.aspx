<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="IntroducerEdit.aspx.cs" Inherits="IntroducerEdit" Title="Introducer Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Introducer - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ID" runat="server" DataSourceID="IntroducerDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/IntroducerFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/IntroducerFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Introducer not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:IntroducerDataSource ID="IntroducerDataSource" runat="server"
			SelectMethod="GetByID"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="String" />

			</Parameters>
		</data:IntroducerDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewBook1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewBook1_SelectedIndexChanged"			 			 
			DataSourceID="BookDataSource1"
			DataKeyNames="ID"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Book.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="Publisher" HeaderText="Publisher" SortExpression="[Publisher]" />				
				<asp:BoundField DataField="Publish_Date" HeaderText="Publish Date" SortExpression="[Publish_Date]" />				
				<asp:BoundField DataField="IsAvailablePdf" HeaderText="Is Available Pdf" SortExpression="[IsAvailablePdf]" />				
				<asp:BoundField DataField="IsAvailablePaper" HeaderText="Is Available Paper" SortExpression="[IsAvailablePaper]" />				
				<asp:BoundField DataField="IsBorrowed" HeaderText="Is Borrowed" SortExpression="[IsBorrowed]" />				
				<asp:BoundField DataField="User_ID" HeaderText="UserID" SortExpression="[User_ID]" />				
				<asp:BoundField DataField="BorrowDate" HeaderText="Borrow Date" SortExpression="[BorrowDate]" />				
				<asp:BoundField DataField="Borrow_Times" HeaderText="Borrow Times" SortExpression="[Borrow_Times]" />				
				<asp:BoundField DataField="IsLost" HeaderText="Is Lost" SortExpression="[IsLost]" />				
				<data:HyperLinkField HeaderText="TypeID" DataNavigateUrlFormatString="BookTypeEdit.aspx?ID={0}" DataNavigateUrlFields="ID" DataContainer="Type_IDSource" DataTextField="TypeName" />
				<data:HyperLinkField HeaderText="PublisherID" DataNavigateUrlFormatString="PublisherEdit.aspx?ID={0}" DataNavigateUrlFields="ID" DataContainer="Publisher_IDSource" DataTextField="Name" />
				<asp:BoundField DataField="Papers_no" HeaderText="Papersno" SortExpression="[Papers_no]" />				
				<data:HyperLinkField HeaderText="IntroducerID" DataNavigateUrlFormatString="IntroducerEdit.aspx?ID={0}" DataNavigateUrlFields="ID" DataContainer="Introducer_IDSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Employee ID" DataNavigateUrlFormatString="EmployeeEdit.aspx?ID={0}" DataNavigateUrlFields="ID" DataContainer="EmployeeI_DSource" DataTextField="UserName" />
				<asp:BoundField DataField="Size" HeaderText="Size" SortExpression="[Size]" />				
				<asp:BoundField DataField="Price" HeaderText="Price" SortExpression="[Price]" />				
				<asp:BoundField DataField="Pdf_Link" HeaderText="Pdf Link" SortExpression="[Pdf_Link]" />				
				<data:HyperLinkField HeaderText="ImageID" DataNavigateUrlFormatString="BookImageEdit.aspx?ID={0}" DataNavigateUrlFields="ID" DataContainer="Image_IDSource" DataTextField="Name" />
				<asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="[ISBN]" />				
				<asp:BoundField DataField="CreatedOn" HeaderText="Created On" SortExpression="[CreatedOn]" />				
				<asp:BoundField DataField="CreatedBy" HeaderText="Created By" SortExpression="[CreatedBy]" />				
				<asp:BoundField DataField="UpdatedOn" HeaderText="Updated On" SortExpression="[UpdatedOn]" />				
				<asp:BoundField DataField="UpdatedBy" HeaderText="Updated By" SortExpression="[UpdatedBy]" />				
				<asp:BoundField DataField="DeletedOn" HeaderText="Deleted On" SortExpression="[DeletedOn]" />				
				<asp:BoundField DataField="DeletedBy" HeaderText="Deleted By" SortExpression="[DeletedBy]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Book Found! </b>
				<asp:HyperLink runat="server" ID="hypBook" NavigateUrl="~/admin/BookEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:BookDataSource ID="BookDataSource1" runat="server" SelectMethod="Find"
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
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:BookFilter  Column="Introducer_ID" QueryStringField="ID" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:BookDataSource>		
		
		<br />
		

</asp:Content>

