using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TDDTestingMVC1.Models;

namespace TDDTestingMVC1.Data
{
    public class OpinionesClienteDataAccessLayer
    {
        private readonly string connectionString = "Data Source=LAPTOP-SD9IUDFC\\SQL; Initial Catalog=db_productos; Encrypt=false; User ID=sa; Password=Bd12345678;";

        // Obtener todas las opiniones
        public List<OpinionesCliente> GetOpiniones()
        {
            List<OpinionesCliente> lst = new List<OpinionesCliente>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("opinionesCliente_SelectAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    OpinionesCliente opinion = new OpinionesCliente
                    {
                        OpinionID = Convert.ToInt32(reader["OpinionID"]),
                        ClienteID = Convert.ToInt32(reader["ClienteID"]),
                        ProductoID = Convert.ToInt32(reader["ProductoID"]),
                        Calificacion = Convert.ToInt32(reader["Calificacion"]),
                        Comentario = reader["Comentario"].ToString(),
                        Fecha = Convert.ToDateTime(reader["Fecha"])
                    };
                    lst.Add(opinion);
                }
                con.Close();
            }
            return lst;
        }

        // Obtener una opinión por su ID
        public OpinionesCliente GetOpinionById(int id)
        {
            OpinionesCliente opinion = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("opinionesCliente_SelectOne", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OpinionID", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    opinion = new OpinionesCliente
                    {
                        OpinionID = Convert.ToInt32(reader["OpinionID"]),
                        ClienteID = Convert.ToInt32(reader["ClienteID"]),
                        ProductoID = Convert.ToInt32(reader["ProductoID"]),
                        Calificacion = Convert.ToInt32(reader["Calificacion"]),
                        Comentario = reader["Comentario"].ToString(),
                        Fecha = Convert.ToDateTime(reader["Fecha"])
                    };
                }
                con.Close();
            }
            return opinion;
        }

        // Agregar una nueva opinión
        public void AddOpinion(OpinionesCliente opinion)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("opinionesCliente_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClienteID", opinion.ClienteID);
                cmd.Parameters.AddWithValue("@ProductoID", opinion.ProductoID);
                cmd.Parameters.AddWithValue("@Calificacion", opinion.Calificacion);
                cmd.Parameters.AddWithValue("@Comentario", opinion.Comentario);
                cmd.Parameters.AddWithValue("@Fecha", opinion.Fecha);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Actualizar una opinión
        public void UpdateOpinion(OpinionesCliente opinion)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("opinionesCliente_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OpinionID", opinion.OpinionID);
                cmd.Parameters.AddWithValue("@ClienteID", opinion.ClienteID);
                cmd.Parameters.AddWithValue("@ProductoID", opinion.ProductoID);
                cmd.Parameters.AddWithValue("@Calificacion", opinion.Calificacion);
                cmd.Parameters.AddWithValue("@Comentario", opinion.Comentario);
                cmd.Parameters.AddWithValue("@Fecha", opinion.Fecha);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Eliminar una opinión
        public bool DeleteOpinion(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("opinionesCliente_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OpinionID", id);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected > 0;
            }
        }

        // Obtener todos los productos
        public List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("productos_SelectAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto producto = new Producto
                    {
                        ProductoID = Convert.ToInt32(reader["ProductoID"]),
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"])
                    };
                    productos.Add(producto);
                }
                con.Close();
            }
            return productos;
        }


        internal IEnumerable GetClientes()
        {
            throw new NotImplementedException();
        }
    }
}