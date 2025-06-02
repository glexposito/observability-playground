namespace OrderInventory.OrderApi.Contracts;

public record OrderRequest(
    string ProductId,
    int Quantity
);