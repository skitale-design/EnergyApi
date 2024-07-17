using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EnergyApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "RaschetnyPriborUchetas",
                columns: table => new
                {
                    RaschetnyPriborUchetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TochkaPostavkisId = table.Column<int>(type: "int", nullable: false),
                    TochkaIzmereniyasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaschetnyPriborUchetas", x => x.RaschetnyPriborUchetaId);
                });

            migrationBuilder.CreateTable(
                name: "SubOrganizations",
                columns: table => new
                {
                    SubOrganizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubOrganizations", x => x.SubOrganizationId);
                    table.ForeignKey(
                        name: "FK_SubOrganizations_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectPotrebleniyas",
                columns: table => new
                {
                    ObjectPotrebleniyaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubOrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectPotrebleniyas", x => x.ObjectPotrebleniyaId);
                    table.ForeignKey(
                        name: "FK_ObjectPotrebleniyas_SubOrganizations_SubOrganizationId",
                        column: x => x.SubOrganizationId,
                        principalTable: "SubOrganizations",
                        principalColumn: "SubOrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointPostavkis",
                columns: table => new
                {
                    TochkaPostavkiId = table.Column<int>(type: "int", nullable: false),
                    MaxPower = table.Column<float>(type: "real", nullable: false),
                    ObjectPotrebleniyaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointPostavkis", x => x.TochkaPostavkiId);
                    table.ForeignKey(
                        name: "FK_PointPostavkis_ObjectPotrebleniyas_ObjectPotrebleniyaId",
                        column: x => x.ObjectPotrebleniyaId,
                        principalTable: "ObjectPotrebleniyas",
                        principalColumn: "ObjectPotrebleniyaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PointPostavkis_RaschetnyPriborUchetas_TochkaPostavkiId",
                        column: x => x.TochkaPostavkiId,
                        principalTable: "RaschetnyPriborUchetas",
                        principalColumn: "RaschetnyPriborUchetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TochkaIzmereniyas",
                columns: table => new
                {
                    TochkaIzmereniyaId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectPotrebleniyaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TochkaIzmereniyas", x => x.TochkaIzmereniyaId);
                    table.ForeignKey(
                        name: "FK_TochkaIzmereniyas_ObjectPotrebleniyas_ObjectPotrebleniyaId",
                        column: x => x.ObjectPotrebleniyaId,
                        principalTable: "ObjectPotrebleniyas",
                        principalColumn: "ObjectPotrebleniyaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TochkaIzmereniyas_RaschetnyPriborUchetas_TochkaIzmereniyaId",
                        column: x => x.TochkaIzmereniyaId,
                        principalTable: "RaschetnyPriborUchetas",
                        principalColumn: "RaschetnyPriborUchetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schetchiks",
                columns: table => new
                {
                    SchetchikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    SchType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePoverki = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TochkaIzmereniyaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schetchiks", x => x.SchetchikId);
                    table.ForeignKey(
                        name: "FK_Schetchiks_TochkaIzmereniyas_TochkaIzmereniyaId",
                        column: x => x.TochkaIzmereniyaId,
                        principalTable: "TochkaIzmereniyas",
                        principalColumn: "TochkaIzmereniyaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransformatorNapryazheniyas",
                columns: table => new
                {
                    TransformatorNapryazheniyaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    TnType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePoverki = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KTN = table.Column<int>(type: "int", nullable: false),
                    TochkaIzmereniyaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransformatorNapryazheniyas", x => x.TransformatorNapryazheniyaId);
                    table.ForeignKey(
                        name: "FK_TransformatorNapryazheniyas_TochkaIzmereniyas_TochkaIzmereniyaId",
                        column: x => x.TochkaIzmereniyaId,
                        principalTable: "TochkaIzmereniyas",
                        principalColumn: "TochkaIzmereniyaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransformatorTokas",
                columns: table => new
                {
                    TransformatorTokaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    TtType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePoverki = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KTT = table.Column<int>(type: "int", nullable: false),
                    TochkaIzmereniyaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransformatorTokas", x => x.TransformatorTokaId);
                    table.ForeignKey(
                        name: "FK_TransformatorTokas_TochkaIzmereniyas_TochkaIzmereniyaId",
                        column: x => x.TochkaIzmereniyaId,
                        principalTable: "TochkaIzmereniyas",
                        principalColumn: "TochkaIzmereniyaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationId", "Address", "Name" },
                values: new object[] { 1, "г. Электроугли, Электродный проезд, дом 1", "ЗАО Электроовцы" });

            migrationBuilder.InsertData(
                table: "RaschetnyPriborUchetas",
                columns: new[] { "RaschetnyPriborUchetaId", "TochkaIzmereniyasId", "TochkaPostavkisId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "SubOrganizations",
                columns: new[] { "SubOrganizationId", "Address", "Name", "OrganizationId" },
                values: new object[,]
                {
                    { 1, "пос. Заветы Ильича, проспект Электрификации, дом 2", "ООО ЭлектроРога", 1 },
                    { 2, "пос. Заветы Ильича, ул. Советская, дом 14", "ОАО ЭлектроКопыта", 1 }
                });

            migrationBuilder.InsertData(
                table: "ObjectPotrebleniyas",
                columns: new[] { "ObjectPotrebleniyaId", "Address", "Name", "SubOrganizationId" },
                values: new object[,]
                {
                    { 1, "ул. Динамо, дом 1", "Объект потребления 1", 1 },
                    { 2, "ул. Динамо, дом 2", "Объект потребления 2", 1 },
                    { 3, "ул. Динамо, дом 3", "Объект потребления 3", 2 },
                    { 4, "ул. Динамо, дом 4", "Объект потребления 4", 2 }
                });

            migrationBuilder.InsertData(
                table: "PointPostavkis",
                columns: new[] { "TochkaPostavkiId", "MaxPower", "ObjectPotrebleniyaId" },
                values: new object[,]
                {
                    { 1, 300f, 1 },
                    { 2, 300f, 2 },
                    { 3, 300f, 3 },
                    { 4, 300f, 4 }
                });

            migrationBuilder.InsertData(
                table: "TochkaIzmereniyas",
                columns: new[] { "TochkaIzmereniyaId", "Name", "ObjectPotrebleniyaId" },
                values: new object[,]
                {
                    { 1, "Точка Измерения 1", 1 },
                    { 2, "Точка Измерения 2", 2 },
                    { 3, "Точка Измерения 3", 3 },
                    { 4, "Точка Измерения 4", 4 }
                });

            migrationBuilder.InsertData(
                table: "Schetchiks",
                columns: new[] { "SchetchikId", "DatePoverki", "Number", "SchType", "TochkaIzmereniyaId" },
                values: new object[,]
                {
                    { 1, new DateTime(2011, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "стандартный", 1 },
                    { 2, new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "стандартный", 2 },
                    { 3, new DateTime(2013, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "стандартный", 3 },
                    { 4, new DateTime(2018, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "стандартный", 4 }
                });

            migrationBuilder.InsertData(
                table: "TransformatorNapryazheniyas",
                columns: new[] { "TransformatorNapryazheniyaId", "DatePoverki", "KTN", "Number", "TnType", "TochkaIzmereniyaId" },
                values: new object[,]
                {
                    { 1, new DateTime(2011, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 1, "", 1 },
                    { 2, new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 2, "", 2 },
                    { 3, new DateTime(2013, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 3, "", 3 },
                    { 4, new DateTime(2014, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 4, "", 4 }
                });

            migrationBuilder.InsertData(
                table: "TransformatorTokas",
                columns: new[] { "TransformatorTokaId", "DatePoverki", "KTT", "Number", "TochkaIzmereniyaId", "TtType" },
                values: new object[,]
                {
                    { 1, new DateTime(2011, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 11, 1, "" },
                    { 2, new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 21, 2, "" },
                    { 3, new DateTime(2013, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 31, 3, "" },
                    { 4, new DateTime(2014, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, 41, 4, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectPotrebleniyas_SubOrganizationId",
                table: "ObjectPotrebleniyas",
                column: "SubOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_PointPostavkis_ObjectPotrebleniyaId",
                table: "PointPostavkis",
                column: "ObjectPotrebleniyaId");

            migrationBuilder.CreateIndex(
                name: "IX_Schetchiks_TochkaIzmereniyaId",
                table: "Schetchiks",
                column: "TochkaIzmereniyaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubOrganizations_OrganizationId",
                table: "SubOrganizations",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_TochkaIzmereniyas_ObjectPotrebleniyaId",
                table: "TochkaIzmereniyas",
                column: "ObjectPotrebleniyaId");

            migrationBuilder.CreateIndex(
                name: "IX_TransformatorNapryazheniyas_TochkaIzmereniyaId",
                table: "TransformatorNapryazheniyas",
                column: "TochkaIzmereniyaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransformatorTokas_TochkaIzmereniyaId",
                table: "TransformatorTokas",
                column: "TochkaIzmereniyaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointPostavkis");

            migrationBuilder.DropTable(
                name: "Schetchiks");

            migrationBuilder.DropTable(
                name: "TransformatorNapryazheniyas");

            migrationBuilder.DropTable(
                name: "TransformatorTokas");

            migrationBuilder.DropTable(
                name: "TochkaIzmereniyas");

            migrationBuilder.DropTable(
                name: "ObjectPotrebleniyas");

            migrationBuilder.DropTable(
                name: "RaschetnyPriborUchetas");

            migrationBuilder.DropTable(
                name: "SubOrganizations");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
