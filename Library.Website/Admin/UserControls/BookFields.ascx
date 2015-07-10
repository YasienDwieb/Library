<%@ Control Language="C#" ClassName="BookFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPublisher" runat="server" Text="Publisher:" AssociatedControlID="dataPublisher" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPublisher" Text='<%# Bind("Publisher") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPublisher" runat="server" Display="Dynamic" ControlToValidate="dataPublisher" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPublish_Date" runat="server" Text="Publish Date:" AssociatedControlID="dataPublish_Date" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPublish_Date" Text='<%# Bind("Publish_Date", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataPublish_Date" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsAvailablePdf" runat="server" Text="Is Available Pdf:" AssociatedControlID="dataIsAvailablePdf" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsAvailablePdf" SelectedValue='<%# Bind("IsAvailablePdf") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsAvailablePaper" runat="server" Text="Is Available Paper:" AssociatedControlID="dataIsAvailablePaper" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsAvailablePaper" SelectedValue='<%# Bind("IsAvailablePaper") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsBorrowed" runat="server" Text="Is Borrowed:" AssociatedControlID="dataIsBorrowed" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsBorrowed" SelectedValue='<%# Bind("IsBorrowed") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUser_ID" runat="server" Text="UserID:" AssociatedControlID="dataUser_ID" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUser_ID" Text='<%# Bind("User_ID") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUser_ID" runat="server" Display="Dynamic" ControlToValidate="dataUser_ID" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataUser_ID" runat="server" Display="Dynamic" ControlToValidate="dataUser_ID" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBorrowDate" runat="server" Text="Borrow Date:" AssociatedControlID="dataBorrowDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBorrowDate" Text='<%# Bind("BorrowDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataBorrowDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBorrow_Times" runat="server" Text="Borrow Times:" AssociatedControlID="dataBorrow_Times" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBorrow_Times" Text='<%# Bind("Borrow_Times") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataBorrow_Times" runat="server" Display="Dynamic" ControlToValidate="dataBorrow_Times" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsLost" runat="server" Text="Is Lost:" AssociatedControlID="dataIsLost" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsLost" SelectedValue='<%# Bind("IsLost") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataType_ID" runat="server" Text="TypeID:" AssociatedControlID="dataType_ID" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataType_ID" DataSourceID="Type_IDBookTypeDataSource" DataTextField="TypeName" DataValueField="ID" SelectedValue='<%# Bind("Type_ID") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:BookTypeDataSource ID="Type_IDBookTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPublisher_ID" runat="server" Text="PublisherID:" AssociatedControlID="dataPublisher_ID" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataPublisher_ID" DataSourceID="Publisher_IDPublisherDataSource" DataTextField="Name" DataValueField="ID" SelectedValue='<%# Bind("Publisher_ID") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:PublisherDataSource ID="Publisher_IDPublisherDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPapers_no" runat="server" Text="Papersno:" AssociatedControlID="dataPapers_no" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPapers_no" Text='<%# Bind("Papers_no") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataPapers_no" runat="server" Display="Dynamic" ControlToValidate="dataPapers_no" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIntroducer_ID" runat="server" Text="IntroducerID:" AssociatedControlID="dataIntroducer_ID" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataIntroducer_ID" DataSourceID="Introducer_IDIntroducerDataSource" DataTextField="Name" DataValueField="ID" SelectedValue='<%# Bind("Introducer_ID") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:IntroducerDataSource ID="Introducer_IDIntroducerDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmployeeI_D" runat="server" Text="Employee ID:" AssociatedControlID="dataEmployeeI_D" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataEmployeeI_D" DataSourceID="EmployeeI_DEmployeeDataSource" DataTextField="UserName" DataValueField="ID" SelectedValue='<%# Bind("EmployeeI_D") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:EmployeeDataSource ID="EmployeeI_DEmployeeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSize" runat="server" Text="Size:" AssociatedControlID="dataSize" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSize" Text='<%# Bind("Size") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSize" runat="server" Display="Dynamic" ControlToValidate="dataSize" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPrice" runat="server" Text="Price:" AssociatedControlID="dataPrice" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPrice" Text='<%# Bind("Price") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataPrice" runat="server" Display="Dynamic" ControlToValidate="dataPrice" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPdf_Link" runat="server" Text="Pdf Link:" AssociatedControlID="dataPdf_Link" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPdf_Link" Text='<%# Bind("Pdf_Link") %>' MaxLength="250"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataImage_ID" runat="server" Text="ImageID:" AssociatedControlID="dataImage_ID" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataImage_ID" DataSourceID="Image_IDBookImageDataSource" DataTextField="Name" DataValueField="ID" SelectedValue='<%# Bind("Image_ID") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:BookImageDataSource ID="Image_IDBookImageDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataISBN" runat="server" Text="ISBN:" AssociatedControlID="dataISBN" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataISBN" Text='<%# Bind("ISBN") %>' MaxLength="50"></asp:TextBox>
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


