using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable
namespace PaymentServiceSample.Migrations
{
    /// <inheritdoc />
    public partial class UpgradedToAbp_8_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(name: "Amount", table: "AvidPaymentServiceWeChatPayRefundRecords", type: "nvarchar(max)", nullable: true);
            migrationBuilder.AddColumn<string>(name: "Channel", table: "AvidPaymentServiceWeChatPayRefundRecords", type: "nvarchar(max)", nullable: true);
            migrationBuilder.AddColumn<string>(name: "CreateTime", table: "AvidPaymentServiceWeChatPayRefundRecords", type: "nvarchar(max)", nullable: true);
            migrationBuilder.AddColumn<string>(name: "FundsAccount", table: "AvidPaymentServiceWeChatPayRefundRecords", type: "nvarchar(max)", nullable: true);
            migrationBuilder.AddColumn<string>(name: "PromotionDetail", table: "AvidPaymentServiceWeChatPayRefundRecords", type: "nvarchar(max)", nullable: true);
            migrationBuilder.AddColumn<string>(name: "Status", table: "AvidPaymentServiceWeChatPayRefundRecords", type: "nvarchar(max)", nullable: true);
            migrationBuilder.AddColumn<string>(name: "UserReceivedAccount", table: "AvidPaymentServiceWeChatPayRefundRecords", type: "nvarchar(max)", nullable: true);
            migrationBuilder.AddColumn<string>(name: "Amount", table: "AvidPaymentServiceWeChatPayPaymentRecords", type: "nvarchar(max)", nullable: true);
            migrationBuilder.AddColumn<string>(name: "Payer", table: "AvidPaymentServiceWeChatPayPaymentRecords", type: "nvarchar(max)", nullable: true);
            migrationBuilder.AddColumn<string>(name: "PromotionDetail", table: "AvidPaymentServiceWeChatPayPaymentRecords", type: "nvarchar(max)", nullable: true);
            migrationBuilder.AddColumn<string>(name: "SceneInfo", table: "AvidPaymentServiceWeChatPayPaymentRecords", type: "nvarchar(max)", nullable: true);
            migrationBuilder.AddColumn<string>(name: "SuccessTime", table: "AvidPaymentServiceWeChatPayPaymentRecords", type: "nvarchar(max)", nullable: true);
            migrationBuilder.AddColumn<string>(name: "TradeState", table: "AvidPaymentServiceWeChatPayPaymentRecords", type: "nvarchar(max)", nullable: true);
            migrationBuilder.AddColumn<string>(name: "TradeStateDesc", table: "AvidPaymentServiceWeChatPayPaymentRecords", type: "nvarchar(max)", nullable: true);
            migrationBuilder.AddColumn<string>(name: "NormalizedName", table: "AbpTenants", type: "nvarchar(64)", maxLength: 64, nullable: false, defaultValue: "");
            migrationBuilder.AlterColumn<string>(name: "Providers", table: "AbpSettingDefinitions", type: "nvarchar(1024)", maxLength: 1024, nullable: true, oldClrType: typeof(string), oldType: "nvarchar(128)", oldMaxLength: 128, oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "DefaultValue", table: "AbpSettingDefinitions", type: "nvarchar(2048)", maxLength: 2048, nullable: true, oldClrType: typeof(string), oldType: "nvarchar(256)", oldMaxLength: 256, oldNullable: true); migrationBuilder.CreateIndex(name: "IX_AbpTenants_NormalizedName", table: "AbpTenants", column: "NormalizedName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(name: "IX_AbpTenants_NormalizedName", table: "AbpTenants");
            migrationBuilder.DropColumn(name: "Amount", table: "AvidPaymentServiceWeChatPayRefundRecords");
            migrationBuilder.DropColumn(name: "Channel", table: "AvidPaymentServiceWeChatPayRefundRecords");
            migrationBuilder.DropColumn(name: "CreateTime", table: "AvidPaymentServiceWeChatPayRefundRecords");
            migrationBuilder.DropColumn(name: "FundsAccount", table: "AvidPaymentServiceWeChatPayRefundRecords");
            migrationBuilder.DropColumn(name: "PromotionDetail", table: "AvidPaymentServiceWeChatPayRefundRecords");
            migrationBuilder.DropColumn(name: "Status", table: "AvidPaymentServiceWeChatPayRefundRecords");
            migrationBuilder.DropColumn(name: "UserReceivedAccount", table: "AvidPaymentServiceWeChatPayRefundRecords");
            migrationBuilder.DropColumn(name: "Amount", table: "AvidPaymentServiceWeChatPayPaymentRecords");
            migrationBuilder.DropColumn(name: "Payer", table: "AvidPaymentServiceWeChatPayPaymentRecords");
            migrationBuilder.DropColumn(name: "PromotionDetail", table: "AvidPaymentServiceWeChatPayPaymentRecords");
            migrationBuilder.DropColumn(name: "SceneInfo", table: "AvidPaymentServiceWeChatPayPaymentRecords");
            migrationBuilder.DropColumn(name: "SuccessTime", table: "AvidPaymentServiceWeChatPayPaymentRecords");
            migrationBuilder.DropColumn(name: "TradeState", table: "AvidPaymentServiceWeChatPayPaymentRecords");
            migrationBuilder.DropColumn(name: "TradeStateDesc", table: "AvidPaymentServiceWeChatPayPaymentRecords");
            migrationBuilder.DropColumn(name: "NormalizedName", table: "AbpTenants");
            migrationBuilder.AlterColumn<string>(name: "Providers", table: "AbpSettingDefinitions", type: "nvarchar(128)", maxLength: 128, nullable: true, oldClrType: typeof(string), oldType: "nvarchar(1024)", oldMaxLength: 1024, oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "DefaultValue", table: "AbpSettingDefinitions", type: "nvarchar(256)", maxLength: 256, nullable: true, oldClrType: typeof(string), oldType: "nvarchar(2048)", oldMaxLength: 2048, oldNullable: true);
        }
    }
}