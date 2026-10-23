Public Class EstudianteService
    Private ReadOnly _estudianteDB As New EstudianteDB()

    Public Function ListarEstudiantes() As List(Of Estudiante)
        Return _estudianteDB.GetAll()
    End Function

    Public Function ObtenerEstudiantePorId(id As Integer) As Estudiante
        If id <= 0 Then
            Throw New ArgumentException("El ID del estudiante no es válido.")
        End If
        Return _estudianteDB.GetById(id)
    End Function

    Public Sub GuardarEstudiante(p As Estudiante)
        ValidarEstudiante(p)
        If p.IdEstudiante = 0 Then
            _estudianteDB.Insert(p)
        Else
            _estudianteDB.Update(p)
        End If
    End Sub

    Public Sub EliminarEstudiante(id As Integer)
        If id <= 0 Then
            Throw New ArgumentException("Seleccione un registro válido para eliminar.")
        End If
        _estudianteDB.Delete(id)
    End Sub

    Private Sub ValidarEstudiante(p As Estudiante)
        If p Is Nothing Then Throw New ArgumentException("Datos requeridos.")
        If String.IsNullOrWhiteSpace(p.Identificacion) Then Throw New ArgumentException("La identificación es obligatoria.")
        If String.IsNullOrWhiteSpace(p.Nombre) Then Throw New ArgumentException("El nombre es obligatorio.")
        If String.IsNullOrWhiteSpace(p.Primer_Apellido) Then Throw New ArgumentException("El primer apellido es obligatorio.")
        If String.IsNullOrWhiteSpace(p.Segundo_Apellido) Then Throw New ArgumentException("El segundo apellido es obligatorio.")
        If String.IsNullOrWhiteSpace(p.Correo) OrElse Not p.Correo.Contains("@") Then Throw New ArgumentException("Ingrese un correo válido.")
        If String.IsNullOrWhiteSpace(p.Grado) Then Throw New ArgumentException("El grado es obligatorio.")
        If p.IdUsuario <= 0 Then Throw New ArgumentException("Seleccione un usuario válido.")
        If p.IdMateria <= 0 Then Throw New ArgumentException("Seleccione una materia válida.")
    End Sub
End Class
