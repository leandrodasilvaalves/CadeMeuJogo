using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebAppCadeMeuJogo.Interfaces.Services;
using WebAppCadeMeuJogo.Services;
using WebAppCadeMeuJogo.Testes.Mock;

namespace WebAppCadeMeuJogo.Testes.Services
{
    [TestClass]
    public class TesteCategoriaValidation
    {
        private ICategoriaValidation validation;

        [TestInitialize]
        public void InicializarTeste()
        {
            validation = new CategoriaValidation();
        }

        [TestMethod]
        public void DeveraFalhar_SeCategoriaNome_MenorQue2digitos()
        {
            var expected = false;
            var result = validation.ValidarNomeCategoria(CategoriaMock.CategoriaDemoInvalida().Nome);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeveraPassar_SeCategoriaNome_MaiorIgual2digitos()
        {
            var expected = true;
            var result = validation.ValidarNomeCategoria(CategoriaMock.CategoriaDemoValida().Nome);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeveraFalhar_SeCategoriaInvalida()
        {
            var expected = new Exception();
            var result = validation.IsValid(CategoriaMock.CategoriaDemoInvalida());
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeveraPassar_SeCategoriaValida()
        {
            var expected = true;
            var result = validation.IsValid(CategoriaMock.CategoriaDemoValida());
            Assert.AreEqual(expected, result);
        }

    }
}
