<%@ Control Language="C#" ClassName="PublisherFields" %>

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
        <td class="literal"><asp:Label ID="lbldataMobile" runat="server" Text="Mobile:" AssociatedControlID="dataMobile" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMobile" Text='<%# Bind("Mobile") %>' MaxLength="14"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmail" runat="server" Text="Email:" AssociatedControlID="dataEmail" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWebsite" runat="server" Text="Website:" AssociatedControlID="dataWebsite" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWebsite" Text='<%# Bind("Website") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFounedOn" runat="server" Text="Founed On:" AssociatedControlID="dataFounedOn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFounedOn" Text='<%# Bind("FounedOn", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataFounedOn" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCountry" runat="server" Text="Country:" AssociatedControlID="dataCountry" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCountry" Text='<%# Bind("Country") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCity" runat="server" Text="City:" AssociatedControlID="dataCity" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCity" Text='<%# Bind("City") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddress" runat="server" Text="Address:" AssociatedControlID="dataAddress" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddress" Text='<%# Bind("Address") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


