namespace OrderInventory.OrderApi.Contracts;

public record OrderResponse(
    int Id,
    string ProductId,
    int Quantity,
    string Status
);