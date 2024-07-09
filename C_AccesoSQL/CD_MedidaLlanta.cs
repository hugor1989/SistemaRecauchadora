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
    public class CD_MedidaLlanta
    {
        public static CD_MedidaLlanta _instancia = null;

        private CD_MedidaLlanta()
        {

        }

        public static CD_MedidaLlanta Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_MedidaLlanta();
                }
                return _instancia;
            }
        }

        public List<MedidaLlanta> ObtenerMedidaLlanta()
        {
            List<MedidaLlanta> rptListaMedidaLlanta = new List<MedidaLlanta>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerMedidaLlantas", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaMedidaLlanta.Add(new MedidaLlanta()
                        {
                            IdMedidaLlanta = Convert.ToInt32(dr["IdMedidaLlanta"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            MetrajeBanda = Convert.ToDecimal(dr["MetrajeBanda"]),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaMedidaLlanta;

                }
                catch (Exception ex)
                {
                    rptListaMedidaLlanta = null;
                    return rptListaMedidaLlanta;
                }
            }
        }

        public bool RegistrarMedidaLlanta(MedidaLlanta oMedidaLlanta)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarMedidaLlanta", oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oMedidaLlanta.Descripcion);
                    cmd.Parameters.AddWithValue("MetrajeBanda", oMedidaLlanta.MetrajeBanda);
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

        public bool ModificarMedidaLlanta(MedidaLlanta oMedidaLlanta)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ModificarMedidaLlanta", oConexion);
                    cmd.Parameters.AddWithValue("IdMedidaLlanta", oMedidaLlanta.IdMedidaLlanta);
                    cmd.Parameters.AddWithValue("Descripcion", oMedidaLlanta.Descripcion);
                    cmd.Parameters.AddWithValue("MetrajeBanda", oMedidaLlanta.MetrajeBanda);
                    cmd.Parameters.AddWithValue("Activo", oMedidaLlanta.Activo);
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

        public bool EliminarMedidaLlanta(int IdMedidaLlanta)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarMedidaLlanta", oConexion);
                    cmd.Parameters.AddWithValue("IdMedidaLlanta", IdMedidaLlanta);
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
