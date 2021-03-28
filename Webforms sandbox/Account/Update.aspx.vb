
Imports System.Data
Imports System.Data.SqlClient

Partial Class Account_Update
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            UpdateUserView(sender.Request.Url.Segments(3))
        End If
    End Sub

    Private Sub UpdateUserView(Id As String)
        Dim constring As String = "Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=aspnet-Webforms_sandbox-42248daf-5cf0-48f3-a045-60197dd8fe8f;AttachDbFilename=|DataDirectory|\aspnet-Webforms_sandbox-42248daf-5cf0-48f3-a045-60197dd8fe8f.mdf;Integrated Security=SSPI"
        Using con As New SqlConnection(constring)
            Using cmd As New SqlCommand("SELECT TOP(1) [Id], [UserName], [FirstName], [LastName], [Email], [PhoneNumber] FROM [aspnet-Webforms_sandbox-42248daf-5cf0-48f3-a045-60197dd8fe8f].[dbo].[AspNetUsers] WHERE Id = '" + Id + "'", con)
                cmd.CommandType = CommandType.Text
                Using sda As New SqlDataAdapter(cmd)
                    Using ds As New DataSet()
                        sda.Fill(ds)
                        Dim Table = ds.Tables(0)
                        UserName.Text = Table.Rows(0)("UserName").ToString()
                        FirstName.Text = Table.Rows(0)("FirstName").ToString()
                        LastName.Text = Table.Rows(0)("LastName").ToString()
                        Email.Text = Table.Rows(0)("Email").ToString()
                        ViewState.Add("Id", Id)
                    End Using
                End Using
            End Using
        End Using
    End Sub
    Protected Sub UserUpdate_Click(sender As Object, e As EventArgs)
        Dim constring As String = "Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=aspnet-Webforms_sandbox-42248daf-5cf0-48f3-a045-60197dd8fe8f;AttachDbFilename=|DataDirectory|\aspnet-Webforms_sandbox-42248daf-5cf0-48f3-a045-60197dd8fe8f.mdf;Integrated Security=SSPI"
        Using con As New SqlConnection(constring)
            Using cmd As New SqlCommand("UPDATE [aspnet-Webforms_sandbox-42248daf-5cf0-48f3-a045-60197dd8fe8f].[dbo].[AspNetUsers] SET [UserName] = @UserName, [FirstName] = @FirstName, [LastName] = @LastName, [Email] = @Email WHERE Id = @Id", con)
                cmd.Parameters.Add(New SqlParameter("@Id", SqlDbType.VarChar)).Value = ViewState("Id")
                cmd.Parameters.Add(New SqlParameter("@UserName", SqlDbType.VarChar)).Value = UserName.Text
                cmd.Parameters.Add(New SqlParameter("@FirstName", SqlDbType.VarChar)).Value = FirstName.Text
                cmd.Parameters.Add(New SqlParameter("@LastName", SqlDbType.VarChar)).Value = LastName.Text
                cmd.Parameters.Add(New SqlParameter("@Email", SqlDbType.VarChar)).Value = Email.Text
                cmd.CommandType = CommandType.Text
                cmd.Connection.Open()
                Dim Response = cmd.ExecuteNonQuery()
                cmd.Dispose()
            End Using
        End Using
    End Sub

End Class
