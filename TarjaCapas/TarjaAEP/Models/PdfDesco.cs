namespace TarjaAEP.Models
{
    #region Usings
    using CapaBLL;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using CapaBO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using Newtonsoft.Json;
    using NBarCodes;
    using System.Drawing.Imaging;
    using System.Web.Hosting;
    #endregion
    public class PdfDesco
    {
        public Document BindingData(Document doc, PlanificacionDescBO planDesc, TarjaDescDetBO tarja)
        {
            string jsonCliente = JsonConvert.SerializeObject(new ForwardersBLL().sp_selPlanDesc_forwarderBLL(planDesc.Rut_cliente));
            ForwardersBO cliente = JsonConvert.DeserializeObject<ForwardersBO>(jsonCliente.Trim(new char[] { '[', ']' }));

            string jsonNave = JsonConvert.SerializeObject(new NavesBLL().sp_sel_naveIDBLL(planDesc.Cod_nave));
            NavesBO nave = JsonConvert.DeserializeObject<NavesBO>(jsonNave.Trim(new char[] { '[', ']' }));

            string jsonPuertoO = JsonConvert.SerializeObject(new PuertoBLL().sp_sel_puertoIDBLL(planDesc.Pue_codO));
            PuertosBO puerto_or = JsonConvert.DeserializeObject<PuertosBO>(jsonPuertoO.Trim(new char[] { '[', ']' }));

            string jsonPuertoD = JsonConvert.SerializeObject(new PuertoBLL().sp_sel_puertoIDBLL(planDesc.Pue_codD));
            PuertosBO puerto_dest = JsonConvert.DeserializeObject<PuertosBO>(jsonPuertoD.Trim(new char[] { '[', ']' }));

            string jsonTarjador = JsonConvert.SerializeObject(new PersonasBLL().sp_sel_personasIDBLL(planDesc.Rut_tarjador));
            PersonasBO tarjador = JsonConvert.DeserializeObject<PersonasBO>(jsonTarjador.Trim(new char[] { '[', ']' }));

            DataTable personasT = new PersonasBLL().sp_sel_personasTarjaBLL(tarja.Nro_tarja);

            string movilizadores = string.Empty;
            string horquillero = string.Empty;

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

            var settings = new BarCodeSettings
            {
                Type = BarCodeType.Code128,
                Data = tarja.Nro_tarja.ToString()
            };

            var generator = new BarCodeGenerator(settings);
            Image imgbarcode;
            using (var barcodeImage = generator.GenerateImage())
            {
                ImageFormat format = ImageFormat.Bmp;
                imgbarcode = Image.GetInstance(barcodeImage, format);
                imgbarcode.ScalePercent(100f);
            }

            Font arialHeading = FontFactory.GetFont("Arial", 15, 1);
            Font arialText = FontFactory.GetFont("Arial", 10, 1);
            string logoPath = HostingEnvironment.MapPath("~/assets/custom/images");

            //Añadir encabezado
            PdfPTable tableHeader = new PdfPTable(3);
            PdfPCell subheader = new PdfPCell(imgbarcode);
            subheader.HorizontalAlignment = 1;
            subheader.VerticalAlignment = 5;
            subheader.Border = 0;
            tableHeader.WidthPercentage = 100;
            tableHeader.DefaultCell.Border = 0;
            tableHeader.DefaultCell.HorizontalAlignment = 1;
            tableHeader.DefaultCell.VerticalAlignment = 5;

            Image logo = Image.GetInstance(logoPath + "/logo.png");
            tableHeader.AddCell(logo);
            Paragraph titulo = new Paragraph("Documento de Desconsolidado", arialHeading);
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
            PdfPCell TitleCliente = new PdfPCell(new Paragraph("Cliente", arialText));
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
            PdfPCell celltitlecontainer = new PdfPCell(new Paragraph("Contenedor", arialText));
            celltitlecontainer.HorizontalAlignment = 1;
            celltitlecontainer.VerticalAlignment = 5;
            celltitlecontainer.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPCell cellcontainer = new PdfPCell(new Paragraph(planDesc.Cod_contenedor.Substring(0, 4) + "-" + planDesc.Cod_contenedor.Substring(4, 6) + "-" + planDesc.Cod_contenedor.Substring(10, 1), arialText));
            cellcontainer.HorizontalAlignment = 1;
            cellcontainer.VerticalAlignment = 5;
            //row2 inicializacion
            PdfPCell celltitlenave = new PdfPCell(new Paragraph("Nave", arialText));
            celltitlenave.BackgroundColor = BaseColor.LIGHT_GRAY;
            celltitlenave.HorizontalAlignment = 1;
            celltitlenave.VerticalAlignment = 5;
            PdfPCell cellnave = new PdfPCell(new Paragraph(nave.Nav_nom, arialText));
            cellnave.HorizontalAlignment = 1;
            cellnave.VerticalAlignment = 5;
            PdfPCell celltitleFechaI = new PdfPCell(new Paragraph("Fecha Inicio", arialText));
            celltitleFechaI.BackgroundColor = BaseColor.LIGHT_GRAY;
            celltitleFechaI.HorizontalAlignment = 1;
            celltitleFechaI.VerticalAlignment = 5;
            PdfPCell cellFechaI = new PdfPCell(new Paragraph(planDesc.Fecha.ToString("dd-MM-yyyy").Substring(0, 10), arialText));
            cellFechaI.HorizontalAlignment = 1;
            cellFechaI.VerticalAlignment = 5;
            PdfPCell celltitleiso = new PdfPCell(new Paragraph("Codigo Iso", arialText));
            celltitleiso.BackgroundColor = BaseColor.LIGHT_GRAY;
            celltitleiso.HorizontalAlignment = 1;
            celltitleiso.VerticalAlignment = 5;
            PdfPCell celliso = new PdfPCell(new Paragraph(planDesc.Cod_iso, arialText));
            celliso.HorizontalAlignment = 1;
            celliso.VerticalAlignment = 5;
            //row3 inicializacion
            PdfPCell titleviaje = new PdfPCell(new Paragraph("Viaje/Etapa", arialText));
            titleviaje.BackgroundColor = BaseColor.LIGHT_GRAY;
            titleviaje.HorizontalAlignment = 1;
            titleviaje.VerticalAlignment = 5;
            PdfPCell cellviaje = new PdfPCell(new Paragraph(planDesc.Cod_viaje.ToString(), arialText));
            cellviaje.HorizontalAlignment = 1;
            cellviaje.VerticalAlignment = 5;
            PdfPCell celltitlefecha = new PdfPCell(new Paragraph("Fecha Termino", arialText));
            celltitlefecha.BackgroundColor = BaseColor.LIGHT_GRAY;
            celltitlefecha.HorizontalAlignment = 1;
            celltitlefecha.VerticalAlignment = 5;
            PdfPCell cellfecha = new PdfPCell(new Paragraph(planDesc.FechaT.ToString("dd-MM-yyyy").Substring(0, 10), arialText));
            cellfecha.HorizontalAlignment = 1;
            cellfecha.VerticalAlignment = 5;
            PdfPCell celltitletara = new PdfPCell(new Paragraph("Tara (Kg.)", arialText));
            celltitletara.HorizontalAlignment = 1;
            celltitletara.VerticalAlignment = 5;
            celltitletara.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPCell celltara = new PdfPCell(new Paragraph(planDesc.Tara.ToString(), arialText));
            celltara.HorizontalAlignment = 1;
            celltara.VerticalAlignment = 5;
            //row4 inicializacion
            PdfPCell titlemanifiesto = new PdfPCell(new Paragraph("Duración Faena", arialText));
            titlemanifiesto.BackgroundColor = BaseColor.LIGHT_GRAY;
            titlemanifiesto.HorizontalAlignment = 1;
            titlemanifiesto.VerticalAlignment = 5;
            PdfPCell cellmanifiesto = new PdfPCell(new Paragraph(planDesc.Duracion * 60 + " Min.", arialText));
            cellmanifiesto.HorizontalAlignment = 1;
            cellmanifiesto.VerticalAlignment = 5;
            PdfPCell titleturno = new PdfPCell(new Paragraph("Mano de Trabajo", arialText));
            titleturno.BackgroundColor = BaseColor.LIGHT_GRAY;
            titleturno.HorizontalAlignment = 1;
            celltitlefecha.VerticalAlignment = 5;
            PdfPCell cellturno = new PdfPCell(new Paragraph(planDesc.Mddt, arialText));
            cellturno.HorizontalAlignment = 1;
            cellturno.VerticalAlignment = 5;
            PdfPCell titlesello1 = new PdfPCell(new Paragraph("Sello 1 (Manifestado/Fisico)", arialText));
            titlesello1.HorizontalAlignment = 1;
            titlesello1.VerticalAlignment = 5;
            titlesello1.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPCell cellsello1 = new PdfPCell(new Paragraph(planDesc.Sello1 + " / " + planDesc.SelloFis1, arialText));
            cellsello1.HorizontalAlignment = 1;
            cellsello1.VerticalAlignment = 5;
            //row5 inicializacion
            PdfPCell titleorigen = new PdfPCell(new Paragraph("Origen", arialText));
            titleorigen.BackgroundColor = BaseColor.LIGHT_GRAY;
            titleorigen.HorizontalAlignment = 1;
            titleorigen.VerticalAlignment = 5;
            PdfPCell cellorigen = new PdfPCell(new Paragraph(puerto_or.Gls_nombre_puerto, arialText));
            cellorigen.HorizontalAlignment = 1;
            cellorigen.VerticalAlignment = 5;
            PdfPCell titlehorai = new PdfPCell(new Paragraph("Hora Inicio", arialText));
            titlehorai.BackgroundColor = BaseColor.LIGHT_GRAY;
            titlehorai.HorizontalAlignment = 1;
            titlehorai.VerticalAlignment = 5;
            PdfPCell cellhorai = new PdfPCell(new Paragraph(planDesc.HoraIR.ToString(), arialText));
            cellhorai.HorizontalAlignment = 1;
            cellhorai.VerticalAlignment = 5;
            PdfPCell titlesello2 = new PdfPCell(new Paragraph("Sello 2 (Manifestado/Fisico)", arialText));
            titlesello2.HorizontalAlignment = 1;
            titlesello2.VerticalAlignment = 5;
            titlesello2.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPCell cellsello2 = new PdfPCell(new Paragraph(planDesc.Sello2 + " / " + planDesc.SelloFis2, arialText));
            cellsello2.HorizontalAlignment = 1;
            cellsello2.VerticalAlignment = 5;
            //row6 inicializacion
            PdfPCell titledestino = new PdfPCell(new Paragraph("Destino", arialText));
            titledestino.BackgroundColor = BaseColor.LIGHT_GRAY;
            titledestino.HorizontalAlignment = 1;
            titledestino.VerticalAlignment = 5;
            PdfPCell celldestino = new PdfPCell(new Paragraph(puerto_dest.Gls_nombre_puerto, arialText));
            celldestino.HorizontalAlignment = 1;
            celldestino.VerticalAlignment = 5;
            PdfPCell titlehorat = new PdfPCell(new Paragraph("Hora Termino", arialText));
            titlehorat.BackgroundColor = BaseColor.LIGHT_GRAY;
            titlehorat.HorizontalAlignment = 1;
            titlehorat.VerticalAlignment = 5;
            PdfPCell cellhorat = new PdfPCell(new Paragraph(planDesc.HoraTR.ToString(), arialText));
            cellhorat.HorizontalAlignment = 1;
            cellhorat.VerticalAlignment = 5;
            PdfPCell titlesello3 = new PdfPCell(new Paragraph("Sello 3 (Manifestado/Fisico)", arialText));
            titlesello3.HorizontalAlignment = 1;
            titlesello3.VerticalAlignment = 5;
            titlesello3.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPCell cellsello3 = new PdfPCell(new Paragraph(planDesc.Sello3 + " / " + planDesc.SelloFis3, arialText));
            cellsello3.HorizontalAlignment = 1;
            cellsello3.VerticalAlignment = 5;


            //row1
            detailTable.AddCell(TitleCliente);
            detailTable.AddCell(cellrutCliente);
            detailTable.AddCell(cellcliente);
            detailTable.AddCell(vacio1);
            detailTable.AddCell(celltitlecontainer);
            detailTable.AddCell(cellcontainer);
            //row2
            detailTable.AddCell(celltitlenave);
            detailTable.AddCell(cellnave);
            detailTable.AddCell(celltitleFechaI);
            detailTable.AddCell(cellFechaI);
            detailTable.AddCell(celltitleiso);
            detailTable.AddCell(celliso);
            //row3
            detailTable.AddCell(titleviaje);
            detailTable.AddCell(cellviaje);
            detailTable.AddCell(celltitlefecha);
            detailTable.AddCell(cellfecha);
            detailTable.AddCell(celltitletara);
            detailTable.AddCell(celltara);
            //row4
            detailTable.AddCell(titlemanifiesto);
            detailTable.AddCell(cellmanifiesto);
            detailTable.AddCell(titleturno);
            detailTable.AddCell(cellturno);
            detailTable.AddCell(titlesello1);
            detailTable.AddCell(cellsello1);
            //row5
            detailTable.AddCell(titleorigen);
            detailTable.AddCell(cellorigen);
            detailTable.AddCell(titlehorai);
            detailTable.AddCell(cellhorai);
            detailTable.AddCell(titlesello2);
            detailTable.AddCell(cellsello2);
            //row6
            detailTable.AddCell(titledestino);
            detailTable.AddCell(celldestino);
            detailTable.AddCell(titlehorat);
            detailTable.AddCell(cellhorat);
            detailTable.AddCell(titlesello3);
            detailTable.AddCell(cellsello3);

            ////tabla contenedor
            PdfPTable detailConte = new PdfPTable(3);
            detailConte.WidthPercentage = 100;
            detailConte.DefaultCell.HorizontalAlignment = 1;
            detailConte.DefaultCell.VerticalAlignment = 5;

            ////row 1
            Image vector = Image.GetInstance(logoPath + "/vector.png");
            vector.ScalePercent(52f);
            PdfPCell cellFotoCont = new PdfPCell(vector);
            cellFotoCont.HorizontalAlignment = 1;
            cellFotoCont.VerticalAlignment = 5;
            PdfPTable tableSecVec = new PdfPTable(2);
            List<SectorVectorBO> listSector = JsonConvert.DeserializeObject<List<SectorVectorBO>>(new SectorVectorBLL().sp_sel_sectorVectorIDDAL(tarja.Nro_tarja));
            string codEstado, nroSector, estado;
            int j = 1;
            foreach (SectorVectorBO sector in listSector)
            {
                codEstado = sector.Cod_estado.ToString();
                nroSector = sector.Nro_sector.ToString();
                PdfPCell estadoSec = new PdfPCell();
                estado = sector.Gls_nombre_estado.ToString();

                estadoSec.AddElement(new Paragraph(nroSector + " " + estado, arialText));
                estadoSec.BackgroundColor = BaseColor.YELLOW;
                estadoSec.HorizontalAlignment = 1;
                estadoSec.VerticalAlignment = 5;
                if (codEstado.Equals("S"))
                {
                    estadoSec.BackgroundColor = BaseColor.WHITE;
                }

                tableSecVec.AddCell(estadoSec);
            }

            tableSecVec.AddCell("");

            PdfPCell cellEstadosSec = new PdfPCell(tableSecVec);

            PdfPTable tableObs = new PdfPTable(1);
            PdfPCell titleObs = new PdfPCell(new Paragraph("OBSERVACIONES GENERALES", arialText));
            titleObs.HorizontalAlignment = 1;
            titleObs.VerticalAlignment = 5;
            titleObs.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPCell cellObs = new PdfPCell(new Paragraph(tarja.Observacion, arialText));
            tableObs.AddCell(titleObs);
            tableObs.AddCell(cellObs);

            PdfPCell obs = new PdfPCell(tableObs);

            detailConte.AddCell(cellFotoCont);
            detailConte.AddCell(cellEstadosSec);
            detailConte.AddCell(obs);

            //tabla detalles personas
            PdfPTable tablapersonas = new PdfPTable(4);
            tablapersonas.WidthPercentage = 100;
            //row1
            PdfPCell titlegrua = new PdfPCell(new Paragraph("GRUA", arialText));
            titlegrua.BackgroundColor = BaseColor.LIGHT_GRAY;
            titlegrua.HorizontalAlignment = 1;
            titlegrua.VerticalAlignment = 5;
            PdfPCell cellgrua = new PdfPCell(new Paragraph(tarja.Grua_cod, arialText));
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

            tablapersonas.AddCell(titlegrua);
            tablapersonas.AddCell(cellgrua);
            tablapersonas.AddCell(titlemovilizadores);
            tablapersonas.AddCell(titletarjador);
            tablapersonas.AddCell(titlehorquillero);
            tablapersonas.AddCell(cellhorquillero);
            tablapersonas.AddCell(cellmovilizadeores);
            tablapersonas.AddCell(celltarjador);

            ////Tabla Merc
            Int64[] codigosMerc;
            string[] marcas = null;
            List<MercanciasDescBO> listMerc = null;
            PdfPTable detalleMerc = new PdfPTable(6);
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
            PdfPCell titleretiro = new PdfPCell(new Paragraph("TIPO DE RETIRO", arialText));
            titleretiro.HorizontalAlignment = 1;
            titleretiro.VerticalAlignment = 5;
            titleretiro.BackgroundColor = BaseColor.LIGHT_GRAY;
            titlebulto.Border = 15;
            detalleMerc.AddCell(titleretiro);
            PdfPCell titlecantidad = new PdfPCell(new Paragraph("CANTIDAD", arialText));
            titlecantidad.HorizontalAlignment = 1;
            titlecantidad.VerticalAlignment = 5;
            titlecantidad.BackgroundColor = BaseColor.LIGHT_GRAY;
            titlecantidad.Border = 15;
            detalleMerc.AddCell(titlecantidad);
            PdfPCell titleTotalmarca = new PdfPCell(new Paragraph("TOTAL", arialText));
            titleTotalmarca.HorizontalAlignment = 1;
            titleTotalmarca.VerticalAlignment = 5;
            titleTotalmarca.BackgroundColor = BaseColor.LIGHT_GRAY;
            titleTotalmarca.Border = 15;
            detalleMerc.AddCell(titleTotalmarca);
            PdfPCell titleobs = new PdfPCell(new Paragraph("OBSERVACIONES", arialText));
            titleobs.HorizontalAlignment = 1;
            titleobs.VerticalAlignment = 5;
            titleobs.BackgroundColor = BaseColor.LIGHT_GRAY;
            titleobs.Border = 15;
            detalleMerc.AddCell(titleobs);
            PdfPCell cellmarca, cellbultos, cellretiro, cellcantidad, celltotalM, cellobs, celltotal;
            string nomBulto = "";
            int suma = 0;
            try
            {
                listMerc = new MercanciasDescBll().sp_sel_mercDescBLL(tarja.Nro_tarja);
                int i = 0;
                codigosMerc = new Int64[listMerc.Count];
                marcas = new string[listMerc.Count];
                foreach (MercanciasDescBO mercs in listMerc)
                {
                    int cantidadB = 0;
                    string cantidad = string.Empty;
                    string observacioMerc = string.Empty;
                    codigosMerc[i] = mercs.Cod_mercancia;
                    if (!verificarMarca(marcas, mercs.Gls_marca))
                    {
                        marcas[i] = mercs.Gls_marca;
                        foreach (MercanciasDescBO mercAux in listMerc)
                        {
                            if (mercAux.Gls_marca.Equals(mercs.Gls_marca))
                            {
                                cantidad += mercAux.N_cantidad.ToString() + " + ";
                                observacioMerc += " " + mercAux.Observacion;
                                cantidadB += mercAux.N_cantidad;
                                nomBulto = mercAux.Desc_bulto;
                            }
                        }
                        cantidad = cantidad.Substring(0, cantidad.Length - 2);
                        suma += cantidadB;
                        cellmarca = new PdfPCell(new Paragraph(mercs.Gls_marca, arialText));
                        cellmarca.HorizontalAlignment = 1;
                        cellmarca.VerticalAlignment = 5;
                        cellmarca.Border = 15;
                        detalleMerc.AddCell(cellmarca);
                        cellbultos = new PdfPCell(new Paragraph(nomBulto, arialText));
                        cellbultos.HorizontalAlignment = 1;
                        cellbultos.VerticalAlignment = 5;
                        cellbultos.Border = 15;
                        detalleMerc.AddCell(cellbultos);
                        cellretiro = new PdfPCell(new Paragraph(mercs.Gls_retiro, arialText));
                        cellretiro.HorizontalAlignment = 1;
                        cellretiro.VerticalAlignment = 5;
                        cellretiro.Border = 15;
                        detalleMerc.AddCell(cellretiro);
                        cellcantidad = new PdfPCell(new Paragraph(cantidad.ToString(), arialText));
                        cellcantidad.HorizontalAlignment = 1;
                        cellcantidad.VerticalAlignment = 5;
                        cellcantidad.Border = 15;
                        detalleMerc.AddCell(cellcantidad);
                        celltotalM = new PdfPCell(new Paragraph(cantidadB.ToString(), arialText));
                        celltotalM.HorizontalAlignment = 1;
                        celltotalM.VerticalAlignment = 5;
                        celltotalM.Border = 15;
                        detalleMerc.AddCell(celltotalM);
                        cellobs = new PdfPCell(new Paragraph(observacioMerc, arialText));
                        cellobs.HorizontalAlignment = 1;
                        cellobs.VerticalAlignment = 5;
                        cellobs.Border = 15;
                        detalleMerc.AddCell(cellobs);

                    }

                    i++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error: " + ex.ToString());
            }
            PdfPCell titletotal = new PdfPCell(new Paragraph("TOTAL", arialText));
            titletotal.Border = 15;
            titletotal.HorizontalAlignment = 1;
            titletotal.VerticalAlignment = 5;
            titletotal.BackgroundColor = BaseColor.LIGHT_GRAY;
            detalleMerc.AddCell(titletotal);

            celltotal = new PdfPCell(new Paragraph(suma.ToString(), arialText));
            celltotal.HorizontalAlignment = 1;
            celltotal.VerticalAlignment = 5;
            celltotal.Border = 15;
            detalleMerc.AddCell(celltotal);
            PdfPCell cellnada = new PdfPCell(new Paragraph(""));
            cellnada.Border = 0;
            detalleMerc.AddCell(cellnada);
            detalleMerc.AddCell(cellnada);
            detalleMerc.AddCell(cellnada);
            detalleMerc.AddCell(cellnada);

            PdfPTable tablefotos = new PdfPTable(3);
            tablefotos.WidthPercentage = 100;
            PdfPCell titletable = new PdfPCell(new Paragraph("FOTOGRAFIAS DESCONSOLIDADO", arialText));
            titletable.Border = 15;
            titletable.HorizontalAlignment = 1;
            titletable.VerticalAlignment = 5;
            titletable.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPCell cellfoto, cellnombrefoto;
            String base64Img = "";
            PdfPTable subtabla = new PdfPTable(1);
            PdfPCell cellfotografias;
            try
            {
                byte[] imageBytes;
                List<FotoContenedorBO> listFotos = new FotoContenedorBLL().sp_sel_fotoContDescBLL(tarja.Nro_tarja);
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
                                Image foto = Image.GetInstance(imageBytes);
                                foto.ScalePercent(15f);
                                cellfoto = new PdfPCell(foto);
                                cellfoto.HorizontalAlignment = 1;
                                cellfoto.VerticalAlignment = 5;
                                cellnombrefoto = new PdfPCell(new Paragraph(nombreImagen, arialText));
                                cellnombrefoto.HorizontalAlignment = 1;
                                cellnombrefoto.VerticalAlignment = 5;
                                subtabla = new PdfPTable(1);
                                subtabla.AddCell(cellfoto);
                                subtabla.AddCell(cellnombrefoto);
                                cellfotografias = new PdfPCell(subtabla);
                                cellfotografias.HorizontalAlignment = 1;
                                cellfotografias.VerticalAlignment = 5;
                                tablefotos.AddCell(cellfotografias);
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
                    Image foto2 = Image.GetInstance(imageBytes);
                    foto2.ScalePercent(15f);
                    cellfoto = new PdfPCell(foto2);
                    cellfoto.HorizontalAlignment = 1;
                    cellfoto.VerticalAlignment = 5;
                    cellnombrefoto = new PdfPCell(new Paragraph(nombreImagen, arialText));
                    cellnombrefoto.HorizontalAlignment = 1;
                    cellnombrefoto.VerticalAlignment = 5;
                    subtabla = new PdfPTable(1);
                    subtabla.AddCell(cellfoto);
                    subtabla.AddCell(cellnombrefoto);
                    cellfotografias = new PdfPCell(subtabla);
                    cellfotografias.HorizontalAlignment = 1;
                    cellfotografias.VerticalAlignment = 5;
                    tablefotos.AddCell(cellfotografias);
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
                                    Image foto = Image.GetInstance(imageBytes);
                                    foto.ScalePercent(15f);
                                    cellfoto = new PdfPCell(foto);
                                    cellfoto.HorizontalAlignment = 1;
                                    cellfoto.VerticalAlignment = 5;
                                    cellnombrefoto = new PdfPCell(new Paragraph(marcaMerc, arialText));
                                    cellnombrefoto.HorizontalAlignment = 1;
                                    cellnombrefoto.VerticalAlignment = 5;
                                    subtabla = new PdfPTable(1);
                                    subtabla.AddCell(cellfoto);
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
                    if (!string.IsNullOrEmpty(nombreImagen))
                    {
                        imageBytes = Convert.FromBase64String(base64Img);
                        Image foto2 = Image.GetInstance(imageBytes);
                        foto2.ScalePercent(15f);
                        cellfoto = new PdfPCell(foto2);
                        cellfoto.HorizontalAlignment = 1;
                        cellfoto.VerticalAlignment = 5;
                        cellnombrefoto = new PdfPCell(new Paragraph(marcaMerc, arialText));
                        cellnombrefoto.HorizontalAlignment = 1;
                        cellnombrefoto.VerticalAlignment = 5;
                        subtabla = new PdfPTable(1);
                        subtabla.AddCell(cellfoto);
                        subtabla.AddCell(cellnombrefoto);
                        cellfotografias = new PdfPCell(subtabla);
                        cellfotografias.HorizontalAlignment = 1;
                        cellfotografias.VerticalAlignment = 5;
                        tablefotos.AddCell(cellfotografias);

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
                List<FotoContenedorBO> listFotosFin = new FotoContenedorBLL().sp_sel_fotoContFinBLL(tarja.Nro_tarja);
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
                                Image foto = Image.GetInstance(imageBytes);
                                foto.ScalePercent(15f);
                                cellfoto = new PdfPCell(foto);
                                cellfoto.HorizontalAlignment = 1;
                                cellfoto.VerticalAlignment = 5;
                                cellnombrefoto = new PdfPCell(new Paragraph(nombreImagen, arialText));
                                cellnombrefoto.HorizontalAlignment = 1;
                                cellnombrefoto.VerticalAlignment = 5;
                                subtabla = new PdfPTable(1);
                                subtabla.AddCell(cellfoto);
                                subtabla.AddCell(cellnombrefoto);
                                cellfotografias = new PdfPCell(subtabla);
                                cellfotografias.HorizontalAlignment = 1;
                                cellfotografias.VerticalAlignment = 5;
                                tablefotos.AddCell(cellfotografias);
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
                    Image foto2 = Image.GetInstance(imageBytes);
                    foto2.ScalePercent(15f);
                    cellfoto = new PdfPCell(foto2);
                    cellfoto.HorizontalAlignment = 1;
                    cellfoto.VerticalAlignment = 5;
                    cellnombrefoto = new PdfPCell(new Paragraph(nombreImagen, arialText));
                    cellnombrefoto.HorizontalAlignment = 1;
                    cellnombrefoto.VerticalAlignment = 5;
                    subtabla = new PdfPTable(1);
                    subtabla.AddCell(cellfoto);
                    subtabla.AddCell(cellnombrefoto);
                    cellfotografias = new PdfPCell(subtabla);
                    cellfotografias.HorizontalAlignment = 1;
                    cellfotografias.VerticalAlignment = 5;
                    tablefotos.AddCell(cellfotografias);
                }

                nombreImagen = "";
                base64Img = "";
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error: " + ex.ToString());
            }
            tablefotos.AddCell(vacio1);
            tablefotos.AddCell(vacio1);

            Paragraph vacio = new Paragraph();
            vacio.Add("\n");
            Paragraph p1 = new Paragraph();
            p1.Add(tableHeader);
            Paragraph p2 = new Paragraph();
            p2.Add(detailTable);
            Paragraph p3 = new Paragraph();
            p3.Add(detailConte);
            Paragraph p4 = new Paragraph();
            p4.Add(tablapersonas);
            Paragraph p5 = new Paragraph();
            p5.Add(detalleMerc);
            Paragraph p6 = new Paragraph();
            p6.Add(tablefotos);

            doc.Add(p1);
            doc.Add(vacio);
            doc.Add(p2);
            doc.Add(p3);
            doc.Add(p4);
            doc.NewPage();
            doc.Add(p5);
            doc.NewPage();
            doc.Add(p6);
            return doc;
        }


        public bool verificarMarca(String[] marcas, string marca)
        {
            bool esta = false;
            if (marcas != null)
            {
                foreach (string marquita in marcas)
                {
                    if (marquita != null)
                    {
                        if (marquita.Equals(marca))
                        {
                            esta = true;
                        }
                    }

                }
            }

            return esta;
        }
    }
}