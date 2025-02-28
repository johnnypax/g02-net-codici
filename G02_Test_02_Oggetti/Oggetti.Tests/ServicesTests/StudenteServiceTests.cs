using FluentAssertions;
using G02_Test_02_Oggetti.Models;
using G02_Test_02_Oggetti.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oggetti.Tests.ServicesTests
{
    public class StudenteServiceTests
    {
        [Theory]
        [InlineData("Giovanni", "Pace")]
        [InlineData("Valeria", "Verdi")]
        public void StudenteService_InsertStudente_ShouldReturnObject(string nom, string cog)
        {
            //Arrange
            var exp = new Studente()
            {
                Nome = nom,
                Cognome = cog
            };

            var serv = new StudenteService();

            //Act
            Studente risultato = serv.InsertStudente(nom, cog); 

            //Assert
            risultato.Should().NotBeNull();
            risultato.Nome.Should().Be(exp.Nome);
            risultato.Cognome.Should().Be(exp.Cognome);
            risultato.Matricola.Should().NotBeNullOrEmpty();

            bool isValidGuid = Guid.TryParse(risultato.Matricola, out Guid guid);
            isValidGuid.Should().BeTrue("GUID Non coerente alle specifiche");

            //Assert.NotNull(risultato);
            //Assert.Equal(exp.Nome, risultato.Nome);
            //Assert.Equal(exp.Cognome, risultato.Cognome);
            //Assert.False(string.IsNullOrEmpty(risultato.Matricola));

            //bool isValidGuid = Guid.TryParse(risultato.Matricola, out Guid guid);
            //Assert.True(isValidGuid, "GUID Non coerente alle specifiche");
        }
    }
}
