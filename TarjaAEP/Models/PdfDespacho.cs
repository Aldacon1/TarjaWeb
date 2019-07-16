namespace TarjaAEP.Models
{
    #region Usings
    using CapaBLL;
    using TarjaAEP.Tools;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using CapaBO;
    using System.Globalization;
    using iTextSharp.text;
    using System.IO;
    using iTextSharp.text.pdf;
    using Newtonsoft.Json;
    using NBarCodes;
    using System.Drawing.Imaging;
    using System.Web;
    using System.Web.Hosting;
    using System.Configuration;
    #endregion
    public class PdfDespacho
    {
        public Document BindingData(Document doc, Int64 nroTarja)
        {
            string jsonPlan = string.Empty,
                jsonDocsConsig = string.Empty,
                jsonCliente = string.Empty,
                jsonNave = string.Empty,
                jsonPuertoD = string.Empty,
                jsonTarjador = string.Empty;

            PlanificacionDespBO planCons;
            List<DocumentoConsigBO> listaDocs;
            ForwardersBO cliente;
            NavesBO nave;
            PuertosBO puerto_dest;
            PersonasBO tarjador;

            try
            {
                jsonPlan = new PlanificacionDespBLL().sp_sel_PlanificacionDespIDBLL(nroTarja);
                planCons = JsonConvert.DeserializeObject<PlanificacionDespBO>(jsonPlan.Trim(new char[] { '[', ']' }));

                jsonDocsConsig = new DocumentoConsigBLL().sp_sel_documentosIDBLL(nroTarja);
                listaDocs = JsonConvert.DeserializeObject<List<DocumentoConsigBO>>(jsonDocsConsig);

                jsonCliente = JsonConvert.SerializeObject(new ForwardersBLL().sp_selPlanDesc_forwarderBLL(planCons.Rut_cliente));
                cliente = JsonConvert.DeserializeObject<ForwardersBO>(jsonCliente.Trim(new char[] { '[', ']' }));

                jsonNave = JsonConvert.SerializeObject(new NavesBLL().sp_sel_naveIDBLL(planCons.Cod_transporte));
                nave = JsonConvert.DeserializeObject<NavesBO>(jsonNave.Trim(new char[] { '[', ']' }));

                jsonPuertoD = JsonConvert.SerializeObject(new PuertoBLL().sp_sel_puertoIDBLL(planCons.Cod_puerto_Dest));
                puerto_dest = JsonConvert.DeserializeObject<PuertosBO>(jsonPuertoD.Trim(new char[] { '[', ']' }));

                jsonTarjador = JsonConvert.SerializeObject(new PersonasBLL().sp_sel_personasIDBLL(planCons.Rut_tarjador));
                tarjador = JsonConvert.DeserializeObject<PersonasBO>(jsonTarjador.Trim(new char[] { '[', ']' }));
            }
            catch (Exception ex)
            {
                throw ex;
            }


            Font arialHeading = FontFactory.GetFont("Arial", 15, 1);
            Font arialText = FontFactory.GetFont("Arial", 10, 1);
            string logoPath = HostingEnvironment.MapPath("~/assets/custom/images");
            var settings = new BarCodeSettings
            {
                Type = BarCodeType.Code128,
                Data = nroTarja.ToString()
            };

            var generator = new BarCodeGenerator(settings);
            iTextSharp.text.Image imgbarcode;
            using (var barcodeImage = generator.GenerateImage())
            {
                ImageFormat format = ImageFormat.Bmp;
                imgbarcode = Image.GetInstance(barcodeImage, format);
                imgbarcode.ScalePercent(100f);
            }

            //Añadir encabezado
            PdfPTable tableHeader = new PdfPTable(3);
            PdfPCell subheader = new PdfPCell(imgbarcode);
            subheader.HorizontalAlignment = 1;
            subheader.VerticalAlignment = 5;
            subheader.Border = 0;
            tableHeader.WidthPercentage = 100;
            tableHeader.DefaultCell.Padding = 4.5f;
            tableHeader.DefaultCell.Border = 0;
            tableHeader.DefaultCell.HorizontalAlignment = 1;
            tableHeader.DefaultCell.VerticalAlignment = 5;

            Image logo = Image.GetInstance(logoPath + "/logo.png");
            tableHeader.AddCell(logo);
            Paragraph titulo = new Paragraph("Documento de Despacho", arialHeading);
            tableHeader.AddCell(titulo);
            tableHeader.AddCell(subheader);

            //Añadir Tabla de detalles
            PdfPTable detailTable = new PdfPTable(6);
            detailTable.WidthPercentage = 100;
            detailTable.DefaultCell.Padding = 4.5f;
            detailTable.DefaultCell.Border = 15;
            detailTable.DefaultCell.HorizontalAlignment = 1;
            detailTable.DefaultCell.VerticalAlignment = 5;

            //row1 inicializacion
            PdfPCell TitleCliente = new PdfPCell(new Paragraph("CLIENTE", arialText));
            TitleCliente.BackgroundColor = BaseColor.LIGHT_GRAY;
            TitleCliente.HorizontalAlignment = 1;
            TitleCliente.VerticalAlignment = 5;
            PdfPCell cellrutCliente = new PdfPCell(new Paragraph(cliente.Rut_cliente + "-" + cliente.Dv_cliente, arialText));
            cellrutCliente.HorizontalAlignment = 1;
            cellrutCliente.VerticalAlignment = 5;
            PdfPCell cellcliente = new PdfPCell(new Paragraph(cliente.Nombre_cliente, arialText));
            cellcliente.HorizontalAlignment = 1;
            cellcliente.VerticalAlignment = 5;
            PdfPCell vacio1 = new PdfPCell(new Paragraph(""));
            PdfPCell celltitlefecha = new PdfPCell(new Paragraph("FECHA", arialText));
            celltitlefecha.HorizontalAlignment = 1;
            celltitlefecha.VerticalAlignment = 5;
            celltitlefecha.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPCell cellfecha = new PdfPCell(new Paragraph(planCons.Fecha.ToString().Substring(0, 10), arialText));
            cellfecha.HorizontalAlignment = 1;
            cellfecha.VerticalAlignment = 5;
            //row2 inicializacion
            PdfPCell celltitlenave = new PdfPCell(new Paragraph("TRANSPORTE", arialText));
            celltitlenave.BackgroundColor = BaseColor.LIGHT_GRAY;
            celltitlenave.HorizontalAlignment = 1;
            celltitlenave.VerticalAlignment = 5;
            PdfPCell cellnave = new PdfPCell(new Paragraph(nave.Nav_nom, arialText));
            cellnave.HorizontalAlignment = 1;
            cellnave.VerticalAlignment = 5;
            PdfPCell celltitlehorrai = new PdfPCell(new Paragraph("HORA INICIO", arialText));
            celltitlehorrai.BackgroundColor = BaseColor.LIGHT_GRAY;
            celltitlehorrai.HorizontalAlignment = 1;
            celltitlehorrai.VerticalAlignment = 5;
            PdfPCell cellhorainicio = new PdfPCell(new Paragraph(planCons.Hora_inicio.ToString(), arialText));
            cellhorainicio.HorizontalAlignment = 1;
            cellhorainicio.VerticalAlignment = 5;
            PdfPCell celltitlehorrat = new PdfPCell(new Paragraph("HORA TERMINO", arialText));
            celltitlehorrat.BackgroundColor = BaseColor.LIGHT_GRAY;
            celltitlehorrat.HorizontalAlignment = 1;
            celltitlehorrat.VerticalAlignment = 5;
            PdfPCell cellhoratermino = new PdfPCell(new Paragraph(planCons.Hora_termino.ToString(), arialText));
            cellhoratermino.HorizontalAlignment = 1;
            cellhoratermino.VerticalAlignment = 5;
            //row3 inicializacion
            PdfPCell titledestino = new PdfPCell(new Paragraph("DESTINO", arialText));
            titledestino.BackgroundColor = BaseColor.LIGHT_GRAY;
            titledestino.HorizontalAlignment = 1;
            titledestino.VerticalAlignment = 5;
            PdfPCell celldestino = new PdfPCell(new Paragraph(puerto_dest.Gls_nombre_puerto, arialText));
            celldestino.HorizontalAlignment = 1;
            celldestino.VerticalAlignment = 5;
            PdfPCell titlecontenedor = new PdfPCell(new Paragraph("CAMION", arialText));
            titlecontenedor.BackgroundColor = BaseColor.LIGHT_GRAY;
            titlecontenedor.HorizontalAlignment = 1;
            titlecontenedor.VerticalAlignment = 5;
            PdfPCell cellcontenedor = new PdfPCell(new Paragraph(planCons.Patente, arialText));
            cellcontenedor.HorizontalAlignment = 1;
            cellcontenedor.VerticalAlignment = 5;
            PdfPCell celltitlesello = new PdfPCell(new Paragraph("SELLO", arialText));
            celltitlesello.HorizontalAlignment = 1;
            celltitlesello.VerticalAlignment = 5;
            celltitlesello.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPCell cellsello = new PdfPCell(new Paragraph("SIN SELLO", arialText));
            cellsello.HorizontalAlignment = 1;
            cellsello.VerticalAlignment = 5;
            //row4 inicializacion
            PdfPCell titlecodiso = new PdfPCell(new Paragraph("CODIGO ISO", arialText));
            titlecodiso.BackgroundColor = BaseColor.LIGHT_GRAY;
            titlecodiso.HorizontalAlignment = 1;
            titlecodiso.VerticalAlignment = 5;
            PdfPCell cellcodiso = new PdfPCell(new Paragraph("N/ISO", arialText));
            cellcodiso.HorizontalAlignment = 1;
            cellcodiso.VerticalAlignment = 5;
            PdfPCell titletara = new PdfPCell(new Paragraph("TARA", arialText));
            titletara.BackgroundColor = BaseColor.LIGHT_GRAY;
            titletara.HorizontalAlignment = 1;
            titletara.VerticalAlignment = 5;
            PdfPCell celltara = new PdfPCell(new Paragraph("", arialText));
            celltara.HorizontalAlignment = 1;
            celltara.VerticalAlignment = 5;

            //row1
            detailTable.AddCell(TitleCliente);
            detailTable.AddCell(cellrutCliente);
            detailTable.AddCell(cellcliente);
            detailTable.AddCell(vacio1);
            detailTable.AddCell(celltitlefecha);
            detailTable.AddCell(cellfecha);
            //row2
            detailTable.AddCell(celltitlenave);
            detailTable.AddCell(cellnave);
            detailTable.AddCell(celltitlehorrai);
            detailTable.AddCell(cellhorainicio);
            detailTable.AddCell(celltitlehorrat);
            detailTable.AddCell(cellhoratermino);
            //row3
            detailTable.AddCell(titledestino);
            detailTable.AddCell(celldestino);
            detailTable.AddCell(titlecontenedor);
            detailTable.AddCell(cellcontenedor);
            detailTable.AddCell(celltitlesello);
            detailTable.AddCell(cellsello);
            //row4
            detailTable.AddCell(titlecodiso);
            detailTable.AddCell(cellcodiso);
            detailTable.AddCell(titletara);
            detailTable.AddCell(celltara);
            detailTable.AddCell(vacio1);
            detailTable.AddCell(vacio1);

            PdfPTable tableObs = new PdfPTable(1);
            PdfPCell titleObs = new PdfPCell(new Paragraph("OBSERVACIONES GENERALES", arialText));
            titleObs.HorizontalAlignment = 1;
            titleObs.VerticalAlignment = 5;
            titleObs.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPCell cellObs = new PdfPCell(new Paragraph(planCons.Observacion, arialText));
            tableObs.AddCell(titleObs);
            tableObs.AddCell(cellObs);

            //tabla detalles personas
            DataTable personasT = new PersonasBLL().sp_sel_personasExpoBLL(nroTarja);

            string movilizadores = string.Empty;
            string horquillero = string.Empty;
            string grua = string.Empty;

            foreach (DataRow row in personasT.Rows)
            {
                if (row["FUNCION"].ToString() == "Movilizador")
                {
                    movilizadores += row["nom_persona"].ToString() + "\n";
                }
                else
                {
                    horquillero = row["nom_persona"].ToString();
                }
            }

            grua = new GruasDescBLL().sp_sel_gruaExpoBLL(nroTarja);

            PdfPTable tablapersonas = new PdfPTable(4);
            tablapersonas.WidthPercentage = 100;
            //row1
            PdfPCell titlegrua = new PdfPCell(new Paragraph("GRUA", arialText));
            titlegrua.BackgroundColor = BaseColor.LIGHT_GRAY;
            titlegrua.HorizontalAlignment = 1;
            titlegrua.VerticalAlignment = 5;
            PdfPCell cellgrua = new PdfPCell(new Paragraph(grua, arialText));
            cellgrua.HorizontalAlignment = 1;
            cellgrua.VerticalAlignment = 5;
            PdfPCell titlemovilizadores = new PdfPCell(new Paragraph("MOVILIZADORES", arialText));
            titlemovilizadores.BackgroundColor = BaseColor.LIGHT_GRAY;
            titlemovilizadores.HorizontalAlignment = 1;
            titlemovilizadores.VerticalAlignment = 5;
            PdfPCell titletarjador = new PdfPCell(new Paragraph("TARJADOR", arialText));
            titletarjador.HorizontalAlignment = 1;
            titletarjador.VerticalAlignment = 5;
            titletarjador.BackgroundColor = BaseColor.LIGHT_GRAY;
            //row2
            PdfPCell titlehorquillero = new PdfPCell(new Paragraph("HORQUILLERO", arialText));
            titlehorquillero.BackgroundColor = BaseColor.LIGHT_GRAY;
            titlehorquillero.HorizontalAlignment = 1;
            titlehorquillero.VerticalAlignment = 5;
            PdfPCell cellhorquillero = new PdfPCell(new Paragraph(horquillero, arialText));
            cellhorquillero.HorizontalAlignment = 1;
            cellhorquillero.VerticalAlignment = 5;
            PdfPCell cellmovilizadeores = new PdfPCell(new Paragraph(movilizadores, arialText));
            titlemovilizadores.HorizontalAlignment = 1;
            titlemovilizadores.VerticalAlignment = 5;
            PdfPCell celltarjador = new PdfPCell(new Paragraph(tarjador.Nom_persona, arialText));
            titletarjador.HorizontalAlignment = 1;
            titletarjador.VerticalAlignment = 5;

            PdfPCell vacio2 = new PdfPCell(new Paragraph("", arialText));
            vacio2.Border = 0;

            tablapersonas.AddCell(titlegrua);
            tablapersonas.AddCell(cellgrua);
            tablapersonas.AddCell(titlemovilizadores);
            tablapersonas.AddCell(titletarjador);
            tablapersonas.AddCell(titlehorquillero);
            tablapersonas.AddCell(cellhorquillero);
            tablapersonas.AddCell(cellmovilizadeores);
            tablapersonas.AddCell(celltarjador);

            //Tabla Merc
            PdfPTable detalleMerc = new PdfPTable(4);
            detalleMerc.WidthPercentage = 100;
            PdfPCell titlemarca = new PdfPCell(new Paragraph("MARCAS/NUMEROS", arialText));
            titlemarca.HorizontalAlignment = 1;
            titlemarca.VerticalAlignment = 5;
            titlemarca.BackgroundColor = BaseColor.LIGHT_GRAY;
            titlemarca.Border = 15;
            detalleMerc.AddCell(titlemarca);
            PdfPCell titlebulto = new PdfPCell(new Paragraph("TIPO BULTO", arialText));
            titlebulto.HorizontalAlignment = 1;
            titlebulto.VerticalAlignment = 5;
            titlebulto.Border = 15;
            titlebulto.BackgroundColor = BaseColor.LIGHT_GRAY;
            detalleMerc.AddCell(titlebulto);
            PdfPCell titlecantidad = new PdfPCell(new Paragraph("CANTIDAD", arialText));
            titlecantidad.HorizontalAlignment = 1;
            titlecantidad.VerticalAlignment = 5;
            titlecantidad.BackgroundColor = BaseColor.LIGHT_GRAY;
            titlecantidad.Border = 15;
            detalleMerc.AddCell(titlecantidad);
            PdfPCell titleobs = new PdfPCell(new Paragraph("OBSERVACIONES", arialText));
            titleobs.HorizontalAlignment = 1;
            titleobs.VerticalAlignment = 5;
            titleobs.BackgroundColor = BaseColor.LIGHT_GRAY;
            titleobs.Border = 15;
            detalleMerc.AddCell(titleobs);
            PdfPCell cellmarca, cellbultos, cellcantidad, cellobs, celltotal;
            string nomBulto = "", marca = "";
            int suma = 0;
            int cantidad = 0;
            Int64[] codigosMerc;
            List<MercanciaExpoBO> listMercs = null;
            foreach (DocumentoConsigBO docConsig in listaDocs)
            {
                string jsonMercs = new MercanciaExpoBLL().sp_sel_mercExpoBLL(docConsig.Nro_documento, docConsig.Nro_tarja);
                listMercs = JsonConvert.DeserializeObject<List<MercanciaExpoBO>>(jsonMercs);
                foreach (MercanciaExpoBO merc in listMercs)
                {
                    marca = merc.Gls_marca;
                    cantidad = merc.N_cantidad;
                    suma += cantidad;
                    nomBulto = new BultosBLL().sp_sel_bultosIDBLL(merc.N_bulto).Rows[0].ItemArray[1].ToString();

                    cellmarca = new PdfPCell(new Paragraph(marca, arialText));
                    cellmarca.HorizontalAlignment = 1;
                    cellmarca.VerticalAlignment = 5;
                    cellmarca.Border = 15;
                    detalleMerc.AddCell(cellmarca);

                    cellbultos = new PdfPCell(new Paragraph(nomBulto, arialText));
                    cellmarca.HorizontalAlignment = 1;
                    cellmarca.VerticalAlignment = 5;
                    cellmarca.Border = 15;
                    detalleMerc.AddCell(cellbultos);

                    cellcantidad = new PdfPCell(new Paragraph(cantidad.ToString(), arialText));
                    cellmarca.HorizontalAlignment = 1;
                    cellmarca.VerticalAlignment = 5;
                    cellmarca.Border = 15;
                    detalleMerc.AddCell(cellcantidad);

                    cellobs = new PdfPCell(new Paragraph(""));
                    cellmarca.HorizontalAlignment = 1;
                    cellmarca.VerticalAlignment = 5;
                    cellmarca.Border = 15;
                    detalleMerc.AddCell(cellobs);
                }
            }

            celltotal = new PdfPCell(new Paragraph(suma.ToString(), arialText));
            celltotal.HorizontalAlignment = 1;
            celltotal.VerticalAlignment = 5;
            celltotal.Border = 15;
            PdfPCell cellnada = new PdfPCell(new Paragraph(""));
            cellnada.Border = 0;
            detalleMerc.AddCell(cellnada);
            PdfPCell titletotal = new PdfPCell(new Paragraph("TOTAL", arialText));
            titletotal.Border = 15;
            titletotal.HorizontalAlignment = 1;
            titletotal.VerticalAlignment = 5;
            titletotal.BackgroundColor = BaseColor.LIGHT_GRAY;
            detalleMerc.AddCell(titletotal);
            detalleMerc.AddCell(celltotal);
            detalleMerc.AddCell(cellnada);

            Paragraph salto = new Paragraph();
            salto.Add("\n");
            Paragraph p1 = new Paragraph();
            p1.Add(tableHeader);
            Paragraph p2 = new Paragraph();
            p2.Add(detailTable);
            Paragraph p3 = new Paragraph();
            p3.Add(tableObs);
            Paragraph p4 = new Paragraph();
            p4.Add(tablapersonas);
            Paragraph p5 = new Paragraph();
            p5.Add(detalleMerc);

            doc.Add(p1);
            doc.Add(salto);
            doc.Add(salto);
            doc.Add(p2);
            doc.Add(p3);
            doc.Add(p4);
            doc.Add(salto);
            doc.Add(p5);

            PdfPTable tablefotos = new PdfPTable(3);
            tablefotos.WidthPercentage = 100;
            PdfPCell titletable = new PdfPCell(new Paragraph("FOTOGRAFIAS CONSOLIDADO", arialText));
            titletable.Border = 15;
            titletable.HorizontalAlignment = 1;
            titletable.VerticalAlignment = 5;
            titletable.BackgroundColor = BaseColor.LIGHT_GRAY;
#pragma warning disable CS0168 // La variable 'cellfoto' se ha declarado pero nunca se usa
            PdfPCell cellfoto, cellnombrefoto;
#pragma warning restore CS0168 // La variable 'cellfoto' se ha declarado pero nunca se usa
            string base64Img = "";
            PdfPTable subtabla = new PdfPTable(1);
            PdfPCell cellfotografias;
            string nombreImg = string.Empty;

            var doctypeConsCnt = ConfigurationManager.AppSettings["FDM:DocTypeConsCnt"].ToString();
            var doctypeMercCons = ConfigurationManager.AppSettings["FDM:DocTypeMercCons"].ToString();

            var fechaLimiteStr = ConfigurationManager.AppSettings["FechaLimite"].ToString().Split('-');

            DateTime fechaLimite = new DateTime(Convert.ToInt32(fechaLimiteStr[0]), Convert.ToInt32(fechaLimiteStr[1]), Convert.ToInt32(fechaLimiteStr[2]));


            if(planCons.Fecha < fechaLimite)
            {
                try
                {
                    byte[] imageBytes;
                    List<FotoContenedorBO> listFotos = new FotoContenedorBLL().sp_sel_fotoConsoBLL(nroTarja);
                    string nombreImagen = string.Empty;
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
                                    Image foto = Image.GetInstance(imageBytes);
                                    foto.ScaleAbsolute(159f, 159f);
                                    cellnombrefoto = new PdfPCell(new Paragraph("FOTO CONSOLIDADO", arialText));
                                    cellnombrefoto.HorizontalAlignment = 1;
                                    cellnombrefoto.VerticalAlignment = 5;
                                    subtabla = new PdfPTable(1);
                                    subtabla.AddCell(new PdfPCell(foto) { HorizontalAlignment = 1, VerticalAlignment = 5 });
                                    subtabla.AddCell(cellnombrefoto);
                                    cellfotografias = new PdfPCell(subtabla);
                                    cellfotografias.HorizontalAlignment = 1;
                                    cellfotografias.VerticalAlignment = 5;
                                    tablefotos.AddCell(cellfotografias);
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
                        Image foto2 = Image.GetInstance(imageBytes);
                        foto2.ScaleAbsolute(159f, 159f);
                        cellnombrefoto = new PdfPCell(new Paragraph("FOTO CONSOLIDADO", arialText));
                        cellnombrefoto.HorizontalAlignment = 1;
                        cellnombrefoto.VerticalAlignment = 5;
                        subtabla = new PdfPTable(1);
                        subtabla.AddCell(new PdfPCell(foto2) { HorizontalAlignment = 1, VerticalAlignment = 5 });
                        subtabla.AddCell(cellnombrefoto);
                        cellfotografias = new PdfPCell(subtabla);
                        cellfotografias.HorizontalAlignment = 1;
                        cellfotografias.VerticalAlignment = 5;
                        tablefotos.AddCell(cellfotografias);
                    }

                    nombreImg = "";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ha ocurrido un error: " + ex.ToString());
                }
            }
            else
            {
                try
                {
                    List<FotografiasFDM> listFotos = new FotografiasFDM().obtenerFotografias(doctypeConsCnt, nroTarja.ToString());
                    string nombreImagen = string.Empty;
                    foreach (FotografiasFDM fotoCont in listFotos)
                    {
                        Image foto2 = Image.GetInstance(new Uri(fotoCont.url_foto));
                        foto2.ScaleAbsolute(159f, 159f);
                        cellnombrefoto = new PdfPCell(new Paragraph("FOTO CONSOLIDADO", arialText));
                        cellnombrefoto.HorizontalAlignment = 1;
                        cellnombrefoto.VerticalAlignment = 5;
                        subtabla = new PdfPTable(1);
                        subtabla.AddCell(new PdfPCell(foto2) { HorizontalAlignment = 1, VerticalAlignment = 5 });
                        subtabla.AddCell(cellnombrefoto);
                        cellfotografias = new PdfPCell(subtabla);
                        cellfotografias.HorizontalAlignment = 1;
                        cellfotografias.VerticalAlignment = 5;
                        tablefotos.AddCell(cellfotografias);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ha ocurrido un error: " + ex.ToString());
                }
            }
            

            foreach (DocumentoConsigBO docConsig in listaDocs)
            {
                //documento
                PdfPTable documento = new PdfPTable(6);
                //row1
                documento.AddCell(TitleCliente);
                documento.AddCell(cellcliente);
                documento.AddCell(cellnada);
                documento.AddCell(cellnada);
                documento.AddCell(celltitlefecha);
                documento.AddCell(cellfecha);
                //row2
                documento.AddCell(celltitlenave);
                documento.AddCell(cellnave);
                documento.AddCell(cellnada);
                documento.AddCell(cellnada);
                documento.AddCell(titledestino);
                documento.AddCell(celldestino);
                //row3
                documento.AddCell(titlecontenedor);
                documento.AddCell(cellcontenedor);
                PdfPCell titleviaje = new PdfPCell(new Paragraph(("VUELTA"), arialText));
                titleviaje.HorizontalAlignment = 1;
                titleviaje.VerticalAlignment = 5;
                titleviaje.BackgroundColor = BaseColor.LIGHT_GRAY;
                titleviaje.Border = 15;
                documento.AddCell(titleviaje);
                PdfPCell cellviaje = new PdfPCell(new Paragraph(planCons.N_vuelta.ToString(), arialText));
                cellviaje.HorizontalAlignment = 1;
                cellviaje.VerticalAlignment = 5;
                cellviaje.Border = 15;
                documento.AddCell(cellviaje);
                PdfPCell titleReserva = new PdfPCell(new Paragraph("RESERVA", arialText));
                titleReserva.HorizontalAlignment = 1;
                titleReserva.VerticalAlignment = 5;
                titleReserva.BackgroundColor = BaseColor.LIGHT_GRAY;
                titleReserva.Border = 15;
                PdfPCell cellReserva = new PdfPCell(new Paragraph("N/A", arialText));
                cellReserva.HorizontalAlignment = 1;
                cellReserva.VerticalAlignment = 5;
                cellReserva.Border = 15;
                documento.AddCell(titleReserva);
                documento.AddCell(cellReserva);

                PdfPTable datosDoc = new PdfPTable(2);
                PdfPTable participantesDoc = new PdfPTable(2);
                participantesDoc.DefaultCell.Border = 0;

                PdfPCell titledres = new PdfPCell(new Paragraph("DRES", arialText));
                titledres.HorizontalAlignment = 1;
                titledres.VerticalAlignment = 5;
                titledres.Border = 15;
                titledres.BackgroundColor = BaseColor.LIGHT_GRAY;
                PdfPCell celldres = new PdfPCell(new Paragraph(docConsig.Gls_dres, arialText));
                celldres.HorizontalAlignment = 1;
                celldres.VerticalAlignment = 5;
                celldres.Border = 15;
                PdfPCell titleconsignante = new PdfPCell(new Paragraph("CONSIGNANTE", arialText));
                titleconsignante.HorizontalAlignment = 1;
                titleconsignante.VerticalAlignment = 5;
                titleconsignante.Border = 15;
                titleconsignante.BackgroundColor = BaseColor.LIGHT_GRAY;
                PdfPCell cellconsignante = new PdfPCell(new Paragraph(docConsig.Gls_consignante, arialText));
                cellconsignante.HorizontalAlignment = 1;
                cellconsignante.VerticalAlignment = 5;
                cellconsignante.Border = 15;
                PdfPCell titleconsignatario = new PdfPCell(new Paragraph("CONSIGNATARIO", arialText));
                titleconsignatario.HorizontalAlignment = 1;
                titleconsignatario.VerticalAlignment = 5;
                titleconsignatario.Border = 15;
                titleconsignatario.BackgroundColor = BaseColor.LIGHT_GRAY;
                PdfPCell cellconsignatario = new PdfPCell(new Paragraph(docConsig.Gls_consignatario, arialText));
                cellconsignatario.HorizontalAlignment = 1;
                cellconsignatario.VerticalAlignment = 5;
                cellconsignatario.Border = 15;
                PdfPCell titledespachante = new PdfPCell(new Paragraph("DESPACHANTE", arialText));
                titledespachante.HorizontalAlignment = 1;
                titledespachante.VerticalAlignment = 5;
                titledespachante.Border = 15;
                titledespachante.BackgroundColor = BaseColor.LIGHT_GRAY;
                PdfPCell celldespachante = new PdfPCell(new Paragraph(docConsig.Gls_despachante, arialText));
                celldespachante.HorizontalAlignment = 1;
                celldespachante.VerticalAlignment = 5;
                celldespachante.Border = 15;

                participantesDoc.AddCell(titledres);
                participantesDoc.AddCell(celldres);
                participantesDoc.AddCell(titleconsignante);
                participantesDoc.AddCell(cellconsignante);
                participantesDoc.AddCell(titleconsignatario);
                participantesDoc.AddCell(cellconsignatario);
                participantesDoc.AddCell(titledespachante);
                participantesDoc.AddCell(celldespachante);

                datosDoc.AddCell(new PdfPCell(participantesDoc));
                datosDoc.DefaultCell.Border = 0;

                PdfPTable nombreDoc = new PdfPTable(2);
                nombreDoc.DefaultCell.Border = 0;
                nombreDoc.AddCell(cellnada);
                PdfPCell nombreDocum = new PdfPCell(new Paragraph(new TIpoDocumentoBLL().sp_sel_tipoDocIDBLL(docConsig.Tipo_documento) + "\n" + docConsig.Nro_documento, arialHeading));
                nombreDocum.HorizontalAlignment = 1;
                nombreDocum.VerticalAlignment = 5;
                nombreDocum.Border = 15;
                nombreDocum.Colspan = 2;

                nombreDoc.AddCell(nombreDocum);
                PdfPCell nombreDocumento = new PdfPCell(nombreDoc);
                nombreDocumento.Border = 0;
                datosDoc.AddCell((nombreDocumento));

                PdfPTable detalleMercDoc = new PdfPTable(5);
                detalleMercDoc.WidthPercentage = 100;
                PdfPCell titlemarcas = new PdfPCell(new Paragraph("MARCAS/NUMEROS", arialText));
                titlemarcas.HorizontalAlignment = 1;
                titlemarcas.VerticalAlignment = 5;
                titlemarcas.BackgroundColor = BaseColor.LIGHT_GRAY;
                titlemarcas.Border = 15;
                detalleMercDoc.AddCell(titlemarcas);
                PdfPCell titlecontenido = new PdfPCell(new Paragraph("CONTENIDO", arialText));
                titlecontenido.HorizontalAlignment = 1;
                titlecontenido.VerticalAlignment = 5;
                titlecontenido.BackgroundColor = BaseColor.LIGHT_GRAY;
                titlecontenido.Border = 15;
                detalleMercDoc.AddCell(titlecontenido);
                PdfPCell titlebultos = new PdfPCell(new Paragraph("TIPO BULTO", arialText));
                titlebultos.HorizontalAlignment = 1;
                titlebultos.VerticalAlignment = 5;
                titlebultos.Border = 15;
                titlebultos.BackgroundColor = BaseColor.LIGHT_GRAY;
                detalleMercDoc.AddCell(titlebultos);
                PdfPCell titlecantidades = new PdfPCell(new Paragraph("CANTIDAD", arialText));
                titlecantidades.HorizontalAlignment = 1;
                titlecantidades.VerticalAlignment = 5;
                titlecantidades.BackgroundColor = BaseColor.LIGHT_GRAY;
                titlecantidades.Border = 15;
                detalleMercDoc.AddCell(titlecantidades);
                PdfPCell titlekilos = new PdfPCell(new Paragraph("KILOS", arialText));
                titlekilos.HorizontalAlignment = 1;
                titlekilos.VerticalAlignment = 5;
                titlekilos.BackgroundColor = BaseColor.LIGHT_GRAY;
                titlekilos.Border = 15;
                detalleMercDoc.AddCell(titlekilos);

                string jsonMercs = new MercanciaExpoBLL().sp_sel_mercExpoBLL(docConsig.Nro_documento, docConsig.Nro_tarja);
                listMercs = JsonConvert.DeserializeObject<List<MercanciaExpoBO>>(jsonMercs);

                codigosMerc = new Int64[listMercs.Count];
                int i = 0;

                foreach (MercanciaExpoBO merc in listMercs)
                {
                    marca = merc.Gls_marca;
                    cantidad = Convert.ToInt32(merc.N_cantidad);
                    suma += cantidad;
                    codigosMerc[i] = Convert.ToInt64(merc.Cod_mercancia);
                    i++;
                    nomBulto = new BultosBLL().sp_sel_bultosIDBLL(merc.N_bulto).Rows[0].ItemArray[1].ToString();

                    cellmarca = new PdfPCell(new Paragraph(marca, arialText));
                    cellmarca.HorizontalAlignment = 1;
                    cellmarca.VerticalAlignment = 5;
                    cellmarca.Border = 15;
                    detalleMercDoc.AddCell(cellmarca);

                    PdfPCell cellContenido = new PdfPCell(new Paragraph("", arialText));
                    cellContenido.HorizontalAlignment = 1;
                    cellContenido.VerticalAlignment = 5;
                    cellContenido.Border = 15;
                    detalleMercDoc.AddCell(cellContenido);

                    cellbultos = new PdfPCell(new Paragraph(nomBulto, arialText));
                    cellmarca.HorizontalAlignment = 1;
                    cellmarca.VerticalAlignment = 5;
                    cellmarca.Border = 15;
                    detalleMercDoc.AddCell(cellbultos);

                    cellcantidad = new PdfPCell(new Paragraph(cantidad.ToString(), arialText));
                    cellmarca.HorizontalAlignment = 1;
                    cellmarca.VerticalAlignment = 5;
                    cellmarca.Border = 15;
                    detalleMercDoc.AddCell(cellcantidad);

                    PdfPCell cellkilos = new PdfPCell(new Paragraph("", arialText));
                    cellkilos.HorizontalAlignment = 1;
                    cellkilos.VerticalAlignment = 5;
                    cellkilos.Border = 15;
                    detalleMercDoc.AddCell(cellkilos);
                }


                if (planCons.Fecha < fechaLimite)
                {
                    foreach (Int64 codigo in codigosMerc)
                    {
                        try
                        {
                            byte[] imageBytes;
                            string marcaMerc = "";
                            string nombreImagen = string.Empty;
                            List<FotoMercanciaBO> listFotoMerc = new FotoMercanciaBLL().sp_sel_fotoMercExpoBLL(codigo);
                            marcaMerc = new MercanciaExpoBLL().sp_sel_marcaMercBLL(codigo);
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
                                            Image foto = Image.GetInstance(imageBytes);
                                            foto.ScaleAbsolute(159f, 159f);
                                            cellnombrefoto = new PdfPCell(new Paragraph(marcaMerc, arialText));
                                            cellnombrefoto.HorizontalAlignment = 1;
                                            cellnombrefoto.VerticalAlignment = 5;
                                            subtabla = new PdfPTable(1);
                                            subtabla.AddCell(new PdfPCell(foto) { HorizontalAlignment = 1, VerticalAlignment = 5 });
                                            subtabla.AddCell(cellnombrefoto);
                                            cellfotografias = new PdfPCell(subtabla);
                                            cellfotografias.HorizontalAlignment = 1;
                                            cellfotografias.VerticalAlignment = 5;
                                            tablefotos.AddCell(cellfotografias);

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
                            imageBytes = Convert.FromBase64String(base64Img);
                            Image foto2 = Image.GetInstance(imageBytes);
                            foto2.ScaleAbsolute(159f, 159f);
                            cellnombrefoto = new PdfPCell(new Paragraph(marcaMerc, arialText));
                            cellnombrefoto.HorizontalAlignment = 1;
                            cellnombrefoto.VerticalAlignment = 5;
                            subtabla = new PdfPTable(1);
                            subtabla.AddCell(new PdfPCell(foto2) { HorizontalAlignment = 1, VerticalAlignment = 5 });
                            subtabla.AddCell(cellnombrefoto);
                            cellfotografias = new PdfPCell(subtabla);
                            cellfotografias.HorizontalAlignment = 1;
                            cellfotografias.VerticalAlignment = 5;
                            tablefotos.AddCell(cellfotografias);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ha ocurrido un error: " + ex.ToString());
                        }
                    }
                }
                else
                {
                    foreach (Int64 codigo in codigosMerc)
                    {
                        try
                        {
                            string marcaMerc = "";
                            string nombreImagen = string.Empty;
                            List<FotografiasFDM> listFotoMerc = new FotografiasFDM().obtenerFotografias(doctypeMercCons, codigo.ToString());
                            marcaMerc = new MercanciaExpoBLL().sp_sel_marcaMercBLL(codigo);
                            foreach (FotografiasFDM fotoMerc in listFotoMerc)
                            {
                                Image foto2 = Image.GetInstance(new Uri(fotoMerc.url_foto));
                                foto2.ScaleAbsolute(159f, 159f);
                                cellnombrefoto = new PdfPCell(new Paragraph(marcaMerc, arialText));
                                cellnombrefoto.HorizontalAlignment = 1;
                                cellnombrefoto.VerticalAlignment = 5;
                                subtabla = new PdfPTable(1);
                                subtabla.AddCell(new PdfPCell(foto2) { HorizontalAlignment = 1, VerticalAlignment = 5 });
                                subtabla.AddCell(cellnombrefoto);
                                cellfotografias = new PdfPCell(subtabla);
                                cellfotografias.HorizontalAlignment = 1;
                                cellfotografias.VerticalAlignment = 5;
                                tablefotos.AddCell(cellfotografias);
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ha ocurrido un error: " + ex.ToString());
                        }
                    }
                }
                
                tablefotos.AddCell(vacio1);
                tablefotos.AddCell(vacio1);


                doc.NewPage();
                doc.Add(logo);
                doc.Add(salto);
                doc.Add(salto);
                doc.Add(documento);
                doc.Add(salto);
                doc.Add(salto);
                doc.Add(datosDoc);
                doc.Add(salto);
                doc.Add(detalleMercDoc);
            }

            doc.NewPage();
            doc.Add(tablefotos);

            return doc;
        }
    }
}
