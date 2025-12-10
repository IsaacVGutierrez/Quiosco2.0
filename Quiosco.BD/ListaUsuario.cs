using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quiosco.Entidades;
using System.Data;
using System.Threading.Tasks;

    namespace Quiosco.BD
    {
        public class ListaUsuario : DatosConexionBD
        {
            // =============================
            //  ABM USUARIO
            // =============================
            public int abmUsuario(string accion, Usuario obj)
            {
                int resultado = -1;

                if (accion == "Alta")
                {
                    string sql = @"
                    INSERT INTO Usuario (Email, NombreUsuario, ContrasenaHash, Telefono, Rol)
                            OUTPUT INSERTED.IdUsuario
                               VALUES (@email, @nombre, @pass, @tel, @rol)
                                     ";

                    SqlCommand cmd = new SqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.Parameters.AddWithValue("@nombre", obj.NombreUsuario);
                    cmd.Parameters.AddWithValue("@pass", obj.ContrasenaHash);
                    cmd.Parameters.AddWithValue("@tel", obj.Telefono ?? "");
                    cmd.Parameters.AddWithValue("@rol", obj.Rol);


                try
                {
                        Abrirconexion();
                        object o = cmd.ExecuteScalar();
                        if (o != null) resultado = Convert.ToInt32(o);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error al insertar Usuario", e);
                    }
                    finally
                    {
                        Cerrarconexion();
                        cmd.Dispose();
                    }

                    return resultado;
                }
                else if (accion == "Modificar")
                {
                    string sql = @"
                    UPDATE Usuario
                    SET Email=@email,
                        NombreUsuario=@nombre,
                        Telefono=@tel
                    WHERE IdUsuario=@id";

                    SqlCommand cmd = new SqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@id", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.Parameters.AddWithValue("@nombre", obj.NombreUsuario);
                    cmd.Parameters.AddWithValue("@tel", obj.Telefono ?? "");
                     cmd.Parameters.AddWithValue("@rol", obj.Rol);
                try
                    {
                        Abrirconexion();
                        resultado = cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error al modificar Usuario", e);
                    }
                    finally
                    {
                        Cerrarconexion();
                        cmd.Dispose();
                    }

                    return resultado;
                }
                else if (accion == "Baja")
                {
                    string sql = @"DELETE FROM Usuario WHERE IdUsuario=@id";

                    SqlCommand cmd = new SqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@id", obj.IdUsuario);

                    try
                    {
                        Abrirconexion();
                        resultado = cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error al eliminar Usuario", e);
                    }
                    finally
                    {
                        Cerrarconexion();
                        cmd.Dispose();
                    }

                    return resultado;
                }

                return resultado;
            }





            // =============================
            // LISTADO COMPLETO
            // =============================
            public List<Usuario> ObtenerUsuarios()
            {
                List<Usuario> lista = new List<Usuario>();

                string sql = @"SELECT IdUsuario, Email, NombreUsuario, ContrasenaHash, Telefono,Rol FROM Usuario";

                SqlCommand cmd = new SqlCommand(sql, conexion);

                try
                {
                    Abrirconexion();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lista.Add(new Usuario
                        {
                            IdUsuario = dr.GetInt32(0),
                            Email = dr.GetString(1),
                            NombreUsuario = dr.GetString(2),
                            ContrasenaHash = dr.GetString(3),
                            Telefono = dr.IsDBNull(4) ? "" : dr.GetString(4),
                            Rol = dr.GetString(5)
                        });
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener usuarios", e);
                }
                finally
                {
                    Cerrarconexion();
                    cmd.Dispose();
                }

                return lista;
            }

            // =============================
            // LOGIN
            // =============================
            public Usuario Login(string email, string passHash)
            {
                string sql = @"
                SELECT IdUsuario, Email, NombreUsuario, ContrasenaHash, Telefono, Rol
                FROM Usuario
                WHERE Email=@email AND ContrasenaHash=@hash";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@hash", passHash);

                try
                {
                    Abrirconexion();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        return new Usuario
                        {
                            IdUsuario = dr.GetInt32(0),
                            Email = dr.GetString(1),
                            NombreUsuario = dr.GetString(2),
                            ContrasenaHash = dr.GetString(3),
                            Telefono = dr.IsDBNull(4) ? "" : dr.GetString(4),
                            Rol = dr.GetString(5)
                        };
                    }

                    return null;
                }
                finally
                {
                    Cerrarconexion();
                    cmd.Dispose();
                }
            }

            // =============================
            // BUSCAR POR EMAIL
            // =============================
            public Usuario BuscarPorEmail(string email)
            {
                string sql = @"
                SELECT IdUsuario, Email, NombreUsuario, ContrasenaHash, Telefono, Rol
                FROM Usuario
                WHERE Email=@email";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@email", email);

                try
                {
                    Abrirconexion();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        return new Usuario
                        {
                            IdUsuario = dr.GetInt32(0),
                            Email = dr.GetString(1),
                            NombreUsuario = dr.GetString(2),
                            ContrasenaHash = dr.GetString(3),
                            Telefono = dr.IsDBNull(4) ? "" : dr.GetString(4),
                            Rol = dr.GetString(5)
                        };
                    }
                    return null;
                }
                finally
                {
                    Cerrarconexion();
                    cmd.Dispose();
                }
            }

            // =============================
            // CREAR CÓDIGO DE RECUPERACIÓN
            // =============================
            public void CrearCodigoRecuperacion(RecuperacionPassword r)
            {
                string sql = @"
                INSERT INTO RecuperacionPassword (IdUsuario, Codigo, Expira)
                VALUES (@id, @codigo, @expira)";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", r.IdUsuario);
                cmd.Parameters.AddWithValue("@codigo", r.Codigo);
                cmd.Parameters.AddWithValue("@expira", r.Expira);

                try
                {
                    Abrirconexion();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    Cerrarconexion();
                    cmd.Dispose();
                }
            }

            // =============================
            // VALIDAR CÓDIGO
            // =============================
            public bool ValidarCodigo(int idUsuario, string codigo)
            {
                string sql = @"
                SELECT COUNT(*)
                FROM RecuperacionPassword
                WHERE IdUsuario=@id AND Codigo=@codigo
                      AND Usado=0 AND Expira > GETDATE()";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                cmd.Parameters.AddWithValue("@codigo", codigo);

                try
                {
                    Abrirconexion();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 1;
                }
                finally
                {
                    Cerrarconexion();
                    cmd.Dispose();
                }
            }

            // =============================
            // MARCAR CÓDIGO USADO
            // =============================
            public void MarcarCodigoUsado(int idUsuario, string codigo)
            {
                string sql = @"
                UPDATE RecuperacionPassword
                SET Usado = 1
                WHERE IdUsuario=@id AND Codigo=@codigo";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                cmd.Parameters.AddWithValue("@codigo", codigo);

                try
                {
                    Abrirconexion();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    Cerrarconexion();
                    cmd.Dispose();
                }
            }

            // =============================
            // CAMBIAR PASSWORD
            // =============================
            public void CambiarPassword(int idUsuario, string nuevoHash)
            {
                string sql = @"UPDATE Usuario SET ContrasenaHash=@hash WHERE IdUsuario=@id";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                cmd.Parameters.AddWithValue("@hash", nuevoHash);

                try
                {
                    Abrirconexion();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    Cerrarconexion();
                    cmd.Dispose();
                }
            }
        }
    }
