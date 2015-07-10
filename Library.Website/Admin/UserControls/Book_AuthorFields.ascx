<%@ Control Language="C#" ClassName="Book_AuthorFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataBook_ID" runat="server" Text="BookID:" AssociatedControlID="dataBook_ID" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataBook_ID" DataSourceID="Book_IDBookDataSource" DataTextField="Name" DataValueField="ID" SelectedValue='<%# Bind("Book_ID") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:BookDataSource ID="Book_IDBookDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAuthor_ID" runat="server" Text="AuthorID:" AssociatedControlID="dataAuthor_ID" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataAuthor_ID" DataSourceID="Author_IDAuthorDataSource" DataTextField="Name" DataValueField="ID" SelectedValue='<%# Bind("Author_ID") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AuthorDataSource ID="Author_IDAuthorDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


