using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventosDelegadosGUI2
{
    //Esta class pertence à componente View
    [Serializable]
    public class ExceptionFaltaDados : Exception
    {
        public string campo;
        public Form form;
        public ExceptionFaltaDados() { }

        public ExceptionFaltaDados (string campo, Form form)
        {
            this.campo = campo;
            this.form = form;
        }
        public ExceptionFaltaDados(string message) : base(message) {}
        public ExceptionFaltaDados(string message, Exception inner) : base(message, inner) { }
        protected ExceptionFaltaDados(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
