using Collezioni_Oggetti.Models;
using Collezioni_Oggetti.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collezioni_Oggetti.Tests.ServicesTests
{
    public class StudenteServiceTests
    {
        private readonly StudenteService _service;

        public StudenteServiceTests() {
            _service = new StudenteService();
        }   

        [Theory]
        [InlineData("Giovanni", "Pace")]
        [InlineData("Valeria", "Verdi")]
        public void StudenteService_InsertStudente_ShouldReturnTrue(string nom, string cog)
        {
            //Arrange
            var exp = new Studente()
            {
                Nome = nom,
                Cognome = cog
            };

            //Act
            var countBefore = _service.NumeroStudenti();
            var risultato = _service.InsertStudente(nom, cog);
            var countAfter = _service.NumeroStudenti();

            var listaStud = _service.FindAll();

            //Assert

            risultato.Should().NotBe(false);
            countBefore.Should().BeLessThan(countAfter);

            listaStud.Should().BeOfType<List<Studente>>();
            //listaStud.Should().ContainEquivalentOf(exp);

            listaStud.Should().Contain(s => (s.Nome == exp.Nome && s.Cognome == exp.Cognome));

            //Assert.True(risultato, "Studente non aggiunto");
            //Assert.Equal(countBefore + 1, countAfter);


        }
    }
}
