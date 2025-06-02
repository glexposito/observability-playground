using Microsoft.AspNetCore.Mvc;
using OrderInventory.OrderApi.Contracts;

namespace OrderInventory.OrderApi.Controllers;

[ApiController]
[Route("orders")]
public class OrderController : ControllerBase
{
    [HttpGet("{id:int}")]
    public ActionResult<OrderResponse> GetOrder(int id)
    {
        if (id > 1000)
        {
            return NotFound();
        }

        var productId = $"SKU-{id:D4}";

        var order = new OrderResponse(
            Id: id,
            ProductId: productId,
            Quantity: 2,
            Status: "Confirmed"
        );

        return order;
    }

    [HttpPost]
    public ActionResult<OrderResponse> CreateOrder([FromBody] OrderRequest request)
    {
        var newOrderId = Random.Shared.Next(1, 1000);

        var response = new OrderResponse(
            Id: newOrderId,
            ProductId: request.ProductId,
            Quantity: request.Quantity,
            Status: "Confirmed"
        );

        return CreatedAtAction(nameof(GetOrder), new { id = response.Id }, response);
    }
}