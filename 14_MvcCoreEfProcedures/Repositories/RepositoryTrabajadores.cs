using _14_MvcCoreEfProcedures.Data;
using _14_MvcCoreEfProcedures.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace _14_MvcCoreEfProcedures.Repositories
{
    public class RepositoryTrabajadores
    {
        private HospitalContext context;

        public RepositoryTrabajadores(HospitalContext context)
        {
            this.context = context;
        }

        public List<Trabajador> GetTrabajadores()
        {
            var consulta = from datos in this.context.Trabajadores
                           select datos;
            return consulta.ToList();
        }

        public List<string> GetOficios()
        {
            var consulta = (from datos in this.context.Trabajadores
                            select datos.Oficio).Distinct();
            return consulta.ToList();
        }

        public TrabajadoresModel GetTrabajadoresOficio(string oficio)
        {
            //LOS PARAMETROS DE SALIDA DEBEN LLEVAR LA PALABRA OUT EN LA EJECUCION DE LA CONSULTA
            string sql = "SP_TRABAJADORES_OFICIO @OFICIO, @PERSONAS OUT,  @MEDIA OUT, @SUMA OUT";

            SqlParameter paramOficio = new SqlParameter("@OFICIO", oficio);

            //LOS PARAMETROS DE SALIDA DEBEN LLEVAR UN VALOR POR DEFECTO
            SqlParameter paramPersonas = new SqlParameter("@PERSONAS", -1);
            SqlParameter paramMedia = new SqlParameter("@MEDIA", -1);
            SqlParameter paramSuma = new SqlParameter("@SUMA", -1);

            //DEBEMOS INICIAR LA DIRECCION DEL PARAMETRO
            paramPersonas.Direction = ParameterDirection.Output;
            paramMedia.Direction = ParameterDirection.Output;
            paramSuma.Direction = ParameterDirection.Output;

            var consulta = this.context.Trabajadores.FromSqlRaw(sql, paramOficio, paramPersonas, paramMedia, paramSuma);

            TrabajadoresModel model = new TrabajadoresModel();
            model.Trabajadores = consulta.ToList();
            model.Personas = int.Parse(paramPersonas.Value.ToString());
            model.MediaSalarial = int.Parse(paramMedia.Value.ToString());
            model.SumaSalarial = int.Parse(paramSuma.Value.ToString());

            return model;
        }
    }
}
