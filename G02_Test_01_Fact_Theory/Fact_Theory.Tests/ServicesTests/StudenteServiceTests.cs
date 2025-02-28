using FluentAssertions;
using G02_Test_01_Fact_Theory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fact_Theory.Tests.ServicesTests
{
    public class StudenteServiceTests
    {
        [Fact]
        public void StudenteService_InsertTest_ShouldReturnString()
        {
            /*
             * Guard Assertions
             * - Arrange: Inizializzazioni necessarie al test
             * - Act: Azioni e creazioni di oggetti necessari al test
             * - Assert: Verifiche dei risultati
             */

            // Arrange
            var studService = new StudenteService();

            // Act
            var result = studService.InsertTest();

            // Assert
            //Assert.Equal("SUCCESS: Ok!", result);

            // Fluent
            result.Should().NotBeNullOrEmpty();
            //result.Should().Be("SUCCESS: Ok!");
            result.Should().Contain("Ok", Exactly.Once());
        }

        [Theory]
        [InlineData("Giovanni", "Pace", "SUCCESS: Giovanni Pace")]
        [InlineData("Valeria", "Verdi", "SUCCESS: Valeria Verdi")]
        public void StudenteService_InsertStudente_ShouldReturnString(string nome, string cognome, string exp)
        {
            //Arrange
            var studService = new StudenteService();

            //Act
            var risultato = studService.InsertStudente(nome, cognome);

            //Assert
            Assert.Equal(exp, risultato);
        }
    }
}
