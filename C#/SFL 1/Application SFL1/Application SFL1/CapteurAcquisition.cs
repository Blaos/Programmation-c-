using System;
using System.Web.Script.Serialization;
using System.Windows;

namespace Application_SFL1
{
    public class CapteurAcquisition
    {
        public float force_vent { get; set; }

        public float puissance { get; set; }

        public CapteurAcquisition()
        {
            force_vent = 0;
            puissance = 0;
        }

        public static CapteurAcquisition ToDeserializeCapteurAcquisition(string sCapteurAcquisitionSerialized)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            CapteurAcquisition oCapteurAcquisition = null;

            try
            {
                oCapteurAcquisition = ser.Deserialize<CapteurAcquisition>(sCapteurAcquisitionSerialized);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de désérialization du capteur d'acquisition en json.", string.Empty, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            return oCapteurAcquisition;
        }
    }
}
