Public Class Category
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("SearchString") <> "" Then
            SqlDSProductList.SelectCommand = "Select * From Product Where ProductName Like '%" & Request.QueryString("SearchString") & "%'"
            SqlDSProductList.DataBind()
            'handle the lblProductList
        Else
            If Request.QueryString("MainCategoryID") <> "" Then
                dynamicTitle.InnerHtml = Request.QueryString("MainCategoryName")
                lblMainCategoryName.Text = Request.QueryString("MainCategoryName")
                metaKeywords.Attributes.Item("content") = "keyword1, keyword2, keyword3, …"
                metaDescription.Attributes.Item("content") = "Description…”
                sqlDSSubCategory.SelectCommand = "Select * From Category Where Parent = " & CInt(Request.QueryString("MainCategoryID"))
                SqlDSProductList.SelectCommand = "Select * From Product Where MainCategoryID = " & CInt(Request.QueryString("MainCategoryID")) & " And Featured = 'Y'"
                SqlDSProductList.DataBind()
                If Request.QueryString("SubCategoryID") <> "" Then
                    lblProductList.Text = "Product List for: " & Request.QueryString("SubCategoryName")
                    SqlDSProductList.SelectCommand = "Select * From Product Where SubCategoryID = " & Int(Request.QueryString("SubCategoryID"))
                    SqlDSProductList.DataBind()
                End If
            ElseIf Request.QueryString("SubCategoryID") <> "" Then
                dynamicTitle.InnerHtml = Request.QueryString("SubCategoryName")
                metaKeywords.Attributes.Item("content") = "keyword1, keyword2, keyword3, …"
                metaDescription.Attributes.Item("content") = "Description…”


            End If
        End If
    End Sub

    Function ApplyDiscount(originalPrice As Double) As Double
        If (Session("Username") IsNot Nothing) Then
            Return originalPrice
        Else
            Return originalPrice * 0.8
        End If


    End Function


End Class