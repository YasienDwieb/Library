<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="UserTypeEdit.aspx.cs" Inherits="UserTypeEdit" Title="UserType Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">User Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ID" runat="server" DataSourceID="UserTypeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/UserTypeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/UserTypeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>UserType not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:UserTypeDataSource ID="UserTypeDataSource" runat="server"
			SelectMethod="GetByID"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="String" />

			</Parameters>
		</data:UserTypeDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewUsers1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewUsers1_SelectedIndexChanged"			 			 
			DataSourceID="UsersDataSource1"
			DataKeyNames="ID"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Users.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="[UserName]" />				
				<asp:BoundField DataField="Password" HeaderText="Password" SortExpression="[Password]" />				
				<asp:BoundField DataField="Last_Login" HeaderText="Last Login" SortExpression="[Last_Login]" />				
				<asp:BoundField DataField="Last_Logout" HeaderText="Last Logout" SortExpression="[Last_Logout]" />				
				<asp:BoundField DataField="Is_Online" HeaderText="Is Online" SortExpression="[Is_Online]" />				
				<asp:BoundField DataField="Is_Active" HeaderText="Is Active" SortExpression="[Is_Active]" />				
				<asp:BoundField DataField="Is_Admin" HeaderText="Is Admin" SortExpression="[Is_Admin]" />				
				<data:HyperLinkField HeaderText="User TypeID" DataNavigateUrlFormatString="UserTypeEdit.aspx?ID={0}" DataNavigateUrlFields="ID" DataContainer="UserType_IDSource" DataTextField="TypeName" />
				<asp:BoundField DataField="First_Name" HeaderText="First Name" SortExpression="[First_Name]" />				
				<asp:BoundField DataField="Last_Name" HeaderText="Last Name" SortExpression="[Last_Name]" />				
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]" />				
				<asp:BoundField DataField="Country" HeaderText="Country" SortExpression="[Country]" />				
				<asp:BoundField DataField="City" HeaderText="City" SortExpression="[City]" />				
				<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="[Address]" />				
				<asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="[Mobile]" />				
				<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="[Phone]" />				
				<asp:BoundField DataField="Postion" HeaderText="Postion" SortExpression="[Postion]" />				
				<asp:BoundField DataField="Is_Deleted" HeaderText="Is Deleted" SortExpression="[Is_Deleted]" />				
				<asp:BoundField DataField="CreatedOn" HeaderText="Created On" SortExpression="[CreatedOn]" />				
				<asp:BoundField DataField="CreatedBy" HeaderText="Created By" SortExpression="[CreatedBy]" />				
				<asp:BoundField DataField="UpdatedOn" HeaderText="Updated On" SortExpression="[UpdatedOn]" />				
				<asp:BoundField DataField="UpdatedBy" HeaderText="Updated By" SortExpression="[UpdatedBy]" />				
				<asp:BoundField DataField="DeletedOn" HeaderText="Deleted On" SortExpression="[DeletedOn]" />				
				<asp:BoundField DataField="DeletedBy" HeaderText="Deleted By" SortExpression="[DeletedBy]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Users Found! </b>
				<asp:HyperLink runat="server" ID="hypUsers" NavigateUrl="~/admin/UsersEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:UsersDataSource ID="UsersDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:UsersProperty Name="UserType"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:UsersFilter  Column="UserType_ID" QueryStringField="ID" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:UsersDataSource>		
		
		<br />
		

</asp:Content>

