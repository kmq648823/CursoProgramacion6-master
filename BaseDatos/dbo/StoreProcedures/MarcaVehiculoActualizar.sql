CREATE PROCEDURE [dbo].[MarcaVehiculoActualizar]
	@MarcaVehiculoId INT,
	@Descripcion VARCHAR(250),
	@Estado BIT

AS
 BEGIN
   SET NOCOUNT ON
   BEGIN TRANSACTION TRASA

   BEGIN TRY 
   --MÉTODO

   UPDATE MarcaVehiculo
   SET 
   Descripcion=@Descripcion,
   Estado=@Estado
   WHERE 
      MarcaVehiculoId=@MarcaVehiculoId

   COMMIT TRANSACTION TRASA

     SELECT 0 AS CodeError, '' AS MsgError

   END TRY

   BEGIN CATCH
     SELECT 
	     ERROR_NUMBER() AS CodeError
	   , ERROR_MESSAGE() AS MsgError

	   ROLLBACK TRANSACTION TRASA
   END CATCH

 END