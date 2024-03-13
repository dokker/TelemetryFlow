using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelemetryFlow.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "opc");

            migrationBuilder.CreateTable(
                name: "OpcNodeGroup",
                schema: "opc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcNodeGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpcNodeProperty",
                schema: "opc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcNodeProperty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpcNodeTag",
                schema: "opc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcNodeTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpcServer",
                schema: "opc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcServer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpcNode",
                schema: "opc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpandedNodeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpcNode_OpcServer_ServerId",
                        column: x => x.ServerId,
                        principalSchema: "opc",
                        principalTable: "OpcServer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpcPublisher",
                schema: "opc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MethodTopics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcPublisher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpcPublisher_OpcServer_ServerId",
                        column: x => x.ServerId,
                        principalSchema: "opc",
                        principalTable: "OpcServer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpcServerEndpoint",
                schema: "opc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityPolicy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthenticationMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcServerEndpoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpcServerEndpoint_OpcServer_ServerId",
                        column: x => x.ServerId,
                        principalSchema: "opc",
                        principalTable: "OpcServer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpcNodeOpcNodeGroup",
                schema: "opc",
                columns: table => new
                {
                    GroupsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NodesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcNodeOpcNodeGroup", x => new { x.GroupsId, x.NodesId });
                    table.ForeignKey(
                        name: "FK_OpcNodeOpcNodeGroup_OpcNodeGroup_GroupsId",
                        column: x => x.GroupsId,
                        principalSchema: "opc",
                        principalTable: "OpcNodeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpcNodeOpcNodeGroup_OpcNode_NodesId",
                        column: x => x.NodesId,
                        principalSchema: "opc",
                        principalTable: "OpcNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpcNodeOpcNodeProperty",
                schema: "opc",
                columns: table => new
                {
                    NodesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcNodeOpcNodeProperty", x => new { x.NodesId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_OpcNodeOpcNodeProperty_OpcNodeProperty_PropertiesId",
                        column: x => x.PropertiesId,
                        principalSchema: "opc",
                        principalTable: "OpcNodeProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpcNodeOpcNodeProperty_OpcNode_NodesId",
                        column: x => x.NodesId,
                        principalSchema: "opc",
                        principalTable: "OpcNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpcNodeOpcNodeTag",
                schema: "opc",
                columns: table => new
                {
                    NodesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcNodeOpcNodeTag", x => new { x.NodesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_OpcNodeOpcNodeTag_OpcNodeTag_TagsId",
                        column: x => x.TagsId,
                        principalSchema: "opc",
                        principalTable: "OpcNodeTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpcNodeOpcNodeTag_OpcNode_NodesId",
                        column: x => x.NodesId,
                        principalSchema: "opc",
                        principalTable: "OpcNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpcNode_ServerId",
                schema: "opc",
                table: "OpcNode",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_OpcNodeOpcNodeGroup_NodesId",
                schema: "opc",
                table: "OpcNodeOpcNodeGroup",
                column: "NodesId");

            migrationBuilder.CreateIndex(
                name: "IX_OpcNodeOpcNodeProperty_PropertiesId",
                schema: "opc",
                table: "OpcNodeOpcNodeProperty",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_OpcNodeOpcNodeTag_TagsId",
                schema: "opc",
                table: "OpcNodeOpcNodeTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_OpcPublisher_ServerId",
                schema: "opc",
                table: "OpcPublisher",
                column: "ServerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpcServerEndpoint_ServerId",
                schema: "opc",
                table: "OpcServerEndpoint",
                column: "ServerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpcNodeOpcNodeGroup",
                schema: "opc");

            migrationBuilder.DropTable(
                name: "OpcNodeOpcNodeProperty",
                schema: "opc");

            migrationBuilder.DropTable(
                name: "OpcNodeOpcNodeTag",
                schema: "opc");

            migrationBuilder.DropTable(
                name: "OpcPublisher",
                schema: "opc");

            migrationBuilder.DropTable(
                name: "OpcServerEndpoint",
                schema: "opc");

            migrationBuilder.DropTable(
                name: "OpcNodeGroup",
                schema: "opc");

            migrationBuilder.DropTable(
                name: "OpcNodeProperty",
                schema: "opc");

            migrationBuilder.DropTable(
                name: "OpcNodeTag",
                schema: "opc");

            migrationBuilder.DropTable(
                name: "OpcNode",
                schema: "opc");

            migrationBuilder.DropTable(
                name: "OpcServer",
                schema: "opc");
        }
    }
}
