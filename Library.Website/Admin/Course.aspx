<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Course.aspx.cs" Inherits="Course" Title="Course List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Course List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CourseDataSource"
				DataKeyNames="ID"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Course.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Course_Name" HeaderText="Course Name" SortExpression="[Course_Name]"  />
				<asp:BoundField DataField="Course_Scope" HeaderText="Course Scope" SortExpression="[Course_Scope]"  />
				<asp:BoundField DataField="Duration" HeaderText="Duration" SortExpression="[Duration]"  />
				<asp:BoundField DataField="DurationType_ID" HeaderText="Duration TypeID" SortExpression="[DurationType_ID]"  />
				<data:BoundRadioButtonField DataField="Is_Deleted" HeaderText="Is Deleted" SortExpression="[Is_Deleted]"  />
				<asp:BoundField DataField="CreatedOn" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created On" SortExpression="[CreatedOn]"  />
				<asp:BoundField DataField="CreatedBy" HeaderText="Created By" SortExpression="[CreatedBy]"  />
				<asp:BoundField DataField="UpdatedOn" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Updated On" SortExpression="[UpdatedOn]"  />
				<asp:BoundField DataField="UpdatedBy" HeaderText="Updated By" SortExpression="[UpdatedBy]"  />
				<asp:BoundField DataField="DeletedOn" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Deleted On" SortExpression="[DeletedOn]"  />
				<asp:BoundField DataField="DeletedBy" HeaderText="Deleted By" SortExpression="[DeletedBy]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Course Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnCourse" OnClientClick="javascript:location.href='CourseEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:CourseDataSource ID="CourseDataSource" runat="server"
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
		</data:CourseDataSource>
	    		
</asp:Content>



