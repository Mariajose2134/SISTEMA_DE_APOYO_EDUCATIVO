Imports System.Data
Imports System.Data.SqlClient
Public Class EstudianteDB
    Private ReadOnly _db As New DbHelper()

    Public Function GetAll() As List(Of Estudiante)
        Dim lista As New List(Of Estudiante)()
        Dim query As String = "SELECT IdEstudiante, Identificacion, Nombre, Primer_Apellido, Segundo_Apellido, Correo, Grado, IdUsuario, IdMateria FROM Estudiantes ORDER BY IdEstudiante DESC"
        Dim dt As DataTable = _db.ExecuteQuery(query)

        For Each row As DataRow In dt.Rows
            lista.Add(MapRowToEstudiante(row))
        Next
        Return lista
    End Function

    Public Function GetById(id As Integer) As Estudiante
        Dim query As String = "SELECT IdEstudiante, Identificacion, Nombre, Primer_Apellido, Segundo_Apellido, Correo, Grado, IdUsuario, IdMateria FROM Estudiantes WHERE IdEstudiante = @IdEstudiante"
        Dim params As New List(Of SqlParameter) From {
            New SqlParameter("@IdEstudiante", id)
        }
        Dim dt As DataTable = _db.ExecuteQuery(query, params)
        If dt.Rows.Count > 0 Then
            Return MapRowToEstudiante(dt.Rows(0))
        End If
        Return Nothing
    End Function

    Public Function Insert(p As Estudiante) As Boolean
        Dim query As String = "INSERT INTO Estudiantes (Identificacion, Nombre, Primer_Apellido, Segundo_Apellido, Correo, Grado, IdUsuario, IdMateria) VALUES (@Identificacion, @Nombre, @Primer_Apellido, @Segundo_Apellido, @Correo, @Grado, @IdUsuario, @IdMateria)"
        Dim params As New List(Of SqlParameter) From {
            New SqlParameter("@Identificacion", p.Identificacion),
            New SqlParameter("@Nombre", p.Nombre),
            New SqlParameter("@Primer_Apellido", p.Primer_Apellido),
            New SqlParameter("@Segundo_Apellido", p.Segundo_Apellido),
            New SqlParameter("@Correo", p.Correo),
            New SqlParameter("@Grado", p.Grado),
            New SqlParameter("@IdUsuario", p.IdUsuario),
            New SqlParameter("@IdMateria", p.IdMateria)
        }
        Return _db.ExecuteNonQuery(query, params) > 0
    End Function

    Public Function Update(p As Estudiante) As Boolean
        Dim query As String = "UPDATE Estudiantes SET Identificacion = @Identificacion, Nombre = @Nombre, Primer_Apellido = @Primer_Apellido, Segundo_Apellido = @Segundo_Apellido, Correo = @Correo, Grado = @Grado, IdUsuario = @IdUsuario, IdMateria = @IdMateria WHERE IdEstudiante = @IdEstudiante"
        Dim params As New List(Of SqlParameter) From {
            New SqlParameter("@IdEstudiante", p.IdEstudiante),
            New SqlParameter("@Identificacion", p.Identificacion),
            New SqlParameter("@Nombre", p.Nombre),
            New SqlParameter("@Primer_Apellido", p.Primer_Apellido),
            New SqlParameter("@Segundo_Apellido", p.Segundo_Apellido),
            New SqlParameter("@Correo", p.Correo),
            New SqlParameter("@Grado", p.Grado),
            New SqlParameter("@IdUsuario", p.IdUsuario),
            New SqlParameter("@IdMateria", p.IdMateria)
        }
        Return _db.ExecuteNonQuery(query, params) > 0
    End Function

    Public Function Delete(id As Integer) As Boolean
        Dim query As String = "DELETE FROM Estudiantes WHERE IdEstudiante = @IdEstudiante"
        Dim params As New List(Of SqlParameter) From {
            New SqlParameter("@IdEstudiante", id)
        }
        Return _db.ExecuteNonQuery(query, params) > 0
    End Function

    Private Function MapRowToEstudiante(row As DataRow) As Estudiante
        Return New Estudiante() With {
            .IdEstudiante = Convert.ToInt32(row("IdEstudiante")),
            .Identificacion = row("Identificacion").ToString(),
            .Nombre = row("Nombre").ToString(),
            .Primer_Apellido = row("Primer_Apellido").ToString(),
            .Segundo_Apellido = row("Segundo_Apellido").ToString(),
            .Correo = row("Correo").ToString(),
            .Grado = row("Grado").ToString(),
            .IdUsuario = Convert.ToInt32(row("IdUsuario")),
            .IdMateria = Convert.ToInt32(row("IdMateria"))
        }
    End Function
End Class
