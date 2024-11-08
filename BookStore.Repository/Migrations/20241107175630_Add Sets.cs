using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_AspNetUsers_CreatedById",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInOrder_Book_BookId",
                table: "BookInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInOrder_Order_OrderId",
                table: "BookInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInShoppingCart_Book_BookId",
                table: "BookInShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInShoppingCart_ShoppingCart_ShoppingCartId",
                table: "BookInShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_OwnerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_OwnerId",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookInShoppingCart",
                table: "BookInShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookInOrder",
                table: "BookInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                newName: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "BookInShoppingCart",
                newName: "BooksInShoppingCarts");

            migrationBuilder.RenameTable(
                name: "BookInOrder",
                newName: "BooksInOrders");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_OwnerId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_OwnerId",
                table: "Orders",
                newName: "IX_Orders_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_BookInShoppingCart_ShoppingCartId",
                table: "BooksInShoppingCarts",
                newName: "IX_BooksInShoppingCarts_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_BookInShoppingCart_BookId",
                table: "BooksInShoppingCarts",
                newName: "IX_BooksInShoppingCarts_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookInOrder_OrderId",
                table: "BooksInOrders",
                newName: "IX_BooksInOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_BookInOrder_BookId",
                table: "BooksInOrders",
                newName: "IX_BooksInOrders_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_CreatedById",
                table: "Books",
                newName: "IX_Books_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AuthorId",
                table: "Books",
                newName: "IX_Books_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksInShoppingCarts",
                table: "BooksInShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksInOrders",
                table: "BooksInOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_CreatedById",
                table: "Books",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Author_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksInOrders_Books_BookId",
                table: "BooksInOrders",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksInOrders_Orders_OrderId",
                table: "BooksInOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksInShoppingCarts_Books_BookId",
                table: "BooksInShoppingCarts",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksInShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "BooksInShoppingCarts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_OwnerId",
                table: "Orders",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_OwnerId",
                table: "ShoppingCarts",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_CreatedById",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Author_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksInOrders_Books_BookId",
                table: "BooksInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksInOrders_Orders_OrderId",
                table: "BooksInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksInShoppingCarts_Books_BookId",
                table: "BooksInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksInShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "BooksInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OwnerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_OwnerId",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksInShoppingCarts",
                table: "BooksInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksInOrders",
                table: "BooksInOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "BooksInShoppingCarts",
                newName: "BookInShoppingCart");

            migrationBuilder.RenameTable(
                name: "BooksInOrders",
                newName: "BookInOrder");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_OwnerId",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OwnerId",
                table: "Order",
                newName: "IX_Order_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_BooksInShoppingCarts_ShoppingCartId",
                table: "BookInShoppingCart",
                newName: "IX_BookInShoppingCart_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_BooksInShoppingCarts_BookId",
                table: "BookInShoppingCart",
                newName: "IX_BookInShoppingCart_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BooksInOrders_OrderId",
                table: "BookInOrder",
                newName: "IX_BookInOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_BooksInOrders_BookId",
                table: "BookInOrder",
                newName: "IX_BookInOrder_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CreatedById",
                table: "Book",
                newName: "IX_Book_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorId",
                table: "Book",
                newName: "IX_Book_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookInShoppingCart",
                table: "BookInShoppingCart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookInOrder",
                table: "BookInOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_AspNetUsers_CreatedById",
                table: "Book",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInOrder_Book_BookId",
                table: "BookInOrder",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInOrder_Order_OrderId",
                table: "BookInOrder",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInShoppingCart_Book_BookId",
                table: "BookInShoppingCart",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInShoppingCart_ShoppingCart_ShoppingCartId",
                table: "BookInShoppingCart",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_OwnerId",
                table: "Order",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_OwnerId",
                table: "ShoppingCart",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
