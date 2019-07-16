using CapaBLL;
using CapaBO;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;

namespace TarjaAEP.Models
{
    public class ZipFotos
    {
        public MemoryStream crearZip(Int64 nroTarja)
        {
            MemoryStream memo = new MemoryStream();
            Int64[] codigosMerc;
            List<MercanciasDescBO> listMerc = null;
            String base64Img = "";

            try
            {
                listMerc = new MercanciasDescBll().sp_sel_mercDescBLL(nroTarja);
                int i = 0;
                codigosMerc = new Int64[listMerc.Count];
                foreach (MercanciasDescBO mercs in listMerc)
                {
                    codigosMerc[i] = mercs.Cod_mercancia;
                    i++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error: " + ex.ToString());
            }

            using (ZipFile zip = new ZipFile())
            {
                try
                {
                    byte[] imageBytes;
                    List<FotoContenedorBO> listFotos = new FotoContenedorBLL().sp_sel_fotoContDescBLL(nroTarja);
                    string nombreImagen = string.Empty;

                    foreach (FotoContenedorBO fotoCl in listFotos)
                    {
                        if (!nombreImagen.Equals(fotoCl.Gls_nombreImg))
                        {
                            if (string.IsNullOrEmpty(nombreImagen))
                            {
                                nombreImagen = fotoCl.Gls_nombreImg;
                                base64Img = fotoCl.Gls_imagen;
                            }
                            else
                            {
                                if (base64Img.Length % 4 != 0)
                                {
                                    string len = (base64Img.Length % 4).ToString();
                                }
                                else
                                {
                                    imageBytes = Convert.FromBase64String(base64Img);
                                    zip.AddEntry(nombreImagen, imageBytes);
                                }

                                nombreImagen = fotoCl.Gls_nombreImg;
                                base64Img = fotoCl.Gls_imagen;
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(nombreImagen))
                            {
                                var parte = fotoCl.Gls_imagen;
                                var largo = parte.Length;
                                base64Img += "" + parte;
                            }
                        }

                    }
                    if (!string.IsNullOrEmpty(base64Img))
                    {
                        imageBytes = Convert.FromBase64String(base64Img);
                        zip.AddEntry(nombreImagen, imageBytes);
                    }
                    base64Img = "";
                    nombreImagen = "";
                }
                catch (Exception ex)
                {
                    throw new Exception("Ha ocurrido un error: " + ex.ToString());
                }

                foreach (Int64 codigo in codigosMerc)
                {
                    try
                    {
                        byte[] imageBytes;
                        string marcaMerc = "";
                        string nombreImagen = string.Empty;
                        List<FotoMercanciaBO> listFotoMerc = new FotoMercanciaBLL().sp_sel_fotoMercDescBLL(codigo);
                        marcaMerc = new MercanciasDescBll().sp_sel_marcaMercBLL(codigo);
                        foreach (FotoMercanciaBO fotoMerc in listFotoMerc)
                        {

                            if (!nombreImagen.Equals(fotoMerc.Gls_nombreImg))
                            {
                                if (string.IsNullOrEmpty(nombreImagen))
                                {
                                    nombreImagen = fotoMerc.Gls_nombreImg;
                                    base64Img = fotoMerc.Gls_imagen;
                                }
                                else
                                {
                                    if (base64Img.Length % 4 != 0)
                                    {
                                        string len = (base64Img.Length % 4).ToString();
                                    }
                                    else
                                    {

                                        imageBytes = Convert.FromBase64String(base64Img);
                                        zip.AddEntry(nombreImagen, imageBytes);

                                    }
                                    nombreImagen = fotoMerc.Gls_nombreImg;
                                    base64Img = fotoMerc.Gls_imagen;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(nombreImagen))
                                {
                                    var parte = fotoMerc.Gls_imagen;
                                    var largo = parte.Length;
                                    base64Img += "" + parte;
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(nombreImagen))
                        {
                            imageBytes = Convert.FromBase64String(base64Img);
                            zip.AddEntry(nombreImagen, imageBytes);

                            nombreImagen = "";
                            base64Img = "";
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ha ocurrido un error: " + ex.ToString());
                    }
                }
                try
                {
                    byte[] imageBytes;
                    string nombreImagen = string.Empty;
                    List<FotoContenedorBO> listFotosFin = new FotoContenedorBLL().sp_sel_fotoContFinBLL(nroTarja);
                    foreach (FotoContenedorBO fotoFin in listFotosFin)
                    {
                        if (!nombreImagen.Equals(fotoFin.Gls_nombreImg))
                        {
                            if (string.IsNullOrEmpty(nombreImagen))
                            {
                                nombreImagen = fotoFin.Gls_nombreImg;
                                base64Img = fotoFin.Gls_imagen;
                            }
                            else
                            {
                                if (base64Img.Length % 4 != 0)
                                {
                                    string len = (base64Img.Length % 4).ToString();
                                }
                                else
                                {
                                    imageBytes = Convert.FromBase64String(base64Img);
                                    zip.AddEntry(nombreImagen, imageBytes);
                                }

                                nombreImagen = fotoFin.Gls_nombreImg;
                                base64Img = fotoFin.Gls_imagen;
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(nombreImagen))
                            {
                                var parte = fotoFin.Gls_imagen;
                                var largo = parte.Length;
                                base64Img += "" + parte;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(nombreImagen))
                    {
                        imageBytes = Convert.FromBase64String(base64Img);
                        base64Img = Convert.ToBase64String(imageBytes);
                        zip.AddEntry(nombreImagen, imageBytes);
                    }

                    nombreImagen = "";
                    base64Img = "";
                }
                catch (Exception ex)
                {
                    throw new Exception("Ha ocurrido un error: " + ex.ToString());
                }
                zip.Save(memo);
            }

            return memo;
        }
    }
}
