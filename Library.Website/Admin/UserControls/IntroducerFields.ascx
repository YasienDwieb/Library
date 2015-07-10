<%@ Control Language="C#" ClassName="IntroducerFields" %>

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
        <td class="literal"><asp:Label ID="lbldataBirthDate" runat="server" Text="Birth Date:" AssociatedControlID="dataBirthDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBirthDate" Text='<%# Bind("BirthDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataBirthDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPosition" runat="server" Text="Position:" AssociatedControlID="dataPosition" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPosition" Text='<%# Bind("Position") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsAlive" runat="server" Text="Is Alive:" AssociatedControlID="dataIsAlive" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataIsAlive" Text='<%# Bind("IsAlive") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMobile" runat="server" Text="Mobile:" AssociatedControlID="dataMobile" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMobile" Text='<%# Bind("Mobile") %>' MaxLength="50"></asp:TextBox>
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
        <td class="literal"><asp:Label ID="lbldataBook_ID" runat="server" Text="BookID:" AssociatedControlID="dataBook_ID" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBook_ID" Text='<%# Bind("Book_ID") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataBook_ID" runat="server" Display="Dynamic" ControlToValidate="dataBook_ID" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataBook_ID" runat="server" Display="Dynamic" ControlToValidate="dataBook_ID" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGender" runat="server" Text="Gender:" AssociatedControlID="dataGender" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataGender" SelectedValue='<%# Bind("Gender") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


