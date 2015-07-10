<%@ Control Language="C#" ClassName="CourseFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataCourse_Name" runat="server" Text="Course Name:" AssociatedControlID="dataCourse_Name" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCourse_Name" Text='<%# Bind("Course_Name") %>' MaxLength="200"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCourse_Name" runat="server" Display="Dynamic" ControlToValidate="dataCourse_Name" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCourse_Scope" runat="server" Text="Course Scope:" AssociatedControlID="dataCourse_Scope" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCourse_Scope" Text='<%# Bind("Course_Scope") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCourse_Scope" runat="server" Display="Dynamic" ControlToValidate="dataCourse_Scope" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataCourse_Scope" runat="server" Display="Dynamic" ControlToValidate="dataCourse_Scope" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDuration" runat="server" Text="Duration:" AssociatedControlID="dataDuration" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDuration" Text='<%# Bind("Duration") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDuration" runat="server" Display="Dynamic" ControlToValidate="dataDuration" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataDuration" runat="server" Display="Dynamic" ControlToValidate="dataDuration" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDurationType_ID" runat="server" Text="Duration TypeID:" AssociatedControlID="dataDurationType_ID" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDurationType_ID" Text='<%# Bind("DurationType_ID") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDurationType_ID" runat="server" Display="Dynamic" ControlToValidate="dataDurationType_ID" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataDurationType_ID" runat="server" Display="Dynamic" ControlToValidate="dataDurationType_ID" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
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


