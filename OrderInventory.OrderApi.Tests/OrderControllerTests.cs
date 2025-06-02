using System.Net;
using System.Net.Http.Json;
using OrderInventory.OrderApi.Contracts;
using Shouldly;

namespace OrderInventory.OrderApi.Tests;

[Collection("WebApp Collection")]
public class OrderControllerTests(WebApplicationFactoryFixture fixture)
{
    private readonly HttpClient _client = fixture.Client;
    
    [Fact]
    public async Task GetOrder_WithValidId_ReturnsOrder()
    {
        // Arrange
        const int id = 42;

        // Act
        var response = await _client.GetAsync($"/orders/{id}", TestContext.Current.CancellationToken);
        
        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
        
        var order = await response.Content.ReadFromJsonAsync<OrderResponse>(cancellationToken: TestContext.Current.CancellationToken);
        order.ShouldNotBeNull();
        order.Id.ShouldBe(id);
        order.ProductId.ShouldBe($"SKU-{id:D4}");
        order.Quantity.ShouldBe(2);
        order.Status.ShouldBe("Confirmed");
    }

    [Fact]
    public async Task GetOrder_WithInvalidId_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync("/orders/1001", TestContext.Current.CancellationToken);
        
        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task CreateOrder_ReturnsCreatedOrder()
    {
        // Arrange
        const string productId = "SKU10";
        const int quantity = 5;
        var request = new OrderRequest(productId, quantity);

        // Act
        var response = await _client.PostAsJsonAsync("/orders", request, cancellationToken: TestContext.Current.CancellationToken);
        
        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.Created);
        
        var created = await response.Content.ReadFromJsonAsync<OrderResponse>(cancellationToken: TestContext.Current.CancellationToken);
        created.ShouldNotBeNull();
        created.Id.ShouldBeGreaterThan(0);
        created.Quantity.ShouldBe(quantity);
        created.Status.ShouldBe("Confirmed");
        created.ProductId.ShouldBe(productId);
    }
}