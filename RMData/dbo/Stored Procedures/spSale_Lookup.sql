CREATE PROCEDURE [dbo].[spSale_Lookup]
	@CashierID nvarchar(128),
	@SaleDate datetime2
AS
begin
	set nocount on;

	select Id
	from dbo.Sale
	where CashierID = @CashierID and SaleDate = @SaleDate;
end
