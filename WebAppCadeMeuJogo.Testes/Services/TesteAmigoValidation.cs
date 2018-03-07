using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebAppCadeMeuJogo.Interfaces.Services;
using WebAppCadeMeuJogo.Services;
using WebAppCadeMeuJogo.Testes.Mock;

namespace WebAppCadeMeuJogo.Testes.Services
{
    [TestClass]
    public class TesteAmigoValidation
    {
        private IAmigoValidation validation;

        [TestInitialize]
        public void InicializarTeste()
        {
            validation = new AmigoValidation();
        }

        [TestMethod]
        public void DeveraFalhar_SeMenorQue_2Digitos()
        {
            var expected = false;
            var result = validation.ValidarNome(AmigoMock.AmigoDemoInvalido().Nome);
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void DeveraPassar_SeNomeMaiorQue_2Digitos()
        {
            var expected = true;
            var result = validation.ValidarNome(AmigoMock.AmigoDemoValido().Nome);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeveraFalhar_SeIdadeMenorQue12()
        {
            var expected = false;
            var result = validation.ValidarDataNascimento(AmigoMock.AmigoDemoInvalido().DataNascimento);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeveraPassar_SeIdadeMaiorOuIgual_12()
        {
            var expected = true;
            var result = validation.ValidarDataNascimento(AmigoMock.AmigoDemoValido().DataNascimento);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeveraFalhar_SeCPFInvalido()
        {
            var expected = false;
            var result = validation.ValidarCPF(AmigoMock.AmigoDemoInvalido().CPF);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeveraPassar_SeCPFValido()
        {
            var expected = true;
            var result = validation.ValidarCPF(AmigoMock.AmigoDemoValido().CPF);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeveraPassar_SeObjetoValido_PorCompleto()
        {
            var expected = true;
            var result = validation.IsValid(AmigoMock.AmigoDemoValido());
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeveraFalhar_SeAlgumaPropriedadeDoObjejto_Invalida()
        {
            var expected = new Exception();
            var result = validation.IsValid(AmigoMock.AmigoDemoInvalido());
            Assert.AreEqual(expected, result);
        }
    }
}
