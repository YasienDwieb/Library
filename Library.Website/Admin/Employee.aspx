<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Employee.aspx.cs" Inherits="Employee" Title="Employee List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Employee List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="EmployeeDataSource"
				DataKeyNames="ID"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Employee.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="[UserName]"  />
				<asp:BoundField DataField="Password" HeaderText="Password" SortExpression="[Password]"  />
				<asp:BoundField DataField="Last_Login" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Login" SortExpression="[Last_Login]"  />
				<asp:BoundField DataField="Last_Logout" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Logout" SortExpression="[Last_Logout]"  />
				<data:BoundRadioButtonField DataField="Is_Online" HeaderText="Is Online" SortExpression="[Is_Online]"  />
				<data:BoundRadioButtonField DataField="Is_Active" HeaderText="Is Active" SortExpression="[Is_Active]"  />
				<data:BoundRadioButtonField DataField="Is_Admin" HeaderText="Is Admin" SortExpression="[Is_Admin]"  />
				<asp:BoundField DataField="First_Name" HeaderText="First Name" SortExpression="[First_Name]"  />
				<asp:BoundField DataField="Last_Name" HeaderText="Last Name" SortExpression="[Last_Name]"  />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]"  />
				<asp:BoundField DataField="Country" HeaderText="Country" SortExpression="[Country]"  />
				<asp:BoundField DataField="City" HeaderText="City" SortExpression="[City]"  />
				<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="[Address]"  />
				<asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="[Mobile]"  />
				<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="[Phone]"  />
				<asp:BoundField DataField="Postion" HeaderText="Postion" SortExpression="[Postion]"  />
				<data:BoundRadioButtonField DataField="Is_Deleted" HeaderText="Is Deleted" SortExpression="[Is_Deleted]"  />
				<asp:BoundField DataField="CreatedOn" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created On" SortExpression="[CreatedOn]"  />
				<asp:BoundField DataField="CreatedBy" HeaderText="Created By" SortExpression="[CreatedBy]"  />
				<asp:BoundField DataField="UpdatedOn" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Updated On" SortExpression="[UpdatedOn]"  />
				<asp:BoundField DataField="UpdatedBy" HeaderText="Updated By" SortExpression="[UpdatedBy]"  />
				<asp:BoundField DataField="DeletedOn" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Deleted On" SortExpression="[DeletedOn]"  />
				<asp:BoundField DataField="DeletedBy" HeaderText="Deleted By" SortExpression="[DeletedBy]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Employee Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnEmployee" OnClientClick="javascript:location.href='EmployeeEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:EmployeeDataSource ID="EmployeeDataSource" runat="server"
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
		</data:EmployeeDataSource>
	    		
</asp:Content>



