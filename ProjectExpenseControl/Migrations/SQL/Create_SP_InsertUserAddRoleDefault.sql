	/*
	Este store sirve para ingresar un usuario y proporcionarle el permiso por
	defecto de Usuario
	*/
USE DBProgramExpenses
if exists (select * from dbo.sysobjects where id = object_id('SP_InsertUserAddRoleDefault') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].SP_InsertUserAddRoleDefault
GO
	CREATE PROCEDURE SP_InsertUserAddRoleDefault	
			@USR_IDE_AREA nvarchar(100),
			@USR_DES_POSITION nvarchar(60),
			@USR_DES_NAME nvarchar(100),
			@USR_DES_FIRST_NAME nvarchar(60),
			@USR_DES_LAST_NAME nvarchar(60),
			@USR_DES_PASSWORD nvarchar(50),
			@USR_DES_PHONE nvarchar(20) = NULL,
			@USR_DES_EMAIL nvarchar(40),
			@USR_FH_CREATED datetime
	AS
	BEGIN
		DECLARE @USR_IDE_USER int,
						@TUSR_IDE_RESOURCE int,
						@ErrorMessage varchar(max)
	BEGIN TRY		
		BEGIN TRAN
			SET @TUSR_IDE_RESOURCE = (SELECT TOP 1 TUSR_IDE_RESOURCE FROM Roles WHERE TUSR_DES_TYPE LIKE '%usuario%')

			IF @TUSR_IDE_RESOURCE IS NULL
				BEGIN
					PRINT 'No se encontraron datos.. pero ahorita los creamos :D'
					INSERT INTO Roles VALUES ('Usuario', GETDATE())			
					SET @TUSR_IDE_RESOURCE = SCOPE_IDENTITY()		
				END
			ELSE
				INSERT INTO
					Users
					VALUES(@USR_IDE_AREA, @USR_DES_POSITION, @USR_DES_NAME, @USR_DES_FIRST_NAME, @USR_DES_LAST_NAME, 
								  @USR_DES_PASSWORD, ISNULL(@USR_DES_PHONE, ''), @USR_DES_EMAIL, @USR_FH_CREATED, GETDATE())

			IF (@@ERROR = 0 )
			BEGIN
				SET @USR_IDE_USER = SCOPE_IDENTITY()
				
				INSERT INTO UserRoles VALUES(@USR_IDE_USER, @TUSR_IDE_RESOURCE)
				
				Print 'EXITO'
				COMMIT TRAN
			END
			ELSE
			BEGIN
				Print 'Hubo errores al intentar leer los par�metros.'
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

