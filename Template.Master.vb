Imports System.Data
Imports System.Data.SqlClient
Public Class Template
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString
        Dim connMainCategory As SqlConnection
        Dim cmdMainCategory As SqlCommand
        Dim drMainCategory As SqlDataReader
        Dim strSQL As String = "Select * from Category Where Parent = 0"
        connMainCategory = New SqlConnection(strConn)
        cmdMainCategory = New SqlCommand(strSQL, connMainCategory)
        connMainCategory.Open()
        drMainCategory = cmdMainCategory.ExecuteReader(CommandBehavior.CloseConnection)
        Dim strMainCategory As String = ""
        Do While drMainCategory.Read()
            strMainCategory = strMainCategory + "<li><a href=''>" + Trim(drMainCategory.Item("CategoryName")) + "</a></li>"
        Loop
        lblMainCategory.Text = strMainCategory
        If Session("Username") <> "" Then
            hrefUsername.InnerHtml = Session("Username")
            hrefCustomer.InnerText = Session("Email")
            hlLogIn.Visible = False
            hlLogOut.Visible = True
            hrefUsername.Visible = False

        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim strSearchString As String = Trim(tbSearchString.Text)
        Dim strSpace As String = " "
        'If InStr(strSearchString, " ") <> True Then
        If strSearchString.Contains(strSpace) <> True Then
            Dim strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString
            Dim connProduct As SqlConnection
            Dim cmdProduct As SqlCommand
            Dim drProduct As SqlDataReader
            Dim strSQL As String = "Select * from Product Where ProductNo = '" & strSearchString & "'"
            'Dim strSQL As String = "Select * from Product Where ProductID = " & CInt(strSearchString)
            connProduct = New SqlConnection(strConn)
            cmdProduct = New SqlCommand(strSQL, connProduct)
            connProduct.Open()
            drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)
            If drProduct.Read() Then
                Dim strProductDetailURL As String = "ProductDetails.aspx?ProductNo=" + strSearchString
                'Dim strProductDetailURL As String = "ProductDetails.aspx?ProductID='" & strSearchString & "'"
                Response.Redirect(strProductDetailURL)
            Else
                Dim strProductListURL As String = "Category.aspx?SearchString=" + strSearchString
                Response.Redirect(strProductListURL)

            End If
            'Response.Write(strSearchString)
        Else
            Dim strProductListURL As String = "Category.aspx?SearchString=" + strSearchString
            Response.Redirect(strProductListURL)
        End If


    End Sub
End Class