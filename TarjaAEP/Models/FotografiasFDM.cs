using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace TarjaAEP.Models
{
    public class FotografiasFDM
    {

        public string nombre_foto { get; set; }
        public string url_foto { get; set; }


        public List<FotografiasFDM> obtenerFotografias(string docType, string docNum)
        {
            List<FotografiasFDM> fotografias = new List<FotografiasFDM>();

            var xmlRequest =
                new XElement("Request_ValidatesFile",
                    new XElement("DocType", docType),
                    new XElement("DocNumber", docNum)
                    );

            //Realiza la validación
            var xmlReader = xmlRequest.CreateReader();

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlReader);

            XmlNode xmlResponse;

            var wsReference = new wsFdm.FdmSoapClient();
            xmlResponse = wsReference.UrlFile(xmlDoc);

            foreach (XmlNode chldNode in xmlResponse.ChildNodes)
            {

                var foto = new FotografiasFDM();


                foto.url_foto = chldNode.InnerText;
                string data = chldNode.OuterXml;
                int pos1 = data.IndexOf("nombre");
                pos1 = data.IndexOf("=", pos1);
                int pos2 = data.IndexOf("tipo");
                string nombre = data.Substring(pos1 + 2, pos2 - pos1 - 4);

                foto.nombre_foto = nombre;

                fotografias.Add(foto);
            }

            return fotografias;
        }


    }
}