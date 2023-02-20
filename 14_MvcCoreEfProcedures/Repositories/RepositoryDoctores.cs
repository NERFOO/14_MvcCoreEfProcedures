using _14_MvcCoreEfProcedures.Data;
using _14_MvcCoreEfProcedures.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

#region
/*
 CREATE PROCEDURE SP_TODOS_DOCTORES
AS
	SELECT * FROM DOCTOR
GO

CREATE PROCEDURE SP_ESPECIALIDADES
AS
	SELECT DISTINCT DOCTOR.ESPECIALIDAD FROM DOCTOR
GO

CREATE PROCEDURE SP_DOCTORES_ESPECIALIDAD (@ESPECIALIDAD NVARCHAR(50))
AS
	SELECT * FROM DOCTOR WHERE ESPECIALIDAD = @ESPECIALIDAD 
GO

CREATE PROCEDURE SP_INCREMENTAR_DOCTORES (@ESPECIALIDAD NVARCHAR(50), @INCREMENTO INT)
AS
	UPDATE DOCTOR SET SALARIO = SALARIO + @INCREMENTO
	WHERE ESPECIALIDAD = @ESPECIALIDAD 
GO
 */
#endregion

namespace _14_MvcCoreEfProcedures.Repositories
{
    public class RepositoryDoctores
    {

        private EnfermosContext context;

        public RepositoryDoctores(EnfermosContext context)
        {
            this.context = context;
        }

        public List<Doctor> GetDoctores()
        {
            using (DbCommand command = this.context.Database.GetDbConnection().CreateCommand())
            {
                string consulta = "SP_TODOS_DOCTORES";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = consulta;

                command.Connection.Open();

                DbDataReader reader = command.ExecuteReader();

                List<Doctor> doctores = new List<Doctor>();
                while (reader.Read())
                {
                    Doctor doctor = new Doctor
                    {
                        HospitalCod = int.Parse(reader["HOSPITAL_COD"].ToString()),
                        DoctorNum = int.Parse(reader["DOCTOR_NO"].ToString()),
                        Apellido = reader["APELLIDO"].ToString(),
                        Especialidad = reader["ESPECIALIDAD"].ToString(),
                        Salario = int.Parse(reader["SALARIO"].ToString())
                    };
                    doctores.Add(doctor);
                }
                reader.Close();
                command.Connection.Close();
                return doctores;
            }
        }

        public List<string> GetEspecialidades()
        {
            string consulta = "SP_ESPECIALIDADES";

            using (DbCommand command = this.context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = consulta;

                command.Connection.Open();

                DbDataReader reader = command.ExecuteReader();

                List<string> especialidades = new List<string>();
                while (reader.Read())
                {
                    especialidades.Add(reader["ESPECIALIDAD"].ToString());
                }

                reader.Close();
                command.Connection.Close();
                return especialidades;
            }
        }

        public List<Doctor> GetDoctoresEspecialidad(string especialidad)
        {
            string sql = "SP_DOCTORES_ESPECIALIDAD @ESPECIALIDAD";

            SqlParameter paramEspecialidad = new SqlParameter("@ESPECIALIDAD", especialidad);

            var consulta = this.context.Doctores.FromSqlRaw(sql, paramEspecialidad);

            List<Doctor> doctores = consulta.AsEnumerable().ToList();

            return doctores;
        }

        public async Task IncrementarSalarioDoctoresAsync(string especialidad, int incremento)
        {
            string sql = "SP_INCREMENTAR_DOCTORES @ESPECIALIDAD, @INCREMENTO";
            SqlParameter pamespe = new SqlParameter("@ESPECIALIDAD", especialidad);
            SqlParameter pamincremento = new SqlParameter("@INCREMENTO", incremento);
            await this.context.Database.ExecuteSqlRawAsync(sql, pamespe, pamincremento);
        }

    }
}
