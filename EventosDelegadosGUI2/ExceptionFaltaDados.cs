using System;
using System.Windows.Forms;

namespace HealthyCheckpoint
{
    //Esta class pertence à componente View
    [Serializable]
    public class ExceptionFaltaDados : Exception
    {
        public string campo;
        public Form form;
        public ExceptionFaltaDados() { }

        public ExceptionFaltaDados(string campo, Form form)
        {
            this.campo = campo;
            this.form = form;
        }
        public ExceptionFaltaDados(string message) : base(message) { }
        public ExceptionFaltaDados(string message, Exception inner) : base(message, inner) { }
        protected ExceptionFaltaDados(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
