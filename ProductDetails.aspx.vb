Imports System.Data
Imports System.Data.SqlClient
Public Class ProductDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("ProductID") <> "" Then
            Dim strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString
            Dim connProduct As SqlConnection
            Dim cmdProduct As SqlCommand
            Dim drProduct As SqlDataReader
            Dim strSQL As String = "Select * from Product Where ProductID = '" & Request.QueryString("ProductID") & "'"
            connProduct = New SqlConnection(strConn)
            cmdProduct = New SqlCommand(strSQL, connProduct)
            connProduct.Open()
            drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)
            If drProduct.Read() Then
                lblProductName.Text = drProduct.Item("ProductName")
                lblProductNo.Text = drProduct.Item("ProductNo")
                lblProductPrice.Text = drProduct.Item("Price")

                If (Session("Username") IsNot Nothing) Then
                    lblProductPrice.Text = drProduct.Item("Price")
                Else
                    Dim discountedPrice As Decimal = drProduct.Item("Price") * 0.8
                    lblProductPrice.Text = discountedPrice.ToString()
                End If
                imgLargeProductImage.ImageUrl = "/images/pictures/Large" + Trim(drProduct.Item("ProductNo")) + ".jpg"
            Else

            End If
        End If
    End Sub

    Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
        '*** get cartNo
        Dim strCartNo As String
        If HttpContext.Current.Request.Cookies("CartNo") Is Nothing Then
            strCartNo = GetRandomCartNoUsingGUID(10)
            Dim CookieTo As New HttpCookie("CartNo", strCartNo)
            HttpContext.Current.Response.AppendCookie(CookieTo)
        Else
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartNo")
            strCartNo = CookieBack.Value
        End If
        'set up ado objects and variabels
        Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString
        Dim conn As New SqlConnection(strConnectionString)
        Dim drCheck As SqlDataReader
        Dim strSQLStatement As String
        Dim cmdSQL As SqlCommand

        'get product price
        strSQLStatement = "Select * From product Where ProductID = '" & Request.QueryString("ProductID") & "'"
        cmdSQL = New SqlCommand(strSQLStatement, conn)
        conn.Open()
        drCheck = cmdSQL.ExecuteReader
        Dim decPrice As Decimal
        If drCheck.Read() Then
            decPrice = drCheck.Item("Price")
        End If
        drCheck.Close()

        'check if this product already exist in the cart
        strSQLStatement = "SELECT * FROM Cart WHERE CartNo = '" & strCartNo & "' and ProductNo = '" & Trim(lblProductNo.Text) & "'"
        cmdSQL.CommandText = strSQLStatement
        drCheck = cmdSQL.ExecuteReader()
        If drCheck.Read() Then
            'update quantity here

        Else
            'add the product
            strSQLStatement = "INSERT INTO Cart (CartNo, ProductNo, ProductName, Quantity, Price) values('" & strCartNo & "', '" & lblProductNo.Text & "', '" & lblProductName.Text & "', " & CInt(tbQuantity.Text) & ", " & decPrice & ")"
        End If
        drCheck.Close() 'when the DataReader is open, its connection is dedicated to its assosicated SQL
        cmdSql.CommandText = strSQLStatement
        Dim drCart = cmdSQL.ExecuteReader(CommandBehavior.CloseConnection)
        Response.Redirect("ViewCart1.aspx")

    End Sub

    Public Function GetRandomCartNoUsingGUID(ByVal length As Integer) As String

        Dim guidResult As String = System.Guid.NewGuid().ToString()

        guidResult = guidResult.Replace("-", String.Empty)

        If length <= 0 OrElse length > guidResult.Length Then
            Throw New ArgumentException("Length must be between 1 and " & guidResult.Length)
        End If
        Return guidResult.Substring(0, length)

    End Function
End Class