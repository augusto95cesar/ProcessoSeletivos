﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoIdWeb.ModelView
{
    public class TurmaView
    {
        public int Id { get; set; }
        public string   Descricao { get; set; }
        public int Serie { get; set; }
        public string Turno { get; set; }
        public int CodEscola { get; set; }
    }
}
