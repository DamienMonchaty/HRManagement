using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.Web.Migrations
{
    public partial class init13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_AspNetUsers_UserId1",
                table: "UserProject");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_Projects_ProjectId1",
                table: "UserProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProject",
                table: "UserProject");

            migrationBuilder.DropIndex(
                name: "IX_UserProject_ProjectId1",
                table: "UserProject");

            migrationBuilder.DropIndex(
                name: "IX_UserProject_UserId1",
                table: "UserProject");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "UserProject");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserProject");

            migrationBuilder.RenameTable(
                name: "UserProject",
                newName: "UserProjects");

            migrationBuilder.RenameColumn(
                name: "PositionEnum",
                table: "Projects",
                newName: "ProjectEnum");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "UserProjects",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserProjects",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProjects",
                table: "UserProjects",
                columns: new[] { "UserId", "ProjectId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "20a62299-a776-4082-a08c-f0f10ed14ae2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "bfe6609e-e382-4e35-88f2-8bea8e06a4f5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4218d6a4-31f3-46f0-abcb-4885d656c9ba", "AQAAAAEAACcQAAAAEJqXyd7qAtKH/r0RMFyTHB9NNHZ9LeAXBirZmiGkCXbcbeyPzR7n54ZZUotWj3XAgg==", "d9d3502d-5b23-49b2-8e25-40f6b8801b4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2310ee2b-5fcf-4550-bf94-4746edb5e909", "AQAAAAEAACcQAAAAENIZXMsYqK814QhD5j0zXMGuRLhhvv+3vJ1WflpqlMvktBIH8n41VrA57QUD0vnstg==", "d921287f-c686-4f75-9bb0-c9703f4c3b60" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { "B22699V4-42A2-4666-9631-1D9D1E2QE4F7", "DESC CLIENT1", "CLIENT1" },
                    { "C4469D48-89A2-3615-9631-1C2D1E2AC/&7", "DESC CLIENT2", "CLIENT2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_ProjectId",
                table: "UserProjects",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjects_AspNetUsers_UserId",
                table: "UserProjects",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjects_Projects_ProjectId",
                table: "UserProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProjects_AspNetUsers_UserId",
                table: "UserProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProjects_Projects_ProjectId",
                table: "UserProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProjects",
                table: "UserProjects");

            migrationBuilder.DropIndex(
                name: "IX_UserProjects_ProjectId",
                table: "UserProjects");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "B22699V4-42A2-4666-9631-1D9D1E2QE4F7");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "C4469D48-89A2-3615-9631-1C2D1E2AC/&7");

            migrationBuilder.RenameTable(
                name: "UserProjects",
                newName: "UserProject");

            migrationBuilder.RenameColumn(
                name: "ProjectEnum",
                table: "Projects",
                newName: "PositionEnum");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "UserProject",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserProject",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ProjectId1",
                table: "UserProject",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserProject",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProject",
                table: "UserProject",
                columns: new[] { "UserId", "ProjectId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "25ccdf88-7ae9-454c-a822-667563ee5282");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "dad15254-15b0-499e-8136-4080610d7331");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a26e6915-3ae7-461e-b378-0020dd68a91f", "AQAAAAEAACcQAAAAELewJZVaOjxO67o/o+UFJvbPNpLpexaOFubAg0KkeeGyV4DUIF8ZM3QsVxdoSYFSfA==", "0ce361b9-2465-4db4-99a0-7fddde42093f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ede676e-ccf3-4c13-9dd6-c74efb13a269", "AQAAAAEAACcQAAAAEJaTymgOu4zpdsA+kkaWHufLcBuH/SPYXgFeDshq31fbFgMfnsgHr2EHH7LSaB7rrQ==", "d5c7baef-7f76-4dc7-8ec4-f7bfa61dc98a" });

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_ProjectId1",
                table: "UserProject",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_UserId1",
                table: "UserProject",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_AspNetUsers_UserId1",
                table: "UserProject",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_Projects_ProjectId1",
                table: "UserProject",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
