
Imports System.Data
Imports System.Data.SqlClient

Partial Class Account_Update
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            UpdateUserView()
        End If
    End Sub

    Private Sub UpdateUserView()
        Dim constring As String = "Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=aspnet-Webforms_sandbox-42248daf-5cf0-48f3-a045-60197dd8fe8f;AttachDbFilename=|DataDirectory|\aspnet-Webforms_sandbox-42248daf-5cf0-48f3-a045-60197dd8fe8f.mdf;Integrated Security=SSPI"
        Using con As New SqlConnection(constring)
            Using cmd As New SqlCommand("SELECT [Id], [UserName], [FirstName], [LastName] [Email], [PhoneNumber] FROM [aspnet-Webforms_sandbox-42248daf-5cf0-48f3-a045-60197dd8fe8f].[dbo].[AspNetUsers]", con)
                cmd.CommandType = CommandType.Text
                Using sda As New SqlDataAdapter(cmd)
                    Using ds As New DataSet()
                        sda.Fill(ds)
                        Dim Table = ds.Tables(0)
                        Console.WriteLine("stop")

                        System.Diagnostics.Debug.WriteLine("hi")
                    End Using
                End Using
            End Using
        End Using
    End Sub
End Class
