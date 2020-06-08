namespace HealthyCheckpoint
{
    //Esta classe pertecence ao componente Model
    class SalvoConduto : ISalvoConduto
    {
        private int id;
        private string origem;
        private string destino;
        private string referencia;
        private bool valido;






        public SalvoConduto(string origem, string destino, int lastIdIssued)
        {
            Id = lastIdIssued + 1;
            Origem = origem;
            Destino = destino;
            Referencia = DefineReferencia();
            Valido = true;
            System.Windows.Forms.Clipboard.SetText(Referencia);
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Origem
        {
            get { return origem; }
            set { origem = value; }
        }

        public string Destino
        {
            get { return destino; }
            set { destino = value; }
        }

        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        public bool Valido
        {
            get { return valido; }
            set { valido = value; }
        }

        private string DefineReferencia()
        {
            //A referencia é composta pelo GrupoDataHora da criação do Salvo-Conduto com o ide com 8 algarismos.
            referencia = Gdh.ActualGdh() + id.ToString("D8");
            return referencia;
        }


    }

    public interface ISalvoConduto
    {
        string Origem { get; }
        string Destino { get; }
        string Referencia { get; }
        bool Valido { get; }
    }
}
