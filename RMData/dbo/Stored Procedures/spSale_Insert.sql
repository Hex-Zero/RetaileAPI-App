CREATE PROCEDURE [dbo].[spSale_Insert]
	@Id int output,
	@CashierID nvarchar(128),
	@SaleDate datetime2,
	@SubTotal money,
	@Tax money,
	@Total money

AS
begin
	set nocount on;
	insert into dbo.Sale(CashierID,SaleDate,SubTotal,Tax,Total)
	values(@CashierID,@SaleDate,@SubTotal,@Tax,@Total);

	select @Id = @@IDENTITY;
end
