using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MinimalApi_Intro.Tests
{
    public class ProductApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public ProductApiTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task GetProducts_ShouldReturnList()
        {
            //Act
            var response = await _httpClient.GetAsync("/products");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            content.Should().Contain("Laptop Gaming").And.Contain("RAM 512MB");

            //response.EnsureSuccessStatusCode();
            //var content = await response.Content.ReadAsStringAsync();
            //Assert.Contains("Laptop Gaming", content);
            //Assert.Contains("RAM 512MB", content);
        }
        
        [Fact]
        public async Task InsertProduct_ShouldReturnOk()
        {
            //Arrange
            var newProd = new { Name = "Hard Disk", Description = "Very hard", Price = 89 };
            var jsonBody = JsonSerializer.Serialize(newProd);
            var body = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            //Act
            var response = await _httpClient.PostAsync("/products", body);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var content = await response.Content.ReadAsStringAsync();
            content.Should().Contain("Hard Disk");

            response.EnsureSuccessStatusCode();
            //var content = await response.Content.ReadAsStringAsync();
            //Assert.Contains("Hard Disk", content);



        }


    }
}
