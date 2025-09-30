using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaCadastro.Model
{               // Classe simples que representa os dados do Locatário
       public class Usuario
        {
            // Nome do usuário
            public string Nome { get; set; }

            // E-mail do usuário
            public string Email { get; set; }

            // CPF do usuário
            public string CPF { get; set; }

            // Endereço do usuário
            public string Endereco { get; set; }
        }
    

}

