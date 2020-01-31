using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPuntoDeVenta.Reporte
{
    public partial class FacturaImprimir : Form
    {
        public FacturaImprimir(int numero)
        {
            ParameterDiscreteValue crtParamDiscreteValue;
            ParameterField crtParamField;
            ParameterFields crtParamFields;

            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamFields = new ParameterFields();

            crtParamDiscreteValue.Value = numero;
            crtParamField.ParameterFieldName = "codigofactura";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);
            
            InitializeComponent();
            crystalReportViewer1.ParameterFieldInfo = crtParamFields;

        }
    }
}
