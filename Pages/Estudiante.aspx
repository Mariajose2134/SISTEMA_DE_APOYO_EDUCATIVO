<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Estudiante.aspx.vb" Inherits="SISTEMA_DE_APOYO_EDUCATIVO.Estudiante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	
		<h2 class="mb-3">Registro de Estudiantes</h2>
		<div class="card mb-4">

			<div class="card-header bg-primary text-white">
				<asp:Label ID="lblTituloForm" runat="server" Text="Nuevo Estudiante" />
			</div>

			<div class="card-body row g-3">
				<div class="col-md-4">
					<label>Identificación</label>
					<asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control" />
				</div>
				<div class="col-md-4">
					<label>Nombre</label>
					<asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
				</div>
				<div class="col-md-4">
					<label>Primer Apellido</label>
					<asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="form-control" />
				</div>
				<div class="col-md-4">
					<label>Segundo Apellido</label>
					<asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="form-control" />
				</div>
				<div class="col-md-6">
					<label>Correo</label>
					<asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TextMode="Email" />
				</div>
				<div class="col-md-6">
					<label>Grado</label>
					<asp:TextBox ID="txtGrado" runat="server" CssClass="form-control" />
				</div>
				<div class="col-md-3">
					<label>IdUsuario</label>
					<asp:TextBox ID="txtIdUsuario" runat="server" CssClass="form-control" TextMode="Number" />
				</div>
				<div class="col-md-3">
					<label>IdMateria</label>
					<asp:TextBox ID="txtIdMateria" runat="server" CssClass="form-control" TextMode="Number" />
				</div>

				<div class="col-md-3 d-flex align-items-end gap-2">
					<asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success w-100" OnClick="btnGuardar_Click" />
					<asp:Button ID="btnLimpiar" runat="server" Text="Cancelar" CssClass="btn btn-secondary w-100" OnClick="btnLimpiar_Click" />
				</div>
			</div>

			<div class="card-body row g-3">
				<asp:GridView ID="gvEstudiantes" runat="server"
					CssClass="table"
					AllowPaging="True" AutoGenerateColumns="False"
					DataKeyNames="Identificacion"
					OnRowCommand="gvEstudiantes_RowCommand">
					<Columns>
						<asp:BoundField DataField="IdEstudiante" HeaderText="IdEstudiante" InsertVisible="False" ReadOnly="True" SortExpression="IdEstudiante" />
						<asp:BoundField DataField="Identificacion" HeaderText="Identificacion" SortExpression="Identificacion" />
						<asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
						<asp:BoundField DataField="Primer_Apellido" HeaderText="Primer Apellido" SortExpression="Primer_Apellido" />
						<asp:BoundField DataField="Segundo_Apellido" HeaderText="Segundo Apellido" SortExpression="Segundo_Apellido " />
						<asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
						<asp:BoundField DataField="Grado" HeaderText="Grado" SortExpression="Grado" />
						<asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" SortExpression="IdUsuario" />
						<asp:BoundField DataField="IdMateria" HeaderText="IdMateria" SortExpression="IdMateria" />
						<asp:TemplateField HeaderText="Acciones">
							<ItemTemplate>
								<asp:Button ID="btnSeleccionar" runat="server" Text="Editar" CommandName="Seleccionar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-sm btn-warning me-1" />
								<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('¿Eliminar este registro?');" />
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
				</asp:GridView>

			</div>
		</div>
	</asp:Content>
