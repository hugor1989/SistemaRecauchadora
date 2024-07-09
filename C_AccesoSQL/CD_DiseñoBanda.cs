using C_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C_AccesoSQL
{
    public class CD_DiseñoBanda
    {
        public static CD_DiseñoBanda _instancia = null;

        private CD_DiseñoBanda()
        {

        }

        public static CD_DiseñoBanda Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_DiseñoBanda();
                }
                return _instancia;
            }
        }

        public List<DiseñoBanda> ObtenerDiseñoBanda()
        {
            List<DiseñoBanda> rptListaDiseñoBanda = new List<DiseñoBanda>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerDiseñoBandas", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaDiseñoBanda.Add(new DiseñoBanda()
                        {
                            IdDiseñoBanda = Convert.ToInt32(dr["IdDiseñoBanda"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            AnchoBanda = Convert.ToDecimal(dr["AnchoBanda"]),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaDiseñoBanda;

                }
                catch (Exception ex)
                {
                    rptListaDiseñoBanda = null;
                    return rptListaDiseñoBanda;
                }
            }
        }

        public bool RegistrarDiseñoBanda(DiseñoBanda oDiseñoBanda)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarDiseñoBanda", oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oDiseñoBanda.Descripcion);
                    cmd.Parameters.AddWithValue("AnchoBanda", oDiseñoBanda.AnchoBanda);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public bool ModificarDiseñoBanda(DiseñoBanda oDiseñoBanda)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ModificarDiseñoBanda", oConexion);
                    cmd.Parameters.AddWithValue("IdDiseñoBanda", oDiseñoBanda.IdDiseñoBanda);
                    cmd.Parameters.AddWithValue("Descripcion", oDiseñoBanda.Descripcion);
                    cmd.Parameters.AddWithValue("AnchoBanda", oDiseñoBanda.AnchoBanda);
                    cmd.Parameters.AddWithValue("Activo", oDiseñoBanda.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }

        public bool EliminarDiseñoBanda(int IdDiseñoBanda)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarDiseñoBanda", oConexion);
                    cmd.Parameters.AddWithValue("IdDiseñoBanda", IdDiseñoBanda);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }
    }
}
