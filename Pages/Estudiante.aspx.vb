Imports System.Data.SqlClient

Public Class Estudiante
    Inherits System.Web.UI.Page

    Private ReadOnly _service As New EstudianteService()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarGrid()
        End If
    End Sub

    Private Property IdEstudianteEditar As Integer
        Get
            Return If(ViewState("IdEstudianteEditar") IsNot Nothing,
                      Convert.ToInt32(ViewState("IdEstudianteEditar")), 0)
        End Get
        Set(value As Integer)
            ViewState("IdEstudianteEditar") = value
        End Set
    End Property

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Try

            Dim usuarioValor As Integer = 0

            If Not Integer.TryParse(txtIdUsuario.Text.Trim(), usuarioValor) Then
                SwalUtils.ShowWarning(Me, "Ingrese un ID de usuario numérico válido.")
                Return
            End If

            Dim materiaValor As Integer = 0

            If Not Integer.TryParse(txtIdMateria.Text.Trim(), materiaValor) Then
                SwalUtils.ShowWarning(Me, "Ingrese un ID de materia numérico válido.")
                Return
            End If

            Dim p As New Estudiante With {
                .IdEstudiante = IdEstudianteEditar,
                .Identificacion = txtIdentificacion.Text.Trim(),
                .Nombre = txtNombre.Text.Trim(),
                .Primer_Apellido = txtPrimerApellido.Text.Trim(),
                .Segundo_Apellido = txtSegundoApellido.Text.Trim(),
                .Correo = txtCorreo.Text.Trim(),
                .Grado = txtGrado.Text.Trim(),
                .IdUsuario = usuarioValor,
                .IdMateria = materiaValor
            }

            Dim esEdicion As Boolean = (IdEstudianteEditar > 0)

            _service.GuardarEstudiante(p)

            LimpiarFormulario()
            CargarGrid()

            SwalUtils.ShowSuccess(
                Me,
                If(esEdicion, "Registro actualizado.", "Registro insertado.")
            )

        Catch ex As Exception
            SwalUtils.ShowError(Me, ex.Message)
        End Try
    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        LimpiarFormulario()
    End Sub

    Protected Sub gvEstudiantes_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName = "Seleccionar" OrElse e.CommandName = "Eliminar" Then
            Try
                Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
                Dim id As Integer = Convert.ToInt32(gvEstudiantes.DataKeys(rowIndex).Value)

                If e.CommandName = "Seleccionar" Then

                    Dim p As Estudiante = _service.ObtenerEstudiantePorId(id)

                    If p IsNot Nothing Then
                        IdEstudianteEditar = p.IdEstudiante

                        txtIdentificacion.Text = p.Identificacion
                        txtNombre.Text = p.Nombre
                        txtPrimerApellido.Text = p.Primer_Apellido
                        txtSegundoApellido.Text = p.Segundo_Apellido
                        txtCorreo.Text = p.Correo
                        txtGrado.Text = p.Grado
                        txtIdUsuario.Text = p.IdUsuario.ToString()
                        txtIdMateria.Text = p.IdMateria.ToString()

                        lblTituloForm.Text = $"Editando Estudiante (ID: {p.IdEstudiante})"
                        btnGuardar.Text = "Actualizar"
                    End If

                ElseIf e.CommandName = "Eliminar" Then

                    _service.EliminarEstudiante(id)

                    If IdEstudianteEditar = id Then
                        LimpiarFormulario()
                    End If

                    CargarGrid()
                    SwalUtils.ShowSuccess(Me, "Registro eliminado correctamente.")

                End If

            Catch ex As Exception
                SwalUtils.ShowError(Me, ex.Message)
            End Try
        End If

    End Sub

    Private Sub CargarGrid()
        Try
            gvEstudiantes.DataSource = _service.ListarEstudiantes()
            gvEstudiantes.DataBind()

        Catch ex As Exception
            SwalUtils.ShowError(Me, "Error al cargar datos: " & ex.Message)
        End Try
    End Sub

    Private Sub LimpiarFormulario()

        IdEstudianteEditar = 0

        txtIdentificacion.Text = ""
        txtNombre.Text = ""
        txtPrimerApellido.Text = ""
        txtSegundoApellido.Text = ""
        txtCorreo.Text = ""
        txtGrado.Text = ""
        txtIdUsuario.Text = ""
        txtIdMateria.Text = ""

        lblTituloForm.Text = "Nuevo Estudiante"
        btnGuardar.Text = "Guardar"

    End Sub

End Class

