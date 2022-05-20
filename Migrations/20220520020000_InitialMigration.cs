using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueBird.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectorData",
                columns: table => new
                {
                    SectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorData", x => x.SectorId);
                    table.ForeignKey(
                        name: "FK_SectorData_SectorData_ParentId",
                        column: x => x.ParentId,
                        principalTable: "SectorData",
                        principalColumn: "SectorId");
                });

            migrationBuilder.CreateTable(
                name: "UserFormFilling",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAgreedToTerms = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFormFilling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    SectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserFormFillingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.SectorId);
                    table.ForeignKey(
                        name: "FK_Sector_UserFormFilling_UserFormFillingId",
                        column: x => x.UserFormFillingId,
                        principalTable: "UserFormFilling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SectorData",
                columns: new[] { "SectorId", "Name", "ParentId", "Value" },
                values: new object[] { new Guid("62528f0d-0e87-4b3b-b1ef-e5106ee79bcd"), "Manufacturing", null, 1 });

            migrationBuilder.InsertData(
                table: "SectorData",
                columns: new[] { "SectorId", "Name", "ParentId", "Value" },
                values: new object[] { new Guid("694920d3-c406-4645-8cea-4ae3196d0d87"), "Service", null, 2 });

            migrationBuilder.InsertData(
                table: "SectorData",
                columns: new[] { "SectorId", "Name", "ParentId", "Value" },
                values: new object[] { new Guid("b7d1b767-757f-4a17-a83f-3a8054b8678c"), "Other", null, 3 });

            migrationBuilder.InsertData(
                table: "SectorData",
                columns: new[] { "SectorId", "Name", "ParentId", "Value" },
                values: new object[,]
                {
                    { new Guid("076c44f7-e704-4717-8d94-665ac1db0918"), "Furniture", new Guid("62528f0d-0e87-4b3b-b1ef-e5106ee79bcd"), 13 },
                    { new Guid("0c911af0-24b1-43dd-b01e-8b292effd4aa"), "Textile and Clothing", new Guid("62528f0d-0e87-4b3b-b1ef-e5106ee79bcd"), 7 },
                    { new Guid("0d2d5955-a5a8-4f1c-a72c-6c905eea8904"), "Machinery", new Guid("62528f0d-0e87-4b3b-b1ef-e5106ee79bcd"), 12 },
                    { new Guid("209e774a-910e-455f-b50d-42f283567b0c"), "Energy technology", new Guid("b7d1b767-757f-4a17-a83f-3a8054b8678c"), 29 },
                    { new Guid("35ff055c-7cff-4992-a1d9-a7c050da86b6"), "Creative industries", new Guid("b7d1b767-757f-4a17-a83f-3a8054b8678c"), 37 },
                    { new Guid("41ee21cf-1645-407f-8f41-6446b04b1080"), "Construction materials", new Guid("62528f0d-0e87-4b3b-b1ef-e5106ee79bcd"), 19 },
                    { new Guid("45c160c7-143f-4a30-8a6d-e168d41222b1"), "Engineering", new Guid("694920d3-c406-4645-8cea-4ae3196d0d87"), 35 },
                    { new Guid("64a3df01-5638-4858-8351-656eec0415a9"), "Wood", new Guid("62528f0d-0e87-4b3b-b1ef-e5106ee79bcd"), 8 },
                    { new Guid("87ac49c4-a1aa-4414-83a0-3f3cb9326812"), "Tourism", new Guid("694920d3-c406-4645-8cea-4ae3196d0d87"), 22 },
                    { new Guid("9617fc1a-f498-4eb8-86ce-3f23c7507c42"), "Translation services", new Guid("694920d3-c406-4645-8cea-4ae3196d0d87"), 141 },
                    { new Guid("a56c4a64-78e5-4e5c-8a34-a306164ca7c5"), "Printing", new Guid("62528f0d-0e87-4b3b-b1ef-e5106ee79bcd"), 5 },
                    { new Guid("ab858701-8f9d-4210-b56f-37a9076f0336"), "Environment", new Guid("b7d1b767-757f-4a17-a83f-3a8054b8678c"), 33 },
                    { new Guid("ac250e4c-f5d6-4e8f-8a1b-810e24883d1d"), "Business services", new Guid("694920d3-c406-4645-8cea-4ae3196d0d87"), 25 },
                    { new Guid("ca207960-b32e-4c98-aabb-37b5468bf9f9"), "Plastic and Rubber", new Guid("62528f0d-0e87-4b3b-b1ef-e5106ee79bcd"), 9 },
                    { new Guid("cd5933ec-2dc9-4155-8fc1-3e3944d1e614"), "Transport and Logistics", new Guid("694920d3-c406-4645-8cea-4ae3196d0d87"), 21 },
                    { new Guid("d7cfc0b9-7a0c-4aa6-99b3-7d3c65ae3915"), "Information Technology and Telecommunications", new Guid("694920d3-c406-4645-8cea-4ae3196d0d87"), 28 },
                    { new Guid("dbf82b38-0b27-4dac-b932-36a7dae1dc96"), "Electronics and Optics", new Guid("62528f0d-0e87-4b3b-b1ef-e5106ee79bcd"), 18 },
                    { new Guid("f2a5bd1a-76c8-43e5-a57f-1c47db0a6db7"), "Metalworking", new Guid("62528f0d-0e87-4b3b-b1ef-e5106ee79bcd"), 11 },
                    { new Guid("f9da9ee9-7ae0-4306-8474-97da9d2c0ec2"), "Food and Beverage", new Guid("62528f0d-0e87-4b3b-b1ef-e5106ee79bcd"), 6 }
                });

            migrationBuilder.InsertData(
                table: "SectorData",
                columns: new[] { "SectorId", "Name", "ParentId", "Value" },
                values: new object[,]
                {
                    { new Guid("0ad93be5-a92e-4254-9531-2c6b10eb5687"), "Plastic profiles", new Guid("ca207960-b32e-4c98-aabb-37b5468bf9f9"), 560 },
                    { new Guid("0ee0b603-a50a-4c5f-9a97-a43dccc76d3d"), "Children's room", new Guid("076c44f7-e704-4717-8d94-665ac1db0918"), 390 },
                    { new Guid("247f282a-8589-4f4b-a500-0e5ebe450e90"), "Rail", new Guid("cd5933ec-2dc9-4155-8fc1-3e3944d1e614"), 114 },
                    { new Guid("25ccaa72-4e7d-4b1a-83d8-b50a92d52353"), "Plastic goods", new Guid("ca207960-b32e-4c98-aabb-37b5468bf9f9"), 556 },
                    { new Guid("269c431d-96ce-4752-9690-e981490bf91f"), "Textile", new Guid("0c911af0-24b1-43dd-b01e-8b292effd4aa"), 45 },
                    { new Guid("2ca4e032-fc43-445b-89ea-c7ca116360af"), "Wooden houses", new Guid("64a3df01-5638-4858-8351-656eec0415a9"), 47 },
                    { new Guid("2d6e3a8d-a80e-4bd7-ac99-afd32d9f7943"), "Project furniture", new Guid("076c44f7-e704-4717-8d94-665ac1db0918"), 99 },
                    { new Guid("3161267b-3534-43d0-802b-a8a653084ef1"), "Road", new Guid("cd5933ec-2dc9-4155-8fc1-3e3944d1e614"), 112 },
                    { new Guid("3f2e067a-9593-46d4-8318-a6925da13dfa"), "Metal products", new Guid("f2a5bd1a-76c8-43e5-a57f-1c47db0a6db7"), 267 },
                    { new Guid("425891a2-8522-49ed-93f8-4826f4ab69e2"), "Data processing, Web portals, E-marketing", new Guid("d7cfc0b9-7a0c-4aa6-99b3-7d3c65ae3915"), 581 },
                    { new Guid("46bda4d0-34ef-4db1-9fe3-72c5f0732a07"), "Office", new Guid("076c44f7-e704-4717-8d94-665ac1db0918"), 392 },
                    { new Guid("47b83906-2d2a-4849-882e-cfc520f6bf51"), "Manufacture of machinery", new Guid("0d2d5955-a5a8-4f1c-a72c-6c905eea8904"), 224 },
                    { new Guid("4b579f27-8d09-411b-88e4-c30447f703c4"), "Construction of metal structures", new Guid("f2a5bd1a-76c8-43e5-a57f-1c47db0a6db7"), 67 },
                    { new Guid("4ddeb2e1-0c8a-4c79-8a21-744a44708b95"), "Packaging", new Guid("ca207960-b32e-4c98-aabb-37b5468bf9f9"), 54 },
                    { new Guid("4ed77c1b-1c0c-44e7-8a92-98b5e6fb2401"), "Kitchen", new Guid("076c44f7-e704-4717-8d94-665ac1db0918"), 98 },
                    { new Guid("4ff334c8-633c-4b1c-8e83-613c9812e38a"), "Air", new Guid("cd5933ec-2dc9-4155-8fc1-3e3944d1e614"), 111 },
                    { new Guid("5f248e37-7697-42d6-9cbb-f2694b3c3cfb"), "Houses and buildings", new Guid("f2a5bd1a-76c8-43e5-a57f-1c47db0a6db7"), 263 },
                    { new Guid("605a6420-140f-4b42-84d1-c4558fca1c85"), "Water", new Guid("cd5933ec-2dc9-4155-8fc1-3e3944d1e614"), 113 },
                    { new Guid("61068c29-1071-4084-b728-bfe5c8e0a554"), "Machinery equipment/tools", new Guid("0d2d5955-a5a8-4f1c-a72c-6c905eea8904"), 91 },
                    { new Guid("655c019d-44cc-4f00-98f0-dcd3235bbd4c"), "Other", new Guid("f9da9ee9-7ae0-4306-8474-97da9d2c0ec2"), 437 },
                    { new Guid("65a70974-805b-4596-9f78-e605fe762fc9"), "Clothing", new Guid("0c911af0-24b1-43dd-b01e-8b292effd4aa"), 44 },
                    { new Guid("6fac4877-ec2a-4539-b553-703e618bfdb9"), "Other", new Guid("0d2d5955-a5a8-4f1c-a72c-6c905eea8904"), 508 },
                    { new Guid("6fe3d7bd-e246-4fc9-903a-4a6170922663"), "Book/Periodicals printing", new Guid("a56c4a64-78e5-4e5c-8a34-a306164ca7c5"), 150 },
                    { new Guid("73312d98-1b06-4463-be0e-573ffb85105c"), "Outdoor", new Guid("076c44f7-e704-4717-8d94-665ac1db0918"), 341 },
                    { new Guid("7a892afc-5ffc-49c0-90d4-e20770b0055d"), "Machinery components", new Guid("0d2d5955-a5a8-4f1c-a72c-6c905eea8904"), 94 },
                    { new Guid("7d1eb2c9-a1a7-46b4-b112-a2b751192d36"), "Other (Wood)", new Guid("64a3df01-5638-4858-8351-656eec0415a9"), 337 },
                    { new Guid("8329d8e0-43b2-4e91-b1da-1493ba53ff56"), "Meat & meat products", new Guid("f9da9ee9-7ae0-4306-8474-97da9d2c0ec2"), 40 },
                    { new Guid("870b9271-4366-45e0-bc87-83b660dafa3c"), "Sweets & snack food", new Guid("f9da9ee9-7ae0-4306-8474-97da9d2c0ec2"), 378 },
                    { new Guid("8c8e9331-f5b3-4560-961d-3f2351dd953f"), "Maritime", new Guid("0d2d5955-a5a8-4f1c-a72c-6c905eea8904"), 97 },
                    { new Guid("933e89c9-699e-4325-ac2f-b2114c23fc7c"), "Other (Furniture)", new Guid("076c44f7-e704-4717-8d94-665ac1db0918"), 394 },
                    { new Guid("95064bcb-8e39-4b51-be1c-9f4f575fbc9f"), "Repair and maintenance service", new Guid("0d2d5955-a5a8-4f1c-a72c-6c905eea8904"), 227 },
                    { new Guid("959ec62e-1a1f-47ab-8a95-0b294194e3bc"), "Bathroom/sauna", new Guid("076c44f7-e704-4717-8d94-665ac1db0918"), 389 },
                    { new Guid("9b22497e-b227-41c7-97c2-1790c1df2708"), "Beverages", new Guid("f9da9ee9-7ae0-4306-8474-97da9d2c0ec2"), 43 },
                    { new Guid("a12a0ba9-599a-4fa7-9712-c90737e83c7c"), "Fish & fish products", new Guid("f9da9ee9-7ae0-4306-8474-97da9d2c0ec2"), 42 },
                    { new Guid("b22949f7-107f-42ba-8fcc-0cf10922b8e9"), "Telecommunications", new Guid("d7cfc0b9-7a0c-4aa6-99b3-7d3c65ae3915"), 122 },
                    { new Guid("b76b3ed6-dfa5-4ac0-8515-74585d4f9ac7"), "Milk & dairy products", new Guid("f9da9ee9-7ae0-4306-8474-97da9d2c0ec2"), 39 },
                    { new Guid("bd5b3044-b2cf-4ede-8896-b7166513955b"), "Living room", new Guid("076c44f7-e704-4717-8d94-665ac1db0918"), 101 },
                    { new Guid("bfa1d68c-d82e-46ad-a966-9bae9833af04"), "Programming, Consultancy", new Guid("d7cfc0b9-7a0c-4aa6-99b3-7d3c65ae3915"), 576 },
                    { new Guid("d53584c2-4e67-42b3-8f67-5a308973b20b"), "Wooden building materials", new Guid("64a3df01-5638-4858-8351-656eec0415a9"), 51 },
                    { new Guid("d6ce4a6d-9fde-4179-908b-c088b14718f4"), "Metal structures", new Guid("0d2d5955-a5a8-4f1c-a72c-6c905eea8904"), 93 },
                    { new Guid("d9330a46-75a8-4317-80b1-9ab8442a9b6d"), "Advertising", new Guid("a56c4a64-78e5-4e5c-8a34-a306164ca7c5"), 148 },
                    { new Guid("ddc7296c-2aa3-482a-8dec-422b87588a9d"), "Plastic processing technology", new Guid("ca207960-b32e-4c98-aabb-37b5468bf9f9"), 559 }
                });

            migrationBuilder.InsertData(
                table: "SectorData",
                columns: new[] { "SectorId", "Name", "ParentId", "Value" },
                values: new object[,]
                {
                    { new Guid("ddeff8eb-cb5e-4ff5-860f-d4046663f45b"), "Software, Hardware", new Guid("d7cfc0b9-7a0c-4aa6-99b3-7d3c65ae3915"), 121 },
                    { new Guid("eb8f9b38-6b69-4b1d-84f0-1ae8d25cfd04"), "Labelling and packaging printing", new Guid("a56c4a64-78e5-4e5c-8a34-a306164ca7c5"), 145 },
                    { new Guid("ed43d82e-6651-4015-88b1-f6b081704da4"), "Bakery & confectionery products", new Guid("f9da9ee9-7ae0-4306-8474-97da9d2c0ec2"), 342 },
                    { new Guid("edd8138d-eff5-4354-9779-1ce853bbedea"), "Bedroom", new Guid("076c44f7-e704-4717-8d94-665ac1db0918"), 385 },
                    { new Guid("f0d77910-bd74-452e-8716-c347be4148e6"), "Metal works", new Guid("f2a5bd1a-76c8-43e5-a57f-1c47db0a6db7"), 542 }
                });

            migrationBuilder.InsertData(
                table: "SectorData",
                columns: new[] { "SectorId", "Name", "ParentId", "Value" },
                values: new object[,]
                {
                    { new Guid("102d0053-9220-4496-9470-7e854ee45b27"), "Gas, Plasma, Laser cutting", new Guid("f0d77910-bd74-452e-8716-c347be4148e6"), 69 },
                    { new Guid("1a731b02-69d9-42be-82a9-70bef359bb92"), "Plastics welding and processing", new Guid("ddc7296c-2aa3-482a-8dec-422b87588a9d"), 53 },
                    { new Guid("51ebfd2d-70c4-4e3d-a220-891268345456"), "Boat/Yacht building", new Guid("8c8e9331-f5b3-4560-961d-3f2351dd953f"), 269 },
                    { new Guid("6a9faa0b-2c67-40a8-8251-e219a3304f7e"), "Forgings, Fasteners", new Guid("f0d77910-bd74-452e-8716-c347be4148e6"), 62 },
                    { new Guid("71e9659f-2c0c-4ac8-90cd-626969a14d65"), "Moulding", new Guid("ddc7296c-2aa3-482a-8dec-422b87588a9d"), 57 },
                    { new Guid("72ee0625-bb8f-4a5e-b707-a1cba55e2702"), "Aluminium and steel workboats", new Guid("8c8e9331-f5b3-4560-961d-3f2351dd953f"), 271 },
                    { new Guid("8069fdc9-1573-45b0-91f6-7f7b3539fc7d"), "MIG, TIG, Aluminum welding", new Guid("f0d77910-bd74-452e-8716-c347be4148e6"), 66 },
                    { new Guid("c75d45f7-68b1-4537-9ad4-fd8c6168dbbf"), "Ship repair and conversion", new Guid("8c8e9331-f5b3-4560-961d-3f2351dd953f"), 230 },
                    { new Guid("f8113241-85fe-4c21-8c40-e5f42b52a87f"), "Blowing", new Guid("ddc7296c-2aa3-482a-8dec-422b87588a9d"), 55 },
                    { new Guid("f8618be7-03c5-44b3-8904-95b01d09c548"), "CNC-machining", new Guid("f0d77910-bd74-452e-8716-c347be4148e6"), 75 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sector_UserFormFillingId",
                table: "Sector",
                column: "UserFormFillingId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorData_ParentId",
                table: "SectorData",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorData_Value",
                table: "SectorData",
                column: "Value",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sector");

            migrationBuilder.DropTable(
                name: "SectorData");

            migrationBuilder.DropTable(
                name: "UserFormFilling");
        }
    }
}
