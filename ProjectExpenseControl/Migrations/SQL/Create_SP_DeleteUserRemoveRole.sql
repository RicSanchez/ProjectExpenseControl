	/*
	Este store sirve para ingresar un usuario y proporcionarle el permiso por
	defecto de Usuario
	*/
USE DB_A39AAA_net
if exists (select * from dbo.sysobjects where id = object_id('SP_DeleteUserRemoveRole') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].SP_DeleteUserRemoveRole
GO
	CREATE PROCEDURE SP_DeleteUserRemoveRole	
			@USR_IDE_USER int
	AS
	BEGIN
		DECLARE @ErrorMessage varchar(max)

	BEGIN TRY		
		BEGIN TRAN
			DELETE FROM Users WHERE USR_IDE_USER = @USR_IDE_USER

			IF @@ROWCOUNT = 0
				BEGIN
					PRINT 'No se encontraron datos. :D'
				END
			ELSE
				DELETE FROM UserRoles WHERE USR_IDE_USER = @USR_IDE_USER

			IF (@@ERROR = 0 )
			BEGIN
				Print 'EXITO'
				COMMIT TRAN
			END
			ELSE
			BEGIN
				Print 'Hubo errores al intentar leer los parametros.'
				ROLLBACK TRAN
				RETURN -1 
			END
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT <> 0
			BEGIN
				SET @ErrorMessage = ERROR_MESSAGE()
				ROLLBACK TRAN
				RAISERROR('Error has occurred in ...', 16, 1, @ErrorMessage)
				RETURN -1 
			END
	END CATCH
END

