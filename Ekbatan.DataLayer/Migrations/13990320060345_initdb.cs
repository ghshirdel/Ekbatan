using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ekbatan.DataLayer.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CName = table.Column<string>(maxLength: 100, nullable: false),
                    CFamily = table.Column<string>(maxLength: 150, nullable: false),
                    MelliCode = table.Column<string>(maxLength: 10, nullable: false),
                    SHNo = table.Column<int>(maxLength: 10, nullable: true),
                    Phone = table.Column<string>(maxLength: 100, nullable: true),
                    MobilePhone = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_ID);
                });

            migrationBuilder.CreateTable(
                name: "FrontAges",
                columns: table => new
                {
                    FrontAge_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FrontAge_Desc = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontAges", x => x.FrontAge_ID);
                });

            migrationBuilder.CreateTable(
                name: "ImageTypes",
                columns: table => new
                {
                    ImageType_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageType_desc = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageTypes", x => x.ImageType_ID);
                });

            migrationBuilder.CreateTable(
                name: "Karbaris",
                columns: table => new
                {
                    Karbari_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Karbari_Desc = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karbaris", x => x.Karbari_ID);
                });

            migrationBuilder.CreateTable(
                name: "MContracts",
                columns: table => new
                {
                    Contract_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Contract_No = table.Column<string>(maxLength: 200, nullable: false),
                    Contract_Date = table.Column<DateTime>(nullable: false),
                    Mel_ID = table.Column<int>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MContracts", x => x.Contract_ID);
                });

            migrationBuilder.CreateTable(
                name: "MelkPositions",
                columns: table => new
                {
                    MelkPosition_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MelkPosition_Desc = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MelkPositions", x => x.MelkPosition_ID);
                });

            migrationBuilder.CreateTable(
                name: "MelkTypes",
                columns: table => new
                {
                    MelkType_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeMelk_Desc = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MelkTypes", x => x.MelkType_ID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Project_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Project_name = table.Column<string>(maxLength: 100, nullable: false),
                    Parv_Date = table.Column<DateTime>(nullable: true),
                    PStart_Date = table.Column<DateTime>(nullable: true),
                    PEnd_Date = table.Column<DateTime>(nullable: true),
                    Payan_Date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Project_ID);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Image_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageType_ID = table.Column<int>(nullable: false),
                    Object_ID = table.Column<int>(nullable: false),
                    ImageName = table.Column<string>(nullable: true),
                    Image_Desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Image_ID);
                    table.ForeignKey(
                        name: "FK_Images_ImageTypes_ImageType_ID",
                        column: x => x.ImageType_ID,
                        principalTable: "ImageTypes",
                        principalColumn: "ImageType_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubContracts",
                columns: table => new
                {
                    SubContract_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Melk_ID = table.Column<int>(nullable: false),
                    Customer_ID = table.Column<int>(nullable: false),
                    Sahm = table.Column<float>(nullable: false),
                    MContractContract_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubContracts", x => x.SubContract_ID);
                    table.ForeignKey(
                        name: "FK_SubContracts_MContracts_MContractContract_ID",
                        column: x => x.MContractContract_ID,
                        principalTable: "MContracts",
                        principalColumn: "Contract_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Melks",
                columns: table => new
                {
                    Melk_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Project_ID = table.Column<int>(nullable: false),
                    MelkType_ID = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    ShPosition = table.Column<int>(nullable: true),
                    MelkPosition_ID = table.Column<int>(nullable: true),
                    PAsli = table.Column<string>(nullable: true),
                    PFarei = table.Column<string>(nullable: true),
                    MArseh = table.Column<double>(nullable: true),
                    MAyan = table.Column<double>(nullable: true),
                    Karbari_ID = table.Column<int>(nullable: false),
                    CFloor = table.Column<int>(nullable: true),
                    NFloor = table.Column<int>(nullable: true),
                    FrontAge_ID = table.Column<int>(nullable: true),
                    Balkon = table.Column<bool>(nullable: false),
                    Anbari = table.Column<bool>(nullable: false),
                    MAnbari = table.Column<float>(nullable: true),
                    Parking = table.Column<bool>(nullable: false),
                    Elevator = table.Column<bool>(nullable: false),
                    Contract_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Melks", x => x.Melk_ID);
                    table.ForeignKey(
                        name: "FK_Melks_FrontAges_FrontAge_ID",
                        column: x => x.FrontAge_ID,
                        principalTable: "FrontAges",
                        principalColumn: "FrontAge_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Melks_Karbaris_Karbari_ID",
                        column: x => x.Karbari_ID,
                        principalTable: "Karbaris",
                        principalColumn: "Karbari_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Melks_MelkPositions_MelkPosition_ID",
                        column: x => x.MelkPosition_ID,
                        principalTable: "MelkPositions",
                        principalColumn: "MelkPosition_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Melks_MelkTypes_MelkType_ID",
                        column: x => x.MelkType_ID,
                        principalTable: "MelkTypes",
                        principalColumn: "MelkType_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Melks_Projects_Project_ID",
                        column: x => x.Project_ID,
                        principalTable: "Projects",
                        principalColumn: "Project_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageType_ID",
                table: "Images",
                column: "ImageType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Melks_FrontAge_ID",
                table: "Melks",
                column: "FrontAge_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Melks_Karbari_ID",
                table: "Melks",
                column: "Karbari_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Melks_MelkPosition_ID",
                table: "Melks",
                column: "MelkPosition_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Melks_MelkType_ID",
                table: "Melks",
                column: "MelkType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Melks_Project_ID",
                table: "Melks",
                column: "Project_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubContracts_MContractContract_ID",
                table: "SubContracts",
                column: "MContractContract_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Melks");

            migrationBuilder.DropTable(
                name: "SubContracts");

            migrationBuilder.DropTable(
                name: "ImageTypes");

            migrationBuilder.DropTable(
                name: "FrontAges");

            migrationBuilder.DropTable(
                name: "Karbaris");

            migrationBuilder.DropTable(
                name: "MelkPositions");

            migrationBuilder.DropTable(
                name: "MelkTypes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "MContracts");
        }
    }
}
