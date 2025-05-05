using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VoucherNegocio
    {
        public List<Voucher> listar()
        {
            List<Voucher> vouchers = new List<Voucher>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setConsulta("SELECT CODIGOVOUCHER, FECHACANJE, IDCLIENTE, IDARTICULO  FROM VOUCHERS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Voucher voucher = new Voucher();
                    voucher.CodigoVoucher = (string)datos.Lector["CodigoVoucher"];
                    if (!(datos.Lector["FechaCanje"] is DBNull))
                        voucher.FechaCanje = (DateTime)datos.Lector["FechaCanje"];

                    if (!(datos.Lector["IdCliente"] is DBNull))
                        voucher.IdCliente = (int)datos.Lector["IdCliente"];

                    if (!(datos.Lector["IdArticulo"] is DBNull))
                        voucher.IdArticulo = (int)datos.Lector["IdArticulo"];
                    
                }

                return vouchers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void asignarVoucher(Voucher voucher)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setConsulta("UPDATE VOUCHERS SET IDCLIENTE = @IdCliente, IDARTICULO = @IdArticulo WHERE CodigoVoucher = @CodigoVoucher ");
                accesoDatos.setParametro("@CodigoVoucher", voucher.CodigoVoucher);
                accesoDatos.setParametro("@IdCliente", voucher.Cliente.Id);
                accesoDatos.setParametro("@IdArticulo", voucher.Articulo.Id);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }

}
