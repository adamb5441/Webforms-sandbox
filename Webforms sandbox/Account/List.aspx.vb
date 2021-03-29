Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Partial Class Account_List
    Inherits Page

    Private Property Persons() As DataTable
        Get
            Return If(ViewState("Persons") IsNot Nothing, DirectCast(ViewState("Persons"), DataTable), Nothing)
        End Get
        Set(value As DataTable)
            ViewState("Persons") = value
        End Set
    End Property


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindListView()
        End If
    End Sub


    Protected Sub OnItemEditing(sender As Object, e As ListViewEditEventArgs)
        ListView1.EditIndex = e.NewEditIndex
        BindListView()
    End Sub


    Protected Sub OnItemUpdating(sender As Object, e As ListViewUpdateEventArgs)
        Dim name As String = TryCast(ListView1.Items(e.ItemIndex).FindControl("lblName"), Label).Text
        Dim country As String = TryCast(ListView1.Items(e.ItemIndex).FindControl("ddlCountries"), DropDownList).SelectedItem.Value
        For Each row As DataRow In Persons.Rows
            If row("Name").ToString() = name Then
                row("Country") = country
                Exit For
            End If
        Next
        ListView1.EditIndex = -1
        BindListView()
    End Sub

    Protected Sub OnItemCanceling(sender As Object, e As ListViewCancelEventArgs)
        ListView1.EditIndex = -1
        BindListView()
    End Sub

    Private Sub BindListView()
        Dim constring As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using con As New SqlConnection(constring)
            Using cmd As New SqlCommand("SELECT [Id], [UserName], [FirstName], [LastName] [Email], [PhoneNumber] FROM [aspnet-Webforms_sandbox-42248daf-5cf0-48f3-a045-60197dd8fe8f].[dbo].[AspNetUsers]", con)
                Dim dt As DataTable = Persons
                If dt Is Nothing Then
                    dt = New DataTable()
                    dt.Columns.AddRange(New DataColumn(6) {
                                        New DataColumn("Id"),
                                        New DataColumn("UserName"),
                                        New DataColumn("FirstName"),
                                        New DataColumn("LastName"),
                                        New DataColumn("Email"),
                                        New DataColumn("Link"),
                                        New DataColumn("PhoneNumber")
                                        })
                    cmd.CommandType = CommandType.Text
                    Using sda As New SqlDataAdapter(cmd)
                        Using ds As New DataSet()
                            sda.Fill(ds)
                            Dim Table = ds.Tables(0)
                            For Each row In Table.Rows
                                dt.Rows.Add(
                                        row.ItemArray(0),
                                        row.ItemArray(1),
                                        row.ItemArray(2),
                                        row.ItemArray(3),
                                        row.ItemArray(4),
                                        "/Account/Update/" + row.ItemArray(0).ToString()
                                    )
                            Next
                            System.Diagnostics.Debug.WriteLine("hi")
                        End Using
                    End Using
                End If
                ListView1.DataSource = dt
                ListView1.DataBind()
            End Using
        End Using
    End Sub

End Class
