using CapaBLL;
using CapaBO;
using Ionic.Zip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;

namespace TarjaAEP.Models
{
    public class ZipFotoCons
    {
        public MemoryStream crearZip(Int64 nroTarja, DateTime fecha)
        {
            var fechaLimiteStr = ConfigurationManager.AppSettings["FechaLimite"].ToString().Split('-');

            DateTime fechaLimite = new DateTime(Convert.ToInt32(fechaLimiteStr[0]), Convert.ToInt32(fechaLimiteStr[1]), Convert.ToInt32(fechaLimiteStr[2]));


            MemoryStream memo = new MemoryStream();

            List<DocumentoConsigBO> listaDocs;
            string jsonDocsConsig = string.Empty;
            
            List<MercanciaExpoBO> listMercs = null;

            string base64Img = "";
            string nombreImg = string.Empty;

            jsonDocsConsig = new DocumentoConsigBLL().sp_sel_documentosIDBLL(nroTarja);
            listaDocs = JsonConvert.DeserializeObject<List<DocumentoConsigBO>>(jsonDocsConsig);

            var doctypeConsCnt = ConfigurationManager.AppSettings["FDM:DocTypeConsCnt"].ToString();
            var doctypeMercCons = ConfigurationManager.AppSettings["FDM:DocTypeMercCons"].ToString();

            if (fecha < fechaLimite)
            {
                using (ZipFile zip = new ZipFile())
                {
                    try
                    {
                        byte[] imageBytes;
                        List<FotoContenedorBO> listFotos = new FotoContenedorBLL().sp_sel_fotoConsoBLL(nroTarja);
                        foreach (FotoContenedorBO fotoCont in listFotos)
                        {
                            if (!nombreImg.Equals(fotoCont.Gls_nombreImg))
                            {
                                if (string.IsNullOrEmpty(nombreImg))
                                {
                                    nombreImg = fotoCont.Gls_nombreImg;
                                    base64Img = fotoCont.Gls_imagen;
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
                                        zip.AddEntry(nombreImg, imageBytes);
                                    }
                                    base64Img = fotoCont.Gls_imagen;
                                    nombreImg = fotoCont.Gls_nombreImg;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(nombreImg))
                                {
                                    var parte = fotoCont.Gls_imagen;
                                    var largo = parte.Length;
                                    base64Img += "" + parte;
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(nombreImg))
                        {
                            imageBytes = Convert.FromBase64String(base64Img);
                            zip.AddEntry(nombreImg, imageBytes);
                        }

                        nombreImg = "";
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ha ocurrido un error: " + ex.ToString());
                    }
                    foreach (DocumentoConsigBO docConsig in listaDocs)
                    {
                        string jsonMercs = new MercanciaExpoBLL().sp_sel_mercExpoBLL(docConsig.Nro_documento, docConsig.Nro_tarja);
                        listMercs = JsonConvert.DeserializeObject<List<MercanciaExpoBO>>(jsonMercs);

                        foreach (MercanciaExpoBO codigo in listMercs)
                        {
                            try
                            {
                                byte[] imageBytes;
                                string nombreImagen = string.Empty;
                                List<FotoMercanciaBO> listFotoMerc = new FotoMercanciaBLL().sp_sel_fotoMercExpoBLL(codigo.Cod_mercancia);
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

                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Ha ocurrido un error: " + ex.ToString());
                            }
                        }
                    }


                    zip.Save(memo);
                }
            }
            else
            {
                using (ZipFile zip = new ZipFile())
                {
                    try
                    {
                        byte[] imageBytes;
                        List<FotografiasFDM> listFotos = new FotografiasFDM().obtenerFotografias(doctypeConsCnt, nroTarja.ToString());
                        foreach (FotografiasFDM fotoCont in listFotos)
                        {
                            nombreImg = fotoCont.nombre_foto;

                            using (var webClient = new WebClient())
                            {
                                imageBytes = webClient.DownloadData(fotoCont.url_foto);
                                zip.AddEntry(nombreImg, imageBytes);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ha ocurrido un error: " + ex.ToString());
                    }
                    foreach (DocumentoConsigBO docConsig in listaDocs)
                    {
                        string jsonMercs = new MercanciaExpoBLL().sp_sel_mercExpoBLL(docConsig.Nro_documento, docConsig.Nro_tarja);
                        listMercs = JsonConvert.DeserializeObject<List<MercanciaExpoBO>>(jsonMercs);

                        foreach (MercanciaExpoBO codigo in listMercs)
                        {
                            try
                            {
                                byte[] imageBytes;
                                string nombreImagen = string.Empty;
                                List<FotografiasFDM> listFotoMerc = new FotografiasFDM().obtenerFotografias(doctypeMercCons, codigo.Cod_mercancia.ToString());


                                foreach (FotografiasFDM fotoMerc in listFotoMerc)
                                {
                                    nombreImagen = fotoMerc.nombre_foto;

                                    using (var webClient = new WebClient())
                                    {
                                        imageBytes = webClient.DownloadData(fotoMerc.url_foto);
                                        zip.AddEntry(nombreImg, imageBytes);
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Ha ocurrido un error: " + ex.ToString());
                            }
                        }
                    }


                    zip.Save(memo);
                }
            }            

            return memo;
        }
    }
}
