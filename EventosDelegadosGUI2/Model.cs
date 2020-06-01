using System;
using System.Collections.Generic;

namespace EventosDelegadosGUI2
{
    class Model
    {
        private View view;
        private List<SalvoConduto> salvoCondutos;

        public Model(View v)
        {
            view = v;
        }

        public int LastIdIssued()
        {
            int max = int.MinValue;
            if (salvoCondutos.Count == 0)
                return -1;
            else
            {
                foreach (SalvoConduto salvoConduto in salvoCondutos)
                {
                    if (salvoConduto.Id > max)
                        max = salvoConduto.Id;
                }
                return max;
            }
        }

        public void CriarNovoSalvoConduto()
        {
            //Criar um novo salvo conduto com os dados indicados
        }
    }
}
