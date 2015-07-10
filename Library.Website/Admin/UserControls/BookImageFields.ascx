<%@ Control Language="C#" ClassName="BookImageFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFormat" runat="server" Text="Format:" AssociatedControlID="dataFormat" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFormat" Text='<%# Bind("Format") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSize" runat="server" Text="Size:" AssociatedControlID="dataSize" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSize" Text='<%# Bind("Size") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLink" runat="server" Text="Link:" AssociatedControlID="dataLink" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLink" Text='<%# Bind("Link") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsAvailable" runat="server" Text="Is Available:" AssociatedControlID="dataIsAvailable" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataIsAvailable" Text='<%# Bind("IsAvailable") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


