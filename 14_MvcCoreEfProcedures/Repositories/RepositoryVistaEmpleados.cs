using _14_MvcCoreEfProcedures.Data;
using _14_MvcCoreEfProcedures.Models;

#region
/*
 ALTER VIEW V_EMPLEADOS_DEPT
AS
	SELECT CAST(ISNULL( ROW_NUMBER() OVER (ORDER BY APELLIDO), 0) AS INT) AS CLAVE, EMP.APELLIDO, EMP.OFICIO, DEPT.DNOMBRE AS NOMBRE, DEPT.LOC AS LOCALIDAD 
	FROM EMP
	INNER JOIN DEPT
	ON EMP.DEPT_NO = DEPT.DEPT_NO


CREATE VIEW V_TRABAJADORES
AS
	SELECT ISNULL(EMP_NO, 0) AS IDTRABAJADOR,
	APELLIDO, OFICIO, SALARIO
	FROM EMP
	UNION
	SELECT DOCTOR_NO, APELLIDO, ESPECIALIDAD, SALARIO FROM DOCTOR
	UNION 
	SELECT EMPLEADO_NO, APELLIDO, FUNCION, SALARIO
	FROM PLANTILLA
GO


CREATE PROCEDURE SP_TRABAJADORES_OFICIO
(@OFICIO NVARCHAR(50), @PERSONAS INT OUT, @MEDIA INT OUT, @SUMA INT OUT)
AS
	SELECT * FROM V_TRABAJADORES
	WHERE OFICIO = @OFICIO
	SELECT @PERSONAS = COUNT(IDTRABAJADOR), @MEDIA = AVG(SALARIO), @SUMA = SUM(SALARIO)
	FROM V_TRABAJADORES
	WHERE OFICIO = @OFICIO
GO

 */
#endregion

namespace _14_MvcCoreEfProcedures.Repositories
{
    public class RepositoryVistaEmpleados
    {
        private HospitalContext context;

        public RepositoryVistaEmpleados(HospitalContext context)
        {
            this.context = context;
        }

        public List<VistaEmpleado> GetEmpleados()
        {
            var consulta = from datos in this.context.VistaEmpleados
                           select datos;
            return consulta.ToList();
        }
    }
}
