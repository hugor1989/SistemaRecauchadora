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
    public class CD_MarcaLlanta
    {
        public static CD_MarcaLlanta _instancia = null;

        private CD_MarcaLlanta()
        {

        }

        public static CD_MarcaLlanta Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_MarcaLlanta();
                }
                return _instancia;
            }
        }

        public List<MarcaLlanta> ObtenerMarcaLlanta()
        {
            List<MarcaLlanta> rptListaMarcaLlanta = new List<MarcaLlanta>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerMarcaLlantas", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaMarcaLlanta.Add(new MarcaLlanta()
                        {
                            IdMarcaLlanta = Convert.ToInt32(dr["IdMarcaLlanta"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaMarcaLlanta;

                }
                catch (Exception ex)
                {
                    rptListaMarcaLlanta = null;
                    return rptListaMarcaLlanta;
                }
            }
        }

        public bool RegistrarMarcaLlanta(MarcaLlanta oMarcaLlanta)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarMarcaLlanta", oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oMarcaLlanta.Descripcion);
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

        public bool ModificarMarcaLlanta(MarcaLlanta oMarcaLlanta)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ModificarMarcaLlanta", oConexion);
                    cmd.Parameters.AddWithValue("IdMarcaLlanta", oMarcaLlanta.IdMarcaLlanta);
                    cmd.Parameters.AddWithValue("Descripcion", oMarcaLlanta.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", oMarcaLlanta.Activo);
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

        public bool EliminarMarcaLlanta(int IdMarcaLlanta)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarMarcaLlanta", oConexion);
                    cmd.Parameters.AddWithValue("IdMarcaLlanta", IdMarcaLlanta);
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
