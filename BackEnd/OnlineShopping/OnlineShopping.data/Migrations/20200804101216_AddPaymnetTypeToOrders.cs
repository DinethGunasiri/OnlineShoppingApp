﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace OnlineShopping.Data.Migrations
{
    public partial class AddPaymnetTypeToOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentException($"{migrationBuilder}");
            }

            migrationBuilder.AddColumn<string>(
                name: "PaymentType",
                table: "Orders",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentException($"{migrationBuilder}");
            }

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Orders");
        }
    }
}
