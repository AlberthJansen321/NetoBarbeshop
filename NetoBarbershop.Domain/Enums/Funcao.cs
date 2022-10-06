using System;

namespace NetoBarbershop.Domain.Enums
{

    [Flags]
    public enum Funcao : int
    {
        Admin = 0,
        Funcionario = 1
    }
}
