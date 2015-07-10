<%@ Control Language="C#" ClassName="BookTypeFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataTypeName" runat="server" Text="Type Name:" AssociatedControlID="dataTypeName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTypeName" Text='<%# Bind("TypeName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


