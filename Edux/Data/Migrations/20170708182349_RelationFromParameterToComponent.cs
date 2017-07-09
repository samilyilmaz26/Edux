using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Edux.Data.Migrations
{
    public partial class RelationFromParameterToComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_ComponentTypes_ComponentTypeId",
                table: "Parameters");

            migrationBuilder.RenameColumn(
                name: "ComponentTypeId",
                table: "Parameters",
                newName: "ComponentId");

            migrationBuilder.RenameIndex(
                name: "IX_Parameters_ComponentTypeId",
                table: "Parameters",
                newName: "IX_Parameters_ComponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_Components_ComponentId",
                table: "Parameters",
                column: "ComponentId",
                principalTable: "Components",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_Components_ComponentId",
                table: "Parameters");

            migrationBuilder.RenameColumn(
                name: "ComponentId",
                table: "Parameters",
                newName: "ComponentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Parameters_ComponentId",
                table: "Parameters",
                newName: "IX_Parameters_ComponentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_ComponentTypes_ComponentTypeId",
                table: "Parameters",
                column: "ComponentTypeId",
                principalTable: "ComponentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
