CREATE PROCEDURE [dbo].[spInventory_GetAll]

AS
	set nocount on;

	SELECT [Id], [ProductId], [Quantity], [PurchasePrice], [PurchaseDate]
	from dbo.Inventory
RETURN 0
