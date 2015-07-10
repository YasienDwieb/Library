<%@ Control Language="C#" ClassName="UsersFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserName" runat="server" Text="User Name:" AssociatedControlID="dataUserName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUserName" Text='<%# Bind("UserName") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUserName" runat="server" Display="Dynamic" ControlToValidate="dataUserName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPassword" runat="server" Text="Password:" AssociatedControlID="dataPassword" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPassword" Text='<%# Bind("Password") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPassword" runat="server" Display="Dynamic" ControlToValidate="dataPassword" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLast_Login" runat="server" Text="Last Login:" AssociatedControlID="dataLast_Login" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLast_Login" Text='<%# Bind("Last_Login", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLast_Login" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLast_Logout" runat="server" Text="Last Logout:" AssociatedControlID="dataLast_Logout" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLast_Logout" Text='<%# Bind("Last_Logout", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLast_Logout" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIs_Online" runat="server" Text="Is Online:" AssociatedControlID="dataIs_Online" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIs_Online" SelectedValue='<%# Bind("Is_Online") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIs_Active" runat="server" Text="Is Active:" AssociatedControlID="dataIs_Active" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIs_Active" SelectedValue='<%# Bind("Is_Active") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIs_Admin" runat="server" Text="Is Admin:" AssociatedControlID="dataIs_Admin" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIs_Admin" SelectedValue='<%# Bind("Is_Admin") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserType_ID" runat="server" Text="User TypeID:" AssociatedControlID="dataUserType_ID" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataUserType_ID" DataSourceID="UserType_IDUserTypeDataSource" DataTextField="TypeName" DataValueField="ID" SelectedValue='<%# Bind("UserType_ID") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:UserTypeDataSource ID="UserType_IDUserTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFirst_Name" runat="server" Text="First Name:" AssociatedControlID="dataFirst_Name" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFirst_Name" Text='<%# Bind("First_Name") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLast_Name" runat="server" Text="Last Name:" AssociatedControlID="dataLast_Name" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLast_Name" Text='<%# Bind("Last_Name") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmail" runat="server" Text="Email:" AssociatedControlID="dataEmail" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>' MaxLength="50"></asp:TextBox>
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
			<tr>
        <td class="literal"><asp:Label ID="lbldataMobile" runat="server" Text="Mobile:" AssociatedControlID="dataMobile" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMobile" Text='<%# Bind("Mobile") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPhone" runat="server" Text="Phone:" AssociatedControlID="dataPhone" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPhone" Text='<%# Bind("Phone") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPostion" runat="server" Text="Postion:" AssociatedControlID="dataPostion" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPostion" Text='<%# Bind("Postion") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIs_Deleted" runat="server" Text="Is Deleted:" AssociatedControlID="dataIs_Deleted" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIs_Deleted" SelectedValue='<%# Bind("Is_Deleted") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedOn" runat="server" Text="Created On:" AssociatedControlID="dataCreatedOn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedOn" Text='<%# Bind("CreatedOn", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedOn" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedBy" runat="server" Text="Created By:" AssociatedControlID="dataCreatedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedBy" Text='<%# Bind("CreatedBy") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataCreatedBy" runat="server" Display="Dynamic" ControlToValidate="dataCreatedBy" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUpdatedOn" runat="server" Text="Updated On:" AssociatedControlID="dataUpdatedOn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpdatedOn" Text='<%# Bind("UpdatedOn", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataUpdatedOn" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUpdatedBy" runat="server" Text="Updated By:" AssociatedControlID="dataUpdatedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpdatedBy" Text='<%# Bind("UpdatedBy") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataUpdatedBy" runat="server" Display="Dynamic" ControlToValidate="dataUpdatedBy" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDeletedOn" runat="server" Text="Deleted On:" AssociatedControlID="dataDeletedOn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDeletedOn" Text='<%# Bind("DeletedOn", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDeletedOn" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDeletedBy" runat="server" Text="Deleted By:" AssociatedControlID="dataDeletedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDeletedBy" Text='<%# Bind("DeletedBy") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataDeletedBy" runat="server" Display="Dynamic" ControlToValidate="dataDeletedBy" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


