using System.Text.RegularExpressions;

namespace RegistroDePlacas.Domain.Usuarios
{
    public record CPF
    {
        public string Numero { get; }

        public CPF(string numero)
        {
            numero = RemoverNaoNumericos(numero);
            if (!EhValido(numero))
            {
                throw new ArgumentException("CPF inválido");
            }

            Numero = numero;
        }

        private bool EhValido(string cpf)
        {
            // CPF já está sem caracteres não numéricos nesta etapa
            if (cpf.Length != 11)
            {
                return false;
            }

            if (cpf.Distinct().Count() == 1)
            {
                return false;
            }

            var cpfArray = cpf.Select(c => int.Parse(c.ToString())).ToArray();
            var soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += cpfArray[i] * (10 - i);
            }

            var primeiroDigitoVerificador = (soma % 11) < 2 ? 0 : 11 - (soma % 11);

            if (cpfArray[9] != primeiroDigitoVerificador)
            {
                return false;
            }

            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += cpfArray[i] * (11 - i);
            }

            var segundoDigitoVerificador = (soma % 11) < 2 ? 0 : 11 - (soma % 11);

            return cpfArray[10] == segundoDigitoVerificador;
        }

        private string RemoverNaoNumericos(string input)
        {
            return Regex.Replace(input, @"[^\d]", "");
        }
    }
}