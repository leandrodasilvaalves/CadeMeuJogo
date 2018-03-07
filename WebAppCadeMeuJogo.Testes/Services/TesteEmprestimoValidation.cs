using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCadeMeuJogo.Interfaces.Services;
using WebAppCadeMeuJogo.Services;
using WebAppCadeMeuJogo.Testes.Mock;

namespace WebAppCadeMeuJogo.Testes.Services
{
    [TestClass]
    public class TesteEmprestimoValidation
    {
        private IEmprestimoValidation validation;

        [TestInitialize]
        public void InicializarTeste()
        {
            validation = new EmprestimoValidation();
        }

        [TestMethod]
        public void DeveraFalhar_SeDataInicio_MenorQueHoje()
        {
            var expected = false;
            var result = validation.ValidarDataInicio(EmprestimoMock.EmprestimoDemoInvalido().DataInicio);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeveraFalhar_SeDataFinal_MaiorQueDataInicial()
        {
            var expected = false;
            var result = validation.ValidarDataFim(EmprestimoMock.EmprestimoDemoInvalido());
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeveraFalhar_SeAmigoId_NaoInformado()
        {
            var expected = false;
            var result = validation.ValidarAmigo(EmprestimoMock.EmprestimoDemoInvalido().AmigoId);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeveraFalhar_SeNenhum_JogoInformado()
        {
            var expected = false;
            var result = validation.ValidarJogos(EmprestimoMock.EmprestimoDemoInvalido().Jogos);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeveraFalhar_SeAlgum_JogoIndisponivel()
        {
            var expected = false;
            //Foi escolhido este mock para o teste porque sua lista de jogos possui jogos indisponíveis enquanto 
            //o mock EmprestimoDemoInvalido possui uma lista vazia e por isso não pode ser utilizado neste teste
            var result = validation.ValidarSeJogosDisponiveis(EmprestimoMock.EmprestimoDemoValido().Jogos);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeveraFalhar_SeAlgumaPropriedadeDoObjejto_Invalida()
        {
            var expected = new Exception();
            var result = validation.IsValid(EmprestimoMock.EmprestimoDemoInvalido());
            Assert.AreEqual(expected, result);
        }

    }
}
