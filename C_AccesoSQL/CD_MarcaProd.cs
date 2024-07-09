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
    public class CD_MarcaProd
    {
        public static CD_MarcaProd _instancia = null;

        private CD_MarcaProd()
        {

        }

        public static CD_MarcaProd Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_MarcaProd();
                }
                return _instancia;
            }
        }

        public List<MarcaProd> ObtenerMarcaProd()
        {
            List<MarcaProd> rptListaMarcaProd = new List<MarcaProd>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerMarcaProds", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaMarcaProd.Add(new MarcaProd()
                        {
                            IdMarcaProd = Convert.ToInt32(dr["IdMarcaProd"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaMarcaProd;

                }
                catch (Exception ex)
                {
                    rptListaMarcaProd = null;
                    return rptListaMarcaProd;
                }
            }
        }

        public bool RegistrarMarcaProd(MarcaProd oMarcaProd)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarMarcaProd", oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oMarcaProd.Descripcion);
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

        public bool ModificarMarcaProd(MarcaProd oMarcaProd)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ModificarMarcaProd", oConexion);
                    cmd.Parameters.AddWithValue("IdMarcaProd", oMarcaProd.IdMarcaProd);
                    cmd.Parameters.AddWithValue("Descripcion", oMarcaProd.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", oMarcaProd.Activo);
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

        public bool EliminarMarcaProd(int IdMarcaProd)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarMarcaProd", oConexion);
                    cmd.Parameters.AddWithValue("IdMarcaProd", IdMarcaProd);
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
