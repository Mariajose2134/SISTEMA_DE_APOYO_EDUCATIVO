Public Class Estudiante
    Public Property IdEstudiante As Integer
    Public Property Identificacion As String
    Public Property Nombre As String
    Public Property Primer_Apellido As String
    Public Property Segundo_Apellido As String
    Public Property Correo As String
    Public Property Grado As String
    Public Property IdUsuario As Integer
    Public Property IdMateria As Integer

    Public Sub New()
    End Sub

    Public Sub New(idestudiante As Integer, identificacion As String, nombre As String, primer_Apellido As String, segundo_Apellido As String, correo As String, grado As String, idusuario As Integer, idmateria As Integer)
        Me.IdEstudiante = idestudiante
        Me.Identificacion = identificacion
        Me.Nombre = nombre
        Me.Primer_Apellido = primer_Apellido
        Me.Segundo_Apellido = segundo_Apellido
        Me.Correo = correo
        Me.Grado = grado
        Me.IdUsuario = idusuario
        Me.IdMateria = idmateria
    End Sub


End Class
