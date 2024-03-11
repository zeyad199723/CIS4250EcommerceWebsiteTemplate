Imports System.Data
Imports System.Data.SqlClient


Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        Dim strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString
        Dim connCustomer As SqlConnection
        Dim cmdCustomer As SqlCommand
        Dim drCustomer As SqlDataReader
        Dim strSQL As String = "Select * from Customer Where Username= '" & Trim(tbUsername.Text) & "' and Password = '" & Trim(tbPassword.Text) & "'"
        connCustomer = New SqlConnection(strConn)
        cmdCustomer = New SqlCommand(strSQL, connCustomer)
        connCustomer.Open()
        drCustomer = cmdCustomer.ExecuteReader(CommandBehavior.CloseConnection)
        If drCustomer.Read() Then
            Session("Username") = drCustomer.Item("Username")
            Response.Redirect("Default.aspx")
        Else
            lblMessage.Text = "Login Failed."
            tbUsername.Text = ""
            tbPassword.Text = ""
        End If
    End Sub
End Class