<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Category.aspx.vb" Inherits="OnlineStoreFall2023.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<meta id="metaDescription" runat="server" name="Description" />
	<meta id="metaKeywords" runat="server" name="keywords" />
	<title id="dynamicTitle" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="col-sm-3">
		<div class="left-sidebar">
			<h2><asp:Label ID="lblMainCategoryName" runat="server" Text=""></asp:Label></h2>
			<div class="panel-group category-products" id="accordian"><!--category-productsr-->
                <asp:SqlDataSource ID="sqlDSSubCategory" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringOnlineStore %>" SelectCommand=""></asp:SqlDataSource>
	            <asp:Repeater ID="rpSubCategory" runat="server" DataSourceID="SqlDSSubCategory">
		            <ItemTemplate>
 				        <div class="panel panel-default">
					        <div class="panel-heading">
						        <h4 class="panel-title"><a href="Category.aspx?MainCategoryID=<%# Request.QueryString("MainCategoryID") %>&MainCategoryName=<%# Trim(Request.QueryString("MainCategoryName")) %>&SubCategoryId=<%# Eval("CategoryID") %>&SubCategoryName=<%# Eval("CategoryName") %>"><%# Trim(Eval("CategoryName")) %></a></h4>
					        </div>
				        </div>                       
			        </ItemTemplate>
	            </asp:Repeater> 
			</div><!--/category-productsr-->										
		</div>
	</div>
				
	<div class="col-sm-9 padding-right">
		<div class="features_items"><!--features_items-->
			<h2 class="title text-center"><asp:Label ID="lblProductList" runat="server" Text="Featured Product"></asp:Label></h2>
                <asp:SqlDataSource ID="SqlDSProductList" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringOnlineStore %>" SelectCommand=""></asp:SqlDataSource>
	            <asp:Repeater ID="rpProductList" runat="server" DataSourceID="SqlDSProductList">
		            <ItemTemplate>
						<div class="col-sm-4">
							<div class="product-image-wrapper">
								<div class="single-products">
									<div class="productinfo text-center">
										<img src='<%# "/images/pictures/" + Trim(Eval("ProductNo")) + ".jpg" %>' alt="Placeholder">
										<h2>$<%# ApplyDiscount( Eval("Price")) %></h2>
										<p><%# Trim(Eval("ProductName")) %><br /><%# Eval("ProductNo") %></p>
										<a href="ProductDetails.aspx?ProductID=<%# Eval("ProductID") %>" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>View Details</a>
									</div>
								</div>
								<div class="choose">
									<ul class="nav nav-pills nav-justified">
										<li><a href=""><i class="fa fa-plus-square"></i>Add to wishlist</a></li>
										<li><a href=""><i class="fa fa-plus-square"></i>Add to compare</a></li>
									</ul>
								</div>
							</div>
						</div>                   
			        </ItemTemplate>
	            </asp:Repeater> 

						
				<ul class="pagination">
					<li class="active"><a href="">1</a></li>
					<li><a href="">2</a></li>
					<li><a href="">3</a></li>
					<li><a href="">&raquo;</a></li>
				</ul>
			</div><!--features_items-->
	</div>
</asp:Content>
